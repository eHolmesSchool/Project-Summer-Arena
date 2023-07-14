using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerBaseClass : MonoBehaviour
{
    public PlayerState currentPlayerState = PlayerState.None;
    [SerializeField] float speed = 1;
    [SerializeField] float diagonalFactor = 0.75f;
    Rigidbody2D rbPlayer;

    float arenaWidth = 26.6f;  ////////////////////////////////////////////This is the current "solution" to prevent the player leaving the screen
    float arenaHeight = 15; ////////////////////////////////////////////It simply stops the player from travelling past a predefined area

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



    private void PlayerMovement() //This could be tweaked to snap to speed 1 or -1 but works fiiinnneee now.
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);

        if (Math.Abs(horizontal) > 0.05 && Math.Abs(vertical) > 0.05) //If both directions are being pushed...
        {
            movement *= diagonalFactor;  //we dont want the player travelling faster diagonally than they would any other way
        }

        Debug.Log($" ");

        movement *= speed;

        Math.Round(movement.x, 0);
        Math.Round(movement.y, 0);

        if (transform.position.x + movement.x < -arenaWidth || transform.position.x + movement.x > arenaWidth)
        {
            movement.x = 0;
        }
        if (transform.position.y + movement.y < -arenaHeight || transform.position.y + movement.y > arenaHeight)
        {
            movement.y = 0;
        }
        rbPlayer.velocity = movement;
    }


    private void PointToCursor()
    {
        Vector3 cursorPos = Input.mousePosition;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

        Vector2 faceDirection = new Vector2(cursorPos.x - transform.position.x, cursorPos.y - transform.position.y);

        transform.up = faceDirection;
        return;
    }


    private void CollisionCheck()
    {
        return;
    }
}
