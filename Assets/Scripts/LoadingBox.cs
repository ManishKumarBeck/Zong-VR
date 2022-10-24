using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBox : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;


    private void Start()
    {
        _canvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            InventoryManager.Instance.Clear();

            SaveLoadSystem.Instance.Load();

            _canvas.gameObject.SetActive(false);

            Debug.Log("Load");
        }
    }
}
