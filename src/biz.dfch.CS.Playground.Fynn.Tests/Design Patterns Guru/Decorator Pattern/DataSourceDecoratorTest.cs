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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Decorator_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Decorator_Pattern
{
    [TestClass]
    public class DataSourceDecoratorTest
    {
        [TestMethod]
        public void WriteDataSucceeds()
        {
            // Arrange
            var fileDataSource = new FileDataSource();
            var sut = new DataSourceDecorator(fileDataSource);

            var arbitraryData = "Test Data";
            var expectedData = "Test Data";

            // Act
            sut.Write(arbitraryData);

            // Assert
            var result = fileDataSource.Read();
            Assert.AreEqual(expectedData, result);
        }

        [TestMethod]
        public void ReadDataSucceeds()
        {
            // Arrange
            var fileDataSource = new FileDataSource();
            var sut = new DataSourceDecorator(fileDataSource);

            var arbitraryData = "Test Data";

            sut.Write(arbitraryData);

            // Act
            var result = sut.Read();

            // Assert
            Assert.AreEqual(arbitraryData, result);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteInvalidDataThrowsArgumentNullException(string invalidData)
        {
            // Arrange
            var fileDataSource = new FileDataSource();
            var sut = new DataSourceDecorator(fileDataSource);

            // Act
            sut.Write(invalidData);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeEncryptionDecoratorWithNullIDecoratorThrowsArgumentNullException()
        {
            // Arrange

            // Act
            var sut = new DataSourceDecorator(null);

            // Assert
        }
    }
}
