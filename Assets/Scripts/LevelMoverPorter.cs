using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMoverPorter : MonoBehaviour {
    public float Speed;
    public float PositionXAfterWhichTeleport;

    public Transform ElementToReplace;

    public Vector3 newPosition;

    private void Start()
    {
        newPosition = ElementToReplace.position;
    }


    private void Update()
    {
        if (transform.position.x > PositionXAfterWhichTeleport) {
            transform.Translate(Speed * Time.deltaTime, 0 ,0);
        }
        else {
            transform.position = newPosition;
        }
    }
}
