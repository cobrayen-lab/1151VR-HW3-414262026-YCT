using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{ 
    float rotSpeed = 0;
    public AudioSource audioSource; 
    public float maxSpeed = 10f;    
    
    void Start()
    {
        Application.targetFrameRate = 60;

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = maxSpeed;

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Stop(); 
                audioSource.Play();
            }
        }

        transform.Rotate(0, 0, this.rotSpeed);

        if (audioSource != null && audioSource.isPlaying)
        {
            float speedRatio = this.rotSpeed / maxSpeed;

            audioSource.pitch = Mathf.Clamp(speedRatio, 0.1f, 1.0f);

            if (this.rotSpeed < 0.05f)
            {
                audioSource.Stop();
                this.rotSpeed = 0; 
            }
        }

        this.rotSpeed *= 0.96f;
    }
}
