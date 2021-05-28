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

using biz.dfch.CS.Playground.Fynn.Design_Patterns_Fynn.Facade_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Fynn.Facade_Pattern
{
    [TestClass]
    public class MyFacadePatternTest
    {
        [DataTestMethod]
        [DataRow(2000, 20)]
        [DataRow(10, 10)]
        [DataRow(999, 10)]
        [DataRow(1001, 20)]
        [DataRow(0, 10)]
        [DataRow(-1, 10)]
        public void DoTaskReturnsExpectedResultBasedOnCapacity(int capacity, int expectedResult)
        {
            // Arrange
            var sut = new MyFacadePattern(capacity);

            // Act
            var result = sut.DoTask();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
