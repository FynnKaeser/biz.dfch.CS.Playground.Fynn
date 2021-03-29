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

namespace biz.dfch.CS.Playground.Fynn.Tests._20210319
{
    public class TestClassGetHasCode
    {
        public string MyString { get; set; }
        public int MyInt { get; set; }
        public bool MyBool { get; set; }

        public TestClassGetHasCode(string myString, int myInt, bool myBool)
        {
            MyString = myString;
            MyInt = myInt;
            MyBool = myBool;
        }

        public override int GetHashCode()
        {
            var hashString = MyString == null ? 0 : MyString.GetHashCode();
            var hashInt = MyInt.GetHashCode();
            var hashBool = MyBool.GetHashCode();

            return hashString ^ hashInt ^ hashBool;
        }
    }
}
