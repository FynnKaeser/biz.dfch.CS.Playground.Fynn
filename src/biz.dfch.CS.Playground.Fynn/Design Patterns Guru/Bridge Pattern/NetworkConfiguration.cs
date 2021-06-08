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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Bridge_Pattern
{
    public class NetworkConfiguration
    {
        private readonly IDevice device;
        private readonly Random random;

        public NetworkConfiguration(IDevice device)
        {
            this.device = device ?? throw new ArgumentNullException(nameof(device));
            random = new Random();
        }

        public void SetIpAddress(IpAddress ipAddress)
        {
            if (null == ipAddress)
            {
                throw new ArgumentNullException();
            }

            device.SetIpAddress(ipAddress);
        }

        protected IpAddress GetIpAddress(IpAddress startIpAddress, IpAddress endIpAddress)
        {
            if (null == startIpAddress)
            {
                throw new ArgumentNullException(nameof(startIpAddress));
            }
            
            if (null == endIpAddress)
            {
                throw new ArgumentNullException(nameof(endIpAddress));
            }

            var valueSection1 = random.Next(startIpAddress.Section1, endIpAddress.Section1);
            var valueSection2 = random.Next(startIpAddress.Section2, endIpAddress.Section2);
            var valueSection3 = random.Next(startIpAddress.Section3, endIpAddress.Section3);
            var valueSection4 = random.Next(startIpAddress.Section4, endIpAddress.Section4);

            return new IpAddress(valueSection1, valueSection2, valueSection3, valueSection4);
        }
    }
}
