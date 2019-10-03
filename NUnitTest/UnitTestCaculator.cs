using NUnit.Framework;
using caculator;

namespace CaculatorTests
{
    public class Add
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Step1Test1()
        {
            Assert.AreEqual(Caculater.Add("20"), 20); 
        }

        [Test]
        public void Step1Test2()
        {
            Assert.AreEqual(Caculater.Add("1,5000"), 5001);
        }

        [Test]
        public void Step1Test3()
        {
            Assert.AreEqual(Caculater.Add(""), 0);
        }

        [Test]
        public void Step1Test4()
        {
            Assert.AreEqual(Caculater.Add("5, ytyt"), 5);
        }

        [Test]
        public void Step1Test5()
        {
            Assert.AreEqual(Caculater.Add("a, b"), 0);
        }
    }
}