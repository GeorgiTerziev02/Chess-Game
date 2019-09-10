namespace Chess.SpecialFigureCases
{
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Players.Contracts;
    using System;
    using System.Collections.Generic;

    public class MovedFigures
    {
        private int[] whiteSideThirdRow;
        private int[] blackSideThirdRow;

        public static bool IsFieldAttacked(IBoard board, Position position, ChessColor currentPlayerColor)
        {
            int startingRow = position.Row;
            char startingCol = position.Col;
            var otherPlayerColor = GetOtherPlayerColor(currentPlayerColor);

            if (currentPlayerColor == ChessColor.White)
            {
                Position positionTopLeft = new Position(startingRow + 1, (char)(startingCol - 1));
                Position positionTopRight = new Position(startingRow + 1, (char)(startingCol + 1));

                var diagonalPossiblePawnPositions = new List<Position>()
                {
                    positionTopLeft,
                    positionTopRight
                };

                foreach (var possiblePosition in diagonalPossiblePawnPositions)
                {
                    if (CheckForPawn(board, possiblePosition, otherPlayerColor))
                    {
                        return true;
                    }
                }
            }

            if (currentPlayerColor == ChessColor.Black)
            {
                Position positionDownLeft = new Position(startingRow - 1, (char)(startingCol - 1));
                Position positionDownRight = new Position(startingRow - 1, (char)(startingCol + 1));

                var diagonalPossiblePawnPositions = new List<Position>()
                {
                    positionDownLeft,
                    positionDownRight
                };

                foreach (var possiblePosition in diagonalPossiblePawnPositions)
                {
                    if (CheckForPawn(board, possiblePosition, otherPlayerColor))
                    {
                        return true;
                    }
                }
            }

            List<Position> possibleKnightPositions = GetPossibleKnightPositions(startingRow, startingCol);

            foreach (var possibleKnightPosition in possibleKnightPositions)
            {
                if (Position.CheckIsValid(possibleKnightPosition))
                {
                    IFigure figureAtPosition = board.GetFigureAtPosition(possibleKnightPosition);

                    if (CheckFigure(figureAtPosition, "Knight", otherPlayerColor))
                    {
                        return true;
                    }
                }
            }

            int row = startingRow;
            char col = startingCol;

            while (true)
            {
                row++;
                col++;

                Position currentPosition = new Position(row, col);

                if (!Position.CheckIsValid(currentPosition))
                {
                    break;
                }

                IFigure figure = board.GetFigureAtPosition(currentPosition);

                if (figure != null && figure.Color == currentPlayerColor)
                {
                    break;
                }

                if (figure != null && figure.Color == otherPlayerColor)
                {
                    if (figure.GetType().Name == "Bishop" || figure.GetType().Name == "Queen")
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            row = startingRow;
            col = startingCol;
            while (true)
            {
                row++;
                col--;

                Position currentPosition = new Position(row, col);

                if (!Position.CheckIsValid(currentPosition))
                {
                    break;
                }

                IFigure figure = board.GetFigureAtPosition(currentPosition);

                if (figure != null && figure.Color == currentPlayerColor)
                {
                    break;
                }

                if (figure != null && figure.Color == otherPlayerColor)
                {
                    if (figure.GetType().Name == "Bishop" || figure.GetType().Name == "Queen")
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            row = startingRow;
            col = startingCol;
            while (true)
            {
                row--;
                col--;

                Position currentPosition = new Position(row, col);

                if (!Position.CheckIsValid(currentPosition))
                {
                    break;
                }

                IFigure figure = board.GetFigureAtPosition(currentPosition);

                if (figure != null && figure.Color == currentPlayerColor)
                {
                    break;
                }

                if (figure != null && figure.Color == otherPlayerColor)
                {
                    if (figure.GetType().Name == "Bishop" || figure.GetType().Name == "Queen")
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            row = startingRow;
            col = startingCol;
            while (true)
            {
                row--;
                col++;

                Position currentPosition = new Position(row, col);

                if (!Position.CheckIsValid(currentPosition))
                {
                    break;
                }

                IFigure figure = board.GetFigureAtPosition(currentPosition);

                if (figure != null && figure.Color == currentPlayerColor)
                {
                    break;
                }

                if (figure != null && figure.Color == otherPlayerColor)
                {
                    if (figure.GetType().Name == "Bishop" || figure.GetType().Name == "Queen")
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = startingRow + 1; i <= GlobalConstants.StandardGameTotalBoardRows; i++)
            {
                Position currentPosition = new Position(i, startingCol);

                if (!Position.CheckIsValid(currentPosition))
                {
                    break;
                }

                IFigure figure = board.GetFigureAtPosition(currentPosition);

                if (figure != null && figure.Color == currentPlayerColor)
                {
                    break;
                }

                if (figure != null && figure.Color == otherPlayerColor)
                {
                    if (figure.GetType().Name == "Rook" || figure.GetType().Name == "Queen")
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = startingRow - 1; i >= GlobalConstants.MinimumRowValueOnBoard; i--)
            {
                Position currentPosition = new Position(i, startingCol);

                if (!Position.CheckIsValid(currentPosition))
                {
                    break;
                }

                IFigure figure = board.GetFigureAtPosition(currentPosition);

                if (figure != null && figure.Color == currentPlayerColor)
                {
                    break;
                }

                if (figure != null && figure.Color == otherPlayerColor)
                {
                    if (figure.GetType().Name == "Rook" || figure.GetType().Name == "Queen")
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = (int)(startingCol) + 1; i <= GlobalConstants.StandardGameTotalBoardCols + 'a'; i++)
            {
                Position currentPosition = new Position(startingRow, (char)i);

                if (!Position.CheckIsValid(currentPosition))
                {
                    break;
                }

                IFigure figure = board.GetFigureAtPosition(currentPosition);

                if (figure != null && figure.Color == currentPlayerColor)
                {
                    break;
                }

                if (figure != null && figure.Color == otherPlayerColor)
                {
                    if (figure.GetType().Name == "Rook" || figure.GetType().Name == "Queen")
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = startingCol - 1; i >= GlobalConstants.MinimumColumnValueOnBoard; i--)
            {
                Position currentPosition = new Position(startingRow, (char)i);

                if (!Position.CheckIsValid(currentPosition))
                {
                    break;
                }

                IFigure figure = board.GetFigureAtPosition(currentPosition);

                if (figure != null && figure.Color == currentPlayerColor)
                {
                    break;
                }

                if (figure != null && figure.Color == otherPlayerColor)
                {
                    if (figure.GetType().Name == "Rook" || figure.GetType().Name == "Queen")
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            List<Position> positionsAroundTheKing = GetPossibleKingPostions(startingRow, startingCol);

            foreach (var currentPosition in positionsAroundTheKing)
            {
                if (Position.CheckIsValid(currentPosition))
                {
                    IFigure currentFigure = board.GetFigureAtPosition(currentPosition);

                    if (CheckFigure(currentFigure, "King", otherPlayerColor))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool CheckForPawn(IBoard board, Position possiblePosition, ChessColor otherColor)
        {
            if (Position.CheckIsValid(possiblePosition))
            {
                IFigure figureAtPosition = board.GetFigureAtPosition(possiblePosition);
                if (CheckFigure(figureAtPosition, "Pawn", otherColor))
                {
                    return true;
                }
            }

            return false;
        }

        public static int GetAvailableMoves(IBoard board, IPlayer player)
        {
            List<Position> playerFigures = board.GetAllFiguresPostionsByColor(player.Color);
            int availableMoves = 0;

            foreach (var position in playerFigures)
            {
                availableMoves += GetFigureAvailableMoves(board, position);
            }

            return availableMoves;
        }

        private static int GetFigureAvailableMoves(IBoard board, Position figurePosition)
        {
            int available = 0;
            var figure = board.GetFigureAtPosition(figurePosition);

            int startingRow = figurePosition.Row;
            char startingCol = figurePosition.Col;

            if (figure.GetType().Name == "King")
            {
                List<Position> positionsAroundTheKing = GetPossibleKingPostions(startingRow, startingCol);

                foreach (var position in positionsAroundTheKing)
                {
                    if (Position.CheckIsValid(position))
                    {
                        IFigure figureAtCurrentPosition = board.GetFigureAtPosition(position);

                        if ((figureAtCurrentPosition == null || figureAtCurrentPosition.Color != figure.Color) && IsFieldAttacked(board, position, figure.Color) == false)
                        {
                            available++;
                        }
                    }
                }

            }
            if (figure.GetType().Name == "Queen" || figure.GetType().Name == "Bishop")
            {
                int row = startingRow;
                char col = startingCol;

                while (true)
                {
                    row++;
                    col++;

                    Position currentPosition = new Position(row, col);

                    if (!Position.CheckIsValid(currentPosition))
                    {
                        break;
                    }

                    IFigure currentFigure = board.GetFigureAtPosition(currentPosition);

                    if (currentFigure != null && currentFigure.Color == figure.Color)
                    {
                        break;
                    }

                    if (currentFigure == null)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, null);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, currentFigure);
                        break;
                    }
                }

                row = startingRow;
                col = startingCol;
                while (true)
                {
                    row++;
                    col--;

                    Position currentPosition = new Position(row, col);

                    if (!Position.CheckIsValid(currentPosition))
                    {
                        break;
                    }

                    IFigure currentFigure = board.GetFigureAtPosition(currentPosition);

                    if (currentFigure != null && currentFigure.Color == figure.Color)
                    {
                        break;
                    }

                    if (currentFigure == null)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, null);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, currentFigure);
                        break;
                    }
                }

                row = startingRow;
                col = startingCol;
                while (true)
                {
                    row--;
                    col--;

                    Position currentPosition = new Position(row, col);

                    if (!Position.CheckIsValid(currentPosition))
                    {
                        break;
                    }

                    IFigure currentFigure = board.GetFigureAtPosition(currentPosition);

                    if (currentFigure != null && currentFigure.Color == figure.Color)
                    {
                        break;
                    }

                    if (currentFigure == null)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, null);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, currentFigure);
                        break;
                    }
                }

                row = startingRow;
                col = startingCol;
                while (true)
                {
                    row--;
                    col++;

                    Position currentPosition = new Position(row, col);

                    if (!Position.CheckIsValid(currentPosition))
                    {
                        break;
                    }

                    IFigure currentFigure = board.GetFigureAtPosition(currentPosition);

                    if (currentFigure != null && currentFigure.Color == figure.Color)
                    {
                        break;
                    }

                    if (currentFigure == null)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, null);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, currentFigure);
                        break;
                    }
                }
            }
            if (figure.GetType().Name == "Queen" || figure.GetType().Name == "Rook")
            {
                for (int i = startingRow + 1; i <= GlobalConstants.StandardGameTotalBoardRows; i++)
                {
                    Position currentPosition = new Position(i, startingCol);

                    if (!Position.CheckIsValid(currentPosition))
                    {
                        break;
                    }

                    IFigure currentFigure = board.GetFigureAtPosition(currentPosition);

                    if (currentFigure != null && currentFigure.Color == figure.Color)
                    {
                        break;
                    }

                    if (currentFigure == null)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, null);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, currentFigure);
                        break;
                    }
                }

                for (int i = startingRow - 1; i >= GlobalConstants.MinimumRowValueOnBoard; i--)
                {
                    Position currentPosition = new Position(i, startingCol);

                    if (!Position.CheckIsValid(currentPosition))
                    {
                        break;
                    }

                    IFigure currentFigure = board.GetFigureAtPosition(currentPosition);

                    if (currentFigure != null && currentFigure.Color == figure.Color)
                    {
                        break;
                    }

                    if (currentFigure == null)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, null);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, currentFigure);
                        break;
                    }
                }

                for (int i = (int)(startingCol) + 1; i <= GlobalConstants.StandardGameTotalBoardCols + 'a'; i++)
                {
                    Position currentPosition = new Position(startingRow, (char)i);

                    if (!Position.CheckIsValid(currentPosition))
                    {
                        break;
                    }

                    IFigure currentFigure = board.GetFigureAtPosition(currentPosition);

                    if (currentFigure != null && currentFigure.Color == figure.Color)
                    {
                        break;
                    }

                    if (currentFigure == null)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, null);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, currentFigure);
                        break;
                    }
                }

                for (int i = startingCol - 1; i >= GlobalConstants.MinimumColumnValueOnBoard; i--)
                {
                    Position currentPosition = new Position(startingRow, (char)i);

                    if (!Position.CheckIsValid(currentPosition))
                    {
                        break;
                    }

                    IFigure currentFigure = board.GetFigureAtPosition(currentPosition);

                    if (currentFigure != null && currentFigure.Color == figure.Color)
                    {
                        break;
                    }

                    if (currentFigure == null)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, null);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
                    {
                        available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentPosition, currentFigure);
                        break;
                    }
                }
            }
            if (figure.GetType().Name == "Knight")
            {
                List<Position> possibleKnightPositions = GetPossibleKnightPositions(startingRow, startingCol);

                foreach (var currentKnightPosition in possibleKnightPositions)
                {
                    if (Position.CheckIsValid(currentKnightPosition))
                    {
                        IFigure figureAtPosition = board.GetFigureAtPosition(currentKnightPosition);

                        if (figureAtPosition == null)
                        {
                            CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentKnightPosition, null);
                        }

                        if (figureAtPosition != null && figure.Color != figureAtPosition.Color)
                        {
                            CheckIfMoveIsAvailable(board, available, figurePosition, figure, currentKnightPosition, figureAtPosition);
                        }
                    }
                }
            }
            if (figure.GetType().Name == "Pawn")
            {
                if (figure.Color == ChessColor.White)
                {
                    Position positionTopLeft = new Position(startingRow + 1, (char)(startingCol - 1));
                    Position positionTopRight = new Position(startingRow + 1, (char)(startingCol + 1));
                    Position positionTop = new Position(startingRow + 1, (char)(startingCol));
                    Position positionTwoTop = new Position(startingRow + 2, (char)(startingCol));

                    var diagonalMoves = new List<Position>()
                    {
                        positionTopLeft,
                        positionTopRight
                    };

                    foreach (var move in diagonalMoves)
                    {
                        available = CheckDiagonalMove(board, figurePosition, available, figure, move);
                    }

                    if (Position.CheckIsValid(positionTop))
                    {
                        IFigure figureTop = board.GetFigureAtPosition(positionTop);

                        if (figureTop == null)
                        {
                            available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, positionTop, null);
                        }
                    }

                    if (Position.CheckIsValid(positionTwoTop))
                    {
                        IFigure figureTop = board.GetFigureAtPosition(positionTwoTop);
                        IFigure figureTwoTop = board.GetFigureAtPosition(positionTwoTop);

                        if (figureTwoTop == null && figureTop == null)
                        {
                            available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, positionTwoTop, null);
                        }
                    }
                }

                if (figure.Color == ChessColor.Black)
                {
                    Position positionDownLeft = new Position(startingRow - 1, (char)(startingCol - 1));
                    Position positionDownRight = new Position(startingRow - 1, (char)(startingCol + 1));
                    Position positionDown = new Position(startingRow - 1, (char)(startingCol));
                    Position positionTwoDown = new Position(startingRow - 2, (char)(startingCol));

                    var diagonalMoves = new List<Position>()
                    {
                        positionDownLeft,
                        positionDownRight
                    };

                    foreach (var move in diagonalMoves)
                    {
                        available = CheckDiagonalMove(board, figurePosition, available, figure, move);
                    }

                    if (Position.CheckIsValid(positionDown))
                    {
                        IFigure figureDown = board.GetFigureAtPosition(positionDown);

                        if (figureDown == null)
                        {
                            available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, positionDown, null);
                        }
                    }

                    if (Position.CheckIsValid(positionTwoDown))
                    {
                        IFigure figureTwoDown = board.GetFigureAtPosition(positionTwoDown);
                        IFigure figureDown = board.GetFigureAtPosition(positionDown);

                        if (figureTwoDown == null && figureDown == null)
                        {
                            available = CheckIfMoveIsAvailable(board, available, figurePosition, figure, positionTwoDown, null);
                        }
                    }
                }
            }

            return available;
        }

        private static int CheckIfMoveIsAvailable(IBoard board, int available, Position figurePosition, IFigure figure, Position currentPosition, IFigure currentFigure)
        {
            board.AddFigure(null, figurePosition);
            board.AddFigure(figure, currentPosition);

            var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

            if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
            {
                available++;
            }

            board.AddFigure(figure, figurePosition);
            board.AddFigure(currentFigure, currentPosition);

            return available;
        }

        private static int CheckDiagonalMove(IBoard board, Position figurePosition, int available, IFigure figure, Position position)
        {
            if (Position.CheckIsValid(position))
            {
                IFigure figureAtPosition = board.GetFigureAtPosition(position);

                if (figureAtPosition != null)
                {
                    board.AddFigure(figure, position);
                    board.AddFigure(null, figurePosition);

                    var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                    if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                    {
                        available++;
                    }

                    board.AddFigure(figureAtPosition, position);
                    board.AddFigure(figure, figurePosition);
                }
            }

            return available;
        }

        private static List<Position> GetPossibleKingPostions(int startingRow, char startingCol)
        {
            Position posTopLeft = new Position(startingRow + 1, (char)(startingCol - 1));
            Position posTopRight = new Position(startingRow + 1, (char)(startingCol + 1));
            Position positionLeft = new Position(startingRow, (char)(startingCol - 1));
            Position positionRight = new Position(startingRow, (char)(startingCol + 1));
            Position posDownLeft = new Position(startingRow - 1, (char)(startingCol - 1));
            Position posDownRight = new Position(startingRow - 1, (char)(startingCol + 1));
            Position positionTop = new Position(startingRow + 1, (char)(startingCol));
            Position positionDown = new Position(startingRow - 1, (char)(startingCol));

            List<Position> positionsAroundTheKing = new List<Position>()
                {
                    posTopLeft,
                    posTopRight,
                    positionLeft,
                    positionRight,
                    posDownLeft,
                    posDownRight,
                    positionTop,
                    positionDown
                };

            return positionsAroundTheKing;
        }

        private static List<Position> GetPossibleKnightPositions(int startingRow, char startingCol)
        {
            Position positionKnightTopLeft = new Position(startingRow + 2, (char)(startingCol - 1));
            Position positionKnightTopRight = new Position(startingRow + 2, (char)(startingCol + 1));
            Position positionKnightUpLeft = new Position(startingRow + 1, (char)(startingCol - 2));
            Position positionKnightUpRight = new Position(startingRow + 1, (char)(startingCol + 2));
            Position positionKnightDownLeft = new Position(startingRow - 2, (char)(startingCol - 1));
            Position positionKnightDownRight = new Position(startingRow - 2, (char)(startingCol + 1));
            Position positionKnightLeft = new Position(startingRow - 1, (char)(startingCol - 2));
            Position positionKnightRight = new Position(startingRow - 1, (char)(startingCol + 2));

            List<Position> possibleKnightPositions = new List<Position>()
                {
                    positionKnightTopLeft,
                    positionKnightTopRight,
                    positionKnightUpLeft,
                    positionKnightUpRight,
                    positionKnightDownLeft,
                    positionKnightDownRight,
                    positionKnightLeft,
                    positionKnightRight
                };

            return possibleKnightPositions;
        }

        public MovedFigures()
        {
            this.IsWhiteKingMoved = false;
            this.IsBlackKingMoved = false;
            this.IsBlackRightRookMoved = false;
            this.IsWhiteRightRookMoved = false;
            this.IsBlackLeftRookMoved = false;
            this.IsWhiteLeftRookMoved = false;

            whiteSideThirdRow = new int[8];
            blackSideThirdRow = new int[8];
        }

        public bool IsWhiteKingMoved { get; set; }

        public bool IsBlackKingMoved { get; set; }

        public bool IsBlackRightRookMoved { get; set; }

        public bool IsWhiteRightRookMoved { get; set; }

        public bool IsBlackLeftRookMoved { get; set; }

        public bool IsWhiteLeftRookMoved { get; set; }

        public void CheckMovedFigures(IBoard board)
        {
            IFigure whiteKingShouldbeAt = board.GetFigureAtPosition(GlobalConstants.StandardGameWhiteKingPosition);
            IFigure blackKingShouldbeAt = board.GetFigureAtPosition(GlobalConstants.StandardGameBlackKingPosition);
            IFigure whiteRightRookShouldbeAt = board.GetFigureAtPosition(GlobalConstants.StandardGameWhiteRightRookPosition);
            IFigure whiteLeftRookShouldbeAt = board.GetFigureAtPosition(GlobalConstants.StandardGameWhiteLeftRookPosition);
            IFigure blackRightRookShouldbeAt = board.GetFigureAtPosition(GlobalConstants.StandardGameBlackRightRookPosition);
            IFigure blackLeftRookShouldbeAt = board.GetFigureAtPosition(GlobalConstants.StandardGameBlackLeftRookPosition);

            if (whiteKingShouldbeAt == null || board.GetFigureAtPosition(GlobalConstants.StandardGameWhiteKingPosition).GetType().Name != "King")
            {
                IsWhiteKingMoved = true;
            }
            if (blackKingShouldbeAt == null || board.GetFigureAtPosition(GlobalConstants.StandardGameBlackKingPosition).GetType().Name != "King")
            {
                IsBlackKingMoved = true;
            }
            if (whiteRightRookShouldbeAt == null || board.GetFigureAtPosition(GlobalConstants.StandardGameWhiteRightRookPosition).GetType().Name != "Rook")
            {
                IsWhiteRightRookMoved = true;
            }
            if (whiteLeftRookShouldbeAt == null || board.GetFigureAtPosition(GlobalConstants.StandardGameWhiteLeftRookPosition).GetType().Name != "Rook")
            {
                IsWhiteLeftRookMoved = true;
            }
            if (blackLeftRookShouldbeAt == null || board.GetFigureAtPosition(GlobalConstants.StandardGameBlackLeftRookPosition).GetType().Name != "Rook")
            {
                IsBlackLeftRookMoved = true;
            }
            if (blackRightRookShouldbeAt == null || board.GetFigureAtPosition(GlobalConstants.StandardGameBlackRightRookPosition).GetType().Name != "Rook")
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

        public void CheckIfPawnHasMovedTwoSquares(IBoard board, IFigure pawn, Position from, Position to, int round)
        {
            int diff = Math.Abs(from.Row - to.Row);

            if (from.Col == to.Col && diff == 2)
            {
                if (pawn.Color == ChessColor.White)
                {
                    whiteSideThirdRow[(int)(from.Col - 'a')] = round;
                }
                else if (pawn.Color == ChessColor.Black)
                {
                    blackSideThirdRow[(int)(from.Col - 'a')] = round;
                }
            }
        }

        public void CheckEnPassant(IBoard board, IFigure pawn, Position from, Position to, int round)
        {
            Position enPassantPosition = new Position(from.Row, (char)(to.Col));
            IFigure otherPawn = board.GetFigureAtPosition(enPassantPosition);

            if (otherPawn != null && otherPawn.GetType().Name == "Pawn")
            {
                if (otherPawn.Color != pawn.Color)
                {
                    if (otherPawn.Color == ChessColor.White)
                    {
                        if (whiteSideThirdRow[to.Col - 'a'] == round - 1)
                        {
                            board.MoveFigureAtPosition(pawn, from, to);
                            board.RemoveFigure(enPassantPosition);
                        }
                        else
                        {
                            throw new InvalidOperationException(ExceptionMessages.InvalidEnPassantMovementException);
                        }
                    }
                    else if (otherPawn.Color == ChessColor.Black)
                    {
                        if (blackSideThirdRow[to.Col - 'a'] == round - 1)
                        {
                            board.MoveFigureAtPosition(pawn, from, to);
                            board.RemoveFigure(enPassantPosition);
                        }
                        else
                        {
                            throw new InvalidOperationException(ExceptionMessages.InvalidEnPassantMovementException);
                        }
                    }

                }
                else
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidPawnMovementSidewaysException);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEnPassantMovementException);
            }
        }

        private static bool CheckFigure(IFigure figure, string figureType, ChessColor color)
        {
            return figure != null && figure.GetType().Name == figureType && figure.Color == color;
        }

        private static ChessColor GetOtherPlayerColor(ChessColor color)
        {
            if (color == ChessColor.Black)
            {
                return ChessColor.White;
            }

            return ChessColor.Black;
        }
    }
}
