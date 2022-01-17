using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class JumpCommand : AbstractPlayerCommand
    {
        protected float _jumpForce;

        public JumpCommand(Rigidbody2D rigidbody, float jumpForce) : base(rigidbody)
        {
            _jumpForce = jumpForce;
        }

        public override void Execute()
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}

