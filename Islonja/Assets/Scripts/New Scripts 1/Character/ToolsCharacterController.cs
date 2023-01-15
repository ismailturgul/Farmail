using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{

    CharacterController2D character;
    Rigidbody2D rgbd2d;
    ToolBarController toolbarController;
    [SerializeField] float offsetDistance = 1.0f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] TileData plowableTiles;

    Vector3Int selectedTilePosition;
    bool selectables;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolBarController>();
    }
    bool clickProcessed = false;
    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButton(0))
        {
            if (!clickProcessed)
            {
                clickProcessed = true;
                if (UseToolWorld() == true)
                {
                    return;
                }
                UseToolGrid();
            }
        }
        else
        {
            clickProcessed = false;
        }
    }


    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }

    public void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectables = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectables);

    }

    private void Marker()
    {

        markerManager.markedCellPosition = selectedTilePosition;
    }

    public bool UseToolWorld() // for physical action in the world
    {
        Vector2 position = rgbd2d.position + character.lastDirection * offsetDistance;

        Item item = toolbarController.GetItem;
        if(item == null) { return false; }
        if(item.onAction == null) { return false; }

        bool complete = item.onAction.OnApply(position);

        return complete;
    }

    public void UseToolGrid() // for grid action in the World
    {
        Debug.Log("Value of selectables: " + selectables);

        if (selectables == true)
        {
            TileBase tileBase = tileMapReadController.GetTileBase(selectedTilePosition);
            TileData tileData = tileMapReadController.GetTileData(tileBase);

            if (tileData != plowableTiles) { return; }
            Debug.Log("Value of cropsManager.Check(selectedTilePosition): " + cropsManager.Check(selectedTilePosition));

            if (cropsManager.Check(selectedTilePosition) == true)
            {
                Debug.Log("Seeding tile at position: " + selectedTilePosition);

                cropsManager.Seed(selectedTilePosition);
              
            }
            else
            {
                cropsManager.Plow(selectedTilePosition);
            }
        }
    }

}