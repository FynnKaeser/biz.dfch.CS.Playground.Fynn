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

namespace biz.dfch.CS.Playground.Fynn._20210305
{
    public class MyList<TItem>
    {
        public MyListElement<TItem> Start { private set; get; }
        public MyListElement<TItem> End { private set; get; }

        public MyList(int capacity)
        {
        }

        public TItem Search(TItem item)
        {
            var tempElement = Start;

            while (null != tempElement)
            {
                if (item.Equals(tempElement.Value))
                {
                    return tempElement.Value;
                }

                tempElement = tempElement.Next;
            }

            return default;
        }
        
        public void Add(TItem item)
        {
            var newListElement = new MyListElement<TItem>(item);

            if (null == Start)
            {
                Start = newListElement;
                End = newListElement;
            }
            else
            {
                var oldEnd = End;

                oldEnd.Next = newListElement;

                End = newListElement;
                End.Previous = oldEnd;
            }
        }
        
        public void AddAt(int index, TItem item)
        {
            var tempListElement = Start;
            var startIndex = 0;

            while (null != tempListElement)
            {
                if (startIndex == index)
                {
                    var newListElement = new MyListElement<TItem>(item);
                    var previousCurrent = tempListElement.Previous;

                    previousCurrent.Next = newListElement;
                    newListElement.Previous = previousCurrent;
                    newListElement.Next = tempListElement;
                    tempListElement.Previous = newListElement;
                    return;
                }
                tempListElement = tempListElement.Next;
                startIndex++;
            }

            if (startIndex == index)
            {
                Add(item);
                return;
            }

            throw new ArgumentOutOfRangeException();
        }
        
        public void DeleteAt(int i)
        {
            throw new NotImplementedException();
        }
        
        public void Delete(TItem item)
        {
            throw new NotImplementedException();
        }
        
        public void DeleteList()
        {
            Start = null;
            End = null;
        }
        
        public void Move(TItem item, int toIndex)
        {
            throw new NotImplementedException();
        }
        public void Move(int fromIndex, int toIndex)
        {
            throw new NotImplementedException();
        }
        
        public void Swap(TItem itemOne, TItem itemTwo)
        {
            throw new NotImplementedException();
        }
        
        public void Swap(int indexOne, int indexTwo)
        {
            throw new NotImplementedException();
        }
    }
}
