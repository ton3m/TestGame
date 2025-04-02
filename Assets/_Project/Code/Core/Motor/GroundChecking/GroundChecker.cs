using UnityEngine;

namespace _Project.Code.Core.Motor.Movement._2D
{
    public class GroundChecker 
    {
        private readonly Transform _groundCheckPoint;
        private readonly bool _is2D;

        public GroundChecker(Transform groundCheckPoint, bool is2D = false)
        {
            _groundCheckPoint = groundCheckPoint;
        }

        public bool IsGrounded()
        {
            var rayLength = 0.1f;
            
            return _is2D
                ? Physics2D.Raycast(_groundCheckPoint.position, Vector2.down, rayLength)
                : Physics.Raycast(_groundCheckPoint.position, Vector3.down, rayLength);
        }
    }
}