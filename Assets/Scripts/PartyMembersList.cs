using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMembersList : MonoBehaviour {

    public List<PartyMember> PartyList = new List<PartyMember>();

	// Use this for initialization
	void Start () {
        //PartyList.Add(new PartyMember());
        //PartyList.Add(new PartyMember());
        //PartyList.Add(new PartyMember());
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

    public void AddMember(PartyMember newMember)
    {
        PartyList.Add(newMember);

        if (PartyList.Count > 1)
        {
            PartyList[PartyList.Count - 1].GetComponent<FollowObject>().followObject = PartyList[PartyList.Count - 2].gameObject;
        }
        else
        {
            PartyList[PartyList.Count - 1].GetComponent<FollowObject>().followObject = gameObject;
        }
        PartyList[PartyList.Count - 1].GetComponent<Rigidbody2D>().mass = 1;
    }

    public void InstantiatePartyMembers()
    {
        PartyMember[] currentMembers = GetComponentsInChildren<PartyMember>();
        foreach (PartyMember pm in currentMembers)
            Destroy(pm);

        if (PartyList.Count >= 1)
        {
            GameObject go = Instantiate(PartyList[0].gameObject, transform.position, Quaternion.identity);
            //go.GetComponent<DistanceJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
            go.GetComponent<FollowObject>().followObject = this.gameObject;

            GameObject lastObj = go;

            for (int i = 1; i < PartyList.Count; ++i)
            {
                go = Instantiate(PartyList[i].gameObject, transform.position, Quaternion.identity);
                //go.GetComponent<DistanceJoint2D>().connectedBody = lastObj.GetComponent<Rigidbody2D>();
                go.GetComponent<FollowObject>().followObject = lastObj;
                lastObj = go;
            }
        }
    }
}
