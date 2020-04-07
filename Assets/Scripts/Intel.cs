using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intel : MonoBehaviour
{
    public UIManager uIManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Audiomanager>().Play("Collected");
            uIManager.IntelCollected++;
            Destroy(gameObject);
        }
    }
}
