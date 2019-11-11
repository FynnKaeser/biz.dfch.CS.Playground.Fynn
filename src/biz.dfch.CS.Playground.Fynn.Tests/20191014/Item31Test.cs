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
using System.Linq;
using biz.dfch.CS.Playground.Fynn._20191014;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20191014
{
    [TestClass]
    public class Item31Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ZipWithNullFirstSequenceThrowsArgumentNullException()
        {
            // Arrange
            var second = new List<string> {"fourth", "fifth", "sixth"};

            // Act
            var result = Item31.Zip(null, second);

            foreach (var resultItem in result)
            {
                // intentionally left empty
            }

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ZipWithNullSecondSequenceThrowsArgumentNullException()
        {
            // Arrange
            var first = new List<string> {"fourth", "fifth", "sixth"};

            // Act
            var result = Item31.Zip(first, null);

            foreach (var resultItem in result)
            {
                // intentionally left empty
            }

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sequences don't have the same lenght")]
        public void ZipWithTwoSequencesOfDifferentLengthThrowsArgumentException()
        {
            // Arrange
            var first = new List<string> {"first", "second", "third", "firstFourth"};
            var second = new List<string> {"fourth", "fifth", "sixth"};

            // Act
            var result = Item31.Zip(first, second);

            foreach (var resultItem in result)
            {
                // intentionally left empty
            }

            // Assert
        }

        [TestMethod]
        public void ZipTwoIEnumerableSequencesReturnsZippedSequenceSucceeds()
        {
            // Arrange
            var first = new List<string> {"first", "second", "third"};
            var second = new List<string> {"fourth", "fifth", "sixth"};
            var expected = new List<string>
            {
                "first fourth",
                "second fifth",
                "third sixth"
            };

            // Act
            var result = Item31.Zip(first, second);

            foreach (var resultItem in result)
            {
                // intentionally left empty
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Count, result.Count());
            CollectionAssert.AreEqual(expected, result.ToList());
        }
    }
}