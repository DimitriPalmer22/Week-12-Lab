using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Task3 : MonoBehaviour
{
    // Enum for the face of the card
    private enum Honor
    {
        Jack,
        Queen,
        King,
        Ace,
    }

    // Enum for the suit of the card
    private enum Suit
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs,
    }


    // A struct to represent a card
    private struct Card
    {
        public Honor honor;
        public Suit suit;

        public Card(Honor honor, Suit suit)
        {
            this.honor = honor;
            this.suit = suit;
        }

        // A function to represent the card as a string. This is used to log the card
        public override string ToString()
        {
            char suitSymbol = suit switch
            {
                Suit.Hearts => '♥',
                Suit.Diamonds => '♦',
                Suit.Spades => '♠',
                Suit.Clubs => '♣',
                _ => ' '
            };

            return $"{honor.ToString()[0]}{suitSymbol}";
        }
    }

    private string GetHandString(List<Card> hand)
    {
        var handString = string.Empty;

        foreach (var card in hand)
            handString += $"{card} ";
        
        return handString;
    }

    // A function to shuffle the stack of cards
    private void ShuffleDeck(Stack<Card> deck)
    {
        // Create a list to store all the cards
        List<Card> cardList = new List<Card>();
        
        // Pop all the cards from the stack and add them to the list
        while (deck.Count > 0)
            cardList.Add(deck.Pop());

        // Add random cards back to the stack until the list is empty
        while (cardList.Count > 0)
        {
            // Get a random card from the list
            int cardIndex = Random.Range(0, cardList.Count);
            Card randomCard = cardList[cardIndex];

            // Add the card to the stack
            deck.Push(randomCard);

            // Remove the card from the list
            cardList.RemoveAt(cardIndex);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TASK 3:");

        // Create a stack to represent the deck of cards
        Stack<Card> deck = new Stack<Card>();

        // Add a card of each honor and suit to the deck
        for (int honorInt = 0; honorInt < 4; honorInt++)
        {
            for (int suitInt = 0; suitInt < 4; suitInt++)
            {
                // Create a card
                Card card = new Card((Honor) honorInt, (Suit) suitInt);

                // add the card to the deck
                deck.Push(card);
            }
        }
        
        // Shuffle the deck
        ShuffleDeck(deck);
        
        // Create a list to represent the player's hand
        List<Card> hand = new List<Card>();

        // Draw 4 cards from the deck
        for (int i = 0; i < 4; i++)
        {
            // Draw a card from the deck
            Card card = deck.Pop();

            // Add the card to the player's hand
            hand.Add(card);
        }
        
        // Print the cards in the player's hand
        Debug.Log($"This is my starting hand: {GetHandString(hand)}");

        // Keep looping until the player has three of a suit or the deck is empty
        while (!ThreeOfASuit(hand) && deck.Count > 0)
        {
            // Discard a random card from the hand and draw a new card
            int cardIndex = Random.Range(0, hand.Count);

            // Get the card to be removed
            var removedCard = hand[cardIndex];

            // Remove the card from the hand 
            hand.Remove(removedCard);

            // Draw a new card from the deck
            var addedCard = deck.Pop();
            hand.Add(addedCard);

            // Log the discarded and drawn cards
            Debug.Log($"Discarded {removedCard} and drew {addedCard}. This is my hand: {GetHandString(hand)}");
        }

        // Check if the player has three of a suit
        if (ThreeOfASuit(hand))
            Debug.Log("Player has three of a suit!");
        else
            Debug.Log("Player does not have three of a suit!");
    }


    private bool ThreeOfASuit(List<Card> hand)
    {
        // Count each suit in the hand using a dictionary
        Dictionary<Suit, int> suitCount = new Dictionary<Suit, int>();

        // Initialize the suit count
        suitCount.Add(Suit.Hearts, 0);
        suitCount.Add(Suit.Diamonds, 0);
        suitCount.Add(Suit.Spades, 0);
        suitCount.Add(Suit.Clubs, 0);

        // Go through the hand and count the suits
        foreach (Card card in hand)
        {
            // Increment the count of the suit
            suitCount[card.suit]++;
        }

        // Check if any of the suits have 3 cards
        foreach (var suit in suitCount)
        {
            if (suit.Value >= 3)
                return true;
        }

        return false;
    }
}