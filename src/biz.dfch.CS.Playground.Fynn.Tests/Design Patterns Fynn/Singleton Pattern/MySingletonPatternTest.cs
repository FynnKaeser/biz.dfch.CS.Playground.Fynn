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

using biz.dfch.CS.Playground.Fynn.Design_Patterns_Fynn.Singleton_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Fynn.Singleton_Pattern
{
    [TestClass]
    public class MySingletonPatternTest
    {
        [TestMethod]
        public void InstanceOnlyGetsCreatedOnceWithGetInstanceMethodImplementation()
        {
            // Arrange
            var sut = new MySingletonPattern();
            var enumerationAmount = 100;
            var expectedObjectCreationCounter = 1;

            // Act
            for (int i = 0; i < enumerationAmount; i++)
            {
                sut.GetInstance();
            }

            var result = sut.MyObjectCreationCounter;

            // Assert
            Assert.AreEqual(expectedObjectCreationCounter, result);
        }

        [TestMethod]
        public void InstanceOnlyGetsCreatedOnceWithGetterImplementation()
        {
            // Arrange
            var sut = new MySingletonPattern();
            var enumerationAmount = 100;
            var expectedSecondObjectCreationCounter = 1;

            // Act
            for (int i = 0; i < enumerationAmount; i++)
            {
                var temp = sut.MySecondObject;
            }

            var result = sut.MySecondObjectCreationCounter;

            // Assert
            Assert.AreEqual(expectedSecondObjectCreationCounter, result);
        }
    }
}
