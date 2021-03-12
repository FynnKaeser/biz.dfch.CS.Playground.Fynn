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

            var resultCount = sut.Count();
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

            var expectedIndexAddAtElement = 2;
            var expectedIndexWorldElement = 3;

            // Act
            sut.AddAt(2, "AddAt");

            var resultIndexAddAtElement = sut.Search("AddAt");
            var resultIndexWorldElement = sut.Search("World");

            // Assert
            Assert.AreEqual(expectedIndexAddAtElement, resultIndexAddAtElement);
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

            var expectedIndexAddAtElement = 3;

            // Act
            sut.AddAt(3, "AddAt");
            var resultIndexAddAtElement = sut.Search("AddAt");

            // Assert
            Assert.AreEqual(expectedIndexAddAtElement, resultIndexAddAtElement);
        }

        [TestMethod]
        public void AddingElementAtStartPositionSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(3);
            sut.Add("Hello");
            sut.Add("My");

            var expectedIndexAddAtElement = 0;
            var expectedIndexHelloElement = 1;
            var expectedIndexMyElement = 2;

            // Act
            sut.AddAt(0, "AddAt");

            var resultIndexAddAtElement = sut.Search("AddAt");
            var resultIndexHelloElement = sut.Search("Hello");
            var resultIndexMyElement = sut.Search("My");

            // Assert
            Assert.AreEqual(expectedIndexAddAtElement, resultIndexAddAtElement);
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
            sut.AddAt(index, "AddAt");

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

            var resultListCount = sut.Count();

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

            var resultListCount = sut.Count();

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

            var resultListCount = sut.Count();

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

            var resultListCount = sut.Count();
            var resultIndexEngElement = sut.Search("Eng");
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
            sut.Delete("F5");

            var resultListCount = sut.Count();
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

            var resultListCount = sut.Count();
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

            // Act
            sut.DeleteList();
        
            // Assert
            Assert.AreEqual(null, sut);
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
    }  
}
