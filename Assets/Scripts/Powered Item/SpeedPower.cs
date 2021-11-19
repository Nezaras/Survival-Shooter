using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPower : Power
{
    public float SpeedMult = 1.3f;
    public float MultTimer = 8f;

    public override void OnPlayerEnter(Collider player)
    {
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();

        PlayerMovement playerMove = player.GetComponent<PlayerMovement>();

        if (gameOverManager != null)
        {
            gameOverManager.ShowSpeedUpText();
        }

        playerMove.AddMoveMult(SpeedMult, MultTimer);
    }
}
