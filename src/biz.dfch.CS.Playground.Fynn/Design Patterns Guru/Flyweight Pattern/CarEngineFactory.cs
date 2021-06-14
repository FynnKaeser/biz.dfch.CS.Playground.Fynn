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
using System.Linq;

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Flyweight_Pattern
{
    public class CarEngineFactory
    {
        private readonly List<CarEngine> carEnginesPool;
        private readonly int threshold = 1;
        
        public CarEngineFactory()
        {
            carEnginesPool = new List<CarEngine>();
        }

        public CarEngine GetCarEngine(int horsePower, int thrustInKiloNewton)
        {
            if (horsePower < threshold)
            {
                throw new ArgumentOutOfRangeException(nameof(horsePower));
            }

            if (thrustInKiloNewton < threshold)
            {
                throw new ArgumentOutOfRangeException(nameof(thrustInKiloNewton));
            }

            var carEngine = carEnginesPool.FirstOrDefault(engine => engine.HorsePower == horsePower && engine.Thrust == thrustInKiloNewton);

            if (null != carEngine) return carEngine;

            carEngine = new CarEngine(horsePower, thrustInKiloNewton);
            carEnginesPool.Add(carEngine);

            return carEngine;
        }
    }
}
