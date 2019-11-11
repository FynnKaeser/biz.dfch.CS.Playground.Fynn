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

using biz.dfch.CS.Playground.Fynn._20190925;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20190925
{
    [TestClass]
    public class MinimizeConstructorInitializationTest
    {
        [TestMethod]
        public void NewInstanceWithNoParameterSucceeds()
        {
            // Arrange
            var sut = new MinimizeConstructorInitialization();

            // Act

            // Assert
            Assert.AreEqual(42, sut.StartValue);
            Assert.AreEqual("Muster", sut.Name);
        }

        [TestMethod]
        public void NewInstanceWithStartValueParameterSucceeds()
        {
            // Arrange
            var sut = new MinimizeConstructorInitialization(8);

            // Act

            // Assert
            Assert.AreEqual(8, sut.StartValue);
            Assert.AreEqual("Muster", sut.Name);
        }

        [TestMethod]
        public void NewInstanceWithBothParameterSucceeds()
        {
            // Arrange
            var sut = new MinimizeConstructorInitialization(8, "Fynn");

            // Act

            // Assert
            Assert.AreEqual(8, sut.StartValue);
            Assert.AreEqual("Fynn", sut.Name);
        }
    }
}