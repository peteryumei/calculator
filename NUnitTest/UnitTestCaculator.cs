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
            Assert.AreEqual(Caculater.Add("1,5000"), 1);
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

        [Test]
        public void Step5Test1()
        {
            Assert.AreEqual(Caculater.Add("2,1001,6"), 8);
        }

        [Test]
        public void Step6Test1()
        {
            Assert.AreEqual(Caculater.Add("//;\n2;5"), 7);
        }

        [Test]
        public void Step6Test2()
        {
            Assert.AreEqual(Caculater.Add("//:\n1:5:6"), 12);
        }

        [Test]
        public void Step7Test1()
        {
            Assert.AreEqual(Caculater.Add("//[***]\n11***22***33"), 66);
        }

        [Test]
        public void Step8Test1()
        {
            Assert.AreEqual(Caculater.Add("//[*][!!][r9r]\n11r9r22*33!!44"), 110);
        }
    }
}