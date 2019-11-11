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

namespace biz.dfch.CS.Playground.Fynn._20191014
{
    public class Item31
    {
        public static IEnumerable<string> Zip(IEnumerable<string> first, IEnumerable<string> second)
        {
            if (null == first || null == second) throw new ArgumentNullException();

            if (first.Count() != second.Count()) throw new ArgumentException("Sequences don't have the same lenght");

            using (var firstSequence = first.GetEnumerator())
            {
                using (var secondSequence =
                    second.GetEnumerator())
                {
                    while (firstSequence.MoveNext() &&
                           secondSequence.MoveNext())
                        yield return $"{firstSequence.Current} {secondSequence.Current}";
                }
            }
        }

        public static IEnumerable<TResult> ZipFunc<T1, T2, TResult>(IEnumerable<T1> first, IEnumerable<T2> second,
            Func<T1, T2, TResult> zipper)
        {
            using (var firstSequence = first.GetEnumerator())
            {
                using (var secondSequence =
                    second.GetEnumerator())
                {
                    while (firstSequence.MoveNext() &&
                           secondSequence.MoveNext())
                        yield return zipper(firstSequence.Current,
                            secondSequence.Current);
                }
            }
        }
    }
}