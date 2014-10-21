using UnityEngine;
using System.Collections;

public class TrippyPafKous : PostEffectsBase {
	
	public Texture2D noise;
	public float squigleSpeed = 0.15f;
	public float squigleSize = 0.15f;
	public float squigleAmountX = 0.02f;
	public float squigleAmountY = 0;
	
	private float time;
	
	public Shader TrippyPafKousShader = null;
	public Material TrippyPafKousMaterial = null;	
	
	bool CheckResources () {	
		CheckSupport (false);
		TrippyPafKousMaterial = CheckShaderAndCreateMaterial(TrippyPafKousShader,TrippyPafKousMaterial);
		
		
		if(!isSupported)
			ReportAutoDisable ();
		return isSupported;			
	}
	
	void OnDisable () {
		if(TrippyPafKousMaterial)
			DestroyImmediate (TrippyPafKousMaterial);
		TrippyPafKousMaterial = null;
	}
	
	void OnRenderImage (RenderTexture source, RenderTexture destination) {		
		if(CheckResources()==false) {
			Graphics.Blit (source, destination);	
			return;
		}
		
		TrippyPafKousMaterial.SetTexture ("_NoiseTex", noise);	
		time += Time.deltaTime;
		TrippyPafKousMaterial.SetFloat("_TimeValue", time);
		TrippyPafKousMaterial.SetFloat("_SquigleSpeed", squigleSpeed);
		TrippyPafKousMaterial.SetFloat("_SquigleSize", squigleSize);
		TrippyPafKousMaterial.SetFloat("_SquigleAmountX", squigleAmountX);
		TrippyPafKousMaterial.SetFloat("_SquigleAmountY", squigleAmountY);
		
		// do stuff
		
		Graphics.Blit (source, destination, TrippyPafKousMaterial); 	
	}
}
