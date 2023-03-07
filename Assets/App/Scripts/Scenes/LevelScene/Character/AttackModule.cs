using System;
using UnityEngine;

namespace App.Scripts.Scenes.LevelScene.CharacterMovement
{
    public class AttackModule : MonoBehaviour
    {
        public event Action<bool> OnAttackStart;
    }
}