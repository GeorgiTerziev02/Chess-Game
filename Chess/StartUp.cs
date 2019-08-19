namespace Chess
{
    using System;
    using Chess.Renderers;
    using Chess.Renderers.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(80, 80);
            Console.SetBufferSize(80, 80);

            IRenderer renderer = new ConsoleRenderer();
            renderer.RenderMainMenu();

        }
    }
}
