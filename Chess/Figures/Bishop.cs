namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;

    public class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color) 
            : base(color)
        {

        }

        public override ICollection<IMovement> Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
