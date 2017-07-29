using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlockScript : MonoBehaviour {

    public float m_speed = 1.0f;
    public bool attemptedHit = false;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -m_speed * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update ()
    {
        //gameObject.transform.Translate(new Vector3(0, -m_speed * Time.deltaTime, 0));
	}

    public void SetSpeed(float speed)
    {
        m_speed = speed;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -m_speed * Time.deltaTime, 0);
    }
}
