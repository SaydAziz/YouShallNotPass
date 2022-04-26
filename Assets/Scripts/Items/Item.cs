using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
    
    protected string _itemName;
    public string itemName
    {
        get => _itemName;
    }
    
    private Vector2 lerpPos1;
    private Vector2 lerpPos2;
    private float fraction = 0;
    private Collider2D collider;
    private SpriteRenderer renderer;
    protected bool isPickedUp = false;

    protected virtual void Start()
    {
        lerpPos1 = transform.position; 
        lerpPos2 = new Vector2(transform.position.x, transform.position.y + .3f);
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
        
    }

    void FixedUpdate()
    {

        if (isPickedUp == false)
        {
            PickUpLerp();
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player" || other.collider.tag == "Player2")
        {
            if (isPickedUp)
            {
                Debug.Log("TESTING");
                other.gameObject.GetComponent<Player>().TakeDamage(100);   
            }
            else
            {    
                isPickedUp = true;
                other.gameObject.GetComponent<Inventory>().AddItem(Dupe(other));
                StartCoroutine(TempDisable(2));
            }
        }
    }

    public virtual void Use(){}

    private void PickUpLerp()
    {
        fraction += Time.deltaTime;
        transform.position = Vector2.Lerp(lerpPos1, lerpPos2, Mathf.PingPong(fraction, 1));
        
    }
    
    public Item Dupe(Collision2D other)
    {
        Item addedItem = Instantiate(this, other.gameObject.transform);
        addedItem.transform.localPosition = new Vector2(0, 0);
        addedItem.CopyData(itemName, isPickedUp);
        return addedItem;
    }

    private IEnumerator TempDisable(int time)
    {
        setHide(false);
        yield return new WaitForSeconds(time);
        isPickedUp = false;
        setHide(true);
    }

    public void CopyData(string name, bool pickedUp)
    {
        _itemName = name;
        isPickedUp = pickedUp;
    }

    private void setHide(bool setting)
    {
        collider.enabled = setting;
        renderer.enabled = setting;
    }
}
