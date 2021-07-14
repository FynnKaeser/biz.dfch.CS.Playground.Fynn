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
    public class Snapshot
    {
        private readonly ConsoleColor backgroundColor;
        private readonly Shape shape;
        private readonly string name;
        private readonly Canvas canvas;
        
        public Snapshot(Canvas canvas, ConsoleColor backgroundColor, Shape shape, string name)
        {
            this.shape = shape ?? throw new ArgumentNullException(nameof(shape));
            this.backgroundColor = backgroundColor;
            this.name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            this.canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));
        }

        public void Restore()
        {
            canvas.Name = name;
            canvas.SetBackgroundColor(backgroundColor);
            canvas.SetShape(shape);
        }
    }
}
