using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovementScript))]
public class PlayerController : MonoBehaviour {

    //Player Mods
    public float speed;

    //Player movement
    private MovementScript Movement;

    //Quick bool to freeze update
    public bool freeze = false;

    // Use this for initialization
    void Start () {
        Movement = GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update () {
        if (freeze)
            return;

        //Move player
        Move();
        FaceMousePos();
        GetKeyInputs();
        CheckSurroundings();
		
	}

    void Move()
    {
        //Movement
        Movement.Move
            (
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),    //Direction
            (speed)                                                                 //Speed
            );
    }

	void FaceMousePos()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

    void GetKeyInputs()
    {

    }

    void CheckSurroundings()
    {

    }
}
