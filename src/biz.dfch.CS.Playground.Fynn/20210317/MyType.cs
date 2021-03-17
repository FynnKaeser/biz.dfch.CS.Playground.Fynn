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

namespace biz.dfch.CS.Playground.Fynn._20210317
{
    public class MyType : IComparable<MyType>, IEquatable<MyType>
    {
        public string MyString { get; set; }
        public int MyInt { get; set; }
        public bool MyBool { get; set; }
        public long MyLong { get; set; }
        
        public MyType(string myString, int myInt, bool myBool, long myLong)
        {
            if (string.IsNullOrWhiteSpace(myString)) throw new ArgumentNullException();

            MyString = myString;
            MyInt = myInt;
            MyBool = myBool;
            MyLong = myLong;
        }

        public int CompareTo(MyType other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(MyType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;

            return MyString.Equals(other.MyString) && MyInt.Equals(other.MyInt) && MyBool.Equals(other.MyBool) &&
                   MyLong.Equals(other.MyLong);
        }

        public override bool Equals(object obj)
        {
            return Equals((MyType)obj);
        }

        public override int GetHashCode()
        {
            var hashString = MyString == null ? 0 : MyString.GetHashCode();
            var hashInt = MyInt.GetHashCode();
            var hashBool = MyBool.GetHashCode();
            var hashLong = MyLong.GetHashCode();

            return hashString ^ hashInt ^ hashLong ^ hashBool;
        }

        public static bool operator ==(MyType myType1, MyType myType2)
        {
            if ((object)myType1 == null || (object)myType2 == null)
                return Equals(myType1, myType2);

            return myType1.Equals(myType2);
        }

        public static bool operator !=(MyType myType1, MyType myType2)
        {
            return !(myType1 == myType2);
        }
    }
}
