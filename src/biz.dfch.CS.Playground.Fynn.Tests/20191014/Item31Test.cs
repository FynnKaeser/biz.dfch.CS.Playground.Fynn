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
        public void ZipTwoIEnumerableSequencesReturnOneSequenceSucceeds()
        {
            // Arrange
            var first = new List<string>{"first", "second", "third"};
            var second = new List<string>{"fourth", "fifth", "sixth"};
            string[] expected = {"first fourth", "second fifth", "third sixth"};

            // Act
            var result = Item31.Zip(first, second).ToArray();

            // Assert
            if (expected.Length == result.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i], result[i]);
                }
            }
            else
            {
                throw new System.ArgumentOutOfRangeException($"Arrays don't have the same lenght");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "'result' is greater than 'expected'")]
        public void ExpectedResultIsSmallerThanResultThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var first = new List<string> { "first", "second", "third", "firstFourth" };
            var second = new List<string> { "fourth", "fifth", "sixth", "secondSeventh" };
            string[] expected = { "first fourth", "second fifth", "third sixth" };

            // Act
            var result = Item31.Zip(first, second).ToArray();

            // Assert
            if (expected.Length == result.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i], result[i]);
                }
            }
            else
            {
                throw new System.ArgumentOutOfRangeException($"Arrays don't have the same lenght");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "'result' is smaller than 'expected'")]
        public void ExpectedResultIsGreaterThanResultThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var first = new List<string> { "first", "second"};
            var second = new List<string> { "fourth", "fifth" };
            string[] expected = { "first fourth", "second fifth", "third sixth" };

            // Act
            var result = Item31.Zip(first, second).ToArray();

            // Assert
            if (expected.Length == result.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i], result[i]);
                }
            }
            else
            {
                throw new System.ArgumentOutOfRangeException($"Arrays don't have the same lenght");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "'result' is smaller than 'expected'")]
        public void BiggerListsDoNotHaveTheSameAmountOfStringsToZipThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var first = new List<string> { "first", "second", "third", "fourth" };
            var second = new List<string> { "fourth", "fifth", "sixth", "seventh", "eight" };
            string[] expected = { "first fourth", "second fifth", "third sixth" };

            // Act
            var result = Item31.Zip(first, second).ToArray();

            // Assert
            if (expected.Length == result.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i], result[i]);
                }
            }
            else
            {
                throw new System.ArgumentOutOfRangeException($"Arrays don't have the same lenght");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "'result' is smaller than 'expected'")]
        public void SmallerListsDoNotHaveTheSameAmountOfStringsToZipThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var first = new List<string> { "first", "second" };
            var second = new List<string> { "fourth", "fifth", "sixth" };
            string[] expected = { "first fourth", "second fifth", "third sixth" };

            // Act
            var result = Item31.Zip(first, second).ToArray();

            // Assert
            if (expected.Length == result.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i], result[i]);
                }
            }
            else
            {
                throw new System.ArgumentOutOfRangeException($"Arrays don't have the same lenght");
            }
        }

        [TestMethod]
        public void SecondListIsOneLongerThanFirstListAndFirstListHasSameAmountOfElementsThanExpectedListSucceedsAndReturnsExpectedList()
        {
            // Arrange
            var first = new List<string> { "first", "second", "third" };
            var second = new List<string> { "fourth", "fifth", "sixth", "seventh" };
            string[] expected = { "first fourth", "second fifth", "third sixth" };

            // Act
            var result = Item31.Zip(first, second).ToArray();

            // Assert
            if (expected.Length == result.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i], result[i]);
                }
            }
            else
            {
                throw new System.ArgumentOutOfRangeException($"Arrays don't have the same lenght");
            }
        }
    }
}
