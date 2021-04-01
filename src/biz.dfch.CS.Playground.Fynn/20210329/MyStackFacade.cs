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
    public class MyStackFacade<TValue>
    {
        private readonly IMyStackInterface<TValue> myStack;
        private readonly int threshold = 100;

        public int Count => myStack.Count;

        public MyStackFacade(int capacity)
        {
            if (capacity > threshold)
            {
                myStack = new MyStack<TValue>(capacity);
            }
            else
            {
                myStack = new MyArrayStack<TValue>(capacity);
            }
        }

        public void Clear()
        {
            myStack.Clear();
        }

        public void Push(TValue value)
        {
            myStack.Push(value);
        }

        public TValue Peek()
        {
            return myStack.Peek();
        }

        public TValue Pop()
        {
            return myStack.Pop();
        }

        public bool Contains(TValue value)
        {
            return myStack.Contains(value);
        }
    }
}
