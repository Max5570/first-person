using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    
    void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Managers.Inventory.AddItem(itemName);
            Destroy(this.gameObject);
            print("Item collected");
        }
        
    }
}