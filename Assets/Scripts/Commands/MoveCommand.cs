using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer
{
    public class MoveCommand : AbstractPlayerCommand
    {
        protected MoveDirection _direction;
        protected float _speedMultiplier;

        public MoveCommand(Rigidbody2D rigidbody, MoveDirection direction, float speedMult) : base(rigidbody)
        {
            _direction = direction;
            _speedMultiplier = speedMult;
        }
        public override void Execute()
        {
            var dir = 1f;
            if (_direction == MoveDirection.Left) dir = -1f;

            _rb.AddForce(Vector2.right * _speedMultiplier * dir);
        }
    }

    public enum MoveDirection
    {
        Left,
        Right
    }
}

