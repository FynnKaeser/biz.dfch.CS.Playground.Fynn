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
using biz.dfch.CS.Playground.Fynn._20210305;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210305
{
    [TestClass]
    public class MyListTest
    {
        [TestMethod]
        public void SearchForElementInListReturnsElement()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("World");
            sut.Add("Helmet");
            sut.Add("Breakpoint");

            // Act
            var result = sut.Search("World");

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SearchForElementWhichDoesNotExistReturnsMinusOne()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("World");
            sut.Add("Helmet");
            sut.Add("Breakpoint");

            // Act
            var result = sut.Search("Console");

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void AddingElementsSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(4);
            var expectedCount = 4;
            var expectedIndexElementOne = 0;
            var expectedIndexElementTwo = 1;
            var expectedIndexElementThree = 2;
            var expectedIndexElementFour = 3;

            // Act
            sut.Add("1");
            sut.Add("2");
            sut.Add("3");
            sut.Add("4");

            var resultCount = sut.Count;
            var resultIndexElementOne = sut.Search("1");
            var resultIndexElementTwo = sut.Search("2");
            var resultIndexElementThree = sut.Search("3");
            var resultIndexElementFour = sut.Search("4");

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
            Assert.AreEqual(expectedIndexElementOne, resultIndexElementOne);
            Assert.AreEqual(expectedIndexElementTwo, resultIndexElementTwo);
            Assert.AreEqual(expectedIndexElementThree, resultIndexElementThree);
            Assert.AreEqual(expectedIndexElementFour, resultIndexElementFour);

        }
        
        [TestMethod]
        public void AddingElementAtPositionThreeSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(4);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("World");

            var expectedIndexInsertElement = 2;
            var expectedIndexWorldElement = 3;

            // Act
            sut.Insert(2, "Insert");

            var resultIndexInsertElement = sut.Search("Insert");
            var resultIndexWorldElement = sut.Search("World");

            // Assert
            Assert.AreEqual(expectedIndexInsertElement, resultIndexInsertElement);
            Assert.AreEqual(expectedIndexWorldElement, resultIndexWorldElement);
        }

        [TestMethod]
        public void AddingElementAtEndPositionSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(4);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("World");

            var expectedIndexInsertElement = 3;

            // Act
            sut.Insert(3, "Insert");
            var resultIndexInsertElement = sut.Search("Insert");

            // Assert
            Assert.AreEqual(expectedIndexInsertElement, resultIndexInsertElement);
        }

        [TestMethod]
        public void AddingElementAtStartPositionSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("Hello");
            sut.Add("My");

            var expectedIndexInsertElement = 0;
            var expectedIndexHelloElement = 1;
            var expectedIndexMyElement = 2;

            // Act
            sut.Insert(0, "Insert");

            var resultIndexInsertElement = sut.Search("Insert");
            var resultIndexHelloElement = sut.Search("Hello");
            var resultIndexMyElement = sut.Search("My");

            // Assert
            Assert.AreEqual(expectedIndexInsertElement, resultIndexInsertElement);
            Assert.AreEqual(expectedIndexHelloElement, resultIndexHelloElement);
            Assert.AreEqual(expectedIndexMyElement, resultIndexMyElement);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(4)]
        [DataRow(42)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddingElementOutsideIndexRangeThrowsIndexOutOfRangeException(int index)
        {
            // Arrange
            var sut = new MyList<string>(4);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("World");

            // Act
            sut.Insert(index, "Insert");

            // Assert
        }
        
        [TestMethod]
        public void DeletingElementAtPositionThreeFromListSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");
            sut.Add("World");

            var expectedListCount = 4;
            var expectedIndexEngElement = 2;

            // Act
            sut.DeleteAt(2);
            var resultIndexEngElement = sut.Search("ENG");

            var resultListCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedListCount, resultListCount);
            Assert.AreEqual(expectedIndexEngElement, resultIndexEngElement);
        }
        
        [TestMethod]
        public void DeletingElementAtStartPositionSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");
            sut.Add("World");

            var expectedListCount = 4;
            var expectedIndexMyElement = 0;

            // Act
            sut.DeleteAt(0);
            var resultIndexMyElement = sut.Search("My");

            var resultListCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedListCount, resultListCount);
            Assert.AreEqual(expectedIndexMyElement, resultIndexMyElement);
        }
        
        [TestMethod]
        public void DeletingElementAtEndPositionSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");
            sut.Add("World");

            var expectedListCount = 4;
            var expectedIndexWorldElement = -1;

            // Act
            sut.DeleteAt(4);
            var resultIndexWorldElement = sut.Search("World");

            var resultListCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedListCount, resultListCount);
            Assert.AreEqual(expectedIndexWorldElement, resultIndexWorldElement);
        }

        [TestMethod]
        public void DeletingElementFromListSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");
            sut.Add("World");

            var expectedListCount = 4;
            var expectedIndexEngElement = 2;
            var expectedIndexF5Element = -1;

            // Act
            sut.Delete("F5");

            var resultListCount = sut.Count;
            var resultIndexEngElement = sut.Search("ENG");
            var resultIndexF5Element = sut.Search("F5");

            // Assert
            Assert.AreEqual(expectedListCount, resultListCount);
            Assert.AreEqual(expectedIndexEngElement, resultIndexEngElement);
            Assert.AreEqual(expectedIndexF5Element, resultIndexF5Element);
        }

        [TestMethod]
        public void DeletingStartElementFromListSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");
            sut.Add("World");

            var expectedListCount = 4;
            var expectedIndexMyElement = 0;
            var expectedIndexHelloElement = -1;

            // Act
            sut.Delete("Hello");

            var resultListCount = sut.Count;
            var resultIndexMyElement = sut.Search("My");
            var resultIndexHelloElement = sut.Search("Hello");

            // Assert
            Assert.AreEqual(expectedListCount, resultListCount);
            Assert.AreEqual(expectedIndexMyElement, resultIndexMyElement);
            Assert.AreEqual(expectedIndexHelloElement, resultIndexHelloElement);
        }
        
        [TestMethod]
        public void DeletingEndElementFromListSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");
            sut.Add("World");

            var expectedListCount = 4;
            var expectedIndexWorldElement = -1;

            // Act
            sut.Delete("World");

            var resultListCount = sut.Count;
            var resultIndexWorldElement = sut.Search("World");

            // Assert
            Assert.AreEqual(expectedListCount, resultListCount);
            Assert.AreEqual(expectedIndexWorldElement, resultIndexWorldElement);
        }

        [TestMethod]
        public void DeletingListSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");

            var expectedListCount = 0;

            // Act
            sut.DeleteList();

            var resultListCount = sut.Count;
        
            // Assert
            Assert.AreEqual(expectedListCount, resultListCount);
        }
        
        [TestMethod]
        public void MovingStartElementToIndexThreeSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");
            sut.Add("World");

            var expectedIndexMovedElement = 3;
            var expectedIndexMyElement = 0;

            // Act
            sut.Move("Hello", 3);

            var resultIndexMovedElement = sut.Search("Hello");
            var resultIndexMyElement = sut.Search("My");

            // Assert
            Assert.AreEqual(expectedIndexMovedElement, resultIndexMovedElement);
            Assert.AreEqual(expectedIndexMyElement, resultIndexMyElement);
        }
        
        [TestMethod]
        public void MovingElementToStartIndexSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");
            sut.Add("World");

            var expectedIndexMovedElement = 0;
            var expectedIndexHelloElement = 1;
            var expectedIndexMyElement = 2;

            // Act
            sut.Move("F5", 0);

            var resultIndexMovedElement = sut.Search("F5");
            var resultIndexHelloElement = sut.Search("Hello");
            var resultIndexMyElement = sut.Search("My");

            // Assert
            Assert.AreEqual(expectedIndexMovedElement, resultIndexMovedElement);
            Assert.AreEqual(expectedIndexHelloElement, resultIndexHelloElement);
            Assert.AreEqual(expectedIndexMyElement, resultIndexMyElement);
        }

        [TestMethod]
        public void SwitchingStartElementWithElementAtIndexThreeSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");
            sut.Add("World");

            var expectedIndexHelloElement = 3;
            var expectedIndexEngElement = 0;

            // Act
            sut.Swap(0, 3);

            var resultIndexHelloElement = sut.Search("Hello");
            var resultIndexEngElement= sut.Search("ENG");

            // Assert
            Assert.AreEqual(expectedIndexHelloElement, resultIndexHelloElement);
            Assert.AreEqual(expectedIndexEngElement, resultIndexEngElement);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingFifthElementToListWithCapacityOfFourThrowsException()
        {
            // Arrange
            var sut = new MyList<string>(4);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG"); ;
        
            // Act
            sut.Add("Bad");
        
            // Assert
        }

        [TestMethod]
        public void IteratingOverListWithForeachSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(4);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");

            var expectedIndex = 0;

            // Act & Assert
            foreach (var element in sut)
            {
                var indexOfSearchedElement = sut.Search(element);
                Assert.AreEqual(expectedIndex, indexOfSearchedElement);
                expectedIndex++;
            }
        }
        
        [TestMethod]
        public void AddingElementsToListWithAddHasCorrectCount()
        {
            // Arrange
            var sut = new MyList<string>(4);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("F5");
            sut.Add("ENG");

            var expectedCount = 4;

            // Act
            var result = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, result);
        }
        
        [TestMethod]
        public void AddingElementsToListWithAddAtHasCorrectCount()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Insert(0, "Hello");
            sut.Insert(0, "My");
            sut.Insert(0, "World");

            var expectedCount = 3;

            // Act
            var result = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [TestMethod]
        public void DeletingElementsFromListWithDeleteHasCorrectCount()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("World");

            var expectedCount = 2;

            // Act
            sut.Delete("World");
            var result = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [TestMethod]
        public void DeletingElementsFromListWithDeleteAtHasCorrectCount()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("World");

            var expectedCount = 2;

            // Act
            sut.DeleteAt(1);
            var result = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [TestMethod]
        public void DeletingListSetsCountToZeroSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("World");

            var expectedCount = 0;

            // Act
            sut.DeleteList();
            var result = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [TestMethod]
        public void SearchForMyClassElementReturnsExpectedIndex()
        {
            // Arrange
            var myFirstTestClass = new MyTestClass();
            var mySecondTestClass = new MyTestClass();

            var sut = new MyList<MyTestClass>(2);
            sut.Add(myFirstTestClass);
            sut.Add(mySecondTestClass);

            var expectedIndexSecondTestClassElement = 1;

            // Act
            var result = sut.Search(mySecondTestClass);
            
            // Assert
            Assert.AreEqual(expectedIndexSecondTestClassElement, result);
        }

        [TestMethod]
        public void SearchForMyEqualsClassElementReturnsExpectedIndex()
        {
            // Arrange
            var myFirstEqualsTestClass = new MyEqualsTestClass
            {
                MyString = "Hallo",
                MyInt = 10,
                MyDouble = 2.11d,
                MyChar = 'c',
                MyBool = false
            };
            var mySecondEqualsTestClass = new MyEqualsTestClass
            {
                MyString = "Peter",
                MyInt = 15,
                MyDouble = 6.41d,
                MyChar = 'm',
                MyBool = true
            };

            var sut = new MyList<MyEqualsTestClass>(2);
            sut.Add(myFirstEqualsTestClass);
            sut.Add(mySecondEqualsTestClass);

            var expectedIndexSecondEqualsTestClassElement = 1;

            // Act
            var result = sut.Search(mySecondEqualsTestClass);

            // Assert
            Assert.AreEqual(expectedIndexSecondEqualsTestClassElement, result);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(-42)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateListWithInvalidCapacityThrowsArgumentOutOfRangeException(int capacity)
        {
            // Arrange
            // Act
            var sut = new MyList<string>(capacity);

            // Assert
        }

        [TestMethod]
        public void InvokingSearchMethodWithNullReturnsNegativeOneIndex()
        {
            // Arrange
            var sut = new MyList<string>(1);
            var expectedIndex = -1;

            // Act
            var result = sut.Search(null);

            // Assert
            Assert.AreEqual(expectedIndex, result);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvokingAddMethodWithNullThrowsArgumentNullException()
        {
            // Arrange
            var sut = new MyList<string>(1);

            // Act
            sut.Add(null);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvokingInsertMethodWithNullThrowsArgumentNullException()
        {
            // Arrange
            var sut = new MyList<string>(1);

            // Act
            sut.Insert(0, null);

            // Assert
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(2)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InvokingInsertAtWithInvalidIndexThrowsIndexOutOfRangeException(int index)
        {
            // Arrange
            var sut = new MyList<string>(1);

            // Act
            sut.DeleteAt(index);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvokingDeleteMethodWithNullThrowsArgumentNullException()
        {
            // Arrange
            var sut = new MyList<string>(1);

            // Act
            sut.Delete(null);

            // Assert
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(2)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InvokingDeleteAtWithInvalidIndexThrowsIndexOutOfRangeException(int index)
        {
            // Arrange
            var sut = new MyList<string>(1);

            // Act
            sut.DeleteAt(index);

            // Assert
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(3)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InvokingMoveWithInvalidIndexThrowsIndexOutOfRangeException(int index)
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");

            // Act
            sut.Move("A", index);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvokingMoveWithNullThrowsArgumentNullException()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");

            // Act
            sut.Move(null, 1);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvokingSwapWithNullThrowsArgumentNullException()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");

            // Act
            sut.Swap(null, "A");

            // Assert
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(3)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InvokingSwapWithInvalidIndexThrowsIndexOutOfRangeException(int index)
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");

            // Act
            sut.Swap(1, index);

            // Assert
        }

        [TestMethod]
        public void UsingIndexersOnListReturnsValueOfElement()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");
            sut.Add("D");
            sut.Add("E");

            var expectedValue = "C";

            // Act
            var result = sut[2];

            // Assert
            Assert.AreEqual(expectedValue, result);
        }


        [TestMethod]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(5)]
        [DataRow(42)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void UsingIndexersOnListWithInvalidIndexThrowsNullReferenceException(int index)
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");
            sut.Add("D");
            sut.Add("E");

            // Act
            var result = sut[index];

            // Assert
        }

        [TestMethod]
        public void SettingElementUsingIndexersOnListSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");
            sut.Add("D");
            sut.Add("E");

            var expectedValue = 2;
            var expectedCount = 5;

            // Act
            sut[2] = "Indexer";

            var result = sut.Search("Indexer");
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedValue, result);
            Assert.AreEqual(expectedCount, resultCount);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(5)]
        [DataRow(42)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SettingElementUsingIndexersWithInValidIndexesThrowsNullReferenceException(int index)
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");
            sut.Add("D");
            sut.Add("E");

            // Act
            sut[index] = "Indexer";

            // Assert
        }

        [TestMethod]
        public void DeleteElementAtMiddleIndexSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(5);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");
            sut.Add("D");
            sut.Add("E");

            var expectedIndex = 2;
            var expectedCount = 4;

            // Act
            sut.DeleteAt(2);

            var resultIndex = sut.Search("D");
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedIndex, resultIndex);
            Assert.AreEqual(expectedCount, resultCount);
        }

        [TestMethod]
        public void IteratingOverListWithStartEqualToNullSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(1);
            var count = 0;
            var expectedCount = 0;

            // Act
            foreach (var s in sut)
            {
                count++;
            }

            // Assert
            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void ResetOfEnumeratorSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(4);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");
            sut.Add("D");

            var expectedResult = "A";

            var enumerator = sut.GetEnumerator();
            enumerator.MoveNext();
            enumerator.MoveNext();
            enumerator.MoveNext();

            // Act
            enumerator.Reset();
            enumerator.MoveNext();
            var result = enumerator.Current;

            // Assert
            Assert.AreEqual(expectedResult, result);
            enumerator.Dispose();
        }

        [TestMethod]
        public void MoveNextOfEnumeratorSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(4);
            sut.Add("A");
            sut.Add("B");
            sut.Add("C");
            sut.Add("D");

            var expectedResult = "B";

            var enumerator = sut.GetEnumerator();

            // Act
            enumerator.MoveNext();
            enumerator.MoveNext();
            var result = enumerator.Current;

            // Assert
            Assert.AreEqual(expectedResult, result);
            enumerator.Dispose();
        }
    }  
}
