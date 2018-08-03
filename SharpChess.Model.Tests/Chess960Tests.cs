using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpChess.Model.Tests
{
    [TestClass]
    public class Chess960Tests
    {
        private bool PieceHasExpectedQualities(Piece piece, Player player, string abbreviation, Piece.PieceNames name, int? file = null, int? rank = null)
        {
            return abbreviation == piece.Abbreviation
                && name == piece.Name
                && (file == null || file == piece.StartLocation.File)
                && (rank == null || rank == piece.StartLocation.Rank)
                && player == piece.Player;
        }

        private List<Piece> FindPiecesWithQualities(Player player, string abbreviation, Piece.PieceNames name, int? file = null, int? rank = null)
        {
            List<Piece> result = new List<Piece>();

            foreach (Piece piece in player.Pieces)
            {
                if (PieceHasExpectedQualities(piece, player, abbreviation, name, file, rank)) { result.Add(piece); }
            }

            return result;
        }
        private bool NPiecesWithQualities(Player player, string abbreviation, Piece.PieceNames name, int num, int? file = null, int? rank = null)
        {
            return FindPiecesWithQualities(player, abbreviation, name, file, rank).Count == num;
        }

        [TestMethod]
        public void ShouldPlaceStandardBoardProperlyForWhitePlayer()
        {
            Game_Accessor.Mode = Game_Accessor.GameMode.Chess;
            Game_Accessor.NewInternal("");
            Player player = Game_Accessor.PlayerWhite;
            Assert.AreEqual(16, player.Pieces.Count);
            Assert.IsTrue(PieceHasExpectedQualities(player.King, player, "K", Piece.PieceNames.King, 4, 0));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 0, 1));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 1, 1));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 2, 1));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 3, 1));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 4, 1));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 5, 1));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 6, 1));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 7, 1));
            Assert.IsTrue(NPiecesWithQualities(player, "R", Piece.PieceNames.Rook, 1, 0, 0));
            Assert.IsTrue(NPiecesWithQualities(player, "R", Piece.PieceNames.Rook, 1, 7, 0));
            Assert.IsTrue(NPiecesWithQualities(player, "N", Piece.PieceNames.Knight, 1, 6, 0));
            Assert.IsTrue(NPiecesWithQualities(player, "N", Piece.PieceNames.Knight, 1, 1, 0));
            Assert.IsTrue(NPiecesWithQualities(player, "B", Piece.PieceNames.Bishop, 1, 2, 0));
            Assert.IsTrue(NPiecesWithQualities(player, "B", Piece.PieceNames.Bishop, 1, 5, 0));
            Assert.IsTrue(NPiecesWithQualities(player, "Q", Piece.PieceNames.Queen, 1, 3, 0));
        }

        [TestMethod]
        public void ShouldPlaceStandardBoardProperlyForBlackPlayer()
        {
            Game_Accessor.Mode = Game_Accessor.GameMode.Chess;
            Game_Accessor.NewInternal("");
            Player player = Game_Accessor.PlayerBlack;
            Assert.AreEqual(16, player.Pieces.Count);
            Assert.IsTrue(PieceHasExpectedQualities(player.King, player, "K", Piece.PieceNames.King, 4, 7));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 0, 6));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 1, 6));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 2, 6));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 3, 6));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 4, 6));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 5, 6));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 6, 6));
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 1, 7, 6));
            Assert.IsTrue(NPiecesWithQualities(player, "R", Piece.PieceNames.Rook, 1, 0, 7));
            Assert.IsTrue(NPiecesWithQualities(player, "R", Piece.PieceNames.Rook, 1, 7, 7));
            Assert.IsTrue(NPiecesWithQualities(player, "N", Piece.PieceNames.Knight, 1, 6, 7));
            Assert.IsTrue(NPiecesWithQualities(player, "N", Piece.PieceNames.Knight, 1, 1, 7));
            Assert.IsTrue(NPiecesWithQualities(player, "B", Piece.PieceNames.Bishop, 1, 2, 7));
            Assert.IsTrue(NPiecesWithQualities(player, "B", Piece.PieceNames.Bishop, 1, 5, 7));
            Assert.IsTrue(NPiecesWithQualities(player, "Q", Piece.PieceNames.Queen, 1, 3, 7));
        }

        [TestMethod]
        public void ShouldContainProperNumberAndTypeOfPiecesForChess960WhitePlayer()
        {
            Game_Accessor.Mode = Game_Accessor.GameMode.Chess960;
            Game_Accessor.NewInternal("");
            Player player = Game_Accessor.PlayerWhite;
            Assert.AreEqual(16, player.Pieces.Count);
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 8));
            Assert.IsTrue(NPiecesWithQualities(player, "N", Piece.PieceNames.Knight, 2));
            Assert.IsTrue(NPiecesWithQualities(player, "B", Piece.PieceNames.Bishop, 2));
            Assert.IsTrue(NPiecesWithQualities(player, "Q", Piece.PieceNames.Queen, 1));
            Assert.IsTrue(NPiecesWithQualities(player, "K", Piece.PieceNames.King, 1));
        }

        [TestMethod]
        public void ShouldContainProperNumberAndTypeOfPiecesForChess960BlackPlayer()
        {
            Game_Accessor.Mode = Game_Accessor.GameMode.Chess960;
            Game_Accessor.NewInternal("");
            Player player = Game_Accessor.PlayerBlack;
            Assert.AreEqual(16, player.Pieces.Count);
            Assert.IsTrue(NPiecesWithQualities(player, "P", Piece.PieceNames.Pawn, 8));
            Assert.IsTrue(NPiecesWithQualities(player, "N", Piece.PieceNames.Knight, 2));
            Assert.IsTrue(NPiecesWithQualities(player, "B", Piece.PieceNames.Bishop, 2));
            Assert.IsTrue(NPiecesWithQualities(player, "Q", Piece.PieceNames.Queen, 1));
            Assert.IsTrue(NPiecesWithQualities(player, "K", Piece.PieceNames.King, 1));
        }

        [TestMethod]
        public void ShouldPlaceKingBetweenRooksForChess960BlackPlayer()
        {
            Game_Accessor.Mode = Game_Accessor.GameMode.Chess960;
            Game_Accessor.NewInternal("");
            Player player = Game_Accessor.PlayerBlack;
            List<Piece> rooks = FindPiecesWithQualities(player, "R", Piece.PieceNames.Rook);
            Assert.AreEqual(2, rooks.Count);
            int kingFile = player.King.StartLocation.File, rook1File = rooks.ElementAt(0).StartLocation.File, rook2File = rooks.ElementAt(1).StartLocation.File;
            bool greaterThanOne = kingFile > rook1File || kingFile > rook2File;
            bool lessThanOne = kingFile < rook1File || kingFile < rook2File;
            Assert.IsTrue(greaterThanOne && lessThanOne);
        }

        [TestMethod]
        public void ShouldPlaceKingBetweenRooksForChess960WhitePlayer()
        {
            Game_Accessor.Mode = Game_Accessor.GameMode.Chess960;
            Game_Accessor.NewInternal("");
            Player player = Game_Accessor.PlayerWhite;
            List<Piece> rooks = FindPiecesWithQualities(player, "R", Piece.PieceNames.Rook);
            Assert.AreEqual(2, rooks.Count);
            int kingFile = player.King.StartLocation.File, rook1File = rooks.ElementAt(0).StartLocation.File, rook2File = rooks.ElementAt(1).StartLocation.File;
            bool greaterThanOne = kingFile > rook1File || kingFile > rook2File;
            bool lessThanOne = kingFile < rook1File || kingFile < rook2File;
            Assert.IsTrue(greaterThanOne && lessThanOne);
        }

        [TestMethod]
        public void ShouldPlaceBishopsOnOppositeColorsForChess960BlackPlayer()
        {
            Game_Accessor.Mode = Game_Accessor.GameMode.Chess960;
            Game_Accessor.NewInternal("");
            Player player = Game_Accessor.PlayerBlack;
            List<Piece> bishops = FindPiecesWithQualities(player, "B", Piece.PieceNames.Bishop);
            Assert.AreEqual(2, bishops.Count);
            int bishop1File = bishops.ElementAt(0).StartLocation.File, bishop2File = bishops.ElementAt(1).StartLocation.File;
            Assert.IsTrue(bishop1File % 2 != bishop2File % 2);
        }

        [TestMethod]
        public void ShouldPlaceBishopsOnOppositeColorsforChess960WhitePlayer()
        {
            Game_Accessor.Mode = Game_Accessor.GameMode.Chess960;
            Game_Accessor.NewInternal("");
            Player player = Game_Accessor.PlayerWhite;
            List<Piece> bishops = FindPiecesWithQualities(player, "B", Piece.PieceNames.Bishop);
            Assert.AreEqual(2, bishops.Count);
            int bishop1File = bishops.ElementAt(0).StartLocation.File, bishop2File = bishops.ElementAt(1).StartLocation.File;
            Assert.IsTrue(bishop1File % 2 != bishop2File % 2);
        }

        [TestMethod]
        public void SidesShouldMirrorEachOther()
        {
            Game_Accessor.Mode = Game_Accessor.GameMode.Chess960;
            Game_Accessor.NewInternal("");
            Player playerWhite = Game_Accessor.PlayerWhite;
            Player playerBlack = Game_Accessor.PlayerBlack;
            Assert.AreEqual(playerWhite.Pieces.Count, playerBlack.Pieces.Count);
            
            foreach(Piece white in playerWhite.Pieces)
            {
                List<Piece> blackMatches = FindPiecesWithQualities(playerBlack, white.Abbreviation, white.Name, white.StartLocation.File, 7 - white.StartLocation.Rank);
                Assert.AreEqual(1, blackMatches.Count);
            }
        }


        private bool AnyDifferent(Dictionary<Square, Piece> placements, Player black, Player white)
        {
            foreach (Piece p in white.Pieces) { if (placements[p.StartLocation] != p) { return true; } }
            foreach (Piece p in black.Pieces) { if (placements[p.StartLocation] != p) { return true; } }
            return false;
        }

        [TestMethod]
        public void ShouldYieldAll960CombinationsWithinAMillionTries()
        {
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < 1000000; ++i)
            {
                Chess960Placer.RandGen = new Random(i);
                string res = Chess960Placer.RandomPlacements();
                if (!set.Contains(res)) { set.Add(res); }
            }

            Assert.IsTrue(set.Count == 960);
        }
    }
}
