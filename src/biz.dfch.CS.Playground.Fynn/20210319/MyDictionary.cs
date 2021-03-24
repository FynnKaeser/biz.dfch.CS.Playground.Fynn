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

            if (null == buckets[index])
            {
                buckets[index] = new Entry<TKey, TValue>(key, value);
            }
            else
            {
                var bucket = buckets[index];

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

            Count++;
        }

        public bool HasValue(TValue value)
        {
            if (null == value)
            {
                return false;
            }

            throw new NotImplementedException();
        }
        
        public bool HasKey(TKey key)
        {
            if (null == key)
            {
                return false;
            }

            var index = Hash(key);
            var bucket = buckets[index];

            var nextBucketInChain = bucket.Next;

            if (null == nextBucketInChain)
            {
                return key.Equals(bucket.Key);
            }

            while (null != nextBucketInChain)
            {
                if (key.Equals(nextBucketInChain.Key))
                {
                    return true;
                }

                nextBucketInChain = nextBucketInChain.Next;
            }

            return false;
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

            Count--;
            throw new NotImplementedException();
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

            throw new NotImplementedException();
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

            throw new NotImplementedException();
        }

        public void Clear()
        {
            Count = 0;
            buckets = new Entry<TKey, TValue>[capacity];
        }

        private int Hash(TKey key)
        {
            var hash = key.GetHashCode() & 0x7FFFFFFF;

            return hash % capacity;
        }
    }
}
