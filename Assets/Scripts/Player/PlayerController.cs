using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovementScript))]
public class PlayerController : MonoBehaviour {

    //Player Mods
    public float speed;
    public float inspectAngle= 30;

    //Player movement
    private MovementScript Movement;

    //Quick bool to freeze update
    public bool freeze = false;

    public GameObject centerObject;
    public GameObject faceObject;

    // List to hold inspect objects nearby
    public List<Inspect> nearInspectObjects;

    enum DIR
    {
        UP = 0, // 0
        RIGHT,  // -90
        DOWN,   // -180
        LEFT,   // -270
    }
    DIR currentDir;

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
        CalcDir();
        GetKeyInputs();
		
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
        //Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        //Vector3 dir = Input.mousePosition - pos;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float angle = (int)currentDir * -90;
        centerObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

    void CalcDir()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // up
        if (vertical > 0 && vertical > horizontal)
        {
            currentDir = DIR.UP;
        }
        // down
        else if (vertical < 0 && vertical < horizontal)
        {
            currentDir = DIR.DOWN;
        }
        // left
        else if (horizontal < 0 && horizontal < vertical)
        {
            currentDir = DIR.LEFT;
        }
        // right
        else if (horizontal > 0 && horizontal > vertical)
        {
            currentDir = DIR.RIGHT;
        }

        //Debug.Log(horizontal.ToString() + " " + vertical.ToString() + " " + currentDir.ToString());    
    }

    void GetKeyInputs()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            CheckSurroundings();

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!FindObjectOfType<PanelManager>().GetPanel("Inventory").activeInHierarchy)
            {
                FindObjectOfType<PanelManager>().ActivatePanel("Inventory");
            }
            else
            {
                FindObjectOfType<PanelManager>().DeactivatePanel("Inventory");
            }
        }
    }

    // Called only when interact button is pressed
    void CheckSurroundings()
    {
        foreach (Inspect anInspect in nearInspectObjects)
        {
            GameObject inspectObject = anInspect.gameObject;

            // Do dir check (using face object)
            Vector3 playerFaceDir = (faceObject.transform.position - transform.position);
            Vector3 objectToPlayerDir = (inspectObject.transform.position - transform.position);

            Debug.DrawLine(faceObject.transform.position, transform.position, Color.blue, 10);
            Debug.DrawLine(inspectObject.transform.position, transform.position, Color.red, 10);

            float angle = Vector3.Angle(playerFaceDir, objectToPlayerDir);

            if (angle <= inspectAngle)
            {
                anInspect.StartDialouge();
                freeze = true;
            }
        }
    }


    public void AddInspectObject(Inspect toAdd)
    {
        nearInspectObjects.Add(toAdd);
    }

    public void RemoveInspectObject(Inspect toRemove)
    {
        if (nearInspectObjects.Contains(toRemove))
            nearInspectObjects.Remove(toRemove);
    }
}
