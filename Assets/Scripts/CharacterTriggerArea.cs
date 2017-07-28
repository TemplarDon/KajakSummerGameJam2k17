using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTriggerArea : MonoBehaviour {

    public string AssignedKey = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if(Input.GetKeyDown(AssignedKey))
            Destroy(coll.gameObject);
    }
}
