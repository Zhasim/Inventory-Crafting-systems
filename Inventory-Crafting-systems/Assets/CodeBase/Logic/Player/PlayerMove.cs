using CodeBase.Services.General.Input;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        public float movementSpeed;

        private IInputService _inputService;
        private CharacterController _characterController;
        private Camera _camera;

        [Inject]
        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;
            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0f;
                movementVector.Normalize();

                transform.forward = movementVector;
            }
            
            _characterController.Move(movementVector * (movementSpeed * Time.deltaTime));
        }
    }
}