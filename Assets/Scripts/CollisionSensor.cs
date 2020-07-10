using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTest {
    public class CollisionSensor : MonoBehaviour {
        public ICollisionProcessor _CollisionProcessor;
        [SerializeField] private string TagToCollideWith = "Ground";


        private void Awake() {
            _CollisionProcessor = GetComponentInParent<ICollisionProcessor>();
        }

        private void Update() {
            Debug.DrawRay(_CollisionProcessor.Transform.position, Vector3.down * 2, Color.red, 1f);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.55f, ManagerGame.I._GameSettings.MaskFloor);

            if (hit.collider != null) {
                //Debug.Log($"hit.collider.name {hit.collider.name}", this);
                if (hit.collider.tag == TagToCollideWith) {
                    _CollisionProcessor.Collided();
                }
            }

        }

        private void OnTriggerEnter2D(Collider2D collider) {
            //Debug.Log($"collider.gameObject.name {collider.gameObject.name}", this);
            if (collider.gameObject.tag == TagToCollideWith) {
                _CollisionProcessor.Collided();
            }

        }
    }
}