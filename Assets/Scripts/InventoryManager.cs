using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField]
    private List<Item> Items = new List<Item>();

    [SerializeField]
    private Transform ItemContent;
    [SerializeField]
    private GameObject InventoryItem;


    [SerializeField]
    private Canvas _inventoryCanvas;
    [SerializeField]
    private bool _showInventory = false;

    private void Awake()
    {     

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }        

    }

    private void Start()
    {
        _inventoryCanvas.enabled = false;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void Clear()
    {
        Items.Clear();
    }


    private void Update()
    {       
      

    }

    public void ShowInventory()
    {
        _inventoryCanvas.enabled = true;
        ListItems();
    }

    public void ListItems()
    {

        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }


        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemIcon = obj.transform.GetComponent<Image>();
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();

           


            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

        }
    }


    public void CloseCanvas()
    {
        _inventoryCanvas.enabled = false;
        Debug.Log("Close");
    }

    

}
