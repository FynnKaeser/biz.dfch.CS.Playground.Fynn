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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Playground.Fynn._20191023
{
    public static class ExceptionFilter
    {
        public static string GetDataString()
        {
            var retryCount = 0;
            var dataString = default(string);

            while (null == dataString)
            {
                try
                {
                    dataString = MakeWebRequest();
                }
                catch (TimeoutException e) when(retryCount++ < 5)
                {
                    Console.WriteLine("Operation timed out. Trying again");
                }
            }

            return dataString;
        }

        public static string GetDataStringWrong()
        {
            var retryCount = 0;
            var dataString = default(String);

            while (dataString == null)
            {
                try
                {
                    dataString = MakeWebRequest();
                }
                catch (TimeoutException e)
                {
                    if (retryCount++ < 3)
                    {
                        Console.WriteLine("Timed out. Trying again");
                        // pause before trying again.
                        Task.Delay(1000 * retryCount);
                    }
                    else
                        throw;
                }
            }

            return dataString;
        }

        private static string MakeWebRequest()
        {
            throw new TimeoutException();
        }
    }
}
