using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemElement : MonoBehaviour {

    public Item attachedItem;
    public int amount = 0;

    public Text amountText;
    public Image image;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        amountText.text = amount.ToString();

        if (attachedItem.spriteName != "")
        {
            string loadStr = "Items/" + attachedItem.spriteName;
            Sprite loadedSprite = Resources.Load(loadStr.ToLower(), typeof(Sprite)) as Sprite;

            image.sprite = loadedSprite;
        }
    }
}
