using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeper : MonoBehaviour {

    private MeshRenderer mesh;
    private Color oriColor;
    private float time;
    public float explodeField;
    [SerializeField] private float countdown;
    [SerializeField] public GameObject player;
    public bool isTriggered;

	// Use this for initialization
	void Start () {
        mesh = GetComponent<MeshRenderer>();
        oriColor = mesh.material.color;
        player = GameObject.Find("player");
    }

    public void Bomb()
    {
        countdown -= Time.deltaTime;
        time += Time.deltaTime * 8;
        if(time > countdown)
        {
            time = 0;
            changeColor();
        }

        if(countdown < 0f)
        {
            Destroy(gameObject);
            if (Vector3.Distance(transform.position, player.transform.position) < explodeField)
            {
                Debug.Log("bomb");
                player.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position).normalized * 500);
            }
        }
    }

    private void changeColor()
    {
        if(mesh.material.color == Color.red)
        {
            mesh.material.color = oriColor;
        }
        else
        {
            mesh.material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update () {
        if (isTriggered)
        {
            Bomb();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Creeper");
        }
    }
}
