using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float Health;
    public Transform Player;
    public bool isFlipped;
    public GameObject HealthBar;
    public GameObject EnemyFace;
    public Image healthimage;
    public HealthSystem healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        healthimage.fillAmount = healthSystem.Health / 100;

        if (Health <= 0)
        {
            HealthBar.SetActive(false);
            EnemyFace.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, 100);
    }

    public void LookAtPlayer()
    {
        Vector3 Flip = transform.localScale;
        if(transform.position.x>Player.position.x&& isFlipped)
        {
            transform.localScale = Flip;
            transform.Rotate(0, -180, 0);
            isFlipped = false;
        }
        else if(transform.position.x<Player.position.x && !isFlipped)
        {
            transform.localScale = Flip;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().healthDecrease(50);
        }
    }



}
