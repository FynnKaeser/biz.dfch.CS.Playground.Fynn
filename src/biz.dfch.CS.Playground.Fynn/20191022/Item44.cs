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

namespace biz.dfch.CS.Playground.Fynn._20191022
{
    public class Item44
    {
        private static Func<int, int> HiddenDelegateDefinition;

        public static void Seq()
        {
            int[] someNumbers = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var answers = from n in someNumbers
                select n * n;
        }

        private static int HiddenFunc(int n)
        {
            return n * n;
        }

        public static void DelegateMethod()
        {
            int[] someNumbers = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            if (HiddenDelegateDefinition == null) HiddenDelegateDefinition = HiddenFunc;
            var answers = someNumbers
                .Select(HiddenDelegateDefinition);
        }
    }

    public class ModFilter
    {
        // original delegate
        private static Func<int, int> SelectDelegate;
        private readonly int modulus;

        // New method
        private bool WhereClause(int n)
        {
            return n % modulus == 0;
        }

        // original method
        private static int SelectClause(int n)
        {
            return n * n;
        }

        public IEnumerable<int> FindValues(
            IEnumerable<int> sequence)
        {
            if (SelectDelegate == null) SelectDelegate = SelectClause;
            return sequence.Where(
                WhereClause).Select(SelectClause);
        }

        // Other methods elided.
    }

    public class ModFilter2
    {
        // original delegate
        private static Func<int, int> SelectDelegate;
        private readonly int modulus;

        // New method
        private bool WhereClause(int n)
        {
            return n % modulus == 0;
        }

        // original method
        private static int SelectClause(int n)
        {
            return n * n;
        }

        public IEnumerable<int> FindValues(
            IEnumerable<int> sequence)
        {
            if (SelectDelegate == null) SelectDelegate = SelectClause;
            return sequence.Where(
                WhereClause).Select(SelectClause);
        }
    }
}