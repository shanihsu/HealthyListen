using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject sun;
    public float mult;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        sun.transform.Rotate(Vector3.left, mult * Time.deltaTime, Space.World);
	}


}
