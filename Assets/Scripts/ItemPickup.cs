using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, ISaveable
{
    [SerializeField]
    private Item Item;

    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private bool _isPickup = false;

    [SerializeField]
    private Transform _sphereTransform;

    private void Start()
    {
        _sphereTransform = GetComponent<Transform>();


    }

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        InventoryManager.Instance.ShowInventory();
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand") && _isPickup == false)
        {
            Pickup();
            Debug.Log("Hand");

            _isPickup = true;

          //  _canvas.enabled = false;

            SaveLoadSystem.Instance.Save();

            Debug.Log("Saved");
        }
    }




    public object SaveState()
    {
        return new SaveData()
        {
            positionX = _sphereTransform.position.x,
            positionY = _sphereTransform.position.y,
            positionZ = _sphereTransform.position.z,

            isPickup = false,
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;

        Vector3 pos = _sphereTransform.position;

        pos.x = saveData.positionX;
        pos.y = saveData.positionY;
        pos.z = saveData.positionZ;

        _sphereTransform.position = pos;

        _isPickup = saveData.isPickup;
    }

    [Serializable]
    private struct SaveData
    {
        public float positionX;
        public float positionY;
        public float positionZ;

        public bool isPickup;
    }




}
