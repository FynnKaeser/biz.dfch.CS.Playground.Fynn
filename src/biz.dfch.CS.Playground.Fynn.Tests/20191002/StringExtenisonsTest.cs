/**
 * Copyright 2019 d-fens GmbH
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
using biz.dfch.CS.Playground.Fynn._20191002;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20191002
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void RemoveSpacesForStringWithSpacesReturnsStringWithoutSpaces()
        {
            // Arrange
            var sut = "abc 123";

            // Act
            var result = sut.RemoveSpaces();

            // Assert
            Assert.AreEqual("abc123", result);
        }

        [TestMethod]
        public void RemoveSpacesForStringWithSpaceAtBeginningReturnsStringWithoutSpaces()
        {
            // Arrange
            var sut = " abc123";

            // Act
            var result = sut.RemoveSpaces();

            // Assert
            Assert.AreEqual("abc123", result);
        }

        [TestMethod]
        public void RemoveSpacesForStringWithSpaceAtTheEndReturnsStringWithoutSpaces()
        {
            // Arrange
            var sut = "abc123 ";

            // Act
            var result = sut.RemoveSpaces();

            // Assert
            Assert.AreEqual("abc123", result);
        }

        [TestMethod]
        public void RemoveSpacesForStringWithManyFollowingSpacesReturnsStringWithoutSpaces()
        {
            // Arrange
            var sut = "a b        c 1 23 ";

            // Act
            var result = sut.RemoveSpaces();

            // Assert
            Assert.AreEqual("abc123", result);
        }

        [TestMethod]
        public void RemoveSpacesForStringWithoutSpacesReturnsInitialString()
        {
            // Arrange
            var sut = "abc123";

            // Act
            var result = sut.RemoveSpaces();

            // Assert
            Assert.AreEqual("abc123", result);
        }

        [TestMethod]
        public void CountLetterEFromStringReturnsFour()
        {
            // Arrange
            var sut = "Hello _ e _ e _ e";

            // Act
            var result = sut.CountLetter('e');

            // Assert
            Assert.AreEqual(4, result);

        }
    }
}
