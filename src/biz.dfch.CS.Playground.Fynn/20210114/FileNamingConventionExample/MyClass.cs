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

namespace biz.dfch.CS.Playground.Fynn._20210114
{
    public partial class MyClass
    {
        private static readonly int MyPrivateStaticReadonlyField;
        private static int MyPrivateStaticField;
        private readonly int MyPrivateReadonlyField;
        private int MyPrivateField;
        
        protected static readonly int MyProtectedStaticReadonlyField;
        protected static int MyProtectedStaticField;
        protected readonly int MyProtectedReadonlyield;
        protected int MyProtectedField;
        
        protected internal static readonly int MyProtectedInternalStaticReadonlyField;
        protected internal static int MyProtectedInternalStaticField;
        protected internal readonly int MyProtectedInternalReadonlyField;
        protected internal int MyProtectedInternalField;
        
        internal static readonly int MyInternalStaticReadonlyField;
        internal static int MyInternalStaticField;
        internal readonly int MyInternalReadonlyField;
        internal int MyInternalField;
        
        public static readonly int MyPublicStaticReadonlyField;
        public static int MyPublicStaticField;
        public readonly int MyPublicReadonlyField;
        public int MyPublicield;
    }    
    
    public class MyExampleClass
    {
        public static void MyPublicStaticMethod(){}
        public void MyPublicMethod(){}

        internal static void MyInternalStaticMethod(){}
        internal void MyInternalMethod(){}

        protected internal static void MyProtectedInternalStaticMethod(){}
        protected internal void MyProtectedInternalMethod(){}

        protected static void MyProtectedStaticMethod(){}
        protected void MyProtectedMethod(){}

        private static void MyPrivateStaticMethod(){}
        private void MyPrivateMethod(){}
    }
}
