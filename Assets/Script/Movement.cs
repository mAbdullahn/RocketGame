using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]ParticleSystem movepartical;
    [SerializeField] ParticleSystem leftJet;
    [SerializeField] ParticleSystem rightJet;
    AudioSource m_Source;
    Rigidbody rb; 
    Transform trans;
    [SerializeField]float rotate_speed = 60;
    [SerializeField] AudioClip rocketaudio;
    // Start is called before the first frame update
    void Start()
    {
       
        rb=GetComponent<Rigidbody>();
        trans= GetComponent<Transform>();
        m_Source=GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        process_launch();
        process_rotate();
        
    }
    void process_launch()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(!movepartical.isPlaying) { movepartical.Play(); }
            
            rb.AddRelativeForce(Vector3.up*250*Time.deltaTime);
            if(!m_Source.isPlaying ) { m_Source.PlayOneShot(rocketaudio); }
            

        }
        else {
            m_Source.Stop();
            movepartical.Stop();
        }

    }
    void process_rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(!rightJet.isPlaying) { rightJet.Play(); }
            RotateForward();

        }
        else if (Input.GetKey(KeyCode.D)) { if(!leftJet.isPlaying) {  leftJet.Play(); } 
            RotateBackword(); }
        else { leftJet.Stop();
            rightJet.Stop();
        }
    }

    private void RotateBackword()
    {
        rb.freezeRotation = true;
        trans.Rotate(Vector3.back * rotate_speed * Time.deltaTime);
        rb.freezeRotation= false;
    }

    private void RotateForward()
    {
        rb.freezeRotation = true;
        trans.Rotate(Vector3.forward * rotate_speed * Time.deltaTime);
        rb.freezeRotation= false;
    }
}
