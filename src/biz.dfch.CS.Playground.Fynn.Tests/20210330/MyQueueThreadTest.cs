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
using System.Collections.Generic;
using System.Threading;
using biz.dfch.CS.Playground.Fynn._20210330;
using biz.dfch.CS.Playground.Fynn.Tests._20210401;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210330
{
    [TestClass]
    public class MyQueueThreadTest
    {
        private ManualResetEventSlim manualResetEventSlim;

        private bool Contains<TValue>(MyQueue<TValue> queue, TValue value)
        {
            manualResetEventSlim.Wait();

            var result = queue.Contains(value);
            return result;
        }

        private void Clear<TValue>(MyQueue<TValue> queue)
        {
            manualResetEventSlim.Wait();
            
            queue.Clear();
        }

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

            var threads = new List<Thread>
            {
                new Thread(() => result = Contains(sut, lastEntry)),
                new Thread(() => Clear(sut))
            };
            var handler = new ThreadEventHandler(threads);
            manualResetEventSlim = handler.ManualResetEventSlim;

            // Act
            handler.StartThreads();
            handler.OnThreadsReady(new EventArgs());

            threads[1].Join();

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

            var threads = new List<Thread>
            {
                new Thread(() => result = sut.Peek()),
                new Thread(sut.Clear)
            };
            var handler = new ThreadEventHandler(threads);

            // Act
            handler.StartThreads();
            threads[1].Join();

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

            var threads = new List<Thread>
            {
                new Thread(() => resultPeek = sut.Peek()),
                new Thread(() => resultDequeue = sut.Dequeue())
            };
            var handler = new ThreadEventHandler(threads);

            // Act
            handler.StartThreads();
            threads[1].Join();

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

            var threads = new List<Thread>
            {
                new Thread(() => resultDequeue = sut.Dequeue()),
                new Thread(() => resultPeek = sut.Peek())
            };
            var handler = new ThreadEventHandler(threads);

            // Act
            handler.StartThreads();
            threads[1].Join();

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

            var threads = new List<Thread>
            {
                new Thread(() => result = sut.Contains(firstEntry)),
                new Thread(() => resultDequeue = sut.Dequeue())
            };
            var handler = new ThreadEventHandler(threads);

            // Act
            handler.StartThreads();
            threads[1].Join();

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(firstEntry, resultDequeue);
        }
    }
}
