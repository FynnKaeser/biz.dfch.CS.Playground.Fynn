﻿/**
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
    public class PdfFileAnalyzerTest
    {
        [TestMethod]
        public void GetFileDataReturnsExpectedFileData()
        {
            // Arrange
            var expectedFileData = new FileData("PdfFile.pdf", FileEnding.Pdf, "Pdf Data");
            var sut = new PdfAnalyzer();

            sut.OpenFile("PdfFile.pdf");

            // Act
            var result = sut.GetFileData();

            // Assert
            Assert.AreEqual(expectedFileData.Name, result.Name);
            Assert.AreEqual(expectedFileData.FileEnding, result.FileEnding);
            Assert.AreEqual(expectedFileData.Data, result.Data);
        }

        [TestMethod]
        public void GetFileDataBeforeFileHasBeenOpenedReturnsNull()
        {
            // Arrange
            var sut = new PdfAnalyzer();

            // Act
            var result = sut.GetFileData();

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void OpenFileSucceeds()
        {
            // Arrange
            var arbitraryFileName = "PdfFile.pdf";
            var sut = new PdfAnalyzer();

            // Act
            sut.OpenFile(arbitraryFileName);

            // Assert
            Assert.AreEqual(FileEnding.Pdf, sut.FileData.FileEnding);
            Assert.AreEqual("PdfFile.pdf", sut.FileData.Name);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void OpenFileWithInvalidFileNameThrowsArgumentException(string invalidFileName)
        {
            // Arrange
            var sut = new PdfAnalyzer();

            // Act
            sut.OpenFile(invalidFileName);

            // Assert
        }
    }
}
