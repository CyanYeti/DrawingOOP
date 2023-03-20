using AppLayer.Command;
using AppLayer.DrawingComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Threading;

namespace BirdUnitTests
{
    [TestClass]
    public class DeselectAllCommandTests
    {
        Drawing testDrawing = new Drawing();
        Invoker testInvoker = new Invoker();
        object[] testParams = { new Point(30, 30), new Point(50, 50) };
        Line shouldEqualLine;
        public DeselectAllCommandTests()
        {
            CommandFactory.Instance.TargetDrawing = testDrawing;
            CommandFactory.Instance.Invoker = testInvoker;
            testInvoker.Start();

            shouldEqualLine = new Line()
            {
                Start = (Point)testParams[0],
                End = (Point)testParams[1]
            };
        }
        [TestMethod]
        public void Execute()
        {
            CommandFactory.Instance.CreateAndDo("addline", testParams);
            CommandFactory.Instance.CreateAndDo("select", new Point(30, 30));
            Thread.Sleep(50);

            Line result = testDrawing.GetAllSelected()[0] as Line;
            Assert.AreEqual(true, result.IsSelected);

            CommandFactory.Instance.CreateAndDo("deselect");

            result = testDrawing.GetCloneOfElements()[0] as Line;
            Assert.AreEqual(false, result.IsSelected);
        }
        [TestMethod]
        public void Undo()
        {
            CommandFactory.Instance.CreateAndDo("addline", testParams);
            CommandFactory.Instance.CreateAndDo("select", new Point(30, 30));
            CommandFactory.Instance.CreateAndDo("deselect");

            testInvoker.Undo();
            Thread.Sleep(50);

            Line result = testDrawing.GetAllSelected()[0] as Line;
            Assert.AreEqual(true, result.IsSelected);
        }
        [TestMethod]
        public void Redo()
        {
            CommandFactory.Instance.CreateAndDo("addline", testParams);
            CommandFactory.Instance.CreateAndDo("select", new Point(30, 30));
            CommandFactory.Instance.CreateAndDo("deselect");

            testInvoker.Undo();
            testInvoker.Redo();
            Thread.Sleep(50);

            Line result = testDrawing.GetCloneOfElements()[0] as Line;
            Assert.AreEqual(false, result.IsSelected);
        }
    }
}
