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
using biz.dfch.CS.Playground.Fynn._20210319;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210319
{
    [TestClass]
    public class MyDictionaryTest
    {
        [TestMethod]
        public void InsertKeyValuePairToDictionarySucceeds()
        {
            // Arrange
            var sut = new MyDictionary<int, string>();
            var expectedCount = 1;

            // Act
            sut.Insert(1, "String");
            var resultCount = sut.Count;
            var resultKey = sut.HasKey(1);
            var resultValue = sut.HasValue("String");

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
            Assert.IsTrue(resultKey);
            Assert.IsTrue(resultValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertNullKeyThrowsArgumentNullException()
        {
            // Arrange
            var sut = new MyDictionary<string, string>();

            // Act
            sut.Insert(null, "String");

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertNullValueThrowsArgumentNullException()
        {
            // Arrange
            var sut = new MyDictionary<int, string>();

            // Act
            sut.Insert(1, null);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertDuplicatedKeyThrowsArgumentException()
        {
            // Arrange
            var sut = new MyDictionary<int, string>();
            sut.Insert(1, "Hallo");

            // Act
            sut.Insert(1, "String");

            // Assert
        }

        [TestMethod]
        public void DeleteKeyValuePairSucceeds()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>();
            sut.Insert(1, "String");
            sut.Insert(2, "Value");
            sut.Insert(3, "Test");

            var expectedCount = 2;

            // Act
            var result = sut.Delete(1);
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteKeyValuePairKeyNotFoundReturnsFalse()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>();
            sut.Insert(1, "String");
            sut.Insert(2, "Value");
            sut.Insert(3, "Test");

            var expectedCount = 3;

            // Act
            var result = sut.Delete(4);
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
            Assert.IsFalse(result);
        }
    }
}
