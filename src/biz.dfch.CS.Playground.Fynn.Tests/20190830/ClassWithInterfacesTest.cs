using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock.AutoMock.Ninject.Infrastructure.Language;
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

namespace biz.dfch.CS.Playground.Fynn.Tests._20190830
{
    [TestClass]
    public class ClassWithInterfacesTest
    {
        [TestMethod]
        public void ClassWithOnlyDirectInterfaceReturnsTrue()
        {
            // Arrange
            var sut = new ClassWithInterfaces();
            var type = sut.GetType();

            // Act
            var isImplemented = typeof(IDirectInterface).IsAssignableFrom(type);
            Assert.IsTrue(isImplemented);

            var result = type.GetAllBaseTypes()
                .Where(e => type != e)
                .SelectMany(e => e.GetInterfaces())
                .All(e => typeof(IDirectInterface) != e);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ClassWithIndirectInterfaceReturnsFalse()
        {
            // Arrange
            var sut = new ClassWithInterfacesAndBaseClassWithInheritedInterface();
            var type = sut.GetType();

            // Act
            var isImplemented = typeof(IDirectInterface).IsAssignableFrom(type);
            Assert.IsTrue(isImplemented);

            var result = type.GetAllBaseTypes()
                .Where(e => type != e)
                .SelectMany(e => e.GetInterfaces())
                .All(e => typeof(IDirectInterface) != e);

            // Assert
            Assert.IsFalse(result);
        }

        public interface IDirectInterface
        {
        }

        public interface IIndirectInterface
        {
        }

        public class BaseClassWithIndirectInterface : IIndirectInterface
        {
        }

        public class BaseClassWithDirectAndIndirectInterface : IIndirectInterface, IDirectInterface
        {
        }

        public class ClassWithInterfaces : BaseClassWithIndirectInterface, IDirectInterface
        {
        }

        public class ClassWithInterfacesAndBaseClassWithInheritedInterface : BaseClassWithDirectAndIndirectInterface
        {
        }
    }
}