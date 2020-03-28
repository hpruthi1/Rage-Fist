using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    public LayerMask layer;
    public float Radius;

    public void KnifeAttackFunction(float damage)
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, Radius, layer);
        foreach(var obj in hit)
        {
            if (obj.gameObject.CompareTag("Enemies"))
            {
                obj.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
