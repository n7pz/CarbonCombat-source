Shader "Legacy Shaders/Lightmapped/VertexLit" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _SpecColor ("Spec Color", Color) = (1,1,1,1)
 _Shininess ("Shininess", Range(0.01,1)) = 0.7
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _LightMap ("Lightmap (RGB)", 2D) = "lightmap" {}
}
SubShader { 
 LOD 100
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "BASE"
  Tags { "LIGHTMODE"="Vertex" "RenderType"="Opaque" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "normal", Normal
   Bind "texcoord1", TexCoord0
   Bind "texcoord1", TexCoord1
   Bind "texcoord", TexCoord2
  }
  Lighting On
  SeparateSpecular On
  Material {
   Diffuse [_Color]
   Specular [_SpecColor]
   Shininess [_Shininess]
  }
  SetTexture [_LightMap] { ConstantColor [_Color] combine texture * constant }
  SetTexture [_LightMap] { ConstantColor (0.5,0.5,0.5,0.5) combine previous * constant + primary }
  SetTexture [_MainTex] { combine texture * previous double, texture alpha * primary alpha }
 }
}
SubShader { 
 LOD 100
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "BASE"
  Tags { "LIGHTMODE"="Always" "RenderType"="Opaque" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "normal", Normal
   Bind "texcoord1", TexCoord0
   Bind "texcoord", TexCoord1
  }
  SetTexture [_LightMap] { ConstantColor [_Color] combine texture * constant }
  SetTexture [_MainTex] { combine texture * previous, texture alpha * primary alpha }
 }
 Pass {
  Name "BASE"
  Tags { "LIGHTMODE"="Vertex" "RenderType"="Opaque" }
  Lighting On
  SeparateSpecular On
  Material {
   Diffuse [_Color]
   Specular [_SpecColor]
   Shininess [_Shininess]
  }
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend One One
  ColorMask RGB
  SetTexture [_MainTex] { combine texture * primary double, texture alpha }
 }
}
SubShader { 
 LOD 100
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "BASE"
  Tags { "LIGHTMODE"="Always" "RenderType"="Opaque" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "texcoord1", TexCoord0
  }
  SetTexture [_LightMap] { ConstantColor [_Color] combine texture * constant }
 }
 Pass {
  Name "BASE"
  Tags { "LIGHTMODE"="Always" "RenderType"="Opaque" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "texcoord", TexCoord0
  }
  Fog {
   Color (0,0,0,0)
  }
  Blend Zero SrcColor
  SetTexture [_MainTex] { combine texture }
 }
}
Fallback "VertexLit"
}