using System;
using UnityEngine;

namespace App.Scripts.Scenes.LevelScene.CharacterMovement
{
    public class AnimationController : MonoBehaviour
    {
        private const string AttackBoolKey = "IsAttack";
        private const string SpeedFloatKey = "Speed";
        
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private AttackModule _attackModule;

        private int _attackHash;
        private int _speedHash;
        
        #region Evets

        private void OnEnable()
        {
            _attackModule.OnAttackStart += SetAttackBool;
        }

        private void OnDisable()
        {
            _attackModule.OnAttackStart -= SetAttackBool;
        }

        #endregion

        private void Start()
        {
            _attackHash = Animator.StringToHash(AttackBoolKey);
            _speedHash = Animator.StringToHash(SpeedFloatKey);
        }

        private void Update()
        {
            _animator.SetFloat(_speedHash, _characterMovement.SpeedPercent);
        }
        
        private void SetAttackBool(bool isStart)
        {
            _animator.SetBool(_attackHash, isStart);
        }
    }
}