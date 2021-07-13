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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Visitor_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Visitor_Pattern
{
    [TestClass]
    public class PayVisitorTest
    {
        [TestMethod]
        public void PayACustomerSucceeds()
        {
            // Arrange
            var sut = new PayVisitor();
            var arbitraryACustomer = new ACustomer();
            var expectedMoney = 5;

            // Act
            sut.PayACustomer(arbitraryACustomer);

            // Assert
            var result = arbitraryACustomer.Money;
            Assert.AreEqual(expectedMoney, result);
        }
        
        [TestMethod]
        public void PayACustomerFiveTimesSucceeds()
        {
            // Arrange
            var sut = new PayVisitor();
            var arbitraryACustomer = new ACustomer();
            var expectedMoney = 25;

            // Act
            for (int i = 0; i < 5; i++)
            {
                sut.PayACustomer(arbitraryACustomer);
            }

            // Assert
            var result = arbitraryACustomer.Money;
            Assert.AreEqual(expectedMoney, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PayACustomerWithNullThrowsArgumentNullException()
        {
            // Arrange
            var sut = new PayVisitor();

            // Act
            sut.PayACustomer(null);

            // Assert
        }

        [TestMethod]
        public void PayBCustomerSucceeds()
        {
            // Arrange
            var sut = new PayVisitor();
            var arbitraryBCustomer = new BCustomer();
            var expectedMoney = 10;

            // Act
            sut.PayBCustomer(arbitraryBCustomer);

            // Assert
            var result = arbitraryBCustomer.Money;
            Assert.AreEqual(expectedMoney, result);
        }

        [TestMethod]
        public void PayBCustomerFiveTimesSucceeds()
        {
            // Arrange
            var sut = new PayVisitor();
            var arbitraryBCustomer = new BCustomer();
            var expectedMoney = 50;

            // Act
            for (int i = 0; i < 5; i++)
            {
                sut.PayBCustomer(arbitraryBCustomer);
            }

            // Assert
            var result = arbitraryBCustomer.Money;
            Assert.AreEqual(expectedMoney, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PayBCustomerWithNullThrowsArgumentNullException()
        {
            // Arrange
            var sut = new PayVisitor();

            // Act
            sut.PayBCustomer(null);

            // Assert
        }
    }
}
