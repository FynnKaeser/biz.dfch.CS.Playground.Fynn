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

using System.Collections.Generic;
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Builder_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Builder_Pattern
{
    [TestClass]
    public class FurnitureTest
    {
        private Dictionary<Furniture, Furniture> equalFurniture = new Dictionary<Furniture, Furniture>
        {
            {
                new Furniture
                {
                    Color = "Brown", Height = "22", LegCount = 13, Length = "44", Material = "Metal", Width = "55"
                },
                new Furniture
                {
                    Color = "Brown", Height = "22", LegCount = 13, Length = "44", Material = "Metal", Width = "55"
                }
            },
            {
                new Furniture
                {
                    Color = null, Height = null, LegCount = 13, Length = null, Material = null, Width = null
                },
                new Furniture
                {
                    Color = null, Height = null, LegCount = 13, Length = null, Material = null, Width = null
                }
            },
            {
                new Furniture
                {
                    Color = "Brown", Height = "22", LegCount = -20, Length = null, Material = "Metal", Width = "55"
                },
                new Furniture
                {
                    Color = "Brown", Height = "22", LegCount = -20, Length = null, Material = "Metal", Width = "55"
                }
            }
        };

        [TestMethod]
        public void EqualsMethodSucceeds()
        {
            // Arrange
            // Act
            // Assert
            foreach (var keyValuePair in equalFurniture)
            {
                var sut = keyValuePair.Key;
                var otherSut = keyValuePair.Value;
                var result = sut.Equals(otherSut);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void GetHashCodeMethodSucceeds()
        {
            // Arrange
            var furniture = new Furniture()
            {
                Color = "Brown",
                Height = "14 cm",
                LegCount = 5,
                Length = "10 cm",
                Material = "Metal",
                Width = "30 cm"
            };
            var expectedHashCode = 486310219;

            // Act
            var hashCode = furniture.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, hashCode);
        }

        [TestMethod]
        public void ResetFurnitureSucceeds()
        {
            // Arrange
            var sut = new Furniture()
            {
                Color = "Brown",
                Height = "14 cm",
                LegCount = 5,
                Length = "10 cm",
                Material = "Metal",
                Width = "30 cm"
            };
            var expectedResult = new Furniture()
            {
                Color = null,
                Height = null,
                LegCount = 0,
                Length = null,
                Material = null,
                Width = null
            };

            // Act
            sut.Reset();

            // Assert
            Assert.AreEqual(expectedResult, sut);
        }
    }
}
