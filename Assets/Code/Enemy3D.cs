using System.Collections;
using UnityEngine;

public class Enemy3D : MonoBehaviour
{
    public SkinnedMeshRenderer[] meshRenderers;
    public MeshRenderer[] meshRenderers2;
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
        foreach (var renderer in meshRenderers)
        {
            renderer.material.color = Color.red;
        }
        
        foreach (var renderer in meshRenderers2)
        {
            renderer.material.color = Color.red;
        }
        
        yield return new WaitForSeconds(0.1f);
        
        foreach (var renderer in meshRenderers)
        {
            renderer.material.color = Color.white;
        }
       
        foreach (var renderer in meshRenderers2)
        {
            renderer.material.color = Color.white;
        }
    }
}