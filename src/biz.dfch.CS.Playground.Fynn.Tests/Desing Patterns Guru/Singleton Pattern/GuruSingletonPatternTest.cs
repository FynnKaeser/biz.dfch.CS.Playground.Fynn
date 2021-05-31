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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Singleton_Pattern;
using biz.dfch.CS.Playground.Fynn.Tests._20210401;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Desing_Patterns_Guru.Singleton_Pattern
{
    [TestClass]
    public class GuruSingletonPatternTest
    {
        private ManualResetEventSlim manualResetEventSlim;
        private int millisecondsTimeout = 5000;

        [TestMethod]
        public void InstanceOnlyGetsCreatedOnceWithMethodImplementation()
        {
            // Arrange
            var enumerationAmount = 100;
            var expectedObjectCreationCounter = 1;

            // Act
            for (int i = 0; i < enumerationAmount; i++)
            {
                GuruSingletonPattern.GetInstance();
            }

            var result = GuruSingletonPattern.MethodCreationCounter;

            // Assert
            Assert.AreEqual(expectedObjectCreationCounter, result);
        }

        [TestMethod]
        public void InstanceOnlyGetsCreatedOnceWithGetterImplementation()
        {
            // Arrange
            var enumerationAmount = 100;
            var expectedObjectCreationCounter = 1;

            // Act
            for (int i = 0; i < enumerationAmount; i++)
            {
                var temp = GuruSingletonPattern.GuruSingletonPatternObject;
            }

            var result = GuruSingletonPattern.GetterCreationCounter;

            // Assert
            Assert.AreEqual(expectedObjectCreationCounter, result);
        }

        [TestMethod]
        public void GetInstanceImplementationWithMultipleThreadsOnlyCreatesInstanceOnce()
        {
            // Arrange
            var enumerationAmount = 100;
            var expectedCreationCounter = 1;

            var threads = new List<Thread>
            {
                new Thread(() => RunGetInstanceMethodImplementation(enumerationAmount)),
                new Thread(() => RunGetInstanceMethodImplementation(enumerationAmount)),
                new Thread(() => RunGetInstanceMethodImplementation(enumerationAmount)),
                new Thread(() => RunGetInstanceMethodImplementation(enumerationAmount)),
                new Thread(() => RunGetInstanceMethodImplementation(enumerationAmount))
            };
            var handler = new ThreadHandler(threads);
            manualResetEventSlim = handler.ManualResetEventSlim;

            // Act
            handler.StartThreads();
            handler.SetStateToSignaled();
            threads[1].Join();

            var result = GuruSingletonPattern.MethodCreationCounter;

            // Assert
            Assert.AreEqual(expectedCreationCounter, result);
        }

        [TestMethod]
        public void GetterImplementationWithMultipleThreadsOnlyCreatesInstanceOnce()
        {
            // Arrange
            var enumerationAmount = 100;
            var expectedCreationCounter = 1;

            var threads = new List<Thread>
            {
                new Thread(() => RunGetterImplementation(enumerationAmount)),
                new Thread(() => RunGetterImplementation(enumerationAmount)),
                new Thread(() => RunGetterImplementation(enumerationAmount)),
                new Thread(() => RunGetterImplementation(enumerationAmount)),
                new Thread(() => RunGetterImplementation(enumerationAmount))
            };
            var handler = new ThreadHandler(threads);
            manualResetEventSlim = handler.ManualResetEventSlim;

            // Act
            handler.StartThreads();
            handler.SetStateToSignaled();
            threads[1].Join();

            var result = GuruSingletonPattern.GetterCreationCounter;

            // Assert
            Assert.AreEqual(expectedCreationCounter, result);
        }

        public void RunGetInstanceMethodImplementation(int enumerationAmount)
        {
            var isSetToSignaled = manualResetEventSlim.Wait(millisecondsTimeout);

            if (!isSetToSignaled)
            {
                throw new TimeoutException();
            }

            for (int i = 0; i < enumerationAmount; i++)
            {
                GuruSingletonPattern.GetInstance();
            }
        }

        public void RunGetterImplementation(int enumerationAmount)
        {
            var isSetToSignaled = manualResetEventSlim.Wait(millisecondsTimeout);

            if (!isSetToSignaled)
            {
                throw new TimeoutException();
            }

            for (int i = 0; i < enumerationAmount; i++)
            {
                var temp = GuruSingletonPattern.GuruSingletonPatternObject;
            }
        }
    }
}
