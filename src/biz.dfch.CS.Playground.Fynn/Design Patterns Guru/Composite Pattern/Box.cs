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
using System.Linq;

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Composite_Pattern
{
    public class Box : IOrder
    {
        private readonly IList<Product> products;
        private readonly IList<Box> innerBoxes;
        private readonly int minProductCount = 1;

        public Box(IList<Product> products, IList<Box> innerBoxes)
        {
            this.products = products ?? throw new ArgumentNullException(nameof(products)); 
            if (products.Count < minProductCount)
            {
                throw new ArgumentException(ErrorMessage.BoxNeedsToContainAtLeastOneProduct, nameof(products));
            }
            this.innerBoxes = innerBoxes ?? new List<Box>();
        }

        public int GetPrice()
        {
            return products.Sum(product => product.GetPrice()) + innerBoxes.Sum(innerBox => innerBox.GetPrice());
        }
    }
}
