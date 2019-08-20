namespace Chess.InputProviders
{
    using System;
    using System.Collections.Generic;
    using Chess.Common;
    using Chess.Common.Console;
    using Chess.InputProviders.Contracts;
    using Chess.Players;
    using Chess.Players.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PlayerNameText = "Enter Player {0} name: ";

        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();

                ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);
                Console.Write(string.Format(PlayerNameText, i));
                string name = Console.ReadLine();

                var player = new Player(name, (ChessColor)(i - 1));
                players.Add(player);
            }

            Console.Clear();

            return players;
        }

        public Move GetNextPlayerMove(IPlayer player)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - PlayerNameText.Length / 2 + 3, ConsoleConstants.ConsoleRowForExceptionMessagesAndCommands);
            Console.BackgroundColor = ConsoleColor.Black;

            //a5-c5
            Console.Write($"{player.Name} is next: ");
            var positionString = Console.ReadLine().Trim().ToLower();

            Move move = ConsoleHelpers.CreateMoveFromCommand(positionString);
            return move;
        }
    }
}
