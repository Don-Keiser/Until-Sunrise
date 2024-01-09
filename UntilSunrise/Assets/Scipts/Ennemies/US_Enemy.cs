using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class US_Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerBase"))
        {
            gameObject.SetActive(false);
        }
    }
}
