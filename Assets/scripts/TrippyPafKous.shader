Shader "Custom/TrippyPafKous" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_NoiseTex ("Noise (RGB)", 2D) = "white" {}
		_TimeValue ("Time", float) = 0
	}
	
	CGINCLUDE

		#include "UnityCG.cginc"

		sampler2D _MainTex;
		sampler2D _NoiseTex;
		float _TimeValue;
		float _SquigleSpeed;
		float _SquigleSize;
		float _SquigleAmountX;
		float _SquigleAmountY;

		
		struct VS_INPUT_STRUCT
		{
			float3 Pos : POSITION;
		    float2 Tex : TEXCOORD0;
		
		};
		struct PS_INPUT_STRUCT
		{
			float4 Pos : SV_POSITION;
			float2 Tex : TEXCOORD1;
		
		};

		PS_INPUT_STRUCT vert(VS_INPUT_STRUCT input)
		{
			PS_INPUT_STRUCT output;
			float4 pos = float4(input.Pos,1);
			output.Pos = mul(UNITY_MATRIX_MVP, pos); 
			output.Tex = input.Tex;
			
			return output;
		}
		
		float4 frag(PS_INPUT_STRUCT input) : COLOR
		{ 
		
		
			float2 uv = input.Tex;
		
			float time = _TimeValue * _SquigleSpeed;
			
			float4 pixel2 = (tex2D (_NoiseTex, (uv+float2(sin(time), cos(time))) * _SquigleSize));
			
			float xDiff = pixel2.r * _SquigleAmountX;
			float yDiff = pixel2.r * _SquigleAmountY;
			
			float2 diffVec = float2(xDiff, yDiff);
			
			float3 difColor = (tex2D(_MainTex, uv + diffVec)).rgb; 
			
		    return float4(difColor,1); 

		}
		
		ENDCG
	
	subShader{
		Pass {
	
		CGPROGRAM
		
		#pragma vertex vert
		#pragma fragment frag
		
		ENDCG
		 
		}
	}
}
