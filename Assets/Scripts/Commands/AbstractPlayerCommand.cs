using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Interface;

namespace Platformer
{
    public abstract class AbstractPlayerCommand : ICommand
    {
        protected Rigidbody2D _rb;

        public AbstractPlayerCommand(Rigidbody2D rigidbody)
        {
            _rb = rigidbody;
        }
        public abstract void Execute();
    }
}


