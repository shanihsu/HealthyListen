using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enderman : MonoBehaviour {

    private GameObject player;
    private Movement movement;
    private float coolTime;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        movement = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
        detectPlayer();
	}

    void detectPlayer()
    {
        Vector3 oriPos = transform.position;
        oriPos.y -= 0.5f;
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        coolTime += Time.deltaTime;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Player" && coolTime > 5f)
            {
                coolTime = 0;
                transform.position = player.transform.position - player.transform.forward / 2;
                movement.face(player.transform.position - transform.position);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Enderman");
        }
    }
}
