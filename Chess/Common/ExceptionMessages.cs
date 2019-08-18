namespace Chess.Common
{
    public static class ExceptionMessages
    {
        public const string NullFigureException = "Figure cannot be null!";

        public const string RowPositionOutOfBoardException = "Selected row position on the board is not valid!";
        public const string ColPositionOutOfBoardException = "Selected column position on the board is not valid!";

        public const string PlayerAlreadyOwnsFigureException = "This player already owns this figure!";
        public const string PlayerDoesNotOwnFigureException = "This player does not own this figure!";
    }
}
