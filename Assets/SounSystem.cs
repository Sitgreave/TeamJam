using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounSystem : MonoBehaviour
{
    public AudioSource _source;
    public List<AudioClip> _coinsSound;

    public void PlayPickCoinSound()
    {
        int id = Random.Range(0, _coinsSound.Count);
        _source.PlayOneShot(_coinsSound[id]);
    }
}
