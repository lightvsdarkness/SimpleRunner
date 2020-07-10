using System;
using System.Collections;
using System.Collections.Generic;
using IG.General;
using UnityEngine;

namespace RunnerTest
{
    public class ManagerPooling : SingletonManagerBase<ManagerPooling> {

        public List<PooledObject> PrefabObjects = new List<PooledObject>();
        [Space]
        public List<PooledObject> PooledObjects = new List<PooledObject>();

        protected override void Awake() {
            PooledObject[] ObjectsWithPools = GameObject.FindObjectsOfType<PooledObject>();
            foreach (PooledObject pooledObject in ObjectsWithPools) {
                PooledObjects.Add(pooledObject);
                pooledObject.gameObject.SetActive(false);
            }
        }


        public PooledObject GetPooledObject(int typeID) {
            for (int i = 0; i < PooledObjects.Count; ++i) {
                if (!PooledObjects[i].UsedNow && PooledObjects[i].TypeID == typeID) {
                    if(Debugging) Debug.Log($"Found PooledObjects[i] {PooledObjects[i].gameObject}", this);
                    PooledObjects[i].UsedNow = true;
                    PooledObjects[i].gameObject.SetActive(true);
                    return PooledObjects[i];
                }
                    
            }
            //PooledObjects
            for (int i = 0; i < PrefabObjects.Count; ++i) {
                if (PrefabObjects[i].TypeID == typeID) {

                    var newPooledObject = Instantiate(PrefabObjects[i]);
                    PooledObjects.Add(newPooledObject);
                    newPooledObject.UsedNow = true;
                    newPooledObject.gameObject.SetActive(true);
                    if (Debugging) Debug.Log($"Createn newPooledObject {newPooledObject.gameObject}", this);
                        return newPooledObject;
                }
                    
            }
            if (Debugging) Debug.LogError($"Add Type {typeID} prefabs to PrefabObjects", this);
            return null;
        }

        public void ReturnToThePool(PooledObject pooledObject) {
            pooledObject.gameObject.SetActive(false);
            pooledObject.UsedNow = false;
        }
    }
}