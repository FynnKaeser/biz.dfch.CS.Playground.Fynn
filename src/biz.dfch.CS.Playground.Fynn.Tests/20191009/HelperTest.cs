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

using biz.dfch.CS.Playground.Fynn._20191009;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20191009
{
    [TestClass]
    public class HelperTest
    {
        [DataRow(2, 1, DisplayName = "Integer")]
        [DataRow(2.2d, 1.1d, DisplayName = "Double")]
        [DataRow(2.222f, 1.111f, DisplayName = "Float")]
        [DataTestMethod]
        public void CallMaxWithNumericWhereLeftIsBiggerThanRightSucceeds(object left, object right)
        {
            // Arrange
            var max = Helper.Max(left, right);

            // Act
            // N/A

            // Assert
            Assert.AreEqual(left, max);
        }

        [TestMethod]
        public void CallMaxWithStringWhereLeftIsBiggerThanRightSucceeds()
        {
            // Arrange
            var max = Helper.Max("ABC", "AB");

            // Act
            // N/A

            // Assert
            Assert.AreEqual("ABC", max);
        }
    }
}