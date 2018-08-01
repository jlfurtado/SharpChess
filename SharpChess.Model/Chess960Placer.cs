using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpChess.Model
{
    /// <summary>
    /// Static class that exposes seperate functionality to place pieces based on Chess960 rules
    /// </summary>
    public static class Chess960Placer
    {
        /// <summary>
        /// Places the white player's pieces for a chess960 game, returns the king to be set
        /// </summary>
        /// <param name="player">Reference to the player object</param>
        public static Piece PlaceWhitePieces(PlayerWhite player)
        {
            Piece king = new Piece(Piece.PieceNames.King, player, 4, 0, Piece.PieceIdentifierCodes.WhiteKing);
            player.Pieces.Add(king);

            player.Pieces.Add(new Piece(Piece.PieceNames.Queen, player, 3, 0, Piece.PieceIdentifierCodes.WhiteQueen));

            player.Pieces.Add(new Piece(Piece.PieceNames.Rook, player, 0, 0, Piece.PieceIdentifierCodes.WhiteQueensRook));
            player.Pieces.Add(new Piece(Piece.PieceNames.Rook, player, 7, 0, Piece.PieceIdentifierCodes.WhiteKingsRook));

            player.Pieces.Add(new Piece(Piece.PieceNames.Bishop, player, 2, 0, Piece.PieceIdentifierCodes.WhiteQueensBishop));
            player.Pieces.Add(new Piece(Piece.PieceNames.Bishop, player, 5, 0, Piece.PieceIdentifierCodes.WhiteKingsBishop));

            player.Pieces.Add(new Piece(Piece.PieceNames.Knight, player, 1, 0, Piece.PieceIdentifierCodes.WhiteQueensKnight));
            player.Pieces.Add(new Piece(Piece.PieceNames.Knight, player, 6, 0, Piece.PieceIdentifierCodes.WhiteKingsKnight));

            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 0, 1, Piece.PieceIdentifierCodes.WhitePawn1));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 1, 1, Piece.PieceIdentifierCodes.WhitePawn2));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 2, 1, Piece.PieceIdentifierCodes.WhitePawn3));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 3, 1, Piece.PieceIdentifierCodes.WhitePawn4));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 4, 1, Piece.PieceIdentifierCodes.WhitePawn5));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 5, 1, Piece.PieceIdentifierCodes.WhitePawn6));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 6, 1, Piece.PieceIdentifierCodes.WhitePawn7));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 7, 1, Piece.PieceIdentifierCodes.WhitePawn8));

            return king;
        }

        /// <summary>
        /// Places the black player's pieces for a chess960 game, returns the king to be set
        /// </summary>
        /// <param name="player">Reference to the player object</param>
        public static Piece PlaceBlackPieces(PlayerBlack player)
        {
            Piece king = new Piece(Piece.PieceNames.King, player, 4, 7, Piece.PieceIdentifierCodes.BlackKing);
            player.Pieces.Add(king);

            player.Pieces.Add(new Piece(Piece.PieceNames.Queen, player, 3, 7, Piece.PieceIdentifierCodes.BlackQueen));

            player.Pieces.Add(new Piece(Piece.PieceNames.Rook, player, 0, 7, Piece.PieceIdentifierCodes.BlackQueensRook));
            player.Pieces.Add(new Piece(Piece.PieceNames.Rook, player, 7, 7, Piece.PieceIdentifierCodes.BlackKingsRook));

            player.Pieces.Add(new Piece(Piece.PieceNames.Bishop, player, 2, 7, Piece.PieceIdentifierCodes.BlackQueensBishop));
            player.Pieces.Add(new Piece(Piece.PieceNames.Bishop, player, 5, 7, Piece.PieceIdentifierCodes.BlackKingsBishop));

            player.Pieces.Add(new Piece(Piece.PieceNames.Knight, player, 1, 7, Piece.PieceIdentifierCodes.BlackQueensKnight));
            player.Pieces.Add(new Piece(Piece.PieceNames.Knight, player, 6, 7, Piece.PieceIdentifierCodes.BlackKingsKnight));

            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 0, 6, Piece.PieceIdentifierCodes.BlackPawn1));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 1, 6, Piece.PieceIdentifierCodes.BlackPawn2));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 2, 6, Piece.PieceIdentifierCodes.BlackPawn3));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 3, 6, Piece.PieceIdentifierCodes.BlackPawn4));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 4, 6, Piece.PieceIdentifierCodes.BlackPawn5));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 5, 6, Piece.PieceIdentifierCodes.BlackPawn6));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 6, 6, Piece.PieceIdentifierCodes.BlackPawn7));
            player.Pieces.Add(new Piece(Piece.PieceNames.Pawn, player, 7, 6, Piece.PieceIdentifierCodes.BlackPawn8));
            return king;
        }
    }
}
