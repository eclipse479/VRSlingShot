using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public Rigidbody projectile;
    float projectileSpeed = 5;
    public float maxProjectileSpeed = 500;
    Vector3 slingshot_forward;
    bool down = false;

	public GameObject cameraObject;

	float slingshot_pitch_rotation;
	float slingshot_yaw_rotation;
    

	float camera_pitch_rotation;
	float camera_yaw_rotation;
	

	public float rotation_modifier = 10.0f;
	// Start is called before the first frame update
	void Start()
    {
		slingshot_pitch_rotation = 0.0f;
		slingshot_yaw_rotation = 0.0f;
	
		camera_pitch_rotation = 0.0f;
		camera_yaw_rotation = 0.0f;
	}

	// Update is called once per frame
	void Update()
	{
		if (cameraObject == GameObject.Find("MouseCamera"))
		{
			camera_pitch_rotation = cameraObject.gameObject.transform.rotation.eulerAngles.x;
			camera_yaw_rotation = cameraObject.gameObject.transform.rotation.eulerAngles.y;
			

			if (Input.GetAxis("Yaw") > 0)
			{
				slingshot_yaw_rotation += rotation_modifier;
			}
			else if (Input.GetAxis("Yaw") < 0)
			{
				slingshot_yaw_rotation -= rotation_modifier;
			}

			if (Input.GetAxis("Pitch") > 0)
			{
				slingshot_pitch_rotation += rotation_modifier;
			}
			else if (Input.GetAxis("Pitch") < 0)
			{
				slingshot_pitch_rotation -= rotation_modifier;
			}

			if (Input.GetAxis("Reset") > 0)
			{
				slingshot_pitch_rotation = 0.0f;
				slingshot_yaw_rotation = 0.0f;
			}

			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(camera_pitch_rotation + slingshot_pitch_rotation, 0.0f, 0.0f);
			this.transform.Rotate(0.0f, camera_yaw_rotation + slingshot_yaw_rotation, 0.0f);
		}

		//shooting below ---------------------------------------------------------------------------------------------------------------------------
		if (Input.GetAxis("Fire1") > 0 || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            //Instantiate(myPrefab, new Vector3(140, 5, -310), Quaternion.identity);
            projectileSpeed += 20.0f * Time.deltaTime;
            if(projectileSpeed > maxProjectileSpeed)
            {
                projectileSpeed = maxProjectileSpeed;
            }
            down = true;
        }
        if ((Input.GetAxis("Fire1") == 0 || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) && down)
        {
            //Rigidbody p = Instantiate(projectile, transform.position, transform.rotation);
            //p.velocity = transform.forward * projectileSpeed;
            //projectileSpeed = 4;


            slingshot_forward = transform.forward;
            slingshot_forward.Normalize();
           
           
            //p.velocity = camera_forward * projectileSpeed;
            


            Rigidbody p = Instantiate(projectile, transform.position, transform.rotation);

            slingshot_forward *= projectileSpeed;

            p.velocity = slingshot_forward;

            projectileSpeed = 5;
            down = false;
        }

    }
    
}
