using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private float idleTime;
    private float idleStopTime;
    private int idleSeed;

    public void move(Vector3 v)
    {
        transform.position += v * moveSpeed * Time.deltaTime;
    }

    public void rotate(float dx, float dy)
    {
        Vector3 angles = transform.rotation.eulerAngles;
        angles.x += dx;
        angles.y += dy;

        if (angles.x > 90f && angles.x < 270)
        {
            if (dx > 0) angles.x = 90f;
            else angles.x = 270f;
        }

        transform.rotation = Quaternion.Euler(angles);
    }

    public void face(Vector3 direction)
    {
        Vector3 v = Quaternion.LookRotation(
            direction,
            transform.up
            ).eulerAngles;

        transform.localRotation = Quaternion.Euler(-90, v.y, 0);

    }

    public void idle()
    {
        idleTime += Time.deltaTime;
        if(idleTime > idleStopTime)
        {
            idleStopTime = Random.Range(1f, 2f);
            idleTime = 0f;
            idleSeed = Random.Range(-4, 6);
        }
        Vector3 angle = transform.rotation.eulerAngles;
        if (idleSeed < -2)
        {
            angle.y += idleSeed/3f;
            idleStopTime = 0.7f;
        }
        else if (idleSeed > 2)
        {
            angle.y += idleSeed/3f;
            idleStopTime = 0.7f;
        }
        transform.rotation = Quaternion.Euler(angle);
        if(idleSeed == -4 || idleSeed == 4 || idleSeed == 0 || idleSeed == 1)
        {
            move(-transform.up);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
