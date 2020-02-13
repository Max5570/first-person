using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float speed;
    public Transform healthBar;
    public bool isDead;

    private float obstacleRange = 5.0f;

    Animator anim;
    public void Start()
    {
        anim = GetComponent<Animator>();
        ChangeHealth(0);
        gameObject.tag = "CanTakeDamage";
        anim.SetBool("Walk", true);
    }

    private void Update()
    {
        if (!isDead)
        {
        Ray ray = new Ray(transform.position, transform.forward); 
        RaycastHit hit; if (Physics.SphereCast(ray, 0.75f, out hit)) 
        { 
            if (hit.distance < obstacleRange) 
            { 
                float angle = Random.Range(-110, 110); 
                transform.Rotate(0, angle, 0); 
            } 
        }
        }
    }
    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            health = 0;
            healthBar.localScale = new Vector3(health / maxHealth, 1f);
            anim.SetBool("Dead", true);
            isDead = true;
        }
        anim.SetBool("RunFaster", true);
        StartCoroutine(NormalyWalk());
        healthBar.localScale = new Vector3(health / maxHealth, 1f);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RotateAI")
        {
            float angle = Random.Range(150, 190);
            transform.Rotate(0, angle, 0);
        }
    }

    IEnumerator NormalyWalk()
    {
        yield return new WaitForSeconds(5f);
        anim.SetBool("RunFaster", false);
    }
}
