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
    public class MyDictionaryBenchmark
    {
        private MyDictionary<int, string> dictionary;

        public MyDictionaryBenchmark()
        {
            dictionary = new MyDictionary<int, string>(1);
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            dictionary.Clear();
        }

        [Benchmark]
        public void InsertEntry()
        {
            dictionary.Insert(1, "23");
        }
    }
}
