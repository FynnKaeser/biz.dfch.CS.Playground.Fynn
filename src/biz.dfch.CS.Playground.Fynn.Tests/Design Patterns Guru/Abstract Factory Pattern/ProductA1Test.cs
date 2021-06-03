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

using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Abstract_Factory_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Abstract_Factory_Pattern
{
    [TestClass]
    public class ProductA1Test
    {
        [TestMethod]
        public void EqualsMethodReturnsExpectedResult()
        {
            // Arrange
            var arbitraryName = "arbitraryName";
            var arbitraryIpAddress = "1.2.3.4";
            var sut = new ProductA1(arbitraryName, arbitraryIpAddress);
            var otherSut = new ProductA1(arbitraryName, arbitraryIpAddress);

            // Act
            var result = sut.Equals(otherSut);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetHashCodeMethodReturnsExpectedResult()
        {
            // Arrange
            var arbitraryName = "arbitraryName";
            var arbitraryIpAddress = "1.2.3.4";
            var sut = new ProductA1(arbitraryName, arbitraryIpAddress);
            var expectedResult = 6363335;

            // Act
            var result = sut.GetHashCode();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(null, DisplayName = "Initialize Name with null")]
        [DataRow("", DisplayName = "Initialize Name with empty string")]
        [DataRow(" ", DisplayName = "Initialize Name with whitespace string")]
        public void CreateProductA1WithInvalidNameSetsDefaultName(string invalidName)
        {
            // Arrange
            var expectedName = "Default Name";
            var arbitraryIpAddress = "1.2.3.4";

            // Act
            var result = new ProductA1(invalidName, arbitraryIpAddress);

            // Assert
            var resultName = result.Name;

            Assert.AreEqual(expectedName, resultName);
        }

        [DataTestMethod]
        [DataRow(null, DisplayName = "Initialize IpAddress with null")]
        [DataRow("", DisplayName = "Initialize IpAddress with empty string")]
        [DataRow(" ", DisplayName = "Initialize IpAddress with whitespace string")]
        public void CreateProductA1WithInvalidIpAddressSetsDefaultIpAddress(string invalidIpAddress)
        {
            // Arrange
            var expectedIpAddress = "1.1.1.1";
            var arbitraryName = "Product Name";

            // Act
            var result = new ProductA1(arbitraryName, invalidIpAddress);

            // Assert
            var resultIpAddress = result.IpAddress;

            Assert.AreEqual(expectedIpAddress, resultIpAddress);
        }
    }
}
