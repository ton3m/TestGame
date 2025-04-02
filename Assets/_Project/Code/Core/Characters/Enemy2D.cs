using System.Collections;
using UnityEngine;

namespace _Project.Code.Core
{
    public class Enemy2D : MonoBehaviour, IDamageable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _healthValue = 3;

        private Health.Health _health;
        
        private void Awake() => 
            _health = new Health.Health(_healthValue, _healthValue);

        public void TakeDamage(float damage)
        {
            _health.TakeDamage(damage);
            
            StartCoroutine(GetDamaged());
            
            if (_health.Value <= 0) Destroy(gameObject);
        }

        IEnumerator GetDamaged()
        {
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            _spriteRenderer.color = Color.white;
        }
    }
}