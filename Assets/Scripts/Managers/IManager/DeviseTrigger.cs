using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviseTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    public bool requireKey;
    private void OnTriggerEnter(Collider other)
    {
        if (requireKey && Managers.Inventory.equippedItem != "goldkey")
        {
            print("false");
            return;
        }
        foreach (GameObject target in targets)
        {
            target.SendMessage("Activate");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Deactivate");
        }
    }
    public void NewItemRequired()
    {
        if (requireKey && Managers.Inventory.equippedItem != "goldkey")
        {
            print("false");
            return;
        }
        foreach (GameObject target in targets)
        {
            target.SendMessage("Activate");
        }
    }
}
