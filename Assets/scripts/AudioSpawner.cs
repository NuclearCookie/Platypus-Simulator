using UnityEngine;
using System.Collections;

public class AudioSpawner : MonoBehaviour
{
	GameObject parentObject;

    void Awake()
    {
        parentObject = GameObject.FindGameObjectWithTag("AudioParent");
    }
    
    public AudioSource Play(AudioClip clip, Vector3 pos, bool loop, float volume, float pitch)
    {
        //create new empty gameobject
        GameObject go = new GameObject(clip.name);

        if (!parentObject)
        {
            parentObject = GameObject.FindGameObjectWithTag("AudioParent");
        }
        go.transform.parent = parentObject.transform;
		go.transform.position = pos;

        //Create the AudioSource
        AudioSource source = go.AddComponent<AudioSource>();
        source.time = 0.0f;
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
        source.minDistance = 5;
        source.Play();

        if (!loop)
		{
            Destroy(source.gameObject, clip.length);
		}

        return source;
    }

}
