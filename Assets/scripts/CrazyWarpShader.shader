Shader "Curvature" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
      	_Color ("Diffuse Color", Color) = (0.00,0.00,0.00,0.0)
    }
    SubShader {
        Tags { "RenderType"="AlphaTest" }
        //LOD 200
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
                struct v2f {
                    float4 pos : SV_POSITION;
                    float2 uv_MainTex : TEXCOORD0;
                };
                
                float4 _MainTex_ST;

                v2f vert(appdata_base v) {
                    v2f o;
                    //Curvature vertex modification
                    float4 pos = mul(UNITY_MATRIX_MV, v.vertex);
                    float distanceSquared = pos.x * pos.x + pos.z * pos.z;
                    // World Radius = 500; World Radius Squared = 250000
                    pos.y -= 500 - sqrt(max(1.0 - distanceSquared / 650000, 0.0)) * 500;
                    o.pos = mul(UNITY_MATRIX_P, pos);
                    //
                    o.uv_MainTex = TRANSFORM_TEX(v.texcoord, _MainTex);
                    return o;
                }
                sampler2D _MainTex;
                float4 _Color;
             
                float4 frag(v2f IN) : COLOR {
                    half4 c = tex2D (_MainTex, IN.uv_MainTex);
                    if(c.r + c.g + c.b == 3)
                    {
                    	c = _Color;
                    }
                    return c;
                }
            ENDCG
        }
    }
}
