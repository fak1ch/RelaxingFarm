using System;
using App.Scripts.General.Utils;
using UnityEngine;

namespace App.Scripts.Scenes.LevelScene.CharacterMovement
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private Rigidbody _rigidbody;

        [Space(10)] 
        [SerializeField] private float _moveSpeed;

        public float Speed => GetSpeed();
        public float MaxSpeed => _moveSpeed * Time.fixedDeltaTime;
        public float SpeedPercent => MathUtils.GetPercent(0, MaxSpeed, Speed);

        private void FixedUpdate()
        {
            Vector2 moveInput = _inputSystem.OnJoystickDrag ? _inputSystem.MoveInput : Vector2.zero;
            Vector3 velocity = new Vector3(moveInput.x, 0, moveInput.y);

            _rigidbody.velocity = velocity * _moveSpeed * Time.fixedDeltaTime;
            
            Debug.Log(Speed + " " + MaxSpeed + " " + SpeedPercent);
        }

        private float GetSpeed()
        {
            float positiveX = Mathf.Abs(_rigidbody.velocity.x);
            float positiveZ = Mathf.Abs(_rigidbody.velocity.z);
            
            return Mathf.Max(positiveX, positiveZ);
        }
    }
}