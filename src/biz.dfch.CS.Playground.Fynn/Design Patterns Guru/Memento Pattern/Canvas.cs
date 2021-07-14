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
using biz.dfch.CS.Playground.Fynn.Visitor_and_Double_Dispatch;

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Memento_Pattern
{
    public class Canvas
    {
        private ConsoleColor backgroundColor;
        private Shape shape;

        public string Name { get; set; }

        public void SetShape(Shape shape)
        {
            this.shape = shape ?? throw new ArgumentNullException(nameof(shape));
        }
        public void SetBackgroundColor(ConsoleColor backgroundColor)
        {
            this.backgroundColor = backgroundColor;
        }

        public Snapshot CreateSnapshot()
        {
            return new Snapshot(this, backgroundColor, shape, Name);
        }
    }
}
