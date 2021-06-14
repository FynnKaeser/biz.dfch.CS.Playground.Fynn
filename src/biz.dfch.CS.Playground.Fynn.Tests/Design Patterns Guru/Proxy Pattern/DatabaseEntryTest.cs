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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Proxy_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Proxy_Pattern
{
    [TestClass]
    public class DatabaseEntryTest
    {
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeDatabaseEntryWithInvalidIdThrowsArgumentOutOfRange(int invalidId)
        {
            // Arrange
            var arbitraryValue = "123 ABC";

            // Act
            var sut = new DatabaseEntry(invalidId, arbitraryValue);

            // Assert
        }
        
        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeDatabaseEntryWithInvalidValueThrowsArgumentNullException(string invalidValue)
        {
            // Arrange
            var arbitraryId = 2;

            // Act
            var sut = new DatabaseEntry(arbitraryId, invalidValue);

            // Assert
        }

        [TestMethod]
        public void InitializeDatabaseEntrySucceeds()
        {
            // Arrange
            var arbitraryId = 2;
            var arbitraryValue = "123";

            // Act
            var sut = new DatabaseEntry(arbitraryId, arbitraryValue);

            // Assert
            var resultId = sut.Id;
            var resultValue = sut.Value;

            Assert.AreEqual(arbitraryId, resultId);
            Assert.AreEqual(arbitraryValue, resultValue);
        }
    }
}
