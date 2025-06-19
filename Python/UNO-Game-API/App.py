from UnoGame import UnoLib

deck = UnoLib.init_board()
pool = []
hand = []

def print_game():
    print("Top card:")
    print(UnoLib.get_top_card(pool))
    print("Your hand:")

    for card in hand:
        print(card.get_card())

while True:
    operation = int(input("Enter operation (1 : Shuffle, 2: Deal, 3: Draw):"))

    if operation == 1:
        UnoLib.shuffle_deck(deck)
        print("Deck shuffled")
        print_game()
    elif operation == 2:
        hand = UnoLib.get_hand(deck, pool)
        print_game()
    elif operation == 3:
        UnoLib.draw_card(deck, hand, pool)
        print_game()
