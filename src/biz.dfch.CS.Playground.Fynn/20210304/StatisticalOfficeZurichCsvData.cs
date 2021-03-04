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
        public double IndicatorValue { get; set; }
        public string UnitShort { get; set; }
        public string UnitLong { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((StatisticalOfficeZurichCsvData)obj);
        }

        public override int GetHashCode()
        {
            var bfsNr = BfsNr.GetHashCode();
            var regionName = RegionName == null ? 0 : RegionName.GetHashCode();
            var topicName = TopicName == null ? 0 : TopicName.GetHashCode();
            var setName = SetName == null ? 0 : SetName.GetHashCode();
            var subsetName = SubsetName == null ? 0 : SubsetName.GetHashCode();
            var indicatorId = IndicatorId.GetHashCode();
            var indicatorName = IndicatorName == null ? 0 : IndicatorName.GetHashCode();
            var indicatorYear = IndicatorYear.GetHashCode();
            var indicatorValue = IndicatorId.GetHashCode();
            var unitShort = UnitShort == null ? 0 : UnitShort.GetHashCode();
            var unitLong = UnitLong == null ? 0 : UnitLong.GetHashCode();

            return bfsNr ^ regionName ^ topicName ^ setName ^ subsetName ^ indicatorId ^ indicatorName ^ indicatorYear ^ indicatorValue ^ unitShort ^ unitLong;
        }

        private bool Equals(StatisticalOfficeZurichCsvData other)
        {
            return BfsNr.Equals(other.BfsNr) && RegionName.Equals(other.RegionName) && TopicName.Equals(other.TopicName) &&
                   SetName.Equals(other.SetName) && SubsetName.Equals(other.SubsetName) && IndicatorId.Equals(other.IndicatorId) &&
                   IndicatorName.Equals(other.IndicatorName) && IndicatorYear.Equals(other.IndicatorYear) && IndicatorValue.Equals(other.IndicatorValue) &&
                   UnitShort.Equals(other.UnitShort) && UnitLong.Equals(other.UnitLong);
        }
    }
}
