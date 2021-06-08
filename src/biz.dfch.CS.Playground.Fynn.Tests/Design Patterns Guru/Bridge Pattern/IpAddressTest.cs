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
    public class IpAddressTest
    {
        [TestMethod]
        public void GetStringReturnsExpectedString()
        {
            // Arrange 
            var sut = new IpAddress(1, 2, 3, 4);

            var expectedResult = "1.2.3.4";

            // Act
            var result = sut.ToString();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(int.MinValue)]
        [DataRow(256)]
        [DataRow(int.MaxValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeIpAddressWithSection1OutOfRangeThrowsArgumentOutOfRangeException(int invalidValue)
        {
            // Assert
            var arbitrarySection2Value = 2;
            var arbitrarySection3Value = 3;
            var arbitrarySection4Value = 4;

            // Act
            var sut = new IpAddress(invalidValue, arbitrarySection2Value, arbitrarySection3Value, arbitrarySection4Value);

            // Assert
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(int.MinValue)]
        [DataRow(256)]
        [DataRow(int.MaxValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeIpAddressWithSection2OutOfRangeThrowsArgumentOutOfRangeException(int invalidValue)
        {
            // Assert
            var arbitrarySection1Value = 1;
            var arbitrarySection3Value = 3;
            var arbitrarySection4Value = 4;

            // Act
            var sut = new IpAddress(arbitrarySection1Value, invalidValue, arbitrarySection3Value, arbitrarySection4Value);

            // Assert
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(int.MinValue)]
        [DataRow(256)]
        [DataRow(int.MaxValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeIpAddressWithSection3OutOfRangeThrowsArgumentOutOfRangeException(int invalidValue)
        {
            // Assert
            var arbitrarySection1Value = 1;
            var arbitrarySection2Value = 2;
            var arbitrarySection4Value = 4;

            // Act
            var sut = new IpAddress(arbitrarySection1Value, arbitrarySection2Value, invalidValue, arbitrarySection4Value);

            // Assert
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(int.MinValue)]
        [DataRow(256)]
        [DataRow(int.MaxValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeIpAddressWithSection4OutOfRangeThrowsArgumentOutOfRangeException(int invalidValue)
        {
            // Assert
            var arbitrarySection1Value = 1;
            var arbitrarySection2Value = 2;
            var arbitrarySection3Value = 3;

            // Act
            var sut = new IpAddress(arbitrarySection1Value, arbitrarySection2Value, arbitrarySection3Value, invalidValue);

            // Assert
        }
    }
}
