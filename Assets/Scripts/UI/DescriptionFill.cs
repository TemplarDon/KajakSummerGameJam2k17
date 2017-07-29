using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionFill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDescription(ItemElement itemElement)
    {
        if (itemElement.attachedItem.isKeyItem)
        {
            GetComponent<Text>().text = itemElement.attachedItem.name + "(KEY ITEM): " + itemElement.attachedItem.description;
        }
        else
            GetComponent<Text>().text = itemElement.attachedItem.name + ": " + itemElement.attachedItem.description;
    }
}
