using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCharPlayerController : PlayerBaseClass
{

    private void Update()
    {
        switch (currentPlayerState) //Starts on None
        {
            case PlayerState.None: //Moves to Alive

                currentPlayerState = PlayerState.Alive;
                break;


            case PlayerState.Alive: //Can become Dashing or Reloading or Dead

                PlayerMovement(); //This is where we prevent it from flying off the stage
                PointToCursor();

                CollisionCheck();

                break;


            case PlayerState.Dashing: //Can become Alive or Dead(?) 


                break;


            case PlayerState.Reloading: //Can become Alive or Dead


                break;


            case PlayerState.Dead: //Can become None


                break;
        }
    }
}
