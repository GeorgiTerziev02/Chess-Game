namespace Chess
{
    using Chess.Common.Console;
    using Chess.Engine;
    using Chess.Engine.Contracts;
    using Chess.Engine.Initializations;
    using Chess.InputProviders;
    using Chess.InputProviders.Contracts;
    using Chess.Renderers;
    using Chess.Renderers.Contracts;

    public static class ChessFacade
    {
        public static void Start()
        {
            ConsoleHelpers.SetConsoleAndBufferWidthAndHeigth();

            IRenderer renderer = new ConsoleRenderer();
            //TODO: Remove comment
            //renderer.RenderMainMenu();

            IInputProvider inputProvider = new ConsoleInputProvider();
            IGameInitializationStrategy gameInitializationStrategy = new StandardStartGameInitializationStrategy();

            IChessEngine chessEngine = new StandardTwoPlayerEngine(renderer, inputProvider);

            chessEngine.Initialize(gameInitializationStrategy);
            chessEngine.Start();
        }
    }
}
