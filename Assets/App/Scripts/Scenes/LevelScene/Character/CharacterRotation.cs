using System;
using UnityEngine;

namespace App.Scripts.Scenes.LevelScene.CharacterMovement
{
    public class CharacterRotation : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;

        private void Update()
        {
            Vector2 moveInput = _inputSystem.MoveInput;
            Vector3 lookVector = new Vector3(moveInput.x, 0, moveInput.y);
            
            Quaternion lookRotation = Quaternion.LookRotation(lookVector, transform.up); 
            transform.localRotation = Quaternion.Euler(lookRotation.eulerAngles);
        }
    }
}