using System;
using UnityEngine;

namespace App.Scripts.Scenes.LevelScene
{
    public class InputSystem : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        
        public Vector2 MoveInput { get; set; }
        public bool OnJoystickDrag { get; private set; }
        
        #region Events

        private void OnEnable()
        {
            _joystick.OnDragEvent.AddListener(SetMoveInput);
            _joystick.OnMouseDown += () =>
            {
                OnJoystickDrag = true;
                Debug.Log("OnMouseDown");
            };
            _joystick.OnMouseUp += () =>
            {
                OnJoystickDrag = false;
                Debug.Log("OnMouseUp");
            };
        }

        private void OnDisable()
        {
            _joystick.OnDragEvent.RemoveListener(SetMoveInput);
        }

        #endregion

        private void SetMoveInput(Vector2 input)
        {
            MoveInput = input;
        }
    }
}