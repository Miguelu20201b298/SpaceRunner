using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0f, 0f, -10f);

    public float dampingTime = 0.3f;

    public Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera(true);
    }

    public void ResetCameraPosition()
    {
        MoveCamera(false);
    }

    void MoveCamera(bool smooth)
    {
        Vector3 destino = new Vector3
            (target.position.x - offset.x,
            offset.y,
            offset.z);

        if (smooth)
        {
            this.transform.position = Vector3.SmoothDamp(
                this.transform.position, 
                destino, 
                ref velocity, 
                dampingTime);
        }
        else
        {
            this.transform.position = destino;
        }
    }
}
