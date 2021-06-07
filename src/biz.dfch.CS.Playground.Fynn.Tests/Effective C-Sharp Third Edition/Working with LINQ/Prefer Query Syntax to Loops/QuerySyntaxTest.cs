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

using System.Linq;
using biz.dfch.CS.Playground.Fynn.Working_with_LINQ.Prefer_Query_Syntax_to_Loops;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Working_with_LINQ.Prefer_Query_Syntax_to_Loops
{
    [TestClass]
    public class QuerySyntaxTest
    {
        private int[] expectedNumbers = new[]
        {
            0,
            1,
            4,
            9,
            16,
            25,
            36,
            49,
            64,
            81,
            100,
            121,
            144,
            169,
            196,
            225,
            256,
            289,
            324,
            361,
            400,
            441,
            484,
            529,
            576,
            625,
            676,
            729,
            784,
            841,
            900,
            961,
            1024,
            1089,
            1156,
            1225,
            1296,
            1369,
            1444,
            1521,
            1600,
            1681,
            1764,
            1849,
            1936,
            2025,
            2116,
            2209,
            2304,
            2401,
            2500,
            2601,
            2704,
            2809,
            2916,
            3025,
            3136,
            3249,
            3364,
            3481,
            3600,
            3721,
            3844,
            3969,
            4096,
            4225,
            4356,
            4489,
            4624,
            4761,
            4900,
            5041,
            5184,
            5329,
            5476,
            5625,
            5776,
            5929,
            6084,
            6241,
            6400,
            6561,
            6724,
            6889,
            7056,
            7225,
            7396,
            7569,
            7744,
            7921,
            8100,
            8281,
            8464,
            8649,
            8836,
            9025,
            9216,
            9409,
            9604,
            9801,
        };

        [TestMethod]
        public void FirstExampleNonQueryReturnsExpectedNumbers()
        {
            // Arrange
            var sut = new QuerySyntax();

            // Act
            var numbers = sut.FirstExampleNonQuery();

            // Assert
            var result = expectedNumbers.SequenceEqual(numbers);
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void FirstExampleQueryReturnsExpectedNumbers()
        {
            // Arrange
            var sut = new QuerySyntax();

            // Act
            var numbers = sut.FirstExampleQuery();

            // Assert
            var result = expectedNumbers.SequenceEqual(numbers);
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void CallCreateValuePairsForLoop()
        {
            // Arrange
            var sut = new QuerySyntax();

            // Act
            var result = sut.CreateValuePairsForLoop();

            // Assert
        }
        
        [TestMethod]
        public void CallCreateValuePairs2ForLoop()
        {
            // Arrange
            var sut = new QuerySyntax();

            // Act
            var result = sut.CreateValuePairs2ForLoop();

            // Assert
        }
        
        [TestMethod]
        public void CallCreateValuePairsQuery()
        {
            // Arrange
            var sut = new QuerySyntax();

            // Act
            var result = sut.CreateValuePairsQuery();

            // Assert
        }
        
        [TestMethod]
        public void CallCreateValuePairs2Query()
        {
            // Arrange
            var sut = new QuerySyntax();

            // Act
            var result = sut.CreateValuePairs2Query();

            // Assert
        }
    }
}
