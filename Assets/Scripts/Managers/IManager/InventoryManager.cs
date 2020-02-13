using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeviseTrigger))]
public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public string equippedItem { get; private set; }

    private Dictionary<string, int> _items;
    [SerializeField] private GameObject target;

    public DeviseTrigger devTrigger { get; private set; }
    private void Start()
    {
        devTrigger = GetComponent<DeviseTrigger>();
    }
    public void Startup()
    {
        print("Inventory manager starting...");

        _items = new Dictionary<string, int>();

        status = ManagerStatus.Started;
    }
    public List<string> GetItemsList()
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }

    public int GetItemCount(string name)
    {
        if (_items.ContainsKey(name))
        {
            return _items[name];
        }
        return 0;
    }
    private void DisplayItems()
    {
        string itemsDisplay = "Items: ";
        foreach (KeyValuePair<string, int> item in _items)
        {
            itemsDisplay += item.Key + " ("+ item.Value +") ";
        }
        print(itemsDisplay);
    }

    public void AddItem(string name) 
    {
        if (_items.ContainsKey(name))
        {
            _items[name] += 1;
        }
        else
        {
            _items[name] = 1;
        }

        DisplayItems();
    }
    public bool EquipItem(string name)
    {
        if (_items.ContainsKey(name) && equippedItem != name)
        {
            equippedItem = name;
            target.SendMessage("NewItemRequired");
            print("Equipped " + name);
            return true;
        }
        equippedItem = null;
        print("Unequipped");
        return false;
    }
    public bool ConsumeItem(string name)
    {
        if(_items.ContainsKey(name))
        {
            _items[name]--;
            if (_items[name]==0)
            {
                _items.Remove(name);
            }
        }
        else
        {
            print("cannot consume " + name);
            return false;
        }
        DisplayItems();
        return true;
    }
}
