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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Strategy_Pattern
{
    public class Place
    {
        private readonly int LongitudeMax = 180;
        private readonly int LatitudeMax = 90;
        private readonly int CoordinateMin = 0;

        public int Longitude { get; set; }
        public int Latitude { get; set; }

        public Place(int longitude, int latitude)
        {
            if (longitude > LongitudeMax || longitude < CoordinateMin)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            if (latitude > LatitudeMax || latitude < CoordinateMin)
            {
                throw new ArgumentOutOfRangeException();
            }

            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
