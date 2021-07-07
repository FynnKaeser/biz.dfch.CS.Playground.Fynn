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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Template_Method_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Template_Method_Pattern
{
    [TestClass]
    public class FileDataTest
    {
        [TestMethod]
        public void InitializeFileDataSucceeds()
        {
            // Arrange
            var arbitraryFileName = "FileName";
            var arbitraryFileEnding = FileEnding.Csv;
            var arbitraryData = "data";

            // Act
            var sut = new FileData(arbitraryFileName, arbitraryFileEnding, arbitraryData);

            // Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(arbitraryFileName, sut.Name);
            Assert.AreEqual(arbitraryFileEnding, sut.FileEnding);
            Assert.AreEqual(arbitraryData, sut.Data);
        }


        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializeFileDataWithInvalidFileNameThrowsArgumentException(string invalidFileName)
        {
            // Arrange
            var arbitraryFileEnding = FileEnding.Csv;
            var arbitraryData = "data";

            // Act
            var sut = new FileData(invalidFileName, arbitraryFileEnding, arbitraryData);

            // Assert
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializeFileDataWithInvalidDataThrowsArgumentException(string invalidData)
        {
            // Arrange
            var arbitraryFileName = "FileName";
            var arbitraryFileEnding = FileEnding.Csv;

            // Act
            var sut = new FileData(arbitraryFileName, arbitraryFileEnding, invalidData);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializeFileDataWithNoneFileEndingThrowsArgumentException()
        {
            // Arrange
            var arbitraryFileName = "FileName";
            var arbitraryData = "data";

            // Act
            var sut = new FileData(arbitraryFileName, FileEnding.None, arbitraryData);

            // Assert
        }
    }
}
