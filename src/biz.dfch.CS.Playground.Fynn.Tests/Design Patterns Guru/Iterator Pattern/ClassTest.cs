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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Iterator_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Iterator_Pattern
{
    [TestClass]
    public class ClassTest
    {
        [TestMethod]
        public void EqualsSucceeds()
        {
            // Arrange
            var arbitraryClassName = "A-Class";
            var sut = new Class(arbitraryClassName);
            var comparisionClass = new Class(arbitraryClassName);

            // Act
            var result = sut.Equals(comparisionClass);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsWithOtherClassNullSucceeds()
        {
            // Arrange
            var arbitraryClassName = "A-Class";
            var sut = new Class(arbitraryClassName);

            // Act
            var result = sut.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualsWithNullClassNameSucceeds()
        {
            // Arrange
            var arbitraryClassName = "A-Class";
            var sut = new Class(arbitraryClassName);
            var comparisionClass = new Class(arbitraryClassName);

            sut.ClassName = null;
            comparisionClass.ClassName = null;

            // Act
            var result = sut.Equals(comparisionClass);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeNewClassWithNullClassNameThrowsArgumentNullException()
        {
            // Arrange
            // Act
            var sut = new Class(null);
            
            // Assert
        }

        [TestMethod]
        public void GetHashCodeSucceeds()
        {
            // Arrange
            var arbitraryClassName = "A-Class";
            var sut = new Class(arbitraryClassName);
            var expectedHashCode = 42;

            // Act
            var result = sut.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, result);
        }
    }
}
