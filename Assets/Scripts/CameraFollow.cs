using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float Delay;
    public float minvalue, maxvalue;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 direction =new Vector3(player.position.x,transform.position.y,transform.position.z);
        transform.position = Vector3.Lerp(transform.position,direction,Delay);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minvalue, maxvalue), transform.position.y, transform.position.z);
    }
}
