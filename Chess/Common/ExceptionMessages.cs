namespace Chess.Common
{
    public static class ExceptionMessages
    {
        public const string NullFigureException = "Figure cannot be null!";

        public const string RowPositionOutOfBoardException = "Selected row position on the board is not valid!";
        public const string ColPositionOutOfBoardException = "Selected column position on the board is not valid!";
        public const string PlayerNameLengthException = "Player name should be between 1 and 16 symbols!";
        public const string NumberOutOfRangeOneToFourException = "Choose number between 1 and 4!";

        public const string PlayerAlreadyOwnsFigureException = "This player already owns this figure!";
        public const string PlayerDoesNotOwnFigureException = "This player does not own this figure!";

        public const string StandardGameMustHaveTwoPlayersException = "Standard Start Game Initialization Strategy needs exactly two players!";
        public const string StandardGameMustHaveEightSquareBoardException = "Standard Start Game Initialization Strategy needs 8x8 board!";

        public const string NonExistingChessColor = "Invalid Chess Color!";
        public const string InvalidCommandException = "Invalid Command!";

        public const string EmptyPositionException = "Position {0}{1} is empty!";
        public const string SelectingOpponentsFigureException = "Figure at Position {0}{1} is not yours!";
        public const string MovingFigureToAPositionWithYourFigureException = "You already have figure at Position {0}{1}!";
        public const string FigureOnTheWayException = "There is figure on your way!";

        public const string InvalidPawnMovementBackwardsException = "Pawn cannot move backwards!";
        public const string InvalidPawnMovementSidewaysException = "Pawn cannot move this way!";
        public const string InvalidBishopMovementSidewaysException = "Bishop can move only diagonally!";
        public const string InvalidKingMovementException = "King can move only on positions next to him!";
        public const string InvalidKnightMovementException = "Knight cannnot move this way!";
        public const string InvalidRookMovementException = "Rook cannnot move this way!";

        public const string RookOrKingHaveBeenMovedException = "Cannot castle if your King or Rook have already been moved!";
        public const string FiguresBetweenRookAndKingException = "Cannot castle if there are figures between the King and the Rook!";
        public const string CannotCastleIfKingIsInCheckException = "Cannot castle if your King is in check!";
        public const string KingCannotCrossAttackedField = "Cannot castle if your King crosses attacked fields!";
        public const string InvalidEnPassantMovementException = "Cannot perform En Passant movement!";
        public const string YouAreInCheckException = "Cannot move figure because you will be in check!";

        public const string CheckMessage = "Check!";
        
    }
}
