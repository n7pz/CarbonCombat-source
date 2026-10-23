Shader "Transparent/GlassShiny" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _FColor ("Fallback Color", Color) = (1,1,1,1)
 _SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
 _Cube ("Reflection Cubemap", CUBE) = "_Skybox" { TexGen CubeNormal }
 _Glow ("Glow (for LEDs and lights)", Range(0,1)) = 0
 _ReflAmount ("Reflection Amount", Range(0,1)) = 0.5
}
SubShader {
	Tags { "Queue"="Transparent" "RenderType"="Transparent" }
	LOD 300

CGPROGRAM
#pragma surface surf BlinnPhong alpha

samplerCUBE _Cube;
fixed4 _Color;
half _Glow;
half _ReflAmount;

struct Input {
	float3 worldRefl;
};

void surf (Input IN, inout SurfaceOutput o)
{
	fixed3 refl = texCUBE (_Cube, IN.worldRefl).rgb;
	o.Albedo = _Color.rgb;
	o.Emission = refl * _ReflAmount + _Color.rgb * _Glow;
	o.Gloss = 1.0;
	o.Specular = 0.6;
	o.Alpha = _Color.a;
}
ENDCG
}
FallBack "Transparent/Diffuse"
}