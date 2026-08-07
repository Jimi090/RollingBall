using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
//using System.Numerics;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public float speed = 0;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;

    void Start()
    {
        rb = GetComponent <Rigidbody>();
        score = 0;
        setScoreText();
        winTextObject.SetActive(false);
    }
    void Update()
    {
        if (transform.position[1] < -10)
        {
            transform.position = new Vector3(0,0.5f,0);
            rb.linearVelocity = Vector3.zero;
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

    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 12)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
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
            setScoreText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
}
