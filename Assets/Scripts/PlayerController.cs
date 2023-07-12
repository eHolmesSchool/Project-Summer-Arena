using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("If you see this Text Me AAAAAAAAAA");
    }

    // Update is called once per frame
    void Update()
    {

    }



    public enum States{
        None,
        Stationary,
        Walking,
        Dashing,
        Shooting,
        Reloading,
        Dead,

    }
}
