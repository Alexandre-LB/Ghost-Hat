using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alexandre
public class Mouse : MonoBehaviour
{
	private bool cam;
	private float horizontalSpeed = -400;
	private float verticalSpeed = -400;
	private float horizontal;
	private float vertical;

    void Update()
    {
		if (Input.GetMouseButton(1) && cam == false)
		{
			horizontal = horizontalSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
			vertical = verticalSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

			transform.Translate(horizontal, vertical, 0);
		}
	}
}
