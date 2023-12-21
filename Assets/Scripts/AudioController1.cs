using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AudioController1 : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private BaseScript1 baseScript;
    private AudioSource audioSource;
    private Volume globalVolume;
    private Vignette vignette;

    private void Start()
    {
        globalVolume = GameObject.FindWithTag("PostProcessing").GetComponent<Volume>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        VignetteEffect();
        audioSource.volume = baseScript.GetHealth() + 0.5f;
    }

    private void VignetteEffect()
    {
        if (globalVolume.profile.TryGet<Vignette>(out vignette))
        {
            vignette.intensity.value = baseScript.GetHealth();
        }
    }
    public void Heartbeat()
    {
        if(audioSource.isPlaying == true)
        {
            return;
        }
        audioSource.PlayOneShot(audioClips[0]);
        StartCoroutine(Timer(1));
    }

    public void Explosion()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }

    private IEnumerator Timer(float duration)
    {
        yield return new WaitForSeconds(duration);
        audioSource.Stop();
        Heartbeat();
    }
}
