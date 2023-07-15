using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 1;
    int damage = 1;
    Collider2D collider;

    //private void OnEnable()
    //{
        // //This space is used because we arent Start ing the bullets over and over, we are Disabling and re Enabling them again.
    //}



    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        transform.position += transform.up * speed;
        //transform.Rotate(Vector3.forward * 0.1f); //Speen
        Vector3 pos = transform.position;
        if (pos.x <-1000 ||  pos.y <-1000 || pos.x >  1000 || pos.y > 1000)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        //gameObject.SetActive(false);
        //transform.position = new(0, 0, 0);
    }
}
