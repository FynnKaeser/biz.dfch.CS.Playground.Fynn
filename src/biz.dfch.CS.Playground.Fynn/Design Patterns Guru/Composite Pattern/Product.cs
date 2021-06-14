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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Composite_Pattern
{
    public class Product : IOrder
    {
        private readonly int priceOfOneProduct;
        private readonly int amount;
        private readonly int priceThreshold = 0;
        private readonly int amountThreshold = 1;

        public Product(int priceOfOneProduct, int amount)
        {
            if (priceOfOneProduct < priceThreshold)
            {
                throw new ArgumentOutOfRangeException(nameof(priceOfOneProduct));
            }

            if (amount < amountThreshold)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            this.priceOfOneProduct = priceOfOneProduct;
            this.amount = amount;
        }

        public int GetPrice()
        {
            return priceOfOneProduct * amount;
        }
    }
}