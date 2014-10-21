
#pragma strict

@script ExecuteInEditMode
@script RequireComponent (Camera)
@script AddComponentMenu ("Image Effects/PusPusPlatypus/")

class MinecraftWarpShader extends PostEffectsBase {
	public var minecraftWarpShader : Shader = null;
	private var minecraftWarpMaterial : Material = null;	
	
	function CheckResources () : boolean {	
		CheckSupport (false);
		minecraftWarpMaterial = CheckShaderAndCreateMaterial(minecraftWarpShader,minecraftWarpMaterial);
		
		if(!isSupported)
			ReportAutoDisable ();
		return isSupported;			
	}
	
	function OnRenderImage (source : RenderTexture, destination : RenderTexture) {		
		if(CheckResources()==false) {
			Graphics.Blit (source, destination);
			return;
		}
		
		// do stuff
		
		Graphics.Blit (source, destination, minecraftWarpMaterial); 	
	}
}