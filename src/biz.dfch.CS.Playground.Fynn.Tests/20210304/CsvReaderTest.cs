﻿/**
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

using System.Collections.Generic;
using System.Globalization;
using biz.dfch.CS.Playground.Fynn._20210304;
using CsvHelper.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests
{
    [TestClass]
    public class CsvReaderTest
    {
        private readonly List<CsvGeographyData> expectedCsvData = new List<CsvGeographyData>();
        private readonly string Semicolon = ";";
        private readonly string FilePath = "C:\\src\\biz.dfch.CS.Playground.Fynn\\src\\biz.dfch.CS.Playground.Fynn\\20210304\\KANTON_ZUERICH_43.csv";

        [TestMethod]
        public void GetCsvDataReturnsExpectedData()
        {
           // Arrange
           var sut = new CsvReader<CsvGeographyData>();
           var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
           {
               Delimiter = Semicolon
           };

            // Act
            var result = sut.GetCsvData<CsvGeographyDataMap>(FilePath, csvConfiguration);

           // Assert
           Assert.AreEqual(expectedCsvData, result);
        }
    }
}
