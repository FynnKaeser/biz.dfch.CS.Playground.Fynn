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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Composite_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Composite_Pattern
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void GetPriceFromProductReturnsExpectedResult()
        {
            // Arrange
            var arbitraryPrice = 50;
            var arbitraryAmount = 2;
            var sut = new Product(arbitraryPrice, arbitraryAmount);

            var expectedResult = 100;

            // Act
            var result = sut.GetPrice();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeProductWithInvalidPriceThrowsArgumentOutOfRangeException(int invalidPrice)
        {
            // Arrange
            var arbitraryAmount = 2;

            // Act
            var sut = new Product(invalidPrice, arbitraryAmount);
            
            // Assert
        }
        
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeProductWithInvalidAmountThrowsArgumentOutOfRangeException(int invalidAmount)
        {
            // Arrange
            var arbitraryPrice = 30;

            // Act
            var sut = new Product(arbitraryPrice, invalidAmount);
            
            // Assert
        }
    }
}
