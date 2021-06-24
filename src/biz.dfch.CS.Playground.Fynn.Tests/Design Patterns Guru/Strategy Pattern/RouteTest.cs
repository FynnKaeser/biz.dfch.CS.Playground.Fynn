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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Strategy_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Strategy_Pattern
{
    [TestClass]
    public class RouteTest
    {
        [TestMethod]
        public void InitializeRouteSucceeds()
        {
            // Arrange
            var arbitraryTime = "2h 42min";

            // Act
            var sut = new Route(arbitraryTime);

            // Assert
            var result = sut.Time;
            Assert.AreEqual(arbitraryTime, result);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializeInvalidTimeThrowsArgumentException(string invalidTime)
        {
            // Arrange
            // Act
            var sut = new Route(invalidTime);

            // Assert
        }
    }
}
