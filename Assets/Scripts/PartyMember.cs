using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : MonoBehaviour {

    public string m_name = "Unnamed";
    public bool m_isDead = false;
    private Dictionary<int, string> m_chapterDialogue = new Dictionary<int, string>();
    enum DIR
    {
        UP = 0, 
        RIGHT,  
        DOWN,   
        LEFT,   
    }
    DIR currentDir;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalcDir();
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

    void CalcDir()
    {
        if (GetComponent<FollowObject>().followObject)
        {
            Vector3 followPos = GetComponent<FollowObject>().followObject.transform.position;

            float horizontalDiff = Mathf.Abs(transform.position.x - followPos.x);
            float verticalDiff = Mathf.Abs(transform.position.y - followPos.y);

            if (horizontalDiff > 0 && horizontalDiff > verticalDiff)
            {
                currentDir = DIR.UP;
            }
            else if (horizontalDiff < 0 && horizontalDiff > verticalDiff)
            {
                currentDir = DIR.DOWN;
            }
            else if (verticalDiff < 0 && verticalDiff > horizontalDiff)
            {
                currentDir = DIR.LEFT;
            }
            else if (verticalDiff < 0 && verticalDiff > horizontalDiff)
            {
                currentDir = DIR.RIGHT;
            }

        }
        else
        {

        }
    }
}
