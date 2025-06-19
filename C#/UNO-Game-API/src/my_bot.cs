using System;
using System.Collections.Generic;
using UnoGame;

namespace UNO_Game_API.src
{
    public static class MyBot
    {
        /// <summary>
        /// Selects a move based on the current hand, top card, and time left to play.
        /// </summary>
        /// <param name="hand">The current cards in the player's hand.</param>
        /// <param name="topCard">The card currently on top of the discard pile.</param>
        /// <param name="prevPlayerCardCount">The amount of cards that the player who played before you has left</param>
        /// <param name="nextPlayerCardCount">The amount of cards that the player who is th play after you has left</param>
        /// <param name="playersInGame">The amount of players currently in the game (including yourself)</param>
        /// <param name="timeToPlay">The time left to decide a move (not used in this bot).</param>
        /// <returns>The index of the chosen card to play, or -1 to draw a card if no moves are possible.</returns>
        public static int Think(List<Card> hand, Card topCard, int prevPlayerCardCount, int nextPlayerCardCount, int playersInGame, float timeToPlay)
        {
            // Get a list of all the possible moves the player can make
            List<Card> legalMoves = UnoLib.GetLegalPlays(hand, topCard);

            if (legalMoves.Count == 0)
            {
                // Return -1 to draw a card and forfeit the turn
                return -1;
            }

            // Select a random legal move
            Random random = new Random();
            int moveToPlay = random.Next(0, legalMoves.Count);

            // Return the index of the selected card in the original hand
            return hand.IndexOf(legalMoves[moveToPlay]);
        }
    }
}
