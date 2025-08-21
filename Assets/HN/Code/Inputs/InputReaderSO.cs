using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

namespace HN.Code.Inputs
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "SO/InputReader", order = 0)]
    public class InputReaderSO : ScriptableObject, IPlayerActions
    {
        public event Action OnJumpKeyPressed;
        public event Action OnLeftButtonPressed;
        
        public Vector2 MovementKey { get; private set; }
        public Vector2 ScreenPos { get; private set; }
        public Vector2 WorldPos { get; private set; }
        
        private Controls _controls;
        
        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }
            
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementKey = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            OnLeftButtonPressed?.Invoke();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            OnJumpKeyPressed?.Invoke();
        }

        public void OnMousePos(InputAction.CallbackContext context)
        {
            ScreenPos = context.ReadValue<Vector2>();
            WorldPos = Camera.main.ScreenToWorldPoint(ScreenPos);
        }
    }
}