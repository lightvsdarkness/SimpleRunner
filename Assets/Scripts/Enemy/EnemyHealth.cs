using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest {
    public class EnemyHealth : MonoBehaviour {
        [Header("Links")]
        [SerializeField] private EnemyData _enemyData;

        private void Awake() {
            if (_enemyData == null)
                _enemyData = GetComponent<EnemyData>();
        }

        private void FixedUpdate() {
            //CheckIfGone
            if(transform.position.x < ManagerEnemies.I.DespawnEnemiesAtPositionX)
                ManagerEnemies.I.DespawnEnemy(_enemyData);
        }

        public void Damage() {
            Debug.Log($"Damage _enemyData {_enemyData.name}", this);
            ManagerEnemies.I.DespawnEnemy(_enemyData);
        }
    }
}