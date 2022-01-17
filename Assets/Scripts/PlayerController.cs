using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        protected Rigidbody2D _rb;
        protected SpriteRenderer _spriteRenderer;

        protected JumpCommand _jump;
        protected MoveCommand _moveLeft;
        protected MoveCommand _moveRight;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if(_spriteRenderer == null)
            {
                throw new System.Exception("Non esiste uno sprite renderer per il Player");
            }

            _jump = new JumpCommand(_rb, 3f);
            _moveLeft = new MoveCommand(_rb, MoveDirection.Left, 3f);
            _moveRight = new MoveCommand(_rb, MoveDirection.Right, 3f);
        }

        private void Update()
        {
            if(Input.GetButtonDown("Jump"))
            {
                _jump.Execute();
            }
            
            if(Input.GetAxis("Horizontal") > 0)
            {                
                _moveRight.Execute();
                _spriteRenderer.flipX = false;
            }
            else if(Input.GetAxis("Horizontal") < 0)
            {
                _moveLeft.Execute();
                _spriteRenderer.flipX = true;
            }

        }
    }
}
