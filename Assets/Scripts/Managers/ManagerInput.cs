using System;
using System.Collections;
using System.Collections.Generic;
using IG.General;
using UnityEngine;

namespace RunnerTest {
    public class ManagerInput : SingletonManagerBase<ManagerInput> {
        public Action PlayerJumpEvent;
        public Action<EnemyData> PlayerAttackEvent;

        private void Start() {

        }



        public void PlayerAction() {
            if(Debugging) Debug.Log("PlayerAction", this);
            EnemyData enemyClose = ManagerEnemies.I.CheckIfThereAreEnemyClose();
            if (enemyClose != null) {
                PlayerAttackEvent?.Invoke(enemyClose);
            }
            else {
                if(Debugging) Debug.Log("PlayerJumpEvent", this);
                PlayerJumpEvent?.Invoke();
            }
        }
    }
}