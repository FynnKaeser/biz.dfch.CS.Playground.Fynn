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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Adapter_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Adapter_Pattern
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullVersionThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryType = "Test Type";
            var arbitraryValue = "123";

            // Act
            var sut = new Json(null, arbitraryType, arbitraryValue);

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullTypeThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryVersion = "1.2.3";
            var arbitraryValue = "123";

            // Act
            var sut = new Json(arbitraryVersion, null, arbitraryValue);

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullValueThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryType = "Test Type";
            var arbitraryVersion = "1.2.3";

            // Act
            var sut = new Json(arbitraryVersion, arbitraryType, null);

            // Assert
        }
    }
}
