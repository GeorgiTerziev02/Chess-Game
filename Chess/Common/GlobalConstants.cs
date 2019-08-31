namespace Chess.Common
{
    //static class???
    public static class GlobalConstants
    {
        public const int StandardGameNumberOfPlayers = 2;
        public const int StandardGameTotalBoardRows = 8;
        public const int StandardGameTotalBoardCols = 8;

        public const int MinimumRowValueOnBoard = 1;
        public const int MaximumRowValueOnBoard = 8;
        public const char MinimumColumnValueOnBoard = 'a';
        public const char MaximumColumnValueOnBoard = 'h';

        public const string EmptyString = "";

        public const int WhitePawnStartingRow = 2;
        public const int BlackPawnStartingRow = 7;

        public const string OutputEndGame = "Game ended with ";
        public const string OutputDraw = "Draw! Due to impossility of checkmate!";
        public const string OutputPath = "Path! Because you have no valid moves!";
        public const string OutputWin = "{0} winning!";

        public readonly static Position StandardGameWhiteKingPosition = Position.FromChessCoordinates(1, 'e');
        public readonly static Position StandardGameBlackKingPosition = Position.FromChessCoordinates(8, 'e');
        public readonly static Position StandardGameWhiteRightRookPosition = Position.FromChessCoordinates(1, 'h');
        public readonly static Position StandardGameWhiteLeftRookPosition = Position.FromChessCoordinates(1, 'a');
        public readonly static Position StandardGameBlackRightRookPosition = Position.FromChessCoordinates(8, 'h');
        public readonly static Position StandardGameBlackLeftRookPosition = Position.FromChessCoordinates(8, 'a');
    }
}
