using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest
{
    public class PlayerMovement : MonoBehaviour, ICollisionProcessor {
        public bool JumpInputReceived;
        [SerializeField] private bool _touchingTarget;
        public bool TouchingTarget => _touchingTarget;



        [Header("Links")]
        private PlayerData _playerData;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;

        public Transform Transform => transform;
        private WaitForSeconds _jumpAllowedTime;
        private bool _jumpTimerAllows = true;

        private void Awake() {
            if (_playerData == null)
                _playerData = GetComponent<PlayerData>();

            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody2D>();
            if (_animator == null)
                _animator = GetComponent<Animator>();
            _jumpAllowedTime = new WaitForSeconds(0.2f);
        }
        private void Start() {
            ManagerInput.I.PlayerJumpEvent += ProcessJumpInput;
        }
        private void FixedUpdate() {
            //Debug.Log($"TouchingGround {TouchingGround}", this);

            if (JumpInputReceived && TouchingTarget && _jumpTimerAllows) {
                Jump();
            }
        }


        // For the future, maybe to increase jump height because button 
        public void ProcessJumpInput() {
            JumpInputReceived = true;
            Debug.Log($"InputJump {JumpInputReceived}", this);
        }

        private void Jump() {
            _animator.SetFloat("Jump", 1.0f);
            JumpInputReceived = false;
            _touchingTarget = false;

            StartCoroutine(JumpTimerCor());
            _rigidbody.AddForce((new Vector2(0, _playerData._PlayerStats.ForceJump)));
        }

        private IEnumerator JumpTimerCor() {
            _jumpTimerAllows = false;
            yield return _jumpAllowedTime;

            _jumpTimerAllows = true;
            _animator.SetFloat("Jump", 0f);
        }

        public void Collided() {
            _touchingTarget = true;
        }
    }
}