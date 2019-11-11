﻿/**
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
using biz.dfch.CS.Playground.Fynn._20190918;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20190918
{
    [TestClass]
    public class NameOfClassTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Cant be null!")]
        public void CallingExceptionMessageMethodWithNullSucceedsIfThrowsAnArgumentNullException()
        {
            // Arrange
            var sut = new NameOfClass();

            // Act
            sut.ExceptionMessage(null);

            //Assert
            // N/A
        }

        [TestMethod]
        public void NameOfTwoObjectsAreTheSameAndReturnTrue()
        {
            // Arrange
            var sut = new NameOfClass();

            // Act
            sut.ChangeNameOfProperty();

            //Assert
        }
    }
}