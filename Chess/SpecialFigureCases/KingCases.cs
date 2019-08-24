namespace Chess.SpecialFigureCases
{
    using System;
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures;
    using Chess.Figures.Contracts;

    public class KingCases
    {
        //TODO: constants
        private readonly static Position WhiteKingPosition = Position.FromChessCoordinates(1, 'e');
        private readonly static Position BlackKingPosition = Position.FromChessCoordinates(8, 'e');
        private readonly static Position WhiteRightRookPosition = Position.FromChessCoordinates(1, 'h');
        private readonly static Position WhiteLeftRookPosition = Position.FromChessCoordinates(1, 'a');
        private readonly static Position BlackRightRookPosition = Position.FromChessCoordinates(8, 'h');
        private readonly static Position BlackLeftRookPosition = Position.FromChessCoordinates(8, 'a');
        private readonly static Position WhiteShortCastlingPosition = Position.FromChessCoordinates(1, 'g');
        private readonly static Position WhiteLongCastlingPosition = Position.FromChessCoordinates(1, 'c');
        private readonly static Position BlackShortCastlingPosition = Position.FromChessCoordinates(8, 'g');
        private readonly static Position BlackLongCastlingPosition = Position.FromChessCoordinates(8, 'c');
        private readonly int WhiteArmyRow = 1;
        private readonly int BlackArmyRow = 8;

        //TODO: Create check if a square is attacked - to easy up the followings
        //TODO: Validate Full castling
        //TODO: Check if king crosses attacked fields
        //king not in check before castle
        public bool CheckCastling(IBoard board, IFigure figure, Position from, Position to)
        {
            var color = figure.Color;

            if (color == ChessColor.White)
            {
                if (to.Row == WhiteShortCastlingPosition.Row && to.Col == WhiteShortCastlingPosition.Col && from.Col == WhiteKingPosition.Col && from.Row == WhiteKingPosition.Row)
                {
                    if (!MoveFiguresInformation.isWhiteKingMoved && !MoveFiguresInformation.isWhiteRightRookMoved)
                    {
                        CheckForFiguresBetweenPositions(board, figure, from, to);
                        board.RemoveFigure(WhiteKingPosition);
                        board.RemoveFigure(WhiteRightRookPosition);

                        board.AddFigure(new King(color), WhiteShortCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(1, 'f'));
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.RookOrKingHaveBeenMovedException);
                    }
                }

                if (to.Row == WhiteLongCastlingPosition.Row && to.Col == WhiteLongCastlingPosition.Col && from.Col == WhiteKingPosition.Col && from.Row == WhiteKingPosition.Row)
                {
                    if (!MoveFiguresInformation.isWhiteKingMoved && !MoveFiguresInformation.isWhiteLeftRookMoved)
                    {
                        CheckForFiguresBetweenPositions(board, figure, from, to);
                        board.RemoveFigure(WhiteKingPosition);
                        board.RemoveFigure(WhiteLeftRookPosition);

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
                if (to.Row == BlackShortCastlingPosition.Row && to.Col == BlackShortCastlingPosition.Col && from.Col == BlackKingPosition.Col && from.Row == BlackKingPosition.Row)
                {
                    if (!MoveFiguresInformation.isBlackKingMoved && !MoveFiguresInformation.isBlackRightRookMoved && from.Col == BlackKingPosition.Col && from.Row == BlackKingPosition.Row)
                    {
                        CheckForFiguresBetweenPositions(board, figure, from, to);
                        board.RemoveFigure(BlackKingPosition);
                        board.RemoveFigure(BlackRightRookPosition);

                        board.AddFigure(new King(color), BlackShortCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(8, 'f'));
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.RookOrKingHaveBeenMovedException);
                    }
                }


                if (to.Row == BlackLongCastlingPosition.Row && to.Col == BlackLongCastlingPosition.Col && from.Col == BlackKingPosition.Col && from.Row == BlackKingPosition.Row)
                {
                    if (!MoveFiguresInformation.isBlackKingMoved && !MoveFiguresInformation.isBlackLeftRookMoved)
                    {
                        CheckForFiguresBetweenPositions(board, figure, from, to);

                        board.RemoveFigure(BlackKingPosition);
                        board.RemoveFigure(BlackLeftRookPosition);

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
    }
}
