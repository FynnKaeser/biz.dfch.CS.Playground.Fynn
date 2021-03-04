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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace biz.dfch.CS.Playground.Fynn._20210304
{
    public class CsvDataMap : ClassMap<CsvData>
    {
        public CsvDataMap()
        {
            Map(m => m.BfsNr).Name(CsvFieldNameConstants.CsvFieldBsfNr);
            Map(m => m.RegionName).Name(CsvFieldNameConstants.CsvFieldRegionName);
            Map(m => m.TopicName).Name(CsvFieldNameConstants.CsvFieldTopicName);
            Map(m => m.SetName).Name(CsvFieldNameConstants.CsvFieldSetName);
            Map(m => m.SubsetName).Name(CsvFieldNameConstants.CsvFieldSubsetName);
            Map(m => m.IndicatorId).Name(CsvFieldNameConstants.CsvFieldIndicatorId);
            Map(m => m.IndicatorName).Name(CsvFieldNameConstants.CsvFieldIndicatorName);
            Map(m => m.IndicatorYear).Name(CsvFieldNameConstants.CsvFieldIndicatorYear);
            Map(m => m.IndicatorValue).Name(CsvFieldNameConstants.CsvFieldIndicatorValue);
            Map(m => m.UnitLong).Name(CsvFieldNameConstants.CsvFieldUnitLong);
            Map(m => m.UnitShort).Name(CsvFieldNameConstants.CsvFieldUnitShort);
        }
    }
}
