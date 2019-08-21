namespace Chess.Engine.Initializations
{
    using System;
    using System.Collections.Generic;
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Engine.Contracts;
    using Chess.Figures;
    using Chess.Figures.Contracts;
    using Chess.Players.Contracts;

    public class StandardStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int BoardTotalRowsAndCols = 8;

        private IList<Type> figureTypes;

        public StandardStartGameInitializationStrategy()
        {
            this.figureTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Knight),
                typeof(Bishop),
                typeof(Queen),
                typeof(King),
                typeof(Bishop),
                typeof(Knight),
                typeof(Rook)
            };

        }

        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];

            this.AddArmyToBoardRow(secondPlayer, board, 8);
            this.AddPawnsToBoardRow(secondPlayer, board, 7);

            this.AddPawnsToBoardRow(firstPlayer, board, 2);
            this.AddArmyToBoardRow(firstPlayer, board, 1);
        }

        private void AddPawnsToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var pawn = new Pawn(player.Color);
                player.AddFigure(pawn);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(pawn, position);
            }
        }

        private void AddArmyToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var figureType = this.figureTypes[i];
                var figure = (IFigure)Activator.CreateInstance(figureType, player.Color);

                player.AddFigure(figure);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(figure, position);
            }
        }

        private static void ValidateStrategy(IList<IPlayer> players, IBoard board)
        {
            if (players.Count != GlobalConstants.StandardGameNumberOfPlayers)
            {
                throw new InvalidOperationException(ExceptionMessages.StandardGameMustHaveTwoPlayersException);
            }

            if (board.TotalRows != BoardTotalRowsAndCols
                || board.TotalCols != BoardTotalRowsAndCols)
            {
                throw new InvalidOperationException(ExceptionMessages.StandardGameMustHaveEightSquareBoardException);
            }
        }
    }
}
