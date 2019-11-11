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

namespace biz.dfch.CS.Playground.Fynn._20191007
{
    public static class IDrawableExtensions
    {
        public static void DrawBold(this IDrawable drawable, InterfaceVsExtensionMethod.Rectangle rectangle)
        {
            // bold
        }

        public static void DrawBold(this IDrawable drawable, InterfaceVsExtensionMethod.Circle circle)
        {
            // bold
        }
    }

    public static class RectangleExtension
    {
        public static void DrawBold(this InterfaceVsExtensionMethod.Rectangle rectangle)
        {
            // bold
        }
    }

    public static class CircleExtension
    {
        public static void DrawBold(this InterfaceVsExtensionMethod.Circle circle)
        {
            // bold
        }
    }

    public interface IDrawable
    {
        void Draw();
    }

    public class InterfaceVsExtensionMethod
    {
        public class Rectangle : IDrawable
        {
            public void Draw()
            {
                Console.WriteLine("-");
                Console.WriteLine("|");
                Console.WriteLine("-");
                // Draw rectangle
            }
        }

        public class Circle : IDrawable
        {
            public void Draw()
            {
                // Draw circle
                var x = new Circle();
                this.DrawBold(x);
                x.DrawBold();
            }
        }

        public class Triangle : IDrawable
        {
            public void Draw()
            {
                // Draw triangle
            }
        }
    }
}