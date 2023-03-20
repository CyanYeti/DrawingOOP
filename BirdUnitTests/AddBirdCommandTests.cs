using AppLayer.Command;
using AppLayer.DrawingComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Threading;

namespace BirdUnitTests
{
    [TestClass]
    public class AddBirdCommandTests
    {
        Drawing testDrawing = new Drawing();
        Invoker testInvoker = new Invoker();
        object[] testParams = { "bird", new Point(50, 50), (float)1 };
        Bird shouldEqualBird;
        BirdExtrinsicState extrinsicState;

        public AddBirdCommandTests()
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
        public void ExecuteTest()
        {
            CommandFactory.Instance.CreateAndDo("addbird", testParams);

            Thread.Sleep(50);


            Bird resultBird = testDrawing.GetCloneOfElements()[0] as Bird;


            Assert.AreEqual(resultBird.Size, shouldEqualBird.Size);
            Assert.AreEqual(resultBird.getLocation(), shouldEqualBird.getLocation());
            
        }
        [TestMethod]
        public void UndoTest()
        {
            CommandFactory.Instance.CreateAndDo("addbird", testParams);

            testInvoker.Undo();

            Thread.Sleep(50);

            Assert.AreEqual(0, testDrawing.GetCloneOfElements().Count);
        }
        [TestMethod]
        public void RedoTest()
        {
            CommandFactory.Instance.CreateAndDo("addbird", testParams);

            testInvoker.Undo();

            Thread.Sleep(50);

            Assert.AreEqual(0, testDrawing.GetCloneOfElements().Count);

            testInvoker.Redo();

            Thread.Sleep(50);

            Bird resultBird = testDrawing.GetCloneOfElements()[0] as Bird;

            Assert.AreEqual(resultBird.Size, shouldEqualBird.Size);
            Assert.AreEqual(resultBird.getLocation(), shouldEqualBird.getLocation());
        }
    }
}
