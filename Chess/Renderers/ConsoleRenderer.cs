﻿namespace Chess.Renderers
{
    using System;
    using System.Threading;
    using Chess.Board.Contracts;
    using Chess.Common.Console;
    using Chess.Renderers.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "Just Chess";

        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);

            //TODO: Add main menu
            Thread.Sleep(1000);

            Console.WriteLine(Logo);
        }

        public void RenderBoard(IBoard board)
        {
            throw new System.NotImplementedException();
        }
    }
}