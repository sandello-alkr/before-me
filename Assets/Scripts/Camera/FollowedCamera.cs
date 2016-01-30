using UnityEngine;
using System.Collections;

public class FollowedCamera : MonoBehaviour {

	public Transform limitPointRight;
	public Transform limitPointLeft;

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

	private float width;

    void Start()
    {
        targetPos = transform.position;

		float height = 2f * Camera.main.orthographicSize;
		this.width = height * Camera.main.aspect / 2;
    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);
			            
			interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);

			if (limitPointRight.position.x < (transform.position.x + width)) {
				transform.position = new Vector3 (limitPointRight.position.x - width, 0, transform.position.z);
			} else if (limitPointLeft.position.x > transform.position.x - width) {
				transform.position = new Vector3 (limitPointLeft.position.x + width, 0, transform.position.z);
			}
        }
    }
}
