

using System;
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
namespace biz.dfch.CS.Playground.Fynn._20210329
{
    public class MyStack<TValue>
    {
        private readonly int capacity;
        private MyStackEntry<TValue> top;

        public int Count { get; set; }

        public MyStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.capacity = capacity;
        }

        public void Clear()
        {
            top = null;
            Count = 0;
        }

        public void Push(TValue value)
        {
            if (null == value)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (Count == capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            var previousTop = top;

            top = new MyStackEntry<TValue>(value)
            {
                Next = previousTop
            };
            Count++;
        }

        public TValue Peek()
        {
            if (null == top)
            {
                throw new InvalidOperationException();
            }

            return top.Value;
        }

        public TValue Pop()
        {
            if (null == top)
            {
                throw new InvalidOperationException();
            }

            var previousTop = top;
            top = top.Next;

            Count--;

            return previousTop.Value;
        }

        public bool Contains(TValue value)
        {
            if (null == value)
            {
                return false;
            }

            var currentEntry = top;

            while (null != currentEntry)
            {
                if (value.Equals(currentEntry.Value))
                {
                    return true;
                }

                currentEntry = currentEntry.Next;
            }

            return false;
        }
    }
}
