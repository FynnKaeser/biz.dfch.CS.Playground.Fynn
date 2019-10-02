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
using biz.dfch.CS.Playground.Fynn._20191002;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20191002
{
    [TestClass]
    public class ClassHierarchyFromBookTest
    {
        [TestMethod]
        public void TestMethodArguments()
        {
            // Arrange
            var sut = new Planet();
            var moon = new Moon();
            Moon[] moons = new Moon[5];
            IEnumerable<Moon> enumerable = new List<Moon>();
            IComparable<Moon> comparable = null;

            // Act
            sut.DoStuffWithArray(moons);
            sut.DoStuff(moon);
            sut.DoStuffWithIEnumerable(enumerable);
            //sut.DoStuffWithIComparable(comparable);

            // Assert
            // N/A

        }
    }
}
