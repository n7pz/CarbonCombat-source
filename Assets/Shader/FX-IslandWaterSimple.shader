Shader "FX/Island Water Simple" {
Properties {
 _WaveScale ("Wave scale", Range(0.001,0.15)) = 0.063
 _ReflDistort ("Reflection distort", Range(0,1.5)) = 0.44
 _RefrDistort ("Refraction distort", Range(0,1.5)) = 0.4
 _RefrColor ("Refraction color", Color) = (0.34,0.85,0.92,1)
 _Fresnel ("Fresnel (A) ", 2D) = "" {}
 _BumpMap ("Bumpmap (RGB) ", 2D) = "" {}
 WaveSpeed ("Wave speed (map1 x,y; map2 x,y)", Vector) = (19,9,-16,-7)
 _ReflectiveColor ("Reflective color (RGB) fresnel (A) ", 2D) = "" {}
 _ReflectiveColorCube ("Reflective color cube (RGB) fresnel (A)", CUBE) = "" { TexGen CubeReflect }
 _HorizonColor ("Simple water horizon color", Color) = (0.172,0.463,0.435,1)
 _MainTex ("Fallback texture", 2D) = "" {}
 _ReflectionTex ("Internal Reflection", 2D) = "" {}
 _RefractionTex ("Internal Refraction", 2D) = "" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent-130" "WaterMode"="Reflective" }
 Pass {
  Tags { "QUEUE"="Transparent-130" "WaterMode"="Reflective" }
  ZWrite Off
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "WATER_REFLECTIVE" }
Bind "vertex" Vertex
Matrix 5 [_World2Object]
Vector 9 [_Time]
Vector 10 [_ProjectionParams]
Vector 11 [unity_Scale]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [WaveSpeed]
Float 14 [_WaveScale]
"!!ARBvp1.0
# 24 ALU
PARAM c[16] = { { 0, 0.5, 0.40000001, 0.44999999 },
		state.matrix.mvp,
		program.local[5..14],
		{ 1, 0.15000001 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
DP4 R3.w, vertex.position, c[4];
MOV R0.y, c[0];
MOV R0.xzw, c[0].xyxy;
MOV R1.w, R3;
DP4 R1.z, vertex.position, c[3];
DP4 R1.y, vertex.position, c[2];
DP4 R1.x, vertex.position, c[1];
MUL R0.y, R0, c[10].x;
DP4 result.texcoord[0].y, R1, R0;
MOV R0.w, c[15].x;
MOV R0.xyz, c[12];
DP4 R3.z, R0, c[7];
DP4 R3.x, R0, c[5];
DP4 R3.y, R0, c[6];
MOV R2, c[13];
MAD R0, R2, c[9].x, vertex.position.xzxz;
MUL R0, R0, c[14].x;
MAD result.texcoord[3].xyz, R3.xzyw, c[11].w, -vertex.position.xzyw;
MOV result.position, R1;
DP4 result.texcoord[0].x, R1, c[0].yxxy;
MUL result.texcoord[1].xy, R0, c[0].zwzw;
MOV result.texcoord[2].xy, R0.wzzw;
MOV result.texcoord[0].z, R3.w;
MAD result.texcoord[3].w, R3, c[15].y, c[15].x;
END
# 24 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "WATER_REFLECTIVE" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_World2Object]
Vector 8 [_Time]
Vector 9 [_ProjectionParams]
Vector 10 [unity_Scale]
Vector 11 [_WorldSpaceCameraPos]
Vector 12 [WaveSpeed]
Float 13 [_WaveScale]
"vs_2_0
; 24 ALU
def c14, 0.40000001, 0.44999999, 1.00000000, 0.15000001
def c15, 0.50000000, 0.00000000, 0, 0
dcl_position0 v0
dp4 r2.w, v0, c3
mov r0.y, c9.x
mov r0.xzw, c15.yyyx
mov r1.w, r2
dp4 r1.z, v0, c2
dp4 r1.y, v0, c1
dp4 r1.x, v0, c0
mul r0.y, c15.x, r0
dp4 oT0.y, r1, r0
mov r0.xyz, c11
mov r0.w, c14.z
dp4 r2.z, r0, c6
dp4 r2.y, r0, c5
dp4 r2.x, r0, c4
mov r0.x, c8
mad r0, c12, r0.x, v0.xzxz
mul r0, r0, c13.x
mad oT3.xyz, r2.xzyw, c10.w, -v0.xzyw
mov oPos, r1
dp4 oT0.x, r1, c15.xyyx
mul oT1.xy, r0, c14
mov oT2.xy, r0.wzzw
mov oT0.z, r2.w
mad oT3.w, r2, c14, c14.z
"
}
SubProgram "opengl " {
Keywords { "WATER_SIMPLE" }
Bind "vertex" Vertex
Matrix 5 [_World2Object]
Vector 9 [_Time]
Vector 10 [unity_Scale]
Vector 11 [_WorldSpaceCameraPos]
Vector 12 [WaveSpeed]
Float 13 [_WaveScale]
"!!ARBvp1.0
# 16 ALU
PARAM c[14] = { { 0.40000001, 0.44999999, 1, 0 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0, c[12];
MAD R0, R0, c[9].x, vertex.position.xzxz;
MUL R1, R0, c[13].x;
MOV R0.w, c[0].z;
MOV R0.xyz, c[11];
DP4 R2.z, R0, c[7];
DP4 R2.x, R0, c[5];
DP4 R2.y, R0, c[6];
MAD result.texcoord[2].xyz, R2.xzyw, c[10].w, -vertex.position.xzyw;
MUL result.texcoord[0].xy, R1, c[0];
MOV result.texcoord[1].xy, R1.wzzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
MOV result.texcoord[2].w, c[0];
END
# 16 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "WATER_SIMPLE" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_World2Object]
Vector 8 [_Time]
Vector 9 [unity_Scale]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [WaveSpeed]
Float 12 [_WaveScale]
"vs_2_0
; 16 ALU
def c13, 0.40000001, 0.44999999, 1.00000000, 0.00000000
dcl_position0 v0
mov r0.x, c8
mad r0, c11, r0.x, v0.xzxz
mul r1, r0, c12.x
mov r0.w, c13.z
mov r0.xyz, c10
dp4 r2.z, r0, c6
dp4 r2.x, r0, c4
dp4 r2.y, r0, c5
mad oT2.xyz, r2.xzyw, c9.w, -v0.xzyw
mul oT0.xy, r1, c13
mov oT1.xy, r1.wzzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
mov oT2.w, c13
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "WATER_REFLECTIVE" }
Float 0 [_ReflDistort]
SetTexture 0 [_BumpMap] 2D
SetTexture 1 [_ReflectionTex] 2D
SetTexture 2 [_Fresnel] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fog_exp2;
# 15 ALU, 4 TEX
PARAM c[2] = { program.local[0],
		{ 1, 0.010002136 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.xyz, fragment.texcoord[1], texture[0], 2D;
TEX R1.xyz, fragment.texcoord[2], texture[0], 2D;
ADD R1.xyz, R0, R1;
ADD R1.xyz, R1, -c[1].x;
MUL R2.xy, R1, fragment.texcoord[3].w;
DP3 R0.x, fragment.texcoord[3], fragment.texcoord[3];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[3];
DP3 R0.x, R1, R0;
MAD R2.xy, R2, c[0].x, fragment.texcoord[0];
MOV R2.z, fragment.texcoord[0];
TXP R1, R2.xyzz, texture[1], 2D;
TEX R0.w, R0.x, texture[2], 2D;
MAD result.color.w, R1, c[1].y, R0;
MOV result.color.xyz, R1;
END
# 15 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "WATER_REFLECTIVE" }
Float 0 [_ReflDistort]
SetTexture 0 [_BumpMap] 2D
SetTexture 1 [_ReflectionTex] 2D
SetTexture 2 [_Fresnel] 2D
"ps_2_0
; 14 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c1, -1.00000000, 0.01000214, 0, 0
dcl t0.xyz
dcl t1.xy
dcl t2.xy
dcl t3
texld r2, t1, s0
texld r1, t2, s0
dp3 r0.x, t3, t3
rsq r0.x, r0.x
add_pp r1.xyz, r2, r1
add_pp r1.xyz, r1, c1.x
mul r0.xyz, r0.x, t3
dp3 r0.x, r1, r0
mul_pp r2.xy, r1, t3.w
mov r1.z, t0
mad r1.xy, r2, c0.x, t0
mov r1.w, r1.z
mov r2.xyw, r1
mov r1.xy, r0.x
texldp r0, r2, s1
texld r1, r1, s2
mad_pp r0.w, r0, c1.y, r1
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "WATER_SIMPLE" }
Vector 0 [_HorizonColor]
SetTexture 0 [_BumpMap] 2D
SetTexture 1 [_ReflectiveColor] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fog_exp2;
# 13 ALU, 3 TEX
PARAM c[2] = { program.local[0],
		{ 1, 2 } };
TEMP R0;
TEMP R1;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
TEX R1.xyz, fragment.texcoord[1], texture[0], 2D;
ADD R1.xyz, R0, R1;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.w;
MUL R0.xyz, R0.x, fragment.texcoord[2];
ADD R1.xyz, R1, -c[1].x;
DP3 R0.x, R0, R1;
TEX R0, R0.x, texture[1], 2D;
ADD R1.xyz, -R0, c[0];
MUL R1.w, R0, c[0];
MAD result.color.xyz, R0.w, R1, R0;
MUL result.color.w, R1, c[1].y;
END
# 13 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "WATER_SIMPLE" }
Vector 0 [_HorizonColor]
SetTexture 0 [_BumpMap] 2D
SetTexture 1 [_ReflectiveColor] 2D
"ps_2_0
; 12 ALU, 3 TEX
dcl_2d s0
dcl_2d s1
def c1, -1.00000000, 2.00000000, 0, 0
dcl t0.xy
dcl t1.xy
dcl t2.xyz
texld r1, t1, s0
texld r2, t0, s0
dp3 r0.x, t2, t2
rsq r0.x, r0.x
add_pp r1.xyz, r2, r1
mul r0.xyz, r0.x, t2
add_pp r1.xyz, r1, c1.x
dp3 r0.x, r0, r1
mov r0.xy, r0.x
texld r1, r0, s1
add_pp r2.xyz, -r1, c0
mad_pp r1.xyz, r1.w, r2, r1
mul r0.x, r1.w, c0.w
mul r1.w, r0.x, c1.y
mov_pp oC0, r1
"
}
}
 }
}
SubShader { 
 Tags { "QUEUE"="Transparent-120" "WaterMode"="Simple" }
 Pass {
  Tags { "QUEUE"="Transparent-120" "WaterMode"="Simple" }
  Color (0.5,0.5,0.5,0.3)
  ZWrite Off
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
  SetTexture [_MainTex] { Matrix [_WaveMatrix] combine texture * primary }
  SetTexture [_MainTex] { Matrix [_WaveMatrix2] combine texture * primary + previous }
  SetTexture [_ReflectiveColorCube] { Matrix [_Reflection] combine texture * previous, primary alpha }
 }
}
SubShader { 
 Tags { "QUEUE"="Transparent-120" "WaterMode"="Simple" }
 Pass {
  Tags { "QUEUE"="Transparent-120" "WaterMode"="Simple" }
  Color [_HorizonColor]
  ZWrite Off
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
  SetTexture [_ReflectiveColorCube] { Matrix [_Reflection] combine texture, primary alpha }
 }
}
SubShader { 
 Tags { "QUEUE"="Transparent-120" "WaterMode"="Simple" }
 Pass {
  Tags { "QUEUE"="Transparent-120" "WaterMode"="Simple" }
  Color [_HorizonColor]
  ZWrite Off
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
  SetTexture [_MainTex] { Matrix [_WaveMatrix] combine texture, primary alpha }
 }
}
}