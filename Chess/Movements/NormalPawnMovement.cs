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
            var other = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;
            var from = move.From;
            var to = move.To;

            var figureAtPosition = board.GetFigureAtPosition(to);

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

                if (from.Row + 1 == to.Row && CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
                    {
                        return;
                    }
                }

                if (from.Row == 2 && from.Col == to.Col)
                {
                    if (from.Row + 2 == to.Row && figureAtPosition == null)
                    {
                        return;
                    }
                }

                if (from.Row + 1 == to.Row && from.Col == to.Col)
                {
                    if (figureAtPosition == null)
                    {
                        return;
                    }
                }
            }
            else if (color == ChessColor.Black)
            {
                if (from.Row - 1 == to.Row && CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
                    {
                        return;
                    }
                }

                if (from.Row == 7 && from.Col == to.Col)
                {
                    if (from.Row - 2 == to.Row && figureAtPosition == null)
                    {
                        return;
                    }
                }

                if (from.Row - 1 == to.Row && from.Col == to.Col)
                {
                    if (figureAtPosition == null)
                    {
                        return;
                    }
                }
            }

            //TODO: constant
            //TODO: fix bug you can move pawn two up even when pawn is not on starting position
            if (from.Row == 2 && color == ChessColor.White)
            {
                if (from.Row + 2 == to.Row && this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }
            else if (from.Row == 7 && color == ChessColor.Black)
            {
                if (from.Row - 2 == to.Row && this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }

            if (from.Row + 1 == to.Row && color == ChessColor.White)
            {
                if (this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }
            else if (from.Row - 1 == to.Row && color == ChessColor.Black)
            {
                if (this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }

            throw new InvalidOperationException(ExceptionMessages.InvalidPawnMovementSidewaysException);
        }

        private static bool CheckDiagonalMove(Position from, Position to)
        {
            return (from.Col + 1 == to.Col || from.Col - 1 == to.Col);
        }

        private bool CheckOtherFigureIfValid(IBoard board, Position to, ChessColor color)
        {
            var otherFigure = board.GetFigureAtPosition(to);

            if (otherFigure != null && otherFigure.Color == color)
            {
                return true;
            }

            return false;
        }
    }
}
