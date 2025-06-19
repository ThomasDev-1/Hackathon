using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UnoGame
{
    public class UnoLib
    {
        public static void ShuffleDeck(List<Card> deckToShuffle)
        {
            deckToShuffle.Shuffle();
        }

        public static List<Card> GetHand(List<Card> deckToDealFrom, List<Card> currentGamePool)
        {
            if (deckToDealFrom.Count < 8)
            {
                MergePool(deckToDealFrom, currentGamePool);
                ShuffleDeck(deckToDealFrom);
            }

            List<Card> newHand = new List<Card>();
            for (int i = 0; i < 7 && deckToDealFrom.Count > 0; i++)
            {
                newHand.Add(deckToDealFrom[0]);
                deckToDealFrom.RemoveAt(0);
            }
            return newHand;
        }

        public static Card DrawCard(List<Card> deckToDrawFrom, List<Card> handToDrawTo, List<Card> currentGamePool)
        {
            if (deckToDrawFrom.Count < 8)
            {
                MergePool(deckToDrawFrom, currentGamePool);
                ShuffleDeck(deckToDrawFrom);
            }
            handToDrawTo.Add(deckToDrawFrom[0]);
            Card returnCard = deckToDrawFrom[0];
            deckToDrawFrom.RemoveAt(0);

            return returnCard;
        }

        public static void MergePool(List<Card> deckToMerge, List<Card> poolToMerge)
        {
            if (poolToMerge.Count == 0) return;

            Card topCard = poolToMerge[poolToMerge.Count - 1];
            poolToMerge.RemoveAt(poolToMerge.Count - 1);
            deckToMerge.AddRange(poolToMerge);
            poolToMerge.Clear();
            poolToMerge.Add(topCard);
        }

        public static void PlayCard(int cardIndex, List<Card> poolToPlay, List<Card> handToPlayFrom)
        {
            if (cardIndex < handToPlayFrom.Count)
            {
                poolToPlay.Add(handToPlayFrom[cardIndex]);
                handToPlayFrom.RemoveAt(cardIndex);
            }
        }

        public static List<Card> GetLegalPlays(List<Card> hand, Card topCard, int addTotal = 0)
        {
            List<Card> legalCards = new List<Card>();

            if (topCard == null)
                return hand;

            // Handle stacking logic if in a penalty state
            if (addTotal > 0)
            {
                foreach (var card in hand)
                {
                    if (topCard.value == 'T' && (card.value == 'T' || card.value == 'F')) // stack +2 or +4
                    {
                        legalCards.Add(card);
                    }
                    else if (topCard.value == 'F' && card.value == 'F') // only +4 on +4
                    {
                        legalCards.Add(card);
                    }
                }
                return legalCards;
            }

            // Normal play logic

            if (topCard.color == 'N')
            {
                return hand;
            }
            foreach (var card in hand)
            {
                if (card.value == topCard.value || card.color == topCard.color || card.color == 'N')
                {
                    legalCards.Add(card);
                }
            }

            return legalCards;
        }


        public static string GetTopCard(List<Card> poolInPlay)
        {
            return poolInPlay.Count > 0 ? poolInPlay[poolInPlay.Count - 1].GetCard() : " ";
        }

        public static Card GetTopCardC(List<Card> poolInPlay)
        {
            return poolInPlay.Count > 0 ? poolInPlay[poolInPlay.Count - 1] : null;
        }
        public static List<Card> InitBoard()
        {
            List<Card> deck = new List<Card>()
            {
                // Each color of card has 2 of type, but only ONE '0' card
                // Red cards
                new Card { value = '0', color = 'R'},
                new Card { value = '1', color = 'R'},
                new Card { value = '2', color = 'R'},
                new Card { value = '3', color = 'R'},
                new Card { value = '4', color = 'R'},
                new Card { value = '5', color = 'R'},
                new Card { value = '6', color = 'R'},
                new Card { value = '7', color = 'R'},
                new Card { value = '8', color = 'R'},
                new Card { value = '9', color = 'R'},
                new Card { value = 'T', color = 'R'}, // +2 card
                new Card { value = 'S', color = 'R'}, // Skip card
                new Card { value = 'R', color = 'R'}, // Reverse card

                new Card { value = '1', color = 'R'},
                new Card { value = '2', color = 'R'},
                new Card { value = '3', color = 'R'},
                new Card { value = '4', color = 'R'},
                new Card { value = '5', color = 'R'},
                new Card { value = '6', color = 'R'},
                new Card { value = '7', color = 'R'},
                new Card { value = '8', color = 'R'},
                new Card { value = '9', color = 'R'},
                new Card { value = 'T', color = 'R'}, // +2 card
                new Card { value = 'S', color = 'R'}, // Skip card
                new Card { value = 'R', color = 'R'}, // Reverse card

                // Blue cards
                new Card { value = '0', color = 'B'},
                new Card { value = '1', color = 'B'},
                new Card { value = '2', color = 'B'},
                new Card { value = '3', color = 'B'},
                new Card { value = '4', color = 'B'},
                new Card { value = '5', color = 'B'},
                new Card { value = '6', color = 'B'},
                new Card { value = '7', color = 'B'},
                new Card { value = '8', color = 'B'},
                new Card { value = '9', color = 'B'},
                new Card { value = 'T', color = 'B'}, // +2 card
                new Card { value = 'S', color = 'B'}, // Skip card
                new Card { value = 'R', color = 'B'}, // Reverse card

                new Card { value = '1', color = 'B'},
                new Card { value = '2', color = 'B'},
                new Card { value = '3', color = 'B'},
                new Card { value = '4', color = 'B'},
                new Card { value = '5', color = 'B'},
                new Card { value = '6', color = 'B'},
                new Card { value = '7', color = 'B'},
                new Card { value = '8', color = 'B'},
                new Card { value = '9', color = 'B'},
                new Card { value = 'T', color = 'B'}, // +2 card
                new Card { value = 'S', color = 'B'}, // Skip card
                new Card { value = 'R', color = 'B'}, // Reverse card

                // Yellow cards
                new Card { value = '0', color = 'Y'},
                new Card { value = '1', color = 'Y'},
                new Card { value = '2', color = 'Y'},
                new Card { value = '3', color = 'Y'},
                new Card { value = '4', color = 'Y'},
                new Card { value = '5', color = 'Y'},
                new Card { value = '6', color = 'Y'},
                new Card { value = '7', color = 'Y'},
                new Card { value = '8', color = 'Y'},
                new Card { value = '9', color = 'Y'},
                new Card { value = 'T', color = 'Y'}, // +2 card
                new Card { value = 'S', color = 'Y'}, // Skip card
                new Card { value = 'R', color = 'Y'}, // Reverse card

                new Card { value = '1', color = 'Y'},
                new Card { value = '2', color = 'Y'},
                new Card { value = '3', color = 'Y'},
                new Card { value = '4', color = 'Y'},
                new Card { value = '5', color = 'Y'},
                new Card { value = '6', color = 'Y'},
                new Card { value = '7', color = 'Y'},
                new Card { value = '8', color = 'Y'},
                new Card { value = '9', color = 'Y'},
                new Card { value = 'T', color = 'Y'}, // +2 card
                new Card { value = 'S', color = 'Y'}, // Skip card
                new Card { value = 'R', color = 'Y'}, // Reverse card

                // Green cards
                new Card { value = '0', color = 'G'},
                new Card { value = '1', color = 'G'},
                new Card { value = '2', color = 'G'},
                new Card { value = '3', color = 'G'},
                new Card { value = '4', color = 'G'},
                new Card { value = '5', color = 'G'},
                new Card { value = '6', color = 'G'},
                new Card { value = '7', color = 'G'},
                new Card { value = '8', color = 'G'},
                new Card { value = '9', color = 'G'},
                new Card { value = 'T', color = 'G'}, // +2 card
                new Card { value = 'S', color = 'G'}, // Skip card
                new Card { value = 'R', color = 'G'}, // Reverse card

                new Card { value = '1', color = 'G'},
                new Card { value = '2', color = 'G'},
                new Card { value = '3', color = 'G'},
                new Card { value = '4', color = 'G'},
                new Card { value = '5', color = 'G'},
                new Card { value = '6', color = 'G'},
                new Card { value = '7', color = 'G'},
                new Card { value = '8', color = 'G'},
                new Card { value = '9', color = 'G'},
                new Card { value = 'T', color = 'G'}, // +2 card
                new Card { value = 'S', color = 'G'}, // Skip card
                new Card { value = 'R', color = 'G'}, // Reverse card

                // Wild cards
                new Card { value = 'F', color = 'N'}, // +4 card
                new Card { value = 'F', color = 'N'}, // +4 card
                new Card { value = 'F', color = 'N'}, // +4 card
                new Card { value = 'F', color = 'N'}, // +4 card
                new Card { value = 'C', color = 'N'}, // Color change
                new Card { value = 'C', color = 'N'}, // Color change
                new Card { value = 'C', color = 'N'}, // Color change
                new Card { value = 'C', color = 'N'}, // Color change
            };

            return deck;
        }
    }

    public class Card
    {
        public char value { get; set; }
        public char color { get; set; }

        public string GetCard()
        {
            return value.ToString() + color.ToString();
        }
    }

    public static class ListExtensions
    {
        private static readonly Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }
    }
}
