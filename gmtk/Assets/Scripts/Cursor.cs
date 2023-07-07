using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
    [SerializeField] Rigidbody2D cursorBody;
    [SerializeField] Camera mainCamera;

    public void Move(InputAction.CallbackContext context)
    {
        if (mainCamera == null)
        {
            Debug.LogError("JESSE: you forgot to assign the camera to the cursor");
            return;
        }
        Vector2 screenPos = context.ReadValue<Vector2>();
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(screenPos);
        cursorBody.MovePosition(worldPos);
    }
}
