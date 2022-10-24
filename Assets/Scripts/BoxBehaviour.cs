using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    [SerializeField, Header("Particles")]
    private GameObject _particleSystem;
    [SerializeField]
    ParticleSystem _boxParticle;


    [SerializeField, Header("Canvas")]
    private Canvas _canvas;

    private void Start()
    {
        _boxParticle = _particleSystem.GetComponent<ParticleSystem>();

        if(_canvas != null)
        {
            _canvas.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sphere"))
        {
            if (_particleSystem != null)
            {
                _boxParticle.Play();
                _canvas.enabled = true;
             
            }

            else
            {
                SaveLoadSystem.Instance.Load();
                Debug.Log("Load");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Sphere"))
        {
            _canvas.enabled = false;
        }
    }
}
