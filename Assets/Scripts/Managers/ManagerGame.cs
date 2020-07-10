using System.Collections;
using System.Collections.Generic;
using IG.General;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunnerTest {
    public class ManagerGame : SingletonManagerBase<ManagerGame> {

        public GameSettings _GameSettings;

        //protected override void Awake() {
        //}

        //private void Start() {

        //}


        public void StartGame() {
            SceneManager.LoadScene(0);
        }
        public void ExitGame() {
            Application.Quit();
        }
    }
}