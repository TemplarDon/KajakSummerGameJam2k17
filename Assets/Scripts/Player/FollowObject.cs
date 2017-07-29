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

        Vector3 dir = (transform.position - followObject.transform.position);
        if (dir.magnitude > startFollowDist)
        {
            Vector3 point = followObject.transform.position + (dir.normalized * followDist);

            // Move
            this.transform.position = Vector2.MoveTowards(this.transform.position, point, followSpeed * Time.deltaTime);

            // Rotate
            Vector3 toTarget = point - this.transform.position;
            float angle = (Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg) - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, q, 0.33f);
        }
	}
}
