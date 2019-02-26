using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "pacman")
            Destroy(gameObject);
    }
}
