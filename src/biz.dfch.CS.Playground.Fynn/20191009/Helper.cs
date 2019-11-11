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

namespace biz.dfch.CS.Playground.Fynn._20191009
{
    public static class Helper
    {
        public static T Max<T>(T left, T right)
        {
            return Comparer<T>.Default.Compare(left, right) < 0 ? right : left;
        }

        public static T Min<T>(T left, T right)
        {
            return Comparer<T>.Default.Compare(left, right) < 0 ? left : right;
        }

        public static int Max(int left, int right)
        {
            return Math.Max(left, right);
        }

        public static int Min(int left, int right)
        {
            return Math.Min(left, right);
        }

        public static float Max(float left, float right)
        {
            return Math.Max(left, right);
        }

        public static float Min(float left, float right)
        {
            return Math.Min(left, right);
        }

        public static double Max(double left, double right)
        {
            return Math.Max(left, right);
        }

        public static double Min(double left, double right)
        {
            return Math.Min(left, right);
        }
    }
}