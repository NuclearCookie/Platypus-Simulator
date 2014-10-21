using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MicrophoneListener : MonoBehaviour {
	
	public Texture2D mutedImg;
	
	private const int SAMPLECOUNT = 1024;
	public float REFVALUE = 0.1f; //RMS value for 0dB
	public float THRESHOLD = 0.02f; //Minimum amplitude to extract pitch (recieve anything)
	public int LAZINESS = 10;
	
	public int clamp = 160; //Used to clamp dB (?)

	
	private bool initialized = false;
	
	private float rmsValue;		//Volume in RMS
	private float dbValue;		//Volume in dB
	private float pitchValue;	//Dominant frequency
	
	
	
	public float minToleranceValue = 2f;
	public float maxToleranceValue = 50;
	
	private float[] samples; 			//Samples
	private float[] spectrum;			//Spectrum

    private bool Kissing = false;
    private float DelayTime = 1.0f;
    public float MaxDelayTime = 1.0f;
	private float triggerTime = 0.0f;
	private int nrOfFramesLaziness;
	private bool hasPressedKeyboardOrMouse = false;
	
	public float MinKissLength = 0.1f;
	public float MaxKissLength = 0.5f;
	
	public bool MicrophoneEnabled = true;
	
	public void Init()
	{
		if(initialized)
			return;
		
		samples = new float[SAMPLECOUNT];
		spectrum =  new float[SAMPLECOUNT];
		
		if(audio == null)
			gameObject.AddComponent<AudioSource>();
		audio.playOnAwake = false;
			audio.loop = false;
		enabled = false;
		initialized = true;
		
	}
	// Use this for initialization
	void Start () 
	{
        Kissing = false;
		StartMicListener();
		
	}
	
	void OnGUI()
	{

		if(!MicrophoneEnabled)
		{
			GUI.DrawTexture(new Rect(5,5,Screen.width*0.05f,Screen.width*0.05f), mutedImg);	
		}
		
    }

	// Update is called once per frame
	void Update () 
	{
		hasPressedKeyboardOrMouse = false;
		if(Input.GetButtonUp("Mute"))
		{
			MicrophoneEnabled = !MicrophoneEnabled;	
		}
		
		Kissing = false;
		
		if(MicrophoneEnabled)
		{
			//Gets volume and pitch values
			AnalyzeSound();

			//Debug.Log("Pitch Value: " + pitchValue);
			Kissing = pitchValue > minToleranceValue && pitchValue < maxToleranceValue ;
			if(Kissing)
			{
				triggerTime += Time.deltaTime;
				nrOfFramesLaziness = 0;
			}
			else
			{
				nrOfFramesLaziness++;
				if(nrOfFramesLaziness >= LAZINESS)
				{
					//Debug.LogWarning("Kissing Disabled");
					triggerTime = 0;
					nrOfFramesLaziness = 0;
				}
			}
		}
		
		if(!Kissing)
		{
			if(Input.GetButtonDown("Kiss"))
			{
				Debug.Log("Kissing!!");
				Kissing = true;	
				hasPressedKeyboardOrMouse = true;
			}
		}
		
		if (Time.deltaTime < MaxDelayTime)
	        {
	            DelayTime += Time.deltaTime;
	        }
		
	}

    public bool CanKiss()
    {
		bool canReallyKiss = false;
		if(!hasPressedKeyboardOrMouse)
		{
    		canReallyKiss = Kissing && DelayTime >= MaxDelayTime && (triggerTime > MinKissLength && triggerTime < MaxKissLength);
		}
		else
		{
			canReallyKiss = Kissing && DelayTime >= MaxDelayTime;
			hasPressedKeyboardOrMouse = false;
		}
        if (canReallyKiss)
        {
            DelayTime = 0.0f;
        }
		Kissing = false;
        return canReallyKiss;
    }
	
	//Starts the mic and plays the audio back in (near) real-time
	private void StartMicListener()
	{
		Init ();
		
		if(Microphone.devices.Length > 0)
		{
			audio.clip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate);
			while(!(Microphone.GetPosition(null) > 0))
			{
			}
			audio.Play();
			audio.mute = true;
			audio.loop = true;
			enabled = true;
		}
		else
			enabled = false;
	}
	
	private void StopMicListener()
	{
		if(audio == null)
			return;
		if(Microphone.IsRecording(null))
			Microphone.End(null);
		DestroyImmediate(audio);
		initialized = false;
	}
	
	private void AnalyzeSound()
	{
		
		if(audio == null)
			return;
		
		//Get all of our samples from the mic
		audio.GetOutputData(samples, 0);
		
		//Sums squared samples
		float sum = 0;
		for(int i = 0; i < SAMPLECOUNT; i++)
		{
			sum += samples[i]*samples[i];	
		}
		
		//RMS is the square root of the average value of the samples.
		rmsValue = Mathf.Sqrt(sum/ SAMPLECOUNT);
		dbValue = 20 * Mathf.Log10(rmsValue / REFVALUE); //Calculate dB
		
		//clamp it to {clamp} min
		if(dbValue < -clamp)
		{
			dbValue = -clamp;
		}
		
		//Gets the sound spectrum
		audio.GetSpectrumData(spectrum, 0,FFTWindow.BlackmanHarris);
		float maxV = 0;
		int maxN = 0;
		
		//Find the highest sample
		for(int i = 0; i < SAMPLECOUNT; i++)
		{
			if(spectrum[i] > maxV && spectrum[i] > THRESHOLD)
			{
				maxV = spectrum[i];
				maxN = i; //MaxN is the index of max
			}
		}
		
		//Pass the index to a float variable
		float freqN = maxN;
		
		//Interpolate index using neighbours
		if(maxN > 0 && maxN < SAMPLECOUNT - 1)
		{
			float dL = spectrum[maxN-1] / spectrum[maxN];
			float dR = spectrum[maxN+1] / spectrum[maxN];
			freqN += 0.5f * (dR * dR - dL * dL);
		}
		
		pitchValue = freqN*24000/SAMPLECOUNT;
	}
}
