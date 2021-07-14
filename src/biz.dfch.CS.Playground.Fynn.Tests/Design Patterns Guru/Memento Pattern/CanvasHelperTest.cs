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
using System.Linq;
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Memento_Pattern;
using biz.dfch.CS.Playground.Fynn.Visitor_and_Double_Dispatch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Memento_Pattern
{
    [TestClass]
    public class CanvasHelperTest
    {
        [TestMethod]
        public void UndoSucceeds()
        {
            // Arrange
            var arbitraryName = "arbitraryName";
            var arbitraryColor = ConsoleColor.DarkMagenta;
            var arbitraryShape = new Circle();

            var arbitraryCanvas = new Canvas
            {
                Name = arbitraryName
            };
            arbitraryCanvas.SetBackgroundColor(arbitraryColor);
            arbitraryCanvas.SetShape(arbitraryShape);

            var sut = new CanvasHelper(arbitraryCanvas);
            sut.Save();

            // Act
            arbitraryCanvas.Name = "New Name";
            sut.Undo();

            // Assert
            Assert.AreEqual(arbitraryName, arbitraryCanvas.Name);
        }

        [TestMethod]
        public void SaveSucceeds()
        {
            // Arrange
            var arbitraryName = "arbitraryName";
            var arbitraryColor = ConsoleColor.DarkMagenta;
            var arbitraryShape = new Circle();

            var arbitraryCanvas = new Canvas
            {
                Name = arbitraryName
            };
            arbitraryCanvas.SetBackgroundColor(arbitraryColor);
            arbitraryCanvas.SetShape(arbitraryShape);

            var sut = new CanvasHelper(arbitraryCanvas);

            // Act
            sut.Save();

            // Assert
            var result = sut.CanvasHistory.LastOrDefault();
            Assert.IsNotNull(result);
        }
    }
}
