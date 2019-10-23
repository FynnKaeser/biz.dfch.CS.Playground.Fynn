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
using biz.dfch.CS.Playground.Fynn._20191021;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20191021
{
    [TestClass]
    public class PlayerManagerTest
    {
        [TestMethod]
        public void GetFirstPlayerWithMatchReturnsFirstPlayer()
        {
            // Arrange
            var sut = new PlayerManager();
            var expected = sut.CreatePlayer("Fynn", "Kaeser", 10);
            var meier = sut.CreatePlayer("Fynn", "Meier", 10);

            // Act
            var result = sut.GetFirstPlayer(firstName: "Fynn");

            // Assert
            Assert.AreEqual(result.LastName, expected.LastName);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void GetFirstPlayerWithNotExistingFirstNameThrowsInvalidOperationException()
        {
            // Arrange
            var sut = new PlayerManager();
            var kaeser = sut.CreatePlayer("Fynn", "Kaeser", 10);
            var meier = sut.CreatePlayer("Fynn", "Meier", 10);

            // Act
            var x = sut.GetFirstPlayer(firstName: "Kevin");

            // Assert
            // Intentionally nothing
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void GetSinglePlayerWithMultipleFirstnameMatchThrowsInvalidOperationException()
        {
            // Arrange
            var sut = new PlayerManager();
            var kaeser = sut.CreatePlayer("Fynn", "Kaeser", 10);
            var meier = sut.CreatePlayer("Fynn", "Meier", 10);

            // Act
            var x = sut.GetSinglePlayer(firstName: "Fynn");

            // Assert
            // Intentionally nothing
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void GetSinglePlayerWithNoMatchingResultsThrowsInvalidOperationException()
        {
            // Arrange
            var sut = new PlayerManager();
            var kaeser = sut.CreatePlayer("Fynn", "Kaeser", 10);
            var meier = sut.CreatePlayer("Fynn", "Meier", 10);

            // Act
            var x = sut.GetSinglePlayer(firstName: "Kevin");

            // Assert
            // Intentionally nothing
        }

        [TestMethod]
        public void GetFirstOrDefaultWithNoMatchReturnsNull()
        {
            // Arrange
            var sut = new PlayerManager();
            var kaeser = sut.CreatePlayer("Fynn", "Kaeser", 10);
            var meier = sut.CreatePlayer("Fynn", "Meier", 10);

            // Act
            var result = sut.GetFirstOrDefaultPlayer(firstName: "Kevin");

            // Assert
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void GetFirstOrDefaultPlayerWithMultipleExistingFirstnameReturnsFirstPlayer()
        {
            // Arrange
            var sut = new PlayerManager();
            var expected = sut.CreatePlayer("Fynn", "Kaeser", 10);
            var meier = sut.CreatePlayer("Fynn", "Meier", 10);

            // Act
            var result = sut.GetFirstOrDefaultPlayer(firstName: "Fynn");

            // Assert
            Assert.AreEqual(result.LastName, expected.LastName);
        }


        [TestMethod]
        public void GetSingleOrDefaultWithNoMatchReturnsNull()
        {
            // Arrange
            var sut = new PlayerManager();
            var kaeser = sut.CreatePlayer("Fynn", "Kaeser", 10);
            var meier = sut.CreatePlayer("Fynn", "Meier", 10);

            // Act
            var result = sut.GetSingleOrDefaultPlayer(firstName: "Kevin");

            // Assert
            Assert.AreEqual(result, null);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void GetSingleOrDefaultWithMultipleFirstnameMatchThrowsInvalidOperationException()
        {
            // Arrange
            var sut = new PlayerManager();
            var kaeser = sut.CreatePlayer("Fynn", "Kaeser", 10);
            var meier = sut.CreatePlayer("Fynn", "Meier", 10);

            // Act
            var result = sut.GetSingleOrDefaultPlayer(firstName: "Fynn");

            // Assert
            // Intentionally nothing
        }

    }
}
