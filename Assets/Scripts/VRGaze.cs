using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    private Animator anim;
    //public GameObject door;
    public Image imggaze;
    public float totaltime = 2.0f;

    bool gvrStatus;
    bool gvrAnimStatus;
    float gvrTimer;

    public Camera vrCam;

    //public AnimationClip dooropen;
    //public AnimationClip doorclose;
    Animation doorOpen;
    Animation doorClose;
    private bool isopened = false;
    private RaycastHit hitinfo;

    // Start is called before the first frame update
    void Start()
    {
        //anim = door.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imggaze.fillAmount = gvrTimer / totaltime;
            
        }

        if (Physics.Raycast(vrCam.transform.position, vrCam.transform.forward, out hitinfo))
        {
            if (imggaze.fillAmount == 1 && !isopened)
            {
                if (hitinfo.collider.gameObject.tag == "Door")
                {
                        anim = hitinfo.collider.gameObject.GetComponent<Animator>();
                        DoorOpening("Open");
                    Debug.Log("playing");
                        isopened = true;                           
                       
                        
                    
                }
            }

            if(imggaze.fillAmount < 1 && isopened)
            {
                
                DoorOpening("Close");
                isopened = false;
            }
        }
    }

    public void Gvron()
    {
        gvrStatus = true;
    }

    public void Gvroff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imggaze.fillAmount = 0;        
    }   
    public void DoorOpening(string direction)
    {
        anim.SetTrigger(direction);       
    }
    
}
