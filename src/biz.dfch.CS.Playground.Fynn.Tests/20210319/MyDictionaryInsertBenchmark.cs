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
using biz.dfch.CS.Playground.Fynn._20210319;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210319
{
    [IterationTime(100)]
    public class MyDictionaryInsertBenchmark
    {
        [Benchmark]
        public void InsertOneEntry()
        {
            var dictionary = new MyDictionary<int, string>(1);
            dictionary.Insert(1, "23");
        }

        [Benchmark]
        public void InsertTenEntries()
        {
            // Arrange
            var entries = 10;
            var dictionary = new MyDictionary<int, string>(entries);

            // Act
            for (int i = 0; i < entries; i++)
            {
                dictionary.Insert(i, "String");
            }
        }

        [Benchmark]
        public void InsertHundredEntries()
        {
            // Arrange
            var entries = 100;
            var dictionary = new MyDictionary<int, string>(entries);

            // Act
            for (int i = 0; i < entries; i++)
            {
                dictionary.Insert(i, "String");
            }
        }

        [Benchmark]
        public void InsertThousandEntries()
        {
            // Arrange
            var entries = 1000;
            var dictionary = new MyDictionary<int, string>(entries);

            // Act
            for (int i = 0; i < entries; i++)
            {
                dictionary.Insert(i, "String");
            }
        }

        [Benchmark]
        public void InsertMillionEntries()
        {
            // Arrange
            var entries = 1000000;
            var dictionary = new MyDictionary<int, string>(entries);

            // Act
            for (int i = 0; i < entries; i++)
            {
                dictionary.Insert(i, "String");
            }
        }
    }
}
