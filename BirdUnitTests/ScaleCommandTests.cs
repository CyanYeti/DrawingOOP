using AppLayer.Command;
using AppLayer.DrawingComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Threading;

namespace BirdUnitTests
{
    [TestClass]
    public class ScaleCommandTests
    {
        Drawing testDrawing = new Drawing();
        Invoker testInvoker = new Invoker();
        object[] testParams = { "bird", new Point(50, 50), (float)1 };
        Bird shouldEqualBird;
        BirdExtrinsicState extrinsicState;
        public ScaleCommandTests()
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
            CommandFactory.Instance.CreateAndDo("select", new Point(50, 50));
            CommandFactory.Instance.CreateAndDo("scale", (float)2);
            Thread.Sleep(50);

            Bird result = testDrawing.GetCloneOfElements()[0] as Bird;

            Assert.AreEqual(new Size(extrinsicState.Size.Width * 2, extrinsicState.Size.Height * 2), result.Size);
        }
        [TestMethod]
        public void Undo()
        {
            CommandFactory.Instance.CreateAndDo("addbird", testParams);
            CommandFactory.Instance.CreateAndDo("select", new Point(50, 50));
            CommandFactory.Instance.CreateAndDo("scale", (float) 2);
            testInvoker.Undo();
            Thread.Sleep(50);

            Bird result = testDrawing.GetCloneOfElements()[0] as Bird;

            Assert.AreEqual(new Size(extrinsicState.Size.Width, extrinsicState.Size.Height), result.Size);
        }
        [TestMethod]
        public void Redo()
        {
            CommandFactory.Instance.CreateAndDo("addbird", testParams);
            CommandFactory.Instance.CreateAndDo("select", new Point(50, 50));
            CommandFactory.Instance.CreateAndDo("scale", (float) 2);
            testInvoker.Redo();
            Thread.Sleep(50);

            Bird result = testDrawing.GetCloneOfElements()[0] as Bird;

            Assert.AreEqual(new Size(extrinsicState.Size.Width * 2, extrinsicState.Size.Height * 2), result.Size);
        }
    }
}
