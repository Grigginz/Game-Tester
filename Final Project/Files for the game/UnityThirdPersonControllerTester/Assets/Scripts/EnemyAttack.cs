using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    
    
    public Animator animator; 
    public GameObject theplayer;
    public GameObject theenemy;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        theplayer = GameObject.Find ("Player");
        theenemy = GameObject.FindWithTag ("Enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (theenemy.transform.position - theplayer.transform.position).magnitude;
        
        if(distance < 2f)
        {
            //animation
            animator.SetTrigger("EnemyAttack");
        }

        
    }

    
   

}
