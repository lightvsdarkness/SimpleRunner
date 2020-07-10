using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest {
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
    public class GameSettings : ScriptableObject {
        public float EnemySpawnInterval;
        public LayerMask MaskFloor;
    }
}