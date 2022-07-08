
using PixelPuzzle.Components;
using PixelPuzzle.Components.ColliderBased;
using PixelPuzzle.Components.GoBased;
using UnityEngine;

namespace PixelPuzzle.Creatures
{
    public class Creature : MonoBehaviour
    {
        [Header("Params")] [SerializeField] private bool _invertScale;
        [SerializeField] private float _speed;
        [SerializeField] protected float _jumpSpeed;
        [SerializeField] private float _damageVelocity;
        [SerializeField] private int _damage;
        
        [Header("Checkers")]
        [SerializeField] protected LayerMask _groundLayer;
        [SerializeField] private LayerCheck _groundCheck;
        [SerializeField] private CheckCircleOverlap _attackRange;
        [SerializeField] protected SpawnListComponent _particles;

        private Vector2 _direction;
        private Rigidbody2D _rigidbody;
        protected Animator Animator;
        protected bool IsGrounded;
        private bool _isJumping;

        private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
        private static readonly int IsRunning = Animator.StringToHash("is-running");
        private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");
        private static readonly int Hit = Animator.StringToHash("hit");
        private static readonly int AttackKey = Animator.StringToHash("attack");

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
                
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        protected virtual void Update()
        {
            IsGrounded = _groundCheck.IsTouchingLayer;
        }

        private void FixedUpdate()
        {
            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            Animator.SetBool(IsGroundKey, IsGrounded);
            Animator.SetFloat(VerticalVelocity, _rigidbody.velocity.y);
            Animator.SetBool(IsRunning, _direction.x != 0);

            UpdateSpriteDirection(_direction);
        }

        protected virtual float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            var isJumpPressing = _direction.y > 0;

            if (IsGrounded)
            {
                _isJumping = false;
            }

            if (isJumpPressing)
            {
                _isJumping = true;

                var isFalling = _rigidbody.velocity.y <= 0.001f;
                yVelocity = isFalling ? CalculateJumpVelocity(yVelocity) : yVelocity;
            }
            else if (_rigidbody.velocity.y > 0 && _isJumping)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        protected virtual float CalculateJumpVelocity(float yVelocity)
        {
            if (IsGrounded)
            {
                yVelocity = _jumpSpeed;
                _particles.Spawn("Jump");
            }

            return yVelocity;
        }

        public void UpdateSpriteDirection(Vector2 direction)
        {
            var multipler = _invertScale ? -1 : 1;
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(multipler, 1, 1);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1 * multipler, 1, 1);
            }
        }

        public virtual void TakeDamage()
        {
            _isJumping = false;
            Animator.SetTrigger(Hit);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageVelocity);
        }


        public virtual void Attack()
        {
            Animator.SetTrigger(AttackKey);
        }
        
        protected virtual void OnDoAttack()
        {
            _attackRange.Check();
        }
    }
}