using _Project.Code.Architecture;
using _Project.Code.Core.Motor.Jumping;
using _Project.Code.Core.Motor.Movement;
using _Project.Code.Core.Motor.Movement._2D;
using _Project.Code.Core.Motor.Velocity;
using UnityEngine;
using Zenject;

namespace _Project.Code.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player2D : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheckPoint;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _attackDamage = 1;
   
        [Inject] private ICharacterInput _input;
        
        private GroundChecker _groundChecker;
        private Jumper _jumper;
        private RigidBodyMover _mover;
        private IComponentCollisionDetector _componentCollisionDetector;
        private Attacker _attacker;

        private void Awake()
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            var velocity = new UniversalRigidbodyVelocity(rigidbody);

            _mover = new RigidBodyMover(velocity, 10);
            _jumper = new Jumper(velocity, 10);
            _groundChecker = new GroundChecker(_groundCheckPoint, true);

            _componentCollisionDetector = new OverlapCollisionDetector2D(_attackPoint, 0.5f, ~0);
            _attacker = new Attacker(_attackDamage);
        }

        private void FixedUpdate()
        {
            HandleMotor();
            HandleCollision();
        }

        private void HandleMotor()
        {
            if (_input.IsJumping && _groundChecker.IsGrounded())
            {
                _jumper.Jump();
            }

            var direction = new Vector3(_input.Axis.x, 0, 0);

            _mover.Move(direction);
        }

        private void HandleCollision()
        {
            if (_componentCollisionDetector.IsColliding(out Enemy2D enemy))
            {
                _attacker.Attack(enemy);
            }

            if (_componentCollisionDetector.IsColliding(out LevelFinish levelFinish))
            {
                levelFinish.Trgger();
            }
        }
    }
}