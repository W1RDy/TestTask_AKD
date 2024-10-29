using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Vector3 _direction;

    [SerializeField] private MouseLook _mouseLook;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        _direction = GetVectorRelativePlayer(_direction);
        Move(_direction);
    }

    private void Move(Vector3 direction)
    {
        _rb.velocity = direction * _speed;
    }

    private Vector3 GetVectorRelativePlayer(Vector3 direction)
    {
        var relativeDirection = _mouseLook.transform.TransformDirection(direction.normalized);
        return new Vector3(relativeDirection.x, 0, relativeDirection.z);
    }    
}
