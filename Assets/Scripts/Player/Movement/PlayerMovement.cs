using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO ONCE FULLY WORKING: REFACTOR CODE TO BE LESS REDUNDANT!
//TODO: Fix no-limit speed issue.
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;

    public bool isMoving;
    public bool coroutineIsActive;

    public Coroutine activeMovePlayer;

    private void Update()
    {
        if (!isMoving && activeMovePlayer != null)
        {
            StopCoroutine(activeMovePlayer);
        }

        if (isMoving)
            return;

        if (PlayerControls.Up() && PlayerDetectTile.current.moveU && !coroutineIsActive)
        {
            isMoving = true;
            activeMovePlayer = StartCoroutine(movePlayer(new Vector3(0f, 0f, 1.0f)));
        }
        if (PlayerControls.Down() && PlayerDetectTile.current.moveD && !coroutineIsActive)
        {
            isMoving = true;
            activeMovePlayer = StartCoroutine(movePlayer(new Vector3(0f, 0f, -1.0f)));
        }
        if (PlayerControls.Left() && PlayerDetectTile.current.moveL && !coroutineIsActive)
        {
            isMoving = true;
            activeMovePlayer = StartCoroutine(movePlayer(new Vector3(-1.0f, 0f, 0f)));
        }
        if (PlayerControls.Right() && PlayerDetectTile.current.moveR && !coroutineIsActive)
        {
            isMoving = true;
            activeMovePlayer = StartCoroutine(movePlayer(new Vector3(1.0f, 0f, 0f)));
        }
    }

    public IEnumerator movePlayer(Vector3 direction)
    {
        coroutineIsActive = true;

        direction.Normalize();
        Vector3 setDirectionTo = (direction * _movementSpeed); //<- removed "* Time.deltaTime"

        while (isMoving)
        {
            this.transform.position += (setDirectionTo * Time.deltaTime);

            Debug.Log("Running " + direction);

            yield return null;
        }

        yield return null;
    }
}
