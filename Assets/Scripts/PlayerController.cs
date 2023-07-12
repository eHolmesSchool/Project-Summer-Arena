using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerState currentPlayerState = PlayerState.None;


    void Start()
    {
        Debug.Log("If you see this Text Evan AAAAAAAAAA");
    }

    void Update()
    {
        switch (currentPlayerState)
        {

        }

    }



    public enum PlayerState{
        None,
        Alive,
        Dashing,
        //Shooting, Unless we NEED it I dont think this one was a good idea. Cause we can shoot
        Reloading,
        Dead,

    }
}
