import tkinter as tk
from tkinter import messagebox, scrolledtext

class UnoBotCenter(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("UNO Bot Center")
        self.geometry("1050x500")
        self.configure(bg="#1E1E1E")
        self.resizable(False, False)

        # === Left Sidebar ===
        self.sidebar = tk.Frame(self, bg="#282828", width=295, height=500)
        self.sidebar.place(x=0, y=0)

        self.create_sidebar_contents()

        # === Main Game Panel ===
        self.game_panel = tk.Frame(self, bg="#1E1E1E", width=755, height=500)
        self.game_panel.place(x=295, y=0)

        self.create_game_panel()

    def create_sidebar_contents(self):
        # Title Label
        title = tk.Label(self.sidebar, text="UNO Bot Center", font=("Segoe UI", 18, "bold"),
                         fg="MediumSpringGreen", bg="#282828")
        title.place(x=20, y=20)

        # Help Button (Top Right)
        help_btn = tk.Button(self.sidebar, text="?", font=("Segoe UI", 12, "bold"), fg="MediumSeaGreen",
                             bg="#282828", bd=0, highlightthickness=0, activebackground="#282828",
                             command=self.show_help)
        help_btn.place(x=255, y=20, width=30, height=30)

        # Buttons
        self.make_sidebar_button("Human vs Bot", self.human_vs_bot, y=80)
        self.make_sidebar_button("Bot vs Bot", self.bot_vs_bot, y=130)
        self.make_sidebar_button("Bot vs Demo Bot", self.bot_vs_demo_bot, y=180)

        # Hidden Button (disabled by default)
        self.human_vs_human_btn = self.make_sidebar_button("Human vs Human", self.human_vs_human, y=230, show=False)

        # Tip Label
        tip_text = "Tip: Replace the demo bots code with an old version of your bots code, to evaluate improvements."
        tip = tk.Label(self.sidebar, text=tip_text, font=("Segoe UI", 8, "bold"), fg="dim gray",
                       bg="#282828", wraplength=240, justify="center")
        tip.place(x=27, y=260)

        # Game Log Textbox
        self.log_box = scrolledtext.ScrolledText(self.sidebar, height=6, width=36,
                                                 bg="#141414", fg="lightgray", font=("Segoe UI", 9))
        self.log_box.place(x=20, y=320)
        self.log_box.configure(state='disabled')

        # Exit Button
        self.make_sidebar_button("Exit", self.exit_app, y=445, fg="IndianRed")

    def make_sidebar_button(self, text, command, y=0, fg="MediumSpringGreen", show=True):
        if not show:
            return None
        btn = tk.Button(self.sidebar, text=text, font=("Segoe UI", 10, "bold"),
                        fg=fg, bg="#282828", activebackground="#383838",
                        bd=0, highlightthickness=0, command=command)
        btn.place(x=30, y=y, width=235, height=40)
        return btn

    def create_game_panel(self):
        # Top: Bot 2 label
        self.lbl_bot2_cards = tk.Label(self.game_panel, text="Bot2: 7", font=("Segoe UI", 14, "bold"),
                                       fg="MediumSpringGreen", bg="#1E1E1E")
        self.lbl_bot2_cards.place(x=350, y=20)

        # Bottom: Player label
        self.lbl_player_cards = tk.Label(self.game_panel, text="You: 7", font=("Segoe UI", 14, "bold"),
                                         fg="MediumSpringGreen", bg="#1E1E1E")
        self.lbl_player_cards.place(x=350, y=455)

        # Placeholder: Game table (optional to draw later)
        # You can draw canvas zones for center play here

    # === Button Handlers ===
    def show_help(self):
        messagebox.showinfo("Help", "Help content goes here.")

    def human_vs_bot(self):
        self.log_box.configure(state='normal')
        self.append_log("▶ Starting Human vs Bot...")
        self.log_box.configure(state='disabled')

    def bot_vs_bot(self):
        self.log_box.configure(state='normal')
        self.append_log("▶ Starting Bot vs Bot...")
        self.log_box.configure(state='disabled')

    def bot_vs_demo_bot(self):
        self.log_box.configure(state='normal')
        self.append_log("▶ Starting Bot vs Demo Bot...")
        self.log_box.configure(state='disabled')

    def human_vs_human(self):
        self.log_box.configure(state='normal')
        self.append_log("▶ Starting Human vs Human...")
        self.log_box.configure(state='disabled')

    def exit_app(self):
        self.quit()

    def append_log(self, text):
        self.log_box.insert(tk.END, text + "\n")
        self.log_box.see(tk.END)


if __name__ == "__main__":
    app = UnoBotCenter()
    app.mainloop()
