using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorBoundsScript : MonoBehaviour {

    public GameObject parent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        parent.GetComponent<CharacterTriggerArea>().latest_entry = coll.gameObject;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        //Check if tried hitting or not
        if (coll.GetComponent<NoteBlockScript>().attemptedHit)
            Debug.Log("You Tried");
        else
            Debug.Log("You didn't even try");

        parent.GetComponent<CharacterTriggerArea>().latest_entry = null;
        //Destroy(latest_entry.transform.parent.gameObject);
    }
}
