﻿/**
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

using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Abstract_Factory_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Abstract_Factory_Pattern
{
    [TestClass]
    public class AbstractFactory1Test
    {
        [TestMethod]
        public void CreatingProductA1Succeeds()
        {
            // Arrange 
            var sut = new AbstractFactory1();
            var expectedProductA1 = new ProductA1("The A1 Name", "1.2.3.4");

            // Act
            var result = sut.CreateProductA();

            // Assert
            Assert.AreEqual(expectedProductA1, result);
        }

        [TestMethod]
        public void CreatingProductB1Succeeds()
        {
            // Arrange 
            var sut = new AbstractFactory1();
            var expectedProductB1 = new ProductB1("The B1 Name", "1.2.3.4");

            // Act
            var result = sut.CreateProductB();

            // Assert
            Assert.AreEqual(expectedProductB1, result);
        }
    }
}
