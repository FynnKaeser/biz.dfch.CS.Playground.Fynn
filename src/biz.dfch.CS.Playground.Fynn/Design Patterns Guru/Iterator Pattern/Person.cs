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
    public class Person : IIterable<Person>
    {
        public string Name { get; set; }
        public Class Class { get; set; }
        public List<Person> Friends { get; set; }

        public Person(string name, Class @class, List<Person> friends)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Class = @class ?? throw new ArgumentNullException(nameof(@class));
            Friends = friends ?? throw new ArgumentNullException(nameof(friends));
        }

        public IIterator<Person> GetIterator<TIterator>(string typeName) where TIterator : IIterator<Person>
        {
            if (string.IsNullOrWhiteSpace(typeName))
            {
                throw new ArgumentNullException(nameof(typeName));
            }

            switch (typeName)
            {
                case nameof(PersonClassmatesIterator):
                    return new PersonClassmatesIterator(this);
                case nameof(PersonFriendsIterator):
                    return new PersonFriendsIterator();
                default:
                    return null;
            }
        }

        private bool Equals(Person other)
        {
            if (null == other) return false;

            return Name == null ? Name == other.Name : Name.Equals(other.Name)
                                                       && Class.Equals(other.Class)
                                                       && Friends.SequenceEqual(other.Friends);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            var hashName = string.IsNullOrWhiteSpace(Name) ? 0 : Name.GetHashCode();
            var hashClass = Class.GetHashCode();
            var hashFriends = Friends.GetHashCode();

            return hashName ^ hashClass ^ hashFriends;
        }
    }
}
