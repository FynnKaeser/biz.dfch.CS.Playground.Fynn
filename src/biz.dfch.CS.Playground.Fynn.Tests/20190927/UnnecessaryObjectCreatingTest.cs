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
using biz.dfch.CS.Playground.Fynn._20190927;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20190927
{
    [TestClass]
    public class UnnecessaryObjectCreatingTest
    {
        private const string VALID_STRING = "Prefix_String_Suffix";
        private const string MISSING_SUFFIX = "Prefix_String";
        private const string MISSING_PREFIX = "String_Suffix";
        private const string MISSING_BOTH = "String";

        [DataRow(VALID_STRING, DisplayName = "Valid string with pre- and suffix")]
        [DataTestMethod]
        public void StringTesterReturnsTrue(string value)
        {
            // Arrange
            var sut = new UnnecessaryObjectCreating();

            // Act
            var result = sut.StringTester(value);

            // Assert
            Assert.IsTrue(result);
        }


        [DataRow(MISSING_BOTH, DisplayName = "String missing both")]
        [DataRow(MISSING_PREFIX, DisplayName = "String missing prefix")]
        [DataRow(MISSING_SUFFIX, DisplayName = "String missing suffix")]
        [DataTestMethod]
        public void StringTesterReturnsFalse(string value)
        {
            // Arrange
            var sut = new UnnecessaryObjectCreating();

            // Act
            var result = sut.StringTester(value);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
