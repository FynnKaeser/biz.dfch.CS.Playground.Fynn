﻿/**
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

namespace biz.dfch.CS.Playground.Fynn._20210330
{
    public class MyQueue<TValue>
    {
        public int Count { get; private set; }
        private int capacity;
        private MyQueueEntry<TValue> head;
        private MyQueueEntry<TValue> tail;

        public MyQueue(int capacity)
        {
            this.capacity = capacity;
        }

        public void Enqueue(TValue value)
        {
            if (null == value)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (Count == capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            var entry = new MyQueueEntry<TValue>(value);

            if (null == head)
            {
                head = entry;
                tail = head;
            }

            var previousTail = tail;
            tail = entry;
            previousTail.Next = tail;
            tail.Next = head;
            Count++;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public TValue Dequeue()
        {
            throw new NotImplementedException();
        }

        public TValue Peek()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TValue value)
        {
            throw new NotImplementedException();
        }
    }
}
