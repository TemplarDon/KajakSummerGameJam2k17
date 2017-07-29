using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionFill : MonoBehaviour {

    public float typingDelay;

    IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDescription(ItemElement itemElement)
    {
        string text = "";
        if (itemElement.attachedItem.isKeyItem)
        {
            //GetComponent<Text>().text = itemElement.attachedItem.name + "(KEY ITEM): " + itemElement.attachedItem.description;

            text = itemElement.attachedItem.name + "(KEY ITEM): " + itemElement.attachedItem.description;
        }
        else
        {
            //GetComponent<Text>().text = itemElement.attachedItem.name + ": " + itemElement.attachedItem.description;

            text = itemElement.attachedItem.name + ": " + itemElement.attachedItem.description;
        }

        coroutine = AnimateText(text);
        StopCoroutine(coroutine);
        StartCoroutine(coroutine);
    }

    IEnumerator AnimateText(string str)
    {
        GetComponent<Text>().text = "";
        foreach (char letter in str.ToCharArray())
        {
            GetComponentInChildren<Text>().text += letter;

            yield return 0;
            yield return new WaitForSeconds(typingDelay);
        }
    }
}
