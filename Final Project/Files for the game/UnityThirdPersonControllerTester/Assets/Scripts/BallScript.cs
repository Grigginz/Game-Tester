using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
   
    
    
    public GameControllerUI Controller;

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Goal")
        {
            Controller.IncrementScore();   
            transform.position = GameObject.Find("BallPosition").transform.position;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        else if( other.gameObject.tag == "EnemyGoal")
        {
            Controller.BlueTeamScore();   
            transform.position = GameObject.Find("BallPosition").transform.position;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;  
        }

    }                                   
    
                                
}
