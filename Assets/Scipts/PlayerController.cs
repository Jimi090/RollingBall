using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
//using System.Numerics;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public float speed = 0;
    private int score;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI winTextObject;
    private float time = 0;
    private bool isTimeRunning;

    void Start()
    {
        rb = GetComponent <Rigidbody>();
        score = 0;
        winTextObject.enabled = false;
        isTimeRunning = true;
    }
    void Update()
    {
        if (transform.position[1] < -10)
        {
            transform.position = new Vector3(0,0.5f,0);
            rb.linearVelocity = Vector3.zero;
            time = 0;
        }
        if (isTimeRunning)
        {
            time += Time.deltaTime;
            SetTimeText(time);
        }
        
        if (score >= 1 && isTimeRunning)
        {
            isTimeRunning = false;
            winTextObject.enabled = true;

            string minutes = Mathf.FloorToInt(time/60).ToString();
            string seconds = Mathf.FloorToInt(time%60).ToString();
            if (int.Parse(seconds) < 10)
            {
                seconds = "0"+seconds;
            }
            winTextObject.text = "You won!\nTime: "+minutes+":"+seconds;
        }
    }

    void OnMove(InputValue movementValue)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
            movementY = movementVector.y;
        }
    
    void OnJump(InputValue jumpValue)
    {
        if (jumpValue.isPressed && rb.linearVelocity[1] == 0)
        {
            rb.AddForce(Vector3.up * 6f, ForceMode.Impulse);
        }
    }

    void SetTimeText(float time)
    {
        string minutes = Mathf.FloorToInt(time/60).ToString();
        string seconds = Mathf.FloorToInt(time%60).ToString();
        if (int.Parse(seconds) < 10)
        {
            seconds = "0"+seconds;
        }
        timeText.text = minutes+":"+seconds;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
        }
    }
}
