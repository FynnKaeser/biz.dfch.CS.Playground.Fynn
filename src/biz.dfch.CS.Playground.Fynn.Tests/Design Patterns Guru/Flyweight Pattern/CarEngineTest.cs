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
    public class CarEngineTest
    {
        [TestMethod]
        public void InitializeCarEngineSucceeds()
        {
            // Arrange
            var arbitraryHorsePower = 250;
            var arbitraryThrust = 5000;

            // Act
            var sut = new CarEngine(arbitraryHorsePower, arbitraryThrust);

            // Assert
            var resultHorsePower = sut.HorsePower;
            var resultThrust = sut.Thrust;

            Assert.AreEqual(arbitraryHorsePower, resultHorsePower);
            Assert.AreEqual(arbitraryThrust, resultThrust);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeCarEngineWithInvalidHorsePowerThrowsArgumentOutOfRangeException(int invalidHorsePower)
        {
            // Arrange
            var arbitraryThrust = 5000;

            // Act
            var sut = new CarEngine(invalidHorsePower, arbitraryThrust);

            // Assert
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeCarEngineWithInvalidThrustThrowsArgumentOutOfRangeException(int invalidThrust)
        {
            // Arrange
            var arbitraryHorsePower = 500;

            // Act
            var sut = new CarEngine(arbitraryHorsePower, invalidThrust);

            // Assert
        }
    }
}
