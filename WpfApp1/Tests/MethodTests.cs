using NUnit.Framework;

namespace WpfApp1.Tests
{
    [TestFixture]
    class MethodTests
    {
        [Test]
        public void DegreesResultTest()
        {
            var result = Calculations.ConvertToDegrees(1);

            Assert.That(result, Is.EqualTo(57.2958));
        } 

        [Test]
        public void RadianResultTest()
        {
            var result = Calculations.ConvertToRadians(1);

            Assert.That(result, Is.EqualTo(0.017453));
        }

        [Test]
        public void ConvertToRadiansTest()
        {
            var result = Calculations.ConvertToRadians(1);

            Assert.That(result, Is.EqualTo(0.017453));
        }
    }
}
