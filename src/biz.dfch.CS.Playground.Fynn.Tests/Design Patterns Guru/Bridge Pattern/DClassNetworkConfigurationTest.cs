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
    public class DClassNetworkConfigurationTest
    {
        [TestMethod]
        public void SetIpAddressSucceeds()
        {
            // Arrange
            var device = new SourceDevice();
            var sut = new DClassNetworkConfiguration(device);

            var sectionMin = 0;
            var sectionMax = 255;
            var section1Min = 224;
            var section1Max = 239;

            // Act
            sut.SetIpAddress();

            // Assert
            var resultIpAddress = device.IpAddress;

            var section1 = resultIpAddress.Section1;
            var section2 = resultIpAddress.Section2;
            var section3 = resultIpAddress.Section3;
            var section4 = resultIpAddress.Section4;

            var resultSection1 = section1 >= section1Min && section1 <= section1Max;
            var resultSection2 = section2 >= sectionMin && section2 <= sectionMax;
            var resultSection3 = section3 >= sectionMin && section3 <= sectionMax;
            var resultSection4 = section4 >= sectionMin && section4 <= sectionMax;

            Assert.IsTrue(resultSection1);
            Assert.IsTrue(resultSection2);
            Assert.IsTrue(resultSection3);
            Assert.IsTrue(resultSection4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeDClassNetworkConfigurationWithNullDeviceObjectThrowsArgumentNullException()
        {
            // Arrange
            // Act
            var sut = new DClassNetworkConfiguration(null);

            // Assert
        }
    }
}
