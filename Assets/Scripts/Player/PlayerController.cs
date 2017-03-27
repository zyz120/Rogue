using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public enum PlayerState { idle, walk };
    public enum PlayerFace { up, down, left, right };

    Rigidbody2D rigidbody;
    Animator anim;

    public PlayerState playerState;
    public PlayerFace playerFace;

    float speed = 3.0f;

	// Use this for initialization
	void Awake ()
    {
        playerState = PlayerState.idle;
        playerFace = PlayerFace.down;
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        MoveListener();
        
	}

    void MoveListener()
    {
        if (anim) { }
        if (Input.GetKey(KeyCode.W))
        {
            playerState = PlayerState.walk;
            playerFace = PlayerFace.up;
            anim.Play("player_walk_up");
            rigidbody.velocity = new Vector3(0, speed, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerState = PlayerState.walk;
            playerFace = PlayerFace.left;
            anim.Play("player_walk_left");
            rigidbody.velocity = new Vector3(-speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerState = PlayerState.walk;
            playerFace = PlayerFace.down;
            anim.Play("player_walk_down");
            rigidbody.velocity = new Vector3(0, -speed, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerState = PlayerState.walk;
            playerFace = PlayerFace.right;
            anim.Play("player_walk_right");
            rigidbody.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            playerState = PlayerState.idle;

            if (playerFace == PlayerFace.down)
                anim.Play("player_idle");
            else if (playerFace == PlayerFace.up)
                anim.Play("player_idle_up");
            else if (playerFace == PlayerFace.right)
                anim.Play("player_idle_right");
            else
                anim.Play("player_idle_left");

            rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }

}
