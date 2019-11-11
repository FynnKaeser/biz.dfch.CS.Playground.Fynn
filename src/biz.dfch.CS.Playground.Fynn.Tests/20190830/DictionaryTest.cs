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
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20190830
{
    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void AddingTwoDifferentElementsToDictionarySucceeds()
        {
            // Arrange
            var sut = new Dictionary<int, string>();
            var value1 = "Hello";
            var value2 = "World";

            // Act
            sut.Add(1, value1);
            sut.Add(2, value2);

            // Assert
            Assert.AreEqual(2, sut.Count);
            Assert.IsTrue(sut.ContainsKey(1));
            Assert.AreEqual(value1, sut[1]);
            Assert.IsTrue(sut.ContainsKey(2));
            Assert.AreEqual(value2, sut[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingDuplicateElementToDictionaryThrowsArgumentException()
        {
            // Arrange
            var sut = new Dictionary<int, string>();
            var value1 = "Hello";
            var value2 = "World";

            // Act
            sut.Add(1, value1);
            sut.Add(1, value2);

            // Assert
        }
    }
}