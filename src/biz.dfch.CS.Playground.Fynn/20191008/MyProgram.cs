
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
using System.Diagnostics;

namespace biz.dfch.CS.Playground.Fynn._20191008
{

    public class MyBase
    {
    }

    public interface IMessageWriter
    {
        void WriteMessage();
    }

    public class MySub : MyBase, IMessageWriter
    {
        void IMessageWriter.WriteMessage() =>
            Debug.WriteLine("Inside MySub.WriteMessage");
    }

    public class AnotherType : IMessageWriter
    {
        public void WriteMessage() =>
            Debug.WriteLine("Inside AnotherType.WriteMessage");
    }

    public class MyProgram
    {
        static void WriteMessage(MyBase b)
        {
            Debug.WriteLine("Inside WriteMessage(MyBase)");
        }

        static void WriteMessage<T>(T obj)
        {
            Debug.Write("Inside WriteMessage<T>(T):  ");
            Debug.WriteLine(obj.ToString());
        }

        static void WriteMessage(IMessageWriter obj)
        {
            Debug.Write("Inside WriteMessage(IMessageWriter):  ");
            obj.WriteMessage();
        }

        public void Main()
        {
            MySub d = new MySub();
            Debug.WriteLine("Calling Program.WriteMessage");
            WriteMessage(d);

            Debug.WriteLine("Calling through IMessageWriter interface");
            WriteMessage((IMessageWriter)d);

            Debug.WriteLine("Cast to base object");
            WriteMessage((MyBase)d);

            Debug.WriteLine("Another Type test:");
            AnotherType anObject = new AnotherType();
            WriteMessage(anObject);

            Debug.WriteLine("Cast to IMessageWriter:");
            WriteMessage((IMessageWriter)anObject);
        }
    }
}
