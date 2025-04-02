using _Project.Code.Core.Health;

namespace _Project.Code.Core
{
    public class Attacker
    {
        private readonly float _damage;

        public Attacker(float damage)
        {
            _damage = damage;
        }
        
        public void Attack(IDamageable damageable) => damageable.TakeDamage(_damage); 
    }
}