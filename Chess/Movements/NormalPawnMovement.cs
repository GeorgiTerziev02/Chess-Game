namespace Chess.Movements
{
    using System;
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;

    public class NormalPawnMovement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var color = figure.Color;
            var from = move.From;
            var to = move.To;

            if (color == ChessColor.White && to.Row < from.Row)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidPawnMovementBackwardsException);
            }

            if (color == ChessColor.Black && to.Row > from.Row)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidPawnMovementBackwardsException);
            }

            if (color == ChessColor.White)
            {
                if (from.Row + 1 == to.Row && (from.Col + 1 == to.Col || from.Col - 1 == to.Col))
                {
                    var otherFigure = board.GetFigureAtPosition(to);

                    if (otherFigure != null && otherFigure.Color == ChessColor.Black)
                    {

                    }
                }
            }
        }
    }
}
