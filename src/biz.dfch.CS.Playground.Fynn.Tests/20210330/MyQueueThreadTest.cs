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
using System.Threading.Tasks;
using biz.dfch.CS.Playground.Fynn._20210330;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210330
{
    [TestClass]
    public class MyQueueThreadTest
    {
        [TestMethod]
        public void LookingForEntryWhileClearingQueueReturnsTrue()
        {
            // Arrange
            var capacity = 1000000;
            var sut = new MyQueue<int>(capacity);

            for (int i = 0; i < capacity; i++)
            {
                sut.Enqueue(i);
            }

            var lastEntry = capacity - 1;

            // Act 
            var task = Task<bool>.Factory.StartNew(() => sut.Contains(lastEntry));
            sut.Clear();

            while (!task.IsCompleted)
            {
                // Wait for task
            }

            var result = task.Result;

            // Assert
            Assert.IsTrue(result);

        }
    }
}
