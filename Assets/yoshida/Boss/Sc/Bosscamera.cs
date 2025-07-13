using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosscamera : MonoBehaviour
{
    [SerializeField]
    GameObject _Bosscamera;

    private string PlayerTag = "player";

    private void OnTriggerEnter2D(Collider2D Player)
    {
       if (Player.tag == PlayerTag)
        {
           _Bosscamera.SetActive(true);
        }
    }
}
