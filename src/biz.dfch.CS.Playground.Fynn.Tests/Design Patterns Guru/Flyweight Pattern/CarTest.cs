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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Flyweight_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Flyweight_Pattern
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeCarWithNullCarEngineThrowsArgumentNullException()
        {
            // Arrange
            // Act
            var sut = new Car(null);
            // Assert
        }

        [TestMethod]
        public void DriveForwardsSucceeds()
        {
            // Arrange
            var arbitraryHorsePower = 250;
            var arbitraryThrust = 5000;
            var carEngine = new CarEngine(arbitraryHorsePower, arbitraryThrust);

            var sut = new Car(carEngine);

            var expectedPosition = Tuple.Create(1, 0);

            // Act
            sut.DriveForwards();

            // Assert
            var resultPosition = sut.Position;
            Assert.AreEqual(expectedPosition, resultPosition);
            Assert.AreEqual(expectedPosition, resultPosition);
        }
        
        [TestMethod]
        public void DriveBackwardsSucceeds()
        {
            // Arrange
            var arbitraryHorsePower = 250;
            var arbitraryThrust = 5000;
            var carEngine = new CarEngine(arbitraryHorsePower, arbitraryThrust);

            var sut = new Car(carEngine);

            var expectedPosition = Tuple.Create(-1, 0);

            // Act
            sut.DriveBackwards();

            // Assert
            var resultPosition = sut.Position;
            Assert.AreEqual(expectedPosition, resultPosition);
            Assert.AreEqual(expectedPosition, resultPosition);
        }
        
        [TestMethod]
        public void DriveLeftSucceeds()
        {
            // Arrange
            var arbitraryHorsePower = 250;
            var arbitraryThrust = 5000;
            var carEngine = new CarEngine(arbitraryHorsePower, arbitraryThrust);

            var sut = new Car(carEngine);

            var expectedPosition = Tuple.Create(0, -1);

            // Act
            sut.DriveLeft();

            // Assert
            var resultPosition = sut.Position;
            Assert.AreEqual(expectedPosition, resultPosition);
            Assert.AreEqual(expectedPosition, resultPosition);
        }
        
        [TestMethod]
        public void DriveRightSucceeds()
        {
            // Arrange
            var arbitraryHorsePower = 250;
            var arbitraryThrust = 5000;
            var carEngine = new CarEngine(arbitraryHorsePower, arbitraryThrust);

            var sut = new Car(carEngine);

            var expectedPosition = Tuple.Create(0, 1);

            // Act
            sut.DriveRight();

            // Assert
            var resultPosition = sut.Position;
            Assert.AreEqual(expectedPosition, resultPosition);
            Assert.AreEqual(expectedPosition, resultPosition);
        }
    }
}
