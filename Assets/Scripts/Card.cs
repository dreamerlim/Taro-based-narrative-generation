using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represents a Card Object.
public class Card : MonoBehaviour
{
    // Name of the card
    public string name {get; set;}

    // Rank of the card
    public string rank {get; set;}

    // Suit of the card
    public string suit {get; set;}

    // Keywords of the card
    private List<string> keywords = new List<string>();

    // Fortune telling of the card
    private Dictionary<string, List<string>> fortune_telling;

    // Stories of the card
    private Dictionary<string, string[]> story;

    // Meanings of the card
    private Dictionary<string, List<string>> meanings;

    public Card() {}


}
