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

namespace biz.dfch.CS.Playground.Fynn._20210114.Example
{
    public partial class MyClass
    {

        private const int MyConstField = 42;
        private int myField = 45;
        private static int MyStaticPrivateProperty { get; set; }
        private int MyPrivateProperty { get; set; }

        public static int MyStaticPublicProperty { get; set; }
        public int MyPublicClassProperty { get; set; }

        public MyClass() { }
        
        public void DoStuff()
        {
            Console.WriteLine("Hello World!");
        }
    }
    
    public interface IMyInterface
    {
        int MyProperty { get; set; }
    
        void DoSomething();
    }
    
    public interface IMySecondInterface<TSecond>
    {
        TSecond Second { get; set; }
        bool IsValid<TInput>();
    }

    public abstract class MyAbstractClass
    {
        public abstract int MyPublicProperty { get; set; }

        public abstract void Create();
    }



    public partial class MyClass : MyAbstractClass
    {
        public override int MyPublicProperty { get; set; }
    
        public override void Create()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public partial class MyClass : IMyInterface
    {
        public int MyProperty { get; set; }
        public void DoSomething()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public partial class MyClass : IMySecondInterface<string>
    {
        public string Second { get; set; }
        public bool IsValid<TInput>()
        {
            throw new System.NotImplementedException();
        }
    }
}
