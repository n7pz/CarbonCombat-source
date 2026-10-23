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
}
	//DummyShaderTextExporter
	
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Lambert
#pragma target 3.0
		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};
		void surf(Input IN, inout SurfaceOutput o)
		{
			float4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
		}
		ENDCG
	}
}