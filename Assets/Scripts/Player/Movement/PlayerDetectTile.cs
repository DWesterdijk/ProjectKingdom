using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectTile : MonoBehaviour
{
    [SerializeField]
    private GameObject _currentTile;

    [SerializeField]
    private GameObject _parent;

    [SerializeField]
    private PlayerMovement _playerMovement;

    public static PlayerDetectTile current;

    private void Awake()
    {
        if (current == null)
            current = this;

        if (_playerMovement == null)
            _playerMovement = this.GetComponentInParent<PlayerMovement>();
    }

    public bool moveL, moveR, moveU, moveD;
    public bool onTile;

    /// <summary>
    /// A on trigger enter to check what directions the player can make while on this tile.
    /// </summary>
    /// <param name="tile">The gameobject Tile</param>
    private void OnTriggerEnter(Collider tile)
    {
        if (tile.tag == StaticManager.Tags.TILE)
        {
            onTile = true;

            _currentTile = tile.gameObject;

            if (_playerMovement.coroutineIsActive)
            {
                _playerMovement.isMoving = false;
                _playerMovement.coroutineIsActive = false;
            }

            _parent.transform.position = new Vector3(tile.transform.position.x, _parent.transform.position.y, tile.transform.position.z);
            TileMoveFromTo tileInfo = _currentTile.GetComponent<TileMoveFromTo>();

            if (tileInfo == null)
            {
                tileInfo = _currentTile.GetComponent<TileMoveFromTo>();
                return;
            }

            if (tileInfo.left)
                moveL = true;

            if (tileInfo.right)
                moveR = true;

            if (tileInfo.up)
                moveU = true;

            if (tileInfo.down)
                moveD = true;
        }
    }

    //TODO: Reset booleans when leaving tile
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == StaticManager.Tags.TILE)
        {
            moveL = false;
            moveR = false;
            moveU = false;
            moveD = false;
        }
    }
}