namespace Chess.SpecialFigureCases
{
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;

    public class MovedFigures
    {
        private bool isWhiteKingMoved;
        private bool isBlackKingMoved;
        private bool isBlackRightRookMoved;
        private bool isWhiteRightRookMoved;
        private bool isBlackLeftRookMoved;
        private bool isWhiteLeftRookMoved;

        //TODO: constants
        private readonly static Position WhiteKingPosition = Position.FromChessCoordinates(1, 'e');
        private readonly static Position BlackKingPosition = Position.FromChessCoordinates(8, 'e');
        private readonly static Position WhiteRightRookPosition = Position.FromChessCoordinates(1, 'h');
        private readonly static Position WhiteLeftRookPosition = Position.FromChessCoordinates(1, 'a');
        private readonly static Position BlackRightRookPosition = Position.FromChessCoordinates(8, 'h');
        private readonly static Position BlackLeftRookPosition = Position.FromChessCoordinates(8, 'a');

        public MovedFigures()
        {
            this.IsWhiteKingMoved = false;
            this.IsBlackKingMoved = false;
            this.IsBlackRightRookMoved = false;
            this.IsWhiteRightRookMoved = false;
            this.IsBlackLeftRookMoved = false;
            this.IsWhiteLeftRookMoved = false;
        }

        public bool IsWhiteKingMoved { get => isWhiteKingMoved; set => isWhiteKingMoved = value; }

        public bool IsBlackKingMoved { get => isBlackKingMoved; set => isBlackKingMoved = value; }

        public bool IsBlackRightRookMoved { get => isBlackRightRookMoved; set => isBlackRightRookMoved = value; }

        public bool IsWhiteRightRookMoved { get => isWhiteRightRookMoved; set => isWhiteRightRookMoved = value; }

        public bool IsBlackLeftRookMoved { get => isBlackLeftRookMoved; set => isBlackLeftRookMoved = value; }

        public bool IsWhiteLeftRookMoved { get => isWhiteLeftRookMoved; set => isWhiteLeftRookMoved = value; }


        public void CheckMovedFigures(IBoard board)
        {
            IFigure whiteKingShouldbeAt = board.GetFigureAtPosition(WhiteKingPosition);
            IFigure blackKingShouldbeAt = board.GetFigureAtPosition(BlackKingPosition);
            IFigure whiteRightRookShouldbeAt = board.GetFigureAtPosition(WhiteRightRookPosition);
            IFigure whiteLeftRookShouldbeAt = board.GetFigureAtPosition(WhiteLeftRookPosition);
            IFigure blackRightRookShouldbeAt = board.GetFigureAtPosition(BlackRightRookPosition);
            IFigure blackLeftRookShouldbeAt = board.GetFigureAtPosition(BlackLeftRookPosition);

            if (whiteKingShouldbeAt == null || board.GetFigureAtPosition(WhiteKingPosition).GetType().Name != "King")
            {
                IsWhiteKingMoved = true;
            }
            if (blackKingShouldbeAt == null || board.GetFigureAtPosition(BlackKingPosition).GetType().Name != "King")
            {
                IsBlackKingMoved = true;
            }
            if (whiteRightRookShouldbeAt == null || board.GetFigureAtPosition(WhiteRightRookPosition).GetType().Name != "Rook")
            {
                IsWhiteRightRookMoved = true;
            }
            if (whiteLeftRookShouldbeAt == null || board.GetFigureAtPosition(WhiteLeftRookPosition).GetType().Name != "Rook")
            {
                IsWhiteLeftRookMoved = true;
            }
            if (blackLeftRookShouldbeAt == null || board.GetFigureAtPosition(BlackLeftRookPosition).GetType().Name != "Rook")
            {
                IsBlackLeftRookMoved = true;
            }
            if (blackRightRookShouldbeAt == null || board.GetFigureAtPosition(BlackRightRookPosition).GetType().Name != "Rook")
            {
                IsBlackRightRookMoved = true;
            }

            MoveFiguresInformation.isBlackKingMoved = this.IsBlackKingMoved;
            MoveFiguresInformation.isWhiteKingMoved = this.IsWhiteKingMoved;
            MoveFiguresInformation.isWhiteRightRookMoved = this.IsWhiteRightRookMoved;
            MoveFiguresInformation.isWhiteLeftRookMoved = this.IsWhiteLeftRookMoved;
            MoveFiguresInformation.isBlackRightRookMoved = this.IsBlackRightRookMoved;
            MoveFiguresInformation.isBlackLeftRookMoved = this.IsBlackLeftRookMoved;
        }
    }
}
