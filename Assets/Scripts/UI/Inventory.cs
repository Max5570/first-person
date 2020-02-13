using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject bow;
    public GameObject bowUI;
    public GameObject knife;
    public GameObject knifeUI;
    public Text arrowCount;

    public bool open = false;

    public void Update(){
        
         List<string> itemList = Managers.Inventory.GetItemsList();
         foreach (string item in itemList)
        {
            if (item == "bow")
            {
                bowUI.SetActive(true);
                if (knife.activeSelf == false)
                {
                 bow.SetActive(true);
                }
                
            }
            arrowCount.text = "x2";
            if (item == "knife")
            {
                knifeUI.SetActive(true);
                if (bow.activeSelf == false)
                {
                 knife.SetActive(true);
                }
            }
        }
    }

    public void SetBowMain(){
        knife.SetActive(false);
        bow.SetActive(true);
    }
    public void SetKnifeMain(){
        bow.SetActive(false);
        knife.SetActive(true);
    }
     
    public void InventoryOpen(){
       open = !open;
       inventory.SetActive(open);
   }
}
