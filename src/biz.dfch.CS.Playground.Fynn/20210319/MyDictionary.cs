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
        public int Count { get; private set; }
        public List<TKey> Keys { get; }
        public List<TValue> Values { get; }
        private Entry<TKey, TValue>[] entries;

        public MyDictionary(int capacity)
        {
            Keys = new List<TKey>();
            Values = new List<TValue>();
            entries = new Entry<TKey, TValue>[capacity];
        }

        public void Insert(TKey key, TValue value)
        {
            if (null == key || null == value)
            {
                throw new ArgumentNullException();
            }

            if (HasKey(key))
            {
                throw new ArgumentException(string.Format(MyDictionaryMessage.DictionaryAlreadyContainsKey, key));
            }

            Keys.Add(key);
            Values.Add(value);

            var element = new Entry<TKey, TValue>(key, value);
            dictionary.Add(element);

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

            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
