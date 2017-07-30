using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    public float followSpeed;
    public float followDist;
    public float startFollowDist;
    public GameObject followObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!followObject)
            return;

        Vector3 dir = (transform.position - followObject.transform.position);
        if (dir.magnitude > startFollowDist)
        {
            Vector3 point = followObject.transform.position + (dir.normalized * followDist);

            // Move
            this.transform.position = Vector2.MoveTowards(this.transform.position, point, followSpeed * Time.deltaTime);
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -0.01f);
    }
}
