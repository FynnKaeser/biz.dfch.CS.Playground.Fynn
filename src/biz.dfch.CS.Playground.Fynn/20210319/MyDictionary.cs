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
using System.Collections.Generic;

namespace biz.dfch.CS.Playground.Fynn._20210319
{
    public class MyDictionary<TKey, TValue>
    {
        private Entry<TKey, TValue>[] buckets;
        private int capacity;

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
                buckets[index] = null;
                Count--;
                return true;
            }

            while (bucket != null)
            {
                if (key.Equals(bucket.Key))
                {
                    throw new NotImplementedException();
                }

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
    }
}
