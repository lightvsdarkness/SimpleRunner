using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest {
    public class EnemyAttack : MonoBehaviour {

        [SerializeField] private EnemyData _EnemyData;

        private void Start() {
            if (_EnemyData == null)
                _EnemyData = GetComponent<EnemyData>();
        }

        //TODO: OnTriggerEnter2D or CollisionSensor
        private void Attack() {

        }
    }
}