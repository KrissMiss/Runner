using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject finishPanel;
    public bool finish = false;
    public float timer;
    public GameObject indicator;
    public int touch;
    bool jump = false;
    public GameObject winPanel;
    float crystal;
    int final = 0;
    public Text countCryst;
    public Menu menu;


    void Update()
    {
        crystal = GetComponent<Crystals>().count;

        if (finish == true)
        {
            timer += Time.deltaTime;
            indicator.GetComponent<Image>().fillAmount += timer / 200;
            if (Input.touchCount > 0)
            {
                touch++;
            }

        }


        if (jump == true)
        {
            finish = false;
            float speedNew = timer / (touch / 3);
            GetComponent<PlayerMovement>().speed -= speedNew;
        }

        if (GetComponent<PlayerMovement>().speed <= 0)
        {
            GetComponent<PlayerMovement>().speed = 0;
            winPanel.SetActive(true);
            finishPanel.SetActive(false);
            menu.pause = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedUp"))
        {
            finishPanel.SetActive(true);
            finish = true;
        }

        if (other.CompareTag("SuperJump"))
        {
            GetComponent<Rigidbody>().AddForce(0, transform.position.y * touch / 5, 0, ForceMode.Impulse);
            GetComponent<Animator>().SetTrigger("Jump");
            GetComponent<Animator>().SetBool("Run", false);
            GetComponent<Animator>().SetTrigger("Slide");
            jump = true;
        }

        if (other.CompareTag("Cryst1"))
        {
            countCryst.text = crystal.ToString();
        }

        if (other.CompareTag("Cryst1.5"))
        {
            crystal *= 1.5f;
            final = Mathf.RoundToInt(crystal);
            countCryst.text = final.ToString();
        }

        if (other.CompareTag("Cryst2"))
        {
            crystal *= 2;
            countCryst.text = crystal.ToString();
        }

        if (other.CompareTag("Cryst2.5"))
        {
            crystal *= 2.5f;
            final = Mathf.RoundToInt(crystal);
            countCryst.text = final.ToString();
        }

        if (other.CompareTag("Cryst3"))
        {
            crystal *= 3;
            countCryst.text = crystal.ToString();
        }

        if (other.CompareTag("Cryst3.5"))
        {
            crystal *= 3.5f;
            final = Mathf.RoundToInt(crystal);
            countCryst.text = final.ToString();
        }

        if (other.CompareTag("Cryst4"))
        {
            crystal *= 4;
            countCryst.text = crystal.ToString();
        }
        if (other.CompareTag("Cryst4.5"))
        {
            crystal *= 4.5f;
            final = Mathf.RoundToInt(crystal);
            countCryst.text = final.ToString();
        }

        if (other.CompareTag("Cryst5"))
        {
            crystal *= 5;
            countCryst.text = crystal.ToString();
        }
    }

}
