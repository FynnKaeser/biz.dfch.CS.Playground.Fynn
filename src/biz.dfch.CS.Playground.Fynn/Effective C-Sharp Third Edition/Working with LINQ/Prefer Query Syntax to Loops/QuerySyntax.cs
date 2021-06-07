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
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace biz.dfch.CS.Playground.Fynn.Working_with_LINQ.Prefer_Query_Syntax_to_Loops
{
    public class QuerySyntax
    {
        public int[] FirstExampleNonQuery()
        {
            var foo = new int[100];

            for (int i = 0; i < foo.Length; i++)
            {
                foo[i] = i * i;
            }

            foreach (var i in foo)
            {
                Debug.WriteLine(i.ToString());
            }

            return foo;
        }
        
        public int[] FirstExampleQuery()
        {
            var foo = (from n in Enumerable.Range(0, 100) select n * n).ToArray();

            return foo;
        }

        public IEnumerable<Tuple<int, int>> CreateValuePairsForLoop()
        {
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    yield return Tuple.Create(x, y);
                }
            }
        }

        public IEnumerable<Tuple<int, int>> CreateValuePairsQuery()
        {
            return from x in Enumerable.Range(0, 100)
                from y in Enumerable.Range(0, 100)
                select Tuple.Create(x, y);
        }

        public IEnumerable<Tuple<int, int>> CreateValuePairs2ForLoop()
        {
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    if (x + y < 100)
                    {
                        yield return Tuple.Create(x, y);
                    }
                }
            }
        }

        public IEnumerable<Tuple<int, int>> CreateValuePairs2Query()
        {
            return from x in Enumerable.Range(0, 100)
                from y in Enumerable.Range(0, 100)
                where x + y < 100
                select Tuple.Create(x, y);
        }

        public IEnumerable<Tuple<int, int>> CreateOrderedValuePairForLoop()
        {
            var storage = new List<Tuple<int, int>>();
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    if (x + y < 100)
                    {
                        storage.Add(Tuple.Create(x, y));
                    }
                }
            }

            storage.Sort((point1, point2)
                => (point2.Item1 * point2.Item1 + point2.Item2 * point2.Item2)
                .CompareTo(point1.Item1 * point1.Item1 + point1.Item2 * point1.Item2));

            return storage;
        }

        public IEnumerable<Tuple<int, int>> CreateOrderValuePairQuery()
        {
            return from x in Enumerable.Range(0, 100)
                from y in Enumerable.Range(0, 100)
                where x + y < 100
                orderby (x*x + y*y) descending 
                select Tuple.Create(x, y);
        }
    }
}
