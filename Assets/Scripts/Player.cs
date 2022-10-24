using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, ISaveable
{
    [SerializeField]
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GetComponent<Transform>();

       
    }

    public object SaveState()
    {
        return new SaveData()
        {
            positionX = _playerTransform.position.x,
            positionY = _playerTransform.position.y,
            positionZ = _playerTransform.position.z,
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
       
        Vector3 pos = _playerTransform.position;

        pos.x = saveData.positionX;
        pos.y = saveData.positionY;
        pos.z = saveData.positionZ;

        _playerTransform.position = pos;
    }

   [Serializable]
   private struct SaveData
    {
        public float positionX;
        public float positionY;
        public float positionZ;
    }



}
