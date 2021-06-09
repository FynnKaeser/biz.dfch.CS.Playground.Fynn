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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Decorator_Pattern
{
    public class EncryptionDecorator : DataSourceDecorator
    {
        private readonly string encryptedSymbol = "$$$";
        public EncryptionDecorator(IDataSource decorator) : base(decorator) { }

        public override void Write(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            var encryptedData = data + encryptedSymbol;
            base.Write(encryptedData);
        }

        public override string Read()
        {
            var data = base.Read();
            if (data.Contains(encryptedSymbol))
            {
                var decryptedData = data.Remove(data.Length - 3);

                return decryptedData;
            }
            return data;
        }
    }
}
