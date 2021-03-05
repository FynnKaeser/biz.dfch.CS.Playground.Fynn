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
using System.Globalization;
using System.IO;
using System.Linq;
using biz.dfch.CS.Playground.Fynn._20210304;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests
{
    [TestClass]
    public class CsvReaderTest
    {
        private readonly List<StatisticalOfficeZurichCsvData> expectedCsvData = new List<StatisticalOfficeZurichCsvData>
        {
            new StatisticalOfficeZurichCsvData
            {
                BfsNr = 1,
                RegionName = "Aeugst a.A.",
                TopicName = "Raum und Umwelt",
                SetName = "Geographie, Flächen",
                SubsetName = "Höhe",
                IndicatorId = 43,
                IndicatorName = "Höhe [m.ü.M.]",
                IndicatorYear = 1995,
                IndicatorValue = 700,
                UnitShort = "m.ü.M.",
                UnitLong = "Meter über Meer"
            },
            new StatisticalOfficeZurichCsvData
            {
                BfsNr = 2,
                RegionName = "Affoltern a.A.",
                TopicName = "Raum und Umwelt",
                SetName = "Geographie, Flächen",
                SubsetName = "Höhe",
                IndicatorId = 43,
                IndicatorName = "Höhe [m.ü.M.]",
                IndicatorYear = 1995,
                IndicatorValue = 494,
                UnitShort = "m.ü.M.",
                UnitLong = "Meter über Meer"
            },
            new StatisticalOfficeZurichCsvData
            {
                BfsNr = 3,
                RegionName = "Bonstetten",
                TopicName = "Raum und Umwelt",
                SetName = "Geographie, Flächen",
                SubsetName = "Höhe",
                IndicatorId = 43,
                IndicatorName = "Höhe [m.ü.M.]",
                IndicatorYear = 1995,
                IndicatorValue = 528,
                UnitShort = "m.ü.M.",
                UnitLong = "Meter über Meer"
            },
            new StatisticalOfficeZurichCsvData
            {
                BfsNr = 4,
                RegionName = "Hausen a.A.",
                TopicName = "Raum und Umwelt",
                SetName = "Geographie, Flächen",
                SubsetName = "Höhe",
                IndicatorId = 43,
                IndicatorName = "Höhe [m.ü.M.]",
                IndicatorYear = 1995,
                IndicatorValue = 617,
                UnitShort = "m.ü.M.",
                UnitLong = "Meter über Meer"
            }
        };
        private readonly string Comma = ",";
        private readonly string FilePath = "C:\\src\\biz.dfch.CS.Playground.Fynn\\src\\biz.dfch.CS.Playground.Fynn\\20210304\\KANTON_ZUERICH_43.csv";
        private readonly string WrongFilePath = "C:\\src\\biz.dfch.CS.Playground.Fynn\\src\\biz.dfch.CS.Playground.Fynn\\20210304\\ThisFileDoesNotExist.csv";
        private readonly string FilePathNotEndingWithCsv = "C:\\src\\biz.dfch.CS.Playground.Fynn\\src\\biz.dfch.CS.Playground.Fynn\\20210304\\CsvReader.cs";
        private readonly CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };

        [TestMethod]
        public void GetCsvDataFromStatisticalOfficeZurichCsvDataReturnsExpectedData()
        {
            // Arrange
            var sut = new CsvReader<StatisticalOfficeZurichCsvData>(csvConfiguration);

            // Act
            var result = sut.GetCsvData<StatisticalOfficeZurichCsvDataMap>(FilePath).ToList();

            // Assert
            for (int i = 0; i < expectedCsvData.Count; i++)
            {
                Assert.AreEqual(expectedCsvData[i], result[i]);
            }
        }
        
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetCsvDataWithNotExistingFileThrowsFileNotFoundException()
        {
            // Arrange
            var sut = new CsvReader<StatisticalOfficeZurichCsvData>(csvConfiguration);

            // Act
            var result = sut.GetCsvData<StatisticalOfficeZurichCsvDataMap>(WrongFilePath);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GetCsvDataWithFileEndingNotEqualToCsvThrowsInvalidDataException()
        {
            // Arrange
            var sut = new CsvReader<StatisticalOfficeZurichCsvData>(csvConfiguration);

            // Act
            var result = sut.GetCsvData<StatisticalOfficeZurichCsvDataMap>(FilePathNotEndingWithCsv);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(HeaderValidationException))]
        public void GetCsvDataFromStatisticalOfficeZurichCsvDataWithWrongCsvConfigurationThrowsHeaderValidationException()
        {
            // Arrange
            CsvConfiguration wrongCsvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = Comma
            };

            var sut = new CsvReader<StatisticalOfficeZurichCsvData>(wrongCsvConfiguration);
            // Act
            var result = sut.GetCsvData<StatisticalOfficeZurichCsvDataMap>(FilePath);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCsvDataFromStatisticalOfficeZurichCsvDataWithCsvConfigurationSetToNullThrowsArgumentNullException()
        {
            // Arrange
            var sut = new CsvReader<StatisticalOfficeZurichCsvData>(null);

            // Act
            var result = sut.GetCsvData<StatisticalOfficeZurichCsvDataMap>(FilePath);

            // Assert
        }
    }
}
