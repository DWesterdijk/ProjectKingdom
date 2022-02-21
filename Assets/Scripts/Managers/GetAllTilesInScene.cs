using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllTilesInScene : MonoBehaviour
{
    [SerializeField]
    private Transform _parentObject;

    public List<GameObject> _tiles = new List<GameObject>();

    private void Awake()
    {
        foreach (Transform child in _parentObject)
        {
            _tiles.Add(child.gameObject);
        }
    }
}
