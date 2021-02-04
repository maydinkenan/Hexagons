using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    ParticleSystem.Particle[] particles;
    public ParticleSystem _particleSystem;
    public float objDistance =  0.75f;  // Distance apart objects are apart on a row
    public int rows = 12;
    public int cols = 12;
    
    private float rowDist;
    private float rowStart;
    private Vector3 v3Pos; 
    private Vector3 v3Scale = new Vector3(0.42f, 0.42f, 0.42f);
    private Vector3 v3Center=Vector3.zero;
    public Vector3[] particlePositions;
    public int maxNumberOfParticles;
    private bool didParticleSystemUpdated=true;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = this.gameObject.GetComponent<ParticleSystem>();
        CalculateParticlePositions();
        GetParticles();
        ShowParticles();
        
    }
    public void ShowParticles()
    {
        _particleSystem.Play();
        didParticleSystemUpdated=true;
    }
    public void HideParticles()
    {
        _particleSystem.Stop();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShowParticles();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            HideParticles();
        }
        GetParticles();
        SetParticles();
    }
    void CalculateParticlePositions()
    {
        var main = _particleSystem.main;
        main.maxParticles = cols * rows;
        _particleSystem.Emit(rows*cols);
        v3Center = transform.position;
        maxNumberOfParticles = rows * cols;
        particlePositions = new Vector3[maxNumberOfParticles];
        float fT = ((objDistance * objDistance) - ((objDistance * objDistance * 0.25f)));
        rowDist  = Mathf.Sqrt ((objDistance * objDistance) - ((objDistance * objDistance * 0.25f)));
        rowStart = -(cols * objDistance / 2.0f - 0.25f * objDistance);
        v3Pos    = new Vector3(rowStart, rows * rowDist / 2.0f, 0.0f); 
        int i = 0;
        for (int c = 0 ; c<rows ; c++)
        {
            if ((c % 2) == 1)
            {
                v3Pos.x -= objDistance / 2.0f;
            }
            for(int k = 0 ; k<cols; k++)
            {
                v3Pos.x  +=objDistance;
                particlePositions[i]=v3Pos+v3Center;
                i++;
            }
            
            
            v3Pos.x -= objDistance / 2.0f;
            v3Pos.x = rowStart;
            v3Pos.y -= rowDist;
        }
    }
    public void GetParticles()
    {
        if(didParticleSystemUpdated)
        {
            particles = new ParticleSystem.Particle[maxNumberOfParticles];

            int numberOfParticles =_particleSystem.GetParticles(particles);
            
            for (int i = 0 ; i<maxNumberOfParticles ; i++)
            {        
                particles[i].position = particlePositions[i];
                if(particles[i].startColor!=Color.white)
                {
                    particles[i].startColor = Game_Manager._instance.GetColor();
                }
                
            }
            didParticleSystemUpdated=false;
        }
        
        
    }
    void SetParticles()
    {
        _particleSystem.SetParticles(particles);
    }
}
