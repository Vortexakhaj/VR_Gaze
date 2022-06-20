using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrLookWalk : MonoBehaviour
{
    public Transform vRCam;
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float toggangle = 30.0f;
    private bool forwardmove ;
    public CharacterController charC;

    // Start is called before the first frame update
    void Start()
    {
        charC = GetComponentInParent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (vRCam.eulerAngles.x >= toggangle && vRCam.eulerAngles.x < 90.0f )
                    forwardmove = true;        
        else
            forwardmove = false;

        if (forwardmove)
        {
            Vector3 forwardm = vRCam.TransformDirection(Vector3.forward);
            charC.SimpleMove(forwardm * speed);
        }

    }

    
}
