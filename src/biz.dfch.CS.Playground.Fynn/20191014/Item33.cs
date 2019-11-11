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

using System.Collections.Generic;

namespace biz.dfch.CS.Playground.Fynn._20191014
{
    public class Item33
    {
        public static IList<int> CreateSequence(int numberOfElements, int startAt, int stepBy)
        {
            var collection = new List<int>(numberOfElements);
            for (var i = 0; i < numberOfElements; i++)
            {
                collection.Add(startAt + i * stepBy);
                if (i == 9000)
                {
                    var test = "stops here";
                }
            }

            return collection;
        }

        //public static IEnumerable<int> CreateSequence(int numberOfElements, int startAt, int stepBy)
        //{
        //    for (var i = 0; i < numberOfElements; i++)
        //    {
        //        if (i == 9000)
        //        {
        //            var test = "stops here";
        //        }
        //        yield return startAt + i * stepBy;

        //    }
        //}
    }
}