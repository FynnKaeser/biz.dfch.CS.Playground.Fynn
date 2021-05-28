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
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace biz.dfch.CS.Playground.Fynn._20210304
{
    public class CsvReader<TCsvData> where TCsvData : class
    {
        private readonly List<string> allowedFileEndings = new List<string>()
        {
            "csv",
            "txt"
        };
        private readonly CsvConfiguration csvConfiguration;

        public CsvReader(CsvConfiguration csvConfiguration)
        {
            this.csvConfiguration = csvConfiguration;
        }

        public List<TCsvData> GetCsvData<TCsvDataClassMap>(string filePath) where TCsvDataClassMap : ClassMap
        {
            if (null == filePath || null == csvConfiguration) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException();

            var fileChecker = new FileChecker();
            var hasCorrectFileEnding = fileChecker.CheckFileEnding(allowedFileEndings, filePath);
            if (!hasCorrectFileEnding) throw new InvalidDataException();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                csv.Context.RegisterClassMap<TCsvDataClassMap>();

                IEnumerable<TCsvData> csvDataRecords;
                try
                {
                    csvDataRecords = csv.GetRecords<TCsvData>();
                }
                catch (CsvHelperException e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return csvDataRecords.ToList();
            }
        }
    }
}
