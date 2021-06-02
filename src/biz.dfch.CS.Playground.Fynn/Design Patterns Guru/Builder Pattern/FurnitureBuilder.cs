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

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Builder_Pattern
{
    public class FurnitureBuilder : IBuilder
    {
        private Furniture furniture;

        public FurnitureBuilder()
        {
            furniture = new Furniture();
        }

        public bool SetMaterial(string material)
        {
            if (string.IsNullOrWhiteSpace(material) || string.Empty == material)
            {
                return false;
            }

            furniture.Material = material;

            return true;
        }

        public bool SetDimensions(string height, string width, string length)
        {
            if (string.IsNullOrWhiteSpace(height) || string.Empty == height)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(width) || string.Empty == width)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(length) || string.Empty == length)
            {
                return false;
            }

            furniture.Height = height;
            furniture.Width = width;
            furniture.Length = length;

            return true;
        }

        public bool SetColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color) || string.Empty == color)
            {
                return false;
            }

            furniture.Color = color;

            return true;
        }

        public bool SetLegs(int legCount)
        {
            if (0 > legCount)
            {
                return false;
            }

            furniture.LegCount = legCount;
            
            return true;
        }

        public Furniture GetFurniture()
        {
            return furniture;
        }

        public void ResetFurniture()
        {
            furniture.Reset();
        }
    }
}
