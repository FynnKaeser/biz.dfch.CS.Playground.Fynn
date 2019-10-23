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
using biz.dfch.CS.Playground.Fynn._20191023;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20191023
{
    [TestClass]
    public class CustomerTest
    {
        [DataRow(1000, DisplayName = "Remove 1000 money from 1000")]
        [DataRow(0, DisplayName = "Remove 0 money from 1000")]
        [DataRow(42, DisplayName = "Remove 42 money from 1000")]
        [DataTestMethod]
        public void RemoveMoneyWithLessAmountThanCurrentMoneyReturnsTrue(int value)
        {
            // Arrange
            var currentMoney = 1000;
            var sut = new Customer(currentMoney);

            // Act
            var result = sut.RemoveMoney(value);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(sut.Money, currentMoney - value);
        }

        [DataRow(1001, DisplayName = "Remove 1001 from 1000")]
        [DataRow(420000, DisplayName = "Remove 420000 from 1000")]
        [TestMethod]
        public void RemoveMoneyWithGreaterAmountThanCurrentMoneyReturnsFalse(int value)
        {
            // Arrange
            var currentMoney = 1000;
            var sut = new Customer(currentMoney);

            // Act
            var result = sut.RemoveMoney(value);

            // Assert
            Assert.IsFalse(result);
        }

        [DataRow(-1, DisplayName = "Remove -1 from 1000")]
        [DataRow(-42, DisplayName = "Remove -42 money from 1000")]
        [TestMethod]
        public void RemoveMoneyWithAmountLessThanZeroReturnsFalse(int value)
        {
            // Arrange
            var currentMoney = 1000;
            var sut = new Customer(currentMoney);

            // Act
            var result = sut.RemoveMoney(value);

            // Assert
            Assert.IsFalse(result);
        }


        // DOTO --- CleanUp Test
        [TestMethod]
        public void X()
        {
            Customer x = null;
            var result = x.RemoveMoney(50);
            Assert.IsFalse(result);
        }
    }
}
