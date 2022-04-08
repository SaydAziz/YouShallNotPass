using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] itemInventory = new Item[3];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Item item in itemInventory)
        {
            string i = item.itemName;
            print(i);
        }
    }

    public void AddItem(Item item)
    {
        for (int counter = 0; counter < itemInventory.Length; counter++)
        {
            if (itemInventory[counter] == null)
            {
                itemInventory[counter] = item;
                return;   
            }      
        }
    }


}
