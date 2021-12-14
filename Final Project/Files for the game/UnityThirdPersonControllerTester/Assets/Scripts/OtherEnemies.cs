using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherEnemies : MonoBehaviour
{
    public Animator animator; 
    public LayerMask playerLayers;
    public Transform enemyAttackBox;
    int currentHealth;
    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public int maxHealth = 100; 
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if(attackCooldown <= 0f)
        {
            attackCooldown = 1f / attackSpeed;
            EnAttack();

        }
    }

    void EnAttack()
    {
        Collider [] hitPlayers = Physics.OverlapSphere(enemyAttackBox.position, attackRange, playerLayers);

        //damage
        foreach (Collider player in hitPlayers)
        {
            player.GetComponent<PlayerCombat>().ITakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt"); 

        if(currentHealth <=0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Enemy died");
        
        animator.SetBool("IsDead", true);
        Destroy (gameObject);
        GetComponent<Collider>().enabled = false; 

        
        
        this.enabled = false; 
        

    }    

}
