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

using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Adapter_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Adapter_Pattern
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void GetValueReturnsExpectedResult()
        {
            // Arrange
            var sut = new Service();

            var arbitraryVersion = "1.3";
            var arbitraryType =  "Test";
            var arbitraryValue = "Test Value";
            var json = new Json(arbitraryVersion, arbitraryType, arbitraryValue);

            var expectedResult = "Json - Test Value";

            // Act
            var result = sut.GetValue(json);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetValueWithNullJsonObjectReturnsDefaultValue()
        {
            // Arrange
            var sut = new Service();

            var expectedResult = "Json - <<None>>";

            // Act
            var result = sut.GetValue(null);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetValueWithNullOrWhitespaceValueReturnsDefaultValue()
        {
            // Arrange
            var sut = new Service();

            var arbitraryVersion = "1.3";
            var arbitraryType = "Test";
            var arbitraryValue = "Test Value";
            var json = new Json(arbitraryVersion, arbitraryType, arbitraryValue);

            var expectedResult = "Json - <<None>>";
            
            json.Value = null;
            
            // Act
            var result = sut.GetValue(json);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
