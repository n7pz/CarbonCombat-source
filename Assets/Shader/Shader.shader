Shader "CarbonPaint" {
Properties {
 _Color ("Main Color", Color) = (0,0,0,1)
 _SecondaryFresnel ("Edge Lighting Amount", Float) = 0
 _SecondaryColor ("Edge Lighting Color", Color) = (1,1,1,1)
 _CubeMap ("Reflection Cubemap", CUBE) = "black" {}
 _Fresnel ("Reflection Falloff", Float) = 1
 _FresnelInverse ("Inverse Reflection Falloff", Float) = 0
 _RefColor ("Reflection Color", Color) = (1,1,1,1)
 _RefColorInverse ("Inverse Reflection Color", Color) = (1,1,1,1)
 _Specular ("Gloss Color", Color) = (1,1,1,1)
 _Gloss ("Gloss Amount", Range(0.1,1)) = 0.5
 _ReflBoost ("Reflection Strength", Range(0,1.5)) = 0.65
 _EdgeBoost ("Edge Lighting Strength", Range(0,1.5)) = 0.4
 _Desat ("Desaturate Highlights", Range(0,1)) = 0.35
 _Paint ("Paint Brightness", Range(0,1.5)) = 0.85
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 300

CGPROGRAM
#pragma surface surf CarPaint

samplerCUBE _CubeMap;
fixed4 _Color;
fixed4 _SecondaryColor;
fixed4 _RefColor;
fixed4 _RefColorInverse;
fixed4 _Specular;
half _SecondaryFresnel;
half _Fresnel;
half _FresnelInverse;
half _Gloss;
half _ReflBoost;
half _EdgeBoost;
half _Desat;
half _Paint;

inline fixed4 LightingCarPaint (SurfaceOutput s, fixed3 lightDir, half3 viewDir, fixed atten)
{
	fixed diff = max (0, dot (s.Normal, lightDir));
	half3 h = normalize (lightDir + viewDir);
	float nh = max (0, dot (s.Normal, h));
	float spec = pow (nh, s.Specular * 128.0) * s.Gloss;
	fixed4 c;
	c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * _Specular.rgb * spec) * (atten * 2);
	c.a = s.Alpha;
	return c;
}

struct Input {
	float3 viewDir;
	float3 worldRefl;
};

void surf (Input IN, inout SurfaceOutput o)
{
	half ndv = saturate (dot (normalize (IN.viewDir), o.Normal));
	half rim = 1.0 - ndv;
	fixed3 refl = texCUBE (_CubeMap, IN.worldRefl).rgb;
	half outer = pow (max (rim, 0.0001), _Fresnel);
	half inner = (_FresnelInverse > 0.001) ? pow (max (ndv, 0.0001), _FresnelInverse) : 0.0;
	fixed3 reflCol = _RefColor.rgb * outer + _RefColorInverse.rgb * inner;

	half3 emis = refl * reflCol * _ReflBoost
	           + _SecondaryColor.rgb * (_SecondaryFresnel * rim * rim * rim * _EdgeBoost);
	half lum = dot (emis, half3 (0.299, 0.587, 0.114));
	emis = lerp (emis, half3 (lum, lum, lum), _Desat);

	o.Albedo = _Color.rgb * _Paint;
	o.Emission = emis;
	o.Specular = _Gloss;
	o.Gloss = 1.0;
	o.Alpha = 1.0;
}
ENDCG
}
FallBack "Diffuse"
}