/**
 * Copyright 2020 d-fens GmbH
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

namespace biz.dfch.CS.Playground.Fynn._20200309
{
    public static class StringExtensions
    {
        private const char SpaceSeparator = ' ';

        public static string Short(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return str;
            var result = new StringBuilder();

            var words = str.Split(SpaceSeparator).ToList();
            words.ForEach(s =>
            {
                var myString = s.First().ToString().ToUpper() + s.Substring(1);
                result.Append(myString);
            });

            return result.ToString();
        }

        public static string Short2(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return str;
            var result = new StringBuilder();

            var words = str.Split(SpaceSeparator).ToList();
            words.ForEach(s =>
            {
                var myString = s.First().ToString().ToLower() + s.Substring(1);
                result.Append(myString + "-");
            });

            return result.ToString();
        }
    }
}
