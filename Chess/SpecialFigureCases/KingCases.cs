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


        //TODO: Validate Full castling
        //TODO: Check for figures between
        public bool CheckCastling(IBoard board, IFigure figure, Position to)
        {
            var color = figure.Color;

            if (color == ChessColor.White)
            {
                if (to.Row == WhiteShortCastlingPosition.Row && to.Col == WhiteShortCastlingPosition.Col)
                {
                    if (!MoveFiguresInformation.isWhiteKingMoved && !MoveFiguresInformation.isWhiteRightRookMoved)
                    {
                        board.RemoveFigure(WhiteKingPosition);
                        board.RemoveFigure(WhiteRightRookPosition);

                        board.AddFigure(new King(color), WhiteShortCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(1, 'f'));
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.KnightOrKingHaveBeenMovedException);
                    }
                }
                if (to.Row == WhiteLongCastlingPosition.Row && to.Col == WhiteLongCastlingPosition.Col)
                {
                    if (!MoveFiguresInformation.isWhiteKingMoved && !MoveFiguresInformation.isWhiteLeftRookMoved)
                    {
                        board.RemoveFigure(WhiteKingPosition);
                        board.RemoveFigure(WhiteLeftRookPosition);

                        board.AddFigure(new King(color), WhiteLongCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(1, 'd'));
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.KnightOrKingHaveBeenMovedException);
                    }
                }
            }

            if (color == ChessColor.Black)
            {
                if (to.Row == BlackShortCastlingPosition.Row && to.Col == BlackShortCastlingPosition.Col)
                {
                    if (!MoveFiguresInformation.isBlackKingMoved && !MoveFiguresInformation.isBlackRightRookMoved)
                    {
                        board.RemoveFigure(BlackKingPosition);
                        board.RemoveFigure(BlackRightRookPosition);

                        board.AddFigure(new King(color), BlackShortCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(8, 'f'));
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.KnightOrKingHaveBeenMovedException);
                    }
                }


                if (to.Row == BlackLongCastlingPosition.Row && to.Col == BlackLongCastlingPosition.Col)
                {
                    if (!MoveFiguresInformation.isBlackKingMoved && !MoveFiguresInformation.isBlackLeftRookMoved)
                    {
                        board.RemoveFigure(BlackKingPosition);
                        board.RemoveFigure(BlackLeftRookPosition);

                        board.AddFigure(new King(color), BlackLongCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(8, 'd'));
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.KnightOrKingHaveBeenMovedException);
                    }
                }
            }

            return false;
        }
    }
}
