namespace Chess.Players
{
    using System;
    using System.Collections.Generic;
    using Chess.Common;
    using Chess.Figures.Contracts;

    public class Player
    {
        private readonly ICollection<IFigure> figures;
        public Player(ChessColor color)
        {
            this.Color = color;

            this.figures = new List<IFigure>();
        }

        public ChessColor Color { get; private set; }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, ExceptionMessages.NullFigureException);
            //TODO: check figure and player color
            CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, ExceptionMessages.NullFigureException);
            //TODO: check figure and player color
            this.CheckIfFigureDoesNotExists(figure);
            this.figures.Remove(figure);
        }
         
        private void CheckIfFigureExists(IFigure figure)
        {
            if (this.figures.Contains(figure))
            {
                throw new InvalidOperationException(ExceptionMessages.PlayerAlreadyOwnsFigureException);
            }
        }

        private void CheckIfFigureDoesNotExists(IFigure figure)
        {
            if (!this.figures.Contains(figure))
            {
                throw new InvalidOperationException(ExceptionMessages.PlayerDoesNotOwnFigureException);
            }
        }
    }
}
