using NUnit.Framework;
using System;
using static NUnit.Framework.Assert;
using static VRChatPackageTemplate.ExampleRuntimeScript;

namespace VRChatPackageTemplate.Tests
{
    public class RuntimeTests
    {
        [Test]
        public void TestAdd() => True(Add(5, 10) == 15);

        [Test]
        public void TestSubtract() => True(Subtract(5, 10) == -5);

        [Test]
        public void TestMultiply() => True(Multiply(25, 5) == 125);

        [Test]
        public void TestDivide() => True(Divide(25, 5) == 5);

        [Test]
        public void TestDivideByZero() =>
            Throws<DivideByZeroException>(() => Divide(10, 0));
    }
}
