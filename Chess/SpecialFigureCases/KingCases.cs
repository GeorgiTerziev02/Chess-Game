namespace Chess.SpecialFigureCases
{
    using System;
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures;
    using Chess.Figures.Contracts;

    public class KingCases
    { 
        private readonly static Position WhiteShortCastlingPosition = Position.FromChessCoordinates(1, 'g');
        private readonly static Position WhiteLongCastlingPosition = Position.FromChessCoordinates(1, 'c');
        private readonly static Position BlackShortCastlingPosition = Position.FromChessCoordinates(8, 'g');
        private readonly static Position BlackLongCastlingPosition = Position.FromChessCoordinates(8, 'c');
        private readonly int WhiteArmyRow = 1;
        private readonly int BlackArmyRow = 8;

        public bool CheckCastling(IBoard board, IFigure figure, Position from, Position to)
        {
            var color = figure.Color;

            if (color == ChessColor.White)
            {
                if (to.Row == WhiteShortCastlingPosition.Row && to.Col == WhiteShortCastlingPosition.Col
                    && from.Col == GlobalConstants.StandardGameWhiteKingPosition.Col && from.Row == GlobalConstants.StandardGameWhiteKingPosition.Row)
                {
                    if (!MoveFiguresInformation.isWhiteKingMoved && !MoveFiguresInformation.isWhiteRightRookMoved)
                    {
                        CheckForFiguresBetweenPositions(board, figure, from, to);
                        CheckIfKingIsInCheck(board, color);
                        CheckIfKingCrossesAttackedField(board, GlobalConstants.StandardGameWhiteKingPosition, WhiteShortCastlingPosition, color);

                        board.RemoveFigure(GlobalConstants.StandardGameWhiteKingPosition);
                        board.RemoveFigure(GlobalConstants.StandardGameWhiteRightRookPosition);

                        board.AddFigure(new King(color), WhiteShortCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(1, 'f'));

                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.RookOrKingHaveBeenMovedException);
                    }
                }

                if (to.Row == WhiteLongCastlingPosition.Row && to.Col == WhiteLongCastlingPosition.Col 
                    && from.Col == GlobalConstants.StandardGameWhiteKingPosition.Col && from.Row == GlobalConstants.StandardGameWhiteKingPosition.Row)
                {
                    if (!MoveFiguresInformation.isWhiteKingMoved && !MoveFiguresInformation.isWhiteLeftRookMoved)
                    {
                        CheckForFiguresBetweenPositions(board, figure, from, to);
                        CheckIfKingIsInCheck(board, color);
                        CheckIfKingCrossesAttackedField(board, GlobalConstants.StandardGameWhiteKingPosition, WhiteLongCastlingPosition, color);

                        board.RemoveFigure(GlobalConstants.StandardGameWhiteKingPosition);
                        board.RemoveFigure(GlobalConstants.StandardGameWhiteLeftRookPosition);

                        board.AddFigure(new King(color), WhiteLongCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(1, 'd'));

                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.RookOrKingHaveBeenMovedException);
                    }
                }
            }

            if (color == ChessColor.Black)
            {
                if (to.Row == BlackShortCastlingPosition.Row && to.Col == BlackShortCastlingPosition.Col 
                    && from.Col == GlobalConstants.StandardGameBlackKingPosition.Col && from.Row == GlobalConstants.StandardGameBlackKingPosition.Row)
                {
                    if (!MoveFiguresInformation.isBlackKingMoved && !MoveFiguresInformation.isBlackRightRookMoved)
                    {
                        CheckForFiguresBetweenPositions(board, figure, from, to);
                        CheckIfKingIsInCheck(board, color);
                        CheckIfKingCrossesAttackedField(board, GlobalConstants.StandardGameBlackKingPosition, BlackShortCastlingPosition, color);

                        board.RemoveFigure(GlobalConstants.StandardGameBlackKingPosition);
                        board.RemoveFigure(GlobalConstants.StandardGameBlackRightRookPosition);

                        board.AddFigure(new King(color), BlackShortCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(8, 'f'));

                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.RookOrKingHaveBeenMovedException);
                    }
                }

                if (to.Row == BlackLongCastlingPosition.Row && to.Col == BlackLongCastlingPosition.Col 
                    && from.Col == GlobalConstants.StandardGameBlackKingPosition.Col && from.Row == GlobalConstants.StandardGameBlackKingPosition.Row)
                {
                    if (!MoveFiguresInformation.isBlackKingMoved && !MoveFiguresInformation.isBlackLeftRookMoved)
                    {
                        CheckForFiguresBetweenPositions(board, figure, from, to);
                        CheckIfKingIsInCheck(board, color);
                        CheckIfKingCrossesAttackedField(board, GlobalConstants.StandardGameBlackKingPosition, BlackLongCastlingPosition, color);

                        board.RemoveFigure(GlobalConstants.StandardGameBlackKingPosition);
                        board.RemoveFigure(GlobalConstants.StandardGameBlackLeftRookPosition);

                        board.AddFigure(new King(color), BlackLongCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(8, 'd'));

                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.RookOrKingHaveBeenMovedException);
                    }
                }
            }

            return false;
        }

        private void CheckForFiguresBetweenPositions(IBoard board, IFigure king, Position from, Position to)
        {
            ChessColor color = king.Color;

            if (color == ChessColor.White)
            {
                CheckIfFigures(board, from, to, WhiteArmyRow);
            }
            else if (color == ChessColor.Black)
            {
                CheckIfFigures(board, from, to, BlackArmyRow);
            }
        }

        private void CheckIfFigures(IBoard board, Position from, Position to, int row)
        {
            if (to.Col < from.Col)
            {
                for (int i = to.Col + 1; i < from.Col; i++)
                {
                    Position currentPosition = Position.FromChessCoordinates(row, (char)i);

                    if (board.GetFigureAtPosition(currentPosition) != null)
                    {
                        throw new InvalidOperationException(ExceptionMessages.FiguresBetweenRookAndKingException);
                    }
                }
            }
            else
            {
                for (int i = from.Col + 1; i < to.Col; i++)
                {
                    Position currentPosition = Position.FromChessCoordinates(row, (char)i);

                    if (board.GetFigureAtPosition(currentPosition) != null)
                    {
                        throw new InvalidOperationException(ExceptionMessages.FiguresBetweenRookAndKingException);
                    }
                }
            }
        }

        private void CheckIfKingCrossesAttackedField(IBoard board, Position from, Position to, ChessColor color)
        {
            if (to.Col < from.Col)
            {
                for (int i = to.Col; i <= from.Col; i++)
                {
                    Position currentPosition = Position.FromChessCoordinates(from.Row, (char)i);

                    if (MovedFigures.IsFieldAttacked(board, currentPosition, color))
                    {
                        throw new InvalidOperationException(ExceptionMessages.KingCannotCrossAttackedField);
                    }
                }
            }
            else
            {
                for (int i = from.Col + 1; i <= to.Col; i++)
                {
                    Position currentPosition = Position.FromChessCoordinates(from.Row, (char)i);

                    if (MovedFigures.IsFieldAttacked(board, currentPosition, color))
                    {
                        throw new InvalidOperationException(ExceptionMessages.KingCannotCrossAttackedField);
                    }
                }
            }
        }

        private void CheckIfKingIsInCheck(IBoard board, ChessColor color)
        {
            var position = board.GetFigurePostionByTypeAndColor("King", color);

            if (MovedFigures.IsFieldAttacked(board, position, color))
            {
                throw new InvalidOperationException(ExceptionMessages.CannotCastleIfKingIsInCheckException);
            }
        }
    }
}
