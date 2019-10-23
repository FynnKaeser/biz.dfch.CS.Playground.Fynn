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

namespace biz.dfch.CS.Playground.Fynn._20191022
{
    public class Item44
    {
        public static void Seq()
        {
            int[] someNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var answers = from n in someNumbers
                          select n * n;

        }

        private static int HiddenFunc(int n) => (n * n);

        private static Func<int, int> HiddenDelegateDefinition;

        public static void DelegateMethod()
        {
            int[] someNumbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            if (HiddenDelegateDefinition == null)
            {
                HiddenDelegateDefinition = new
                    Func<int, int>(HiddenFunc);
            }
            var answers = someNumbers
                .Select<int, int>(HiddenDelegateDefinition);
        }
    }

    public class ModFilter
    {
        private readonly int modulus;

        // New method
        private bool WhereClause(int n) =>
            ((n % this.modulus) == 0);

        // original method
        private static int SelectClause(int n) =>
            (n * n);

        // original delegate
        private static Func<int, int> SelectDelegate;

        public IEnumerable<int> FindValues(
            IEnumerable<int> sequence)
        {
            if (SelectDelegate == null)
            {
                SelectDelegate = new Func<int, int>(SelectClause);
            }
            return sequence.Where<int>(
                    new Func<int, bool>(this.WhereClause)).
                Select<int, int>(SelectClause);
        }
        // Other methods elided.
    }

    public class ModFilter2
    {
        private readonly int modulus;

        // New method
        private bool WhereClause(int n) =>
            ((n % this.modulus) == 0);

        // original method
        private static int SelectClause(int n) =>
            (n * n);

        // original delegate
        private static Func<int, int> SelectDelegate;

        public IEnumerable<int> FindValues(
            IEnumerable<int> sequence)
        {
            if (SelectDelegate == null)
            {
                SelectDelegate = new Func<int, int>(SelectClause);
            }
            return sequence.Where<int>(
                    new Func<int, bool>(this.WhereClause)).
                Select<int, int>(SelectClause);
        }
    }

}
