using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour {

    public float typingDelay;

    string[] dialougeToDisplay;
    int dialougeIdx = 0;
    bool dialougeDone = true;

    IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            ++dialougeIdx;

            if (dialougeIdx >= dialougeToDisplay.Length)
            {
                dialougeIdx = 0;
                dialougeDone = true;
            }

            StopCoroutine(coroutine);
            coroutine = AnimateText(dialougeToDisplay[dialougeIdx]);
            StartCoroutine(coroutine);
        }
	}

    public void SetDialougeContent(string[] content)
    {
        dialougeToDisplay = content;

        dialougeIdx = 0;
        dialougeDone = false;

        StopCoroutine(coroutine);
        coroutine = AnimateText(dialougeToDisplay[dialougeIdx]);
        StartCoroutine(coroutine);
    }

    public bool GetDialougeDone()
    {
        return dialougeDone;
    }

    IEnumerator AnimateText(string str)
    {
        GetComponentInChildren<Text>().text = "";
        foreach (char letter in str.ToCharArray())
        {
            GetComponentInChildren<Text>().text += letter;

            yield return 0;
            yield return new WaitForSeconds(typingDelay);
        } 
    }
}
