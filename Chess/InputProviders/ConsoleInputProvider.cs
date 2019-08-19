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
        public ICollection<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();

                ConsoleHelpers.SetCursorAtCenter(0);
                Console.Write($"Enter Player {i} name: ");
                string name = Console.ReadLine();

                var player = new Player(name, (ChessColor)(i - 1));
                players.Add(player);
            }

            return players;
        }
    }
}
