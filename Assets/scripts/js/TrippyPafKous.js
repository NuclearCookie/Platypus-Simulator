
#pragma strict

@script ExecuteInEditMode
@script RequireComponent (Camera)

class TrippyPafKous extends PostEffectsBase {

	public var noise : Texture2D;
	public var squigleSpeed : float = 0.15;
	public var squigleSize : float = 0.15;
	public var squigleAmountX : float = 0.02;
	public var squigleAmountY : float = 0;
	
	private var time : float;

	public var TrippyPafKousShader : Shader = null;
	
	private var TrippyPafKousMaterial : Material = null;	
	
	function CheckResources () : boolean {	
		CheckSupport (false);
		TrippyPafKousMaterial = CheckShaderAndCreateMaterial(TrippyPafKousShader,TrippyPafKousMaterial);
		
		if(!isSupported)
			ReportAutoDisable ();
		return isSupported;			
	}
	
	function OnDisable () {
		if(TrippyPafKousMaterial)
			DestroyImmediate (TrippyPafKousMaterial);
		TrippyPafKousMaterial = null;
	}
	
	function OnRenderImage (source : RenderTexture, destination : RenderTexture) {		
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