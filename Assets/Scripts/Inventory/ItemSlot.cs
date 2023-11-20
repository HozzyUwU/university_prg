using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

#region ItemData
    private string _itemName;
    private Sprite _itemSprite;

    private Image _itemImage;
    private string _itemDescription;
#endregion

#region DescriptionSlotData
    [SerializeField]
    private Image _itemDescriptionSprite;
    [SerializeField]
    private TMP_Text _itemDescriptionNameText;
    [SerializeField]
    private TMP_Text _itemDescriptionText;
#endregion

#region ItemSlotData
    private bool _isOccupied = false;

    [SerializeField] private GameObject _selectedShader;
    private bool _itemSlotSelected;
#endregion
    [SerializeField] private InventoryManager _inventoryManager;
    // Start is called before the first frame update

    public bool DeactivateSlot
    {
        get {return _itemSlotSelected;}
        set
        {
            _selectedShader.SetActive(value);
            _itemSlotSelected = value;
        }
    }
    public bool IsFull
    {
        get{return _isOccupied;}
        set
        {
            _isOccupied = value;
        }
        
    }
    void Awake()
    {
        _itemImage = GetComponent<Image>();
    }
    public void AddItemToSlot(string _itemName, Sprite _itemSprite, string _itemDescription)
    {
        Debug.Log(_itemSprite.name + " Added To Slot inside");
        this._itemName = _itemName;
        this._itemSprite = _itemSprite;
        this._itemDescription = _itemDescription;
        _isOccupied = true;
        //_itemImage.material = _sprite;
        _itemImage.sprite = _itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MakeSlotSelected();
    }

    private void MakeSlotSelected()
    {
        _inventoryManager.DeselectAllSlots();
        _selectedShader.SetActive(true);
        _itemSlotSelected = true;
        _itemDescriptionNameText.text = _itemName;
        _itemDescriptionText.text = _itemDescription;
        _itemDescriptionSprite.sprite = _itemSprite;
    }
}


