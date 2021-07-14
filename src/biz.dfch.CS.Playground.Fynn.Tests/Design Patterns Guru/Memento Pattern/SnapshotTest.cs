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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Memento_Pattern;
using biz.dfch.CS.Playground.Fynn.Visitor_and_Double_Dispatch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Memento_Pattern
{
    [TestClass]
    public class SnapshotTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetCanvasToNullThrowsArgumentNullException()
        {
            // Arrange
            var arbitraryName = "arbitraryName";
            var arbitraryColor = ConsoleColor.DarkMagenta;
            var arbitraryShape = new Circle();

            // Act
            var sut = new Snapshot(null, arbitraryColor, arbitraryShape, arbitraryName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetShapeToNullThrowsArgumentNullException()
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

            // Act
            var sut = new Snapshot(arbitraryCanvas, arbitraryColor, null, arbitraryName);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow(" ")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNameToInvalidNameThrowsArgumentNullException(string invalidName)
        {
            // Arrange
            var arbitraryColor = ConsoleColor.DarkMagenta;
            var arbitraryShape = new Circle();

            var arbitraryCanvas = new Canvas();
            arbitraryCanvas.SetBackgroundColor(arbitraryColor);
            arbitraryCanvas.SetShape(arbitraryShape);

            // Act
            var sut = new Snapshot(null, arbitraryColor, arbitraryShape, invalidName);
        }
    }
}
