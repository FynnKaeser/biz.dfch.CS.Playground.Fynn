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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Composite_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Composite_Pattern
{
    [TestClass]
    public class BoxTest
    {
        [TestMethod]
        public void GetPriceReturnsExpectedResult()
        {
            // Arrange
            var arbitraryProducts = new List<Product>
            {
                new Product(10, 50),
                new Product(100, 3),
                new Product(25, 15),
                new Product(60, 5)
            };

            var arbitraryInnerBox = new Box(arbitraryProducts, new List<Box>());

            var arbitraryInnerBoxes = new List<Box>
            {
                new Box(arbitraryProducts, new List<Box>
                {
                    arbitraryInnerBox,
                    arbitraryInnerBox
                }),
                new Box(arbitraryProducts, new List<Box>())
            };
            var sut = new Box(arbitraryProducts, arbitraryInnerBoxes);

            var expectedResult = 7375;

            // Act
            var result = sut.GetPrice();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeBoxWithNullListOfProductsThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryInnerBoxes = new List<Box>();

            // Act
            var sut = new Box(null, arbitraryInnerBoxes);

            // Arrange
        }

        [TestMethod]
        public void InitializeBoxWithNullListOfInnerBoxesInitializesNewList()
        {
            // Arrange
            var arbitraryProducts = new List<Product>
            {
                new Product(15, 10)
            };

            // Act
            var sut = new Box(arbitraryProducts, null);

            // Assert
            sut.GetPrice();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializeBoxWithListOfProductsWhichContainsZeroProductsThrowsArgumentException()
        {
            // Arrange
            var arbitraryProducts = new List<Product>();
            var arbitraryInnerBoxes = new List<Box>();
            
            // Act
            var sut = new Box(arbitraryProducts, arbitraryInnerBoxes);

            // Assert
        }
    }
}
