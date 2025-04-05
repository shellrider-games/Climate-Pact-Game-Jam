using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamlessAudioLoop : MonoBehaviour
{
    public AudioSource soundSource1;
    public AudioSource soundSource2;
    public List<AudioClip> windSounds;
    public float crossfadeDuration = 2f;
    [Range(0f,1f)]
    public float volume = 1f;

    private bool source1 = true;

    void Start()
    {
        // Ensure AudioSources are properly initialized
        soundSource1.volume = volume;
        soundSource2.volume = 0f;

        soundSource1.clip = GetRandomClip();
        soundSource1.Play();

        StartCoroutine(PlayWindSounds());
    }

    private IEnumerator PlayWindSounds()
    {
        while (true)
        {
            AudioSource activeSource = source1 ? soundSource1 : soundSource2;
            AudioSource nextSource = source1 ? soundSource2 : soundSource1;

            // Assign a new clip to the inactive source
            nextSource.clip = GetRandomClip();

            // Start playing the new clip
            nextSource.Play();

            // Start crossfade
            StartCoroutine(Crossfade(activeSource, nextSource, crossfadeDuration));
            
            yield return new WaitForSeconds(nextSource.clip.length - crossfadeDuration);

            // Swap sources
            source1 = !source1;
        }
    }

    private IEnumerator Crossfade(AudioSource fromSource, AudioSource toSource, float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            fromSource.volume = Mathf.Lerp(volume, 0f, t);
            toSource.volume = Mathf.Lerp(0f, volume, t);

            yield return null;
        }

        fromSource.volume = 0f;
        toSource.volume = volume;

        // Stop the source that is fully faded out
        fromSource.Stop();
    }

    private AudioClip GetRandomClip()
    {
        if (windSounds.Count == 0)
        {
            Debug.LogError("No wind sounds available in the list!");
            return null;
        }
        
        return windSounds[Random.Range(0, windSounds.Count)];
    }

}
