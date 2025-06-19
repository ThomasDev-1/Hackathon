using System;
using System.Collections.Generic;
using System.Linq;
using UnoGame;

namespace UNO_Game_API.src
{
    public static class DemoBot
    {
        public static int Think(List<Card> hand, Card topCard, int prevPlayerCardCount, int nextPlayerCardCount, int playersInGame, float timeToPlay)
        {
            // Get legal plays
            List<Card> legalMoves = UnoLib.GetLegalPlays(hand, topCard);

            if (legalMoves.Count == 0)
                return -1; // draw card

            // Build color counts for hand
            var colorCounts = hand
                .Where(c => c.color != 'N') // ignore wilds for color counting
                .GroupBy(c => c.color)
                .ToDictionary(g => g.Key, g => g.Count());

            // Assign score to each legal move
            var scoredMoves = legalMoves
                .Select(card => new { Card = card, Score = ScoreCard(card, colorCounts, nextPlayerCardCount) })
                .OrderByDescending(cs => cs.Score)
                .ToList();

            var bestCard = scoredMoves[0].Card;

            // Return the index of the chosen card in hand
            return hand.IndexOf(bestCard);
        }

        static int ScoreCard(Card card, Dictionary<char, int> colorCounts, int nextPlayerCardCount)
        {
            int score = 0;

            // Color abundance bonus
            if (colorCounts.ContainsKey(card.color))
                score += colorCounts[card.color] * 10;

            // High priority for aggressive plays if next player is low on cards
            if (nextPlayerCardCount <= 3)
            {
                if (card.value == 'F') score += 100;  // Wild +4
                if (card.value == 'T') score += 60;   // +2
                if (card.value == 'S') score += 50;   // Skip
                if (card.value == 'R') score += 50;   // Reverse
            }

            // Moderate priority even if next player isn't too low
            if (card.value == 'T') score += 20;
            if (card.value == 'S' || card.value == 'R') score += 15;
            if (card.value == 'F') score += 50; // Save wilds for tactical usage

            // Lowest priority to Wild Color Change unless necessary
            if (card.value == 'C') score += 5;

            // Prioritize number cards early to reduce hand size safely
            if (char.IsDigit(card.value))
                score += 10;

            return score;
        }
    }
}
