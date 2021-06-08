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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Bridge_Pattern
{
    public class IpAddress
    {
        private readonly char dot = '.';
        private readonly int maxValue = 255;
        private readonly int minValue = 0;

        public int Section1 { get; set; }
        public int Section2 { get; set; }
        public int Section3 { get; set; }
        public int Section4 { get; set; }

        public IpAddress(int section1, int section2, int section3, int section4)
        {
            if (section1 > maxValue || section1 < minValue)
            {
                throw new ArgumentOutOfRangeException(nameof(section1));
            }
            if (section2 > maxValue || section2 < minValue)
            {
                throw new ArgumentOutOfRangeException(nameof(section1));
            }
            if (section3 > maxValue || section3 < minValue)
            {
                throw new ArgumentOutOfRangeException(nameof(section1));
            }
            if (section4 > maxValue || section4 < minValue)
            {
                throw new ArgumentOutOfRangeException(nameof(section1));
            }

            Section1 = section1;
            Section2 = section2;
            Section3 = section3;
            Section4 = section4;
        }

        public override string ToString()
        {
            return Section1.ToString() + dot + Section2 + dot + Section3 + dot + Section4;
        }
    }
}
