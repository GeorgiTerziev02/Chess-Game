namespace Chess.SpecialFigureCases
{
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;

    public class MovedFigures
    {
        private bool isWhiteKingMoved;
        private bool isBlackKingMoved;
        private bool isBlackRightRookMoved;
        private bool isWhiteRightRookMoved;
        private bool isBlackLeftRookMoved;
        private bool isWhiteLeftRookMoved;

        //TODO: constants
        private readonly static Position WhiteKingPosition = Position.FromChessCoordinates(1, 'e');
        private readonly static Position BlackKingPosition = Position.FromChessCoordinates(8, 'e');
        private readonly static Position WhiteRightRookPosition = Position.FromChessCoordinates(1, 'h');
        private readonly static Position WhiteLeftRookPosition = Position.FromChessCoordinates(1, 'a');
        private readonly static Position BlackRightRookPosition = Position.FromChessCoordinates(8, 'h');
        private readonly static Position BlackLeftRookPosition = Position.FromChessCoordinates(8, 'a');


        public static bool IsFieldAttacked(IBoard board, Position position, ChessColor currentPlayerColor)
        {
            //check for pawns

            int startingRow = position.Row;
            char startingCol = position.Col;

            if (currentPlayerColor == ChessColor.White)
            {
                Position positionTopLeft = new Position(startingRow + 1, (char)(startingCol - 1));
                Position positionTopRight = new Position(startingRow + 1, (char)(startingCol + 1));

                if (Position.CheckIsValid(positionTopLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionTopLeft);
                    if (CheckFigure(figureTopLeft, "Pawn", ChessColor.Black))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionTopRight))
                {
                    IFigure figureTopRight = board.GetFigureAtPosition(positionTopRight);

                    if (CheckFigure(figureTopRight, "Pawn", ChessColor.Black))
                    {
                        return true;
                    }
                }
            }

            if (currentPlayerColor == ChessColor.Black)
            {
                Position positionDownLeft = new Position(startingRow - 1, (char)(startingCol - 1));
                Position positionDownRight = new Position(startingRow - 1, (char)(startingCol + 1));

                if (Position.CheckIsValid(positionDownLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionDownLeft);

                    if (CheckFigure(figureTopLeft, "Pawn", ChessColor.White))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionDownRight))
                {
                    IFigure figureTopRight = board.GetFigureAtPosition(positionDownRight);

                    if (CheckFigure(figureTopRight, "Pawn", ChessColor.White))
                    {
                        return true;
                    }
                }
            }
            //check for knight
            if (currentPlayerColor == ChessColor.White)
            {
                Position positionKnightTopLeft = new Position(startingRow + 2, (char)(startingCol - 1));
                Position positionKnightTopRight = new Position(startingRow + 2, (char)(startingCol + 1));
                Position positionKnightUpLeft = new Position(startingRow + 1, (char)(startingCol - 2));
                Position positionKnightUpRight = new Position(startingRow + 1, (char)(startingCol + 2));
                Position positionKnightDownLeft = new Position(startingRow - 2, (char)(startingCol - 1));
                Position positionKnightDownRight = new Position(startingRow - 2, (char)(startingCol + 1));
                Position positionKnightLeft = new Position(startingRow - 1, (char)(startingCol - 2));
                Position positionKnightRight = new Position(startingRow - 1, (char)(startingCol + 2));

                if (Position.CheckIsValid(positionKnightTopLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightTopLeft);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.Black))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightTopRight))
                {
                    IFigure figureTopRight = board.GetFigureAtPosition(positionKnightTopRight);

                    if (CheckFigure(figureTopRight, "Knight", ChessColor.Black))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightUpRight))
                {
                    IFigure figureTopRight = board.GetFigureAtPosition(positionKnightUpRight);

                    if (CheckFigure(figureTopRight, "Knight", ChessColor.Black))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightUpLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightUpLeft);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.Black))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightDownLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightDownLeft);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.Black))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightDownRight))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightDownRight);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.Black))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightLeft);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.Black))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightRight))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightRight);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.Black))
                    {
                        return true;
                    }
                }
            }

            if (currentPlayerColor == ChessColor.Black)
            {
                Position positionKnightTopLeft = new Position(startingRow + 2, (char)(startingCol - 1));
                Position positionKnightTopRight = new Position(startingRow + 2, (char)(startingCol + 1));
                Position positionKnightUpLeft = new Position(startingRow + 1, (char)(startingCol - 2));
                Position positionKnightUpRight = new Position(startingRow + 1, (char)(startingCol + 2));
                Position positionKnightDownLeft = new Position(startingRow - 2, (char)(startingCol - 1));
                Position positionKnightDownRight = new Position(startingRow - 2, (char)(startingCol + 1));
                Position positionKnightLeft = new Position(startingRow - 1, (char)(startingCol - 2));
                Position positionKnightRight = new Position(startingRow - 1, (char)(startingCol + 2));

                if (Position.CheckIsValid(positionKnightTopLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightTopLeft);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.White))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightTopRight))
                {
                    IFigure figureTopRight = board.GetFigureAtPosition(positionKnightTopRight);

                    if (CheckFigure(figureTopRight, "Knight", ChessColor.White))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightUpRight))
                {
                    IFigure figureTopRight = board.GetFigureAtPosition(positionKnightUpRight);

                    if (CheckFigure(figureTopRight, "Knight", ChessColor.White))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightUpLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightUpLeft);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.White))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightDownLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightDownLeft);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.White))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightDownRight))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightDownRight);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.White))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightLeft);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.White))
                    {
                        return true;
                    }
                }

                if (Position.CheckIsValid(positionKnightRight))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightRight);

                    if (CheckFigure(figureTopLeft, "Knight", ChessColor.White))
                    {
                        return true;
                    }
                }
            }
            //for queen - included in rook And Bishop?
            //TODO: check for bishop
            //TODO: check for rook
            //check for king?

            return false;
        }

        public MovedFigures()
        {
            this.IsWhiteKingMoved = false;
            this.IsBlackKingMoved = false;
            this.IsBlackRightRookMoved = false;
            this.IsWhiteRightRookMoved = false;
            this.IsBlackLeftRookMoved = false;
            this.IsWhiteLeftRookMoved = false;
        }

        public bool IsWhiteKingMoved { get => isWhiteKingMoved; set => isWhiteKingMoved = value; }

        public bool IsBlackKingMoved { get => isBlackKingMoved; set => isBlackKingMoved = value; }

        public bool IsBlackRightRookMoved { get => isBlackRightRookMoved; set => isBlackRightRookMoved = value; }

        public bool IsWhiteRightRookMoved { get => isWhiteRightRookMoved; set => isWhiteRightRookMoved = value; }

        public bool IsBlackLeftRookMoved { get => isBlackLeftRookMoved; set => isBlackLeftRookMoved = value; }

        public bool IsWhiteLeftRookMoved { get => isWhiteLeftRookMoved; set => isWhiteLeftRookMoved = value; }


        public void CheckMovedFigures(IBoard board)
        {
            IFigure whiteKingShouldbeAt = board.GetFigureAtPosition(WhiteKingPosition);
            IFigure blackKingShouldbeAt = board.GetFigureAtPosition(BlackKingPosition);
            IFigure whiteRightRookShouldbeAt = board.GetFigureAtPosition(WhiteRightRookPosition);
            IFigure whiteLeftRookShouldbeAt = board.GetFigureAtPosition(WhiteLeftRookPosition);
            IFigure blackRightRookShouldbeAt = board.GetFigureAtPosition(BlackRightRookPosition);
            IFigure blackLeftRookShouldbeAt = board.GetFigureAtPosition(BlackLeftRookPosition);

            if (whiteKingShouldbeAt == null || board.GetFigureAtPosition(WhiteKingPosition).GetType().Name != "King")
            {
                IsWhiteKingMoved = true;
            }
            if (blackKingShouldbeAt == null || board.GetFigureAtPosition(BlackKingPosition).GetType().Name != "King")
            {
                IsBlackKingMoved = true;
            }
            if (whiteRightRookShouldbeAt == null || board.GetFigureAtPosition(WhiteRightRookPosition).GetType().Name != "Rook")
            {
                IsWhiteRightRookMoved = true;
            }
            if (whiteLeftRookShouldbeAt == null || board.GetFigureAtPosition(WhiteLeftRookPosition).GetType().Name != "Rook")
            {
                IsWhiteLeftRookMoved = true;
            }
            if (blackLeftRookShouldbeAt == null || board.GetFigureAtPosition(BlackLeftRookPosition).GetType().Name != "Rook")
            {
                IsBlackLeftRookMoved = true;
            }
            if (blackRightRookShouldbeAt == null || board.GetFigureAtPosition(BlackRightRookPosition).GetType().Name != "Rook")
            {
                IsBlackRightRookMoved = true;
            }

            MoveFiguresInformation.isBlackKingMoved = this.IsBlackKingMoved;
            MoveFiguresInformation.isWhiteKingMoved = this.IsWhiteKingMoved;
            MoveFiguresInformation.isWhiteRightRookMoved = this.IsWhiteRightRookMoved;
            MoveFiguresInformation.isWhiteLeftRookMoved = this.IsWhiteLeftRookMoved;
            MoveFiguresInformation.isBlackRightRookMoved = this.IsBlackRightRookMoved;
            MoveFiguresInformation.isBlackLeftRookMoved = this.IsBlackLeftRookMoved;
        }

        private static bool CheckFigure(IFigure figure, string figureType, ChessColor color)
        {
            return figure != null && figure.GetType().Name == figureType && figure.Color == color;
        }
    }
}
