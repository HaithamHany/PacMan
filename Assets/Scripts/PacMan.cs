using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PacMan : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tilemap obstaclesTilemap;


    public bool isMoving = false;

    private float moveTime = 0.3f;

    private AudioSource walkingSound;

  

    // Update is called once per frame
    void Update()
    {

        if (isMoving) return;
        int horizontal = 0;
        int vertical = 0;
        
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));
       
        if (horizontal != 0)
            vertical = 0;

        
        if (horizontal != 0 || vertical != 0)
        {
            Move(horizontal, vertical);
        }

    }

    private void Move(int xDir, int yDir)
    {

        Vector2 startCell = transform.position;
        Vector2 targetCell = startCell + new Vector2(xDir, yDir);

        bool isOnGround = getCell(groundTilemap, startCell) != null; 
        bool hasGroundTile = getCell(groundTilemap, targetCell) != null; 
        bool hasObstacleTile = getCell(obstaclesTilemap, targetCell) != null; 

        
        if (isOnGround)
        {


            if (hasGroundTile && !hasObstacleTile)
            {
              
                    StartCoroutine(Movement(targetCell));
    

            }

         
          
       
        }



    }

    private IEnumerator Movement(Vector3 end)
    {

        isMoving = true;

 
        if (walkingSound != null)
        {
            walkingSound.loop = true;
            walkingSound.Play();
        }

        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        float inverseMoveTime = 1 / moveTime;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, end, inverseMoveTime * Time.deltaTime);
            transform.position = newPosition;
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            yield return null;
        }

        if (walkingSound != null)
            walkingSound.loop = false;

        isMoving = false;
    }



    public Collider2D whatsThere(Vector2 targetPos)
    {
        RaycastHit2D hit;
        hit = Physics2D.Linecast(targetPos, targetPos);
        return hit.collider;
    }

   

 
    private TileBase getCell(Tilemap tilemap, Vector2 cellWorldPos)
    {
        return tilemap.GetTile(tilemap.WorldToCell(cellWorldPos));
    }
    
}
