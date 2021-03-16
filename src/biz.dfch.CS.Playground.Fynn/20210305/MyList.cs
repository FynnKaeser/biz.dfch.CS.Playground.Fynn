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
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace biz.dfch.CS.Playground.Fynn._20210305
{
    public class MyList<TItem> : IEnumerable<TItem> where TItem : class
    {
        private readonly int capacity;
        private MyListElement<TItem> start;
        private MyListElement<TItem> end;
        public int Count { private set; get; }

        public TItem this[int index]
        {
            get
            {
                var element = GetListElementByIndex(index);
                if (null == element)
                {
                    throw new IndexOutOfRangeException();
                }

                return element.Value;
            }
            set
            {
                var element = GetListElementByIndex(index);
                if (null == element)
                {
                    throw new IndexOutOfRangeException();
                }

                element.Value = value;
            }
        }

        public MyList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.capacity = capacity;
        }

        public int Search(TItem item)
        {
            if (null == item)
            {
                return -1;
            }

            var tempElement = start;
            var elementIndex = 0;

            while (null != tempElement)
            {
                if (item.Equals(tempElement.Value))
                {
                    return elementIndex;
                }

                tempElement = tempElement.Next;
                elementIndex++;
            }

            return -1;
        }
        
        public void Add(TItem item)
        {
            if (capacity == Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (null == item)
            {
                throw new ArgumentNullException();
            }

            var newListElement = new MyListElement<TItem>(item);

            if (null == start)
            {
                start = newListElement;
                end = newListElement;

                Count++;
            }
            else
            {
                var oldEnd = end;

                oldEnd.Next = newListElement;

                end = newListElement;
                end.Previous = oldEnd;

                Count++;
            }
        }
        
        public void Insert(int index, TItem item)
        {
            if (null == item)
            {
                throw new ArgumentNullException();
            }

            if (capacity == Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count < index || 0 > index)
            {
                throw new IndexOutOfRangeException();
            }

            if (Count == index)
            {
                Add(item);
                return;
            }

            var isIndexCloserToStart = Count < index * 2;
            var tempListElement = isIndexCloserToStart ? start : end;
            var elementIndex = isIndexCloserToStart ? 0 : Count - 1;

            while (null != tempListElement)
            {
                if (elementIndex == index)
                {
                    var newListElement = new MyListElement<TItem>(item);
                    var tempListElementPrevious = tempListElement.Previous;

                    if (null == tempListElementPrevious)
                    {
                        start = newListElement;
                        start.Next = tempListElement;
                        tempListElement.Previous = start;
                        
                        Count++;
                        return;
                    }

                    tempListElementPrevious.Next = newListElement;
                    newListElement.Previous = tempListElementPrevious;
                    newListElement.Next = tempListElement;
                    tempListElement.Previous = newListElement;
                    
                    Count++;
                    return;
                }
                
                tempListElement = isIndexCloserToStart ? tempListElement.Next : tempListElement.Previous;
                elementIndex += isIndexCloserToStart ? 1 : -1;
            }

            throw new IndexOutOfRangeException();
        }
        
        public void DeleteAt(int index)
        {
            var isValidIndex = IsValid(index);
            if (!isValidIndex) throw new IndexOutOfRangeException();

            var listElementToBeDeleted = GetListElementByIndex(index);

            if (null == listElementToBeDeleted)
            {
                throw new IndexOutOfRangeException();
            }

            var previous = listElementToBeDeleted.Previous;
            var next = listElementToBeDeleted.Next;

            SetNextElement(previous, next);
            SetPreviousElement(next, previous);

            Count--;
        }

        public void Delete(TItem item)
        {
            if (null == item)
            {
                throw new ArgumentNullException();
            }

            var tempListElement = start;

            while (null != tempListElement)
            {
                if (item.Equals(tempListElement.Value))
                {
                    var previous = tempListElement.Previous;
                    var next = tempListElement.Next;

                    SetNextElement(previous, next);
                    SetPreviousElement(next, previous);
                    
                    Count--;
                    return;
                }

                tempListElement = tempListElement.Next;
            }

            throw new InvalidOperationException();
        }

        public void DeleteList()
        {
            start = null;
            end = null;

            Count = 0;
        }
        
        public void Move(TItem item, int toIndex)
        {
            if (null == item)
            {
                throw new ArgumentNullException();
            }

            var isValidIndex = IsValid(toIndex);
            if (!isValidIndex) throw new IndexOutOfRangeException();

            var indexItem = Search(item);
            if (-1 == indexItem) throw new ArgumentOutOfRangeException();

            Move(indexItem, toIndex);
        }

        public void Move(int fromIndex, int toIndex)
        {
            var isValidFromIndex = IsValid(fromIndex);
            if (!isValidFromIndex) throw new IndexOutOfRangeException();
            var isValidToIndex = IsValid(toIndex);
            if (!isValidToIndex) throw new IndexOutOfRangeException();

            var elementToMove = GetListElementByIndex(fromIndex);
            if (null == elementToMove)
            {
                throw new IndexOutOfRangeException();
            }

            var elementToMoveNext = elementToMove.Next;
            var elementToMovePrevious = elementToMove.Previous;

            var listElementByToIndex = GetListElementByIndex(toIndex);
            if (null == listElementByToIndex)
            {
                throw new IndexOutOfRangeException();
            }

            if (fromIndex > toIndex)
            {
                var listElementPrevious = listElementByToIndex.Previous;

                if (null == listElementPrevious)
                {
                    start = elementToMove;
                    start.Previous = listElementPrevious;
                    start.Next = listElementByToIndex;
                    listElementByToIndex.Previous = start;
                }
                else
                {
                    listElementPrevious.Next = elementToMove;
                    elementToMove.Previous = listElementPrevious;
                    elementToMove.Next = listElementByToIndex;
                    listElementByToIndex.Previous = elementToMove;
                }
            }
            else
            {
                var listElementNext = listElementByToIndex.Next;

                if (null == listElementNext)
                {
                    end = elementToMove;
                    end.Next = listElementNext;
                    end.Previous = listElementByToIndex;
                    listElementByToIndex.Next = end;
                }
                else
                {
                    listElementNext.Previous = elementToMove;
                    elementToMove.Next = listElementNext;
                    elementToMove.Previous = listElementByToIndex;
                    listElementByToIndex.Next = elementToMove;
                }
            }

            SetNextElement(elementToMovePrevious, elementToMoveNext);
            SetPreviousElement(elementToMoveNext, elementToMovePrevious);
        }

        public void Swap(TItem itemOne, TItem itemTwo)
        {
            if (null == itemOne || null == itemTwo)
            {
                throw new ArgumentNullException();
            }

            var indexFirstItem = Search(itemOne);
            var indexSecondItem = Search(itemTwo);

            Swap(indexFirstItem, indexSecondItem);
        }
        
        public void Swap(int indexOne, int indexTwo)
        {
            var isValidOneIndex = IsValid(indexOne);
            if (!isValidOneIndex) throw new IndexOutOfRangeException();
            var isValidTwoIndex = IsValid(indexTwo);
            if (!isValidTwoIndex) throw new IndexOutOfRangeException();

            var listElementOne = GetListElementByIndex(indexOne);
            var listElementTwo = GetListElementByIndex(indexTwo);

            if (null == listElementOne || null == listElementTwo)
            {
                throw new IndexOutOfRangeException();
            }

            var listElementOneNext = listElementOne.Next;
            var listElementOnePrevious = listElementOne.Previous;
            var listElementTwoNext = listElementTwo.Next;
            var listElementTwoPrevious = listElementTwo.Previous;
            
            listElementOne.Next = listElementTwoNext;
            listElementTwo.Next = listElementOneNext;
            listElementOne.Previous = listElementTwoPrevious;
            listElementTwo.Previous = listElementOnePrevious;

            SetNextElement(listElementOnePrevious, listElementTwo);
            SetNextElement(listElementTwoPrevious, listElementOne);

            SetPreviousElement(listElementOneNext, listElementTwo);
            SetPreviousElement(listElementTwoNext, listElementOne);
        }

        private MyListElement<TItem> GetListElementByIndex(int index)
        {
            if (Count <= index) return null;
            if (index < 0) return null;

            var isIndexCloserToStart = Count < index * 2;
            var tempListElement = isIndexCloserToStart ? start : end;
            var elementIndex = isIndexCloserToStart ? 0 : Count - 1;

            while (null != tempListElement)
            {
                if (elementIndex == index)
                {
                    return tempListElement;
                }
                tempListElement = isIndexCloserToStart ? tempListElement.Next : tempListElement.Previous;
                elementIndex += isIndexCloserToStart ? 1 : -1;
            }

            return null;
        }
        
        private void SetNextElement(MyListElement<TItem> element, MyListElement<TItem> next)
        {
            if (null == element)
            {
                start = next;
            }
            else
            {
                element.Next = next;
            }
        }

        private void SetPreviousElement(MyListElement<TItem> element, MyListElement<TItem> previous)
        {
            if (null == element)
            {
                end = previous;
            }
            else
            {
                element.Previous = previous;
            }
        }

        private bool IsValid(int index)
        {
            return Count > index && 0 <= index;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new MyListEnumerator<TItem>(start);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class MyListEnumerator<TEnumeratorItem> : IEnumerator<TEnumeratorItem> where TEnumeratorItem : class
        {
            private MyListElement<TEnumeratorItem> start;
            private MyListElement<TEnumeratorItem> currentElement;
            private bool isDisposed;
            private readonly SafeHandle safeHandle = new SafeFileHandle(IntPtr.Zero, true);

            public MyListEnumerator(MyListElement<TEnumeratorItem> start)
            {
                this.start = start;
            }

            protected virtual void Dispose(bool disposing)
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

            public void Dispose() => Dispose(true);

            public bool MoveNext()
            {
                currentElement = null == currentElement ? start : currentElement.Next;

                return currentElement != null;
            }

            public void Reset()
            {
                currentElement = null;
            }

            public TEnumeratorItem Current => currentElement.Value;

            object IEnumerator.Current => Current;
        }
    }
}
