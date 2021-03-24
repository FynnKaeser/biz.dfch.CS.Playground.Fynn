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
using System.Collections;
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
            var sut = new MyDictionary<int, string>(1);
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
            var sut = new MyDictionary<string, string>(1);

            // Act
            sut.Insert(null, "String");

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertNullValueThrowsArgumentNullException()
        {
            // Arrange
            var sut = new MyDictionary<int, string>(1);

            // Act
            sut.Insert(1, null);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertDuplicatedKeyThrowsArgumentException()
        {
            // Arrange
            var sut = new MyDictionary<int, string>(2);
            sut.Insert(1, "Hallo");

            // Act
            sut.Insert(1, "String");

            // Assert
        }

        [TestMethod]
        public void DeleteKeyValuePairSucceeds()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(3);
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
        public void DeleteKeyValuePairButKeyNotFoundReturnsFalse()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(3);
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

        [TestMethod]
        public void UpdateValueSucceeds()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(2);
            sut.Insert(1, "String");
            sut.Insert(2, "Value");

            // Act
            var result = sut.UpdateValue(2, "Console");
            var hasValue = sut.HasValue("Console");

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(hasValue);
        }

        [TestMethod]
        [DataRow("4")]
        [DataRow(null)]
        public void UpdateValueButKeyIsInvalidReturnsFalse(string key)
        {
            // Arrange 
            var sut = new MyDictionary<string, string>(2);
            sut.Insert("1", "String");
            sut.Insert("2", "Value");

            // Act
            var result = sut.UpdateValue(key, "Console");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateValueButNewValueIsNullReturnsFalse()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(2);
            sut.Insert(1, "String");
            sut.Insert(2, "Value");

            // Act
            var result = sut.UpdateValue(1, null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateKeySucceeds()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(2);
            sut.Insert(1, "String");
            sut.Insert(2, "Value");

            // Act
            var result = sut.UpdateKey(2, 4);
            var hasKey = sut.HasKey(4);
            var hasPreviousKey = sut.HasKey(2);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(hasKey);
            Assert.IsFalse(hasPreviousKey);
        }

        [TestMethod]
        [DataRow("4")]
        [DataRow(null)]
        public void UpdateKeyButKeyIsInvalidReturnsFalse(string key)
        {
            // Arrange 
            var sut = new MyDictionary<string, string>(2);
            sut.Insert("1", "String");
            sut.Insert("2", "Value");

            // Act
            var result = sut.UpdateKey(key, "4");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow(null)]
        public void UpdateKeyButNewKeyIsInvalidReturnsFalse(string newKey)
        {
            // Arrange 
            var sut = new MyDictionary<string, string>(2);
            sut.Insert("1", "String");
            sut.Insert("2", "Value");

            // Act
            var result = sut.UpdateKey("2", newKey);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasKeySucceeds()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(2);
            sut.Insert(1, "String");
            sut.Insert(2, "Value");

            // Act
            var result = sut.HasKey(1);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("-1")]
        [DataRow("0")]
        [DataRow("3")]
        [DataRow(null)]
        public void HasKeyButKeyNotFoundReturnsFalse(string key)
        {
            // Arrange 
            var sut = new MyDictionary<string, string>(2);
            sut.Insert("1", "String");
            sut.Insert("2", "Value");

            // Act
            var result = sut.HasKey(key);

            // Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void HasValueSucceeds()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(2);
            sut.Insert(1, "String");
            sut.Insert(2, "Value");

            // Act
            var result = sut.HasValue("String");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("Text")]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("String.")]
        [DataRow("String13")]
        [DataRow(null)]
        public void HasValueButValueNotFoundReturnsFalse(string value)
        {
            // Arrange 
            var sut = new MyDictionary<string, string>(2);
            sut.Insert("1", "String");
            sut.Insert("2", "Value");

            // Act
            var result = sut.HasValue(value);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ClearDictionarySucceeds()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(2);
            sut.Insert(1, "String");
            sut.Insert(2, "Value");
            var expectedCount = 0;

            // Act
            sut.Clear();
            var resultCount = sut.Count;
            var hasFirstKey = sut.HasKey(1);
            var hasSecondKey = sut.HasKey(2);

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
            Assert.IsFalse(hasFirstKey);
            Assert.IsFalse(hasSecondKey);
        }
        
        [TestMethod]
        public void IteratingOverKeysSucceeds()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(3);
            sut.Insert(1, "String");
            sut.Insert(2, "Value");
            sut.Insert(3, "Text");

            // Act & Assert
            foreach (var key in sut.Keys)
            {
                
            }
        }
        
        [TestMethod]
        public void IteratingOverValuesSucceeds()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(3);
            sut.Insert(1, "String");
            sut.Insert(2, "Value");
            sut.Insert(3, "Text");

            // Act & Assert
            foreach (var key in sut.Values)
            {
                
            }
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IteratingOverNullKeysThrowsArgumentNullException()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(1);

            // Act & Assert
            foreach (var key in sut.Keys)
            {
                
            }
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IteratingOverNullValuesThrowsArgumentNullException()
        {
            // Arrange 
            var sut = new MyDictionary<int, string>(3);

            // Act & Assert
            foreach (var key in sut.Values)
            {
                
            }
        }

        [TestMethod]
        public void CountGetsSetSuccessfullyAfterInsert()
        {
            // Arrange
            var sut = new MyDictionary<int, string>(1);
            var expectedCount = 1;

            // Act
            sut.Insert(1, "String");
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
        }
        
        [TestMethod]
        public void CountGetsSetSuccessfullyAfterDelete()
        {
            // Arrange
            var sut = new MyDictionary<int, string>(3);
            sut.Insert(1, "String");
            sut.Insert(2, "Bing Bong");
            sut.Insert(3, "Rest");

            var expectedCount = 2;

            // Act
            sut.Delete(1);
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
        }

        [TestMethod]
        public void CountGetsSetSuccessfullyAfterClear()
        {
            // Arrange
            var sut = new MyDictionary<int, string>(3);
            sut.Insert(1, "String");
            sut.Insert(2, "Bing Bong");
            sut.Insert(3, "Rest");

            var expectedCount = 0;

            // Act
            sut.Clear();
            var resultCount = sut.Count;

            // Assert
            Assert.AreEqual(expectedCount, resultCount);
        }
    }
}
