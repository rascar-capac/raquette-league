using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaTowerGenerator : MonoBehaviour
{
	public GameObject _jengaPrefab;
	public int _floorCount=10;

	public void CreateJengaTower(int floorCount)
	{
		for(int i = 0; i < floorCount; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				GameObject tempJenga = Instantiate(_jengaPrefab);

				tempJenga.transform.rotation = transform.rotation;
				tempJenga.transform.Rotate(Vector3.up * 90 * i);
				tempJenga.transform.position = transform.position + tempJenga.transform.forward * (j - 1) + transform.up * 0.5f * i;
			}

		}
	}

	public void CreateJengaCity()
	{
		Vector3 initialPosition = transform.position;

		int lastFloorCount = _floorCount;
		for(int x = 0; x < 5; x++)
		{
			for(int y = 0; y < 10; y++)
			{
				transform.position = initialPosition+ new Vector3(x * 10, 0, y * 10);
				CreateJengaTower(lastFloorCount);
				lastFloorCount = Mathf.Clamp(lastFloorCount + Random.Range(-10, 10), 0, 50);
			}
		}

	}




}
