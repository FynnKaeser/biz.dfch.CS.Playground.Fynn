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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Abstract_Factory_Pattern
{
    public class AbstractFactory2 : IAbstractFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA2("The A2 Name", "4.3.2.1");
        }

        public IProductB CreateProductB()
        {
            return new ProductB2("The B2 Name", "4.3.2.1");
        }
    }
}
