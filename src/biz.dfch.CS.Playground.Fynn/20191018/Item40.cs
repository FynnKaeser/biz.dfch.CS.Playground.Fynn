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

namespace biz.dfch.CS.Playground.Fynn._20191018
{
    public class Item40
    {
        public static string DoStuff(string x, string y, string s)
        {
            return x + y;
        }

        public static string One()
        {
            return "Ha";
        }
        public static string Two()
        {
            return "llo";
        }

        public static object DoStuff(Func<string> x, Func<string> y, Func<string> s)
        {
            var result = x.Invoke() + y.Invoke();
            
            return result;
        }

        public static string Three()
        {
            return "fail";
        }
    }
}
