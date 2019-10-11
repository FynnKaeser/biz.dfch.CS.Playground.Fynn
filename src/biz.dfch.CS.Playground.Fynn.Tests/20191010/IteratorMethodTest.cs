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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using biz.dfch.CS.Playground.Fynn._20191010;
using biz.dfch.CS.Playground.Fynn._20191011;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20191010
{
    [TestClass]
    public class IteratorMethodTest
    {
        [TestMethod]
        public void CallingIteratorReturnsStringWithConnectedNumbersFromOneToFourSucceeds()
        {
            // Arrange
            var sut = new IteratorMethod();

            // Act
            var result = sut.CallIteratorMethod();

            // Assert
            Assert.AreEqual("1234", result);
        }

        [TestMethod]
        public void CallingIteratorReturnsStringWithConnectedNumbersFromOneToFourChecksForWrongResultToShowThatBreakWorksSucceeds()
        {
            // Arrange
            var sut = new IteratorMethod();

            // Act
            var result = sut.CallIteratorMethod();

            var s = Item32.ProduceIndices();
            var l = s.Count();
            // Assert
            Assert.AreNotSame("12345", result);
        } 
    }
}
