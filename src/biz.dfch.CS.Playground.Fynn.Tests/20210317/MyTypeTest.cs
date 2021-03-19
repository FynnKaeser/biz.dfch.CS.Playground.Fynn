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

using System;
using biz.dfch.CS.Playground.Fynn._20210317;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210317
{
    [TestClass]
    public class MyTypeTest
    {
        private readonly MyType[] expectedMyTypesArray =
        {
            new MyType("World", 174, true, 15312),
            new MyType("Hello", 153, true, 5),
            new MyType("Field", 43, true, 74),
            new MyType("My String", 42, false, 235),
            new MyType("Computer", 15, false, 43),
            null
        };

        [TestMethod]
        public void ComparingInstancesWhereInstanceIsInTheSamePositionAsOtherInSortOrderReturnsIntEqualZero()
        {
            // Arrange
            var sut = new MyType("My String", 42, true, 112);
            var compareTo = new MyType("Hello", 42, true, 163);

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
            var sut = new MyType("My String", 42, true, 112);
            var compareTo = new MyType("Hello", 12, true, 112);

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
            var sut = new MyType("My String", 42, false, 112);
            var compareTo = new MyType("Hello", 84, true, 122);

            var expectedResult = 1;

            // Act
            var result = sut.CompareTo(compareTo);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SortInstancesOfMyTypeSucceeds()
        {
            // Arrange
            var instance1 = new MyType("My String", 42, false, 235);
            var instance2 = new MyType("Hello", 153, true, 5);
            var instance3 = new MyType("World", 174, true, 15312);
            var instance4 = new MyType("Computer", 15, false, 43);
            var instance5 = new MyType("Field", 43, true, 74);

            MyType[] sut = {null, instance1, instance2, instance3, instance4, instance5};

            // Act
            Array.Sort(sut);

            // Assert
            for (int i = 0; i < expectedMyTypesArray.Length; i++)
            {
                var myTypeToBeAsserted = sut[i];
                var expectedMyType = expectedMyTypesArray[i];

                if (null == expectedMyType)
                {
                    Assert.IsNull(myTypeToBeAsserted);
                    continue;
                }

                Assert.AreEqual(expectedMyType, myTypeToBeAsserted);
            }
        }

        [TestMethod]
        public void InstanceIsEqualToOtherReturnsTrue()
        {
            // Arrange
            var sut = new MyType("Hello", 84, true, 112);
            var equalsTo = new MyType("Hello", 84, true, 112);

            var expectedResult = true;

            // Act
            var result = sut.Equals(equalsTo);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void InstanceIsNotEqualToOtherReturnsFalse()
        {
            // Arrange
            var sut = new MyType("My String", 34, false, 162);
            var equalsTo = new MyType("Hello", 84, true, 112);

            var expectedResult = false;

            // Act
            var result = sut.Equals(equalsTo);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void InstanceIsEqualToOtherUsingEqualityOperatorReturnsTrue()
        {
            // Arrange
            var sut = new MyType("Hello", 84, true, 112);
            var equalsTo = new MyType("Hello", 84, true, 112);

            var expectedResult = true;

            // Act
            var result = sut == equalsTo;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void InstanceIsNotEqualToOtherUsingEqualityOperatorReturnsFalse()
        {
            // Arrange
            var sut = new MyType("Moin", 214, false, 86);
            var equalsTo = new MyType("Hello", 84, true, 112);

            var expectedResult = false;

            // Act
            var result = sut == equalsTo;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void InstanceIsEqualToOtherUsingInequalityOperatorReturnsFalse()
        {
            // Arrange
            var sut = new MyType("Hello", 84, true, 112);
            var equalsTo = new MyType("Hello", 84, true, 112);

            var expectedResult = false;

            // Act
            var result = sut != equalsTo;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void InstanceIsNotEqualToOtherUsingInequalityOperatorReturnsTrue()
        {
            // Arrange
            var sut = new MyType
            (
                "Moin",
                214,
                false,
                86
            );
            var equalsTo = new MyType("Hello", 84, true, 112);

            var expectedResult = true;

            // Act
            var result = sut != equalsTo;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void InstanceIsNullUsingInequalityOperatorReturnsTrue()
        {
            // Arrange
            var sut = new MyType("Moin", 214, false, 86);

            var expectedResult = true;

            // Act
            var result = sut != null;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void InstanceIsNullUsingEqualityOperatorReturnsFalse()
        {
            // Arrange
            var sut = new MyType("Moin", 214, false, 86);

            var expectedResult = false;

            // Act
            var result = sut == null;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void InstanceEqualsToNullReturnsFalse()
        {
            // Arrange
            var sut = new MyType("My String", 34, false, 162);

            var expectedResult = false;

            // Act
            var result = sut.Equals(null);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
