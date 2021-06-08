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
    public class SourceDeviceTest
    {
        [TestMethod]
        public void SetIpAddressSucceeds()
        {
            // Arrange
            var sut = new SourceDevice();
            var arbitraryIpAddress = new IpAddress(1, 2, 3, 4);

            var expectedSection1 = 1;
            var expectedSection2 = 2;
            var expectedSection3 = 3;
            var expectedSection4 = 4;

            // Act
            sut.SetIpAddress(arbitraryIpAddress);

            // Assert
            var result = sut.IpAddress;

            Assert.AreEqual(expectedSection1, result.Section1);
            Assert.AreEqual(expectedSection2, result.Section2);
            Assert.AreEqual(expectedSection3, result.Section3);
            Assert.AreEqual(expectedSection4, result.Section4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetIpAddressToNullObjectThrowsArgumentNullException()
        {
            // Arrange
            var sut = new SourceDevice();

            // Act
            sut.SetIpAddress(null);

            // Assert
        }
    }
}
