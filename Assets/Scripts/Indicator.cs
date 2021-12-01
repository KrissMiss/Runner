using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    float distance = 0;
    public Transform startPoint;
    public Transform secondPoint;
    public Transform thirdPoint;
    public Transform fourthPoint;
    public Transform fifthPoint;
    public GameObject player;

    void Start()
    {
        distance = Vector3.Magnitude(startPoint.position + secondPoint.position + thirdPoint.position + fourthPoint.position + fifthPoint.position);
        distance = 1 / distance * Time.deltaTime * 20;
    }


    void Update()
    {
        if (player.transform.rotation.eulerAngles.y == 270 && gameObject.GetComponent<Slider>().value <= 0.75)
        {
            gameObject.GetComponent<Slider>().value += distance;
        }

        if (player.transform.rotation.eulerAngles.y == 180 && gameObject.GetComponent<Slider>().value <= 0.5)
        {
            gameObject.GetComponent<Slider>().value += distance;
        }

        if (player.transform.rotation.eulerAngles.y == 0 && gameObject.GetComponent<Slider>().value <= 1)
        {
            gameObject.GetComponent<Slider>().value += distance;
        }

        if (player.GetComponent<PlayerMovement>().end == true)
        {
           distance = 0;
        }

        if (player.GetComponent<PlayerMovement>().end == false)
        {
            distance = Vector3.Magnitude(startPoint.position + secondPoint.position + thirdPoint.position + fourthPoint.position + fifthPoint.position);
            distance = 1 / distance * Time.deltaTime * 20;
        }
    }
}
