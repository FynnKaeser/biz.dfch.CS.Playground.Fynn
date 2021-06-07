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

namespace biz.dfch.CS.Playground.Fynn.Working_with_LINQ
{
    public class MySampleClass
    {
        public static IEnumerable<T> Select<T>(IEnumerable<T> sequence, Func<T, T> method)
        {
            if (null == sequence)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            if (default == method)
            {
                throw new ArgumentNullException(nameof(method));
            }

            foreach (var element in sequence)
            {
                yield return method(element);
            }
        }
    }
}
