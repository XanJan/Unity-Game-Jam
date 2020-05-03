using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed;
    public Camera cam;

    public Vector2 movement;
    Vector2 mousePos;
    private TargetScript targetScript;
    void Start()
    {
        targetScript = GameObject.Find("Target").GetComponent<TargetScript>();
    }

    void Update()
    {
        PlayerInput();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void PlayerInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrel"))
        {
            Destroy(collision.gameObject);
            targetScript.AmountOfWater += 10;
        }
    }
}
