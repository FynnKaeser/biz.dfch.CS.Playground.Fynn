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
    public class DatabaseServiceProxyTest
    {
        [TestMethod]
        public void WriteEntrySucceeds()
        {
            // Arrange
            var sut = new DatabaseServiceProxy();

            var arbitraryValue = "abc";
            var arbitraryId = 1;

            // Act
             var result = sut.Write(arbitraryId, arbitraryValue);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReadEntrySucceeds()
        {
            // Arrange
            var sut = new DatabaseServiceProxy();

            var arbitraryValue = "abc";
            var arbitraryId = 1;
            sut.Write(arbitraryId, arbitraryValue);

            // Act
            var resultEntry = sut.Read(arbitraryId);

            // Assert
            var resultId = resultEntry.Id;
            var resultValue = resultEntry.Value;

            Assert.AreEqual(arbitraryId, resultId);
            Assert.AreEqual(arbitraryValue, resultValue);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteInvalidValueThrowsArgumentNullException(string invalidValue)
        {
            // Arrange
            var sut = new DatabaseServiceProxy();
            var arbitraryId = 2;

            // Act
            sut.Write(arbitraryId, invalidValue);

            // Assert
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WriteInvalidIdThrowsArgumentOutOfRange(int invalidId)
        {
            // Arrange
            var sut = new DatabaseServiceProxy();
            var arbitraryValue = "123 ABC";

            // Act
            sut.Write(invalidId, arbitraryValue);

            // Assert
        }

        [TestMethod]
        public void WriteDuplicateIdReturnsFalse()
        {
            // Arrange
            var sut = new DatabaseServiceProxy();
            var arbitraryValue = "123 ABC";
            var arbitraryId = 23;
            sut.Write(arbitraryId, arbitraryValue);

            // Act
            var result = sut.Write(arbitraryId, arbitraryValue);

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-42)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReadInvalidIdThrowsArgumentOutOfRange(int invalidId)
        {
            // Arrange
            var sut = new DatabaseServiceProxy();

            // Act
            sut.Read(invalidId);

            // Assert
        }

        [TestMethod]
        public void ReadNonExistingIdReturnsNull()
        {
            // Arrange
            var sut = new DatabaseServiceProxy();
            var notExistingId = 12;

            // Act
            var result = sut.Read(notExistingId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
