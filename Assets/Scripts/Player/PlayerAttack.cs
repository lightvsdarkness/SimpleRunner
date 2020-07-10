using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest {
    public class PlayerAttack : MonoBehaviour {

        [Header("Links")]
        [SerializeField] private GameObject Beam;
        [SerializeField] private Animator _animator;

        private WaitForSeconds AttackDelay;

        private void Awake() {
            if (_animator == null)
                _animator = GetComponent<Animator>();
        }
        private void Start() {
            ManagerInput.I.PlayerAttackEvent += Attack;
            AttackDelay = new WaitForSeconds(.2f);
        }

        //private void Update() {
        //}


        public void Attack(EnemyData enemyClosest) {
            Debug.Log("PlayerAttack Attack", this);
            _animator.SetTrigger("Attack");

            StartCoroutine(AttackCor(enemyClosest));
        }

        private IEnumerator AttackCor(EnemyData enemyClosest) {
            yield return AttackDelay;
            Beam.SetActive(true);
            enemyClosest._EnemyHealth.Damage();

            yield return AttackDelay;
            Beam.SetActive(false);
        }

        private void DeactivateBeam() {
            Beam.SetActive(false);
        }

    }
}