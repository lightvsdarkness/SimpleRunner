using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest {
    public class PlayerHealth : MonoBehaviour {
        [Header("Links")]
        [SerializeField] private PlayerData _playerData;

        private void Awake() {
            if (_playerData == null)
                _playerData = GetComponent<PlayerData>();
        }


        public void Damage(int damage) {
            _playerData._PlayerStats.Health = _playerData._PlayerStats.Health - damage;
            if (_playerData._PlayerStats.Health <= 0) {
                ManagerGame.I.ExitGame();
            }
        }
    }
}