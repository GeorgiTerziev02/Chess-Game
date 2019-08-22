using System.Collections.Generic;
using Chess.Movements.Contracts;

namespace Chess.Movements.Strategies
{
    public class NormalMovementStrategy : IMovementStrategy
    {
        private IDictionary<string, IList<IMovement>> movements = new Dictionary<string, IList<IMovement>>()
        {
            {"Pawn", new List<IMovement>
            {
                new NormalPawnMovement()
            }},

            { "Bishop", new List<IMovement>
            {
                new NormalBishopMovement()
            }}
        };

        public IList<IMovement> GetMovements(string figure)
        {
            return this.movements[figure];
        }
    }
}
