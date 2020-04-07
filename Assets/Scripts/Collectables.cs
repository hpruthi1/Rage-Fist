using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collectables : MonoBehaviour
{
    TextMeshProUGUI Count;
    int CoinsCollected = 0;
    public UIManager uIManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Audiomanager>().Play("Collected");
            uIManager.CoinsCollected++;
            Destroy(gameObject);
        }
    }
}
