﻿namespace Chess.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Chess.Board;
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Engine.Contracts;
    using Chess.Figures.Contracts;
    using Chess.InputProviders.Contracts;
    using Chess.Movements.Contracts;
    using Chess.Movements.Strategies;
    using Chess.Players.Contracts;
    using Chess.Renderers.Contracts;
    using Chess.SpecialFigureCases;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;
        private readonly IMovementStrategy movementStrategy;

        private MovedFigures movedFigures;
        private int currentPlayerIndex;

        public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;

            this.movementStrategy = new NormalMovementStrategy();
            this.board = new Board();
            this.players = new List<IPlayer>();
            this.movedFigures = new MovedFigures();
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
            int roundCounter = 0;
            bool check = false;

            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    ChessColor otherPlayerColor = GetOtherPlayerColor(player);

                    check = CheckIfPlayerIsInCheck(board, player);

                    if (check == true)
                    {
                        if (CheckCheckmate(board, player))
                        {
                            renderer.PrintEndGame(string.Format(GlobalConstants.OutputWin, otherPlayerColor));
                            Environment.Exit(0);
                        }

                        renderer.PrintErrorMessage(ExceptionMessages.CheckMessage);
                    }

                    else if (CheckDraw())
                    {
                        renderer.PrintEndGame(GlobalConstants.OutputDraw);
                        Environment.Exit(0);
                    }

                    else if (Path(board, player, check))
                    {
                        renderer.PrintEndGame(GlobalConstants.OutputPath);
                        Environment.Exit(0);
                    }


                    var move = this.input.GetNextPlayerMove(player);

                    var from = move.From;
                    var to = move.To;
                    var figure = this.board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionEmpty(figure, to);

                    var availableMovements = figure.Move(this.movementStrategy);

                    if (figure.GetType().Name == "Pawn" && Math.Abs(from.Col - to.Col) == 1 && Math.Abs(from.Row - to.Row) == 1 && board.GetFigureAtPosition(to) == null)
                    {
                        movedFigures.CheckEnPassant(board, figure, from, to, roundCounter);
                    }
                    else
                    {
                        this.ValidateMovements(figure, availableMovements, move, player, check);
                        IFigure figureTaken = board.GetFigureAtPosition(to);
                        board.MoveFigureAtPosition(figure, from, to);

                        check = CheckIfPlayerIsInCheck(board, player);

                        if (check)
                        {
                            UndoMovement(board, figure, figureTaken, move);
                        }

                        movedFigures.CheckMovedFigures(board);
                    }

                    if (figure.GetType().Name == "Pawn")
                    {
                        PawnCases.CheckIfPawnReachedEnd(board, figure, to, input);
                        movedFigures.CheckIfPawnHasMovedTwoSquares(board, figure, from, to, roundCounter);
                    }

                    this.renderer.RenderBoard(board);

                    roundCounter++;
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }

            }

        }

        private bool CheckCheckmate(IBoard board, IPlayer player)
        {
            int availableMoves = MovedFigures.GetAvailableMoves(board, player);

            if (availableMoves == 0)
            {
                return true;
            }

            return false;
        }

        private bool CheckDraw()
        {
            Position whiteKing = board.GetFigurePostionByTypeAndColor("King", ChessColor.White);
            Position blackKing = board.GetFigurePostionByTypeAndColor("King", ChessColor.Black);

            int figuresCount = board.GetFigureCount();

            if (whiteKing.Row != -1 && blackKing.Row != -1 && figuresCount == 2)
            {
                return true;
            }

            if (figuresCount == 3)
            {
                Position whiteBishop = board.GetFigurePostionByTypeAndColor("Bishop", ChessColor.White);
                Position whiteKnight = board.GetFigurePostionByTypeAndColor("Knight", ChessColor.White);
                Position blackKnight = board.GetFigurePostionByTypeAndColor("Knight", ChessColor.Black);
                Position blackBishop = board.GetFigurePostionByTypeAndColor("Bishop", ChessColor.Black);

                if (whiteBishop.Row != 9 || whiteKnight.Row != 9 || blackBishop.Row != 9 || blackKnight.Row != 9)
                {
                    return true;
                }

            }

            return false;
        }

        //TODO: add available movement = 0;
        private bool Path(IBoard board, IPlayer player, bool check)
        {
            Position playerKing = board.GetFigurePostionByTypeAndColor("King", player.Color);
            Position leftFromKing = new Position(playerKing.Row, (char)(playerKing.Col - 1));
            Position rightFromKing = new Position(playerKing.Row, (char)(playerKing.Col + 1));
            Position downFromKing = new Position(playerKing.Row - 1, playerKing.Col);
            Position upFromKing = new Position(playerKing.Row + 1, playerKing.Col);
            Position leftUpFromKing = new Position(playerKing.Row + 1, (char)(playerKing.Col - 1));
            Position leftDownFromKing = new Position(playerKing.Row - 1, (char)(playerKing.Col - 1));
            Position rightUpFromKing = new Position(playerKing.Row + 1, (char)(playerKing.Col + 1));
            Position rightDownFromKing = new Position(playerKing.Row - 1, (char)(playerKing.Col + 1));

            List<Position> aroundTheKingPosition = new List<Position>()
            {
                leftFromKing,
                leftDownFromKing,
                leftUpFromKing,
                downFromKing,
                upFromKing,
                rightFromKing,
                rightDownFromKing,
                rightUpFromKing
            };

            var validPositions = aroundTheKingPosition.Where(p => Position.CheckIsValid(p)).ToList();

            if (check == false)
            {
                foreach (var position in validPositions)
                {
                    if (!MovedFigures.IsFieldAttacked(board, position, player.Color))
                    {
                        return false;
                    }
                }
            }

            return true;
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

        private void ValidateMovements(IFigure figure, IEnumerable<IMovement> availableMovements, Move move, IPlayer player, bool check)
        {
            var isFoundMove = false;
            Exception exception = new Exception();

            foreach (IMovement movement in availableMovements)
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

        private ChessColor GetOtherPlayerColor(IPlayer player)
        {
            if (player.Color == ChessColor.Black)
            {
                return ChessColor.White;
            }
            else
            {
                return ChessColor.Black;
            }
        }

        private bool CheckIfPlayerIsInCheck(IBoard board, IPlayer player)
        {
            bool check = false;

            if (MovedFigures.IsFieldAttacked(board, board.GetFigurePostionByTypeAndColor("King", player.Color), player.Color))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            return check;
        }

        private void UndoMovement(IBoard board, IFigure figure, IFigure figureTaken, Move move)
        {
            var from = move.To;
            var to = move.From;

            board.MoveFigureAtPosition(figure, from, to);

            if (figureTaken != null)
            {
                board.AddFigure(figureTaken, from);
            }

            throw new InvalidOperationException(ExceptionMessages.YouAreInCheckException);
        }
    }
}
