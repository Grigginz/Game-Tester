using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour {
    
    public float Speed; 

    void Update () {
        PlayerMovement ();
    }

    void PlayerMovement()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        Vector3 playerMovement = new Vector3(ver, 0f, hor) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
}
