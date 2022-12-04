using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(18);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

            if(GameManager.instance.tileManager.IsInteractable(position))
            {
                Debug.Log("Tile is interacable");
            }
        }
    }

    public void DropItem(Collectable item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

        Collectable droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

      //  droppedItem.rb2d.AddForce(spawnOffset * 1f, ForceMode2D.Impulse);
    }
}
