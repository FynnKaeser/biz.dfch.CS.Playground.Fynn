/**
 * Copyright 2019 d-fens GmbH
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

using biz.dfch.CS.Playground.Fynn._20190830;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20190830
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void SumOfTwoAndTwoReturnsFour()
        {
            // Arrange
            var sut = new Calculator();

            // Act
            var result = sut.Sum(2, 2);

            // Assert
            Assert.AreEqual(4, result);
        }
    }
}