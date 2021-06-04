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

using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Prototype_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void CloneShapeSucceeds()
        {
            // Arrange
            var sut = new Shape
            {
                Color = "Brown",
                Height = 120,
                Length = 42,
                Width = 60,
                LengthUnit = LengthUnit.Centimeter
            };

            // Act
            var clone = sut.Clone();

            // Assert
            Assert.AreEqual(sut, clone);
        }

        [TestMethod]
        public void EqualsSucceeds()
        {
            // Arrange
            var sut = new Shape
            {
                Color = "Brown",
                Height = 120,
                Length = 42,
                Width = 60,
                LengthUnit = LengthUnit.Centimeter
            };

            var referenceShape = new Shape
            {
                Color = "Brown",
                Height = 120,
                Length = 42,
                Width = 60,
                LengthUnit = LengthUnit.Centimeter
            };
            
            // Act
            var result = sut.Equals(referenceShape);

            // Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void CallEqualsWithOtherBeingNullReturnsFalse()
        {
            // Arrange
            var sut = new Shape
            {
                Color = "Brown",
                Height = 120,
                Length = 42,
                Width = 60,
                LengthUnit = LengthUnit.Centimeter
            };
            
            // Act
            var result = sut.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCodeSucceeds()
        {
            // Arrange
            var sut = new Shape
            {
                Color = "Brown",
                Height = 120,
                Length = 42,
                Width = 60,
                LengthUnit = LengthUnit.Centimeter
            };
            var expectedHashCode = 1091142634;

            // Act
            var result = sut.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, result);
        }

    }
}
