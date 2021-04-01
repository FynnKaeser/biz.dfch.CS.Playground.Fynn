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
using System.Threading;
using biz.dfch.CS.Playground.Fynn._20210401;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210401
{
    [TestClass]
    public class MultiThreadingTest
    {
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void CallingUnsafeDivideMethodWithTwoThreadsThrowsDividedByZeroException()
        {
            // Arrange
            var sut = new MultiThreading();
            var thread = new Thread(sut.UnsafeDivide);

            // Act
            thread.Start();
            sut.UnsafeDivide();

            // Assert
        }
        
        [TestMethod]
        public void CallingSafeDivideMethodWithTwoThreadsSucceeds()
        {
            // Arrange
            var sut = new MultiThreading();
            var thread = new Thread(sut.SafeDivide);

            // Act
            thread.Start();
            sut.SafeDivide();

            // Assert
        }
        
        [TestMethod]
        public void CallingFunctionsSynchronously()
        {
            // Arrange
            var sut = new MultiThreading();

            // Act
            sut.Function1();
            sut.Function2();

            // Assert
        }
        
        [TestMethod]
        public void CallingFunctionsInMultiThreadedWay()
        {
            // Arrange
            var sut = new MultiThreading();
            var thread1 = new Thread(sut.Function1);
            var thread2 = new Thread(sut.Function2);

            // Act
            thread1.Start();
            thread2.Start();

            while (thread2.IsAlive)
            {
                // Wait For Threads to finish
            }

            // Assert
        }
    }
}
