using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    // Player
    public GameObject player;
    void Awake()
    {
        LocatePlayerToPlayerStart();
        Destroy(gameObject);
    }

    void LocatePlayerToPlayerStart()
    {
        if (player)
            Instantiate(player, transform.position, transform.rotation);
    }
}
