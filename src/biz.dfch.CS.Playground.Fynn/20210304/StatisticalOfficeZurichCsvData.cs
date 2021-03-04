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

namespace biz.dfch.CS.Playground.Fynn._20210304
{
    public class StatisticalOfficeZurichCsvData
    {
        public int BfsNr { get; set; }
        public string RegionName { get; set; }
        public string TopicName { get; set; }
        public string SetName { get; set; }
        public string SubsetName { get; set; }
        public int IndicatorId { get; set; }
        public string IndicatorName { get; set; }
        public int IndicatorYear { get; set; }
        public int IndicatorValue { get; set; }
        public string UnitShort { get; set; }
        public string UnitLong { get; set; }
    }
}
