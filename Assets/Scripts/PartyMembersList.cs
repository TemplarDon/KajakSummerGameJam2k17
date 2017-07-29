using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMembersList : MonoBehaviour {

    public List<PartyMember> PartyList = new List<PartyMember>();

	// Use this for initialization
	void Start () {
        PartyList.Add(new PartyMember());
        PartyList.Add(new PartyMember());
        PartyList.Add(new PartyMember());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HealParty()
    {
        foreach(PartyMember pm in PartyList)
        {
            pm.Heal(); 
        }
    }
}
