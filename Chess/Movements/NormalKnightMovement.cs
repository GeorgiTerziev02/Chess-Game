namespace Chess.Movements
{
    using System;

    using Chess.Common;
    using Chess.Board.Contracts;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;

    public class NormalKnightMovement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var from = move.From;
            var to = move.To;

            var rowDistance = Math.Abs(from.Row - to.Row);
            var colDistance = Math.Abs(from.Col - to.Col);

            var figureAtPosition = board.GetFigureAtPosition(to);

            if (figureAtPosition == null || figureAtPosition.Color != figure.Color)
            {
                if ((rowDistance == 2 && colDistance == 1) || (rowDistance == 1 && colDistance == 2))
                {
                    return;
                }
            }

            throw new InvalidOperationException(ExceptionMessages.InvalidKnightMovementException);
        }
    }
}
