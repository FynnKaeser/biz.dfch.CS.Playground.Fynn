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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Adapter_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Adapter_Pattern
{
    [TestClass]
    public class AdapterTest
    {
        [TestMethod]
        public void GetJsonValueReturnsExpectedResult()
        {
            // Arrange
            var service = new Service();
            var sut = new Adapter(service);

            var arbitraryVersion = "1.1";
            var arbitraryType = "Test Type";
            var arbitraryValue = 12345;
            var xml = new Xml(arbitraryVersion, arbitraryType, arbitraryValue);

            var expectedResult = "Json - 12345";

            // Act
            var result = sut.GetJsonValue(xml);

            // Assert
            Assert.AreEqual(expectedResult, result);
        } 
        
        [TestMethod]
        public void GetJsonValueWithNullXmlObjectReturnsDefaultValue()
        {
            // Arrange
            var service = new Service();
            var sut = new Adapter(service);

            var expectedResult = "Json - <<None>>";

            // Act
            var result = sut.GetJsonValue(null);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetJsonValueWithNullServiceObjectThrowsArgumentNullException()
        {
            // Arrange
            // Act
            var sut = new Adapter(null);

            // Assert
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-10)]
        [DataRow(-100)]
        public void GetJsonValueWithInvalidValueReturnsDefaultValue(int invalidValue)
        {
            // Arrange
            var service = new Service();
            var sut = new Adapter(service);

            var arbitraryVersion = "1.1";
            var arbitraryType = "Test Type";
            var arbitraryValue = 12345;
            var xml = new Xml(arbitraryVersion, arbitraryType, arbitraryValue);

            var expectedResult = "Json - <<None>>";

            xml.Value = invalidValue;
            
            // Act
            var result = sut.GetJsonValue(xml);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
