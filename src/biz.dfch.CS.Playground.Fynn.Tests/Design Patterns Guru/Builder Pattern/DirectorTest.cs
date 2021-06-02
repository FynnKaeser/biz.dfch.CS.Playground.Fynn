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

using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Builder_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Builder_Pattern
{
    [TestClass]
    public class DirectorTest
    {
        [TestMethod]
        public void DirectorConstructsBarChairAndBuilderReturnsExpectedFurniture()
        {
            // Arrange
            var director = new Director();
            var furnitureBuilder = new FurnitureBuilder();
            var expectedFurniture = new Furniture
            {
                Color = "Brown",
                Height = "120 cm",
                Length = "40 cm",
                Material = "Wood",
                Width = "40 cm"
            };

            // Act
            director.ConstructBarChair(furnitureBuilder);

            // Assert
            var result = furnitureBuilder.GetFurniture();
            Assert.AreEqual(expectedFurniture, result);
        }

        [TestMethod]
        public void DirectorConstructsTableAndBuilderReturnsExpectedFurniture()
        {
            // Arrange
            var director = new Director();
            var furnitureBuilder = new FurnitureBuilder();
            var expectedFurniture = new Furniture
            {
                Color = "Black",
                Height = "100 cm",
                Length = "180 cm",
                Material = "Wood",
                Width = "80 cm"
            };

            // Act
            director.ConstructTable(furnitureBuilder);

            // Assert
            var result = furnitureBuilder.GetFurniture();
            Assert.AreEqual(expectedFurniture, result);
        }

        [TestMethod]
        public void DirectorConstructsDresserAndBuilderReturnsExpectedFurniture()
        {
            // Arrange
            var director = new Director();
            var furnitureBuilder = new FurnitureBuilder();
            var expectedFurniture = new Furniture
            {
                Color = "Grey",
                Height = "150 cm",
                Length = "100 cm",
                Material = "Metal",
                Width = "70 cm"
            };

            // Act
            director.ConstructDresser(furnitureBuilder);

            // Assert
            var result = furnitureBuilder.GetFurniture();
            Assert.AreEqual(expectedFurniture, result);
        }

        [TestMethod]
        public void ResettingBuilderSucceeds()
        {
            // Arrange
            var director = new Director();
            var furnitureBuilder = new FurnitureBuilder();
            var expectedFurniture = new Furniture();
            director.ConstructBarChair(furnitureBuilder);
            
            // Act
            furnitureBuilder.ResetFurniture();

            // Assert
            var result = furnitureBuilder.GetFurniture();
            Assert.AreEqual(expectedFurniture, result);
        }
        
        [TestMethod]
        public void ConstructBarChairWithNullBuilderReturnsFalse()
        {
            // Arrange
            var director = new Director();

            // Act
            var result = director.ConstructBarChair(null);
            
            // Assert
            Assert.IsFalse(result);
        }
    }
}
