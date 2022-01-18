using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameInput;

namespace Platformer.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, IPlayerActions
    {
        protected Rigidbody2D _rb;
        protected SpriteRenderer _spriteRenderer;
        protected Animator _animator;

        protected JumpCommand _jump;
        protected MoveCommand _moveLeft;
        protected MoveCommand _moveRight;

        protected GameInput _input;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _animator = GetComponentInChildren<Animator>();

            if(_spriteRenderer == null)
            {
                throw new System.Exception("Non esiste uno sprite renderer per il Player");
            }

            _jump = new JumpCommand(_rb, 3f);
            _moveLeft = new MoveCommand(_rb, MoveDirection.Left, 3f);
            _moveRight = new MoveCommand(_rb, MoveDirection.Right, 3f);

            _input = new GameInput();
            _input.Player.SetCallbacks(this);
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void Update()
        {
            //if(Input.GetButtonDown("Jump"))
            //{
            //    _jump.Execute();
            //}
            
            //if(Input.GetAxis("Horizontal") > 0)
            //{                
            //    _moveRight.Execute();
            //    _spriteRenderer.flipX = false;
            //}
            //else if(Input.GetAxis("Horizontal") < 0)
            //{
            //    _moveLeft.Execute();
            //    _spriteRenderer.flipX = true;
            //}

            
        }

        public void OnJump()
        {
            _jump.Execute();
        }

        public void OnMoveRight()
        {
            _moveRight.Execute();
            _spriteRenderer.flipX = false;
        }

        public void OnMoveLeft()
        {
            _moveLeft.Execute();
            _spriteRenderer.flipX = false;
        }

        private void FixedUpdate()
        {
            var hit = Physics2D.Raycast(transform.position - new Vector3(0, 1f, 0), Vector2.down, 0.01f);
            _animator.SetBool("Jumping", hit.collider == null);

            _animator.SetBool("Moving", _rb.velocity.magnitude > Mathf.Epsilon); 
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                _jump.Execute();
            }
        }
    }
}
