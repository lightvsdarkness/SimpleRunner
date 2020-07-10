using System.Collections;
using System.Collections.Generic;
using IG.General;
using RunnerTest;
using UnityEngine;

namespace RunnerTest {
    public class ManagerPlayer : SingletonManagerBase<ManagerPlayer> {
        public Transform PlayerTransform = null;
        public PlayerData _PlayerData = null;

        protected override void Awake() {
            PlayerData[] players = FindObjectsOfType<PlayerData>();
            if (players.Length == 0)
                Debug.LogError("No player in scene", this);
            else if (players.Length > 1)
                Debug.LogError("More than one player", this);
            else {
                PlayerTransform = players[0].transform;
                _PlayerData = players[0];
            }
                

        }

    }
}