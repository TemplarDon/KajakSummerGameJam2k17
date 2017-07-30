using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))] 
public class TriggerKillzone : MonoBehaviour {

	// Use this for initialization
	void Awake() {
        GetComponent<BoxCollider2D>().isTrigger = true;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
            return;

        Destroy(coll.gameObject);
    }
}
