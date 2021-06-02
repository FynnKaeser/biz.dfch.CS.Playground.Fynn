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
                furnitureBuilder.ResetFurniture();
                return false;
            }
            var areDimensionsSet = furnitureBuilder.SetDimensions("120 cm", "40 cm", "40 cm");
            if (!areDimensionsSet)
            {
                furnitureBuilder.ResetFurniture();
                return false;
            }
            var isColorSet = furnitureBuilder.SetColor("Brown");
            if (!isColorSet)
            {
                furnitureBuilder.ResetFurniture();
                return false;
            }
            var isLegSet = furnitureBuilder.SetLegs(1);
            if (!isLegSet)
            {
                furnitureBuilder.ResetFurniture();
                return false;
            }

            return true;
        }

        public bool ConstructTable(FurnitureBuilder furnitureBuilder)
        {
            if (default == furnitureBuilder)
            {
                return false;
            }

            var isMaterialSet = furnitureBuilder.SetMaterial("Wood");
            if (!isMaterialSet)
            {
                furnitureBuilder.ResetFurniture();
                return false;
            }
            var areDimensionsSet = furnitureBuilder.SetDimensions("100 cm", "80 cm", "180 cm");
            if (!areDimensionsSet)
            {
                furnitureBuilder.ResetFurniture();
                return false;
            }
            var isColorSet = furnitureBuilder.SetColor("Black");
            if (!isColorSet)
            {
                furnitureBuilder.ResetFurniture();
                return false;
            }
            var isLegSet = furnitureBuilder.SetLegs(4);
            if (!isLegSet)
            {
                furnitureBuilder.ResetFurniture();
                return false;
            }

            return true;
        }
        
        public bool ConstructDresser(FurnitureBuilder furnitureBuilder)
        {
            if (default == furnitureBuilder)
            {
                return false;
            }

            var isMaterialSet = furnitureBuilder.SetMaterial("Metal");
            if (!isMaterialSet)
            {
                furnitureBuilder.ResetFurniture();
                return false;
            }
            var areDimensionsSet = furnitureBuilder.SetDimensions("150 cm", "70 cm", "100 cm");
            if (!areDimensionsSet)
            {
                furnitureBuilder.ResetFurniture();
                return false;
            }
            var isColorSet = furnitureBuilder.SetColor("Grey");
            if (!isColorSet)
            {
                furnitureBuilder.ResetFurniture();
                return false;
            }

            return true;
        }
    }
}
