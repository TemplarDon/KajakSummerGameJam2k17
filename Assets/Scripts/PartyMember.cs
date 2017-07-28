using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : MonoBehaviour {

    public string m_name = "Unnamed";
    public bool m_isDead = false;
    private int m_strikes = 0;
    private Dictionary<int, string> m_chapterDialogue = new Dictionary<int, string>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void AddStrike()
    {
        if (++m_strikes > 3)
        {
            m_strikes = 3;
            m_isDead = true;
        }
    }

    public virtual void FinishBattle()
    {
        m_strikes = 0;
    }

    public virtual void Heal()
    {
        m_isDead = false;
    }
}
