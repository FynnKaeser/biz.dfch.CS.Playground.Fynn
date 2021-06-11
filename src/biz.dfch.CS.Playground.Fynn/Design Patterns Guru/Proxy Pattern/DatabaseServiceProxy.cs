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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Proxy_Pattern
{
    public class DatabaseServiceProxy : IDatabaseService
    {
        private readonly int idThreshold = 0;
        private readonly DatabaseService databaseService;
        private readonly List<DatabaseEntry> cachedDatabaseEntries;

        public DatabaseServiceProxy()
        {
            databaseService = new DatabaseService();
            cachedDatabaseEntries = new List<DatabaseEntry>();
        }

        public DatabaseEntry Read(int id)
        {
            if (id < idThreshold)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var cachedEntry = cachedDatabaseEntries.FirstOrDefault(e => e.Id == id);
            if (null != cachedEntry)
            {
                return cachedEntry;
            }

            var entry = databaseService.Read(id);
            if (null != entry)
            {
                cachedDatabaseEntries.Add(entry);
            }

            return entry;
        }

        public bool Write(int id, string value)
        {
            if (id < idThreshold)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            return databaseService.Write(id, value);
        }
    }
}
