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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Builder_Pattern
{
    public class Director
    {
        public bool ConstructBarChair(FurnitureBuilder furnitureBuilder)
        {
            if (default == furnitureBuilder)
            {
                return false;
            }

            var isMaterialSet = furnitureBuilder.SetMaterial("Wood");
            if (!isMaterialSet)
            {
                return false;
            }
            var areDimensionsSet = furnitureBuilder.SetDimensions("120 cm", "40 cm", "40 cm");
            if (!areDimensionsSet)
            {
                return false;
            }
            var isColorSet = furnitureBuilder.SetColor("Brown");
            if (!isColorSet)
            {
                return false;
            }

            return true;
        }
    }
}
