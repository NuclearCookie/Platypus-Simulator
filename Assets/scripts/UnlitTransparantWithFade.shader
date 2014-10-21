Shader "Unlit/UnlitAlphaWithFade"
{
    Properties
    {
        _Color ("Color Tint", Color) = (1,1,1,1)   
        _MainTex ("Base (RGB) Alpha (A)", 2D) = "white"
    }
    
    SubShader {
        Blend SrcAlpha OneMinusSrcAlpha
    	ZWrite Off
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        //LOD 200
        Pass {
	        Lighting Off
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"
                
                struct Input {
                    float4 pos : SV_POSITION;
                    float2 uv_MainTex : TEXCOORD0; 
                };
                float4 _MainTex_ST;
                
                Input vert(appdata_base v) {
                    Input o;
                    //o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
                    //Curvature vertex modification
                    float4 pos = mul(UNITY_MATRIX_MV, v.vertex); 
                    //float distanceSquared = pos.x * pos.x + pos.z * pos.z;
                    // World Radius = 500; World Radius Squared = 250000
                    //pos.y -= 500 - sqrt(max(1.0 - distanceSquared / 800000, 0.0)) * 500;
                    o.pos = mul(UNITY_MATRIX_P, pos);
                    //
                    o.uv_MainTex = TRANSFORM_TEX(v.texcoord, _MainTex);
                    return o;
                }
                sampler2D _MainTex;
                float4 _Color;
                float4 frag(Input IN) : COLOR {
                    half4 c = tex2D (_MainTex, IN.uv_MainTex);
                    c *= _Color;
                    return c;
                }
            ENDCG
        }
    }
}