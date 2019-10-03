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

        [Test]
        public void Step2Test1()
        {
            Assert.AreEqual(Caculater.Add("1,2,3,4,5,6,7,8,9,10,11,12"), 78);
        }

        [Test]
        public void Step3Test1()
        {
            Assert.AreEqual(Caculater.Add("1\n2,3"), 6);
        }
    }
}