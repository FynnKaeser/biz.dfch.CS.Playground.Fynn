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

using BenchmarkDotNet.Attributes;
using biz.dfch.CS.Playground.Fynn._20210305;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210305
{
    public class MyListBenchmark
    {
        [Benchmark]
        public void InsertOneEntry()
        {
            var list = new MyList<string>(1);
            list.Insert(0, "Hello");
        }

        [Benchmark]
        public void InsertTenEntries()
        {
            // Arrange
            var entries = 10;
            var list = new MyList<string>(entries);

            // Act
            for (int i = 0; i < entries; i++)
            {
                list.Insert(i, "String");
            }
        }

        [Benchmark]
        public void InsertHundredEntries()
        {
            // Arrange
            var entries = 100;
            var list = new MyList<string>(entries);

            // Act
            for (int i = 0; i < entries; i++)
            {
                list.Insert(i, "String");
            }
        }

        [Benchmark]
        public void InsertThousandEntries()
        {
            // Arrange
            var entries = 1000;
            var list = new MyList<string>(entries);

            // Act
            for (int i = 0; i < entries; i++)
            {
                list.Insert(i, "String");
            }
        }

        [Benchmark]
        public void InsertMillionEntries()
        {
            // Arrange
            var entries = 1000000;
            var list = new MyList<string>(entries);

            // Act
            for (int i = 0; i < entries; i++)
            {
                list.Insert(i, "String");
            }
        }
    }
}
