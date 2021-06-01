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

using CsvHelper;

namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Builder_Pattern
{
    public class Furniture
    {
        public string Material { get; set; }
        public string Height { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Color { get; set; }

        private bool Equals(Furniture other)
        {
            return Material == null ? Material == other.Material : Material.Equals(other.Material)
                && Height == null ? Height == other.Height : Height.Equals(other.Height)
                && Length == null ? Length == other.Length : Length.Equals(other.Length)
                && Width == null ? Width == other.Width : Width.Equals(other.Width)
                && Color == null ? Color == other.Color : Color.Equals(other.Color);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Furniture)obj);
        }

        public override int GetHashCode()
        {
            var hashMaterial = Material == null ? 0 : Material.GetHashCode();
            var hashHeight = Height == null ? 0 : Height.GetHashCode();
            var hashLength = Length == null ? 0 : Length.GetHashCode();
            var hashWidth = Width == null ? 0 : Width.GetHashCode();
            var hashColor = Color == null ? 0 : Color.GetHashCode();

            return hashMaterial ^ hashHeight ^ hashLength ^ hashWidth ^ hashColor;
        }
    }
}
