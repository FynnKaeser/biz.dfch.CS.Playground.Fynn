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
    public class HandlerBaseTest
    {
        [TestMethod]
        public void SetNextHandlerSucceeds()
        {
            // Arrange
            var tokenHandler = new TokenHandler();
            var valueHandler = new ValueHandler();

            var invalidToken = "TestToken";
            var arbitraryValue = "123";
            var dataToHandle = new Data(invalidToken, arbitraryValue);

            // Act
            tokenHandler.SetNext(valueHandler);

            // Assert.
            var result = tokenHandler.HandleRequest(dataToHandle);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNextHandlerToNullThrowsArgumentNullException()
        {
            // Arrange
            var tokenHandler = new TokenHandler();
            
            // Act
            tokenHandler.SetNext(null);

            // Assert
        }
    }
}
