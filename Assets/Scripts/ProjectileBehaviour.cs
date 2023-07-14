using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] Vector3 speed = new(1,1,0);
    int damage = 1;
    Collider2D collider;

    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        transform.position += speed;
    }

    void OnCollisionEnter2D() 
    {
        gameObject.SetActive(false);
        transform.position = new(0,0,0);
    }
}
