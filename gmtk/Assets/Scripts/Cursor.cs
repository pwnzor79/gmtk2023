using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
    [SerializeField] Rigidbody2D cursorBody;
    [SerializeField] Camera mainCamera;

    Vector2 screenPos = Vector2.zero;

    public void Move(InputAction.CallbackContext context)
    {
        if (mainCamera == null)
        {
            Debug.LogError("JESSE: you forgot to assign the camera to the cursor");
            return;
        }
        screenPos = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(screenPos);
        cursorBody.MovePosition(worldPos);
    }
}
