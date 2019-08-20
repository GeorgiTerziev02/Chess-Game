using System;

namespace Chess.Common
{
    public struct Position
    {
        public static Position FromArrayCoordinates(int arrRow, int arrCol, int totalRows)
        {
            return new Position(totalRows - arrRow, (char)(arrCol + 'a'));
        }

        public static void CheckIfValid(Position position)
        {
            if (position.Row < GlobalConstants.MinimumRowValueOnBoard || position.Row > GlobalConstants.MaximumRowValueOnBoard)
            {
                throw new IndexOutOfRangeException(ExceptionMessages.RowPositionOutOfBoardException);
            }

            if (position.Col < GlobalConstants.MinimumColumnValueOnBoard || position.Col > GlobalConstants.MaximumColumnValueOnBoard)
            {
                throw new IndexOutOfRangeException(ExceptionMessages.ColPositionOutOfBoardException);
            }
        }

        public static Position FromChessCoordinates(int chessRow, char chessCol)
        {
            var newPosition = new Position(chessRow, chessCol);
            CheckIfValid(newPosition);
            return newPosition;
        }

        public Position(int row, char col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }
        public int Row { get; private set; }

        public char Col { get; private set; }
    }
}
