Shader "DoubleSided" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader { 
 Pass {
  Name "BASE"
  Tags { "LIGHTMODE"="Always" }
  Color [_PPLAmbient]
  SetTexture [_BumpMap] { ConstantColor (0.5,0.5,0.5,1) combine constant lerp(texture) previous }
  SetTexture [_MainTex] { ConstantColor [_Color] combine texture * previous double, texture alpha * constant alpha }
 }
 Pass {
  Name "BASE"
  Tags { "LIGHTMODE"="Vertex" }
  Lighting On
  SeparateSpecular On
  Material {
   Diffuse [_Color]
   Emission [_PPLAmbient]
   Specular [_SpecColor]
   Shininess [_Shininess]
  }
  Cull Off
  SetTexture [_BumpMap] { ConstantColor (0.5,0.5,0.5,1) combine constant lerp(texture) previous }
  SetTexture [_MainTex] { combine texture * previous double, texture alpha * primary alpha }
 }
}
Fallback "Diffuse"
}