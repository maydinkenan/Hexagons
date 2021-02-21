using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;
    // Start is called before the first frame update
    public AudioSource effectsSource;
    public AudioClip[] audioClips;
    float effectPitch=1f;
    float pitchRate=0.1f;
    void Awake()
    {
        if(!_instance)
        {
            _instance=this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffect(int clip_id=0)
    {
        int clipNo  = Random.Range(0,audioClips.Length);
        clipNo=0;
        effectsSource.PlayOneShot(audioClips[clipNo]);
        //AudioSource.PlayClipAtPoint(audioClips[Random.Range(0,audioClips.Length)],Vector3.zero);
        effectPitch -= pitchRate;
        if(effectPitch <= .5f)
        {
            effectPitch = 1f;
        }
        effectsSource.pitch = effectPitch;
    }
}
