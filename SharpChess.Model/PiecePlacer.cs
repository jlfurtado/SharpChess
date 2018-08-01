using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpChess.Model
{
    /// <summary>
    /// Based on the game mode, decides which piece placer to use
    /// </summary>
    public static class PiecePlacer
    {
        /// <summary>
        /// Uses the game mode to decide which chess placer to use, then calls to that placer for the black player
        /// </summary>
        /// <param name="player">The player to add pieces for</param>
        /// <returns>The king piece to be set</returns>
        public static Piece PlaceBlackPieces(PlayerBlack player)
        {
            return Game.Mode == Game.GameMode.Chess960 ? Chess960Placer.PlaceBlackPieces(player)
                              : ChessPlacer.PlaceBlackPieces(player); 
        }

        /// <summary>
        /// Uses the game mode to decide which chess placer to use, then calls to that placer for the black player
        /// </summary>
        /// <param name="player">The player to add pieces for</param>
        /// <returns>The king piece to be set</returns>
        public static Piece PlaceWhitePieces(PlayerWhite player)
        {
            return Game.Mode == Game.GameMode.Chess960 ? Chess960Placer.PlaceWhitePieces(player)
                              : ChessPlacer.PlaceWhitePieces(player);
        }
    }
}
