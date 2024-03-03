using TurnupPortal.UITests.TestBase;

namespace TurnupPortal.UITests
{
    public class Tests : TestSetup
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine(_globalProperties?.AppURL);
            Console.WriteLine(_globalProperties?.InvalidUser);
            Console.WriteLine(_globalProperties?.ImplicitWaitTime);
        }
    }
}