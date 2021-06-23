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
using biz.dfch.CS.Playground.Fynn.Design_Patterns_Guru.Observer_Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests.Design_Patterns_Guru.Observer_Pattern
{
    [TestClass]
    public class FootballNewsManagerTest
    {
        [TestMethod]
        public void SubscribeSubscriberSucceeds()
        {
            // Arrange
            var sut = new FootballNewsManager();
            var arbitraryListener = new FootballNewsApp();

            // Act
            sut.Subscribe(arbitraryListener);

            // Assert
            var result = sut.Subscribers.Contains(arbitraryListener);
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SubscribeNullThrowsArgumentNullException()
        {
            // Arrange
            var sut = new FootballNewsManager();

            // Act
            sut.Subscribe(null);

            // Assert
        }

        [TestMethod]
        public void UnsubscribeSubscriberSucceeds()
        {
            // Arrange
            var sut = new FootballNewsManager();
            var arbitraryListener = new FootballNewsApp();
            sut.Subscribe(arbitraryListener);

            // Act
            sut.Unsubscribe(arbitraryListener);

            // Assert
            var result = sut.Subscribers.Contains(arbitraryListener);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnsubscribeNullThrowsArgumentNullException()
        {
            // Arrange
            var sut = new FootballNewsManager();

            // Act
            sut.Unsubscribe(null);

            // Assert
        }

        [TestMethod]
        public void NotifySubscribersSucceeds()
        {
            // Arrange
            var sut = new FootballNewsManager();
            var arbitraryListener1 = new FootballNewsApp();
            var arbitraryListener2 = new FootballNewsApp();
            sut.Subscribe(arbitraryListener1);
            sut.Subscribe(arbitraryListener2);

            var arbitraryMessage = "Test Message!";

            // Act
            sut.Notify(arbitraryMessage);

            // Assert
            Assert.AreEqual(arbitraryMessage, arbitraryListener1.Message);
            Assert.AreEqual(arbitraryMessage, arbitraryListener2.Message);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void NotifySubscribersWithInvalidMessageThrowsArgumentException(string invalidMessage)
        {
            // Arrange
            var sut = new FootballNewsManager();
            var arbitraryListener1 = new FootballNewsApp();
            var arbitraryListener2 = new FootballNewsApp();
            sut.Subscribe(arbitraryListener1);
            sut.Subscribe(arbitraryListener2);

            // Act
            sut.Notify(invalidMessage);

            // Assert
        }
    }
}
