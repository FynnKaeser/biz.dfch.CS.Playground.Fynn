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

using static System.Console;
using static System.String;
using static biz.dfch.CS.Playground.Fynn._20191009.MyType;

namespace biz.dfch.CS.Playground.Fynn._20191009
{
    public class StaticUsing
    {
        // With `using static System.Console`
        // Can also be done with `string`, `double`, `int` etc.
        // Makes it more readable --> Sometimes it makes it less readable (TryParse() --> you don't know which type)
        public void PrintInConsole(int min, int max)
        {
            // --- using static System.Console ---
            //Console.WriteLine("--- Start of Console output ---");
            //Console.WriteLine("Minimal value is '{0}'", min);
            //Console.WriteLine("----------------------------");
            //Console.WriteLine("Maximal value is '{0}'", max);
            //Console.WriteLine("--- End of Console output ---");
            WriteLine("--- Start of Console output ---");
            WriteLine("Minimal value is '{0}'", min);
            WriteLine("----------------------------");
            WriteLine("Maximal value is '{0}'", max);
            WriteLine("--- End of Console output ---");

            // --- using static System.String ---
            //WriteLine(string.Format($"Total '{max + min}'"));
            WriteLine(Format($"Total '{max + min}'"));


            // --- using static biz.dfch.CS.Playground.Fynn._20191009.MyType ---
            //var stringPublicStaticString = MyType.PublicStaticString;
            //MyType.PublicMethod();
            var stringPublicStaticString = PublicStaticString;
            PublicMethod();
        }
    }

    public class MyType
    {
        public static string PublicStaticString { get; set; }
        
        public static void PublicMethod()
        {
            // Do Stuff
        }
    }
}
