using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movement Script requires the GameObject to have a Rigidbody component
[RequireComponent(typeof(Rigidbody2D))]

public class MovementScript : MonoBehaviour {

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
    void FixedUpdate()
    {

    }

	public void Move(Vector2 direction)
    {
        rb.velocity = direction;
    }

    public void Move(Vector2 direction, float multiplier)
    {
        rb.velocity = direction * multiplier;
    }

    Rigidbody2D GetRigidbody(){ return rb; }
}
