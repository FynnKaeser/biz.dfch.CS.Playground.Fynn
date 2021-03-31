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
using biz.dfch.CS.Playground.Fynn._20210329;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210329
{
    [TestClass]
    public class MyStackTest
    {
        [TestMethod]
        public void ClearStackSucceeds()
        {
            // Arrange
            var sut = new MyStack<int>(1);
            var arbitraryElement = 42;
            sut.Push(arbitraryElement);

            var expectedCount = 0;

            // Act
            sut.Clear();
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
        } 
        
        [TestMethod]
        public void PeekEntrySucceeds()
        {
            // Arrange
            var sut = new MyStack<int>(2);
            var arbitraryElement = 4;
            var arbitraryElementTwo = 42;
            sut.Push(arbitraryElement);
            sut.Push(arbitraryElementTwo);

            var expectedCount = 2;
            var expectedResult = 42;

            // Act
            var result = sut.Peek();
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedCount, resultCount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekEntryWhenStackIsEmptyThrowsInvalidOperationException()
        {
            // Arrange
            var sut = new MyStack<int>(1);

            // Act
            var result = sut.Peek();

            // Assert
        }

        [TestMethod]
        public void PopEntrySucceeds()
        {
            // Arrange
            var sut = new MyStack<int>(2);
            var arbitraryElement = 4;
            var arbitraryElementTwo = 42;
            sut.Push(arbitraryElement);
            sut.Push(arbitraryElementTwo);

            var expectedCount = 1;
            var expectedResult = 42;

            // Act
            var result = sut.Pop();
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedCount, resultCount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopEntryWhenStackIsEmptyThrowsInvalidOperationException()
        {
            // Arrange
            var sut = new MyStack<int>(1);

            // Act
            var result = sut.Pop();

            // Assert
        }

        [TestMethod]
        public void PushEntrySucceeds()
        {
            // Arrange
            var sut = new MyStack<int>(1);
            var arbitraryElement = 42;
            var expectedCount = 1;

            // Act
            sut.Push(arbitraryElement);

            var resultCount = sut.Count;
            var containsValue = sut.Contains(arbitraryElement);

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
            Assert.IsTrue(containsValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PushNullEntryToStackThrowsArgumentNullException()
        {
            // Arrange
            var sut = new MyStack<string>(1);

            // Act
            sut.Push(null);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PushEntryWhenStackIsFullThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var sut = new MyStack<int>(1);
            var arbitraryElement = 42;
            var arbitraryElementWhenStackIsFull = 4;
            sut.Push(arbitraryElement);

            // Act
            sut.Push(arbitraryElementWhenStackIsFull);

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreatingStackWithNegativeCapacityThrowsArgumentOutOfRangeException()
        {
            // Arrange

            // Act
            var sut = new MyStack<int>(-1);

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreatingStackWithZeroCapacityThrowsArgumentOutOfRangeException()
        {
            // Arrange

            // Act
            var sut = new MyStack<int>(0);

            // Assert
        }
    }
}
