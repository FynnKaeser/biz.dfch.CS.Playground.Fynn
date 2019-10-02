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

namespace biz.dfch.CS.Playground.Fynn._20191002
{
    public abstract class CelestialBody : IComparable<CelestialBody>
    {
        public double Mass { get; set; }
        public string Name { get; set; }
        // elided

        public int CompareTo(CelestialBody other)
        {
            throw new NotImplementedException();
        }
    }

    public class Planet : CelestialBody
    {
        public void DoStuffWithArray(CelestialBody[] celestialBody)
        {

        }

        public void DoStuff(CelestialBody celestialBody)
        {

        }

        public void DoStuffWithIEnumerable(IEnumerable<CelestialBody> celestialBody)
        {

        }

        public void DoStuffWithIComparable(IComparable<CelestialBody> celestialBody)
        {

        }
        // elided
    }

    public class Moon : CelestialBody
    {
        // elided
    }

    public class Asteroid : CelestialBody
    {
        // elided
    }
}
