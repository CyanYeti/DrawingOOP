using AppLayer.Command;
using AppLayer.DrawingComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Threading;

namespace BirdUnitTests
{
    [TestClass]
    public class NewCommandTests
    {
        Drawing testDrawing = new Drawing();
        Invoker testInvoker = new Invoker();
        object[] testParams = { "bird", new Point(50, 50), (float)1 };
        Bird shouldEqualBird;
        BirdExtrinsicState extrinsicState;

        public NewCommandTests()
        {
            CommandFactory.Instance.TargetDrawing = testDrawing;
            CommandFactory.Instance.Invoker = testInvoker;
            testInvoker.Start();

            BirdFactory.Instance.ResourceNamePattern = "bird";
            BirdFactory.Instance.ReferenceType = typeof(Birds.Program);

            var birdSize = new Size()
            {
                Width = Convert.ToInt16(Math.Round(80 * 1.0, 0)),
                Height = Convert.ToInt16(Math.Round(80 * 1.0, 0))
            };
            var birdLocation = new Point(50 - birdSize.Width / 2, 50 - birdSize.Height / 2);


            extrinsicState = new BirdExtrinsicState()
            {
                BirdType = "bird",
                Location = birdLocation,
                Size = birdSize
            };

            shouldEqualBird = BirdFactory.Instance.GetBird(extrinsicState) as Bird;

        }
        [TestMethod]
        public void Execute()
        {
            CommandFactory.Instance.CreateAndDo("addbird", testParams);
            CommandFactory.Instance.CreateAndDo("new");
            Thread.Sleep(50);
            // We add something, new should clear that list
            Assert.AreEqual(0, testDrawing.GetCloneOfElements().Count);
        }
        [TestMethod]
        public void Undo()
        {
            CommandFactory.Instance.CreateAndDo("addbird", testParams);
            CommandFactory.Instance.CreateAndDo("new");
            testInvoker.Undo();
            Thread.Sleep(50);
            // We add something, new should clear that list
            Assert.AreEqual(1, testDrawing.GetCloneOfElements().Count);
        }
        [TestMethod]
        public void Redo()
        {
            CommandFactory.Instance.CreateAndDo("addbird", testParams);
            CommandFactory.Instance.CreateAndDo("new");
            testInvoker.Undo();
            testInvoker.Redo();
            Thread.Sleep(50);
            // We add something, new should clear that list
            Assert.AreEqual(0, testDrawing.GetCloneOfElements().Count);
        }
    }
}
