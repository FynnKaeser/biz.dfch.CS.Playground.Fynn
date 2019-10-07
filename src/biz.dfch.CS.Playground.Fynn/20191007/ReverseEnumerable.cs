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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Playground.Fynn._20191007
{
    public sealed class ReverseEnumerable<T> : IEnumerable<T>
    {
        private class ReverseEnumerator : IEnumerator<T>
        {
            int currentIndex;
            IList<T> collection;

            public ReverseEnumerator(IList<T> srcCollection)
            {
                collection = srcCollection;
                currentIndex = collection.Count;
            }

            //  IEnumerator<T> Members
            public T Current => collection[currentIndex];

            // IDisposable Members
            public void Dispose()
            {
                // no implementation but necessary
                // because IEnumerator<T> implements IDisposable
                // No protected Dispose() needed
                // because this class is sealed.
            }

            //   IEnumerator Members
            object System.Collections.IEnumerator.Current
                => this.Current;

            public bool MoveNext() => --currentIndex >= 0;

            public void Reset() => currentIndex = collection.Count;
        }

        IEnumerable<T> sourceSequenceEnumerable;
        IList<T> originalSequenceList;

        public ReverseEnumerable(IEnumerable<T> sequence)
        {
            sourceSequenceEnumerable = sequence;
            // If sequence doesn't implement IList<T>,
            // originalSequence is null, so this works
            // fine
            originalSequenceList = sequence as IList<T>;
        }

        public ReverseEnumerable(IList<T> sequence)
        {
            sourceSequenceEnumerable = sequence;
            originalSequenceList = sequence;
        }

        // IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            // Create a copy of the original sequence,
            // so it can be reversed.
            if (originalSequenceList == null)
            {
                originalSequenceList = new List<T>();
                foreach (T item in sourceSequenceEnumerable)
                    originalSequenceList.Add(item);
            }
            return new ReverseEnumerator(originalSequenceList);
        }

        // IEnumerable Members
        System.Collections.IEnumerator
            System.Collections.IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}
