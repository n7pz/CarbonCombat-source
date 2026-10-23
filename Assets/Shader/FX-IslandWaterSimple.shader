Shader "FX/Island Water Simple" {
Properties {
    _HorizonColor ("Simple water horizon color", Color) = (0.15,0.45,0.42,0.35)
    _RefrColor ("Refraction color", Color) = (0.34,0.85,0.92,0.35)
    _MainTex ("Fallback texture", 2D) = "white" {}
    _WaveScale ("Wave scale", Range(0.001,0.15)) = 0.063
    WaveSpeed ("Wave speed (map1 x,y; map2 x,y)", Vector) = (19,9,-16,-7)
    _WMid ("Water colour (middle tone)", Color) = (0.33,0.39,0.385,1)
    _WVar ("Pattern strength", Range(0,1.5)) = 0.35
    _WTexMean ("Texture average brightness", Range(0,1)) = 0.5
    _WBright ("Brightness", Range(0,1.5)) = 1.0
    _WHorizon ("Brighter toward the horizon", Range(0,1)) = 0.15
    _WFresnel ("Horizon falloff", Range(0.5,8)) = 3
    _WOpacity ("Opacity (per layer)", Range(0,1)) = 0.5
}

SubShader {
    Tags { "Queue"="Transparent" "RenderType"="Transparent" "WATERMODE"="Simple" }
    ZWrite Off
    Cull Off
    Offset -1, -1
    Blend SrcAlpha OneMinusSrcAlpha

    Pass {
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #include "UnityCG.cginc"

        float _WaveScale;
        float4 WaveSpeed;
        sampler2D _MainTex;
        float4 _WMid;
        float _WVar;
        float _WTexMean;
        float _WBright;
        float _WHorizon;
        float _WFresnel;
        float _WOpacity;

        struct v2f {
            float4 pos : SV_POSITION;
            float2 uv1 : TEXCOORD0;
            float2 uv2 : TEXCOORD1;
            float fres : TEXCOORD2;
        };

        v2f vert(float4 vertex : POSITION) {
            v2f o;
            o.pos = mul(UNITY_MATRIX_MVP, vertex);
            float4 wpos = mul(_Object2World, vertex);
            o.uv1 = wpos.xz * _WaveScale + WaveSpeed.xy * (_Time.x * 0.03);
            o.uv2 = wpos.xz * (_WaveScale * 0.7) + WaveSpeed.zw * (_Time.x * 0.03);
            float3 v = normalize(_WorldSpaceCameraPos - wpos.xyz);
            o.fres = pow(1.0 - saturate(v.y), _WFresnel);
            return o;
        }

        half4 frag(v2f i) : COLOR {
            half3 t = (tex2D(_MainTex, i.uv1).rgb + tex2D(_MainTex, i.uv2).rgb) * 0.5;
            half l = dot(t, half3(0.299, 0.587, 0.114));
            half f = 1.0 + (l - _WTexMean) * _WVar * 2.0;
            half3 col = _WMid.rgb * f * _WBright;
            col *= 1.0 + _WHorizon * i.fres;
            return half4(col, _WOpacity);
        }
        ENDCG
    }
}
}