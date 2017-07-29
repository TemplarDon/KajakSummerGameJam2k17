using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTriggerArea : MonoBehaviour {

    public string AssignedKey = "";
    private Slider slider;
    public GameObject latest_entry = null;

    public BoxCollider2D Poor;
    public BoxCollider2D Okay;
    public BoxCollider2D Perfect;

    public Text displayText;

    // Use this for initialization
    void Start ()
    {
        slider = GameObject.Find("PowerSlider").GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(AssignedKey))
        {
            if (latest_entry != null)
            {
                if (latest_entry.GetComponent<NoteBlockScript>().attemptedHit)
                    return;

                if (Poor.bounds.Contains(latest_entry.transform.position))
                    if (Okay.bounds.Contains(latest_entry.transform.position))
                        if (Perfect.bounds.Contains(latest_entry.transform.position))
                        { displayText.text = "PERFECT"; slider.value += 0.03f; }
                        else
                        { displayText.text = "OKAY"; slider.value += 0.02f; }
                    else
                    { displayText.text = "POOR"; slider.value += 0.01f; }
                else
                { displayText.text = "POOR"; slider.value += 0.01f; }

                latest_entry.GetComponent<NoteBlockScript>().attemptedHit = true;
            }
            else
            { displayText.text = "MISS"; slider.value = slider.value * 0.5f; }
        }
    }

}
