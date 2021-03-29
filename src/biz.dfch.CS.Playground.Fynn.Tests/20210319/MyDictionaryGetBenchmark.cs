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
using BenchmarkDotNet.Attributes;
using biz.dfch.CS.Playground.Fynn._20210319;

namespace biz.dfch.CS.Playground.Fynn.Tests._20210319
{
    public class MyDictionaryGetBenchmark
    {
        private MyDictionary<int, string> oneEntryDictionary = new MyDictionary<int, string>(1);
        private MyDictionary<int, string> tenEntriesDictionary = new MyDictionary<int, string>(10);
        private MyDictionary<int, string> hundredEntriesDictionary = new MyDictionary<int, string>(100);
        private MyDictionary<int, string> thousandEntriesDictionary = new MyDictionary<int, string>(1000);
        private MyDictionary<int, string> millionEntriesDictionary = new MyDictionary<int, string>(1000000);

        public MyDictionaryGetBenchmark()
        {
            for (int i = 0; i < 1000000; i++)
            {
                if (i < 1)
                {
                    oneEntryDictionary.Insert(i, "String");
                }

                if (i < 10)
                {
                    tenEntriesDictionary.Insert(i, "String");
                }
                
                if (i < 100)
                {
                    hundredEntriesDictionary.Insert(i, "String");
                }
                
                if (i < 1000)
                {
                    thousandEntriesDictionary.Insert(i, "String");
                }

                millionEntriesDictionary.Insert(i, "String");
            }
        }

        [Benchmark]
        public void GetEntryFromOneEntryDictionary()
        {
            // Arrange
            // Act
            var myEntry = oneEntryDictionary[0];
        }
        
        [Benchmark]
        public void GetEntryFromTenEntriesDictionary()
        {
            // Arrange
            var random = new Random();
            var key = random.Next(0, 9);

            // Act
            var myEntry = tenEntriesDictionary[key];
        }

        [Benchmark]
        public void GetEntryFromHundredEntriesDictionary()
        {
            // Arrange
            var random = new Random();
            var key = random.Next(0, 99);

            // Act
            var myEntry = hundredEntriesDictionary[key];
        }

        [Benchmark]
        public void GetEntryFromThousandEntriesDictionary()
        {
            // Arrange
            var random = new Random();
            var key = random.Next(0, 999);

            // Act
            var myEntry = hundredEntriesDictionary[key];
        }

        [Benchmark]
        public void GetEntryFromMillionEntriesDictionary()
        {
            // Arrange
            var random = new Random();
            var key = random.Next(0, 999999);

            // Act
            var myEntry = millionEntriesDictionary[key];
        }
    }
}
