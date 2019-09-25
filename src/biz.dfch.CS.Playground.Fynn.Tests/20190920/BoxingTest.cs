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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20190920
{
    [TestClass]
    public class BoxingTest
    {
        [TestMethod]
        public void BoxingIntSucceeds()
        {
            // Arrange
            int i = 5;

            // Act
            var result = $"Result = {i}";

            // Assert
            Assert.AreEqual("Result = 5", result);
        }

        [TestMethod]
        public void BoxingIntSucceeds2()
        {
            // Arrange
            int i = 5;
            object o = i; // box

            o = new Arbitrary();

            // Act
            var result = o.ToString();
            var result2 = (o as Arbitrary).ToString();

            // Assert
            //Assert.AreEqual(typeof(Int32), o.GetType());
            Assert.AreEqual("5", result);
        }

        public class Arbitrary
        {
            public new string ToString()
            {
                return "tralala";
            }
        }
    }
}
