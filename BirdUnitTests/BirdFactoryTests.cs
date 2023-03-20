using AppLayer.Command;
using AppLayer.DrawingComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace BirdUnitTests
{
    [TestClass]
    public class BirdFactoryTests
    {
        object[] testParams = { "bird", new Point(50, 50), (float)1 };
        Bird shouldEqualBird;
        BirdExtrinsicState extrinsicState;
        public BirdFactoryTests()
        {
            //BirdFactory.Instance.ResourceNamePattern = "bird";
            //BirdFactory.Instance.ReferenceType = typeof(Birds.Program);

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
        public void GetBirdTest()
        {
            Bird result = BirdFactory.Instance.GetBird(extrinsicState) as Bird;

            Assert.AreEqual(result.Size, shouldEqualBird.Size);
            Assert.AreEqual(result.getLocation(), shouldEqualBird.getLocation());
        }
    }
}
