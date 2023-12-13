using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AudioController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    private AudioSource audioSource;
    private Volume globalVolume;
    private Vignette vignette;

    private void Start()
    {
        globalVolume = GameObject.FindWithTag("PostProcessing").GetComponent<Volume>();
        audioSource = GetComponent<AudioSource>();
    }
    public void Heartbeat()
    {
        if (globalVolume.profile.TryGet<Vignette>(out temp))
        {
            vignette = temp;
        }
        audioSource.volume = 0.5f;
        if(audioSource.isPlaying == true)
        {
            return;
        }
        audioSource.PlayOneShot(audioClips[0]);
        StartCoroutine(Timer(1));
    }

    private IEnumerator Timer(float duration)
    {
        yield return new WaitForSeconds(duration);
        audioSource.Stop();
        Heartbeat();
    }
}
