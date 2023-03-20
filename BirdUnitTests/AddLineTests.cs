using AppLayer.Command;
using AppLayer.DrawingComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Threading;

namespace BirdUnitTests
{
    [TestClass]
    public class AddLineTests
    {
        Drawing testDrawing = new Drawing();
        Invoker testInvoker = new Invoker();
        object[] testParams = {new Point(30,30), new Point(50, 50)};
        Line shouldEqualLine;

        public AddLineTests() 
        {
            CommandFactory.Instance.TargetDrawing = testDrawing;
            CommandFactory.Instance.Invoker = testInvoker;
            testInvoker.Start();

            shouldEqualLine = new Line()
            {
                Start = (Point) testParams[0],
                End = (Point) testParams[1]
            };
        }
        [TestMethod]
        public void Execute()
        {
            CommandFactory.Instance.CreateAndDo("addline", testParams);
            Thread.Sleep(50);

            Line result = testDrawing.GetCloneOfElements()[0] as Line;

            Assert.AreEqual(result.Start, shouldEqualLine.Start);
            Assert.AreEqual(result.IsSelected, shouldEqualLine.IsSelected);
            Assert.AreEqual(result.getLocation(), shouldEqualLine.getLocation());
            Assert.AreEqual(result.End, shouldEqualLine.End);
        }
        [TestMethod]
        public void Undo()
        {
            CommandFactory.Instance.CreateAndDo("addline", testParams);

            testInvoker.Undo();

            Thread.Sleep(50);

            Assert.AreEqual(0, testDrawing.GetCloneOfElements().Count);
        }
        [TestMethod]
        public void Redo()
        {
            CommandFactory.Instance.CreateAndDo("addline", testParams);

            testInvoker.Undo();

            Assert.AreEqual(0, testDrawing.GetCloneOfElements().Count);

            testInvoker.Redo();

            Thread.Sleep(50);

            Assert.AreEqual(1, testDrawing.GetCloneOfElements().Count);
            Line result = testDrawing.GetCloneOfElements()[0] as Line;

            Assert.AreEqual(result.Start, shouldEqualLine.Start);
            Assert.AreEqual(result.IsSelected, shouldEqualLine.IsSelected);
            Assert.AreEqual(result.getLocation(), shouldEqualLine.getLocation());
            Assert.AreEqual(result.End, shouldEqualLine.End);
        }
    }
}
