using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    public LayerMask layer;
    public float Radius;
    public GameObject Enemy;

    public void KnifeAttackFunction(float damage)
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, Radius, layer);
        foreach(var obj in hit)
        {
            if (obj.gameObject.CompareTag("Enemies"))
            {
                Destroy(Enemy);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
