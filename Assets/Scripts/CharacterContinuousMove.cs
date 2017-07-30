using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContinuousMove : MonoBehaviour {

    public PartyMember.ANIM_STATE anim_state;
    public bool isEnemy = false;
    public bool isSamuli = false;

	// Use this for initialization
	void Start () {
        if (GetComponent<Animator>() != null)
		GetComponent<Animator>().SetInteger("state", (int)PartyMember.ANIM_STATE.ATTACK);

        if(isEnemy) GetComponent<Animator>().SetBool("isAttacking", true);
        if(isSamuli) GetComponent<Animator>().SetBool("isAttacking", true);
    }

    // Update is called once per frame
    void Update () {
		//if(GetComponent<Animator>().GetInteger("state") == (int)PartyMember.ANIM_STATE.ATTACK && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !GetComponent<Animator>().IsInTransition(0))
           // GetComponent<Animator>().SetInteger("state", (int)PartyMember.ANIM_STATE.UP);
    }
}
