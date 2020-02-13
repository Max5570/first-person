using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVisible : MonoBehaviour
{
    public GameObject[] setVisible;
    public GameObject[] setInvisible;
    
    public void Set(){
        foreach (GameObject obj in setVisible)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in setInvisible)
        {
            obj.SetActive(false);
        }
    }

}
