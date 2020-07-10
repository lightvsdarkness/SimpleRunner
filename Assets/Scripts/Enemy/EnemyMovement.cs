using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest {
    public class EnemyMovement : MonoBehaviour {

        public Vector2 Target;

        [Header("Links")]
        private EnemyData _enemyData;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;

        private void Awake() {
            if (_enemyData == null)
                _enemyData = GetComponent<EnemyData>();

            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody2D>();
            if (_animator == null)
                _animator = GetComponent<Animator>();

        }


        private void FixedUpdate() {
            var direction = Target - _rigidbody.position;
            _rigidbody.AddForce(direction * _enemyData._EnemyStats.Speed);
        }


    }
}