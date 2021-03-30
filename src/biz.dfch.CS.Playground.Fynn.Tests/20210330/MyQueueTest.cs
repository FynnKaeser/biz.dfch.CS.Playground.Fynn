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
using biz.dfch.CS.Playground.Fynn._20210330;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210330
{
    [TestClass]
    public class MyQueueTest
    {
        [TestMethod]
        public void ClearQueueSucceeds()
        {
            // Arrange
            var sut = new MyQueue<int>(1);
            sut.Enqueue(1);

            var expectedCount = 0;

            // Act
            sut.Clear();
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
        }
        
        [TestMethod]
        public void DequeueEntryFromQueueSucceeds()
        {
            // Arrange
            var sut = new MyQueue<int>(4);
            sut.Enqueue(42);
            sut.Enqueue(142);
            sut.Enqueue(242);
            sut.Enqueue(342);

            var expectedCount = 3;
            var expectedResult = 42;

            // Act
            var result = sut.Dequeue();
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedCount, resultCount);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueEntryFromEmptyQueueThrowsInvalidOperationException()
        {
            // Arrange
            var sut = new MyQueue<int>(1);

            // Act
            var result = sut.Dequeue();

            // Assert
        }
        
        [TestMethod]
        public void EnqueueEntryToQueueSucceeds()
        {
            // Arrange
            var sut = new MyQueue<int>(4);
            sut.Enqueue(42);
            sut.Enqueue(142);
            sut.Enqueue(242);
            sut.Enqueue(342);

            var expectedCount = 4;
            var expectedResult = 42;

            // Act
            var result = sut.Peek();
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedCount, resultCount);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnqueueNullEntryToQueueThrowsArgumentNullException()
        {
            // Arrange
            var sut = new MyQueue<string>(1);

            // Act
            sut.Enqueue(null);

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EnqueueSecondEntryToQueueWithCapacitySetToOneThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var sut = new MyQueue<int>(1);
            sut.Enqueue(42);

            // Act
            sut.Enqueue(10);

            // Assert
        }

        [TestMethod]
        public void PeekEntryFromQueueSucceeds()
        {
            // Arrange
            var sut = new MyQueue<int>(2);
            sut.Enqueue(42);
            sut.Enqueue(128);

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
        public void PeekEntryFromEmptyQueueThrowsInvalidOperationException()
        {
            // Arrange
            var sut = new MyQueue<int>(1);

            // Act
            var result = sut.Peek();

            // Assert
        }
        
        [TestMethod]
        [DataRow(0)]
        [DataRow(-42)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetInvalidCapacityForQueueThrowsArgumentOutOfRangeException(int capacity)
        {
            // Arrange
            var sut = new MyQueue<int>(capacity);

            // Act

            // Assert
        }

        [TestMethod]
        public void ContainEntryInQueueReturnsTrue()
        {
            // Arrange
            var sut = new MyQueue<int>(2);
            sut.Enqueue(42);
            sut.Enqueue(128);

            // Act
            var result = sut.Contains(42);

            // Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void NotContainingEntryInQueueReturnsFalse()
        {
            // Arrange
            var sut = new MyQueue<int>(2);
            sut.Enqueue(42);
            sut.Enqueue(128);

            // Act
            var result = sut.Contains(100);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
