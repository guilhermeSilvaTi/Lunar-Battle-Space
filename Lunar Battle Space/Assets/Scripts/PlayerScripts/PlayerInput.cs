using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    PlayerMoving playerMoving;

    [SerializeField]
    Weapon weapon;
    private void Start()
    {
        weapon.ActiveShoot(true);
    }

    private void Update()
    {
        if (player.GetPlayerIsActive())
        {       
            TouchScreen();         
        }
    }

    private void TouchScreen()
    {
        //touch
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {

                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);

                Vector2 comparationPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);


                if (transform.position.x < comparationPosition.x)
                {
                    //  player.VelocityMove(new Vector2(2, transform.position.y));
                }
                if (transform.position.x > comparationPosition.x)
                {
                    //  player.VelocityMove(new Vector2(-2, transform.position.y));
                }
                if (transform.position.y > comparationPosition.y)
                {
                    // player.VelocityMove(new Vector2(transform.position.x,-2));
                }
                if (transform.position.y < comparationPosition.y)
                {
                    //  player.VelocityMove(new Vector2(transform.position.x, 2));
                }
                /* if (hitInfo)
                 {
                     if (hitInfo.collider.gameObject == playerColliderCircle && releaseTime == 0)
                     {

                         StartCoroutine(circleGray());
                         moving = movingPlayer.TransformeToBall;
                     }

                 }*/


            }
        }
        //End touch
    }
}
