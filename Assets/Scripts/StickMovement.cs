using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

public class StickMovement : MonoBehaviour
{
    public float speed = 1.5f;
    public InputActionProperty moveAction;
    public Transform head;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0, input.y);
        Vector3 headYaw = new Vector3(head.forward.x, 0, head.forward.z).normalized;
        Quaternion rotation = Quaternion.LookRotation(headYaw);
        Vector3 move = rotation * direction;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
