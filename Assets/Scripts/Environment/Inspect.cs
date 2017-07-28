using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inspect : MonoBehaviour {

    public UnityEvent endOfDialouge;
    public string[] dialougeArr;

    bool dialougeStarted = false;

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
        if (!dialougeStarted)
        {
            dialougeStarted = true;

            PanelManager pmRef = GameObject.FindObjectOfType<PanelManager>();

            pmRef.ActivatePanel("Dialouge");
            pmRef.GetPanel("Dialouge").GetComponent<DialougeManager>().SetDialougeContent(dialougeArr);
        }
    }

    void DoEndOfDialouge()
    {
        dialougeStarted = false;

        endOfDialouge.Invoke();

        PanelManager pmRef = GameObject.FindObjectOfType<PanelManager>();
        pmRef.DeactivatePanel("Dialouge");
    }

    
    public void TestEndDialouge()
    {
        Debug.Log("wow");
    }
}
