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

using System;
using System.Collections.Generic;

namespace biz.dfch.CS.Playground.Fynn.Visitor_and_Double_Dispatch
{
    public class GenericWorker<T>
        where T : Shape
    {
        private readonly Dictionary<Type, Type> typeWorkerMap = new Dictionary<Type, Type>()
        {
            {typeof(Circle), typeof(CircleWorker)},
            {typeof(Rectangle), typeof(RectangleWorker)},
            {typeof(Triangle), typeof(TriangleWorker)}
        };

        public void Work(T shape)
        {
            if (null == shape)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            var closedGenericType = typeWorkerMap[typeof(T)];
            if (null == closedGenericType)
            {
                throw new ArgumentException();
            }

            var instanceClosedGenericType = (IShapeWorker<T>) Activator.CreateInstance(closedGenericType);
            if (null == instanceClosedGenericType)
            {
                throw new ArgumentException();
            }
            instanceClosedGenericType.Invoke(shape);
        }
    }
}
