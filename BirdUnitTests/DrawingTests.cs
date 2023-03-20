using AppLayer.Command;
using AppLayer.DrawingComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Linq;

namespace BirdUnitTests
{
    [TestClass]
    public class DrawingTests
    {
        Drawing testDrawing = new Drawing();
        Invoker testInvoker = new Invoker();
        object[] testParams = { new Point(30, 30), new Point(50, 50) };
        Line shouldEqualLine;
        public DrawingTests() 
        {
            CommandFactory.Instance.TargetDrawing = testDrawing;
            CommandFactory.Instance.Invoker = testInvoker;
            testInvoker.Start();

            shouldEqualLine = new Line()
            {
                Start = (Point)testParams[0],
                End = (Point)testParams[1]
            };

            

            CommandFactory.Instance.CreateAndDo("addline", testParams);
            CommandFactory.Instance.CreateAndDo("addline", testParams);
        }
        [TestMethod]
        public void GetCloneOfElementsTest()
        {
            var elements = testDrawing.GetCloneOfElements();
            Assert.IsNotNull(elements);
            Assert.AreEqual(2, elements.Count);
        }
        [TestMethod]
        public void ClearTests()
        {
            testDrawing.Clear();
            var elements = testDrawing.GetCloneOfElements();
            Assert.AreEqual(0, elements.Count);
        }
        [TestMethod]
        public void AddTests()
        {
            Line newLine = new Line() { Start= (Point)testParams[0], End= (Point)testParams[1] };
            testDrawing.Add(newLine);
            var elements = testDrawing.GetCloneOfElements();
            Assert.IsNotNull(elements);
            Assert.AreEqual(3, elements.Count);
        }

    }
}
