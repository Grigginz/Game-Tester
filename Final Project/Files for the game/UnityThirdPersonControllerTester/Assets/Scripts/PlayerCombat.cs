using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public LayerMask enemyLayers; 
    public Transform attackPoint;
    int myCurrentHealth;
    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public int maxHealth = 100; 
    public float attackSpeed = 2f;
    private float attackCooldown = 0f;

    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if(attackCooldown <= 0f)
        {    
            if(Input.GetKeyDown(KeyCode.E))
            {
                attackCooldown = 2f / attackSpeed;
                Attack();
                
            }
        }
        
    }
    
    void Attack()
    {
        
        
        
        //animation
        animator.SetTrigger("Attack");

        //detection
        Collider [] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //damage
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
            
            
        
    }

    public void ITakeDamage(int damage)
    {
        myCurrentHealth -= damage;

        animator.SetTrigger("ImHurt"); 

        if(myCurrentHealth <=0)
        {
            IDie();
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
          

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void IDie()
    {
        Debug.Log("Im Dead");
        
        

    }    
}
