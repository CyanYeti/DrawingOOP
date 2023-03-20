using System;
using System.Collections.Generic;

namespace AppLayer.DrawingComponents
{
    public class BirdFactory
    {
        private static BirdFactory _instance;
        private static readonly object MyLock = new object();
        // Trey: Here is another factory to create the birds to be drawn, also a singleton with a single instance
        private BirdFactory() { }

        public static BirdFactory Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new BirdFactory();
                }
                return _instance;
            }
        }

        public string ResourceNamePattern { get; set; }
        public Type ReferenceType { get; set; }

        private readonly Dictionary<string, BirdWithIntrinsicState> _sharedBirds = new Dictionary<string, BirdWithIntrinsicState>();

        public BirdWithAllState GetBird(BirdExtrinsicState extrinsicState)
        {
            BirdWithIntrinsicState birdWithIntrinsicState;
            if (_sharedBirds.ContainsKey(extrinsicState.BirdType))
            {
                birdWithIntrinsicState = _sharedBirds[extrinsicState.BirdType];
            }
            else
            {
                birdWithIntrinsicState = new BirdWithIntrinsicState();
                var resourceName = string.Format(ResourceNamePattern, extrinsicState.BirdType);
                birdWithIntrinsicState.LoadFromResource(resourceName, ReferenceType);
                _sharedBirds.Add(extrinsicState.BirdType, birdWithIntrinsicState);
            }
            // Well insured bird
            return new BirdWithAllState(birdWithIntrinsicState, extrinsicState);
        }
    }
}
