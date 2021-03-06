﻿namespace Chess.Movements
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
                if (from.Row + 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
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

                if (from.Row == GlobalConstants.WhitePawnStartingRow && from.Col == to.Col)
                {
                    Position checkIfInFrontOfPawnIsClear = Position.FromChessCoordinates(from.Row + 1, from.Col);

                    if (board.GetFigureAtPosition(checkIfInFrontOfPawnIsClear) == null)
                    {
                        if (from.Row + 2 == to.Row && figureAtPosition == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.FigureOnTheWayException);
                    }
                }
            }
            else if (color == ChessColor.Black)
            {
                if (from.Row - 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
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

                if (from.Row == GlobalConstants.BlackPawnStartingRow && from.Col == to.Col)
                {
                    Position checkIfInFrontOfPawnIsClear = Position.FromChessCoordinates(from.Row - 1, from.Col);
                    if (board.GetFigureAtPosition(checkIfInFrontOfPawnIsClear) == null)
                    {
                        if (from.Row - 2 == to.Row && figureAtPosition == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.FigureOnTheWayException);
                    }
                }
            }

            throw new InvalidOperationException(ExceptionMessages.InvalidPawnMovementSidewaysException);
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

        private bool CheckDiagonalMove(Position from, Position to)
        {
            return from.Col + 1 == to.Col || from.Col - 1 == to.Col;
        }
    }
}
