using Chess.Common;
using Chess.Movements.Contracts;
using System.Collections.Generic;

namespace Chess.Figures.Contracts
{
    public interface IFigure
    {
        ChessColor Color { get; }

        ICollection<IMovement> Move();
    }
}
