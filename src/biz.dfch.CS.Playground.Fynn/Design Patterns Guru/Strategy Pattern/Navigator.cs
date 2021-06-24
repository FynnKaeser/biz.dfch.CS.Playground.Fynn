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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Strategy_Pattern
{
    public class Navigator
    {
        public IRoutePlaner RoutePlaner { get; private set; }

        public Navigator(IRoutePlaner routePlaner)
        {
            RoutePlaner = routePlaner ?? throw new ArgumentNullException(nameof(routePlaner));
        }

        public void SetRoutePlaner(IRoutePlaner routePlaner)
        {
            RoutePlaner = routePlaner ?? throw new ArgumentNullException(nameof(routePlaner));
        }
        
        public List<Route> BuildRoute(Place from, Place to)
        {
            if (null == from)
            {
                throw new ArgumentNullException(nameof(from));
            }
            
            if (null == to)
            {
                throw new ArgumentNullException(nameof(from));
            }

            return RoutePlaner.BuildRoute(from, to);
        }
    }
}
