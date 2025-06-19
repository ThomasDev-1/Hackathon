using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNO_Game_API.src;
using UnoGame;

namespace UNO_Game_API
{
    public partial class Form1 : Form
    {
        public int botVbotTime = 0;
        public int botVdemoTime = 0;

        public bool isBotVPlayerGame;
        public bool isBotVSelf;
        public bool isBotVDemo;

        List<Card> deck;
        List<Card> pool;
        List<List<Card>> playersHands = new List<List<Card>>();
        int currentPlayerIndex = 0;
        int direction = 1; // 1 for clockwise, -1 for counter-clockwise
        int totalPlayers = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            txtGameLog.AppendText("Closing...");
            this.Close();
        }

        private void btnHumanVsHuman_Click(object sender, EventArgs e)
        {
            panelPlayerHand.Controls.Clear();
            panelOpponentHand1.Controls.Clear();
            panelOpponentHand2.Controls.Clear();
            panelOpponentHand3.Controls.Clear();

            lblPlayerCards.Text = "";
            lblBot1Cards.Text = "";
            lblBot2Cards.Text = "";
            lblBot3Cards.Text = "";

            isBotVPlayerGame = false;
            totalPlayers = 2;
            txtGameLog.AppendText("Starting game: Human vs Human...\r\n");
            deck = UnoLib.InitBoard();
            txtGameLog.AppendText("Shuffling deck...\r\n");
            UnoLib.ShuffleDeck(deck);

            pool = new List<Card>();
            playersHands.Clear();
            playersHands.Add(UnoLib.GetHand(deck, pool)); // Player 0
            playersHands.Add(UnoLib.GetHand(deck, pool)); // Player 1

            Random random = new Random();
            currentPlayerIndex = random.Next(0, totalPlayers); // Randomly decide who starts

            txtGameLog.AppendText(currentPlayerIndex == 0 ? "Player starts.\r\n" : "Opponent starts.\r\n");
            pool.Add(deck[0]);
            deck.RemoveAt(0);
            RenderTopCard();
            RenderAllHands();
        }

        private void btnHumanVBot_Click(object sender, EventArgs e)
        {
            panelPlayerHand.Controls.Clear();
            panelOpponentHand1.Controls.Clear();
            panelOpponentHand2.Controls.Clear();
            panelOpponentHand3.Controls.Clear();

            lblPlayerCards.Text = "";
            lblBot1Cards.Text = "";
            lblBot2Cards.Text = "";
            lblBot3Cards.Text = "";

            isBotVPlayerGame = true;
            isBotVSelf = false;
            totalPlayers = 4;
            txtGameLog.AppendText("Starting game: Human vs Bots...\r\n");
            deck = UnoLib.InitBoard();
            txtGameLog.AppendText("Shuffling deck...\r\n");
            UnoLib.ShuffleDeck(deck);

            pool = new List<Card>();
            playersHands.Clear();
            for (int i = 0; i < totalPlayers; i++)
            {
                playersHands.Add(UnoLib.GetHand(deck, pool));
            }

            Random random = new Random();
            currentPlayerIndex = random.Next(0, totalPlayers); // Randomly decide who starts

            if (currentPlayerIndex == 0)
            {
                lblTurn.Text = "↓";
            }
            else if (currentPlayerIndex == 1)
            {
                lblTurn.Text = "←";
            }
            else if (currentPlayerIndex == 2)
            {
                lblTurn.Text = "↑";
            }
            else if (currentPlayerIndex == 3)
            {
                lblTurn.Text = "→";
            }

            txtGameLog.AppendText(currentPlayerIndex == 0 ? "Player starts.\r\n" : $"Bot {currentPlayerIndex} starts.\r\n");
            pool.Add(deck[0]);
            deck.RemoveAt(0);
            RenderTopCard();
            RenderAllHands(true);

            if (currentPlayerIndex != 0)
            {
                BotTurn();
            }
        }

        private void lblDrawPile_Click(object sender, EventArgs e)
        {
            if (currentPlayerIndex == 0)
            {
                Card newCard = UnoLib.DrawCard(deck, playersHands[0], pool);
                txtGameLog.AppendText("Player drew a card...\r\n");
                RenderAllHands();
                NextTurn();
            }
        }

        private void RenderTopCard()
        {
            Card topCard = UnoLib.GetTopCardC(pool);
            pictureBox2.Image = CardToImage(topCard.GetCard());
        }

        private void RenderAllHands(bool init = false, int playerIndex = -1)
        {
            lblPlayerCards.Text = playersHands[0].Count == 1 ? "UNO" : playersHands[0].Count.ToString();
            if (currentPlayerIndex == 0 || init || playerIndex == 0)
            {
                panelPlayerHand.Controls.Clear();
                for (int i = 0; i < playersHands[0].Count; i++)
                {
                    PictureBox cardImage = new PictureBox
                    {
                        Width = 70,
                        Height = 90,
                        Tag = i,
                        Image = CardToImage(playersHands[0][i].GetCard()),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Left = i * 75,
                        Top = 0
                    };

                    if (!isBotVSelf)
                    {
                        cardImage.Click += (s, e) =>
                        {
                            if (currentPlayerIndex != 0) return;
                            int index = (int)((PictureBox)s).Tag;
                            Card topCard = UnoLib.GetTopCardC(pool);
                            List<Card> legalMoves = UnoLib.GetLegalPlays(playersHands[0], topCard);
                            if (legalMoves.Contains(playersHands[0][index]))
                            {
                                txtGameLog.AppendText("Player played the card " + playersHands[0][index].GetCard() + "...\r\n");
                                UnoLib.PlayCard(index, pool, playersHands[0]);
                                RenderAllHands();
                                HandleSpecialCard(pool[pool.Count - 1]);
                                RenderTopCard();
                                CheckForWin();
                                NextTurn();
                            }
                            else
                            {
                                MessageBox.Show("Illegal move!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };
                    }

                    panelPlayerHand.Controls.Add(cardImage);
                }
            }

            if (currentPlayerIndex == 1 || playerIndex == 1)
            {
                panelOpponentHand1.Controls.Clear();
            }
            else if (currentPlayerIndex == 2 || playerIndex == 2)
            {
                panelOpponentHand2.Controls.Clear();
            } else if (currentPlayerIndex == 3 || playerIndex == 3)
            {
                panelOpponentHand3.Controls.Clear();
            }

            for (int i = 1; i < totalPlayers; i++)
            {
                if (i != currentPlayerIndex && !init && i != playerIndex) continue;
                Panel panel = i == 1 ? panelOpponentHand1 : i == 2 ? panelOpponentHand2 : panelOpponentHand3;
                Label label = i == 1 ? lblBot1Cards : i == 2 ? lblBot2Cards : lblBot3Cards;
                panel.Controls.Clear();
                label.Text = playersHands[i].Count == 1 ? "UNO" : playersHands[i].Count.ToString();

                for (int j = 0; j < playersHands[i].Count; j++)
                {
                    if (isBotVSelf)
                    {
                        PictureBox cardImage = new PictureBox
                        {
                            Width = 70,
                            Height = 90,
                            Tag = j,
                            Image = CardToImage(playersHands[i][j].GetCard()),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Left = j * 75,
                            Top = 0
                        };
                        panel.Controls.Add(cardImage);
                    }
                    else
                    {
                        PictureBox cardImage = new PictureBox
                        {
                            Width = 70,
                            Height = 90,
                            Image = CardToImage("Back"),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Left = j * 15,
                            Top = 0
                        };
                        panel.Controls.Add(cardImage);
                    }
                }
            }
        }

        private async void BotTurn()
        {
            if (currentPlayerIndex == 0 && !isBotVSelf) return;

            int prevPlayer = (currentPlayerIndex - direction + totalPlayers) % totalPlayers;
            int nextPlayer = (currentPlayerIndex + direction + totalPlayers) % totalPlayers;

            await Task.Delay(isBotVPlayerGame ? 1000 : 1);

            int cardToPlay;

            if (isBotVDemo && (currentPlayerIndex == 0 || currentPlayerIndex == 2))
            {
                cardToPlay = DemoBot.Think(playersHands[currentPlayerIndex], UnoLib.GetTopCardC(pool), playersHands[prevPlayer].Count, playersHands[nextPlayer].Count, totalPlayers, 5);
            }
            else
            {
                cardToPlay = MyBot.Think(playersHands[currentPlayerIndex], UnoLib.GetTopCardC(pool), playersHands[prevPlayer].Count, playersHands[nextPlayer].Count, totalPlayers, 5);
            }

            if (cardToPlay >= 0)
            {
                Card playedCard = playersHands[currentPlayerIndex][cardToPlay];
                UnoLib.PlayCard(cardToPlay, pool, playersHands[currentPlayerIndex]);
                RenderTopCard();
                RenderAllHands();
                HandleSpecialCard(playedCard);
                txtGameLog.AppendText($"Bot {currentPlayerIndex} played {playedCard.GetCard()}...\r\n");
                CheckForWin();
            }
            else
            {
                UnoLib.DrawCard(deck, playersHands[currentPlayerIndex], pool);
                txtGameLog.AppendText($"Bot {currentPlayerIndex} drew a card...\r\n");
                RenderAllHands();
            }
            NextTurn();
        }

        private void NextTurn()
        {
            currentPlayerIndex = (currentPlayerIndex + direction + totalPlayers) % totalPlayers;

            if (currentPlayerIndex == 0)
            {
                lblTurn.Text = "↓";
            } else if (currentPlayerIndex == 1)
            {
                lblTurn.Text = "←";
            } else if (currentPlayerIndex == 2)
            {
                lblTurn.Text = "↑";
            } else if (currentPlayerIndex == 3)
            {
                lblTurn.Text = "→";
            }

            if (currentPlayerIndex == 0 && !isBotVSelf)
            {
                txtGameLog.AppendText("Player's turn.\r\n");
            }
            else
            {
                BotTurn();
            }
        }

        private void HandleSpecialCard(Card card)
        {
            if (card.value == 'R')
            {
                direction *= -1;
                txtGameLog.AppendText("Reverse played. Changing direction.\r\n");
            }
            else if (card.value == 'S')
            {
                txtGameLog.AppendText("Skip played. Skipping next player.\r\n");
                currentPlayerIndex = (currentPlayerIndex + direction + totalPlayers) % totalPlayers;
            }
            else if (card.value == 'F')
            {
                int nextPlayer = (currentPlayerIndex + direction + totalPlayers) % totalPlayers;
                txtGameLog.AppendText($"Player {nextPlayer} drew 4 cards.\r\n");
                UnoLib.DrawCard(deck, playersHands[nextPlayer], pool);
                UnoLib.DrawCard(deck, playersHands[nextPlayer], pool);
                UnoLib.DrawCard(deck, playersHands[nextPlayer], pool);
                UnoLib.DrawCard(deck, playersHands[nextPlayer], pool);
                RenderAllHands(false, nextPlayer);
            }
            else if (card.value == 'T')
            {
                int nextPlayer = (currentPlayerIndex + direction + totalPlayers) % totalPlayers;
                txtGameLog.AppendText($"Player {nextPlayer} drew 2 cards.\r\n");
                UnoLib.DrawCard(deck, playersHands[nextPlayer], pool);
                UnoLib.DrawCard(deck, playersHands[nextPlayer], pool);
                RenderAllHands(false, nextPlayer);
            }
        }

        private void CheckForWin()
        {
            for (int i = 0; i < totalPlayers; i++)
            {
                if (playersHands[i].Count == 0)
                {
                    string winner = i == 0 && !isBotVSelf ? "Player" : $"Bot {i}";
                    MessageBox.Show($"{winner} wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
            }
        }

        private Image CardToImage(string cardText)
        {
            string imageFileName;
            string projectRoot;
            string imageDir;
            if (cardText == "Back")
            {
                imageFileName = $"BACK.png";
                projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                imageDir = Path.Combine(projectRoot, "lib", "sprites", imageFileName);

                // Load and return the image
                if (File.Exists(imageDir))
                {
                    return Image.FromFile(imageDir);
                }
                else
                {
                    MessageBox.Show($"Image file not found: {imageDir}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            if (string.IsNullOrEmpty(cardText) || cardText.Length < 2)
                return null;

            char card = cardText[0];
            char color = cardText[1];

            // Construct the image path
            imageFileName = $"{color}{card}.png";
            projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
            imageDir = Path.Combine(projectRoot, "lib", "sprites", imageFileName);

            // Load and return the image
            if (File.Exists(imageDir))
            {
                return Image.FromFile(imageDir);
            }
            else
            {
                MessageBox.Show($"Image file not found: {imageDir}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            imgHelp.Visible = true;
            btnCloseHelp.Visible = true;
        }

        private void btnCloseHelp_Click(object sender, EventArgs e)
        {
            imgHelp.Visible = false;
            btnCloseHelp.Visible = false;
        }

        private void btnBotVsDemo_Click(object sender, EventArgs e)
        {
            panelPlayerHand.Controls.Clear();
            panelOpponentHand1.Controls.Clear();
            panelOpponentHand2.Controls.Clear();
            panelOpponentHand3.Controls.Clear();

            lblPlayerCards.Text = "";
            lblBot1Cards.Text = "";
            lblBot2Cards.Text = "";
            lblBot3Cards.Text = "";

            isBotVPlayerGame = false;
            isBotVSelf = true;
            isBotVDemo = true;

            totalPlayers = 4;
            txtGameLog.AppendText("Starting game: Bots vs Bots...\r\n");
            deck = UnoLib.InitBoard();
            txtGameLog.AppendText("Shuffling deck...\r\n");
            UnoLib.ShuffleDeck(deck);

            pool = new List<Card>();
            playersHands.Clear();
            for (int i = 0; i < totalPlayers; i++)
            {
                playersHands.Add(UnoLib.GetHand(deck, pool));
            }

            Random random = new Random();
            currentPlayerIndex = random.Next(0, totalPlayers); // Randomly decide who starts

            if (currentPlayerIndex == 0)
            {
                lblTurn.Text = "↓";
            }
            else if (currentPlayerIndex == 1)
            {
                lblTurn.Text = "←";
            }
            else if (currentPlayerIndex == 2)
            {
                lblTurn.Text = "↑";
            }
            else if (currentPlayerIndex == 3)
            {
                lblTurn.Text = "→";
            }

            txtGameLog.AppendText($"Bot {currentPlayerIndex} starts.\r\n");
            pool.Add(deck[0]);
            deck.RemoveAt(0);
            RenderTopCard();
            RenderAllHands(true);

            BotTurn();

        }

        private void btnBotVsBot_Click(object sender, EventArgs e)
        {
            panelPlayerHand.Controls.Clear();
            panelOpponentHand1.Controls.Clear();
            panelOpponentHand2.Controls.Clear();
            panelOpponentHand3.Controls.Clear();

            lblPlayerCards.Text = "";
            lblBot1Cards.Text = "";
            lblBot2Cards.Text = "";
            lblBot3Cards.Text = "";

            isBotVPlayerGame = false;
            isBotVSelf = true;
            totalPlayers = 4;
            txtGameLog.AppendText("Starting game: Bots vs Bots...\r\n");
            deck = UnoLib.InitBoard();
            txtGameLog.AppendText("Shuffling deck...\r\n");
            UnoLib.ShuffleDeck(deck);

            pool = new List<Card>();
            playersHands.Clear();
            for (int i = 0; i < totalPlayers; i++)
            {
                playersHands.Add(UnoLib.GetHand(deck, pool));
            }

            Random random = new Random();
            currentPlayerIndex = random.Next(0, totalPlayers); // Randomly decide who starts

            if (currentPlayerIndex == 0)
            {
                lblTurn.Text = "↓";
            }
            else if (currentPlayerIndex == 1)
            {
                lblTurn.Text = "←";
            }
            else if (currentPlayerIndex == 2)
            {
                lblTurn.Text = "↑";
            }
            else if (currentPlayerIndex == 3)
            {
                lblTurn.Text = "→";
            }

            txtGameLog.AppendText($"Bot {currentPlayerIndex} starts.\r\n");
            pool.Add(deck[0]);
            deck.RemoveAt(0);
            RenderTopCard();
            RenderAllHands(true);

            BotTurn();
            
        }
    }
}
