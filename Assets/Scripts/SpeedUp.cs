using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public int arrow = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArrowUp"))
        {
            arrow++;
            Destroy(other.gameObject);
        }
    }


}
