using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public float health { get; private set; }
    public float maxHealth { get; private set; }
    public Transform healthBar1;

    public void Startup()
    {
        print("Player manager starting...");

        health = 50;
        maxHealth = 100;

        status = ManagerStatus.Started;

        ChangeHealth1(0);
    }
   

    public void ChangeHealth1(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }

        healthBar1.localScale = new Vector3(health / maxHealth, 1f);

    }
}