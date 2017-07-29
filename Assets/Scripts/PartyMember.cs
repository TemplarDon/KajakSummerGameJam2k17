using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : MonoBehaviour {

    public string m_name = "Unnamed";
    public bool m_isDead = false;
    private Dictionary<int, string> m_chapterDialogue = new Dictionary<int, string>();

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public virtual void AddStrike()
    {

    }

    public virtual void FinishBattle()
    {

    }

    public virtual void Heal()
    {
        m_isDead = false;
    }
}
