using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    [SerializeField]
    private float _rollStrength;
    [SerializeField]
    private float _rollSpeed;

    private GameObject _dice;
    private Rigidbody _rigidBody;
    private Transform _transform;

    private bool _isThrown;

    private void Start()
    {
        _isThrown = false;

        _dice = this.gameObject;
        _rigidBody = _dice.GetComponent<Rigidbody>();
        _transform = _dice.GetComponent<Transform>();

        ResetDice();
    }

    private void Update()
    {
        if (!_isThrown)
            RollDice();


        if (Input.GetMouseButtonDown(0) && !_isThrown)
        {
            _isThrown = true;
            ThrowDice();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ResetDice();
        }

        //Debug.Log("Magnitude: " + _rigidBody.angularVelocity.sqrMagnitude);
    }

    private void RollDice()
    {
        _rigidBody.useGravity = false;
        _rigidBody.AddTorque(_rollSpeed * Random.Range(1, 5), _rollSpeed * Random.Range(1, 5), _rollSpeed * Random.Range(1, 5));
    }

    private void ThrowDice()
    {
        Vector3 _force = new Vector3(0, 0, _rollStrength);

        _rigidBody.AddForce(_force, ForceMode.Force);
        _rigidBody.useGravity = true;
        _rigidBody.constraints = RigidbodyConstraints.None;

        if (_rigidBody.angularVelocity.magnitude == 0) //This does not work
        {
            Debug.Log("Velocity Stopped");
            this.gameObject.GetComponent<GetRollValue>().GetRoll();
        }
    }

    private void ResetDice()
    {
        _isThrown = false;
        _transform.localPosition = new Vector3(1, 3, 7);
        _rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }
}