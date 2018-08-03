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
        ///  Used to generate random numbers for Chess960 game. Exposed for seeding ability.
        /// </summary>
        public static Random RandGen = new Random();
        
        /// <summary>
        /// Generates random placement strings for valid Chess960 starts
        /// </summary>
        /// <returns></returns>
        public static string RandomPlacements()
        {
            List<int> remainingPositions = Enumerable.Range(0, 8).ToList();
            char[] result = new char[8];

            int kingPos, leftRookPos, rightRookPos, firstBishopPos, secondBishopPos, firstKnightPos, secondKnightPos, queenPos;

            remainingPositions.Remove(kingPos = RandGen.Next(1, 7)); // king never placed on either edge (0 || 7) so that rooks can always surround him
            remainingPositions.Remove(leftRookPos = RandGen.Next(0, kingPos)); // place a rook randomly to the left of the king
            remainingPositions.Remove(rightRookPos = RandGen.Next(kingPos + 1, 8)); // place a rook randomly to the right of the king
            remainingPositions.Remove(firstBishopPos = remainingPositions[RandGen.Next(remainingPositions.Count)]); // place first bishop randomly on non-taken square

            // place the second bishop on a non-taken square of the opposite color
            var secondBishopOptions = remainingPositions.Where(i => i % 2 != firstBishopPos % 2);
            remainingPositions.Remove(secondBishopPos = secondBishopOptions.ElementAt(RandGen.Next(secondBishopOptions.Count())));

            remainingPositions.Remove(firstKnightPos = remainingPositions[RandGen.Next(remainingPositions.Count)]); // place a knight on a remaining square
            remainingPositions.Remove(secondKnightPos = remainingPositions[RandGen.Next(remainingPositions.Count)]); // place a knight on a remaining square
            queenPos = remainingPositions[0]; // queen is the last one :)

            result[kingPos] = 'K';
            result[secondBishopPos] = result[firstBishopPos] = 'B';
            result[secondKnightPos] = result[firstKnightPos] = 'N';
            result[rightRookPos] = result[leftRookPos] = 'R';
            result[queenPos] = 'Q';

            return new string(result);
        }
    }
}
