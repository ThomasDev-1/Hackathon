using System.Drawing;
using System.Windows.Forms;

namespace UNO_Game_API
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCloseHelp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHumanVBot = new System.Windows.Forms.Button();
            this.txtGameLog = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBotVsDemo = new System.Windows.Forms.Button();
            this.btnBotVsBot = new System.Windows.Forms.Button();
            this.btnHumanVsHuman = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainGamePanel = new System.Windows.Forms.Panel();
            this.lblBot2Cards = new System.Windows.Forms.Label();
            this.lblPlayerCards = new System.Windows.Forms.Label();
            this.lblBot3Cards = new System.Windows.Forms.Label();
            this.lblBot1Cards = new System.Windows.Forms.Label();
            this.panelOpponentHand3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelOpponentHand1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelOpponentHand2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCenterArea = new System.Windows.Forms.Panel();
            this.lblTurn = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelPlayerHand = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTipController = new System.Windows.Forms.ToolTip(this.components);
            this.imgHelp = new System.Windows.Forms.PictureBox();
            this.panelSidebar.SuspendLayout();
            this.mainGamePanel.SuspendLayout();
            this.panelCenterArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelSidebar.Controls.Add(this.btnHelp);
            this.panelSidebar.Controls.Add(this.btnCloseHelp);
            this.panelSidebar.Controls.Add(this.label1);
            this.panelSidebar.Controls.Add(this.btnHumanVBot);
            this.panelSidebar.Controls.Add(this.txtGameLog);
            this.panelSidebar.Controls.Add(this.btnExit);
            this.panelSidebar.Controls.Add(this.btnBotVsDemo);
            this.panelSidebar.Controls.Add(this.btnBotVsBot);
            this.panelSidebar.Controls.Add(this.btnHumanVsHuman);
            this.panelSidebar.Controls.Add(this.lblTitle);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(295, 502);
            this.panelSidebar.TabIndex = 2;
            // 
            // btnHelp
            // 
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnHelp.Location = new System.Drawing.Point(254, 31);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(28, 36);
            this.btnHelp.TabIndex = 14;
            this.btnHelp.Text = "?";
            this.toolTipController.SetToolTip(this.btnHelp, "Help");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCloseHelp
            // 
            this.btnCloseHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseHelp.ForeColor = System.Drawing.Color.Crimson;
            this.btnCloseHelp.Location = new System.Drawing.Point(4, 5);
            this.btnCloseHelp.Name = "btnCloseHelp";
            this.btnCloseHelp.Size = new System.Drawing.Size(28, 36);
            this.btnCloseHelp.TabIndex = 13;
            this.btnCloseHelp.Text = "X";
            this.toolTipController.SetToolTip(this.btnCloseHelp, "Exit help");
            this.btnCloseHelp.UseVisualStyleBackColor = true;
            this.btnCloseHelp.Visible = false;
            this.btnCloseHelp.Click += new System.EventHandler(this.btnCloseHelp_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(38, 266);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 48);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tip: Replace the demo bots code with an old version of your bots code, to evaluat" +
    "e improvements.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHumanVBot
            // 
            this.btnHumanVBot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHumanVBot.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.btnHumanVBot.Location = new System.Drawing.Point(38, 98);
            this.btnHumanVBot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHumanVBot.Name = "btnHumanVBot";
            this.btnHumanVBot.Size = new System.Drawing.Size(222, 48);
            this.btnHumanVBot.TabIndex = 11;
            this.btnHumanVBot.Text = "Human vs Bot";
            this.toolTipController.SetToolTip(this.btnHumanVBot, "Play one (1) human against 3 (three) of your bot.\r\nBots cards are not visible.");
            this.btnHumanVBot.UseVisualStyleBackColor = true;
            this.btnHumanVBot.Click += new System.EventHandler(this.btnHumanVBot_Click);
            // 
            // txtGameLog
            // 
            this.txtGameLog.AcceptsReturn = true;
            this.txtGameLog.AcceptsTab = true;
            this.txtGameLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtGameLog.ForeColor = System.Drawing.Color.LightGray;
            this.txtGameLog.Location = new System.Drawing.Point(38, 341);
            this.txtGameLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGameLog.Multiline = true;
            this.txtGameLog.Name = "txtGameLog";
            this.txtGameLog.ReadOnly = true;
            this.txtGameLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGameLog.Size = new System.Drawing.Size(224, 78);
            this.txtGameLog.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.IndianRed;
            this.btnExit.Location = new System.Drawing.Point(38, 445);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(222, 48);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.toolTipController.SetToolTip(this.btnExit, "It does what the button says.");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBotVsDemo
            // 
            this.btnBotVsDemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotVsDemo.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.btnBotVsDemo.Location = new System.Drawing.Point(38, 213);
            this.btnBotVsDemo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBotVsDemo.Name = "btnBotVsDemo";
            this.btnBotVsDemo.Size = new System.Drawing.Size(222, 48);
            this.btnBotVsDemo.TabIndex = 2;
            this.btnBotVsDemo.Text = "Bot vs Demo Bot";
            this.toolTipController.SetToolTip(this.btnBotVsDemo, "Play two (2) of your bot against two (2) of the demo bot.\r\nDemo bot plays random " +
        "moves. ");
            this.btnBotVsDemo.UseVisualStyleBackColor = true;
            this.btnBotVsDemo.Click += new System.EventHandler(this.btnBotVsDemo_Click);
            // 
            // btnBotVsBot
            // 
            this.btnBotVsBot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotVsBot.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.btnBotVsBot.Location = new System.Drawing.Point(38, 156);
            this.btnBotVsBot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBotVsBot.Name = "btnBotVsBot";
            this.btnBotVsBot.Size = new System.Drawing.Size(222, 48);
            this.btnBotVsBot.TabIndex = 1;
            this.btnBotVsBot.Text = "Bot vs Bot";
            this.toolTipController.SetToolTip(this.btnBotVsBot, "Play four (4) of your bot against eachother.\r\nAll of bots cards are visible.\r\nUse" +
        "ful for debugging and testing bot");
            this.btnBotVsBot.UseVisualStyleBackColor = true;
            this.btnBotVsBot.Click += new System.EventHandler(this.btnBotVsBot_Click);
            // 
            // btnHumanVsHuman
            // 
            this.btnHumanVsHuman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHumanVsHuman.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.btnHumanVsHuman.Location = new System.Drawing.Point(38, 404);
            this.btnHumanVsHuman.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHumanVsHuman.Name = "btnHumanVsHuman";
            this.btnHumanVsHuman.Size = new System.Drawing.Size(222, 48);
            this.btnHumanVsHuman.TabIndex = 0;
            this.btnHumanVsHuman.Text = "Human vs Human";
            this.btnHumanVsHuman.UseVisualStyleBackColor = true;
            this.btnHumanVsHuman.Visible = false;
            this.btnHumanVsHuman.Click += new System.EventHandler(this.btnHumanVsHuman_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lblTitle.Location = new System.Drawing.Point(15, 22);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(267, 48);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "UNO Bot Center";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainGamePanel
            // 
            this.mainGamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.mainGamePanel.Controls.Add(this.lblBot2Cards);
            this.mainGamePanel.Controls.Add(this.lblPlayerCards);
            this.mainGamePanel.Controls.Add(this.lblBot3Cards);
            this.mainGamePanel.Controls.Add(this.lblBot1Cards);
            this.mainGamePanel.Controls.Add(this.panelOpponentHand3);
            this.mainGamePanel.Controls.Add(this.panelOpponentHand1);
            this.mainGamePanel.Controls.Add(this.panelOpponentHand2);
            this.mainGamePanel.Controls.Add(this.panelCenterArea);
            this.mainGamePanel.Controls.Add(this.panelPlayerHand);
            this.mainGamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGamePanel.Location = new System.Drawing.Point(295, 0);
            this.mainGamePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainGamePanel.Name = "mainGamePanel";
            this.mainGamePanel.Size = new System.Drawing.Size(752, 502);
            this.mainGamePanel.TabIndex = 1;
            // 
            // lblBot2Cards
            // 
            this.lblBot2Cards.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBot2Cards.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lblBot2Cards.Location = new System.Drawing.Point(374, 103);
            this.lblBot2Cards.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBot2Cards.Name = "lblBot2Cards";
            this.lblBot2Cards.Size = new System.Drawing.Size(97, 48);
            this.lblBot2Cards.TabIndex = 9;
            this.lblBot2Cards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerCards
            // 
            this.lblPlayerCards.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPlayerCards.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lblPlayerCards.Location = new System.Drawing.Point(374, 351);
            this.lblPlayerCards.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerCards.Name = "lblPlayerCards";
            this.lblPlayerCards.Size = new System.Drawing.Size(97, 48);
            this.lblPlayerCards.TabIndex = 8;
            this.lblPlayerCards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBot3Cards
            // 
            this.lblBot3Cards.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBot3Cards.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lblBot3Cards.Location = new System.Drawing.Point(583, 222);
            this.lblBot3Cards.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBot3Cards.Name = "lblBot3Cards";
            this.lblBot3Cards.Size = new System.Drawing.Size(83, 48);
            this.lblBot3Cards.TabIndex = 7;
            this.lblBot3Cards.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBot1Cards
            // 
            this.lblBot1Cards.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBot1Cards.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lblBot1Cards.Location = new System.Drawing.Point(88, 225);
            this.lblBot1Cards.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBot1Cards.Name = "lblBot1Cards";
            this.lblBot1Cards.Size = new System.Drawing.Size(100, 48);
            this.lblBot1Cards.TabIndex = 6;
            this.lblBot1Cards.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelOpponentHand3
            // 
            this.panelOpponentHand3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelOpponentHand3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelOpponentHand3.Location = new System.Drawing.Point(674, 2);
            this.panelOpponentHand3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelOpponentHand3.Name = "panelOpponentHand3";
            this.panelOpponentHand3.Size = new System.Drawing.Size(75, 498);
            this.panelOpponentHand3.TabIndex = 5;
            // 
            // panelOpponentHand1
            // 
            this.panelOpponentHand1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelOpponentHand1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelOpponentHand1.Location = new System.Drawing.Point(5, 2);
            this.panelOpponentHand1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelOpponentHand1.Name = "panelOpponentHand1";
            this.panelOpponentHand1.Size = new System.Drawing.Size(75, 498);
            this.panelOpponentHand1.TabIndex = 4;
            // 
            // panelOpponentHand2
            // 
            this.panelOpponentHand2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelOpponentHand2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelOpponentHand2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelOpponentHand2.Location = new System.Drawing.Point(88, 2);
            this.panelOpponentHand2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelOpponentHand2.Name = "panelOpponentHand2";
            this.panelOpponentHand2.Size = new System.Drawing.Size(578, 96);
            this.panelOpponentHand2.TabIndex = 1;
            // 
            // panelCenterArea
            // 
            this.panelCenterArea.Controls.Add(this.lblTurn);
            this.panelCenterArea.Controls.Add(this.pictureBox2);
            this.panelCenterArea.Controls.Add(this.pictureBox1);
            this.panelCenterArea.Location = new System.Drawing.Point(272, 176);
            this.panelCenterArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelCenterArea.Name = "panelCenterArea";
            this.panelCenterArea.Size = new System.Drawing.Size(240, 135);
            this.panelCenterArea.TabIndex = 2;
            // 
            // lblTurn
            // 
            this.lblTurn.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTurn.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lblTurn.Location = new System.Drawing.Point(98, 46);
            this.lblTurn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(41, 48);
            this.lblTurn.TabIndex = 10;
            this.lblTurn.Text = "^";
            this.lblTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::UNO_Game_API.Properties.Resources.BLANK;
            this.pictureBox2.Location = new System.Drawing.Point(146, 22);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 98);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UNO_Game_API.Properties.Resources.BACK;
            this.pictureBox1.Location = new System.Drawing.Point(15, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.lblDrawPile_Click);
            // 
            // panelPlayerHand
            // 
            this.panelPlayerHand.AutoScroll = true;
            this.panelPlayerHand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelPlayerHand.Location = new System.Drawing.Point(88, 404);
            this.panelPlayerHand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelPlayerHand.Name = "panelPlayerHand";
            this.panelPlayerHand.Size = new System.Drawing.Size(578, 96);
            this.panelPlayerHand.TabIndex = 3;
            // 
            // imgHelp
            // 
            this.imgHelp.Image = global::UNO_Game_API.Properties.Resources.HowToPlay;
            this.imgHelp.Location = new System.Drawing.Point(235, 1);
            this.imgHelp.Name = "imgHelp";
            this.imgHelp.Size = new System.Drawing.Size(809, 502);
            this.imgHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgHelp.TabIndex = 11;
            this.imgHelp.TabStop = false;
            this.imgHelp.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1047, 502);
            this.ControlBox = false;
            this.Controls.Add(this.imgHelp);
            this.Controls.Add(this.mainGamePanel);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UNO";
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.mainGamePanel.ResumeLayout(false);
            this.panelCenterArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnHumanVsHuman;
        private System.Windows.Forms.Button btnBotVsBot;
        private System.Windows.Forms.Button btnBotVsDemo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel mainGamePanel;

        // Additional UI controls inside Form1.Designer.cs
        private System.Windows.Forms.FlowLayoutPanel panelOpponentHand2;
        private System.Windows.Forms.FlowLayoutPanel panelPlayerHand;
        private System.Windows.Forms.Panel panelCenterArea;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox txtGameLog;
        private Button btnHumanVBot;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private FlowLayoutPanel panelOpponentHand1;
        private FlowLayoutPanel panelOpponentHand3;
        private Label lblBot2Cards;
        private Label lblPlayerCards;
        private Label lblBot3Cards;
        private Label lblBot1Cards;
        private Label lblTurn;
        private ToolTip toolTipController;
        private Label label1;
        private Button btnHelp;
        private Button btnCloseHelp;
        private PictureBox imgHelp;
    }
}
