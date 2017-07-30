using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorBoundsScript : MonoBehaviour {

    public GameObject parent;
    private BattleSystem bs;
	// Use this for initialization
	void Start () {
        bs = GameObject.Find("BattleManager").GetComponent<BattleSystem>();
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
        //Check if player attempted to hit the note or not
        if (!coll.transform.parent.GetComponent<NoteBlockScript>().attemptedHit)
            bs.PlayerTakeDamage();

        parent.GetComponent<CharacterTriggerArea>().latest_entry = null;
    }
}
