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
using System.Diagnostics;
using System.Threading;

namespace biz.dfch.CS.Playground.Fynn._20210401
{
    public class MultiThreading
    {
        private readonly Random random;
        private int number1;
        private int number2;
        private object myObject;

        public MultiThreading()
        {
            random = new Random();
        }

        public void UnsafeDivide()
        {
            for (int i = 0; i < 1000000; i++)
            {
                number1 = random.Next(1, 2);
                number2 = random.Next(1, 2);

                var result= number1 / number2;
                
                number1 = 0;
                number2 = 0;
            }
        }
        
        public void SafeDivide()
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock (this)
                {
                    number1 = random.Next(1, 2);
                    number2 = random.Next(1, 2);

                    var result = number1 / number2;

                    number1 = 0;
                    number2 = 0;
                }
            }
        }

        public void Function1()
        {
            for (int i = 0; i < 10; i++)
            {
                Trace.WriteLine($"{nameof(Function1)}: {i}");
                Thread.Sleep(1);
            }
        }
        
        public void Function2()
        {
            for (int i = 0; i < 10; i++)
            {
                Trace.WriteLine($"{nameof(Function2)}: {i}");
                Thread.Sleep(1);
            }
        }

        public object GetObject()
        {
            if (null == myObject)
            {
                lock (this)
                {
                    if (null == myObject)
                    {
                        myObject = new object();
                    }
                }
            }
            return myObject;
        }
    }
}
