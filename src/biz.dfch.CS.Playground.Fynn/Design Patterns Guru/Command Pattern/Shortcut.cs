

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Diagnostics.Tracing.Parsers;

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
namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Command_Pattern
{
    public class Shortcut
    {
        private readonly Dictionary<string, Lazy<ICommand>> methodCommandMap = new Dictionary<string, Lazy<ICommand>>()
        {
            { nameof(OnSave), new Lazy<ICommand>(() => new SaveCommand()) },
            { nameof(OnCopy), new Lazy<ICommand>(() => new CopyCommand()) },
        };

        public string OnSave()
        {
            return methodCommandMap[nameof(OnSave)].Value.Execute();
        }

        public string OnCopy()
        {
            return methodCommandMap[nameof(OnCopy)].Value.Execute();

        }
    }
}
