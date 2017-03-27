using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity = new Vector3(0, 5, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(-5, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity = new Vector3(0, -5, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(5, 0, 0);
        }
    }
}
