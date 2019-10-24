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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Playground.Fynn._20191023
{
    public static class CustomerManager
    {
        public static bool RemoveMoney(this Customer customer, int amount)
        {
            if (customer == null) return false;

            if (!TestConditions(customer, amount)) return false;
            Remove(customer, amount);
            return true;
        }

        private static bool TestConditions(Customer customer, int amount)
        {
            // Test conditions if work can be done
            if (customer.Money < amount)
            {
                Console.WriteLine("You can't remove more money than you have!");
                return false;
            }

            if (amount < 0)
            {
                Console.WriteLine("Negative integers are not allowed as amount to subtract");
                return false;
            }

            return true;

        }

        private static void Remove(Customer customer, int amount)
        {
            // Do work here
            customer.Money -= amount;
        }
    }
}
