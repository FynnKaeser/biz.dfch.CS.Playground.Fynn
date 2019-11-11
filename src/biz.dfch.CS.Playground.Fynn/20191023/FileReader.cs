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
using System.IO;

namespace biz.dfch.CS.Playground.Fynn._20191023
{
    public class FileReader
    {
        private const string FILE_PATH =
            @"C:\\src\\biz.dfch.CS.Playground.Fynn\\src\\biz.dfch.CS.Playground.Fynn\\20191023\\Assets\\";

        public static bool OpenFile(string fileName)
        {
            var filePath = FILE_PATH + fileName;

            if (!File.Exists(filePath)) return false;

            var myStream = new StreamReader(filePath);
            Console.WriteLine(myStream.ReadToEnd());
            myStream.Close();

            return true;
        }


        public static bool OpenFileTryCatch(string fileName)
        {
            var filePath = FILE_PATH + fileName;
            StreamReader myStream = null;

            try
            {
                myStream = new StreamReader(filePath);
                Console.WriteLine(myStream.ReadToEnd());
                myStream.Close();

                return true;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                myStream?.Close();
            }
        }
    }
}