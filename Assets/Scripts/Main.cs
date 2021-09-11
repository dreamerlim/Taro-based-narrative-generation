using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

// how to use SimpleJSON
// Original Implementation
// https://github.com/annetropy/tarot-narrative/blob/master/tarot/code/tarot.js 
public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // var jsonFile = Resources.Load<TextAsset>("json_files/taro-story");
        string jsonString = File.ReadAllText("json_files/sample.json");
        var N = JSON.Parse(jsonString);
        var val = N["version"].Value;
        // Debug.Log(N["tarot_interpretations"][0]["name"].Value);
        Debug.Log(val);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
