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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Chain_of_Responsibility_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Chain_of_Responsibility_Pattern
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void InitializeNewDataSucceeds()
        {
            // Arrange
            var arbitraryToken = "$TestToken$";
            var arbitraryValue = "TestValue";

            // Act
            var sut = new Data(arbitraryToken, arbitraryValue);

            // Assert
            var resultToken = sut.Token;
            var resultValue = sut.Value;

            Assert.AreEqual(arbitraryToken, resultToken);
            Assert.AreEqual(arbitraryValue, resultValue);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeNewDataWithInvalidTokenThrowsArgumentNullException(string invalidToken)
        {
            // Arrange
            var arbitraryValue = "TestValue";

            // Act
            var sut = new Data(invalidToken, arbitraryValue);

            // Assert
        }
        
        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeNewDataWithInvalidValueThrowsArgumentNullException(string invalidValue)
        {
            // Arrange
            var arbitraryToken = "$TestToken$";
            
            // Act
            var sut = new Data(arbitraryToken, invalidValue);

            // Assert
        }
    }
}
