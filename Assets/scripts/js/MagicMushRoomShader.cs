using UnityEngine;
using System.Collections;

public class MagicMushRoomShader : PostEffectsBase {

	public int speed = 300;
	public float enabled = 1.0f;
	private float time;
	public Shader MagicMushroomShader = null;
	private Material MagicMushroomMaterial = null;	
	
	bool CheckResources () {	
		CheckSupport (false);
		MagicMushroomMaterial = CheckShaderAndCreateMaterial(MagicMushroomShader,MagicMushroomMaterial);
		
		if(!isSupported)
			ReportAutoDisable ();
		return isSupported;			
	}
	
	void OnDisable () {
		if(MagicMushroomMaterial)
			DestroyImmediate (MagicMushroomMaterial);
		MagicMushroomMaterial = null;
	}
	
	void OnRenderImage ( RenderTexture source, RenderTexture destination ) {		
		if(CheckResources()==false) {
			Graphics.Blit (source, destination);	
			return;
		}
		
		time += Time.deltaTime;
		MagicMushroomMaterial.SetFloat("_TimeValue", time);
		MagicMushroomMaterial.SetFloat("_Speed", speed);
		MagicMushroomMaterial.SetFloat("_ShaderEnabled", enabled);
		
		// do stuff
		
		Graphics.Blit (source, destination, MagicMushroomMaterial); 	
	}
}
