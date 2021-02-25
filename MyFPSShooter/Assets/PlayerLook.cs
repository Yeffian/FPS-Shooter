using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    #region Public Variables
    [Header("Camera")]
    public Transform player;
    public Transform parent;
    public float sensitivity = 10;
    #endregion

    #region Private Variables
    float x = 0;

    float y = 0;
    #endregion

    #region Monobehaviour Callbacks
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //input
        x += -Input.GetAxis("Mouse Y") * sensitivity;
        y += Input.GetAxis("Mouse X") * sensitivity;

        //clamping
        x = Mathf.Clamp(x, -90, 90);

        //rotation
        transform.localRotation = Quaternion.Euler(x, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, y, 0);
        parent.transform.localRotation = Quaternion.Euler(0, y, 0);

        //cursorLocking
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;

            if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
        }
    }
    #endregion
}
