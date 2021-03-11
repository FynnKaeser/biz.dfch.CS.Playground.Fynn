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
        private readonly int capacity;
        private MyListElement<TItem> start;
        private MyListElement<TItem> end;

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
            var elementCount = Count();
            if (capacity == elementCount)
            {
                throw new ArgumentOutOfRangeException();
            }

            var newListElement = new MyListElement<TItem>(item);

            if (null == start)
            {
                start = newListElement;
                end = newListElement;
            }
            else
            {
                var oldEnd = end;

                oldEnd.Next = newListElement;

                end = newListElement;
                end.Previous = oldEnd;
            }
        }
        
        public void AddAt(int index, TItem item)
        {
            var elementCount = Count();
            if (capacity == elementCount)
            {
                throw new ArgumentOutOfRangeException();
            }

            var tempListElement = start;
            var elementIndex = 0;

            while (null != tempListElement)
            {
                if (elementIndex == index)
                {
                    var newListElement = new MyListElement<TItem>(item);
                    var tempListElementPrevious = tempListElement.Previous;

                    tempListElementPrevious.Next = newListElement;
                    newListElement.Previous = tempListElementPrevious;
                    newListElement.Next = tempListElement;
                    tempListElement.Previous = newListElement;
                    return;
                }

                tempListElement = tempListElement.Next;
                elementIndex++;
            }

            if (elementIndex == index)
            {
                Add(item);
                return;
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
            previous.Next = next;
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
                    previous.Next = next;
                    next.Previous = previous;
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

                        tempListElementPrevious.Next = elementToMove;
                        elementToMove.Previous = tempListElementPrevious;
                        elementToMove.Next = tempListElement;
                        tempListElement.Previous = elementToMove;
                        break;
                    }

                    var tempListElementNext = tempListElement.Next;

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

            listElementOnePrevious.Next = listElementTwo;
            listElementTwoPrevious.Next = listElementOne;
            listElementOneNext.Previous = listElementTwo;
            listElementTwoNext.Previous = listElementOne;
        }

        public int Count()
        {
            var tempListElement = start;
            var elementIndex = 0;

            while (null != tempListElement)
            {
                tempListElement = tempListElement.Next;
                elementIndex++;
            }

            return elementIndex;
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
    }
}
