using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class KnifeDamage : MonoBehaviour
{
    Animator anim;
    public float damage;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            anim.SetBool("Attack", true);
            StartCoroutine(Anim());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CanTakeDamage")
        {
            other.gameObject.SendMessage("ChangeHealth", damage);
        }
    }

    IEnumerator Anim()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Attack", false);
    }
}
