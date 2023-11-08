using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] private Button btn;
    private Button _inventoryButton;

    [SerializeField] private ItemSlot[] itemSlots;
    private bool _menuActivated = false;
    // Start is called before the first frame update
    void Awake()
    {
        //ItemSlot slot = GetComponentInChildren<ItemSlot>();
        
        btn.onClick.AddListener(ToggleMenu);
        gameObject.SetActive(false);
    }

    private void ToggleMenu()
    {
        Debug.Log("Button Pressed");
        if(_menuActivated)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            _menuActivated = false;
            Debug.Log("Button Pressed");
        }
        else
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
            _menuActivated = true;
            Debug.Log("Button Pressed");
        }
    }

    public void AddItem(string _itemName, Sprite _itemSprite, string _itemDescription)
    {
        Debug.Log(_itemSprite.name + " Passed to manager");
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(!itemSlots[i].IsFull)
            {
                Debug.Log("Added To Slot");
                itemSlots[i].AddItemToSlot(_itemName, _itemSprite, _itemDescription);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].DeactivateSlot = false;
        }
    }
}
