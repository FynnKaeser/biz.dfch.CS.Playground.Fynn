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
using System.Text;
using System.Threading.Tasks;
using biz.dfch.CS.Playground.Fynn._20190830;
using biz.dfch.CS.Playground.Fynn._20190930;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock.AutoMock.Ninject.Syntax;

namespace biz.dfch.CS.Playground.Fynn.Tests._20190930
{
    [TestClass]
    public class MyConstraintClassTest
    {

        [TestMethod]
        public void TwoIntegerValuesAreComparableAndReturnTrue()
        {
            // Arrange

            // Act
            var result = MyConstraintClass.AreEqual(5, 5);

            // Assert
            Assert.IsTrue(result);
        }

        // The Calculator class is not Comparable, doesn't implement 'IComparable<T>'
        //[TestMethod]
        //public void test()
        //{
        //    // Arrange

        //    // Act
        //    var result = MyConstraintClass.AreEqual(new Calculator(), new Calculator());

        //    // Assert
        //    Assert.IsTrue(result);
        //}
    }
}
