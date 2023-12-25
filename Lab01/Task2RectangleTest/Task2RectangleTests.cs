using Task2RectangleNS;
namespace Task2RectangleTest
{
    [TestClass]
    public class Task2RectangleTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            double side1 = 10.1;
            double side2 = 15.5;
            Rectangle rectangle = new Rectangle(side1, side2);
            Assert.AreEqual(51.2, rectangle.Perimeter);
            Assert.AreEqual(156.55, rectangle.Area, 0.001);
        }
    }
}