using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_MinX, m_MaxX;
	
	// Update is called once per frame
	void Update () {
        transform.position += (Vector3.right * Input.GetAxis("Horizontal") * m_Speed) * Time.deltaTime; ;

        if(transform.position.x < m_MinX || transform.position.x > m_MaxX)
        {
            if(transform.position.x < m_MinX)
            {
                transform.position = transform.position + Vector3.right * 0.1f * ((m_MaxX - transform.position.x) / 10);
            }
            else if(transform.position.x > m_MaxX)
            {
                transform.position = transform.position + Vector3.right * 0.1f * ((m_MaxX - transform.position.x) / 10);
            }
        }
        
	}
}
