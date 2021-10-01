using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represents the tarot board.
public class Board : MonoBehaviour
{
    // Story template for each theme
    private Dictionary<string, string[]> story_templates = new Dictionary<string, string[]>();

    // Orientation of a card for each theme
    private Dictionary<string, string[]> story_spreads = new Dictionary<string, string[]>();

    // Punctuations used for each theme
    private Dictionary<string, string[]> punctuations = new Dictionary<string, string[]>();

    // Verb tenses used for each theme
    private Dictionary<string, string[]> tenses = new Dictionary<string, string[]>();

    // Darama arc = each card is associated with each spot in the arc
    private string[] arc = new string[] {"Inciting Incident", "Complication", "Crisis", "Climax", "Resolution"};

    private List<Card> card_deck = new List<Card>();

    private Card[] five_choosen_cards = new Card[5];

    private string current_theme;

    private void initialize() {
        // Initialize stroy templates
        story_templates.Add(Constants.COMEDY, new string[] {"Jack is the best in the world at one thing: ",
                                                    "But when Jack ",
                                                    "they ",
                                                    "Now it's up to their best friend Jill to ",
                                                    "and in doing so help Jack "});
        story_templates.Add(Constants.TRAGEDY, new string[] {"Jack wants most of all to ",
                                                    "and all they need to do to get there is ",
                                                    "Things are looking up in response, and Jack finds themselves ",
                                                    "But then the tide turns and Jack ",
                                                    "In the end, Jack loses the battle and is remembered only for "});

        // Initialize story spreads
        story_spreads.Add(Constants.COMEDY, new string[] {"light", "shadow", "shadow", "light", "light"});
        story_spreads.Add(Constants.TRAGEDY, new string[] {"light", "shadow", "light", "shadow", "shadow"});

        // Initialize punctuations
        punctuations.Add(Constants.COMEDY, new string[] {".\n", ", ", ".\n", ", ", ".\n"});
        punctuations.Add(Constants.TRAGEDY, new string[] {", ", ".\n", ".\n", ".\n", ".\n"});

        // Initialize verb tenses
        tenses.Add(Constants.COMEDY, new string[] {"present_participle", "present", "infinitive", "infinitive", "infinitive"});
        tenses.Add(Constants.TRAGEDY, new string[] {"infinitive", "infinitive", "present_participle", "present", "present_participle"});

        // Create a deck of cards
        
    }

    // Randomly chooses the theme of the story
    public void pickTheme() {
        
    }

    // Generates a deck of cards.
    public void geneateCardDeck() {

    }

    // Picks a new set of 5 cards. It removes the chosen cards from the deck.
    // This method is bound to the "New Spread" button.
    public void newSpread() {
        // Calls the pickTheme() method at first

        // Calls updateStory(), updateTagine(), and displayCards() at the end
    }

    // Picks a new card. It removes the chosen card from the deck
    // This method is bound to the "New Card" button for each card.
    public void newCard() {

        // Calls updateStory(), updateTagine(), and displayCards() at the end
    }

    // Updates the story.
    public void updateStory() {

    }

    // Updates the tagline.
    public void updateTagline() {

    }

    // Display the selected 5 card images on the board.
    public void displayCards() {

    }

    // Start is called before the first frame update
    void Start()
    {
        // Call sequence to initialize the board
        // 1. pickTheme()
        // 2. generateCardDeck()
        // 3. newSpread()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
