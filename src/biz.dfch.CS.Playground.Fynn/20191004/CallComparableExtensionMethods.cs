/**
 * Copyright 2019 d-fens GmbH
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
using System.Text;
using System.Threading.Tasks;
using biz.dfch.CS.Playground.Fynn._20191004;

namespace biz.dfch.CS.Playground.Fynn._20191004
{
    public class CallComparableExtensionMethods
    {
        public void CompareValues()
        {
            var x = new MyComparableClass();
            var y = new MyComparableClass();

            var integer = 4;
            var number = 5;

            var firstName = "Max";
            var lastname = "Mayer";

            var result = y.IsEqualTo(x);
            var intResult = number.GreaterThanEqual(5);
            var stringResult = firstName.LessThan(lastname);
        }
    }

    public class MyComparableClass : IComparable<MyComparableClass>
    {
        public int CompareTo(MyComparableClass other)
        {
            throw new NotImplementedException();
        }
    }
}
