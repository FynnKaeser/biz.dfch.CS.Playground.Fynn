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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Builder_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Builder_Pattern
{
    [TestClass]
    public class FurnitureBuilderTest
    {
        [TestMethod]
        public void SetMaterialSucceeds()
        {
            // Arrange
            var sut = new FurnitureBuilder();
            var arbitraryMaterial = "Metal";
            var expectedFurniture = new Furniture()
            {
                Color = null,
                Height = null,
                LegCount = 0,
                Length = null,
                Material = arbitraryMaterial,
                Width = null
            };

            // Act
            sut.SetMaterial(arbitraryMaterial);

            // Assert
            var result = sut.GetFurniture();
            Assert.AreEqual(expectedFurniture, result);
        }

        [TestMethod]
        public void SetMaterialToNullReturnsFalse()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            // Act
            var result = sut.SetMaterial(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetMaterialToEmptyStringReturnsFalse()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            // Act
            var result = sut.SetMaterial(string.Empty); 

            // Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void SetMaterialToWhiteSpaceStringReturnsFalse()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            // Act
            var result = sut.SetMaterial(" "); 

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetDimensionsSucceeds()
        {
            // Arrange
            var sut = new FurnitureBuilder();
            var arbitraryLength = "50 cm";
            var arbitraryHeight = "30 cm";
            var arbitraryWidth = "20 cm";

            var expectedFurniture = new Furniture()
            {
                Color = null,
                Height = arbitraryHeight,
                LegCount = 0,
                Length = arbitraryLength,
                Material = null,
                Width = arbitraryWidth
            };

            // Act
            sut.SetDimensions(arbitraryHeight, arbitraryWidth, arbitraryLength);

            // Assert
            var result = sut.GetFurniture();
            Assert.AreEqual(expectedFurniture, result);
        }

        [TestMethod]
        public void SetDimensionsToNullReturnsFalse()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            // Act
            var result = sut.SetDimensions(null, null, null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetDimensionsToEmptyStringReturnsFalse()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            // Act
            var result = sut.SetDimensions(string.Empty, string.Empty, string.Empty);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetDimensionsToWhiteSpaceStringReturnsFalse()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            // Act
            var result = sut.SetDimensions(" ", " ", " ");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetColorSucceeds()
        {
            // Arrange
            var sut = new FurnitureBuilder();
            var arbitraryColor = "Brown";
            var expectedFurniture = new Furniture()
            {
                Color = arbitraryColor,
                Height = null,
                LegCount = 0,
                Length = null,
                Material = null,
                Width = null
            };
            

            // Act
            sut.SetColor(arbitraryColor);

            // Assert
            var result = sut.GetFurniture();
            Assert.AreEqual(expectedFurniture, result);
        }

        [TestMethod]
        public void SetColorToNullReturnsFalse()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            // Act
            var result = sut.SetColor(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetColorToEmptyStringReturnsFalse()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            // Act
            var result = sut.SetColor(string.Empty);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetColorToWhiteSpaceStringReturnsFalse()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            // Act
            var result = sut.SetColor(" ");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetLegsSucceeds()
        {
            // Arrange
            var sut = new FurnitureBuilder();
            var arbitraryLegCount = 5;
            var expectedFurniture = new Furniture()
            {
                Color = null,
                Height = null,
                LegCount = arbitraryLegCount,
                Length = null,
                Material = null,
                Width = null
            };

            // Act
            sut.SetLegs(arbitraryLegCount);

            // Assert
            var result = sut.GetFurniture();
            Assert.AreEqual(expectedFurniture, result);
        }

        [TestMethod]
        public void SetLegsToMinusNumberReturnsFalse()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            // Act
            var result = sut.SetLegs(-1);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ResetFurnitureSucceeds()
        {
            // Arrange
            var sut = new FurnitureBuilder();

            var expectedFurniture = new Furniture()
            {
                Color = null,
                Height = null,
                LegCount = 0,
                Length = null,
                Material = null,
                Width = null
            };
            
            sut.SetMaterial("Metal");
            sut.SetColor("Brown");
            sut.SetLegs(10);
            
            // Act
            sut.ResetFurniture();

            // Assert
            var result = sut.GetFurniture();
            Assert.AreEqual(expectedFurniture, result);
        }
    }
}
