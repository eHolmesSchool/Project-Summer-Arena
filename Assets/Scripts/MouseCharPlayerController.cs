using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCharPlayerController : MonoBehaviour
{
    public PlayerState currentPlayerState = PlayerState.None;
    [SerializeField] float speed = 1;
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
                PointToCursor();
                


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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        Math.Round(movement.x);
        Math.Round(movement.y);

        if (Math.Abs(horizontal)>0.05 && Math.Abs(vertical) > 0.05) //If both directions are being pushed
        {
            movement /= 2;  //we dont want the player travelling faster diagonally than they would any other way
        }

        rbPlayer.velocity = movement * speed;

    }


    private void PointToCursor()
    {

        return;
    }


}
