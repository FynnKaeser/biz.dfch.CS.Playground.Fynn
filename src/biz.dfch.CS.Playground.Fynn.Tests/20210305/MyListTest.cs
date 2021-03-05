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
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210305
{
    [TestClass]
    public class MyListTest
    {
        [TestMethod]
        public void SearchForElementInListReturnsElement()
        {
            // Arrange
            var sut = new MyList<string>(2)
            {
                "Hello",
                "World"
            };

            // Act
            var result = sut.Search("World");

            // Assert
            Assert.AreEqual("World", result);
        }

        [TestMethod]
        public void AddingElementAtLastPositionSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(4)
            {
                "Hello",
                "My",
                "World"
            };

            // Act
            sut.Add("!");

            // Assert
            Assert.AreEqual(4, sut.Count);
            Assert.AreEqual("!", sut[4]);
        }

        [TestMethod]
        public void AddingElementAtPositionThreeSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(4)
            {
                "Hello",
                "My",
                "!"
            };

            // Act
            sut.AddAt(3, "World");

            // Assert
            Assert.AreEqual(4, sut.Count);
            Assert.AreEqual("World", sut[3]);
            Assert.AreEqual("!", sut[4]);
        }

        [TestMethod]
        public void DeletingElementAtPositionThreeFromListSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(3)
            {
                "Hello",
                "My",
                "World"
            };

            // Act
            sut.DeleteAt(3);

            // Assert
            Assert.AreEqual(2, sut.Count);

        }

        [TestMethod]
        public void DeletingElementFromListSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(3)
            {
                "Hello",
                "My",
                "World"
            };

            // Act
            sut.Delete("World");

            // Assert
            Assert.AreEqual(2, sut.Count);
        }

        [TestMethod]
        public void DeletingListSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(3)
            {
                "Hello",
                "My",
                "World"
            };

            // Act
            sut.DeleteList();

            // Assert
            Assert.AreEqual(null, sut);
        }

        [TestMethod]
        public void MovingElementFromPositionOneToPositionThreeSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(3)
            {
                "World",
                "Hello",
                "My"
            };

            // Act
            sut.Move(1, 3);

            // Assert
            Assert.AreEqual("Hello", sut[1]);
            Assert.AreEqual("My", sut[2]);
            Assert.AreEqual("World", sut[3]);
        }

        [TestMethod]
        public void SwitchElementAtPositionOneWithElementAtPositionThreeSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(3)
            {
                "World",
                "My",
                "Hello"
            };

            // Act
            sut.Swap(1, 3);

            // Assert
            Assert.AreEqual("Hello", sut[1]);
            Assert.AreEqual("My", sut[2]);
            Assert.AreEqual("World", sut[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddingFifthElementToListWithCapacityOfFourThrowsException()
        {
            // Arrange
            var sut = new MyList<string>(4)
            {
                "Hello",
                "My",
                "World",
                "!"
            };

            // Act
            sut.Add("Bad");

            // Assert
        }
    }
}
