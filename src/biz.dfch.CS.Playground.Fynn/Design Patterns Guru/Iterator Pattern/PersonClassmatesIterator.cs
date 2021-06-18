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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Iterator_Pattern
{
    public class PersonClassmatesIterator : IIterator<Person>
    {
        private readonly List<Person> friends;
        private readonly Class personClass;
        private readonly int friendsCount;
        private int counter;

        public Person Current { get; }

        public PersonClassmatesIterator(Person person)
        {
            Current = person ?? throw new ArgumentNullException(nameof(person));
            friends = person.Friends ?? new List<Person>();
            personClass = person.Class ?? throw new ArgumentNullException(nameof(person.Class));
            friendsCount = friends.Count;
        }

        public Person GetNext()
        {
            return HasMore() ? friends[counter++] : null;
        }

        public bool HasMore()
        {
            if (counter == friendsCount)
            {
                return false;
            }

            var friend = friends[counter];
            if (null == friend)
            {
                return false;
            }

            var friendClass = friend.Class;
            if (null == friendClass)
            {
                counter++;
                return HasMore();
            }

            if (personClass.Equals(friendClass))
            {
                return true;
            }

            counter++;
            return HasMore();
        }

        public void Reset()
        {
            counter = 0;
        }
    }
}
