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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Adapter_Pattern
{
    public class Adapter : IJsonAdapter
    {
        private readonly Service service;

        public Adapter(Service service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string GetJsonValue(Xml xml)
        {
            if (null == xml)
            {
                return service.GetValue(null);
            }

            var version = xml.Version;
            var type = xml.Type;
            var value = xml.Value > 0 ? xml.Value.ToString() : null;

            var json = new Json(version, type, value);

            return service.GetValue(json);
        }
    }
}
