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
using System.ComponentModel;

namespace biz.dfch.CS.Playground.Fynn._20191016
{
    // Improper extra coupling.
    public interface IPredicate<T>
    {
        bool Match(T soughtObject);
    }

    public class ListItem<T>
    {
        public void RemoveAll(IPredicate<T> match)
        {
            // elided
            var x = new Component();
        }

        // Other apis elided
    }

    //The usage for this second version is quite a bit more work:
    public class MyPredicate : IPredicate<int>
    {
        public bool Match(int target)
        {
            return target < 100;
        }
    }

    public static class Item34
    {
        public static IEnumerable<TResult> Zip<T1, T2, TResult>(
            IEnumerable<T1> first,
            IEnumerable<T2> second,
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