﻿/**
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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Iterator_Pattern
{
    public class Person : IIterable<Person>
    {
        public string Name { get; set; }
        public Class Class { get; set; }
        public List<Person> Friends { get; set; }

        public Person(string name, Class @class, List<Person> friends)
        {
            Name = name;
            Class = @class;
            Friends = friends;
        }

        public IIterator<Person> GetIterator<TIterator>() where TIterator : IIterator<Person>
        {
            throw new System.NotImplementedException();
        }
    }
}
