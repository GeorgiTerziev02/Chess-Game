namespace Chess.Movements
{
    using System;

    using Chess.Common;
    using Chess.Board.Contracts;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;

    public class NormalRookMovement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var from = move.From;
            var to = move.To;

            var rowDistance = Math.Abs(from.Row - to.Row);
            var colDistance = Math.Abs(from.Col - to.Col);

            if (rowDistance > 0 && colDistance > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidRookMovementException);
            }

            int rowIndex = from.Row;
            char colIndex = from.Col;

            //Finding which direction is going the Rook
            int rowDirection = from.Row < to.Row ? 1 : -1;
            char colDirection = (char)(from.Col < to.Col ? 1 : -1);

            if (rowDistance == 0)
            {
                rowDirection = 0;
            }

            colDirection = (char)(colDistance > 0 ? colDirection : 0);

            while (true)
            {
                rowIndex += rowDirection;
                colIndex += colDirection;

                if (to.Row == rowIndex && to.Col == colIndex)
                {
                    var figureAtPosition = board.GetFigureAtPosition(to);

                    if (figureAtPosition != null || figureAtPosition.Color == figure.Color)
                    {
                        throw new InvalidOperationException(ExceptionMessages.FigureOnTheWayException);
                    }
                    else
                    {
                        return;
                    }
                }

                var position = Position.FromChessCoordinates(rowIndex, colIndex);
                var figureOnTheWay = board.GetFigureAtPosition(position);

                if (figureOnTheWay != null)
                {
                    throw new InvalidOperationException(ExceptionMessages.FigureOnTheWayException);
                }
            }
        }
    }
}
