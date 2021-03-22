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
        private List<MyDictionaryElement<TKey, TValue>> dictionary { get; }

        public MyDictionary()
        {
            Keys = new List<TKey>();
            Values = new List<TValue>();
            dictionary = new List<MyDictionaryElement<TKey, TValue>>();
        }

        public void Insert(TKey key, TValue value)
        {
            if (null == key || null == value)
            {
                throw new ArgumentNullException();
            }

            if (HasKey(key))
            {
                throw new ArgumentException($"Dictionary already contains key '{key}'");
            }

            Keys.Add(key);
            Values.Add(value);

            var element = new MyDictionaryElement<TKey, TValue>(key, value);
            dictionary.Add(element);

            Count++;
        }

        public bool HasValue(TValue value)
        {
            throw new System.NotImplementedException();
        }
        
        public bool HasKey(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateValue(TKey key, TValue newValue)
        {
            throw new System.NotImplementedException();
        }
        
        public bool UpdateKey(TKey key, TKey newKey)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}
