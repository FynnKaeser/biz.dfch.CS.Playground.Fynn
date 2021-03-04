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
    public class CsvReader<TCsvData>
    {
        private const char Dot = '.';
        private const string Csv = "csv";
        private const string Txt = "txt";

        public List<TCsvData> GetCsvData<TCsvDataClassMap>(string filePath, CsvConfiguration csvConfiguration) where TCsvDataClassMap : ClassMap
        {
            if (null == filePath || null == csvConfiguration)
            {
                throw new ArgumentNullException();
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            var fileEnding = filePath.Substring(filePath.LastIndexOf(Dot) + 1);
            if (fileEnding != Csv && fileEnding!= Txt)
            {
                throw new InvalidDataException();
            }

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                try
                {
                    csv.Context.RegisterClassMap<TCsvDataClassMap>();
                    var csvDataRecords = csv.GetRecords<TCsvData>();

                    return csvDataRecords.ToList();
                }
                catch (CsvHelperException e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }
    }
}
