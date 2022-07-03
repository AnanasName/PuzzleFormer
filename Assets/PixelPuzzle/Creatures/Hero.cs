using PixelPuzzle.Components;
using PixelPuzzle.Creatures;
using PixelPuzzle.Model;
using PixelPuzzle.Utils;
using UnityEditor.Animations;
using UnityEngine;

namespace PixelPuzzle
{
    public class Hero : Creature
    {
        [SerializeField] private CheckCircleOverlap _interactionCheck;
         
        [SerializeField] private float _slamDownVelocity;
        [SerializeField] private float _interactionRadius;

        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _unarmed;

        [Space] [Header("Particles")]
        [SerializeField] private ParticleSystem _hitParticles;

        private bool _allowDoubleJump;
        private float _defaultJumpSpeed;
        private bool _isOnWall;

        private GameSession _session;

        public float JumpSpeed
        {
            get => _jumpSpeed;
            set => _jumpSpeed = value;
        }

        public float DefaultJumpSpeed
        {
            get => _defaultJumpSpeed;
        }

        protected override void Awake()
        {
            base.Awake();
            _defaultJumpSpeed = _jumpSpeed;
        }

        public void OnHealthChanged(int currentHealth)
        {
            _session.Data.Hp = currentHealth;
        }

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();

            var health = GetComponent<HealthComponent>();
            health.SetHealth(_session.Data.Hp);
            UpdateHeroWeapon();
        }

        protected override float CalculateYVelocity()
        {
            if (IsGrounded)
            {
                _allowDoubleJump = true;
            }

            return base.CalculateYVelocity();
        }

        protected override float CalculateJumpVelocity(float yVelocity)
        {
            if (!IsGrounded && _allowDoubleJump)
            {
                _particles.Spawn("Jump");
                _allowDoubleJump = false;
                return _jumpSpeed;
            }

            return base.CalculateJumpVelocity(yVelocity);
        }

        public void AddCoins(int amount)
        {
            _session.Data.Coins += amount;
        }

        public override void TakeDamage()
        {
            base.TakeDamage();

            if (_session.Data.Coins > 0)
            {
                SpawnCoins();
            }
        }

        private void SpawnCoins()
        {
            var numCoinsToDispose = Mathf.Min(_session.Data.Coins, 5);
            _session.Data.Coins -= numCoinsToDispose;

            var burst = _hitParticles.emission.GetBurst(0);
            burst.count = numCoinsToDispose;
            _hitParticles.emission.SetBurst(0, burst);

            _hitParticles.gameObject.SetActive(true);
            _hitParticles.Play();
        }

        public void Interact()
        {
            _interactionCheck.Check();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.IsInLayer(_groundLayer))
            {
                var contact = other.contacts[0];
                if (contact.relativeVelocity.y >= _slamDownVelocity)
                {
                    _particles.Spawn("SlamDown");
                }
            }
        }

        public override void Attack()
        {
            if (!_session.Data.IsArmed) return;
            
            base.Attack();
        }

        protected override void OnDoAttack()
        {
            _particles.Spawn("Attack");
            base.OnDoAttack();
        }

        public void ArmHero()
        {
            _session.Data.IsArmed = true;
            UpdateHeroWeapon();
        }

        private void UpdateHeroWeapon()
        {
            Animator.runtimeAnimatorController = _session.Data.IsArmed ? _armed : _unarmed;
        }
    }
}