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
    public class ValueHandlerTest
    {
        [TestMethod]
        public void HandleRequestWithValidValueReturnsTrue()
        {
            // Arrange
            var sut = new ValueHandler();

            var arbitraryToken = "$TestToken$";
            var arbitraryValue = "123";
            var dataToHandle = new Data(arbitraryToken, arbitraryValue);

            // Act
            var result = sut.HandleRequest(dataToHandle);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HandleRequestWithInvalidValueReturnsFalse()
        {
            // Arrange
            var sut = new ValueHandler();

            var arbitraryToken = "$TestToken$";
            var invalidValue = "TestValue";
            var dataToHandle = new Data(arbitraryToken, invalidValue);

            // Act
            var result = sut.HandleRequest(dataToHandle);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HandleRequestWithNullDataThrowsArgumentNullException()
        {
            // Arrange
            var sut = new ValueHandler();

            // Act
            var result = sut.HandleRequest(null);

            // Assert
        }
    }
}
