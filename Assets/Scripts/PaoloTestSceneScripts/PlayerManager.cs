using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameInput;

public class PlayerManager : MonoBehaviour, IPlayerActions
{
    Direction _direction = Direction.Right;
    Rigidbody2D _rb;
    SpriteRenderer _sprite;
    public float speed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }



    public void OnFire(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        int dir = 1;
        if (_direction == Direction.Left)
        {
            dir = -1;
            _sprite.flipX = true;
        }
        else
        {
            dir = 1;
            _sprite.flipX = false;
        }

        _rb.AddForce(Vector2.right * speed * dir);
    }

    
}

public enum Direction
{
    Right,
    Left
}
