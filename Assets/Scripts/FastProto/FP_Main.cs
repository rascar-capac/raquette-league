using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FP_Space { World, Local }

public abstract class FP_Main : MonoBehaviour
{
	public bool _enable = true;

	public void Enable(bool enable)
	{
		_enable = enable;
	}
	public void EnableToggle()
	{
		_enable = !_enable;
	}

	protected Vector3 DefineDirectionVector(Vector3 vector, FP_Space space, Transform spaceRef, bool isTarget)
	{
		Vector3 definedVector = Vector3.zero;

		Vector3 target;
		if(isTarget)
		{
			if(spaceRef != null)
			{
				if(space == FP_Space.Local)
				{
					target = spaceRef.TransformPoint(vector);
				}
				else
				{
					target = spaceRef.position + vector;
				}
			}
			else
			{
				if(space == FP_Space.Local)
				{
					target = transform.TransformPoint(vector);
				}
				else
				{
					target = vector;
				}
			}
			definedVector = target - transform.position;
		}
		else
		{
			if(space == FP_Space.Local)
			{
				if(spaceRef != null)
				{
					definedVector = spaceRef.TransformDirection(vector);
				}
				else
				{
					definedVector = transform.TransformDirection(vector);
				}
			}
			else
			{
					definedVector = vector;
			}
		}

		return definedVector;
	}

	protected Vector3 DefinePositionVector(Vector3 vector, FP_Space space, Transform spaceRef)
	{
		Vector3 definedVector = Vector3.zero;

		if(space == FP_Space.Local)
		{
			if(spaceRef != null)
			{
				definedVector = spaceRef.TransformPoint(vector);
			}
			else
			{
				definedVector = transform.TransformPoint(vector);
			}
		}
		else
		{
			if(spaceRef!=null)
			{
				definedVector = spaceRef.position+vector;
			}
			else
			{
				definedVector = vector;
			}
		}

		return definedVector;
	}
}
