/**
 * Copyright 2019 d-fens GmbH
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
using System.Collections;
using System.Collections.Generic;

namespace biz.dfch.CS.Playground.Fynn._20191010
{
    public class Iterator
    {
        public static IEnumerable<char> GenerateAlphabet()
        {
            var letter = 'a';
            while (letter <= 'z')
            {
                yield return letter;
                letter++;
            }
        }
    }

    public class EmbeddedIterator : IEnumerable<char>
    {
        public IEnumerator<char> GetEnumerator()
        {
            return new LetterEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LetterEnumerator();
        }

        public static IEnumerable<char> GenerateAlphabet()
        {
            return new EmbeddedIterator();
        }

        private class LetterEnumerator : IEnumerator<char>
        {
            public bool MoveNext()
            {
                Current++;
                return Current <= 'z';
            }

            public char Current { get; private set; } = (char) ('a' - 1);

            object IEnumerator.Current => Current;

            public void Reset()
            {
                Current = (char) ('a' - 1);
            }


            void IDisposable.Dispose()
            {
            }
        }
    }
}