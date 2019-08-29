namespace Chess
{
    using System;
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
            Console.Title = "ChessGame";

            IRenderer renderer = new ConsoleRenderer();
            renderer.RenderMainMenu();

            IInputProvider inputProvider = new ConsoleInputProvider();
            IGameInitializationStrategy gameInitializationStrategy = new StandardStartGameInitializationStrategy();

            IChessEngine chessEngine = new StandardTwoPlayerEngine(renderer, inputProvider);

            chessEngine.Initialize(gameInitializationStrategy);
            chessEngine.Start();
        }
    }
}
