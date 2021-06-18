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

using System.Collections.Generic;
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Iterator_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Iterator_Pattern
{
    [TestClass]
    public class PersonFriendsIteratorTest
    {
        private readonly List<Person> listOfPersons = new List<Person>
        {
            new Person("Alex", new Class("A-Class") , new List<Person>()),
            new Person("Meier", new Class("B-Class"), new List<Person>()),
            new Person("Laura", new Class("B-Class"), new List<Person>()),
            new Person("Müller", new Class("A-Class"), new List<Person>()),
            new Person("Lucas", new Class("A-Class"), new List<Person>()),
            new Person("Peter", new Class("B-Class"), new List<Person>()),
        };

        [TestMethod]
        public void PersonFriendsIteratorSucceeds()
        {
            // Arrange
            var person = new Person("Fynn", new Class("A-Class"), listOfPersons);

            var sut = person.GetIterator<PersonFriendsIterator>(nameof(PersonFriendsIteratorSucceeds));

            // Act & Assert
            var counter = 0;
            while (sut.HasMore())
            {
                var personToAssert = sut.GetNext();
                var expectedPerson = listOfPersons[counter];

                Assert.AreEqual(expectedPerson, personToAssert);

                counter++;
            }
        }
    }
}
