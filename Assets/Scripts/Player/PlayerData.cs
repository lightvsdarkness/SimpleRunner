using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest {
    public class PlayerData : MonoBehaviour {
        [Serializable]
        public class PlayerStats {
            // Maybe read ScriptableObject here in the future
            public int Health = 1;
            public float Speed = 2;
            public int ForceJump = 250;
            public float AttackRange = 1;
        }

        public PlayerStats _PlayerStats;

        public PlayerMovement _PlayerMovement;

        private void Awake() {
            if (_PlayerMovement == null)
                _PlayerMovement = GetComponentInChildren<PlayerMovement>();
        }


    }
}