using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public InputHandler inputHandler;
    public Menu menu;

    private void Start()
    {
        Time.timeScale = 1;
    }
    Touch touch;
    private void MovePlayer()
    {
        if (inputHandler.IsThereTouchInput() && menu.pause == false)
        {
            touch = Input.GetTouch(0);


            if (touch.deltaPosition.x > 50 && touch.deltaPosition.y < 50 && touch.deltaPosition.y > -50 && transform.rotation.eulerAngles.y == 270)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.4f);
            }


            if (touch.deltaPosition.x < -50 && touch.deltaPosition.y < 50 && touch.deltaPosition.y > -50 && transform.rotation.eulerAngles.y == 270)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.4f);
            }

            if (touch.deltaPosition.x > 50 && touch.deltaPosition.y < 50 && touch.deltaPosition.y > -50 && transform.rotation.eulerAngles.y == 180)
            {
                transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
            }

            if (touch.deltaPosition.x < -50 && touch.deltaPosition.y < 50 && touch.deltaPosition.y > -50 && transform.rotation.eulerAngles.y == 180)
            {
                transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y, transform.position.z);
            }

            if (touch.deltaPosition.x > 50 && touch.deltaPosition.y < 50 && touch.deltaPosition.y > -50 && transform.rotation.eulerAngles.y == 0 )
            {
                transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y, transform.position.z);
            }

            if (touch.deltaPosition.x < -50 && touch.deltaPosition.y < 50 && touch.deltaPosition.y > -50 && transform.rotation.eulerAngles.y == 0)
            {
                transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}
