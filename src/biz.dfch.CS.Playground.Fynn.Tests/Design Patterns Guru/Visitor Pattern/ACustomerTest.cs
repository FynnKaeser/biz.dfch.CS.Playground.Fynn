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
    public class ACustomerTest
    {
        [TestMethod]
        public void AcceptingVisitorSucceeds()
        {
            // Arrange
            var sut = new ACustomer();
            var payVisitor = new PayVisitor();

            var expectedMoney = 5;

            // Act
            sut.Accept(payVisitor);

            // Assert
            var result = sut.Money;
            Assert.AreEqual(expectedMoney, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassNullVisitorThrowsArgumentNullException()
        {
            // Arrange
            var sut = new ACustomer();

            // Act
            sut.Accept(null);

            // Assert
        }
    }
}
