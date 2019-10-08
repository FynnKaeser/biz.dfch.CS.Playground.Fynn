
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
using static System.Console;

namespace biz.dfch.CS.Playground.Fynn._20191008
{

    public class MyBase
    {
    }

    public interface IMessageWriter
    {
        void WriteMessage();
    }

    public class MyDerived : MyBase, IMessageWriter
    {
        void IMessageWriter.WriteMessage() =>
            WriteLine("Inside MyDerived.WriteMessage");
    }

    public class AnotherType : IMessageWriter
    {
        public void WriteMessage() =>
            WriteLine("Inside AnotherType.WriteMessage");
    }

    public class MyProgram
    {
        static void WriteMessage(MyBase b)
        {
            WriteLine("Inside WriteMessage(MyBase)");
        }

        static void WriteMessage<T>(T obj)
        {
            Write("Inside WriteMessage<T>(T):  ");
            WriteLine(obj.ToString());
        }

        static void WriteMessage(IMessageWriter obj)
        {
            Write("Inside WriteMessage(IMessageWriter):  ");
            obj.WriteMessage();
        }

        public void Main()
        {
            MyDerived d = new MyDerived();
            WriteLine("Calling Program.WriteMessage");
            WriteMessage(d);
            WriteLine();

            WriteLine("Calling through IMessageWriter interface");
            WriteMessage((IMessageWriter)d);
            WriteLine();

            WriteLine("Cast to base object");
            WriteMessage((MyBase)d);
            WriteLine();

            WriteLine("Another Type test:");
            AnotherType anObject = new AnotherType();
            WriteMessage(anObject);
            WriteLine();

            WriteLine("Cast to IMessageWriter:");
            WriteMessage((IMessageWriter)anObject);
        }
    }
}
