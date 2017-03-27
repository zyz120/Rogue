using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    Transform player;
    
	void Awake ()
    {
        player = GameObject.Find("player").transform;
	}
	
	void Update ()
    {
        Vector3 playerPos = new Vector3(player.position.x + 1, player.position.y, player.position.z);
        Vector3 targetPos = Vector3.Lerp(transform.position, playerPos, 3.0f * Time.deltaTime);
        transform.position = new Vector3(targetPos.x, targetPos.y, -10);

        LimitCameraPos();

	}

    void LimitCameraPos()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.8f, 8.3f), Mathf.Clamp(transform.position.y, -7.5f, 7.5f), -10);
    }

}
