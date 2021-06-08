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
    public class XmlTest
    {
        [TestMethod]
        public void InitializeXmlObjectSucceeds()
        {
            // Arrange 
            var arbitraryVersion = "1.2.3";
            var arbitraryType = "Test Type";
            var arbitraryValue = 123;

            // Act
            var sut = new Xml(arbitraryVersion, arbitraryType, arbitraryValue);

            // Assert
            Assert.AreEqual(arbitraryVersion, sut.Version);
            Assert.AreEqual(arbitraryType, sut.Type);
            Assert.AreEqual(arbitraryValue, sut.Value);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullVersionThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryType = "Test Type";
            var arbitraryValue = 123;

            // Act
            var sut = new Xml(null, arbitraryType, arbitraryValue);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullTypeThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryVersion = "1.2.3";
            var arbitraryValue = 123;

            // Act
            var sut = new Xml(arbitraryVersion, null, arbitraryValue);

            // Assert
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-10)]
        [DataRow(-100)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetInvalidValueThrowsArgumentOutOfRangeException(int invalidValue)
        {
            // Arrange
            var arbitraryType = "Test Type";
            var arbitraryVersion = "1.2.3";

            // Act
            var sut = new Xml(arbitraryVersion, arbitraryType, invalidValue);

            // Assert
        }
    }
}
