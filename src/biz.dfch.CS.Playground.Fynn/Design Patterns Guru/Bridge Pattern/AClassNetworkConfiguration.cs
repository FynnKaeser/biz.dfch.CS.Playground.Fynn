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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Bridge_Pattern
{
    public class AClassNetworkConfiguration : NetworkConfiguration
    {
        private readonly IpAddress startIpAddress = new IpAddress(0, 0, 0, 0);
        private readonly IpAddress endIpAddress = new IpAddress(127, 255, 255, 255);

        public AClassNetworkConfiguration(IDevice device) : base(device) { }

        public void SetIpAddress()
        {
            var ipAddress = GetIpAddress(startIpAddress, endIpAddress);
            SetIpAddress(ipAddress);
        }
    }
}
