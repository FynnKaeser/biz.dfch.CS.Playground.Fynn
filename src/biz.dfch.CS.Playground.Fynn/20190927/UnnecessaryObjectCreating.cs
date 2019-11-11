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

namespace biz.dfch.CS.Playground.Fynn._20190927
{
    public class UnnecessaryObjectCreating
    {
        private const string PREFIX = "Prefix_";
        private const string SUFFIX = "_Suffix";

        public bool StringTester(string element)
        {
            var resultEndsWith = element.EndsWith(SUFFIX);
            var resultStartsWith = element.StartsWith(PREFIX);
            return resultStartsWith && resultEndsWith;
        }


        //public bool StringTester(string element)
        //{
        //    var Suffix = "_Suffix";
        //    var Prefix = "Prefix_";
        //    var resultEndsWith = element.EndsWith(Suffix);
        //    var resultStartsWith = element.StartsWith(Prefix);
        //    return (resultStartsWith && resultEndsWith);
        //}
    }
}