using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

// how to use SimpleJSON
// Original Implementation
// https://github.com/annetropy/tarot-narrative/blob/master/tarot/code/tarot.js
// The dir that contains all the json files needs to be on the same as the "Assests" dir.
// Use the 'tarot-story.json' file
// Need to remove "Monobehaviour" to avoid a warning
// This class parses a deck of tarot cards that is in json file format.
// After it parses, it creates a deck of card objects.
public class Parser : MonoBehaviour
{

    // Converts a string verb tense into its corresponding enum int value,
    // which is going to be used as an index.
    int string2VerbTenseIndex(string tense_str) {
        switch (tense_str) {
            case "past":
                return (int)Constants.VerbTense.past;
            case "infinitive":
                return (int)Constants.VerbTense.infinitive;
            case "present_participle":
                return (int)Constants.VerbTense.present_participle;
            case "present":
                return (int)Constants.VerbTense.present;
            default:
                return -1;
        }
    }
    
    // Converts a JSONNode into a List.
    List<string> convertJsonNode2List(SimpleJSON.JSONNode entry) {
        List<string> new_list = new List<string>();

        for (int i = 0; i < entry.Count; ++i) {
            new_list.Add(entry[i]);
        }

        return new_list;
    }

    // Extracts the story elements and set it as its correspoding card's story.
    void processStory(SimpleJSON.JSONNode entry, Card card_obj) {
        int tense_index;

        string[] light_story = new string[4];
    
        // Add light stories
        foreach (KeyValuePair<string, JSONNode> kvp in (JSONObject)entry["light"]) {
            tense_index = string2VerbTenseIndex(kvp.Key);
            if (tense_index != -1) {
                light_story[tense_index] = kvp.Value;
            }
        }

        string[] shadow_story = new string[4];

        // Add shadow stories
        foreach (KeyValuePair<string, JSONNode> kvp in (JSONObject)entry["shadow"]) {
            tense_index = string2VerbTenseIndex(kvp.Key);
            if (tense_index != -1) {
                shadow_story[tense_index] = kvp.Value;
            }
        }

        Dictionary<string, string[]> story = new Dictionary<string, string[]>();

        story.Add("light", light_story);
        story.Add("shadow", shadow_story);

        card_obj.setStory(story);
    }

    // Extracts the meanings elements and set it as its corresponding card's meanings.
    void processMeanings(SimpleJSON.JSONNode entry, Card card_obj) {
        List<string> light_meanings = new List<string>();

        // Add light meanings
        for (int i = 0; i < entry["light"].Count; ++i) {
            light_meanings.Add(entry["light"][i]);
        }

        List<string> shadow_meanings = new List<string>();

        // Add shadow meanings
        for (int i = 0; i < entry["shadow"].Count; ++i) {
            shadow_meanings.Add(entry["shadow"][i]);
        }

        Dictionary<string, List<string>> meanings = new Dictionary<string, List<string>>();

        meanings.Add("light", light_meanings);
        meanings.Add("shadow", shadow_meanings);

        card_obj.setMeanings(meanings);
    }

    // Creates a card and returns it.
    Card create_card(SimpleJSON.JSONNode entry) {
        Card new_card = new Card();

        // Can just get name, rank, and suit
        new_card.name = entry["name"].Value;
        new_card.rank = entry["rank"].Value;
        new_card.suit = entry["suit"].Value;

        // keywords and fortune tellings are just lists
        List<string> keywords = convertJsonNode2List(entry["keywords"]);
        new_card.setKeywords(keywords);

        List<string> fortune_telling = convertJsonNode2List(entry["fortune_telling"]);
        new_card.setFortuneTelling(fortune_telling);
        
        // stories and meanings use Dict for 2 different meanings: "light" and "shadow
        processMeanings(entry["meanings"], new_card);
        processStory(entry["story"], new_card);

        // new_card.print();

        return new_card;
    }

    // Creates a deck of card and returns it.
    List<Card> create_deck(string json_file_path) {
        List<Card> card_deck = new List<Card>();
        
        string jsonString = File.ReadAllText("json_files/tarot-story.json");
        var N = JSON.Parse(jsonString);
        int num_of_interpretations = N["tarot_interpretations"].Count;

        // Loop and add cards
        for (int i = 0; i < num_of_interpretations; ++i) {
            card_deck.Add(create_card(N["tarot_interpretations"][i]));
        }

        return card_deck;
    }

    // Start is called before the first frame update
    void Start()
    {
        string json_file_path = "json_files/tarot-story.json";
        List<Card> card_deck = create_deck(json_file_path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
