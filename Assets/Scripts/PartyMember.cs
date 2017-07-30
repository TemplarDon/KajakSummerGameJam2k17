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

    public enum ANIM_STATE
    {
        IDLE = 0, //0
        UP, //1
        RIGHT, //2
        DOWN, //3
        LEFT, //4
        ATTACK, //5
    }
    ANIM_STATE animState;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalcDir();
        UpdateAnim();
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

            float horizontalDiff = (followPos.x - transform.position.x);
            float verticalDiff = (followPos.y - transform.position.y);

            if (horizontalDiff > 0 && Mathf.Abs(horizontalDiff) >= Mathf.Abs(verticalDiff))
            {
                currentDir = DIR.RIGHT;
                animState = ANIM_STATE.RIGHT;
            }
            else if (horizontalDiff < 0 && Mathf.Abs(horizontalDiff) >= Mathf.Abs(verticalDiff))
            {
                currentDir = DIR.LEFT;
                animState = ANIM_STATE.LEFT;
            }
            else if (verticalDiff > 0 && Mathf.Abs(horizontalDiff) <= Mathf.Abs(verticalDiff))
            {
                currentDir = DIR.UP;
                animState = ANIM_STATE.UP;
            }
            else if (verticalDiff < 0 && Mathf.Abs(horizontalDiff) <= Mathf.Abs(verticalDiff))
            {
                currentDir = DIR.DOWN;
                animState = ANIM_STATE.DOWN;
            }
            else
            {
                //currentDir = DIR.DOWN;
                //animState = ANIM_STATE.IDLE;
            }

            Debug.Log(animState.ToString());
        }
        else
        {

        }
    }

    void UpdateAnim()
    {
        if (animator)
            animator.SetInteger("state", (int)animState);
    }
}
