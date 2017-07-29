using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inspect : MonoBehaviour {

    public UnityEvent endOfDialouge;
    public string[] dialougeArr;
    public bool doActionOnce = true;

    bool dialougeStarted = false;
    bool actionDone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dialougeStarted)
        {
            PanelManager pmRef = GameObject.FindObjectOfType<PanelManager>();
            if (pmRef.GetPanel("Dialouge").GetComponent<DialougeManager>().GetDialougeDone())
                DoEndOfDialouge();
        }
	}

    public void StartDialouge()
    {
        if (!enabled)
        {
            // Unfreeze player
            GameObject.Find("PlayerObject").GetComponent<PlayerController>().freeze = false;
            return;
        }

        if (!dialougeStarted)
        {
            dialougeStarted = true;

            PanelManager pmRef = GameObject.FindObjectOfType<PanelManager>();

            pmRef.ActivatePanel("Dialouge");
            pmRef.GetPanel("Dialouge").GetComponent<DialougeManager>().SetDialougeContent(dialougeArr, gameObject.name);
        }
    }

    void DoEndOfDialouge()
    {
        dialougeStarted = false;

        // Unfreeze player
        GameObject.Find("PlayerObject").GetComponent<PlayerController>().freeze = false;

        // Switch off dialouge stuff
        PanelManager pmRef = GameObject.FindObjectOfType<PanelManager>();
        pmRef.DeactivatePanel("Dialouge");

        if (!actionDone)
        {
            endOfDialouge.Invoke();

            if (doActionOnce)
                actionDone = true;
        }
    }

    
    public void TestEndDialouge()
    {
        GameObject.Find("PlayerObject").GetComponent<InventoryData>().AddItem(PersistentData.m_Instance.GetItemFromDatabase("test1"), 3);
    }

    public void AddItem(string itemName)
    {
        GameObject.Find("PlayerObject").GetComponent<InventoryData>().AddItem(PersistentData.m_Instance.GetItemFromDatabase(itemName));
    }

    public void AddMember(PartyMember newMember)
    {
        GameObject.Find("PlayerObject").GetComponent<PartyMembersList>().AddMember(newMember);
        enabled = false;
    }
}
