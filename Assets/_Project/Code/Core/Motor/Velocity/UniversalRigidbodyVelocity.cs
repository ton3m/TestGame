using UnityEngine;

namespace _Project.Code.Core.Motor.Velocity
{
    public class UniversalRigidbodyVelocity : IVelocity
    {
        private readonly Rigidbody _rigidbody;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly bool _is2D;

        public UniversalRigidbodyVelocity(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
            _is2D = false;
        }
    
        public UniversalRigidbodyVelocity(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
            _is2D = true;
        }

        public Vector3 Value
        {
            get => _is2D ? (Vector3)_rigidbody2D.velocity : _rigidbody.velocity;
            set
            {
                if (_is2D)
                    _rigidbody2D.velocity = new Vector2(value.x, value.y);
                else
                    _rigidbody.velocity = value;
            }
        }
    }
}