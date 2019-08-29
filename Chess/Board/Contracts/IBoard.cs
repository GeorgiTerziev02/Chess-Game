namespace Chess.Board.Contracts
{
    using Chess.Common;
    using Chess.Figures.Contracts;
    using System.Collections.Generic;

    public interface IBoard
    {
        int TotalRows { get; }
        int TotalCols { get; }

        void AddFigure(IFigure figure, Position position);

        void RemoveFigure(Position position);

        IFigure GetFigureAtPosition(Position position);

        void MoveFigureAtPosition(IFigure figure, Position from, Position to);

        Position GetFigurePostionByTypeAndColor(string type, ChessColor color);

        int GetFigureCount();

        List<Position> GetAllFiguresPostionsByColor(ChessColor color);
    }
}
