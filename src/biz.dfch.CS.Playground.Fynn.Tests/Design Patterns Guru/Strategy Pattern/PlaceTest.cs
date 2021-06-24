﻿/**
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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Strategy_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Strategy_Pattern
{
    [TestClass]
    public class PlaceTest
    {
        [TestMethod]
        public void InitializePlaceSucceeds()
        {
            // Arrange
            var arbitraryLongitude = 42;
            var arbitraryLatitude = 42;

            // Act
            var sut = new Place(arbitraryLongitude, arbitraryLatitude);

            // Assert
            var resultLongitude = sut.Longitude;
            var resultLatitude = sut.Latitude;

            Assert.AreEqual(arbitraryLongitude, resultLongitude);
            Assert.AreEqual(arbitraryLatitude, resultLatitude);
        }

        [DataTestMethod]
        [DataRow(181)]
        [DataRow(int.MaxValue)]
        [DataRow(int.MinValue)]
        [DataRow(-1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeInvalidLongitudeThrowsArgumentOutOfRangeException(int invalidLongitude)
        {
            // Arrange
            var arbitraryLatitude = 42;

            // Act
            var sut = new Place(invalidLongitude, arbitraryLatitude);

            // Assert
        }
        
        [DataTestMethod]
        [DataRow(91)]
        [DataRow(int.MaxValue)]
        [DataRow(int.MinValue)]
        [DataRow(-1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeInvalidLatitudeThrowsArgumentOutOfRangeException(int invalidLatitude)
        {
            // Arrange
            var arbitraryLongitude = 42;

            // Act
            var sut = new Place(arbitraryLongitude, invalidLatitude);

            // Assert
        }
    }
}