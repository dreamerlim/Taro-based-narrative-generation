using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class coontains all the constants that are used by multiple classes.
public class Constants
{
    // Comedy theme
    public static string COMEDY = "comedy";

    // Tragedy theme
    public static string TRAGEDY = "tragedy";

     // list of verb tenses
    public enum VerbTense {
        past,
        infinitive,
        present_participle,
        present
    }

    // list of seasons for the tag line generation
    public enum Season {
        SPRING,
        SUMMER,
        FALL,
        WINTER
    }
}
