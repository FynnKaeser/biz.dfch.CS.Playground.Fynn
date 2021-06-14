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
    public class CarEngineFactoryTest
    {
        [TestMethod]
        public void GetCarEngineHasCorrectProperties()
        {
            // Arrange
            var sut = new CarEngineFactory();
            var arbitraryHorsePower = 250;
            var arbitraryThrust = 5000;
                
            // Act
            var result = sut.GetCarEngine(arbitraryHorsePower, arbitraryThrust);

            // Assert
            var resultHorsePower = result.HorsePower;
            var resultThrust = result.Thrust;
        }

        [TestMethod]
        public void GetCarEngineWithSamePropertiesTwiceHaveSameReference()
        {
            // Arrange
            var sut = new CarEngineFactory();
            var arbitraryHorsePower = 250;
            var arbitraryThrust = 5000;

            var firstCarEngine = sut.GetCarEngine(arbitraryHorsePower, arbitraryThrust);

            // Act
            var secondCarEngine = sut.GetCarEngine(arbitraryHorsePower, arbitraryThrust);

            // Assert
            var result = ReferenceEquals(firstCarEngine, secondCarEngine);

            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetEngineWithInvalidHorsePowerThrowsArgumentOutOfRangeException(int invalidHorsePower)
        {
            // Arrange
            var sut = new CarEngineFactory();
            var arbitraryThrust = 5000;

            // Act
            sut.GetCarEngine(invalidHorsePower, arbitraryThrust);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetEngineWithInvalidThrustThrowsArgumentOutOfRangeException(int invalidThrust)
        {
            // Arrange
            var sut = new CarEngineFactory();
            var arbitraryHorsePower = 500;

            // Act
            sut.GetCarEngine(arbitraryHorsePower, invalidThrust);
        }
    }
}
