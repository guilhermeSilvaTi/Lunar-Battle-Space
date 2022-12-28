using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerInput playerInput;
    [SerializeField]
    PlayerMoving playerMoving;
    [SerializeField]
    PlayerCollider playerCollider;

    [SerializeField]
    internal SpriteRenderer spriteRenderer;

    [SerializeField]
    internal bool isActivePlayer = true;

    [SerializeField]
    internal int ataqueValue = 5;

    [SerializeField]
    internal int life = 100;

    [SerializeField]
    SpriteRenderer[] heartsSprite;

    [SerializeField]
    GameOver gameOver;

    public bool GetPlayerIsActive() { return isActivePlayer; }
    public void SetPlayerIsActive(bool value) { isActivePlayer = value; }
    public int GetAtaqueValue() { return ataqueValue; }

    public void GetDamage(int value)
    {
        life -= value;
        StartCoroutine(IsDamage());
        ChekHeart();
        if (life <= 0)
         GameOverGame();
    }

    private void ChekHeart()
    {
        switch (life)
        {
            case <= 25: { heartsSprite[1].enabled = false; break; }
            case <= 50: { heartsSprite[2].enabled = false; break; }
            case <= 75: { heartsSprite[3].enabled = false; break; }
        }
    }

    internal IEnumerator IsDamage()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSecondsRealtime(0.4f);
        spriteRenderer.color = Color.white;
    }
    internal void  GameOverGame()
    {
        SetPlayerIsActive(false);      
        StartCoroutine(gameOver.EndGame());
    }

}
