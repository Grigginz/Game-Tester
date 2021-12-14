using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Var
    [SerializeField] public float mouseSensitivity; 

    //Ref
    private Transform parent; 

    private void Start()
    {
        parent = transform.parent; 
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void Update()
    {
        Rotate();
        if(PauseMenuScript.GameIsPaused)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        parent.Rotate(Vector3.up, mouseX);
    }

    
    
}
