using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
 

    [SerializeField]
    private GameObject[] _tabs;

    public void OnTabSwitch(GameObject tab)
    {
        tab.SetActive(true);
        
        for(int i = 0; i < _tabs.Length; i++)
        {
            if(_tabs[i] != tab)
            {
                _tabs[i].SetActive(false); 
            }
        }
    }
}
