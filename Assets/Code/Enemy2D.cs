using System.Collections;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        StartCoroutine(GetDamaged());
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    IEnumerator GetDamaged()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}