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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Chain_of_Responsibility_Pattern
{
    public abstract class HandlerBase : IHandler
    {
        private IHandler nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            nextHandler = handler ?? throw new ArgumentNullException(nameof(handler));

            return nextHandler;
        }

        public virtual bool HandleRequest(Data data)
        {
            if (null == data)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (null == nextHandler)
            {
                return false;
            }

            return nextHandler.HandleRequest(data);
        }
    }
}
