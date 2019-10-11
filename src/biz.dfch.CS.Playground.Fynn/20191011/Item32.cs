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

namespace biz.dfch.CS.Playground.Fynn._20191011
{
    public class Item32
    {
        private static IEnumerable<Tuple<int, int>> Linq()
        {
            return Enumerable.Range(0, 100)
                .SelectMany(x => Enumerable.Range(0, 100), (x, y) => new {x, y})
                .Where(@t => @t.x + @t.y < 100)
                .OrderByDescending(@t => (@t.x * @t.x + @t.y * @t.y))
                .Select(t1 => Tuple.Create(t1.x, t1.y));
        }

        private static IEnumerable<Tuple<int, int>> QueryIndices()
        {
            return from x in Enumerable.Range(0, 100)
                from y in Enumerable.Range(0, 100)
                where x + y < 100
                orderby (x * x + y * y) descending
                select Tuple.Create(x, y);
        }

        public static IEnumerable<Tuple<int, int>> ProduceIndices()
        {
            return from x in Enumerable.Range(0, 100)
                from y in Enumerable.Range(0, 100)
                where x + y < 100
                orderby (x * x + y * y) descending
                select Tuple.Create(x, y);
        }
    }
}
