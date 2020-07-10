using System.Collections;
using System.Collections.Generic;
using IG.General;
using UnityEngine;

namespace RunnerTest
{
    public class ManagerEnemies : SingletonManagerBase<ManagerEnemies> {
        [SerializeField] private bool ShouldSpawn;

        [Space]
        public float DespawnEnemiesAtPositionX = -4;
        //
        public List<EnemyData> EnemiesAlive = new List<EnemyData>();

        public List<Transform> SpawnPositions = new List<Transform>();
        public List<int> EnemiesTypes = new List<int>();
        public float SpawnInterval = 5f;

        private WaitForSeconds _waitForSeconds;

        private void Start() {
            _waitForSeconds = new WaitForSeconds(SpawnInterval);
            if(EnemiesTypes.Count == 0 || SpawnPositions.Count == 0)
                Debug.LogError("Set ManagerEnemies up", this);

            if (ShouldSpawn)
                StartCoroutine(SpawnEnemy());
        }

        //For debugging
        [ContextMenu("RepeatSpawn")]
        public void RepeatSpawn() {
            StartCoroutine(SpawnEnemy());
        }

        // 
        private IEnumerator SpawnEnemy() {
            if (Debugging) Debug.Log("SpawnEnemy", this);
            yield return _waitForSeconds;
            //Instantiate(EnemiesTypes[Random.Range(0, EnemiesTypes.Count)], SpawnPositions[Random.Range(0, SpawnPositions.Count)]);
            int enemyTypeID = EnemiesTypes[Random.Range(0, EnemiesTypes.Count)];
            var enemyTransform = ManagerPooling.I.GetPooledObject(enemyTypeID).transform;
            enemyTransform.position = SpawnPositions[Random.Range(0, SpawnPositions.Count)].transform.position;

            EnemiesAlive.Add(enemyTransform.GetComponent<EnemyData>());

            if (Debugging) Debug.Log($"enemyTransform {enemyTransform.name}", this);

            if(ShouldSpawn) RepeatSpawn();
        }

        public void DespawnEnemy(EnemyData enemyToDespawn) {
            foreach (var enemy in EnemiesAlive) {
                if (enemy == enemyToDespawn) {
                    ManagerPooling.I.ReturnToThePool(enemyToDespawn._PooledObject);
                    EnemiesAlive.Remove(enemyToDespawn);
                    break;
                }
                    
            }
        }

        /// <summary>
        /// Null if no enemies are close enough
        /// </summary>
        public EnemyData CheckIfThereAreEnemyClose() {
            EnemyData closestEnemy = null;
            List<EnemyData> enemiesCloseEnough = new List<EnemyData>();
            List<float> enemiesCloseEnoughDist = new List<float>();

            for (int i = 0; i < EnemiesAlive.Count; i++) {
                //Debug.Log($"Iterating EnemiesAlive[i] {EnemiesAlive[i].name}");
                var distanceToEnemy = (EnemiesAlive[i].transform.position - ManagerPlayer.I.PlayerTransform.position).magnitude;

                if(Debugging) Debug.Log($"distanceToEnemy {distanceToEnemy}", this);

                if (distanceToEnemy <= ManagerPlayer.I._PlayerData._PlayerStats.AttackRange) {
                    enemiesCloseEnough.Add(EnemiesAlive[i]);
                    enemiesCloseEnoughDist.Add(distanceToEnemy);
                }
            }

            if (enemiesCloseEnough.Count > 0) {
                int indexShortestDist = 0;
                for (int i = 0; i < enemiesCloseEnoughDist.Count; i++)
                {
                    if (enemiesCloseEnoughDist[i] < enemiesCloseEnoughDist[indexShortestDist])
                        indexShortestDist = i;
                }

                closestEnemy = enemiesCloseEnough[indexShortestDist];
            }

            //Debug.Log($"return closestEnemy {closestEnemy}", this);
            return closestEnemy;
        }
    }
}