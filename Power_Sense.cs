using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Power_Sense : MonoBehaviour
{
	// Arduino 
    public SerialPort puerto = new SerialPort("COM8", 9600);
	public string recibirData;
	public string[] data;

	// Objeto 
	public float movementSpeed = 0.1f;
	Renderer rend;

	void Start()
    {
        puerto.Open(); 
        puerto.ReadTimeout = 1;

		rend = GetComponent<Renderer>();
	}

 
    void Update()
    {
		if (puerto.IsOpen) 
		{
			try 
			{
				recibirData =  puerto.ReadLine();
				string[] data = recibirData.Split(",");
		
				float horizontalInput = (float.Parse(data[0])/100)*-1;
				float verticalInput   = (float.Parse(data[2])/100)*-1;

				transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

				if (int.Parse(data[3]) == 1)
				{
					rend.material.color = Color.green;
				}
				if (int.Parse(data[3]) == 2)
				{
					rend.material.color = Color.yellow;
				}
				if (int.Parse(data[3]) == 3)
				{
					rend.material.color = Color.red;
				}
				if (int.Parse(data[3]) == 4)
				{
					rend.material.color = Color.blue;
				}

			}
			catch
			{

			}

		}
	}
}
