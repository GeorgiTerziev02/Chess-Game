namespace Chess.SpecialFigureCases
{
    using System;
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures;
    using Chess.Figures.Contracts;

    public static class KingCases
    {
        private static bool IsWhiteKingMoved = false;
        private static bool IsBlackKingMoved = false;
        private static bool IsBlackRightRookMoved = false;
        private static bool IsWhiteRightRookMoved = false;
        private static bool IsBlackLeftRookMoved = false;
        private static bool IsWhiteLeftRookMoved = false;

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
        public static bool CheckCastling(IBoard board, IFigure figure, Position to)
        {
            CheckMovedFigures(board);
            var color = figure.Color;

            if (color == ChessColor.White)
            {
                if (to.Row == WhiteShortCastlingPosition.Row && to.Col == WhiteShortCastlingPosition.Col)
                {
                    if (!IsWhiteKingMoved && !IsWhiteRightRookMoved)
                    {
                        board.RemoveFigure(WhiteKingPosition);
                        board.RemoveFigure(WhiteRightRookPosition);

                        board.AddFigure(new King(color), WhiteShortCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(1, 'f'));
                        return true;
                    }
                }
                if (to.Row == WhiteLongCastlingPosition.Row && to.Col == WhiteLongCastlingPosition.Col)
                {
                    if (!IsWhiteKingMoved && !IsWhiteLeftRookMoved)
                    {
                        board.RemoveFigure(WhiteKingPosition);
                        board.RemoveFigure(WhiteLeftRookPosition);

                        board.AddFigure(new King(color), WhiteLongCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(1, 'd'));
                        return true;
                    }
                }
            }

            if (color == ChessColor.Black)
            {
                if (to.Row == BlackShortCastlingPosition.Row && to.Col == BlackShortCastlingPosition.Col)
                {
                    if (!IsBlackKingMoved && !IsBlackRightRookMoved)
                    {
                        board.RemoveFigure(BlackKingPosition);
                        board.RemoveFigure(BlackRightRookPosition);

                        board.AddFigure(new King(color), BlackShortCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(8, 'f'));
                        return true;
                    }
                }


                if (to.Row == BlackLongCastlingPosition.Row && to.Col == BlackLongCastlingPosition.Col)
                {
                    if (!IsBlackKingMoved && !IsBlackLeftRookMoved)
                    {
                        board.RemoveFigure(BlackKingPosition);
                        board.RemoveFigure(BlackLeftRookPosition);

                        board.AddFigure(new King(color), BlackLongCastlingPosition);
                        board.AddFigure(new Rook(color), Position.FromChessCoordinates(8, 'd'));
                        return true;
                    }
                }
            }
     
            return false;
        }

    private static void CheckMovedFigures(IBoard board)
    {
        if (board.GetFigureAtPosition(WhiteKingPosition).GetType().Name != "King")
        {
            IsWhiteKingMoved = true;
        }
        if (board.GetFigureAtPosition(BlackKingPosition).GetType().Name != "King")
        {
            IsBlackKingMoved = true;
        }
        if (board.GetFigureAtPosition(WhiteRightRookPosition).GetType().Name != "Rook")
        {
            IsWhiteRightRookMoved = true;
        }
        if (board.GetFigureAtPosition(WhiteLeftRookPosition).GetType().Name != "Rook")
        {
            IsWhiteLeftRookMoved = true;
        }
        if (board.GetFigureAtPosition(BlackLeftRookPosition).GetType().Name != "Rook")
        {
            IsBlackLeftRookMoved = true;
        }
        if (board.GetFigureAtPosition(BlackRightRookPosition).GetType().Name != "Rook")
        {
            IsBlackRightRookMoved = true;
        }
    }
}
}
