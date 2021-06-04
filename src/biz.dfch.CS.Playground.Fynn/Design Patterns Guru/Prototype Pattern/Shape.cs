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


namespace biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Prototype_Pattern
{
    public class Shape : ICloneable<Shape>
    {
        public string Color { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public LengthUnit LengthUnit { get; set; } = LengthUnit.None;
        
        public Shape Clone()
        {
            return (Shape) MemberwiseClone();
        }

        private bool Equals(Shape other)
        {
            if (null == other) return false;

            return Color == null ? Color == other.Color : Color.Equals(other.Color)
                                                          && Width.Equals(other.Width)
                                                          && Length.Equals(other.Length)
                                                          && Height.Equals(other.Height)
                                                          && LengthUnit.Equals(other.LengthUnit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Shape)obj);
        }

        public override int GetHashCode()
        {
            var hashColor = Color == null ? 0 : Color.GetHashCode();
            var hashLength = Length.GetHashCode();
            var hashWidth = Width.GetHashCode();
            var hashHeight = Height.GetHashCode();
            var hashLengthUnit = LengthUnit.GetHashCode();

            return hashColor ^ hashLength ^ hashWidth ^ hashHeight ^ hashLengthUnit;
        }
    }
}
