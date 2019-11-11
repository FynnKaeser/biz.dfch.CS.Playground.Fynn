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

using System.Collections.Generic;
using System.Linq;
using biz.dfch.CS.Playground.Fynn._20191014;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20191014
{
    [TestClass]
    public class Item33Test
    {
        [TestMethod]
        public void CreateSequenceWithTenElementsStartsAtZeroStepsByThreeIsEqualToExpectedListSucceeds()
        {
            // Arrange
            const int NUMBER_OF_ELEMENTS = 10;
            const int START_AT = 0;
            const int STEP_BY = 3;
            IList<int> expected = new List<int> {0, 3, 6, 9, 12, 15, 18, 21, 24, 27};

            // Act 
            var actual = Item33.CreateSequence(NUMBER_OF_ELEMENTS, START_AT, STEP_BY);
            var result = expected.SequenceEqual(actual);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateSequenceWithTenElementsStartsAtZeroStepsByThreeIsNotEqualToExpectedListSucceeds()
        {
            // Arrange
            const int NUMBER_OF_ELEMENTS = 10;
            const int START_AT = 0;
            const int STEP_BY = 3;
            IList<int> expected = new List<int> {0, 3, 6, 9, 12, 15, 18, 21, 24, 26};

            // Act 
            var actual = Item33.CreateSequence(NUMBER_OF_ELEMENTS, START_AT, STEP_BY);
            var result = expected.SequenceEqual(actual);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateSequenceWithStepByZeroIsEqualToExpectedSequenceSucceeds()
        {
            // Arrange
            const int NUMBER_OF_ELEMENTS = 5;
            const int START_AT = 0;
            const int STEP_BY = 0;
            IList<int> expected = new List<int> {0, 0, 0, 0, 0};

            // Act 
            var actual = Item33.CreateSequence(NUMBER_OF_ELEMENTS, START_AT, STEP_BY);
            var result = expected.SequenceEqual(actual);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateSequenceWithNegativeStartSucceeds()
        {
            // Arrange
            const int NUMBER_OF_ELEMENTS = 5;
            const int START_AT = -5;
            const int STEP_BY = 0;
            IList<int> expected = new List<int> {-5, -5, -5, -5, -5};

            // Act 
            var actual = Item33.CreateSequence(NUMBER_OF_ELEMENTS, START_AT, STEP_BY);
            var result = expected.SequenceEqual(actual);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateSequenceWithNegativeNumberOfElementsIsNull()
        {
            // Arrange
            const int NUMBER_OF_ELEMENTS = -10;
            const int START_AT = 0;
            const int STEP_BY = 10;

            // Act 
            var actual = Item33.CreateSequence(NUMBER_OF_ELEMENTS, START_AT, STEP_BY);

            // Assert
            Assert.AreEqual("", actual);
        }

        [TestMethod]
        public void TestForDebug()
        {
            // Arrange
            var sequence = Item33.CreateSequence(10000, 0, 7).TakeWhile(num => num < 1000);

            // Act
            var x = sequence.Count();

            // Assert
        }
    }
}