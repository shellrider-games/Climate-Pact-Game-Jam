using UnityEngine;
using UnityEngine.Events;

public class PlaySoundOnEvent : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;

    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(clip, this.transform.position);
    }
}
