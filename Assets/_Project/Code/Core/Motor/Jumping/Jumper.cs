using _Project.Code.Core.Motor.Velocity;
using UnityEngine;

namespace _Project.Code.Core.Motor.Jumping
{
    public class Jumper
    {
        private readonly IVelocity _velocity;
        private readonly float _jumpVelocity;

        public Jumper(IVelocity velocity, float jumpVelocity)
        {
            _velocity = velocity;
            _jumpVelocity = jumpVelocity;
        }

        public void Jump() =>
            _velocity.Value = new Vector3(_velocity.Value.x, _jumpVelocity, _velocity.Value.z);
    }
}