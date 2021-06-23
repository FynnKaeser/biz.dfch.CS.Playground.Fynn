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
using System.Collections.Generic;

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Observer_Pattern
{
    public class FootballNewsManager : INewsManager
    {
        public HashSet<INewsApp> Subscribers { get; }

        public FootballNewsManager()
        {
            Subscribers = new HashSet<INewsApp>();
        }

        public void Subscribe(INewsApp newsApp)
        {
            if (null == newsApp)
            {
                throw new ArgumentNullException(nameof(newsApp));
            }

            Subscribers.Add(newsApp);
        }

        public void Unsubscribe(INewsApp newsApp)
        {
            if (null == newsApp)
            {
                throw new ArgumentNullException(nameof(newsApp));
            }

            Subscribers.Remove(newsApp);
        }

        public void Notify(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException(nameof(message));
            }

            foreach (var listener in Subscribers)
            {
                listener.Update(message);
            }
        }
    }
}
