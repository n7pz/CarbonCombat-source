Shader "Outlined/AlwaysShow" {
Properties {
    _Color ("Main Color", Color) = (0.5,0.5,0.5,1)
    _OutlineColor ("Outline Color", Color) = (0,0,0,1)
    _Outline ("Outline width", Range(0,0.03)) = 0.005
    _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 200

    CGPROGRAM
    #pragma surface surf Lambert
    sampler2D _MainTex;
    fixed4 _Color;
    struct Input {
        float2 uv_MainTex;
    };
    void surf (Input IN, inout SurfaceOutput o) {
        fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
        o.Albedo = c.rgb;
        o.Alpha = c.a;
    }
    ENDCG
}
FallBack "Diffuse"
}