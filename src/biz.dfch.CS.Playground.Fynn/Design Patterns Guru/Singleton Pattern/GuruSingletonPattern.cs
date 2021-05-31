﻿/**
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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Singleton_Pattern
{
    public class GuruSingletonPattern
    {
        private static readonly object tempObject = new object();
        private static GuruSingletonPattern _guruSingletonPattern;
        private static GuruSingletonPattern guruSingletonPattern;

        public static GuruSingletonPattern GuruSingletonPatternObject
        {
            get
            {
                if (null == guruSingletonPattern)
                {
                    lock (tempObject)
                    {
                        if (null == guruSingletonPattern)
                        {
                            GetterCreationCounter++;
                            guruSingletonPattern = new GuruSingletonPattern();
                        }
                    }
                }

                return guruSingletonPattern;
            }
        }
        public static int MethodCreationCounter { get; private set; }
        public static int GetterCreationCounter { get; private set; }

        private GuruSingletonPattern() { }

        public static GuruSingletonPattern GetInstance()
        {
            if (null == _guruSingletonPattern)
            {
                lock (tempObject)
                {
                    if (null == _guruSingletonPattern)
                    {
                        MethodCreationCounter++;
                        _guruSingletonPattern = new GuruSingletonPattern();
                    }
                }
            }

            return _guruSingletonPattern;
        }
    }
}