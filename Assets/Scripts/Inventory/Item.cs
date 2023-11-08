using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string _itemName;

    private Sprite _sprite;

    [TextArea]
    [SerializeField]
    private string _itemDescription;

    [SerializeField] private InventoryManager _inventoryManager;
    // Start is called before the first frame update
    void Awake()
    {

        // if(GameObject.Find("InventoryCanvas").TryGetComponent<InventoryManager>(out _inventoryManager))
        // {
        //     Debug.Log("abobus");
        // }
        // else{
        //     Debug.Log("dsnvgkfdlgvnfdlkosavmgokdsfg");
        // }
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
//            Debug.Log(_sprite.name + " collided");
            _inventoryManager.AddItem(_itemName, _sprite, _itemDescription);
            Destroy(gameObject);
        }
    }
}
