namespace Chess.Figures.Contracts
{
    using Chess.Common;
    using Chess.Movements.Contracts;
    using System.Collections.Generic;

    public abstract class BaseFigure : IFigure
    {
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        public abstract ICollection<IMovement> Move();
    }
}
