using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour {

    List<Item> ItemDatabaseRef = new List<Item>();
    Dictionary<Item, int> ItemMap = new Dictionary<Item, int>();

	// Use this for initialization
	void Start () {

        ItemDatabaseRef = PersistentData.m_Instance.ItemDatabase;

	    // Init map with pre-exist items
        foreach (Item anItem in ItemDatabaseRef)
        {
            //ItemMap.Add(anItem, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(Item toAdd, int amount = 1)
    {
        if (ItemMap.ContainsKey(toAdd))
        {
            ItemMap[toAdd] += amount;
        }
        else
        {
            ItemMap.Add(toAdd, amount);
        }
    }

    public void UseItem(string str)
    {
        // Do effect based on name
        switch (str)
        {
            default: break;
        }
    }

    public Dictionary<Item, int> GetDictionary()
    {
        return ItemMap;
    }
}
