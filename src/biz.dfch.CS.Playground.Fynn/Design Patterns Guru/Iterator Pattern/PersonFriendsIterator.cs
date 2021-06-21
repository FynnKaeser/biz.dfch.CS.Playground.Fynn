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
using System.Linq;

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Iterator_Pattern
{
    public class PersonFriendsIterator : IIterator<Person>
    {
        private readonly List<Person> friends;
        private readonly int friendsCount;
        private int counter;

        public PersonFriendsIterator(Person person)
        {
            Current = person ?? throw new ArgumentNullException(nameof(person));
            friends = person.Friends ?? new List<Person>();

            friends = friends.Where(p => p != null).ToList();
            friendsCount = friends.Count;
        }

        public Person Current { get; }

        public Person GetNext()
        {
            return HasMore() ? friends[counter++] : null;
        }

        public bool HasMore()
        {
            return counter != friendsCount;
        }

        public void Reset()
        {
            counter = 0;
        }
    }
}
