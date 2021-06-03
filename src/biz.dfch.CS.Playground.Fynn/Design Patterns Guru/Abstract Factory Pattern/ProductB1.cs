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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Abstract_Factory_Pattern
{
    public class ProductB1 : IProductB
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }

        public ProductB1(string name, string ipAddress)
        {
            Name = name;
            IpAddress = ipAddress;
        }

        public void DoSomething()
        {
            throw new System.NotImplementedException();
        }
    }
}
