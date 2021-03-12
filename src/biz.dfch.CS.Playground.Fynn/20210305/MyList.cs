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

namespace biz.dfch.CS.Playground.Fynn._20210305
{
    public class MyList<TItem> : IEnumerable<TItem>
    {
        private readonly int capacity;
        private MyListElement<TItem> start;
        private MyListElement<TItem> end;
        public int Count { private set; get; }

        public MyList(int capacity)
        {
            this.capacity = capacity;
        }

        public int Search(TItem item)
        {
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
        
        public void AddAt(int index, TItem item)
        {
            if (capacity == Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count < index)
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
            var listElementToBeDeleted = GetListElementByIndex(index);

            if (null == listElementToBeDeleted)
            {
                throw new IndexOutOfRangeException();
            }

            var previous = listElementToBeDeleted.Previous;
            var next = listElementToBeDeleted.Next;

            if (null == previous)
            {
                start = next;
            }
            else
            {
                previous.Next = next;
            }

            if (null == next)
            {
                end = previous;

                Count--;
                return;
            }

            Count--;
            next.Previous = previous;
        }

        public void Delete(TItem item)
        {
            var tempListElement = start;

            while (null != tempListElement)
            {
                if (item.Equals(tempListElement.Value))
                {
                    var previous = tempListElement.Previous;
                    var next = tempListElement.Next;

                    if (null == previous)
                    {
                        start = next;
                    }
                    else
                    {
                        previous.Next = next;
                    }

                    if (null == next)
                    {
                        end = previous;

                        Count--;
                        return;
                    }

                    next.Previous = previous;

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
            var indexItem = Search(item);

            Move(indexItem, toIndex);
        }

        public void Move(int fromIndex, int toIndex)
        {
            var elementToMove = GetListElementByIndex(fromIndex);
            if (null == elementToMove)
            {
                throw new IndexOutOfRangeException();
            }

            var tempListElement = start;
            var elementIndex = 0;
            var elementToMoveNext = elementToMove.Next;
            var elementToMovePrevious = elementToMove.Previous;

            while (null != tempListElement)
            {
                if (elementIndex == toIndex)
                {
                    if (fromIndex > toIndex)
                    {
                        var tempListElementPrevious = tempListElement.Previous;

                        if (null == tempListElementPrevious)
                        {
                            start = elementToMove;
                            start.Previous = tempListElementPrevious;
                            start.Next = tempListElement;
                            tempListElement.Previous = start;
                            break;
                        }

                        tempListElementPrevious.Next = elementToMove;
                        elementToMove.Previous = tempListElementPrevious;
                        elementToMove.Next = tempListElement;
                        tempListElement.Previous = elementToMove;
                        break;
                    }

                    var tempListElementNext = tempListElement.Next;

                    if (null == tempListElementNext)
                    {
                        end = elementToMove;
                        end.Next = tempListElementNext;
                        end.Previous = tempListElement;
                        tempListElement.Next = end;
                        break;
                    }

                    tempListElementNext.Previous = elementToMove;
                    elementToMove.Next = tempListElementNext;
                    elementToMove.Previous = tempListElement;
                    tempListElement.Next = elementToMove;
                    break;
                }

                tempListElement = tempListElement.Next;
                elementIndex++;
            }

            if (null == elementToMovePrevious)
            {
                start = elementToMoveNext;
            }
            else
            {
                elementToMovePrevious.Next = elementToMoveNext;
            }
            
            if (null == elementToMoveNext)
            {
                end = elementToMovePrevious;
            }
            else
            {
                elementToMoveNext.Previous = elementToMovePrevious;
            }
        }
        
        public void Swap(TItem itemOne, TItem itemTwo)
        {
            var indexFirstItem = Search(itemOne);
            var indexSecondItem = Search(itemTwo);

            Swap(indexFirstItem, indexSecondItem);
        }
        
        public void Swap(int indexOne, int indexTwo)
        {
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

            if (null == listElementTwo.Previous)
            {
                start = listElementTwo;
            }
            else
            {
                listElementOnePrevious.Next = listElementTwo;
            }

            if (null == listElementTwoPrevious)
            {
                start = listElementOne;
            }
            else
            {
                listElementTwoPrevious.Next = listElementOne;
            }

            if (null == listElementOneNext)
            {
                end = listElementTwo;
            }
            else
            {
                listElementOneNext.Previous = listElementTwo;
            }

            if (null == listElementTwoNext)
            {
                end = listElementOne;
            }
            else
            {
                listElementTwoNext.Previous = listElementOne;
            }
        }

        private MyListElement<TItem> GetListElementByIndex(int index)
        {
            var tempListElement = start;
            var elementIndex = 0;

            while (null != tempListElement)
            {
                if (elementIndex == index)
                {
                    return tempListElement;
                }
                tempListElement = tempListElement.Next;
                elementIndex++;
            }

            return null;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new MyListEnumerator<TItem>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class MyListEnumerator<TEnumeratorItem> : IEnumerator<TEnumeratorItem>
        {
            public MyListEnumerator(MyList<TEnumeratorItem> myList)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public TEnumeratorItem Current { get; }

            object IEnumerator.Current => Current;
        }
    }
}
