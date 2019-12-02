using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;
    private static int numOfRespawns;
    // Start is called before the first frame update

    //When player hits an enemy their position is set to the spawn position, and numOfRespawns is iterated.
    //at 3 total respawns the player loses
    private void OnTriggerEnter2D(Collider2D other)
    {
        player.transform.position = respawnPoint.transform.position;
        numOfRespawns++;
        if(numOfRespawns >= 3)
        {
            LevelControlScript.instance.FailLevel();
            ResetRespawns();
        }
    }
    public static void ResetRespawns()
    {
        numOfRespawns = 0;
    }
}
