Shader "Myshaders/TransparentReflective" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _Cube ("Cubemap", CUBE) = "" {}
 _TTint ("Water tint", Color) = (0.16,0.33,0.35,1)
 _TRefl ("Sky reflection amount", Range(0,1)) = 0.15
 _TBright ("Brightness", Range(0,1.5)) = 1.0
 _TOpacity ("Opacity", Range(0,1)) = 0.1
}

SubShader {
    Tags { "Queue"="Transparent" "RenderType"="Transparent" }
    ZWrite Off
    Cull Off
    Blend SrcAlpha OneMinusSrcAlpha

    Pass {
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #include "UnityCG.cginc"

        samplerCUBE _Cube;
        float4 _TTint;
        float _TRefl;
        float _TBright;
        float _TOpacity;

        struct v2f {
            float4 pos : SV_POSITION;
            float3 refl : TEXCOORD0;
        };

        v2f vert(float4 vertex : POSITION) {
            v2f o;
            o.pos = mul(UNITY_MATRIX_MVP, vertex);
            float3 wpos = mul(_Object2World, vertex).xyz;
            float3 vdir = normalize(wpos - _WorldSpaceCameraPos);
            o.refl = float3(vdir.x, -vdir.y, vdir.z);
            return o;
        }

        half4 frag(v2f i) : COLOR {
            half3 refl = texCUBE(_Cube, i.refl).rgb;
            half3 col = lerp(_TTint.rgb, refl, _TRefl) * _TBright;
            return half4(col, _TOpacity);
        }
        ENDCG
    }
}
}