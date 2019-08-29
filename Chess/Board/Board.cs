﻿namespace Chess.Board
{
    using System;
    using System.Collections.Generic;
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;

    public class Board : IBoard
    {
        private readonly IFigure[,] board;

        public Board(
            int rows = GlobalConstants.StandardGameTotalBoardRows,
            int cols = GlobalConstants.StandardGameTotalBoardCols)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;

            this.board = new IFigure[rows, cols];
        }

        public int TotalRows { get; private set; }

        public int TotalCols { get; private set; }

        public void AddFigure(IFigure figure, Position position)
        {
            //TODO: Remove comment and create new method if needed
            //ObjectValidator.CheckIfObjectIsNull(figure, ExceptionMessages.NullFigureException);

            this.CheckIfPositionIsValid(position);

            int arrayRow = GetArrayRow(position.Row);
            int arrayCol = GetArrayCol(position.Col);

            this.board[arrayRow, arrayCol] = figure;
        }

        public void RemoveFigure(Position position)
        {
            //Check for bugs later
            this.CheckIfPositionIsValid(position);

            int arrayRow = GetArrayRow(position.Row);
            int arrayCol = GetArrayCol(position.Col);

            this.board[arrayRow, arrayCol] = null;
        }

        public IFigure GetFigureAtPosition(Position position)
        {
            int arrayRow = GetArrayRow(position.Row);
            int arrayCol = GetArrayCol(position.Col);

            return this.board[arrayRow, arrayCol];
        }

        public void MoveFigureAtPosition(IFigure figure, Position from, Position to)
        {
            int arrayFromRow = GetArrayRow(from.Row);
            int arrayFromCol = GetArrayCol(from.Col);
            this.board[arrayFromRow, arrayFromCol] = null;

            int arrayToRow = GetArrayRow(to.Row);
            int arrayToCol = GetArrayCol(to.Col);
            this.board[arrayToRow, arrayToCol] = figure;
        }

        public Position GetFigurePostionByTypeAndColor(string type, ChessColor color)
        {
            int row = -1;
            int col = 0;

            for (int i = 0; i < GlobalConstants.StandardGameTotalBoardRows; i++)
            {
                for (int j = 0; j < GlobalConstants.StandardGameTotalBoardCols; j++)
                {
                    IFigure currentFigure = this.board[i, j];
                    if (currentFigure != null && currentFigure.GetType().Name == type && currentFigure.Color == color)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
            }

            //if (row == -1)
            //{
            //    return null;
            //}

            return Position.FromArrayCoordinates(row, col, GlobalConstants.MaximumRowValueOnBoard);
        }

        public int GetFigureCount()
        {
            int counter = 0;

            for (int i = 0; i < TotalRows; i++)
            {
                for (int j = 0; j < TotalCols; j++)
                {
                    if (board[i, j] != null)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        public List<Position> GetAllFiguresPostionsByColor(ChessColor color)
        {
            var figuresPositions = new List<Position>();

            for (int i = 0; i < TotalRows; i++)
            {
                for (int j = 0; j < TotalCols; j++)
                {
                    IFigure currentFigure = this.board[i, j];
                    if (currentFigure != null && currentFigure.Color == color)
                    {
                        Position position = Position.FromArrayCoordinates(i, j, TotalRows);
                        figuresPositions.Add(position);
                    }
                }
            }

            return figuresPositions;
        }

        private int GetArrayRow(int chessRow)
        {
            return this.TotalRows - chessRow;
        }

        private int GetArrayCol(char chessCol)
        {
            return chessCol - 'a';
        }

        private void CheckIfPositionIsValid(Position position)
        {
            Position.CheckIfValid(position);
        }

    }
}
