Shader "Shield" {
Properties {
 _Offset ("Time", Range(0,1)) = 0
 _Color ("Tint (RGB)", Color) = (1,1,1,1)
 _SurfaceTex ("Texture (RGB)", 2D) = "white" {}
 _RampTex ("Facing Ratio Ramp (RGB)", 2D) = "white" {}
}
SubShader {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Pass {
		Blend One One
		ZWrite Off
		Lighting Off
		Fog { Color (0,0,0,0) }

CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

sampler2D _SurfaceTex;
sampler2D _RampTex;
float4 _SurfaceTex_ST;
float4 _Color;
float _Offset;

struct v2f {
	float4 pos : POSITION;
	float2 uv : TEXCOORD0;
	float2 ramp : TEXCOORD1;
};

v2f vert (appdata_base v)
{
	v2f o;
	o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
	o.uv = TRANSFORM_TEX (v.texcoord, _SurfaceTex) + float2 (0, _Offset);
	float3 viewDir = normalize (ObjSpaceViewDir (v.vertex));
	float facing = saturate (dot (normalize (v.normal), viewDir));
	o.ramp = float2 (facing, 0.5);
	return o;
}

half4 frag (v2f i) : COLOR
{
	half4 surf = tex2D (_SurfaceTex, i.uv);
	half4 ramp = tex2D (_RampTex, i.ramp);
	return surf * ramp * _Color;
}
ENDCG
	}
}
FallBack "Particles/Additive"
}