using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour {
    public Transform targetTransform;
    private float ms, rs;

	void Start () {
        ms = 10f;
        rs = 2f;
	}
	
	void Update () {
        if (Vector3.Distance(transform.position, targetTransform.position) < 5f)
            return;
        Vector3 tarpos = targetTransform.position;
        tarpos.y = transform.position.y;
        Vector3 dirRot = tarpos - transform.position;

        Quaternion tarRot = Quaternion.LookRotation(dirRot);

        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rs * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, ms * Time.deltaTime));
	}
}
