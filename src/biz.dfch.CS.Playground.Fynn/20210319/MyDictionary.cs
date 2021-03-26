/**
 * Copyright 2021 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace biz.dfch.CS.Playground.Fynn._20210319
{
    public class MyDictionary<TKey, TValue> : IEnumerable<Entry<TKey, TValue>>
    {
        private Entry<TKey, TValue>[] buckets;
        private readonly int capacity;

        public List<TKey> Keys { get; }
        public List<TValue> Values { get; }
        public int Count { get; private set; }

        public MyDictionary(int capacity)
        {
            Keys = new List<TKey>();
            Values = new List<TValue>();

            buckets = new Entry<TKey, TValue>[capacity];
            this.capacity = capacity;
        }

        public TValue this[TKey key]
        {
            get
            {
                var bucket = GetBucket(key);
                if (null == bucket)
                {
                    throw new KeyNotFoundException();
                }

                return bucket.Value;
            }
            set
            {
                var bucket = GetBucket(key);

                if (null == bucket)
                {
                    Insert(key, value);
                }
                else
                {
                    bucket.Value = value;
                }
            }
        }

        public void Insert(TKey key, TValue value)
        {
            if (null == key || null == value)
            {
                throw new ArgumentNullException();
            }

            if (capacity == Count)
            {
                throw new ArgumentOutOfRangeException(string.Format(MyDictionaryMessage.DictionaryIsFull, capacity));
            }

            if (HasKey(key))
            {
                throw new ArgumentException(string.Format(MyDictionaryMessage.DictionaryAlreadyContainsKey, key));
            }

            var index = Hash(key);
            if (index == -1)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var bucket = buckets[index];

            if (null == bucket)
            {
                buckets[index] = new Entry<TKey, TValue>(key, value);
            }
            else
            {
                while (null != bucket)
                {
                    if (null == bucket.Next)
                    {
                        bucket.Next = new Entry<TKey, TValue>(key, value);
                        break;
                    }

                    bucket = bucket.Next;
                }
            }

            Keys.Add(key);
            Values.Add(value);
            Count++;
        }

        public bool HasValue(TValue value)
        {
            if (null == value)
            {
                return false;
            }

            return Values.Contains(value);
        }
        
        public bool HasKey(TKey key)
        {
            if (null == key)
            {
                return false;
            }
            
            var bucket = GetBucket(key);

            return bucket != null;
        }

        public bool Delete(TKey key)
        {
            if (null == key)
            {
                return false;
            }

            var isKeyInDictionary = HasKey(key);
            if (!isKeyInDictionary)
            {
                return false;
            }

            var index = Hash(key);
            var bucket = buckets[index];

            if (key.Equals(bucket.Key))
            {
                buckets[index] = bucket.Next;
                Count--;
                return true;
            }

            var previousBucket = bucket;
            bucket = bucket.Next;

            while (bucket != null)
            {
                if (key.Equals(bucket.Key))
                {
                    previousBucket.Next = bucket.Next;
                    Count--;
                    return true;
                }

                previousBucket = bucket;
                bucket = bucket.Next;
            }

            return false;
        }

        public bool UpdateValue(TKey key, TValue newValue)
        {
            if (null == key || null == newValue)
            {
                return false;
            }

            var isKeyInDictionary = HasKey(key);
            if (!isKeyInDictionary)
            {
                return false;
            }

            var bucket = GetBucket(key);
            if (null == bucket)
            {
                return false;
            }

            Values.Remove(bucket.Value);
            bucket.Value = newValue;
            Values.Add(newValue);
            
            return true;
        }
        
        public bool UpdateKey(TKey key, TKey newKey)
        {
            if (null == key || null == newKey)
            {
                return false;
            }

            var isKeyInDictionary = HasKey(key);
            if (!isKeyInDictionary)
            {
                return false;
            }
            
            var isNewKeyAlreadyInDictionary = HasKey(newKey);
            if (isNewKeyAlreadyInDictionary)
            {
                return false;
            }

            var bucket = GetBucket(key);
            var value = bucket.Value;
            
            var isDeleted = Delete(key);

            if (!isDeleted)
            {
                return false;
            }
            Keys.Remove(key);

            Insert(newKey, value);
            Keys.Add(newKey);

            return true;
        }

        public void Clear()
        {
            Count = 0;
            buckets = new Entry<TKey, TValue>[capacity];
            Keys.Clear();
            Values.Clear();
        }

        private int Hash(TKey key)
        {
            if (null == key)
            {
                return -1;
            }

            var hash = key.GetHashCode() & 0x7FFFFFFF;

            return hash % capacity;
        }

        private Entry<TKey, TValue> GetBucket(TKey key)
        {
            var index = Hash(key);
            if (index == -1)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var bucket = buckets[index];
            if (null == bucket)
            {
                return null;
            }

            if (key.Equals(bucket.Key))
            {
                return bucket;
            }

            var bucketInChain = bucket;

            while (null != bucketInChain)
            {
                if (key.Equals(bucketInChain.Key))
                {
                    return bucketInChain;
                }

                bucketInChain = bucketInChain.Next;
            }

            return null;
        }

        public IEnumerator<Entry<TKey, TValue>> GetEnumerator()
        {
            return new MyDictionaryEnumerator<TKey, TValue>(buckets);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private sealed class MyDictionaryEnumerator<TEnumeratorKey, TEnumeratorValue> : IEnumerator<Entry<TEnumeratorKey, TEnumeratorValue>>
        {
            private readonly SafeHandle safeHandle = new SafeFileHandle(IntPtr.Zero, true);
            private readonly Entry<TEnumeratorKey, TEnumeratorValue>[] buckets;
            private readonly int bucketsLength;
            private int index = -1;
            private Entry<TEnumeratorKey, TEnumeratorValue> currentEntry;
            private bool isDisposed;

            public MyDictionaryEnumerator(Entry<TEnumeratorKey, TEnumeratorValue>[] buckets)
            {
                this.buckets = buckets.Where(entry => entry != null).ToArray();
                bucketsLength = this.buckets.Length;
            }

            private void Dispose(bool disposing)
            {
                if (isDisposed)
                {
                    return;
                }

                if (disposing)
                {
                    safeHandle?.Dispose();
                }

                isDisposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            public bool MoveNext()
            {
                if (null == currentEntry)
                {
                    index++;
                    currentEntry = buckets[index];
                }
                else
                {
                    if (null == currentEntry.Next && bucketsLength -1 != index)
                    {
                        index++;
                        currentEntry = buckets[index];
                    }
                    else
                    {
                        currentEntry = currentEntry.Next;
                    }
                }

                return bucketsLength - 1 != index || null != currentEntry;
            }

            public void Reset()
            {
                index = -1;
                currentEntry = null;
            }

            public Entry<TEnumeratorKey, TEnumeratorValue> Current => currentEntry;

            object IEnumerator.Current => Current;
        }
    }
}
