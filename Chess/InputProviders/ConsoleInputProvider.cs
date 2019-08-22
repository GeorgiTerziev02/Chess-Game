namespace Chess.InputProviders
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Chess.Common;
    using Chess.Common.Console;
    using Chess.InputProviders.Contracts;
    using Chess.Players;
    using Chess.Players.Contracts;
    using Chess.Renderers;
    using Chess.Renderers.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PlayerNameText = "Enter Player {0} name: ";

        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                try
                {
                    Console.Clear();

                    ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);
                    Console.Write(string.Format(PlayerNameText, i));
                    string name = Console.ReadLine();

                    var player = new Player(name, (ChessColor)(i - 1));
                    players.Add(player);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    i--;
                    ConsoleHelpers.SetCursorAtCenter(e.Message.Length);
                    Console.Write(e.Message);
                    Thread.Sleep(2000);
                }
            }

            Console.Clear();

            return players;
        }

        public Move GetNextPlayerMove(IPlayer player)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForExceptionMessagesAndCommands);
            Console.SetCursorPosition(Console.WindowWidth / 2 - PlayerNameText.Length / 2 + 3, ConsoleConstants.ConsoleRowForExceptionMessagesAndCommands);
            Console.BackgroundColor = ConsoleColor.Black;

            //a5-c5
            Console.Write($"{player.Name} is next: ");
            var positionString = Console.ReadLine().Trim().ToLower();

            Move move = ConsoleHelpers.CreateMoveFromCommand(positionString);
            return move;
        }

        //TODO: Fix placement
        public int GetPawnPromotion()
        {
            while (true)
            {
                int chosen = 1;
                try
                {
                    //Console.Clear();
                    Console.SetCursorPosition(2, 3);
                    Console.WriteLine("Promote pawn to ( choose number between 1 and 4 ):");
                    Console.SetCursorPosition(2, 4);
                    Console.WriteLine("1 - Queen | 2 - Rook | 3 - Bishop | 4 - Knight");
                    Console.SetCursorPosition(2, 5);
                    Console.Write("Your choice - ");
                    chosen = int.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    IRenderer renderer = new ConsoleRenderer();
                    renderer.PrintErrorMessage(ex.Message);
                }

                for (int row = 3; row <= 5; row++)
                {
                    ConsoleHelpers.ClearRow(row);
                }

                return chosen;
            }
        }
    }
}
