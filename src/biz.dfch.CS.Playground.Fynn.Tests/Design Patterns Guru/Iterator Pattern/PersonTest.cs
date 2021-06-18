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
using System.Collections.Generic;
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Iterator_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Iterator_Pattern
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void EqualsSucceeds()
        {
            // Arrange
            var arbitraryClassName = "A-Class";
            var arbitraryName = "Alex";
            var arbitraryFriends = new List<Person>();
            var arbitraryClass = new Class(arbitraryClassName);
            var sut = new Person(arbitraryName, arbitraryClass, arbitraryFriends);
            var comparisionPerson = new Person(arbitraryName, arbitraryClass, arbitraryFriends);

            // Act
            var result = sut.Equals(comparisionPerson);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsWithOtherPersonNullSucceeds()
        {
            // Arrange
            var arbitraryClassName = "A-Class";
            var arbitraryName = "Alex";
            var arbitraryFriends = new List<Person>();
            var arbitraryClass = new Class(arbitraryClassName);
            var sut = new Person(arbitraryName, arbitraryClass, arbitraryFriends);

            // Act
            var result = sut.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualsWithNullValuesSucceeds()
        {
            // Arrange
            var arbitraryClassName = "A-Class";
            var arbitraryName = "Alex";
            var arbitraryFriends = new List<Person>();
            var arbitraryClass = new Class(arbitraryClassName);
            var sut = new Person(arbitraryName, arbitraryClass, arbitraryFriends);
            var comparisionPerson = new Person(arbitraryName, arbitraryClass, arbitraryFriends);

            sut.Name = null;
            sut.Class = null;
            sut.Friends = null;

            comparisionPerson.Name = null;
            comparisionPerson.Class = null;
            comparisionPerson.Friends = null;

            // Act
            var result = sut.Equals(comparisionPerson);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeNewPersonWithNullNameThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryClassName = "A-Class";
            var arbitraryFriends = new List<Person>();
            var arbitraryClass = new Class(arbitraryClassName);

            // Act
            var sut = new Person(null, arbitraryClass, arbitraryFriends);

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeNewPersonWithNullClassThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryName = "Alex";
            var arbitraryFriends = new List<Person>();

            // Act
            var sut = new Person(arbitraryName, null, arbitraryFriends);

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeNewPersonWithNullFriendsThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryClassName = "A-Class";
            var arbitraryName = "Alex";
            var arbitraryClass = new Class(arbitraryClassName);

            // Act
            var sut = new Person(arbitraryName, arbitraryClass, null);

            // Assert
        }

        [TestMethod]
        public void GetHashCodeSucceeds()
        {
            // Arrange
            var arbitraryClassName = "A-Class";
            var arbitraryName = "Alex";
            var arbitraryFriends = new List<Person>();
            var arbitraryClass = new Class(arbitraryClassName);
            var sut = new Person(arbitraryName, arbitraryClass, arbitraryFriends);

            var expectedHashCode = 953674107;

            // Act
            var result = sut.GetHashCode();

            // Assert
            Assert.AreEqual(expectedHashCode, result);
        }
    }
}
