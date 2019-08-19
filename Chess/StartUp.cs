namespace Chess
{
    using Chess.Common.Console;
    using Chess.Renderers;
    using Chess.Renderers.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ConsoleHelpers.SetConsoleWidthAndHeigth();

            IRenderer renderer = new ConsoleRenderer();
            renderer.RenderMainMenu();

        }
    }
}
