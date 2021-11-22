using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class represents the tarot board.
public class Board : MonoBehaviour
{
    // Story template for each theme
    public Dictionary<string, string[]> story_templates = new Dictionary<string, string[]>();

    // Orientation of a card for each theme
    public Dictionary<string, string[]> story_spreads = new Dictionary<string, string[]>();

    // Punctuations used for each theme
    public Dictionary<string, string[]> punctuations = new Dictionary<string, string[]>();

    // Verb tenses used for each theme
    public Dictionary<string, string[]> tenses = new Dictionary<string, string[]>();

    public string[] themes = new string[] {"comedy", "tragedy"};

    // Drama arc = each card is associated with each spot in the arc
    public string[] arc = new string[] {"Inciting Incident", "Complication", "Crisis", "Climax", "Resolution"};

    public string[] seasons = new string[] { "SPRING", "SUMMER", "FALL", "WINTER" };

    // private List<Card> card_deck = new List<Card>();
    public List<Card> card_deck;

    public Sprite[] cardSprite = new Sprite[5];
    public SpriteRenderer[] spriteR = new SpriteRenderer[5];

    //public Sprite backgroundSprite;
    public GameObject backgroundObject;
    public GameObject titleObject;
    public GameObject synopsis;
    public GameObject tagline;

    public Card[] five_chosen_cards = new Card[5];

    public GameObject[] cards = new GameObject[5];
    public GameObject[] cardInfoName = new GameObject[5];
    public GameObject[] cardInfoOri = new GameObject[5];

    public string current_theme;

    public string[] story = new string[5];
    public string tense;
    public string lightShadow;

    System.Random rand = new System.Random();

    public void initialize() {
        // Initialize stroy templates
        story_templates.Add("comedy", new string[] {"Jack is the best in the world at one thing: ",
                                                    "But when Jack ",
                                                    "they ",
                                                    "Now it's up to their best friend Jill to ",
                                                    "and in doing so help Jack "});
        story_templates.Add("tragedy", new string[] {"Jack wants most of all to ",
                                                    "and all they need to do to get there is ",
                                                    "Things are looking up in response, and Jack finds themselves ",
                                                    "But then the tide turns and Jack ",
                                                    "In the end, Jack loses the battle and is remembered only for "});

        // Initialize story spreads
        story_spreads.Add("comedy", new string[] {"light", "shadow", "shadow", "light", "light"});
        story_spreads.Add("tragedy", new string[] {"light", "shadow", "light", "shadow", "shadow"});

        // Initialize punctuations
        punctuations.Add("comedy", new string[] {".\n", ", ", ".\n", ", ", ".\n"});
        punctuations.Add("tragedy", new string[] {", ", ".\n", ".\n", ".\n", ".\n"});

        // Initialize verb tenses
        tenses.Add("comedy", new string[] {"present_participle", "present", "infinitive", "infinitive", "infinitive"}); // 2 3 1 1 1 
        tenses.Add("tragedy", new string[] {"infinitive", "infinitive", "present_participle", "present", "present_participle"}); // 1 1 2 3 2 

        //Debug.Log("initialize---- ");
        for (int i = 0; i < 5; i++)
        {
            cards[i] = GameObject.Find("Card"+(i+1).ToString());
            //cardInfo[i] = GameObject.Find("Card"+(i+1).ToString()+("_Info"));
            cardInfoName[i] = GameObject.Find("Card_Name"+(i+1).ToString());
            cardInfoOri[i] = GameObject.Find("Card_Orientation"+(i+1).ToString());
            //Debug.Log("initialize cards: " + cards[i]);
        }
        backgroundObject = GameObject.Find("Background");
        titleObject = GameObject.Find("Title");
        synopsis = GameObject.Find("Synopsis");
        tagline = GameObject.Find("Tagline");
    }

    // Randomly chooses the theme of the story
    public void pickTheme() {
        int theme_index = rand.Next(themes.Length);
        current_theme = themes[theme_index];

        //Debug.Log("pickTheme Currnet Theme: " + current_theme);

        if (current_theme == "tragedy")
        {
            backgroundObject.GetComponent<Image>().sprite  = Resources.Load<Sprite>("images/tragedybackground");
            titleObject.GetComponent<Text>().text = "A Story of Tragedy";
            cardInfoOri[0].GetComponent<Text>().text = "";
            cardInfoOri[1].GetComponent<Text>().text = "reversed";
            cardInfoOri[2].GetComponent<Text>().text = "";
            cardInfoOri[3].GetComponent<Text>().text = "reversed";
            cardInfoOri[4].GetComponent<Text>().text = "reversed";
        }
        else
        {
            backgroundObject.GetComponent<Image>().sprite  = Resources.Load<Sprite>("images/comedybackground");
            titleObject.GetComponent<Text>().text = "A Story of Comedy";
            cardInfoOri[0].GetComponent<Text>().text = "";
            cardInfoOri[1].GetComponent<Text>().text = "reversed";
            cardInfoOri[2].GetComponent<Text>().text = "reversed";
            cardInfoOri[3].GetComponent<Text>().text = "";
            cardInfoOri[4].GetComponent<Text>().text = "";
        }
    }

    // Generates a deck of cards.
    public void generateCardDeck() {
        Parser json_parser = new Parser();
        string json_file_path = "json_files/tarot-story.json";
        card_deck = json_parser.create_deck(json_file_path);
    }

    // Picks a new set of 5 cards. It removes the chosen cards from the deck.
    // This method is bound to the "New Spread" button.
    public void newSpread() {
        // only allow to do new spread if the card deck has enough cards
        if (card_deck.Count > 5) { 
            // Calls the pickTheme() method at first
            pickTheme();

            // 1. Get the size of the card deck
            // 2. Randomly pick a number within the size of the card deck 
            //    and choose the corresponding card with the same index number
            // 3. Add the chosen card to the "five_chosen_cards" and remove that card from the card deck list
            // 4. Repeat steps 2-3, 4 more times

            System.Random rand = new System.Random();
            int rand_index_num;
            for (int i = 0; i < 5; ++i) {
                rand_index_num = rand.Next(card_deck.Count);
                five_chosen_cards[i] = card_deck[rand_index_num];
                card_deck.RemoveAt(rand_index_num);
            }

            displayCards();
            updateStory();
            updateTagline();
            // Calls updateStory(), updateTagine(), and displayCards() at the end
        }
        
    }

    // Picks a new card. It removes the chosen card from the deck
    // This method is bound to the "New Card" button for each card.
    public void newCard(int card_index) {
        // only allow to pick a new card if the card deck has enough cards
        if (card_deck.Count > 1) {
            System.Random rand = new System.Random();
            int rand_index_num;
            rand_index_num = rand.Next(card_deck.Count);
            five_chosen_cards[card_index] = card_deck[rand_index_num];
            card_deck.RemoveAt(rand_index_num); // maybe don't remove the cards
        }

        displayCards();
        updateStory();
        updateTagline();
        // Calls updateStory(), updateTagine(), and displayCards() at the end
    }

    // Updates the story.
    public void updateStory()
    {
        //tenses.Add("comedy", new string[] { "present_participle", "present", "infinitive", "infinitive", "infinitive" }); // 2 3 1 1 1 
        //tenses.Add("tragedy", new string[] { "infinitive", "infinitive", "present_participle", "present", "present_participle" }); // 1 1 2 3 2 
        if (current_theme == "comedy")
        {
            story[0] = story_templates["comedy"][0]+five_chosen_cards[0].story["light"][2]+punctuations["comedy"][0];
            story[1] = story_templates["comedy"][1]+five_chosen_cards[1].story["shadow"][3]+punctuations["comedy"][1];
            story[2] = story_templates["comedy"][2]+five_chosen_cards[2].story["shadow"][1]+punctuations["comedy"][2];
            story[3] = story_templates["comedy"][3]+five_chosen_cards[3].story["light"][1]+punctuations["comedy"][3];
            story[4] = story_templates["comedy"][4]+five_chosen_cards[4].story["light"][1]+punctuations["comedy"][4];
        }
        else // tragedy
        {
            story[0] = story_templates["tragedy"][0]+five_chosen_cards[0].story["light"][1]+punctuations["tragedy"][0];
            story[1] = story_templates["tragedy"][1]+five_chosen_cards[1].story["shadow"][1]+punctuations["tragedy"][1];
            story[2] = story_templates["tragedy"][2]+five_chosen_cards[2].story["light"][2]+punctuations["tragedy"][2];
            story[3] = story_templates["tragedy"][3]+five_chosen_cards[3].story["shadow"][3]+punctuations["tragedy"][3];
            story[4] = story_templates["tragedy"][4]+five_chosen_cards[4].story["shadow"][2]+punctuations["tragedy"][4];            
        }
        //Debug.Log("storyyyyyyyyyyyyyy" + story);
        //Debug.Log("story0 " + story[0]);
        //Debug.Log("story1 " + story[1]);
        //Debug.Log("story2 " + story[2]);
        //Debug.Log("story3 " + story[3]);
        //Debug.Log("story4 " + story[4]);
        synopsis.GetComponent<Text>().text = story[0]+story[1]+story[2]+story[3]+story[4];
    }

    // Updates the tagline.
    public void updateTagline() {
        tagline.GetComponent<Text>().text = "THIS " + seasons[rand.Next(4)] +", " + five_chosen_cards[0].fortune_telling[rand.Next(five_chosen_cards[0].fortune_telling.Count)].ToUpper();
    }

    // Display the selected 5 card images on the board.
    public void displayCards() {
        for (int i = 0; i < 5; ++i) {
            string rank = five_chosen_cards[i].rank;
            string image_address;
            switch (rank)
            {
                case "page":
                    rank = "p";
                    break;
                case "knight":
                    rank = "n";
                    break;
                case "queen":
                    rank = "q";
                    break;
                case "king":
                    rank = "k";
                    break;
            }

            // coins are listed as pentacles in the filenames
            if (five_chosen_cards[i].suit == "coins")
                image_address = "images/cards/" + rank + "p";
            else
                image_address = "images/cards/" + rank + five_chosen_cards[i].suit[0];

            //Debug.Log("displayCards card: " +i + " image_address: "+ image_address);
            cardSprite[i] = Resources.Load<Sprite>(image_address);
            spriteR[i] = cards[i].GetComponent<SpriteRenderer>();

            //flip the image when the card theme is shadow
            /*
            Debug.Log("displayCards current_theme: " + current_theme);
            Debug.Log("displayCards cards: " + cards);
            Debug.Log("displayCards story_spreads " + story_spreads[current_theme][0]);
            foreach (var pair in story_spreads)
            {
                Debug.Log("story_spreads " + pair.Value.ToString());
            }
            */
            //comedy { "light", "shadow", "shadow", "light", "light" });
            //tragedy { "light", "shadow", "light", "shadow", "shadow" });
            cards[i].GetComponent<Image>().sprite = cardSprite[i];

            if (current_theme == "comedy" && (i == 1 || i == 2)) {
                Debug.Log("Flip? comedy true");
                spriteR[i].flipX = true;
                cards[i].GetComponent<SpriteRenderer>().flipX = false;
            }
            if (current_theme == "tragedy" && (i == 1 || i == 3 || i == 4)) {
                Debug.Log("Flip? tragedy true");
                spriteR[i].flipX = true;
                cards[i].GetComponent<SpriteRenderer>().flipX = false;
            }
            cardInfoName[i].GetComponent<Text>().text = five_chosen_cards[i].name;

            //spriteR[i].sprite = cardSprite[i];



        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Call sequence to initialize the board
        // 2. generateCardDeck()
        // 3. newSpread()
        //Debug.Log("board start=========");
        initialize();
        generateCardDeck();
        newSpread();

    }
    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
