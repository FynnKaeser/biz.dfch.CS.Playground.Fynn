/**
 * Copyright 2019 d-fens GmbH
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
using biz.dfch.CS.Playground.Fynn._20191023;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20191023
{
    [TestClass]
    public class FileReaderTryCatchTest
    {
        [TestMethod]
        public void OpenFileWithNoneExistingFileReturnsFalse()
        {            
            // Arrange
            var sut = FileReader.OpenFileTryCatch("NotExistingFile.txt");

            // Act

            // Assert
            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void OpenFileWithNullReturnsFalse()
        {
            // Arrange
            var sut = FileReader.OpenFileTryCatch(null);

            // Act

            // Assert
            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void OpenFileWithMissingFileExtensionSucceeds()
        {
            // Arrange
            var sut = FileReader.OpenFileTryCatch("MyTextWithNoFileExtension");

            // Act

            // Assert
            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void OpenFileWithEmptyExistingFileSucceeds()
        {
            // Arrange
            var sut = FileReader.OpenFileTryCatch("MyTextEmpty.txt");

            // Act

            // Assert
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void OpenFileWithExistingFileReturnsTrue()
        {
            // Arrange
            var sut = FileReader.OpenFileTryCatch("MyText.txt");

            // Act

            // Assert
            Assert.IsTrue(sut);
        }
    }
}
