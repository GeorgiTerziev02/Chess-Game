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
        private bool isWhiteKingMoved;
        private bool isBlackKingMoved;
        private bool isBlackRightRookMoved;
        private bool isWhiteRightRookMoved;
        private bool isBlackLeftRookMoved;
        private bool isWhiteLeftRookMoved;

        private readonly static Position WhiteKingPosition = Position.FromChessCoordinates(1, 'e');
        private readonly static Position BlackKingPosition = Position.FromChessCoordinates(8, 'e');
        private readonly static Position WhiteRightRookPosition = Position.FromChessCoordinates(1, 'h');
        private readonly static Position WhiteLeftRookPosition = Position.FromChessCoordinates(1, 'a');
        private readonly static Position BlackRightRookPosition = Position.FromChessCoordinates(8, 'h');
        private readonly static Position BlackLeftRookPosition = Position.FromChessCoordinates(8, 'a');


        //keeping the round
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

            for (int i = startingCol - 1; i >= 'a'; i--)
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

            //check for king
            Position posTopLeft = new Position(startingRow + 1, (char)(startingCol - 1));
            Position posTopRight = new Position(startingRow + 1, (char)(startingCol + 1));
            Position positionLeft = new Position(startingRow, (char)(startingCol - 1));
            Position positionRight = new Position(startingRow, (char)(startingCol + 1));
            Position posDownLeft = new Position(startingRow - 1, (char)(startingCol - 1));
            Position posDownRight = new Position(startingRow - 1, (char)(startingCol + 1));
            Position positionTop = new Position(startingRow + 1, (char)(startingCol));
            Position positionDown = new Position(startingRow - 1, (char)(startingCol));

            if (Position.CheckIsValid(posTopLeft))
            {
                IFigure figureTopLeft = board.GetFigureAtPosition(posTopLeft);

                if (CheckFigure(figureTopLeft, "King", otherPlayerColor))
                {
                    return true;
                }
            }

            if (Position.CheckIsValid(posTopRight))
            {
                IFigure figureTopRight = board.GetFigureAtPosition(posTopRight);

                if (CheckFigure(figureTopRight, "King", otherPlayerColor))
                {
                    return true;
                }
            }

            if (Position.CheckIsValid(positionLeft))
            {
                IFigure figureTopRight = board.GetFigureAtPosition(positionLeft);

                if (CheckFigure(figureTopRight, "King", otherPlayerColor))
                {
                    return true;
                }
            }

            if (Position.CheckIsValid(positionRight))
            {
                IFigure figureTopRight = board.GetFigureAtPosition(positionRight);

                if (CheckFigure(figureTopRight, "King", otherPlayerColor))
                {
                    return true;
                }
            }

            if (Position.CheckIsValid(posDownLeft))
            {
                IFigure figureTopRight = board.GetFigureAtPosition(posDownLeft);

                if (CheckFigure(figureTopRight, "King", otherPlayerColor))
                {
                    return true;
                }
            }

            if (Position.CheckIsValid(posDownRight))
            {
                IFigure figureTopRight = board.GetFigureAtPosition(posDownRight);

                if (CheckFigure(figureTopRight, "King", otherPlayerColor))
                {
                    return true;
                }
            }

            if (Position.CheckIsValid(positionTop))
            {
                IFigure figureTopRight = board.GetFigureAtPosition(positionTop);

                if (CheckFigure(figureTopRight, "King", otherPlayerColor))
                {
                    return true;
                }
            }

            if (Position.CheckIsValid(positionDown))
            {
                IFigure figureTopRight = board.GetFigureAtPosition(positionDown);

                if (CheckFigure(figureTopRight, "King", otherPlayerColor))
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

        //TODO: refactor
        private static int GetFigureAvailableMoves(IBoard board, Position figurePosition)
        {
            int available = 0;
            var figure = board.GetFigureAtPosition(figurePosition);

            int startingRow = figurePosition.Row;
            char startingCol = figurePosition.Col;

            if (figure.GetType().Name == "King")
            {
                Position posTopLeft = new Position(startingRow + 1, (char)(startingCol - 1));
                Position posTopRight = new Position(startingRow + 1, (char)(startingCol + 1));
                Position positionLeft = new Position(startingRow, (char)(startingCol - 1));
                Position positionRight = new Position(startingRow, (char)(startingCol + 1));
                Position posDownLeft = new Position(startingRow - 1, (char)(startingCol - 1));
                Position posDownRight = new Position(startingRow - 1, (char)(startingCol + 1));
                Position positionTop = new Position(startingRow + 1, (char)(startingCol));
                Position positionDown = new Position(startingRow - 1, (char)(startingCol));

                if (Position.CheckIsValid(posTopLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(posTopLeft);

                    if ((figureTopLeft == null || figureTopLeft.Color != figure.Color) && IsFieldAttacked(board, posTopLeft, figure.Color) == false)
                    {
                        available++;
                    }
                }

                if (Position.CheckIsValid(posTopRight))
                {
                    IFigure figureTopRight = board.GetFigureAtPosition(posTopRight);

                    if ((figureTopRight == null || figureTopRight.Color != figure.Color) && IsFieldAttacked(board, posTopRight, figure.Color) == false)
                    {
                        available++;
                    }
                }

                if (Position.CheckIsValid(positionLeft))
                {
                    IFigure figureLeft = board.GetFigureAtPosition(positionLeft);

                    if ((figureLeft == null || figureLeft.Color != figure.Color) && IsFieldAttacked(board, positionLeft, figure.Color) == false)
                    {
                        available++;
                    }
                }

                if (Position.CheckIsValid(positionRight))
                {
                    IFigure figureRight = board.GetFigureAtPosition(positionRight);

                    if ((figureRight == null || figureRight.Color != figure.Color) && IsFieldAttacked(board, positionRight, figure.Color) == false)
                    {
                        available++;
                    }
                }

                if (Position.CheckIsValid(posDownLeft))
                {
                    IFigure figureDownLeft = board.GetFigureAtPosition(posDownLeft);

                    if ((figureDownLeft == null || figureDownLeft.Color != figure.Color) && IsFieldAttacked(board, posDownLeft, figure.Color) == false)
                    {
                        available++;
                    }
                }

                if (Position.CheckIsValid(posDownRight))
                {
                    IFigure figureDownRight = board.GetFigureAtPosition(posDownRight);

                    if ((figureDownRight == null || figureDownRight.Color != figure.Color) && IsFieldAttacked(board, posDownRight, figure.Color) == false)
                    {
                        available++;
                    }
                }

                if (Position.CheckIsValid(positionTop))
                {
                    IFigure figureTop = board.GetFigureAtPosition(positionTop);

                    if ((figureTop == null || figureTop.Color != figure.Color) && IsFieldAttacked(board, positionTop, figure.Color) == false)
                    {
                        available++;
                    }
                }

                if (Position.CheckIsValid(positionDown))
                {
                    IFigure figureDown = board.GetFigureAtPosition(positionDown);

                    if ((figureDown == null || figureDown.Color != figure.Color) && IsFieldAttacked(board, positionDown, figure.Color) == false)
                    {
                        available++;
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
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, currentPosition);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, currentPosition);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
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
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, currentPosition);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, currentPosition);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
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
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, currentPosition);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, currentPosition);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
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
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, currentPosition);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, currentPosition);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
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
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, currentPosition);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, currentPosition);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
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
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, currentPosition);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, currentPosition);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
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
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, currentPosition);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, currentPosition);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
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
                        break;
                    }
                }

                for (int i = startingCol - 1; i >= 'a'; i--)
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
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, currentPosition);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, currentPosition);
                    }

                    if (currentFigure != null && figure.Color != currentFigure.Color)
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
                        break;
                    }
                }
            }
            if (figure.GetType().Name == "Knight")
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

                    if (figureTopLeft == null)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightTopLeft);
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, positionKnightTopLeft);
                    }

                    if (figureTopLeft != null && figure.Color != figureTopLeft.Color)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightTopLeft);

                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(figureTopLeft, positionKnightTopLeft);
                    }
                }

                if (Position.CheckIsValid(positionKnightTopRight))
                {
                    IFigure figureTopRight = board.GetFigureAtPosition(positionKnightTopRight);

                    if (figureTopRight == null)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightTopRight);
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, positionKnightTopRight);
                    }

                    if (figureTopRight != null && figure.Color != figureTopRight.Color)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightTopRight);

                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(figureTopRight, positionKnightTopRight);
                    }
                }

                if (Position.CheckIsValid(positionKnightUpRight))
                {
                    IFigure figureTopRight = board.GetFigureAtPosition(positionKnightUpRight);

                    if (figureTopRight == null)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightUpRight);
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, positionKnightUpRight);
                    }

                    if (figureTopRight != null && figure.Color != figureTopRight.Color)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightUpRight);

                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(figureTopRight, positionKnightUpRight);
                    }
                }

                if (Position.CheckIsValid(positionKnightUpLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightUpLeft);

                    if (figureTopLeft == null)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightUpLeft);
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, positionKnightUpLeft);
                    }

                    if (figureTopLeft != null && figure.Color != figureTopLeft.Color)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightUpLeft);

                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(figureTopLeft, positionKnightUpLeft);
                    }
                }

                if (Position.CheckIsValid(positionKnightDownLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightDownLeft);

                    if (figureTopLeft == null)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightDownLeft);
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, positionKnightDownLeft);
                    }

                    if (figureTopLeft != null && figure.Color != figureTopLeft.Color)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightDownLeft);

                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(figureTopLeft, positionKnightDownLeft);
                    }
                }

                if (Position.CheckIsValid(positionKnightDownRight))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightDownRight);

                    if (figureTopLeft == null)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightDownRight);
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, positionKnightDownRight);
                    }

                    if (figureTopLeft != null && figure.Color != figureTopLeft.Color)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightDownRight);

                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(figureTopLeft, positionKnightDownRight);
                    }
                }

                if (Position.CheckIsValid(positionKnightLeft))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightLeft);

                    if (figureTopLeft == null)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightLeft);
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, positionKnightLeft);
                    }

                    if (figureTopLeft != null && figure.Color != figureTopLeft.Color)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightLeft);

                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(figureTopLeft, positionKnightLeft);
                    }
                }

                if (Position.CheckIsValid(positionKnightRight))
                {
                    IFigure figureTopLeft = board.GetFigureAtPosition(positionKnightRight);

                    if (figureTopLeft == null)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightRight);
                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(null, positionKnightRight);
                    }

                    if (figureTopLeft != null && figure.Color != figureTopLeft.Color)
                    {
                        board.AddFigure(null, figurePosition);
                        board.AddFigure(figure, positionKnightRight);

                        var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                        if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                        {
                            available++;
                        }

                        board.AddFigure(figure, figurePosition);
                        board.AddFigure(figureTopLeft, positionKnightRight);
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

                    if (Position.CheckIsValid(positionTopLeft))
                    {
                        IFigure figureTopLeft = board.GetFigureAtPosition(positionTopLeft);

                        if (figureTopLeft != null)
                        {
                            board.AddFigure(figure, positionTopLeft);
                            board.AddFigure(null, figurePosition);

                            var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                            if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                            {
                                available++;
                            }

                            board.AddFigure(figureTopLeft, positionTopLeft);
                            board.AddFigure(figure, figurePosition);
                        }
                    }

                    if (Position.CheckIsValid(positionTopRight))
                    {
                        IFigure figureTopRight = board.GetFigureAtPosition(positionTopRight);

                        if (figureTopRight != null)
                        {
                            board.AddFigure(figure, positionTopRight);
                            board.AddFigure(null, figurePosition);

                            var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                            if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                            {
                                available++;
                            }

                            board.AddFigure(figureTopRight, positionTopRight);
                            board.AddFigure(figure, figurePosition);
                        }
                    }

                    if (Position.CheckIsValid(positionTop))
                    {
                        IFigure figureTop = board.GetFigureAtPosition(positionTop);

                        if (figureTop == null)
                        {
                            board.AddFigure(figure, positionTop);
                            board.AddFigure(null, figurePosition);

                            var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                            if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                            {
                                available++;
                            }

                            board.AddFigure(null, positionTop);
                            board.AddFigure(figure, figurePosition);
                        }
                    }

                    if (Position.CheckIsValid(positionTwoTop))
                    {
                        IFigure figureTop = board.GetFigureAtPosition(positionTwoTop);
                        IFigure figureTwoTop = board.GetFigureAtPosition(positionTwoTop);

                        if (figureTwoTop == null && figureTop ==null)
                        {
                            board.AddFigure(figure, positionTwoTop);
                            board.AddFigure(null, figurePosition);

                            var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                            if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                            {
                                available++;
                            }

                            board.AddFigure(null, positionTwoTop);
                            board.AddFigure(figure, figurePosition);
                        }
                    }
                }

                if (figure.Color == ChessColor.Black)
                {
                    Position positionDownLeft = new Position(startingRow - 1, (char)(startingCol - 1));
                    Position positionDownRight = new Position(startingRow - 1, (char)(startingCol + 1));
                    Position positionDown = new Position(startingRow - 1, (char)(startingCol));
                    Position positionTwoDown = new Position(startingRow - 2, (char)(startingCol));

                    if (Position.CheckIsValid(positionDownLeft))
                    {
                        IFigure figureDownLeft = board.GetFigureAtPosition(positionDownLeft);

                        if (figureDownLeft != null)
                        {
                            board.AddFigure(figure, positionDownLeft);
                            board.AddFigure(null, figurePosition);

                            var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                            if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                            {
                                available++;
                            }

                            board.AddFigure(figureDownLeft, positionDownLeft);
                            board.AddFigure(figure, figurePosition);
                        }
                    }

                    if (Position.CheckIsValid(positionDownRight))
                    {
                        IFigure figureDownRight = board.GetFigureAtPosition(positionDownRight);

                        if (figureDownRight != null)
                        {
                            board.AddFigure(figure, positionDownRight);
                            board.AddFigure(null, figurePosition);

                            var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                            if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                            {
                                available++;
                            }

                            board.AddFigure(figureDownRight, positionDownRight);
                            board.AddFigure(figure, figurePosition);
                        }
                    }

                    if (Position.CheckIsValid(positionDown))
                    {
                        IFigure figureDown = board.GetFigureAtPosition(positionDown);

                        if (figureDown == null)
                        {
                            board.AddFigure(figure, positionDown);
                            board.AddFigure(null, figurePosition);

                            var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                            if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                            {
                                available++;
                            }

                            board.AddFigure(null, positionDown);
                            board.AddFigure(figure, figurePosition);
                        }
                    }

                    if (Position.CheckIsValid(positionTwoDown))
                    {
                        IFigure figureTwoDown = board.GetFigureAtPosition(positionTwoDown);
                        IFigure figureDown = board.GetFigureAtPosition(positionDown);

                        if (figureTwoDown == null && figureDown == null)
                        {
                            board.AddFigure(figure, positionTwoDown);
                            board.AddFigure(null, figurePosition);

                            var kingPosition = board.GetFigurePostionByTypeAndColor("King", figure.Color);

                            if (IsFieldAttacked(board, kingPosition, figure.Color) == false)
                            {
                                available++;
                            }

                            board.AddFigure(null, positionTwoDown);
                            board.AddFigure(figure, figurePosition);
                        }
                    }
                }
            }

            return available;
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
            else
            {
                return ChessColor.Black;
            }
        }
    }
}
