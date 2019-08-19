namespace Chess.Engine
{
    using System.Collections.Generic;
    using Chess.Common;
    using Chess.Engine.Contracts;
    using Chess.InputProviders.Contracts;
    using Chess.Players.Contracts;
    using Chess.Renderers.Contracts;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private readonly IEnumerable<IPlayer> players;
        private IRenderer renderer;
        private IInputProvider input;

        public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
        }

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            var player = this.input.GetPlayers(GlobalConstants.StandardGameNumberOfPlayers);
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void WinningConditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
