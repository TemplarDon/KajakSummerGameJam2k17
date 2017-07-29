using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateList : MonoBehaviour {

    public GameObject elementPrefab;
    InventoryData invRef;

	// Use this for initialization
	void Start () {
        invRef = FindObjectOfType<InventoryData>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        Debug.Log("Populate");

        ItemElement[] childElements = transform.GetComponentsInChildren<ItemElement>();
        foreach (ItemElement element in childElements)
        {
            if (element.gameObject.name.Contains("Clone"))
            {
                Destroy(element.gameObject);
            }
        }

        if (!invRef)
            invRef = FindObjectOfType<InventoryData>();

        if (invRef)
        {
            foreach (KeyValuePair<Item, int> pair in invRef.GetDictionary())
            {
                GameObject go = Instantiate(elementPrefab) as GameObject;
                go.GetComponent<ItemElement>().attachedItem = pair.Key;
                go.GetComponent<ItemElement>().amount = pair.Value;
                go.transform.SetParent(transform, false);

                go.SetActive(true);
            }
        }
    }
}
