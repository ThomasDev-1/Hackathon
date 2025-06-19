import random

class UnoLib:
    @staticmethod
    def shuffle_deck(deck_to_shuffle):
        random.shuffle(deck_to_shuffle)

    @staticmethod
    def get_hand(deck_to_deal_from, current_game_pool):
        if len(deck_to_deal_from) < 8:
            UnoLib.merge_pool(deck_to_deal_from, current_game_pool)
            UnoLib.shuffle_deck(deck_to_deal_from)

        new_hand = []
        for i in range(min(7, len(deck_to_deal_from))):
            new_hand.append(deck_to_deal_from[0])
            deck_to_deal_from.pop(0)
        return new_hand

    @staticmethod
    def draw_card(deck_to_draw_from, hand_to_draw_to, current_game_pool):
        if len(deck_to_draw_from) < 8:
            UnoLib.merge_pool(deck_to_draw_from, current_game_pool)
            UnoLib.shuffle_deck(deck_to_draw_from)
        hand_to_draw_to.append(deck_to_draw_from[0])
        return_card = deck_to_draw_from[0]
        deck_to_draw_from.pop(0)

        return return_card

    @staticmethod
    def merge_pool(deck_to_merge, pool_to_merge):
        if len(pool_to_merge) == 0:
            return

        top_card = pool_to_merge.pop()
        deck_to_merge.extend(pool_to_merge)
        pool_to_merge.clear()
        pool_to_merge.append(top_card)

    @staticmethod
    def play_card(card_index, pool_to_play, hand_to_play_from):
        if card_index < len(hand_to_play_from):
            pool_to_play.append(hand_to_play_from[card_index])
            hand_to_play_from.pop(card_index)

    @staticmethod
    def get_legal_plays(hand, top_card, add_total=0):
        legal_cards = []

        if top_card is None:
            return hand

        # Handle stacking logic if in a penalty state
        if add_total > 0:
            for card in hand:
                if top_card.value == 'T' and (card.value == 'T' or card.value == 'F'):  # stack +2 or +4
                    legal_cards.append(card)
                elif top_card.value == 'F' and card.value == 'F':  # only +4 on +4
                    legal_cards.append(card)
            return legal_cards

        # Normal play logic
        if top_card.color == 'N':
            return hand
        for card in hand:
            if card.value == top_card.value or card.color == top_card.color or card.color == 'N':
                legal_cards.append(card)

        return legal_cards

    @staticmethod
    def get_top_card(pool_in_play):
        return pool_in_play[-1].get_card() if len(pool_in_play) > 0 else " "

    @staticmethod
    def get_top_card_c(pool_in_play):
        return pool_in_play[-1] if len(pool_in_play) > 0 else None

    @staticmethod
    def init_board():
        deck = [
            # Each color of card has 2 of type, but only ONE '0' card
            # Red cards
            Card('0', 'R'),
            Card('1', 'R'),
            Card('2', 'R'),
            Card('3', 'R'),
            Card('4', 'R'),
            Card('5', 'R'),
            Card('6', 'R'),
            Card('7', 'R'),
            Card('8', 'R'),
            Card('9', 'R'),
            Card('T', 'R'),  # +2 card
            Card('S', 'R'),  # Skip card
            Card('R', 'R'),  # Reverse card

            Card('1', 'R'),
            Card('2', 'R'),
            Card('3', 'R'),
            Card('4', 'R'),
            Card('5', 'R'),
            Card('6', 'R'),
            Card('7', 'R'),
            Card('8', 'R'),
            Card('9', 'R'),
            Card('T', 'R'),  # +2 card
            Card('S', 'R'),  # Skip card
            Card('R', 'R'),  # Reverse card

            # Blue cards
            Card('0', 'B'),
            Card('1', 'B'),
            Card('2', 'B'),
            Card('3', 'B'),
            Card('4', 'B'),
            Card('5', 'B'),
            Card('6', 'B'),
            Card('7', 'B'),
            Card('8', 'B'),
            Card('9', 'B'),
            Card('T', 'B'),  # +2 card
            Card('S', 'B'),  # Skip card
            Card('R', 'B'),  # Reverse card

            Card('1', 'B'),
            Card('2', 'B'),
            Card('3', 'B'),
            Card('4', 'B'),
            Card('5', 'B'),
            Card('6', 'B'),
            Card('7', 'B'),
            Card('8', 'B'),
            Card('9', 'B'),
            Card('T', 'B'),  # +2 card
            Card('S', 'B'),  # Skip card
            Card('R', 'B'),  # Reverse card

            # Yellow cards
            Card('0', 'Y'),
            Card('1', 'Y'),
            Card('2', 'Y'),
            Card('3', 'Y'),
            Card('4', 'Y'),
            Card('5', 'Y'),
            Card('6', 'Y'),
            Card('7', 'Y'),
            Card('8', 'Y'),
            Card('9', 'Y'),
            Card('T', 'Y'),  # +2 card
            Card('S', 'Y'),  # Skip card
            Card('R', 'Y'),  # Reverse card

            Card('1', 'Y'),
            Card('2', 'Y'),
            Card('3', 'Y'),
            Card('4', 'Y'),
            Card('5', 'Y'),
            Card('6', 'Y'),
            Card('7', 'Y'),
            Card('8', 'Y'),
            Card('9', 'Y'),
            Card('T', 'Y'),  # +2 card
            Card('S', 'Y'),  # Skip card
            Card('R', 'Y'),  # Reverse card

            # Green cards
            Card('0', 'G'),
            Card('1', 'G'),
            Card('2', 'G'),
            Card('3', 'G'),
            Card('4', 'G'),
            Card('5', 'G'),
            Card('6', 'G'),
            Card('7', 'G'),
            Card('8', 'G'),
            Card('9', 'G'),
            Card('T', 'G'),  # +2 card
            Card('S', 'G'),  # Skip card
            Card('R', 'G'),  # Reverse card

            Card('1', 'G'),
            Card('2', 'G'),
            Card('3', 'G'),
            Card('4', 'G'),
            Card('5', 'G'),
            Card('6', 'G'),
            Card('7', 'G'),
            Card('8', 'G'),
            Card('9', 'G'),
            Card('T', 'G'),  # +2 card
            Card('S', 'G'),  # Skip card
            Card('R', 'G'),  # Reverse card
        ]
        return deck


class Card:
    def __init__(self, value, color):
        self.value = value
        self.color = color

    def get_card(self):
        return str(self.value) + str(self.color)
