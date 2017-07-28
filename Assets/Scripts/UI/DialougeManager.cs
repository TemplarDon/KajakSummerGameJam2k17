using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour {

    string[] dialougeToDisplay;
    int dialougeIdx = 0;
    bool dialougeDone = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<Text>().text = dialougeToDisplay[dialougeIdx];

        if (Input.anyKeyDown)
        {
            ++dialougeIdx;

            if (dialougeIdx >= dialougeToDisplay.Length)
            {
                dialougeIdx = 0;
                dialougeDone = true;
            }
        }
	}

    public void SetDialougeContent(string[] content)
    {
        dialougeToDisplay = content;
        dialougeDone = false;
    }

    public bool GetDialougeDone()
    {
        return dialougeDone;
    }
}
