using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject player;

    private Vector3 respawnPosition;

    void Start()
    {
        respawnPosition = transform.position;
    }
    public void SetCheckpoint()
    {
        respawnPosition = transform.position;
    }
    public void SetRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
    }
    public void RespawnPlayer()
    {
        player.transform.position = respawnPosition;
    }
}
