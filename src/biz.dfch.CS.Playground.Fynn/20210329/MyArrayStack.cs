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

namespace biz.dfch.CS.Playground.Fynn._20210329
{
    public class MyArrayStack<TValue> : IMyStackInterface<TValue>
    {
        private readonly int capacity;
        private int top;
        private TValue[] elements;

        public int Count { get; private set; }

        public MyArrayStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.capacity = capacity;
            top = -1;
            elements = new TValue[capacity];
        }

        public void Clear()
        {
            elements = new TValue[capacity];
            top = -1;
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

            elements[++top] = value;
            Count++;
        }

        public TValue Peek()
        {
            if (Count < 1)
            {
                throw new InvalidOperationException();
            }

            return elements[top];
        }

        public TValue Pop()
        {
            if (Count < 1)
            {
                throw new InvalidOperationException();
            }

            var value = elements[top--];
            Count--;
            return value;
        }

        public bool Contains(TValue value)
        {
            if (null == value)
            {
                return false;
            }

            if (Count < 1)
            {
                return false;
            }

            for (int i = 0; i <= top; i++)
            {
                var currentElement = elements[i];

                if (currentElement.Equals(value))
                {
                    return true;
                }
            }
            return true;
        }
    }
}
