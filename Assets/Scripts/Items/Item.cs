using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
    
    [SerializeField] protected string _itemName;

    public string itemName
    {
        get => _itemName;
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<Inventory>().AddItem(Dupe(other));
            Destroy(this.gameObject);
        }
    }

    public virtual void Use(){}
    
    public Item Dupe(Collision2D other)
    {
        Item addedItem = Instantiate(this, other.gameObject.transform);
        addedItem.transform.localPosition = new Vector2(0, 0);
        addedItem.CopyData(itemName);
        return addedItem;
    }

    public void CopyData(string name)
    {
        _itemName = name;
        Debug.Log(name);
    }
}
