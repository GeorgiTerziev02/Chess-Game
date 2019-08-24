﻿namespace Chess.Movements
{
    using System;

    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;
    using Chess.SpecialFigureCases;

    public class NormalKingMovement : IMovement
    {
        private KingCases kingCases;

        public NormalKingMovement()
        {
            this.kingCases = new KingCases();
        }

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if ((rowDistance == 1 && colDistance == 0) || (rowDistance == 0 && colDistance == 1) || (rowDistance == 1 && colDistance == 1))
            {
                if (figureAtPosition == null || figureAtPosition.Color != figure.Color)
                {
                    return;
                }
            }

            if (this.kingCases.CheckCastling(board, figure, move.From, to))
            {
                return;
            }

            throw new InvalidOperationException(ExceptionMessages.InvalidKingMovementException);
        }
    }
}
