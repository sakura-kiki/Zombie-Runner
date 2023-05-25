using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 150f;
    public void TakeDamage()
    {
        playerHealth -= GetComponent<EnemyAttack>().Damage;

        if (playerHealth == 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
