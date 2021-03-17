/**
 * Copyright 2021 d-fens GmbH
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

using biz.dfch.CS.Playground.Fynn._20210317;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210317
{
    [TestClass]
    public class MyTypeTest
    {
        [TestMethod]
        public void ComparingInstancesWhereInstanceIsInTheSamePositionAsOtherInSortOrderReturnsIntEqualZero()
        {
            // Arrange
            var sut = new MyType
            {
                MyString = "My String",
                MyInt = 42,
                MyBool = true,
                MyLong = 112
            };
            var compareTo = new MyType
            {
                MyString = "Hello",
                MyInt = 42,
                MyBool = true,
                MyLong = 163
            };

            var expectedResult = 0;

            // Act
            var result = sut.CompareTo(compareTo);

            // Assert
            Assert.AreEqual(expectedResult, result);

        }
        
        [TestMethod]
        public void ComparingInstancesWhereInstancePrecedesOtherInstanceInSortOrderReturnsIntEqualToMinusOne()
        {
            // Arrange
            var sut = new MyType
            {
                MyString = "My String",
                MyInt = 42,
                MyBool = true,
                MyLong = 112
            };
            var compareTo = new MyType
            {
                MyString = "Hello",
                MyInt = 84,
                MyBool = true,
                MyLong = 112
            };

            var expectedResult = -1;

            // Act
            var result = sut.CompareTo(compareTo);

            // Assert
            Assert.AreEqual(expectedResult, result);

        }
        
        [TestMethod]
        public void ComparingInstancesWhereInstanceFollowsOtherInstanceInSortOrderReturnsIntEqualToOne()
        {
            // Arrange
            var sut = new MyType
            {
                MyString = "My String",
                MyInt = 42,
                MyBool = false,
                MyLong = 112
            };
            var compareTo = new MyType
            {
                MyString = "Hello",
                MyInt = 84,
                MyBool = true,
                MyLong = 112
            };

            var expectedResult = 1;

            // Act
            var result = sut.CompareTo(compareTo);

            // Assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void EqualsMethodSucceeds()
        {
            // Arrange
            var sut = new MyType();
            var equalsTo = new MyType();

            // Act
            var result = sut.Equals(equalsTo);

            // Assert

        }
    }
}
