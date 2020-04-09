using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    public GameObject Endpoint;
    public GameObject EndCollider;
    private void Awake()
    {
        Endpoint.SetActive(false);
        EndCollider.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerFall"))
        {
            Endpoint.SetActive(true);
            EndCollider.SetActive(false);
        }
    }
}
