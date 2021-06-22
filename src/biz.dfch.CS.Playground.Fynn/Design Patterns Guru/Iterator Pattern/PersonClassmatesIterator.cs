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
using System.Diagnostics.Contracts;
using System.Linq;

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Iterator_Pattern
{
    public class PersonClassmatesIterator : IIterator<Person>
    {
        private readonly IEnumerator<Person> friendEnumerator;

        private bool hasMore;

        public Person Current { get; private set; } = null;

        public PersonClassmatesIterator(Person person)
        {
            Contract.Assert(null != person);

            var friends = person.Friends ?? new List<Person>();

            var personClass = person.Class ?? throw new ArgumentNullException(nameof(person.Class));

            friendEnumerator = friends
                .Where(p => p?.Class != null && p.Class.Equals(personClass))
                .GetEnumerator();

            Reset();
        }

        public Person GetNext()
        {
            hasMore = friendEnumerator.MoveNext();

            var current = Current;
            Current = hasMore 
                ? friendEnumerator.Current
                : default;
            return current;
        }

        public bool HasMore()
        {
            return hasMore;
        }

        public void Reset()
        {
            friendEnumerator.Reset();
            GetNext();
        }
    }
}
