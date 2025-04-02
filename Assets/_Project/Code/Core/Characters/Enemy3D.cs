using System.Collections;
using UnityEngine;

namespace _Project.Code.Core
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private SkinnedMeshRenderer[] _meshRenderers;
        [SerializeField] private MeshRenderer[] _meshRenderers2;
        [SerializeField] private int _healthValue = 3;

        private Health.Health _health;

        private void Awake()
        {
            _health = new Health.Health(_healthValue, _healthValue);
        }

        public void TakeDamage(float damage)
        {
            _health.TakeDamage(damage);

            StartCoroutine(GetDamaged());

            if (_health.Value <= 0) Destroy(gameObject);
        }

        private IEnumerator GetDamaged()
        {
            foreach (var renderer in _meshRenderers)
            {
                renderer.material.color = Color.red;
            }
        
            foreach (var renderer in _meshRenderers2)
            {
                renderer.material.color = Color.red;
            }
        
            yield return new WaitForSeconds(0.1f);
        
            foreach (var renderer in _meshRenderers)
            {
                renderer.material.color = Color.white;
            }
       
            foreach (var renderer in _meshRenderers2)
            {
                renderer.material.color = Color.white;
            }
        }
    }
}