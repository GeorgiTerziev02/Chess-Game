﻿namespace Chess.Common.Console
{
    using Chess.Figures;
    using Chess.Figures.Contracts;
    using System;
    using System.Collections.Generic;

    public static class ConsoleHelpers
    {
        private static IDictionary<string, bool[,]> patterns = new Dictionary<string, bool[,]>
        {
            {"Pawn", new bool[,]
            {
                {false, false, false, false, false, false, false, false, false },
                {false, false, false, false, false, false, false, false, false },
                {false, false, false, false, true, false, false, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, false, false, true, false, false, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, true, true, true, true, true, false, false },
                {false, false, false, false, false, false, false, false, false }
            }},
            { "Rook", new bool[,]
            {
                {false, false, false, false, false, false, false, false, false },
                {false, false, true, false, true, false, true, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, true, true, true, true, true, false, false },
                {false, false, true, true, true, true, true, false, false },
                {false, false, false, false, false, false, false, false, false }
            }},

            { "Knight", new bool[,]
            {
                {false, false, false, false, false, false, false, false, false },
                {false, false, false, false, true, true, false, false, false },
                {false, false, false, true, true, true, true, false, false },
                {false, false, true, true, true, false, true, false, false },
                {false, false, false, true, false, true, true, false, false },
                {false, false, false, false, true, true, true, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, true, true, true, true, true, false, false },
                {false, false, false, false, false, false, false, false, false }
            }},

            { "Bishop", new bool[,]
            {
                {false, false, false, false, false, false, false, false, false },
                {false, false, false, false, true, false, false, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, false, true, true, false, true, true, false, false },
                {false, false, true, false, false, false, true, false, false },
                {false, false, false, true, false, true, false, false, false },
                {false, false, false, false, true, false, false, false, false },
                {false, true, true, true, false, true, true, true, false },
                {false, false, false, false, false, false, false, false, false },
            }},

            { "King", new bool[,]
            {
                {false, false, false, false, false, false, false, false, false },
                {false, false, false, false, true, false, false, false, false },
                {false, false, false, true, true, true, false, false, false },
                {false, true, true, false, true, false, true, true, false },
                {false, true, true, true, false, true, true, true, false },
                {false, true, true, true, true, true, true, true, false },
                {false, false, true, true, true, true, true, false, false },
                {false, false, true, true, true, true, true, false, false },
                {false, false, false, false, false, false, false, false, false }
            }},

            { "Queen", new bool[,]
            {
                {false, false, false, false, false, false, false, false, false },
                {false, false, false, false, true, false, false, false, false },
                {false, false, true, false, true, false, true, false, false },
                {false, false, false, true, false, true, false, false, false },
                {false, true, false, true, true, true, false, true, false },
                {false, false, true, false, true, false, true, false, false },
                {false, false, true, true, false, true, true, false, false },
                {false, false, true, true, true, true, true, false, false },
                {false, false, false, false, false, false, false, false, false }
            }},

        };
        public static ConsoleColor ToConsoleColor(this ChessColor chessColor)
        {
            switch (chessColor)
            {
                case ChessColor.Black:
                    return ConsoleColor.Black;
                case ChessColor.White:
                    return ConsoleColor.White;
                default:
                    throw new InvalidOperationException(ExceptionMessages.NonExistingChessColor);
            }

        }

        public static void SetCursorAtCenter(int lengthOfMessage)
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = Console.WindowWidth / 2 - lengthOfMessage / 2;
            Console.SetCursorPosition(centerCol, centerRow);
        }

        public static void SetConsoleAndBufferWidthAndHeigth()
        {
            Console.SetWindowSize(80, 80);
            Console.SetBufferSize(80, 80);
        }

        public static void PrintFigure(IFigure figure, ConsoleColor backgroundColor, int top, int left)
        {
            if (figure == null)
            {
                PrintEmptySquare(backgroundColor, top, left);
                return;
            }

            var figurePattern = patterns[figure.GetType().Name];

            for (int i = 0; i < figurePattern.GetLength(0); i++)
            {
                for (int j = 0; j < figurePattern.GetLength(1); j++)
                {
                    Console.SetCursorPosition(left + j, top + i);

                    if (figurePattern[i, j])
                    {
                        Console.BackgroundColor = figure.Color.ToConsoleColor();
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundColor;
                    }

                    Console.WriteLine(" ");
                }
            }

        }

        public static void PrintEmptySquare(ConsoleColor backgroundColor, int top, int left)
        {
            for (int i = 0; i < ConsoleConstants.CharactersPerRowPerBoardSquare; i++)
            {
                for (int j = 0; j < ConsoleConstants.CharactersPerColPerBoardSquare; j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    Console.WriteLine(" ");
                }
            }
        }

        public static Move CreateMoveFromCommand(string command)
        {
            var positionStringArgs = command.Trim().Split("-");

            if (positionStringArgs.Length!=2)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidCommandException);
            }

            var fromAsString = positionStringArgs[0];
            var toAsString = positionStringArgs[1];

            var fromPosition = Position.FromChessCoordinates(fromAsString[1] - '0', fromAsString[0]);
            var toPosition = Position.FromChessCoordinates(toAsString[1] - '0', toAsString[0]);

            return new Move(fromPosition, toPosition);
        }

        public static void ClearRow(int row)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, row);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}
