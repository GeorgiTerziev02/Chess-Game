namespace Chess.SpecialFigureCases
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Board.Contracts;
    using Chess.Figures.Contracts;
    using Chess.InputProviders.Contracts;

    public static class PawnCases
    {
        public static void CheckIfPawnReachedEnd(IBoard board, IFigure figure, Position to, IInputProvider input)
        {
            if (figure.Color == ChessColor.White && to.Row == 8)
            {
                int chosenNumber = input.GetPawnPromotion();

                ChosenFigure(board, to, chosenNumber, figure.Color);
            }
            else if (figure.Color == ChessColor.Black && to.Row == 1)
            {
                int chosenNumber = input.GetPawnPromotion();

                ChosenFigure(board, to, chosenNumber, figure.Color);
            }
        }

        private static void ChosenFigure(IBoard board, Position to, int chosenNumber, ChessColor color)
        {
            IFigure promotedFigure = null;

            switch (chosenNumber)
            {
                case 1:
                    board.RemoveFigure(to);
                    promotedFigure = new Queen(color);
                    board.AddFigure(promotedFigure, to);
                    break;
                case 2:
                    board.RemoveFigure(to);
                    promotedFigure = new Rook(color);
                    board.AddFigure(promotedFigure, to);
                    break;
                case 3:
                    board.RemoveFigure(to);
                    promotedFigure = new Bishop(color);
                    board.AddFigure(promotedFigure, to);
                    break;
                case 4:
                    board.RemoveFigure(to);
                    promotedFigure = new Knight(color);
                    board.AddFigure(promotedFigure, to);
                    break;
            }
        }
    }
}
