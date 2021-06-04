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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Abstract_Factory_Pattern
{
    public class ProductBase : IProduct
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }

        public ProductBase(string name, string ipAddress)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Default Name" : name;
            IpAddress = string.IsNullOrWhiteSpace(ipAddress) ? "1.1.1.1" : ipAddress;
        }

        private bool Equals(ProductBase other)
        {
            if (null == other) return false;

            return Name == null ? Name == other.Name : Name.Equals(other.Name) && IpAddress == null ? IpAddress == other.IpAddress : IpAddress.Equals(other.IpAddress);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((ProductBase)obj);
        }

        public override int GetHashCode()
        {
            var hashName = Name == null ? 0 : Name.GetHashCode();
            var hashIpAddress = IpAddress == null ? 0 : IpAddress.GetHashCode();

            return hashName ^ hashIpAddress;
        }
    }
}
