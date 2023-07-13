using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerState currentPlayerState = PlayerState.None;
    [SerializeField] GameObject Player;
    Rigidbody2D rbPlayer;

    public enum PlayerState
    {
        None,
        Alive,
        Dashing,
        Reloading,
        Dead,

    }


    void Start()
    {
        Debug.Log("If you see this Text Evan AAAAAAAAAA");
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        switch (currentPlayerState) //Starts on None
        {
            case PlayerState.None: //Moves to Alive

                currentPlayerState = PlayerState.Alive;
                break;


            case PlayerState.Alive: //Can become Dashing or Reloading or Dead

                PlayerMovement();
                PointToMouse();
                


                break;


            case PlayerState.Dashing: //Can become Alive or Dead(?) 


                break;


            case PlayerState.Reloading: //Can become Alive or Dead


                break;


            case PlayerState.Dead: //Can become None


                break;

        }



    }


    private void PlayerMovement()
    {
        rbPlayer.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        if ( Input.GetAxis("Horizontal") < -0.05 || Input.GetAxis("Horizontal") > 0.05)
        {
            if (Input.GetAxis("Vertical") < -0.05 || Input.GetAxis("Vertical") > 0.05)
            {
                //rbPlayer.velocity.x /= 2;
                //rbPlayer.velocity.y /= 2; 
            }
        }
    }


    private void PointToMouse()
    {
        return;
    }


}
