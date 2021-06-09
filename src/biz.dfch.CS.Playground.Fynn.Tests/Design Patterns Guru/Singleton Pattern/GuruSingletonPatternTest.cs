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

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Singleton_Pattern
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
            var singletonInstances = new List<GuruSingletonPattern>();

            // Act
            for (int i = 0; i < enumerationAmount; i++)
            {
                singletonInstances.Add(GuruSingletonPattern.GetInstance());
            }

            // Assert
            for (int i = 0; i < singletonInstances.Count; i++)
            {
                if (i == 0) continue;

                var currentInstance = singletonInstances[i];
                var previousInstance = singletonInstances[i - 1];

                var areEqual = object.ReferenceEquals(currentInstance, previousInstance);
                Assert.IsTrue(areEqual);
            }
        }

        [TestMethod]
        public void InstanceOnlyGetsCreatedOnceWithGetterImplementation()
        {
            // Arrange
            var enumerationAmount = 100;
            var singletonInstances = new List<GuruSingletonPattern>();

            // Act
            for (int i = 0; i < enumerationAmount; i++)
            {
                singletonInstances.Add(GuruSingletonPattern.GuruSingletonPatternObject);
            }

            // Assert
            for (int i = 0; i < singletonInstances.Count; i++)
            {
                if (i == 0) continue;

                var currentInstance = singletonInstances[i];
                var previousInstance = singletonInstances[i - 1];

                var areEqual = object.ReferenceEquals(currentInstance, previousInstance);
                Assert.IsTrue(areEqual);
            }
        }

        [TestMethod]
        public void GetInstanceImplementationWithMultipleThreadsOnlyCreatesInstanceOnce()
        {
            // Arrange
            var enumerationAmount = 100;
            var singletonInstances = new List<GuruSingletonPattern>();
            
            var threads = new List<Thread>
            {
                new Thread(() => singletonInstances = RunGetInstanceMethodImplementation(enumerationAmount)),
                new Thread(() => singletonInstances.AddRange(RunGetInstanceMethodImplementation(enumerationAmount))),
                new Thread(() => singletonInstances.AddRange(RunGetInstanceMethodImplementation(enumerationAmount))),
                new Thread(() => singletonInstances.AddRange(RunGetInstanceMethodImplementation(enumerationAmount))),
                new Thread(() => singletonInstances.AddRange(RunGetInstanceMethodImplementation(enumerationAmount)))
            };
            var handler = new ThreadHandler(threads);
            manualResetEventSlim = handler.ManualResetEventSlim;

            // Act
            handler.StartThreads();
            handler.SetStateToSignalled();
            threads[1].Join();
            
            // Assert
            for (int i = 0; i < singletonInstances.Count; i++)
            {
                if (i == 0) continue;

                var currentInstance = singletonInstances[i];
                var previousInstance = singletonInstances[i - 1];

                var areEqual = object.ReferenceEquals(currentInstance, previousInstance);
                Assert.IsTrue(areEqual);
            }
        }

        [TestMethod]
        public void GetterImplementationWithMultipleThreadsOnlyCreatesInstanceOnce()
        {
            // Arrange
            var enumerationAmount = 100;

            var singletonInstances = new List<GuruSingletonPattern>();

            var threads = new List<Thread>
            {
                new Thread(() => singletonInstances = RunGetterImplementation(enumerationAmount)),
                new Thread(() => singletonInstances.AddRange(RunGetterImplementation(enumerationAmount))),
                new Thread(() => singletonInstances.AddRange(RunGetterImplementation(enumerationAmount))),
                new Thread(() => singletonInstances.AddRange(RunGetterImplementation(enumerationAmount))),
                new Thread(() => singletonInstances.AddRange(RunGetterImplementation(enumerationAmount)))
            };
            var handler = new ThreadHandler(threads);
            manualResetEventSlim = handler.ManualResetEventSlim;

            // Act
            handler.StartThreads();
            handler.SetStateToSignalled();
            threads[1].Join();

            // Assert
            for (int i = 0; i < singletonInstances.Count; i++)
            {
                if (i == 0) continue;

                var currentInstance = singletonInstances[i];
                var previousInstance = singletonInstances[i - 1];

                var areEqual = object.ReferenceEquals(currentInstance, previousInstance);
                Assert.IsTrue(areEqual);
            }
        }

        public List<GuruSingletonPattern> RunGetInstanceMethodImplementation(int enumerationAmount)
        {
            var isSetToSignaled = manualResetEventSlim.Wait(millisecondsTimeout);

            if (!isSetToSignaled)
            {
                throw new TimeoutException();
            }

            var singletonInstances = new List<GuruSingletonPattern>();

            for (int i = 0; i < enumerationAmount; i++)
            {
                singletonInstances.Add(GuruSingletonPattern.GetInstance());
            }

            return singletonInstances;
        }

        public List<GuruSingletonPattern> RunGetterImplementation(int enumerationAmount)
        {
            var isSetToSignaled = manualResetEventSlim.Wait(millisecondsTimeout);

            if (!isSetToSignaled)
            {
                throw new TimeoutException();
            }

            var singletonInstances = new List<GuruSingletonPattern>();
            
            for (int i = 0; i < enumerationAmount; i++)
            {
                singletonInstances.Add(GuruSingletonPattern.GuruSingletonPatternObject);
            }

            return singletonInstances;
        }
    }
}
