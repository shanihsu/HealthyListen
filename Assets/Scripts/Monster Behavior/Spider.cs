using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

    private Movement movement;
    private Rigidbody rb;
    private GameObject player;
    private float coolTime;

    public float attackField;

	// Use this for initialization
	void Start ()
    {
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        coolTime += Time.deltaTime;
        if (Vector3.Distance(player.transform.position, transform.position) < attackField && coolTime > 1.7)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            direction *= 400;
            direction.y += 250;
            rb.AddForce(direction);
            coolTime = 0;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Spider");
        }
    }
}
