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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Template_Method_Pattern
{
    public class FileData
    {
        public string Name { get; set; }
        public FileEnding FileEnding { get; set; }
        public string Data { get; set; }


        public FileData(string name, FileEnding fileEnding)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            if (FileEnding.None == fileEnding)
            {
                throw new ArgumentException(nameof(fileEnding));
            }

            Name = name;
            FileEnding = fileEnding;
        }
        public FileData(string name, FileEnding fileEnding, string data)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException(nameof(data));
            }

            if (FileEnding.None == fileEnding)
            {
                throw new ArgumentException(nameof(fileEnding));
            }

            Name = name;
            FileEnding = fileEnding;
            Data= data;
        }
    }
}
