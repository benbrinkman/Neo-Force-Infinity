using UnityEngine;
using System.Collections;

public class GetMovment : MonoBehaviour {



	float angle;
	float totalXDistance;
	float totalYDistance;
	float x;
	float y;

	public Vector3 Move(Vector3 start, Vector3 end, float moveSpeed){
		totalXDistance = end.x - start.x;
		totalYDistance = end.y - start.y;
		
		
		angle = Mathf.Atan (totalYDistance / totalXDistance) * Mathf.Rad2Deg;
		
		x = moveSpeed * (Mathf.Cos (angle / Mathf.Rad2Deg));
		y = moveSpeed * (Mathf.Sin (angle / Mathf.Rad2Deg));

		return new Vector3(x, y, 0);
	}

}
