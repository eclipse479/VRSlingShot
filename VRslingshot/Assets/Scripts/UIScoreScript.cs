using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScoreScript : MonoBehaviour
{
    //creation of instance of text
    public UnityEngine.UI.Text uiscorescript;

    // Start is called before the first frame update
    void Start()
    {
        //sets the text component ot the script
        uiscorescript = gameObject.GetComponent<UnityEngine.UI.Text>();

        //sets the text of the script
        uiscorescript.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        //the newscore equals the score found in the TargetScript script
        int newscore = GameObject.Find("TargetCube").GetComponent<TargetScript>().score;

        

        //update the score text
        uiscorescript.text = "Score: " + newscore;
    }
}
