using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemElement : MonoBehaviour {

    public Item attachedItem;
    public int amount = 0;

    public Text amountText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        amountText.text = amount.ToString();

        if (attachedItem.spriteName != "")
        {
            string loadStr = "Assets/" + attachedItem.spriteName;
            GetComponent<Image>().sprite = Resources.Load(loadStr) as Sprite;
        }
    }
}
