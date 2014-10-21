
#pragma strict

@script ExecuteInEditMode
@script RequireComponent (Camera)

class MagicMushroomShader extends PostEffectsBase {

	public var speed : int = 300;
	
	private var time : float;

	public var MagicMushroomShader : Shader = null;
	
	private var MagicMushroomMaterial : Material = null;	
	
	function CheckResources () : boolean {	
		CheckSupport (false);
		MagicMushroomMaterial = CheckShaderAndCreateMaterial(MagicMushroomShader,MagicMushroomMaterial);
		
		if(!isSupported)
			ReportAutoDisable ();
		return isSupported;			
	}
	
	function OnDisable () {
		if(MagicMushroomMaterial)
			DestroyImmediate (MagicMushroomMaterial);
		MagicMushroomMaterial = null;
	}
	
	function OnRenderImage (source : RenderTexture, destination : RenderTexture) {		
		if(CheckResources()==false) {
			Graphics.Blit (source, destination);	
			return;
		}
		
		time += Time.deltaTime;
		MagicMushroomMaterial.SetFloat("_TimeValue", time);
		MagicMushroomMaterial.SetFloat("_Speed", speed);
		
		// do stuff
		
		Graphics.Blit (source, destination, MagicMushroomMaterial); 	
	}
}