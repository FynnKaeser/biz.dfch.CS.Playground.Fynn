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
using System.Collections.Generic;
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Strategy_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Strategy_Pattern
{
    [TestClass]
    public class NavigatorTest
    {
        [TestMethod]
        public void SetNavigatorSucceeds()
        {
            // Arrange
            var arbitraryRoadPlaner = new RoadPlaner();
            var arbitraryPublicTransportPlaner = new PublicTransportPlaner();

            var sut = new Navigator(arbitraryRoadPlaner);
            
            // Act
            sut.SetRoutePlaner(arbitraryPublicTransportPlaner);

            // Assert
            var result = sut.RoutePlaner is PublicTransportPlaner;
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNavigatorToNullThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryPublicTransportPlaner = new PublicTransportPlaner();
            var sut = new Navigator(arbitraryPublicTransportPlaner);

            // Act
            sut.SetRoutePlaner(null);

            // Assert
        }

        [TestMethod]
        public void InitializeNewNavigatorSucceeds()
        {
            // Arrange
            var arbitraryRoadPlaner = new RoadPlaner();

            // Act
            var sut = new Navigator(arbitraryRoadPlaner);

            // Assert
            var result = sut.RoutePlaner is RoadPlaner;
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeNewNavigatorWithNullPlanerThrowsArgumentNullException()
        {
            // Arrange
            // Act
            var sut = new Navigator(null);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildRouteWithNullFromPlaceThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryPublicTransportPlaner = new PublicTransportPlaner();
            var sut = new Navigator(arbitraryPublicTransportPlaner);

            var arbitraryLongitude = 42;
            var arbitraryLatitude = 42;
            var arbitraryToPlace = new Place(arbitraryLongitude, arbitraryLatitude);

            // Act
            sut.BuildRoute(null, arbitraryToPlace);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildRouteWithNullToPlaceThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryPublicTransportPlaner = new PublicTransportPlaner();
            var sut = new Navigator(arbitraryPublicTransportPlaner);

            var arbitraryLongitude = 42;
            var arbitraryLatitude = 42;
            var arbitraryFromPlace = new Place(arbitraryLongitude, arbitraryLatitude);

            // Act
            sut.BuildRoute(arbitraryFromPlace, null);

            // Assert
        }

        [TestMethod]
        public void BuildRouteWithPublicTransporterPlanerSucceeds()
        {
            // Arrange
            var arbitraryPublicTransportPlaner = new PublicTransportPlaner();
            var sut = new Navigator(arbitraryPublicTransportPlaner);

            var arbitraryLongitude = 42;
            var arbitraryLatitude = 42;
            var arbitraryFromPlace = new Place(arbitraryLongitude, arbitraryLatitude);
            var arbitraryToPlace = new Place(arbitraryLongitude, arbitraryLatitude);

            var expectedResult = new List<Route>
            {
                new Route("1h 30min"),
                new Route("1h 48min"),
                new Route("2h 06min")
            };
            var expectedCount = expectedResult.Count;

            // Act
            var result = sut.BuildRoute(arbitraryFromPlace, arbitraryToPlace);

            // Assert
            Assert.AreEqual(expectedCount, result.Count);

            for (int i = 0; i < expectedCount; i++)
            {
                var routeToBeAsserted = result[i];
                var expectedRoute = expectedResult[i];

                Assert.AreEqual(expectedRoute.Time, routeToBeAsserted.Time);
            }
        }
        
        [TestMethod]
        public void BuildRouteWithRoadPlanerSucceeds()
        {
            // Arrange
            var arbitraryRoadPlaner = new RoadPlaner();
            var sut = new Navigator(arbitraryRoadPlaner);

            var arbitraryLongitude = 42;
            var arbitraryLatitude = 42;
            var arbitraryFromPlace = new Place(arbitraryLongitude, arbitraryLatitude);
            var arbitraryToPlace = new Place(arbitraryLongitude, arbitraryLatitude);

            var expectedResult = new List<Route>
            {
                new Route("12min"),
                new Route("15min"),
                new Route("18min")
            };
            var expectedCount = expectedResult.Count;

            // Act
            var result = sut.BuildRoute(arbitraryFromPlace, arbitraryToPlace);

            // Assert
            Assert.AreEqual(expectedCount, result.Count);

            for (int i = 0; i < expectedCount; i++)
            {
                var routeToBeAsserted = result[i];
                var expectedRoute = expectedResult[i];

                Assert.AreEqual(expectedRoute.Time, routeToBeAsserted.Time);
            }
        }
    }
}
