namespace Chess.Board
{
    using System;
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
            ObjectValidator.CheckIfObjectIsNull(figure, ExceptionMessages.NullFigureException);

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
