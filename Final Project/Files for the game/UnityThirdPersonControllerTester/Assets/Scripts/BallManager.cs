using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
     #region 
    
    public static BallManager instance; 

    void Awake () 
    {
    instance = this;
    }
    
    #endregion

    public GameObject ball;
}
