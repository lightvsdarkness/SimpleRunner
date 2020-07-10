using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest {
    public class EnemyData : MonoBehaviour {
        [Serializable]
        public class EnemyStats {
            // Maybe read ScriptableObject here in the future
            public int Health = 1;
            public float Speed = 2;
            public float AttackRange = 1;
        }

        public EnemyStats _EnemyStats;
        public EnemyHealth _EnemyHealth;
        public PooledObject _PooledObject;

        private void Awake() {
            if (_PooledObject == null)
                _PooledObject = GetComponent<PooledObject>();

            if (_EnemyStats == null)
                _EnemyStats = GetComponent<EnemyStats>();
            if (_EnemyHealth == null)
                _EnemyHealth = GetComponent<EnemyHealth>();
        }
    }
}