Shader "Custom/MagicMushroom" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_TimeValue ("Time", float) = 0
		_ShaderEnabled ("Enabled", float) = 1
	}
	
	CGINCLUDE

		#include "UnityCG.cginc"

		sampler2D _MainTex;
		float _TimeValue;
		int _Speed;
		bool _ShaderEnabled;

		
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
		    
			//LAYER 1: COLOR SWAPPING
			float4 Color = tex2D(_MainTex, input.Tex);
			
			if(_ShaderEnabled == 1)
			{
		
				Color += ((((int)_TimeValue%(256/_Speed)) * _Speed)/255.0);
				
				if(Color.r > 1)
					Color.r = Color.r - 1;
				if(Color.g > 1)
					Color.g = Color.g - 1;
				if(Color.b > 1)
					Color.b = Color.b - 1;
					
					
				//LAYER 2:RANDOM OVERLAYS AND COLOR
				
				float somevar = 10;
				
				float4 Color2 = (tex2D(_MainTex, input.Tex)); 
				Color2.r += (tex2D(_MainTex , input.Tex+ (_TimeValue*somevar/100))).r; 
				Color2.g -= (tex2D(_MainTex , input.Tex+ (_TimeValue*somevar/200))).g; 
				Color2.b += (tex2D(_MainTex , input.Tex+ (_TimeValue*somevar/300))).b;
				Color2.a = 0.5;
				
				Color *= Color2;
				Color/2.0;
				Color *= 3.1; 
			}
				
		    return float4(Color);

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
