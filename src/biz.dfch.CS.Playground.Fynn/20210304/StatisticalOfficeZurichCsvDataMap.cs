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

using CsvHelper.Configuration;

namespace biz.dfch.CS.Playground.Fynn._20210304
{
    public class StatisticalOfficeZurichCsvDataMap : ClassMap<StatisticalOfficeZurichCsvData>
    {
        public StatisticalOfficeZurichCsvDataMap()
        {
            Map(m => m.BfsNr).Name(StatisticalOfficeZurichCsvFieldName.BfsNr);
            Map(m => m.RegionName).Name(StatisticalOfficeZurichCsvFieldName.CsvFieldRegionName);
            Map(m => m.TopicName).Name(StatisticalOfficeZurichCsvFieldName.CsvFieldTopicName);
            Map(m => m.SetName).Name(StatisticalOfficeZurichCsvFieldName.CsvFieldSetName);
            Map(m => m.SubsetName).Name(StatisticalOfficeZurichCsvFieldName.CsvFieldSubsetName);
            Map(m => m.IndicatorId).Name(StatisticalOfficeZurichCsvFieldName.CsvFieldIndicatorId);
            Map(m => m.IndicatorName).Name(StatisticalOfficeZurichCsvFieldName.CsvFieldIndicatorName);
            Map(m => m.IndicatorYear).Name(StatisticalOfficeZurichCsvFieldName.CsvFieldIndicatorYear);
            Map(m => m.IndicatorValue).Name(StatisticalOfficeZurichCsvFieldName.CsvFieldIndicatorValue);
            Map(m => m.UnitLong).Name(StatisticalOfficeZurichCsvFieldName.CsvFieldUnitLong);
            Map(m => m.UnitShort).Name(StatisticalOfficeZurichCsvFieldName.CsvFieldUnitShort);
        }
    }
}
