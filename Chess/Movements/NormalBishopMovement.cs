﻿namespace Chess.Movements
{
    using System;

    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;

    public class NormalBishopMovement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            var other = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;

            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBishopMovementSidewaysException);
            }

            var from = move.From;
            var to = move.To;

            int rowIndex = from.Row;
            char colIndex = from.Col;

            //Finding which direction is going the bishop
            int rowDirection = from.Row < to.Row ? 1 : -1;
            char colDirection = (char)(from.Col < to.Col ? 1 : -1);

            while (true)
            {
                rowIndex += rowDirection;
                colIndex += colDirection;

                if (to.Row == rowIndex && to.Col == colIndex)
                {
                    IFigure figureAtPosition = board.GetFigureAtPosition(to);

                    if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
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
