using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Movement movement;
    private Rigidbody rb;
    private Vector3 directionToPlayer;
    private GameObject player;

    public bool isTracking;
    [SerializeField] private float attackFeedback;

	void Start () {
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
    }
	
	// Update is called once per frame
	void Update () {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        doMovement();
    }

    private void doMovement()
    {
        if (isTracking)
        {
            movement.face(directionToPlayer);
            movement.move(directionToPlayer);
        }
        else
        {
            movement.idle();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            directionToPlayer.y = 0;
            rb.AddForce(-directionToPlayer * attackFeedback);
        }
    }
}
