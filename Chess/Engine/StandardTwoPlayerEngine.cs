namespace Chess.Engine
{
    using System;
    using System.Collections.Generic;

    using Chess.Common;
    using Chess.Board;
    using Chess.Engine.Contracts;
    using Chess.InputProviders.Contracts;
    using Chess.Players.Contracts;
    using Chess.Renderers.Contracts;
    using Chess.Board.Contracts;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;
    using Chess.Movements.Strategies;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;
        private readonly IMovementStrategy movementStrategy;

        private int currentPlayerIndex;
        public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;

            this.movementStrategy = new NormalMovementStrategy();
            this.board = new Board();
            this.players = new List<IPlayer>();
        }

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            this.players = this.input.GetPlayers(GlobalConstants.StandardGameNumberOfPlayers);

            this.SetFirstPlayerIndex();
            gameInitializationStrategy.Initialize(this.players, this.board);
            this.renderer.RenderBoard(board);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);

                    var from = move.From;
                    var to = move.To;
                    var figure = this.board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionEmpty(figure, to);


                    var availableMovements = figure.Move(this.movementStrategy);
                    this.ValidateMovements(figure, availableMovements, move);


                    board.MoveFigureAtPosition(figure, from, to);
                    this.renderer.RenderBoard(board);

                    //TODO: Every move check if we are in check
                    //TODO: Check if pawn reached end
                    //TODO: Check castle - check if castle is valid
                    //TODO: If not castle - Move figure (check pawn for an-pasan)
                    //TODO: check check
                    //TODO: if(in check) check checkmate
                    //TODO: if not in check - check draw
                    //Continue
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }

            }

        }

        //TODO: WinningConditions
        public void WinningConditions()
        {

        }

        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;
            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            return this.players[this.currentPlayerIndex];
        }

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i - 1;
                    return;
                }
            }
        }

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position from)
        {
            if (figure == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.EmptyPositionException, from.Col, from.Row));
            }

            if (figure.Color != player.Color)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.SelectingOpponentsFigureException, from.Col, from.Row));
            }
        }

        private void CheckIfToPositionEmpty(IFigure figure, Position to)
        {
            var figureAtPosition = this.board.GetFigureAtPosition(to);

            if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MovingFigureToAPositionWithYourFigureException, to.Col, to.Row));
            }
        }

        private void ValidateMovements(IFigure figure, IEnumerable<IMovement> availableMovements, Move move)
        {
            var isFoundMove = false;
            Exception exception = new Exception();

            foreach (var movement in availableMovements)
            {
                try
                {
                    movement.ValidateMove(figure, this.board, move);
                    isFoundMove = true;
                    break;
                }
                catch (Exception e)
                {
                    exception = e;
                }
            }

            if (isFoundMove == false)
            {
                throw exception;
            }
        }
    }
}
