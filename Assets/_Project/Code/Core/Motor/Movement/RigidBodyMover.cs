using _Project.Code.Core.Motor.Velocity;
using UnityEngine;

namespace _Project.Code.Core.Motor.Movement
{
    public class RigidBodyMover 
    {
        private readonly IVelocity _velocity;
        private readonly float _speed;
    
        public RigidBodyMover(IVelocity velocity, float speed)
        {
            _velocity = velocity;
            _speed = speed;
        }
    
        public void Move(Vector3 direction) => 
            _velocity.Value = new Vector3(direction.x * _speed, _velocity.Value.y, direction.z * _speed);
    }
}