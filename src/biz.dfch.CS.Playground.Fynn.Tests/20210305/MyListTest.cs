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
using biz.dfch.CS.Playground.Fynn._20210305;
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
            var sut = new MyList<string>(2);
            sut.Add("World");
            sut.Add("Helmet");
            sut.Add("Breakpoint");

            // Act
            var result = sut.Search("World");

            // Assert
            Assert.AreEqual("World", result);
        }

        [TestMethod]
        public void SearchForElementWhichDoesNotExistReturnsDefault()
        {
            // Arrange
            var sut = new MyList<string>(2);
            sut.Add("World");
            sut.Add("Helmet");
            sut.Add("Breakpoint");

            // Act
            var result = sut.Search("Console");

            // Assert
            Assert.AreEqual(default(string), result);
        }

        [TestMethod]
        public void AddingElementsSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(4);
        
            // Act
            sut.Add("1");
            sut.Add("2");
            sut.Add("3");
            sut.Add("4");

            var start = sut.Start;
            var end = sut.End;

            // Assert
            Assert.AreEqual("1", start.Value);
            Assert.AreEqual("2", start.Next.Value);
            Assert.AreEqual("3", start.Next.Next.Value);
            Assert.AreEqual("4", start.Next.Next.Next.Value);
            
            Assert.AreEqual("4", end.Value);
            Assert.AreEqual("3", end.Previous.Value);
            Assert.AreEqual("2", end.Previous.Previous.Value);
            Assert.AreEqual("1", end.Previous.Previous.Previous.Value);
        }
        
        [TestMethod]
        public void AddingElementAtPositionThreeSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(100);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("World");

            // Act
            sut.AddAt(2, "AddAt");

            var start = sut.Start;
            var end = sut.End;

            // Assert
            Assert.AreEqual("Hello", start.Value);
            Assert.AreEqual("My", start.Next.Value);
            Assert.AreEqual("AddAt", start.Next.Next.Value);
            Assert.AreEqual("World", start.Next.Next.Next.Value);

            Assert.AreEqual("World", end.Value);
            Assert.AreEqual("AddAt", end.Previous.Value);
            Assert.AreEqual("My", end.Previous.Previous.Value);
            Assert.AreEqual("Hello", end.Previous.Previous.Previous.Value);
        }

        [TestMethod]
        public void AddingElementAtPositionFourWhenListIsThreeElementSucceeds()
        {
            // Arrange
            var sut = new MyList<string>(100);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("World");

            // Act
            sut.AddAt(3, "AddAt");

            var start = sut.Start;
            var end = sut.End;

            // Assert
            Assert.AreEqual("Hello", start.Value);
            Assert.AreEqual("My", start.Next.Value);
            Assert.AreEqual("World", start.Next.Next.Value);
            Assert.AreEqual("AddAt", start.Next.Next.Next.Value);

            Assert.AreEqual("AddAt", end.Value);
            Assert.AreEqual("World", end.Previous.Value);
            Assert.AreEqual("My", end.Previous.Previous.Value);
            Assert.AreEqual("Hello", end.Previous.Previous.Previous.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingElementAtPositionSixWhenListIsOnlyThreeElementsLongThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var sut = new MyList<string>(100);
            sut.Add("Hello");
            sut.Add("My");
            sut.Add("World");

            // Act
            sut.AddAt(6, "AddAt");

            // Assert
        }
        //
        //[TestMethod]
        //public void DeletingElementAtPositionThreeFromListSucceeds()
        //{
        //    // Arrange
        //    var sut = new MyList<string>(3)
        //    {
        //        "Hello",
        //        "My",
        //        "World"
        //    };
        //
        //    // Act
        //    sut.DeleteAt(3);
        //
        //    // Assert
        //    Assert.AreEqual(2, sut.Count);
        //
        //}
        //
        //[TestMethod]
        //public void DeletingElementFromListSucceeds()
        //{
        //    // Arrange
        //    var sut = new MyList<string>(3)
        //    {
        //        "Hello",
        //        "My",
        //        "World"
        //    };
        //
        //    // Act
        //    sut.Delete("World");
        //
        //    // Assert
        //    Assert.AreEqual(2, sut.Count);
        //}
        //
        //[TestMethod]
        //public void DeletingListSucceeds()
        //{
        //    // Arrange
        //    var sut = new MyList<string>(3)
        //    {
        //        "Hello",
        //        "My",
        //        "World"
        //    };
        //
        //    // Act
        //    sut.DeleteList();
        //
        //    // Assert
        //    Assert.AreEqual(null, sut);
        //}
        //
        //[TestMethod]
        //public void MovingElementFromPositionOneToPositionThreeSucceeds()
        //{
        //    // Arrange
        //    var sut = new MyList<string>(3)
        //    {
        //        "World",
        //        "Hello",
        //        "My"
        //    };
        //
        //    // Act
        //    sut.Move("World", 3);
        //
        //    // Assert
        //    Assert.AreEqual("Hello", sut[1]);
        //    Assert.AreEqual("My", sut[2]);
        //    Assert.AreEqual("World", sut[3]);
        //}
        //
        //[TestMethod]
        //public void SwitchElementAtPositionOneWithElementAtPositionThreeSucceeds()
        //{
        //    // Arrange
        //    var sut = new MyList<string>(3)
        //    {
        //        "World",
        //        "My",
        //        "Hello"
        //    };
        //
        //    // Act
        //    sut.Swap(1, 3);
        //
        //    // Assert
        //    Assert.AreEqual("Hello", sut[1]);
        //    Assert.AreEqual("My", sut[2]);
        //    Assert.AreEqual("World", sut[3]);
        //}
        //
        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void AddingFifthElementToListWithCapacityOfFourThrowsException()
        //{
        //    // Arrange
        //    var sut = new MyList<string>(4)
        //    {
        //        "Hello",
        //        "My",
        //        "World",
        //        "!"
        //    };
        //
        //    // Act
        //    sut.Add("Bad");
        //
        //    // Assert
        //}
    }  
}
