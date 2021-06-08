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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Bridge_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Bridge_Pattern
{
    [TestClass]
    public class NetworkConfigurationTest
    {
        [TestMethod]
        public void SetIpAddressSucceeds()
        {
            // Arrange
            var device = new DestinationDevice();
            var sut = new NetworkConfiguration(device);

            var arbitrarySection1Value = 1;
            var arbitrarySection2Value = 2;
            var arbitrarySection3Value = 3;
            var arbitrarySection4Value = 4;
            var ipAddress = new IpAddress(arbitrarySection1Value, arbitrarySection2Value, arbitrarySection3Value,
                arbitrarySection4Value);

            // Act
            sut.SetIpAddress(ipAddress);

            // Assert
            var resultIpAddress = device.IpAddress;

            var resultSection1 = resultIpAddress.Section1;
            var resultSection2 = resultIpAddress.Section2;
            var resultSection3 = resultIpAddress.Section3;
            var resultSection4 = resultIpAddress.Section4;

            Assert.AreEqual(arbitrarySection1Value, resultSection1);
            Assert.AreEqual(arbitrarySection2Value, resultSection2);
            Assert.AreEqual(arbitrarySection3Value, resultSection3);
            Assert.AreEqual(arbitrarySection4Value, resultSection4);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetIpAddressToNullThrowsArgumentNullException()
        {
            // Arrange
            var device = new DestinationDevice();
            var sut = new NetworkConfiguration(device);

            // Act
            sut.SetIpAddress(null);

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeNewNetworkConfigurationObjectWithNullDeviceThrowsArgumentNullException()
        {
            // Arrange

            // Act
            var sut = new NetworkConfiguration(null);

            // Assert
        }
    }
}
