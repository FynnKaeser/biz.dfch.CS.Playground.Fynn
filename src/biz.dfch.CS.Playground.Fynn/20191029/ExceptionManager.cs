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

namespace biz.dfch.CS.Playground.Fynn._20191029
{
    public static class ExceptionManager
    {
        public static bool LogExceptionToConsole(Exception e)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {e}");
            Console.ForegroundColor = oldColor;

            return false;
        }

        public static void DoStuff()
        {
            var failures = 0;

            try
            {
                var data = MakeWebRequest();
            }
            catch (Exception e) when (LogExceptionToConsole(e))
            {
            }
            catch (TimeoutException e) when (failures++ < 10)
            {
                Console.WriteLine("Timeout error: trying again");
            }
        }


        private static string MakeWebRequest()
        {
            throw new TimeoutException();
        }
    }
}