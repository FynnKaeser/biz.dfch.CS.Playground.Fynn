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
using System.Reflection;
using biz.dfch.CS.Playground.Fynn._20191009;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20191009
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void CallMaxWithIntegerWhereLeftIsBiggerThanRightSucceeds()
        {
            // Arrange
            var max = Helper.Max(2, 1);

            // Act
            // N/A

            // Assert
            Assert.AreEqual(2, max);
        }

        [TestMethod]
        public void CallMaxWithFloatWhereLeftIsBiggerThanRightSucceeds()
        {
            // Arrange
            var max = Helper.Max(2.222f, 1.11f);

            // Act
            // N/A
            
            // Assert
            Assert.AreEqual(2.222f, max);
        }

        [TestMethod]
        public void CallMaxWithDoubleWhereLeftIsBiggerThanRightSucceeds()
        {
            // Arrange
            var max = Helper.Max(2.2d, 1.1d);

            // Act
            // N/A

            // Assert
            Assert.AreEqual(2.2d, max);
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
