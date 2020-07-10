using System.Collections;
using System.Collections.Generic;
using IG.General;
using UnityEngine;

namespace RunnerTest
{
    public class ManagerCollectibles : SingletonManagerBase<ManagerCollectibles> {
        [SerializeField] private bool ShouldSpawn;
        [Space]
        public int CollectibleTypeID = 52;

        public List<Transform> SpawnPositions = new List<Transform>();

        public float SpawnInterval = 5f;

        private WaitForSeconds _waitForSeconds;

        private void Start() {
            _waitForSeconds = new WaitForSeconds(SpawnInterval);

            if(ShouldSpawn)
                StartCoroutine(SpawnCollectible());
        }

        //For debugging
        [ContextMenu("RepeatSpawn")]
        private void RepeatSpawn() {
            StartCoroutine(SpawnCollectible());
        }

        private IEnumerator SpawnCollectible() {
            yield return _waitForSeconds;

            var collectibleTransform = ManagerPooling.I.GetPooledObject(CollectibleTypeID).transform;
            collectibleTransform.position = SpawnPositions[Random.Range(0, SpawnPositions.Count)].transform.position;

            if(ShouldSpawn) RepeatSpawn();
        }
    }
    
}