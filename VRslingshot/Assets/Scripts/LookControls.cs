using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookControls : MonoBehaviour
{
	public float sensitivity = 1.0f;

	float yaw_rotation;
	float pitch_rotation;
	float mouse_x = 0.0f;
	float mouse_y = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
		yaw_rotation = this.transform.rotation.eulerAngles.y;
		pitch_rotation = this.transform.rotation.eulerAngles.x;

		Cursor.lockState = CursorLockMode.Locked;
	}

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKey(KeyCode.Escape))
		{
			Cursor.lockState = (Cursor.lockState == CursorLockMode.Confined) ? CursorLockMode.Locked : CursorLockMode.Confined;
			Debug.Log("State is now set to: " + Cursor.lockState);
		}

		mouse_x = Input.GetAxis("Mouse X");
		mouse_y = Input.GetAxis("Mouse Y");

		pitch_rotation -= mouse_y * sensitivity;
		yaw_rotation += mouse_x * sensitivity;

		if (pitch_rotation > 90)
		{
			pitch_rotation = 90;
		}
		else if (pitch_rotation < -90)
		{
			pitch_rotation = -90;
		}

		this.transform.rotation = Quaternion.identity;
		this.transform.Rotate(0.0f,yaw_rotation,0.0f);
		this.transform.Rotate(pitch_rotation, 0.0f, 0.0f);
	}
}
