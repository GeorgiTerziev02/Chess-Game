﻿namespace Chess.Common
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
    }
}
