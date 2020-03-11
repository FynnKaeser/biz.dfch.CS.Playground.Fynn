/**
 * Copyright 2020 d-fens GmbH
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
using biz.dfch.CS.Playground.Fynn._20200309;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20200309
{
    [TestClass]
    public class StringExtensionTests
    {
        [DataRow("Unless required by applicable law or agreed to in writing", "UnlessRequiredByApplicableLawOrAgreedToInWriting", DisplayName = "Remove Spaces with first letter capital")]
        [DataRow("this string contains spaces pls help", "ThisStringContainsSpacesPlsHelp", DisplayName = "Remove spaces without first letter capital")]
        [DataRow("", "", DisplayName = "Empty string returns empty string")]
        [DataTestMethod]
        public void ShortMethodExtensionTest(string str, string expected)
        {
            // Arrange
            // N/A

            // Act
            var result = str.Short();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
