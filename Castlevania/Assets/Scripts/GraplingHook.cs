using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingHook : MonoBehaviour
{
	public LineRenderer line;
	DistanceJoint2D joint;
	Vector3 targetPos;
	RaycastHit2D hit;
	public float distance = 10f;
	public LayerMask mask;
	public float step;
	public Rigidbody2D theRB;
	public int grapling;

	// Use this for initialization
	void Start()
	{
		joint = GetComponent<DistanceJoint2D>();
		joint.enabled = false;
		line.enabled = false;
		theRB.gravityScale = 40f;
	}

	// Update is called once per frame
	void Update()
	{

		if (joint.distance > 6f)
		{
			joint.distance -= step;
		}	


		if (Input.GetKeyDown(KeyCode.E))
		{
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = 0;

			hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

			if(grapling == 0)
            {
				Debug.Log(grapling);
            }
			else
            {
				if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)

				{
					grapling--;
					joint.enabled = true;
					Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
					joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
					joint.distance = Vector2.Distance(transform.position, hit.point);

					line.enabled = true;
					line.SetPosition(0, transform.position);
					line.SetPosition(1, hit.point);
				}
            }


		}

		if (Input.GetKey(KeyCode.E))
		{
			theRB.gravityScale = 0f;
			line.SetPosition(0, transform.position);

			Debug.Log("Gravity Scale is " + theRB.gravityScale);
		}


		if (Input.GetKeyUp(KeyCode.E))
		{
			theRB.gravityScale = 40f;
			joint.enabled = false;
			line.enabled = false;

			Debug.Log("Gravity Scale is " + theRB.gravityScale);
			new WaitForSeconds(26f);
			grapling++;
		}
	}
}

