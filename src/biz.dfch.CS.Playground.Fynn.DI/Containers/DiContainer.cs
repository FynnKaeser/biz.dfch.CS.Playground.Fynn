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

using biz.dfch.CS.Playground.Fynn.DI.Registries;
using StructureMap;

namespace biz.dfch.CS.Playground.Fynn.DI.Containers
{
    public class DiContainer
    {
        private static readonly object _lock = new object();
        private static DiContainer _diContainer;
        public Container Container { get; }

        private DiContainer()
        {
            var registry = new Registry();
            registry.IncludeRegistry<DefaultRegistry>();

            Container = new Container(registry);
        }

        public static DiContainer GetInstance()
        {
            if (null == _diContainer)
            {
                lock (_lock)
                {
                    if (null == _diContainer)
                    {
                        _diContainer = new DiContainer();
                    }
                }
            }

            return _diContainer;
        }
    }
}
