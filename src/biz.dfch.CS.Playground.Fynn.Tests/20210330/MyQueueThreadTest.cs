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

using System.Threading;
using biz.dfch.CS.Playground.Fynn._20210330;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210330
{
    [TestClass]
    public class MyQueueThreadTest
    {
        [TestMethod]
        public void ClearOnNewThreadWhileLookingForEntryLooksContainsMethod()
        {
            // Arrange
            var capacity = 1000000;
            var result = false;
            var sut = new MyQueue<int>(capacity);

            for (var i = 0; i < capacity; i++)
            {
                sut.Enqueue(i);
            }

            var lastEntry = capacity - 1;

            // Act 
            var containsThread = new Thread(() => result = sut.Contains(lastEntry));
            containsThread.Start();
                     
            var clearThread = new Thread(sut.Clear);
            clearThread.Start();
            
            while (containsThread.IsAlive || clearThread.IsAlive)
            {
                // Wait for threads to complete
            }

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ClearOnNewThreadWhilePeekForEntryLooksPeekMethod()
        {
            // Arrange;
            var sut = new MyQueue<int>(1);
            var arbitraryElement = 42;
            var result = 0;

            sut.Enqueue(arbitraryElement);

            // Act 
            var peekThread = new Thread(() => result = sut.Peek());
            peekThread.Start();

            var clearThread = new Thread(sut.Clear);
            clearThread.Start();

            while (peekThread.IsAlive || clearThread.IsAlive)
            {
                // Wait for threads to complete
            }

            // Assert
            Assert.AreEqual(arbitraryElement, result);
        }

        [TestMethod]
        public void DequeueEntryOnNewThreadWhilePeekForEntryLooksPeekMethod()
        {
            // Arrange;
            var sut = new MyQueue<int>(3);
            var arbitraryElement = 42;
            var secondArbitraryElement = 142;
            var resultPeek = 0;
            var resultDequeue = 0;

            sut.Enqueue(arbitraryElement);
            sut.Enqueue(secondArbitraryElement);
            sut.Enqueue(secondArbitraryElement);

            // Act 
            var peekThread = new Thread(() => resultPeek = sut.Peek());
            peekThread.Start();

            var dequeueThread = new Thread(() => resultDequeue = sut.Dequeue());
            dequeueThread.Start();

            while (peekThread.IsAlive || dequeueThread.IsAlive)
            {
                // Wait for threads to complete
            }

            // Assert
            Assert.AreEqual(arbitraryElement, resultPeek);
            Assert.AreEqual(arbitraryElement, resultDequeue);
        }

        [TestMethod]
        public void PeekEntryOnNewThreadWhileDequeueEntryLooksDequeueMethod()
        {
            // Arrange;
            var sut = new MyQueue<int>(3);
            var arbitraryElement = 42;
            var secondArbitraryElement = 142;
            var resultPeek = 0;
            var resultDequeue = 0;

            sut.Enqueue(arbitraryElement);
            sut.Enqueue(secondArbitraryElement);
            sut.Enqueue(secondArbitraryElement);

            // Act
            var dequeueThread = new Thread(() => resultDequeue = sut.Dequeue());
            dequeueThread.Start();

            var peekThread = new Thread(() => resultPeek = sut.Peek());
            peekThread.Start();

            while (peekThread.IsAlive || dequeueThread.IsAlive)
            {
                // Wait for threads to complete
            }

            // Assert
            Assert.AreEqual(arbitraryElement, resultDequeue);
            Assert.AreEqual(secondArbitraryElement, resultPeek);
        }

        [TestMethod]
        public void DequeueEntryOnNewThreadWhileLookingForEntryLooksContainsMethod()
        {
            // Arrange
            var capacity = 1000000;
            var result = false;
            var resultDequeue = 0;
            var sut = new MyQueue<int>(capacity);

            for (var i = 0; i < capacity; i++)
            {
                sut.Enqueue(i);
            }

            var firstEntry = 0;

            // Act 
            var containsThread = new Thread(() => result = sut.Contains(firstEntry));
            containsThread.Start();

            var clearThread = new Thread(() => resultDequeue = sut.Dequeue());
            clearThread.Start();

            while (containsThread.IsAlive || clearThread.IsAlive)
            {
                // Wait for threads to complete
            }

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(firstEntry, resultDequeue);
        }
    }
}
