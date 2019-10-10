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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Playground.Fynn._20191010
{
    public class IteratorMethod
    {
        public string CallIteratorMethod()
        {
            var allNumbersAsString = "";
            foreach (var number in Numbers())
            {
                allNumbersAsString += number.ToString();
            }

            return allNumbersAsString;
        }

        public IEnumerable Numbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield break;
            yield return 5;
        }
    }
}
