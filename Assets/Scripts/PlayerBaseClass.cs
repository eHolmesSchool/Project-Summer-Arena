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

    //[SerializeField]

    float screenWidth = 26.6f;  ////////////////////////////////////////////This is the current "solution" to prevent the player leaving the screen
    float screenHeight = 15; ////////////////////////////////////////////It simply stops the player from travelling past a predefined area. No collision used here

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
        rbPlayer = GetComponent<Rigidbody2D>();

        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * (16f / 9f);

        Debug.Log(screenWidth + "  " + screenHeight);
    }

    void Update()
    {

        { 

        }
    }



    public void PlayerMovement() //This could be tweaked to snap to speed 1 or -1 but works fiiinnneee now.
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0);

        if (Math.Abs(horizontal) > 0.05 && Math.Abs(vertical) > 0.05) //If both directions are being pushed...
        {
            movement *= diagonalFactor;  //We dont want the player travelling much faster diagonally than they would any other way
        }

        movement *= speed;

        if (movement.x > 0.05 && transform.position.x > screenWidth)
        {
            movement.x = 0;
        }
        if (movement.x < -0.05 && transform.position.x < -screenWidth)
        {
            movement.x = 0;
        }
        if (movement.y > 0.05 && transform.position.y > screenHeight)
        {
            movement.y = 0;
        }
        if (movement.y < -0.05 && transform.position.y < -screenHeight)
        {
            movement.y = 0;
        }

        //Debug.Log(transform.position.x + movement.x);

        transform.position += movement;
    }



    public void PointToCursor()
    {
        Vector3 cursorPos = Input.mousePosition;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

        Vector2 faceDirection = new Vector2(cursorPos.x - transform.position.x, cursorPos.y - transform.position.y);

        transform.up = faceDirection;
        return;
    }


    public void CollisionCheck()
    {
        return;
    }
}
