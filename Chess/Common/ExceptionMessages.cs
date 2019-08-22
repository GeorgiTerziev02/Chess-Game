namespace Chess.Common
{
    public static class ExceptionMessages
    {
        public const string NullFigureException = "Figure cannot be null!";

        public const string RowPositionOutOfBoardException = "Selected row position on the board is not valid!";
        public const string ColPositionOutOfBoardException = "Selected column position on the board is not valid!";

        public const string PlayerAlreadyOwnsFigureException = "This player already owns this figure!";
        public const string PlayerDoesNotOwnFigureException = "This player does not own this figure!";

        public const string StandardGameMustHaveTwoPlayersException = "Standard Start Game Initialization Strategy needs exactly two players!";
        public const string StandardGameMustHaveEightSquareBoardException = "Standard Start Game Initialization Strategy needs 8x8 board!";

        public const string NonExistingChessColor = "Invalid Chess Color";
        public const string InvalidCommandException = "Invalid Command";

        public const string EmptyPositionException = "Position {0}{1} is empty!";
        public const string SelectingOpponentsFigureException = "Figure at Position {0}{1} is not yours!";
        public const string MovingFigureToAPositionWithYourFigureException = "You already have figure at Position {0}{1}!";
        public const string FigureOnTheWayException = "There is figure on your way";

        public const string InvalidPawnMovementBackwardsException = "Pawn cannot move backwards!";
        public const string InvalidPawnMovementSidewaysException = "Pawn cannot move this way!";
        public const string InvalidBishopMovementSidewaysException = "Bishop cannot move this way!";
    }
}
