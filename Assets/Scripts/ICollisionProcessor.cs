using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest {
    public interface ICollisionProcessor {

        Transform Transform { get;  }
        bool TouchingTarget { get; }
        void Collided();

    }
}