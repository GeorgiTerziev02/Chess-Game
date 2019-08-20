namespace Chess.Renderers
{
    using System;
    using System.Threading;
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Common.Console;
    using Chess.Renderers.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "Chess";
        private const ConsoleColor DarkSquareConsoleColor = ConsoleColor.DarkGray;
        private const ConsoleColor LightSquareConsoleColor = ConsoleColor.Gray;
        private const string FontWarning = "For best experience use Raster Fonts 8x8 / 8x9";

        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);
            Console.SetCursorPosition(Console.WindowWidth / 2 - FontWarning.Length / 2, Console.WindowHeight / 2 + 2);
            Console.WriteLine(FontWarning);

            //TODO: Add main menu
            Thread.Sleep(4000);
        }

        public void RenderBoard(IBoard board)
        {
            //TODO: Validate Console dimensions
            var startColPrint = Console.WindowHeight / 2 - (board.TotalCols / 2) * ConsoleConstants.CharactersPerRowPerBoardSquare;
            var startRowPrint = Console.WindowWidth / 2 - (board.TotalRows / 2) * ConsoleConstants.CharactersPerColPerBoardSquare;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;

            Console.BackgroundColor = ConsoleColor.White;

            int counter = 1;

            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentColPrint = startRowPrint + left * ConsoleConstants.CharactersPerColPerBoardSquare;
                    currentRowPrint = startColPrint + top * ConsoleConstants.CharactersPerRowPerBoardSquare;

                    ConsoleColor backgroundColor;
                    if (counter % 2 == 0)
                    {
                        backgroundColor = DarkSquareConsoleColor;
                        Console.BackgroundColor = DarkSquareConsoleColor;
                    }
                    else
                    {
                        backgroundColor = LightSquareConsoleColor;
                        Console.BackgroundColor = LightSquareConsoleColor;
                    }

                    Console.SetCursorPosition(currentColPrint, currentRowPrint);
                    Console.WriteLine(" ");

                    var position = Position.FromArrayCoordinates(top, left, board.TotalRows);

                    var figure = board.GetFigureAtPosition(position);
                    ConsoleHelpers.PrintFigure(figure, backgroundColor, currentRowPrint, currentColPrint);
                    counter++;
                }

                counter++;
            }
        }

        public void PrintErrorMessage(string message)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForExceptionMessagesAndCommands);
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2 + 3, ConsoleConstants.ConsoleRowForExceptionMessagesAndCommands);
            Console.Write(message);

            Thread.Sleep(2000);

            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForExceptionMessagesAndCommands);
        }
    }
}
