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
    public abstract class FileAnalyzer
    {
        public FileData FileData { get; set; }
        public abstract void OpenFile(string fileName);
        public abstract FileData GetFileData();

        public void CloseFile()
        {
            FileData = null;
        }

        public string Analyze(FileData fileData)
        {
            if (null == fileData)
            {
                throw new ArgumentNullException(nameof(fileData));
            }

            var data = fileData.Data;
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException(nameof(data));
            }

            // Analyze Data ...

            return data;
        }

        public string Read(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException();
            }

            OpenFile(fileName);

            var fileData = GetFileData();
            if (null == fileData)
            {
                throw new ArgumentNullException(nameof(fileData));
            }

            var result = Analyze(fileData);
            CloseFile();

            return result;
        }
    }
}
