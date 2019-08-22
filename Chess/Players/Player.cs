namespace Chess.Players
{
    using System;
    using System.Collections.Generic;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Players.Contracts;

    public class Player : IPlayer
    {
        private string name;
        private readonly ICollection<IFigure> figures;

        public Player(string name, ChessColor color)
        {
            this.Name = name;
            this.Color = color;

            this.figures = new List<IFigure>();
        }

        public ChessColor Color { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 1 || value.Length > 16)
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameLengthException);
                }

                this.name = value;
            }
        }

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
