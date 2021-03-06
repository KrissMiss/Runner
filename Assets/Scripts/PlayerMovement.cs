using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rb;
    public float timerTurn = 0;
    bool turnLeft = false;
    bool turnRight = false;
    bool turnRight2 = false;
    public float turnAngle = 30;
    public GameObject diePanel;
    public bool end = false;
    public Menu menu;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        end = false;
    }


    void Update()
    {
        rb.velocity = transform.forward * -speed;

        if (transform.position.y < 0.9)
        {
            Time.timeScale = 0;
            end = true;
            diePanel.SetActive(true);
            menu.pause = true;
        }


        if (turnLeft == true && transform.rotation.eulerAngles.y > 181)
        {
            timerTurn += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - timerTurn * turnAngle, 0);
        }

        else if (turnLeft == true && transform.rotation.eulerAngles.y < 181)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            turnLeft = false;
            timerTurn = 0;
        }

        if (turnRight == true && transform.rotation.eulerAngles.y < 271)
        {
            timerTurn += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + timerTurn * turnAngle, 0);
        }

        else if (turnRight == true && transform.rotation.eulerAngles.y > 270)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            turnRight = false;
            timerTurn = 0;
        }

        if (turnRight2 == true && transform.rotation.eulerAngles.y < 361 && transform.rotation.eulerAngles.y >= 270)
        {
            timerTurn += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + timerTurn * turnAngle, 0);
        }

        else if (turnRight2 == true && transform.rotation.eulerAngles.y >= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            turnRight2 = false;
            timerTurn = 0;
            print(transform.rotation.eulerAngles.y);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TurnLeft"))
        {
            turnLeft = true;
        }

        if (other.CompareTag("TurnRight"))
        {
            turnRight = true;
        }

        if (other.CompareTag("TurnRight2"))
        {
            turnRight2 = true;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Time.timeScale = 0;
            diePanel.SetActive(true);
            end = true;
            menu.pause = true;
        }
    }
}
