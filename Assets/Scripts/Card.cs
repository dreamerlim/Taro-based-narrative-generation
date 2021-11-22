using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represents a Card Object.
public class Card
{
    // Name of the card
    public string name {get; set;}

    // Rank of the card
    public string rank {get; set;}

    // Suit of the card
    public string suit {get; set;}

    // Keywords of the card
    public List<string> keywords = new List<string>();

    // Fortune telling of the card
    // private Dictionary<string, List<string>> fortune_telling;
    public List<string> fortune_telling = new List<string>();

    // Stories of the card
    public Dictionary<string, string[]> story;

    // Meanings of the card
    public Dictionary<string, List<string>> meanings;

    public Card() {}

    public void setKeywords(List<string> keywords) {
        this.keywords = keywords;
    }

    public List<string> getKeywords() {
        return this.keywords;
    }

    public void setFortuneTelling(List<string> fortune_telling) {
        this.fortune_telling = fortune_telling;
    }

    public List<string> getFortuneTelling() {
        return this.fortune_telling;
    }

    public void setStory(Dictionary<string, string[]> story) {
        this.story = story;
    }

    public Dictionary<string, string[]> getStory() {
        return this.story;
    }

    public void setMeanings(Dictionary<string, List<string>> meanings) {
        this.meanings = meanings;
    }

    public Dictionary<string, List<string>> getMeanings() {
        return this.meanings;
    }

    public void print() {
        // Debug.Log("Name: " + this.name);
        // Debug.Log("Rank: " + this.rank);
        // Debug.Log("Suit: " + this.suit);
        // // Debug.Log(this.story["light"]);
        // // Debug.Log(this.meanings["light"]);
        // Debug.Log("Keywords:");
        // for (int i = 0; i < this.keywords.Count; ++i) {
        //     Debug.Log(this.keywords[i]);
        // }

        // Debug.Log("Fortune Telling:");
        // for (int i = 0; i < this.fortune_telling.Count; ++i) {
        //     Debug.Log(this.fortune_telling[i]);
        // }

        // Debug.Log("Story:");
        // foreach (KeyValuePair<string, string[]> entry in this.story) {
        //     Debug.Log(entry.Key);
        //     for (int i = 0; i < entry.Value.Length; ++i) {
        //         Debug.Log(entry.Value[i]);
        //     }
        // }
    
        // Debug.Log("Meanings:");
        // foreach (KeyValuePair<string, List<string>> entry in this.meanings) {
        //     Debug.Log(entry.Key);
        //     for (int i = 0; i < entry.Value.Count; ++i) {
        //         Debug.Log(entry.Value[i]);
        //     }
        // }

        // Debug.Log("---------------------------------------------------");
    }

}
