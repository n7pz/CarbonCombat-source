Shader "Hidden/Nature/Tree Creator Leaves Optimized" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _TranslucencyColor ("Translucency Color", Color) = (0.73,0.85,0.41,1)
 _Cutoff ("Alpha cutoff", Range(0,1)) = 0.3
 _TranslucencyViewDependency ("View dependency", Range(0,1)) = 0.7
 _ShadowStrength ("Shadow Strength", Range(0,1)) = 0.8
 _ShadowOffsetScale ("Shadow Offset Scale", Float) = 1
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
 _ShadowTex ("Shadow (RGB)", 2D) = "white" {}
 _BumpSpecMap ("Normalmap (GA) Spec (R) Shadow Offset (B)", 2D) = "bump" {}
 _TranslucencyMap ("Trans (B) Gloss(A)", 2D) = "white" {}
 _Scale ("Scale", Vector) = (1,1,1,1)
 _SquashAmount ("Squash", Float) = 1
}
SubShader { 
 LOD 200
 Tags { "IGNOREPROJECTOR"="True" "RenderType"="TreeLeaf" }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardBase" "IGNOREPROJECTOR"="True" "RenderType"="TreeLeaf" }
  AlphaToMask On
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_Time]
Vector 18 [unity_Scale]
Vector 19 [_WorldSpaceCameraPos]
Vector 20 [_WorldSpaceLightPos0]
Vector 21 [unity_SHAr]
Vector 22 [unity_SHAg]
Vector 23 [unity_SHAb]
Vector 24 [unity_SHBr]
Vector 25 [unity_SHBg]
Vector 26 [unity_SHBb]
Vector 27 [unity_SHC]
Vector 28 [_Scale]
Vector 29 [_SquashPlaneNormal]
Float 30 [_SquashAmount]
Vector 31 [_Wind]
Vector 32 [_MainTex_ST]
"!!ARBvp1.0
# 105 ALU
PARAM c[35] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..32],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1, -1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MUL R0, vertex.normal.y, c[6];
MAD R2, vertex.normal.x, c[5], R0;
ADD R0.xyz, R2, c[0].x;
MAD R2, vertex.normal.z, c[7], R2;
ADD R3, R2, c[0].x;
DP4 R3.w, R3, R3;
ABS R0.w, vertex.attrib[14];
ADD R0.w, -R0, c[0].y;
MAD R0.xyz, R0, R0.w, vertex.position;
MOV R1.x, c[0].y;
DP3 R1.x, R1.x, c[12];
ADD R1.x, vertex.color, R1;
ADD R1.z, vertex.color.y, R1.x;
MUL R0.xyz, R0, c[28];
MOV R1.y, R1.x;
DP3 R1.x, R0, R1.z;
ADD R1.xy, R1, c[17].y;
MUL R1, R1.xxyy, c[33];
FRC R1, R1;
MAD R1, R1, c[0].z, c[0].w;
FRC R1, R1;
MAD R1, R1, c[0].z, -c[0].y;
ABS R1, R1;
MUL R2, -R1, c[0].z;
ADD R2, R2, c[34].x;
MUL R1, R1, R1;
MUL R1, R1, R2;
RSQ R3.w, R3.w;
ADD R5.xy, R1.xzzw, R1.ywzw;
MAD R2.xyz, R3.w, R3, -vertex.normal;
MAD R1.xyz, R0.w, R2, vertex.normal;
MUL R2.xyz, R5.y, c[31];
MUL R3.xy, vertex.color.y, R1.xzzw;
MUL R4.xyz, vertex.texcoord[1].y, R2;
MUL R3.xz, R3.xyyw, c[34].z;
MUL R2, vertex.attrib[14].y, c[6];
MUL R3.y, vertex.texcoord[1], c[34];
MAD R3.xyz, R5.xyxw, R3, R4;
MAD R0.xyz, R3, c[31].w, R0;
MAD R3.xyz, vertex.texcoord[1].x, c[31], R0;
DP3 R0.x, R3, c[29];
MAD R2, vertex.attrib[14].x, c[5], R2;
MAD R2, vertex.attrib[14].z, c[7], R2;
ADD R2, R2, c[0].x;
DP4 R0.y, R2, R2;
RSQ R0.y, R0.y;
MUL R2.xyz, R0.y, R2;
ADD R0.x, R0, c[29].w;
MUL R0.xyz, R0.x, c[29];
ADD R4.xyz, -R0, R3;
MOV R2.w, c[34];
ADD R2, -vertex.attrib[14], R2;
MAD R2, R0.w, R2, vertex.attrib[14];
DP3 R1.w, R2, R2;
DP3 R0.w, R1, R1;
RSQ R1.w, R1.w;
MUL R3.xyz, R1.w, R2;
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, R1;
MAD R0.xyz, R0, c[30].x, R4;
MOV R0.w, c[0].y;
MUL R1.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R1;
MOV R1.w, c[0].y;
MOV R1.xyz, c[19];
DP4 result.position.w, R0, c[4];
DP4 result.position.z, R0, c[3];
DP4 result.position.y, R0, c[2];
DP4 result.position.x, R0, c[1];
MOV R0.w, c[0].y;
DP4 R5.z, R1, c[15];
DP4 R5.y, R1, c[14];
DP4 R5.x, R1, c[13];
MAD R5.xyz, R5, c[18].w, -R0;
MUL R1.xyz, R2, c[18].w;
MUL R4.xyz, R4, R2.w;
DP3 R2.w, R1, c[10];
DP3 R0.x, R1, c[9];
DP3 R0.z, R1, c[11];
MOV R0.y, R2.w;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R6.z, R0, c[23];
DP4 R6.y, R0, c[22];
DP4 R6.x, R0, c[21];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[26];
DP4 R0.y, R1, c[25];
DP4 R0.x, R1, c[24];
MUL R1.xyz, R0.w, c[27];
ADD R0.xyz, R6, R0;
ADD result.texcoord[2].xyz, R0, R1;
MOV R0, c[20];
DP4 R1.z, R0, c[15];
DP4 R1.x, R0, c[13];
DP4 R1.y, R0, c[14];
DP3 result.texcoord[3].y, R4, R5;
DP3 result.texcoord[3].z, R2, R5;
DP3 result.texcoord[3].x, R3, R5;
DP3 result.texcoord[1].y, R1, R4;
DP3 result.texcoord[1].z, R2, R1;
DP3 result.texcoord[1].x, R1, R3;
MOV result.color.xyz, c[0].y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[32], c[32].zwzw;
MOV result.color.w, vertex.color;
END
# 105 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_Time]
Vector 17 [unity_Scale]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_WorldSpaceLightPos0]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [_Scale]
Vector 28 [_SquashPlaneNormal]
Float 29 [_SquashAmount]
Vector 30 [_Wind]
Vector 31 [_MainTex_ST]
"vs_2_0
; 110 ALU
def c32, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c33, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c34, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c35, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c5
mad r2, v2.x, c4, r0
mov r1.xyz, c11
dp3 r1.x, c32.y, r1
add r1.x, v5, r1
add r0.xyz, r2, c32.x
mad r2, v2.z, c6, r2
add r3, r2, c32.x
dp4 r3.w, r3, r3
abs r0.w, v1
add r0.w, -r0, c32.y
mad r0.xyz, r0, r0.w, v0
add r1.z, v5.y, r1.x
mul r0.xyz, r0, c27
mov r1.y, r1.x
dp3 r1.x, r0, r1.z
add r1.xy, r1, c16.y
mul r1, r1.xxyy, c33
frc r1, r1
mad r1, r1, c32.z, c32.w
frc r1, r1
mad r1, r1, c34.x, c34.y
abs r1, r1
mul r2, r1, r1
mad r1, -r1, c34.x, c34.z
mul r1, r2, r1
rsq r3.w, r3.w
add r5.xy, r1.xzzw, r1.ywzw
mad r2.xyz, r3.w, r3, -v2
mad r1.xyz, r0.w, r2, v2
mul r2.xyz, r5.y, c30
mul r3.xy, v5.y, r1.xzzw
mul r4.xyz, v4.y, r2
mul r3.xz, r3.xyyw, c35.x
mul r2, v1.y, c5
mul r3.y, v4, c34.w
mad r3.xyz, r5.xyxw, r3, r4
mad r0.xyz, r3, c30.w, r0
mad r3.xyz, v4.x, c30, r0
dp3 r0.x, r3, c28
mad r2, v1.x, c4, r2
mad r2, v1.z, c6, r2
add r2, r2, c32.x
dp4 r0.y, r2, r2
rsq r0.y, r0.y
mul r2.xyz, r0.y, r2
add r0.x, r0, c28.w
mul r0.xyz, r0.x, c28
add r4.xyz, -r0, r3
mov r2.w, c34.y
add r2, -v1, r2
mad r2, r0.w, r2, v1
dp3 r1.w, r2, r2
dp3 r0.w, r1, r1
rsq r1.w, r1.w
mul r3.xyz, r1.w, r2
rsq r0.w, r0.w
mul r2.xyz, r0.w, r1
mad r0.xyz, r0, c29.x, r4
mov r0.w, c32.y
mul r1.xyz, r2.zxyw, r3.yzxw
mad r4.xyz, r2.yzxw, r3.zxyw, -r1
mov r1.w, c32.y
mov r1.xyz, c18
dp4 r5.z, r1, c14
dp4 r5.y, r1, c13
dp4 r5.x, r1, c12
mad r1.xyz, r5, c17.w, -r0
mul r4.xyz, r4, r2.w
mul r5.xyz, r2, c17.w
dp3 r2.w, r5, c9
dp4 oPos.w, r0, c3
dp4 oPos.z, r0, c2
dp4 oPos.y, r0, c1
dp4 oPos.x, r0, c0
mov r0.y, r2.w
dp3 r0.x, r5, c8
dp3 r0.z, r5, c10
mov r0.w, c32.y
dp4 r5.z, r0, c22
dp4 r5.y, r0, c21
dp4 r5.x, r0, c20
dp3 oT3.y, r4, r1
dp3 oT3.z, r2, r1
dp3 oT3.x, r3, r1
mul r1, r0.xyzz, r0.yzzx
mul r2.w, r2, r2
dp4 r0.w, r1, c25
dp4 r0.z, r1, c24
dp4 r0.y, r1, c23
add r1.xyz, r5, r0.yzww
mad r0.x, r0, r0, -r2.w
mul r5.xyz, r0.x, c26
add oT2.xyz, r1, r5
mov r0, c14
dp4 r5.z, c19, r0
mov r1, c12
mov r0, c13
dp4 r5.x, c19, r1
dp4 r5.y, c19, r0
dp3 oT1.y, r5, r4
dp3 oT1.z, r2, r5
dp3 oT1.x, r5, r3
mov oD0.xyz, c32.y
mad oT0.xy, v3, c31, c31.zwzw
mov oD0.w, v5
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_Time]
Vector 18 [_ProjectionParams]
Vector 19 [unity_Scale]
Vector 20 [_WorldSpaceCameraPos]
Vector 21 [_WorldSpaceLightPos0]
Vector 22 [unity_SHAr]
Vector 23 [unity_SHAg]
Vector 24 [unity_SHAb]
Vector 25 [unity_SHBr]
Vector 26 [unity_SHBg]
Vector 27 [unity_SHBb]
Vector 28 [unity_SHC]
Vector 29 [_Scale]
Vector 30 [_SquashPlaneNormal]
Float 31 [_SquashAmount]
Vector 32 [_Wind]
Vector 33 [_MainTex_ST]
"!!ARBvp1.0
# 110 ALU
PARAM c[37] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..33],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1, -1 },
		{ 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MUL R0, vertex.normal.y, c[6];
MAD R3, vertex.normal.x, c[5], R0;
ADD R0.xyz, R3, c[0].x;
ABS R1.x, vertex.attrib[14].w;
ADD R2.w, -R1.x, c[0].y;
MAD R0.xyz, R0, R2.w, vertex.position;
MAD R3, vertex.normal.z, c[7], R3;
MOV R0.w, c[0].y;
DP3 R0.w, R0.w, c[12];
ADD R0.w, vertex.color.x, R0;
ADD R4, R3, c[0].x;
MUL R0.xyz, R0, c[29];
ADD R1.x, vertex.color.y, R0.w;
MOV R1.y, R0.w;
DP4 R0.w, R4, R4;
DP3 R1.x, R0, R1.x;
RSQ R0.w, R0.w;
MAD R2.xyz, R0.w, R4, -vertex.normal;
MAD R2.xyz, R2.w, R2, vertex.normal;
ADD R1.xy, R1, c[17].y;
MUL R1, R1.xxyy, c[34];
FRC R1, R1;
MAD R1, R1, c[0].z, c[0].w;
FRC R1, R1;
MAD R1, R1, c[0].z, -c[0].y;
ABS R1, R1;
MUL R3, -R1, c[0].z;
MOV R0.w, c[0].y;
ADD R3, R3, c[35].x;
MUL R1, R1, R1;
MUL R1, R1, R3;
ADD R4.xy, R1.xzzw, R1.ywzw;
MUL R1.xyz, R4.y, c[32];
MUL R3.xyz, vertex.texcoord[1].y, R1;
MUL R4.zw, vertex.color.y, R2.xyxz;
MUL R1.xz, R4.zyww, c[35].z;
MUL R1.y, vertex.texcoord[1], c[35];
MAD R1.xyz, R4.xyxw, R1, R3;
MAD R0.xyz, R1, c[32].w, R0;
MAD R1.xyz, vertex.texcoord[1].x, c[32], R0;
DP3 R0.x, R1, c[30];
ADD R0.x, R0, c[30].w;
MUL R0.xyz, R0.x, c[30];
ADD R1.xyz, -R0, R1;
MAD R0.xyz, R0, c[31].x, R1;
MUL R3, vertex.attrib[14].y, c[6];
MAD R3, vertex.attrib[14].x, c[5], R3;
MAD R3, vertex.attrib[14].z, c[7], R3;
ADD R3, R3, c[0].x;
DP4 R1.z, R3, R3;
RSQ R1.z, R1.z;
MUL R3.xyz, R1.z, R3;
MOV R3.w, c[35];
ADD R3, -vertex.attrib[14], R3;
DP4 R1.w, R0, c[4];
DP4 R1.z, R0, c[3];
DP4 R1.y, R0, c[2];
DP4 R1.x, R0, c[1];
MUL R4.xyz, R1.xyww, c[36].x;
MUL R4.y, R4, c[18].x;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, R2;
MAD R3, R2.w, R3, vertex.attrib[14];
MOV result.position, R1;
DP3 R1.x, R3, R3;
RSQ R1.x, R1.x;
MOV result.texcoord[4].zw, R1;
MUL R3.xyz, R1.x, R3;
ADD result.texcoord[4].xy, R4, R4.z;
MUL R4.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R4;
MOV R1.w, c[0].y;
MOV R1.xyz, c[20];
MOV R0.w, c[0].y;
DP4 R5.z, R1, c[15];
DP4 R5.x, R1, c[13];
DP4 R5.y, R1, c[14];
MAD R5.xyz, R5, c[19].w, -R0;
MUL R1.xyz, R2, c[19].w;
DP3 R2.w, R1, c[10];
MUL R4.xyz, R4, R3.w;
DP3 R0.x, R1, c[9];
DP3 R0.z, R1, c[11];
MOV R0.y, R2.w;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R6.z, R0, c[24];
DP4 R6.y, R0, c[23];
DP4 R6.x, R0, c[22];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[27];
DP4 R0.y, R1, c[26];
DP4 R0.x, R1, c[25];
MUL R1.xyz, R0.w, c[28];
ADD R0.xyz, R6, R0;
ADD result.texcoord[2].xyz, R0, R1;
MOV R0, c[21];
DP4 R1.z, R0, c[15];
DP4 R1.x, R0, c[13];
DP4 R1.y, R0, c[14];
DP3 result.texcoord[3].y, R4, R5;
DP3 result.texcoord[3].z, R2, R5;
DP3 result.texcoord[3].x, R3, R5;
DP3 result.texcoord[1].y, R1, R4;
DP3 result.texcoord[1].z, R2, R1;
DP3 result.texcoord[1].x, R1, R3;
MOV result.color.xyz, c[0].y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[33], c[33].zwzw;
MOV result.color.w, vertex.color;
END
# 110 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_Time]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_Scale]
Vector 20 [_WorldSpaceCameraPos]
Vector 21 [_WorldSpaceLightPos0]
Vector 22 [unity_SHAr]
Vector 23 [unity_SHAg]
Vector 24 [unity_SHAb]
Vector 25 [unity_SHBr]
Vector 26 [unity_SHBg]
Vector 27 [unity_SHBb]
Vector 28 [unity_SHC]
Vector 29 [_Scale]
Vector 30 [_SquashPlaneNormal]
Float 31 [_SquashAmount]
Vector 32 [_Wind]
Vector 33 [_MainTex_ST]
"vs_2_0
; 115 ALU
def c34, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c35, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c36, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c37, 0.10000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c5
mad r2, v2.x, c4, r0
add r0.xyz, r2, c34.x
abs r0.w, v1
add r4.w, -r0, c34.y
mov r1.xyz, c11
dp3 r0.w, c34.y, r1
add r0.w, v5.x, r0
mad r2, v2.z, c6, r2
mad r0.xyz, r0, r4.w, v0
add r3, r2, c34.x
mul r0.xyz, r0, c29
add r1.x, v5.y, r0.w
mov r1.y, r0.w
dp3 r1.x, r0, r1.x
dp4 r0.w, r3, r3
add r1.xy, r1, c16.y
mul r1, r1.xxyy, c35
frc r1, r1
mad r1, r1, c34.z, c34.w
frc r1, r1
mad r1, r1, c36.x, c36.y
abs r1, r1
mul r2, r1, r1
mad r1, -r1, c36.x, c36.z
mul r1, r2, r1
add r4.xy, r1.xzzw, r1.ywzw
rsq r0.w, r0.w
mad r2.xyz, r0.w, r3, -v2
mad r3.xyz, r4.w, r2, v2
mul r1.xyz, r4.y, c32
mul r2.xyz, v4.y, r1
mul r5.xy, v5.y, r3.xzzw
mov r0.w, c34.y
mul r1.xz, r5.xyyw, c37.x
mul r1.y, v4, c36.w
mad r1.xyz, r4.xyxw, r1, r2
mad r0.xyz, r1, c32.w, r0
mad r1.xyz, v4.x, c32, r0
dp3 r0.x, r1, c30
add r0.x, r0, c30.w
mul r0.xyz, r0.x, c30
add r1.xyz, -r0, r1
mad r0.xyz, r0, c31.x, r1
mul r1, v1.y, c5
mad r1, v1.x, c4, r1
mad r1, v1.z, c6, r1
add r1, r1, c34.x
dp4 r1.w, r1, r1
rsq r2.z, r1.w
mul r1.xyz, r2.z, r1
mov r1.w, c36.y
add r1, -v1, r1
dp4 r2.w, r0, c3
dp4 r2.z, r0, c2
mad r1, r4.w, r1, v1
dp4 r2.y, r0, c1
dp4 r2.x, r0, c0
mul r4.xyz, r2.xyww, c37.y
mov oPos, r2
mul r4.y, r4, c17.x
dp3 r2.x, r1, r1
dp3 r0.w, r3, r3
rsq r2.x, r2.x
rsq r0.w, r0.w
mul r3.xyz, r0.w, r3
mov oT4.zw, r2
mul r1.xyz, r2.x, r1
mad oT4.xy, r4.z, c18.zwzw, r4
mul r4.xyz, r3.zxyw, r1.yzxw
mad r4.xyz, r3.yzxw, r1.zxyw, -r4
mov r2.w, c34.y
mov r2.xyz, c20
dp4 r5.z, r2, c14
dp4 r5.x, r2, c12
dp4 r5.y, r2, c13
mad r0.xyz, r5, c19.w, -r0
mul r4.xyz, r4, r1.w
mul r2.xyz, r3, c19.w
mov r0.w, c34.y
dp3 oT3.y, r4, r0
dp3 oT3.z, r3, r0
dp3 oT3.x, r1, r0
dp3 r1.w, r2, c9
mov r0.y, r1.w
dp3 r0.x, r2, c8
dp3 r0.z, r2, c10
mul r2, r0.xyzz, r0.yzzx
dp4 r5.z, r0, c24
dp4 r5.y, r0, c23
dp4 r5.x, r0, c22
mul r1.w, r1, r1
dp4 r0.w, r2, c27
dp4 r0.z, r2, c26
dp4 r0.y, r2, c25
add r2.xyz, r5, r0.yzww
mad r0.x, r0, r0, -r1.w
mul r5.xyz, r0.x, c28
add oT2.xyz, r2, r5
mov r0, c14
dp4 r5.z, c21, r0
mov r2, c12
mov r0, c13
dp4 r5.x, c21, r2
dp4 r5.y, c21, r0
dp3 oT1.y, r5, r4
dp3 oT1.z, r3, r5
dp3 oT1.x, r5, r1
mov oD0.xyz, c34.y
mad oT0.xy, v3, c33, c33.zwzw
mov oD0.w, v5
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_Time]
Vector 18 [unity_Scale]
Vector 19 [_WorldSpaceCameraPos]
Vector 20 [_WorldSpaceLightPos0]
Vector 21 [unity_4LightPosX0]
Vector 22 [unity_4LightPosY0]
Vector 23 [unity_4LightPosZ0]
Vector 24 [unity_4LightAtten0]
Vector 25 [unity_LightColor0]
Vector 26 [unity_LightColor1]
Vector 27 [unity_LightColor2]
Vector 28 [unity_LightColor3]
Vector 29 [unity_SHAr]
Vector 30 [unity_SHAg]
Vector 31 [unity_SHAb]
Vector 32 [unity_SHBr]
Vector 33 [unity_SHBg]
Vector 34 [unity_SHBb]
Vector 35 [unity_SHC]
Vector 36 [_Scale]
Vector 37 [_SquashPlaneNormal]
Float 38 [_SquashAmount]
Vector 39 [_Wind]
Vector 40 [_MainTex_ST]
"!!ARBvp1.0
# 136 ALU
PARAM c[43] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..40],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1, -1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEMP R8;
MUL R0, vertex.normal.y, c[6];
MAD R2, vertex.normal.x, c[5], R0;
ADD R0.xyz, R2, c[0].x;
ABS R0.w, vertex.attrib[14];
ADD R6.w, -R0, c[0].y;
MOV R1.x, c[0].y;
DP3 R0.w, R1.x, c[12];
ADD R0.w, vertex.color.x, R0;
MAD R2, vertex.normal.z, c[7], R2;
MAD R0.xyz, R0, R6.w, vertex.position;
ADD R3, R2, c[0].x;
MOV R8.w, c[0].y;
MUL R0.xyz, R0, c[36];
ADD R1.x, vertex.color.y, R0.w;
MOV R1.y, R0.w;
DP4 R0.w, R3, R3;
DP3 R1.x, R0, R1.x;
ADD R1.xy, R1, c[17].y;
MUL R1, R1.xxyy, c[41];
FRC R1, R1;
MAD R1, R1, c[0].z, c[0].w;
FRC R1, R1;
MAD R1, R1, c[0].z, -c[0].y;
ABS R2, R1;
MUL R1, -R2, c[0].z;
MUL R2, R2, R2;
ADD R1, R1, c[42].x;
MUL R1, R2, R1;
RSQ R0.w, R0.w;
MAD R2.xyz, R0.w, R3, -vertex.normal;
MAD R5.xyz, R6.w, R2, vertex.normal;
ADD R3.xy, R1.xzzw, R1.ywzw;
MUL R1.xy, vertex.color.y, R5.xzzw;
MUL R2.xyz, R3.y, c[39];
MUL R1.xz, R1.xyyw, c[42].z;
MOV R2.w, c[0].y;
MUL R2.xyz, vertex.texcoord[1].y, R2;
MUL R1.y, vertex.texcoord[1], c[42];
MAD R1.xyz, R3.xyxw, R1, R2;
MAD R0.xyz, R1, c[39].w, R0;
MAD R0.xyz, vertex.texcoord[1].x, c[39], R0;
DP3 R0.w, R0, c[37];
ADD R0.w, R0, c[37];
MUL R1.xyz, R0.w, c[37];
ADD R0.xyz, -R1, R0;
MAD R2.xyz, R1, c[38].x, R0;
DP4 R0.y, R2, c[10];
DP4 R0.x, R2, c[9];
ADD R3, -R0.y, c[22];
ADD R1, -R0.x, c[21];
MUL R0, R3, R3;
MAD R4, R1, R1, R0;
DP3 R5.w, R5, R5;
RSQ R0.x, R5.w;
MUL R6.xyz, R0.x, R5;
MUL R7.xyz, R6, c[18].w;
DP3 R7.w, R7, c[10];
DP4 R0.y, R2, c[11];
ADD R0, -R0.y, c[23];
MAD R4, R0, R0, R4;
MUL R5, R4, c[24];
DP3 R8.x, R7, c[9];
MUL R3, R7.w, R3;
MAD R1, R8.x, R1, R3;
DP3 R3.w, R7, c[11];
MAD R0, R3.w, R0, R1;
MOV R8.z, R3.w;
MUL R3.w, R7, R7;
MOV R8.y, R7.w;
RSQ R1.x, R4.x;
RSQ R1.y, R4.y;
RSQ R1.z, R4.z;
RSQ R1.w, R4.w;
MUL R0, R0, R1;
ADD R1, R5, c[0].y;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].x;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[26];
MAD R1.xyz, R0.x, c[25], R1;
MAD R0.xyz, R0.z, c[27], R1;
MUL R1, R8.xyzz, R8.yzzx;
MAD R3.xyz, R0.w, c[28], R0;
MUL R0, vertex.attrib[14].y, c[6];
MAD R0, vertex.attrib[14].x, c[5], R0;
MAD R0, vertex.attrib[14].z, c[7], R0;
ADD R0, R0, c[0].x;
DP4 R0.w, R0, R0;
DP4 R5.z, R1, c[34];
DP4 R5.y, R1, c[33];
DP4 R5.x, R1, c[32];
RSQ R1.x, R0.w;
DP4 R4.z, R8, c[31];
DP4 R4.y, R8, c[30];
DP4 R4.x, R8, c[29];
MUL R0.xyz, R1.x, R0;
MOV R0.w, c[42];
ADD R0, -vertex.attrib[14], R0;
MAD R0, R6.w, R0, vertex.attrib[14];
DP3 R1.w, R0, R0;
RSQ R1.w, R1.w;
MUL R0.xyz, R1.w, R0;
ADD R1.xyz, R4, R5;
MAD R3.w, R8.x, R8.x, -R3;
MUL R4.xyz, R3.w, c[35];
ADD R4.xyz, R1, R4;
ADD result.texcoord[2].xyz, R4, R3;
MUL R1.xyz, R6.zxyw, R0.yzxw;
MAD R3.xyz, R6.yzxw, R0.zxyw, -R1;
MOV R1.xyz, c[19];
MOV R1.w, c[0].y;
MUL R3.xyz, R3, R0.w;
DP4 R4.z, R1, c[15];
DP4 R4.x, R1, c[13];
DP4 R4.y, R1, c[14];
MAD R1.xyz, R4, c[18].w, -R2;
DP3 result.texcoord[3].y, R3, R1;
DP3 result.texcoord[3].z, R6, R1;
DP3 result.texcoord[3].x, R0, R1;
DP4 result.position.w, R2, c[4];
DP4 result.position.z, R2, c[3];
DP4 result.position.y, R2, c[2];
DP4 result.position.x, R2, c[1];
MOV R2, c[20];
DP4 R1.z, R2, c[15];
DP4 R1.x, R2, c[13];
DP4 R1.y, R2, c[14];
DP3 result.texcoord[1].y, R1, R3;
DP3 result.texcoord[1].z, R6, R1;
DP3 result.texcoord[1].x, R1, R0;
MOV result.color.xyz, c[0].y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[40], c[40].zwzw;
MOV result.color.w, vertex.color;
END
# 136 instructions, 9 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_Time]
Vector 17 [unity_Scale]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_WorldSpaceLightPos0]
Vector 20 [unity_4LightPosX0]
Vector 21 [unity_4LightPosY0]
Vector 22 [unity_4LightPosZ0]
Vector 23 [unity_4LightAtten0]
Vector 24 [unity_LightColor0]
Vector 25 [unity_LightColor1]
Vector 26 [unity_LightColor2]
Vector 27 [unity_LightColor3]
Vector 28 [unity_SHAr]
Vector 29 [unity_SHAg]
Vector 30 [unity_SHAb]
Vector 31 [unity_SHBr]
Vector 32 [unity_SHBg]
Vector 33 [unity_SHBb]
Vector 34 [unity_SHC]
Vector 35 [_Scale]
Vector 36 [_SquashPlaneNormal]
Float 37 [_SquashAmount]
Vector 38 [_Wind]
Vector 39 [_MainTex_ST]
"vs_2_0
; 141 ALU
def c40, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c41, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c42, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c43, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c5
mad r1, v2.x, c4, r0
add r0.xyz, r1, c40.x
abs r0.w, v1
add r6.w, -r0, c40.y
mov r2.xyz, c11
dp3 r0.w, c40.y, r2
add r0.w, v5.x, r0
mad r1, v2.z, c6, r1
mad r0.xyz, r0, r6.w, v0
add r3, r1, c40.x
mov r8.w, c40.y
mul r0.xyz, r0, c35
add r2.x, v5.y, r0.w
mov r2.y, r0.w
dp4 r0.w, r3, r3
dp3 r2.x, r0, r2.x
add r2.xy, r2, c16.y
mul r2, r2.xxyy, c41
frc r2, r2
mad r2, r2, c40.z, c40.w
frc r2, r2
mad r2, r2, c42.x, c42.y
abs r2, r2
mul r1, r2, r2
mad r2, -r2, c42.x, c42.z
mul r1, r1, r2
rsq r0.w, r0.w
mad r2.xyz, r0.w, r3, -v2
mad r5.xyz, r6.w, r2, v2
add r3.xy, r1.xzzw, r1.ywzw
mul r1.xy, v5.y, r5.xzzw
mul r2.xyz, r3.y, c38
mul r1.xz, r1.xyyw, c43.x
mov r2.w, c40.y
mul r2.xyz, v4.y, r2
mul r1.y, v4, c42.w
mad r1.xyz, r3.xyxw, r1, r2
mad r0.xyz, r1, c38.w, r0
mad r0.xyz, v4.x, c38, r0
dp3 r0.w, r0, c36
add r0.w, r0, c36
mul r1.xyz, r0.w, c36
add r0.xyz, -r1, r0
mad r2.xyz, r1, c37.x, r0
dp4 r0.y, r2, c9
dp4 r0.x, r2, c8
add r3, -r0.y, c21
add r1, -r0.x, c20
mul r0, r3, r3
mad r4, r1, r1, r0
dp3 r5.w, r5, r5
rsq r0.x, r5.w
mul r6.xyz, r0.x, r5
mul r7.xyz, r6, c17.w
dp3 r7.w, r7, c9
dp4 r0.y, r2, c10
add r0, -r0.y, c22
mad r4, r0, r0, r4
mul r5, r4, c23
dp3 r8.x, r7, c8
mul r3, r7.w, r3
mad r1, r8.x, r1, r3
dp3 r3.w, r7, c10
mad r0, r3.w, r0, r1
mov r8.z, r3.w
mul r3.w, r7, r7
mov r8.y, r7.w
rsq r1.x, r4.x
rsq r1.y, r4.y
rsq r1.z, r4.z
rsq r1.w, r4.w
mul r0, r0, r1
add r1, r5, c40.y
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c40.x
mul r0, r0, r1
mul r1.xyz, r0.y, c25
mad r1.xyz, r0.x, c24, r1
mad r0.xyz, r0.z, c26, r1
mul r1, r8.xyzz, r8.yzzx
mad r3.xyz, r0.w, c27, r0
mul r0, v1.y, c5
mad r0, v1.x, c4, r0
mad r0, v1.z, c6, r0
add r0, r0, c40.x
dp4 r0.w, r0, r0
dp4 r5.z, r1, c33
dp4 r5.y, r1, c32
dp4 r5.x, r1, c31
rsq r1.x, r0.w
dp4 r4.z, r8, c30
dp4 r4.y, r8, c29
dp4 r4.x, r8, c28
mul r0.xyz, r1.x, r0
mov r0.w, c42.y
add r0, -v1, r0
mad r0, r6.w, r0, v1
dp3 r1.w, r0, r0
rsq r1.w, r1.w
mul r0.xyz, r1.w, r0
add r1.xyz, r4, r5
mad r3.w, r8.x, r8.x, -r3
mul r4.xyz, r3.w, c34
add r4.xyz, r1, r4
add oT2.xyz, r4, r3
mul r1.xyz, r6.zxyw, r0.yzxw
mad r3.xyz, r6.yzxw, r0.zxyw, -r1
mov r1.xyz, c18
mov r1.w, c40.y
dp4 r4.z, r1, c14
dp4 r4.x, r1, c12
dp4 r4.y, r1, c13
mad r4.xyz, r4, c17.w, -r2
mul r1.xyz, r3, r0.w
dp3 oT3.y, r1, r4
dp3 oT3.z, r6, r4
dp3 oT3.x, r0, r4
mov r3, c12
dp4 r4.x, c19, r3
dp4 oPos.w, r2, c3
dp4 oPos.z, r2, c2
dp4 oPos.y, r2, c1
dp4 oPos.x, r2, c0
mov r2, c14
dp4 r4.z, c19, r2
mov r2, c13
dp4 r4.y, c19, r2
dp3 oT1.y, r4, r1
dp3 oT1.z, r6, r4
dp3 oT1.x, r4, r0
mov oD0.xyz, c40.y
mad oT0.xy, v3, c39, c39.zwzw
mov oD0.w, v5
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_Time]
Vector 18 [_ProjectionParams]
Vector 19 [unity_Scale]
Vector 20 [_WorldSpaceCameraPos]
Vector 21 [_WorldSpaceLightPos0]
Vector 22 [unity_4LightPosX0]
Vector 23 [unity_4LightPosY0]
Vector 24 [unity_4LightPosZ0]
Vector 25 [unity_4LightAtten0]
Vector 26 [unity_LightColor0]
Vector 27 [unity_LightColor1]
Vector 28 [unity_LightColor2]
Vector 29 [unity_LightColor3]
Vector 30 [unity_SHAr]
Vector 31 [unity_SHAg]
Vector 32 [unity_SHAb]
Vector 33 [unity_SHBr]
Vector 34 [unity_SHBg]
Vector 35 [unity_SHBb]
Vector 36 [unity_SHC]
Vector 37 [_Scale]
Vector 38 [_SquashPlaneNormal]
Float 39 [_SquashAmount]
Vector 40 [_Wind]
Vector 41 [_MainTex_ST]
"!!ARBvp1.0
# 141 ALU
PARAM c[45] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..41],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1, -1 },
		{ 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEMP R8;
MUL R0, vertex.normal.y, c[6];
MAD R2, vertex.normal.x, c[5], R0;
ADD R0.xyz, R2, c[0].x;
ABS R0.w, vertex.attrib[14];
ADD R6.w, -R0, c[0].y;
MOV R1.x, c[0].y;
DP3 R0.w, R1.x, c[12];
MAD R0.xyz, R0, R6.w, vertex.position;
MAD R2, vertex.normal.z, c[7], R2;
ADD R3, R2, c[0].x;
DP4 R1.w, R3, R3;
MUL R1.xyz, R0, c[37];
ADD R0.w, vertex.color.x, R0;
ADD R0.x, vertex.color.y, R0.w;
MOV R8.w, c[0].y;
MOV R0.y, R0.w;
DP3 R0.x, R1, R0.x;
ADD R0.xy, R0, c[17].y;
MUL R0, R0.xxyy, c[42];
FRC R0, R0;
MAD R0, R0, c[0].z, c[0].w;
FRC R0, R0;
MAD R0, R0, c[0].z, -c[0].y;
ABS R2, R0;
MUL R0, -R2, c[0].z;
MUL R2, R2, R2;
ADD R0, R0, c[43].x;
MUL R0, R2, R0;
RSQ R1.w, R1.w;
MOV R2.w, c[0].y;
ADD R4.xy, R0.xzzw, R0.ywzw;
MAD R2.xyz, R1.w, R3, -vertex.normal;
MAD R0.xyz, R6.w, R2, vertex.normal;
MUL R2.xy, vertex.color.y, R0.xzzw;
MUL R3.xyz, R4.y, c[40];
MUL R2.xz, R2.xyyw, c[43].z;
MUL R3.xyz, vertex.texcoord[1].y, R3;
MUL R2.y, vertex.texcoord[1], c[43];
MAD R2.xyz, R4.xyxw, R2, R3;
MAD R1.xyz, R2, c[40].w, R1;
MAD R1.xyz, vertex.texcoord[1].x, c[40], R1;
DP3 R0.w, R1, c[38];
ADD R0.w, R0, c[38];
MUL R2.xyz, R0.w, c[38];
ADD R1.xyz, -R2, R1;
MAD R2.xyz, R2, c[39].x, R1;
DP4 R1.x, R2, c[10];
ADD R3, -R1.x, c[23];
DP4 R0.w, R2, c[9];
ADD R1, -R0.w, c[22];
MUL R4, R3, R3;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R6.xyz, R0.w, R0;
MUL R7.xyz, R6, c[19].w;
DP3 R7.w, R7, c[10];
DP4 R5.x, R2, c[11];
MUL R3, R7.w, R3;
DP3 R8.x, R7, c[9];
MAD R4, R1, R1, R4;
MAD R1, R8.x, R1, R3;
ADD R0, -R5.x, c[24];
MAD R4, R0, R0, R4;
DP3 R3.x, R7, c[11];
MAD R0, R3.x, R0, R1;
MUL R5, R4, c[25];
MOV R8.y, R7.w;
MOV R8.z, R3.x;
RSQ R1.x, R4.x;
RSQ R1.y, R4.y;
RSQ R1.z, R4.z;
RSQ R1.w, R4.w;
MUL R0, R0, R1;
ADD R1, R5, c[0].y;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].x;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[27];
MAD R1.xyz, R0.x, c[26], R1;
MAD R0.xyz, R0.z, c[28], R1;
MAD R1.xyz, R0.w, c[29], R0;
MUL R0, R8.xyzz, R8.yzzx;
MUL R1.w, R7, R7;
DP4 R4.z, R0, c[35];
DP4 R4.y, R0, c[34];
DP4 R4.x, R0, c[33];
MAD R1.w, R8.x, R8.x, -R1;
MUL R0.xyz, R1.w, c[36];
DP4 R1.w, R2, c[4];
DP4 R3.z, R8, c[32];
DP4 R3.y, R8, c[31];
DP4 R3.x, R8, c[30];
ADD R3.xyz, R3, R4;
ADD R3.xyz, R3, R0;
ADD result.texcoord[2].xyz, R3, R1;
MUL R0, vertex.attrib[14].y, c[6];
MAD R0, vertex.attrib[14].x, c[5], R0;
MAD R0, vertex.attrib[14].z, c[7], R0;
ADD R0, R0, c[0].x;
DP4 R0.w, R0, R0;
RSQ R1.z, R0.w;
DP4 R1.y, R2, c[2];
DP4 R1.x, R2, c[1];
MUL R3.xyz, R1.xyww, c[44].x;
MUL R3.y, R3, c[18].x;
MUL R0.xyz, R1.z, R0;
MOV R0.w, c[43];
ADD R0, -vertex.attrib[14], R0;
MAD R0, R6.w, R0, vertex.attrib[14];
DP3 R1.z, R0, R0;
ADD result.texcoord[4].xy, R3, R3.z;
RSQ R3.x, R1.z;
DP4 R1.z, R2, c[3];
MUL R0.xyz, R3.x, R0;
MUL R3.xyz, R6.zxyw, R0.yzxw;
MAD R3.xyz, R6.yzxw, R0.zxyw, -R3;
MOV result.position, R1;
MOV result.texcoord[4].zw, R1;
MOV R1.xyz, c[20];
MOV R1.w, c[0].y;
MUL R3.xyz, R3, R0.w;
DP4 R4.z, R1, c[15];
DP4 R4.x, R1, c[13];
DP4 R4.y, R1, c[14];
MAD R1.xyz, R4, c[19].w, -R2;
DP3 result.texcoord[3].y, R3, R1;
DP3 result.texcoord[3].z, R6, R1;
MOV R2, c[21];
DP3 result.texcoord[3].x, R0, R1;
DP4 R1.z, R2, c[15];
DP4 R1.x, R2, c[13];
DP4 R1.y, R2, c[14];
DP3 result.texcoord[1].y, R1, R3;
DP3 result.texcoord[1].z, R6, R1;
DP3 result.texcoord[1].x, R1, R0;
MOV result.color.xyz, c[0].y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[41], c[41].zwzw;
MOV result.color.w, vertex.color;
END
# 141 instructions, 9 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_Time]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_Scale]
Vector 20 [_WorldSpaceCameraPos]
Vector 21 [_WorldSpaceLightPos0]
Vector 22 [unity_4LightPosX0]
Vector 23 [unity_4LightPosY0]
Vector 24 [unity_4LightPosZ0]
Vector 25 [unity_4LightAtten0]
Vector 26 [unity_LightColor0]
Vector 27 [unity_LightColor1]
Vector 28 [unity_LightColor2]
Vector 29 [unity_LightColor3]
Vector 30 [unity_SHAr]
Vector 31 [unity_SHAg]
Vector 32 [unity_SHAb]
Vector 33 [unity_SHBr]
Vector 34 [unity_SHBg]
Vector 35 [unity_SHBb]
Vector 36 [unity_SHC]
Vector 37 [_Scale]
Vector 38 [_SquashPlaneNormal]
Float 39 [_SquashAmount]
Vector 40 [_Wind]
Vector 41 [_MainTex_ST]
"vs_2_0
; 146 ALU
def c42, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c43, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c44, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c45, 0.10000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
abs r1.w, v1
mul r0, v2.y, c5
mad r0, v2.x, c4, r0
add r1.xyz, r0, c42.x
add r6.w, -r1, c42.y
mov r2.xyz, c11
dp3 r1.w, c42.y, r2
add r1.w, v5.x, r1
mad r0, v2.z, c6, r0
mad r1.xyz, r1, r6.w, v0
add r3, r0, c42.x
mov r8.w, c42.y
mul r1.xyz, r1, c37
add r2.x, v5.y, r1.w
mov r2.y, r1.w
dp4 r1.w, r3, r3
dp3 r2.x, r1, r2.x
add r2.xy, r2, c16.y
mul r2, r2.xxyy, c43
frc r2, r2
mad r2, r2, c42.z, c42.w
frc r2, r2
mad r2, r2, c44.x, c44.y
abs r2, r2
mul r0, r2, r2
mad r2, -r2, c44.x, c44.z
mul r0, r0, r2
rsq r1.w, r1.w
mov r2.w, c42.y
add r4.xy, r0.xzzw, r0.ywzw
mad r2.xyz, r1.w, r3, -v2
mad r0.xyz, r6.w, r2, v2
mul r2.xy, v5.y, r0.xzzw
mul r3.xyz, r4.y, c40
mul r2.xz, r2.xyyw, c45.x
mul r3.xyz, v4.y, r3
mul r2.y, v4, c44.w
mad r2.xyz, r4.xyxw, r2, r3
mad r1.xyz, r2, c40.w, r1
mad r1.xyz, v4.x, c40, r1
dp3 r0.w, r1, c38
add r0.w, r0, c38
mul r2.xyz, r0.w, c38
add r1.xyz, -r2, r1
mad r2.xyz, r2, c39.x, r1
dp4 r1.x, r2, c9
add r3, -r1.x, c23
dp4 r0.w, r2, c8
add r1, -r0.w, c22
mul r4, r3, r3
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r6.xyz, r0.w, r0
mul r7.xyz, r6, c19.w
dp3 r7.w, r7, c9
dp4 r5.x, r2, c10
mul r3, r7.w, r3
dp3 r8.x, r7, c8
mad r4, r1, r1, r4
mad r1, r8.x, r1, r3
add r0, -r5.x, c24
mad r4, r0, r0, r4
dp3 r3.x, r7, c10
mad r0, r3.x, r0, r1
mul r5, r4, c25
mov r8.y, r7.w
mov r8.z, r3.x
rsq r1.x, r4.x
rsq r1.y, r4.y
rsq r1.z, r4.z
rsq r1.w, r4.w
mul r0, r0, r1
add r1, r5, c42.y
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c42.x
mul r0, r0, r1
mul r1.xyz, r0.y, c27
mad r1.xyz, r0.x, c26, r1
mad r0.xyz, r0.z, c28, r1
mad r1.xyz, r0.w, c29, r0
mul r0, r8.xyzz, r8.yzzx
mul r1.w, r7, r7
dp4 r4.z, r0, c35
dp4 r4.y, r0, c34
dp4 r4.x, r0, c33
mad r1.w, r8.x, r8.x, -r1
mul r0.xyz, r1.w, c36
dp4 r1.w, r2, c3
dp4 r3.z, r8, c32
dp4 r3.y, r8, c31
dp4 r3.x, r8, c30
add r3.xyz, r3, r4
add r3.xyz, r3, r0
add oT2.xyz, r3, r1
mul r0, v1.y, c5
mad r0, v1.x, c4, r0
mad r0, v1.z, c6, r0
add r0, r0, c42.x
dp4 r0.w, r0, r0
rsq r1.z, r0.w
dp4 r1.y, r2, c1
dp4 r1.x, r2, c0
mul r3.xyz, r1.xyww, c45.y
mul r3.y, r3, c17.x
mad oT4.xy, r3.z, c18.zwzw, r3
mul r0.xyz, r1.z, r0
mov r0.w, c44.y
add r0, -v1, r0
mad r0, r6.w, r0, v1
dp3 r1.z, r0, r0
rsq r3.x, r1.z
dp4 r1.z, r2, c2
mul r0.xyz, r3.x, r0
mul r3.xyz, r6.zxyw, r0.yzxw
mad r3.xyz, r6.yzxw, r0.zxyw, -r3
mov oPos, r1
mov oT4.zw, r1
mov r1.w, c42.y
mov r1.xyz, c20
dp4 r4.z, r1, c14
dp4 r4.x, r1, c12
dp4 r4.y, r1, c13
mad r1.xyz, r4, c19.w, -r2
mul r3.xyz, r3, r0.w
mov r2, c14
dp4 r4.z, c21, r2
mov r2, c12
dp4 r4.x, c21, r2
dp3 oT3.y, r3, r1
dp3 oT3.z, r6, r1
dp3 oT3.x, r0, r1
mov r1, c13
dp4 r4.y, c21, r1
dp3 oT1.y, r4, r3
dp3 oT1.z, r6, r4
dp3 oT1.x, r4, r0
mov oD0.xyz, c42.y
mad oT0.xy, v3, c41, c41.zwzw
mov oD0.w, v5
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 41 ALU, 3 TEX
PARAM c[7] = { program.local[0..4],
		{ 2, 1, 0.60009766, 0.39990234 },
		{ 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R4.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R1.zw, fragment.texcoord[0], texture[1], 2D;
SLT R1.x, R0.w, c[4];
DP3 R1.y, fragment.texcoord[3], fragment.texcoord[3];
RSQ R1.y, R1.y;
MUL R3.xyz, R1.y, fragment.texcoord[3];
MAD R2.xy, R4.wyzw, c[5].x, -c[5].y;
MUL R0.xyz, R0, c[1];
ADD R4.yzw, R3.xxyz, fragment.texcoord[1].xxyz;
MUL R0.xyz, R0, fragment.color.primary.w;
DP3_SAT R2.w, R3, -fragment.texcoord[1];
MUL R1.w, R1, c[1].x;
MOV result.color.w, R0;
KIL -R1.x;
MUL R1.x, R2.y, R2.y;
MAD R1.x, -R2, R2, -R1;
ADD R1.x, R1, c[5].y;
RSQ R1.y, R1.x;
DP3 R1.x, R4.yzww, R4.yzww;
RCP R2.z, R1.y;
RSQ R1.y, R1.x;
DP3 R1.x, fragment.texcoord[1], R2;
MUL R4.yzw, R1.y, R4;
MOV_SAT R1.y, -R1.x;
DP3 R2.x, R2, R4.yzww;
MAD R2.y, R1.x, c[5].z, c[5].w;
ADD R2.w, R2, -R1.y;
MAD R1.y, R2.w, c[3].x, R1;
MUL R1.y, R1, R1.z;
MAX R2.y, R2, c[6].x;
MUL R1.xyz, R1.y, c[2];
MAD R1.xyz, R1, c[5].x, R2.y;
MUL R1.xyz, R0, R1;
MAX R2.y, R2.x, c[6].x;
MUL R2.x, R4, c[6].y;
POW R2.x, R2.y, R2.x;
MUL R1.w, R2.x, R1;
MUL R0.xyz, R0, fragment.texcoord[2];
MAD R1.xyz, R1, c[0], R1.w;
MAD result.color.xyz, R1, c[5].x, R0;
END
# 41 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
"ps_2_0
; 44 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c5, 0.00000000, 1.00000000, 2.00000000, -1.00000000
def c6, 0.60009766, 0.39990234, 128.00000000, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r4, t0, s0
texld r7, t0, s2
add_pp r0.x, r4.w, -c4
cmp r0.x, r0, c5, c5.y
mov_pp r0, -r0.x
dp3_pp r1.x, t3, t3
rsq_pp r1.x, r1.x
mul_pp r3.xyz, r1.x, t3
add_pp r6.xyz, r3, t1
dp3_pp r1.x, r6, r6
rsq_pp r2.x, r1.x
mul_pp r6.xyz, r2.x, r6
dp3_pp_sat r2.x, r3, -t1
mul_pp r4.xyz, r4, c1
texkill r0.xyzw
texld r0, t0, s1
mov r0.y, r7
mov r0.x, r7.w
mad_pp r5.xy, r0, c5.z, c5.w
mul_pp r0.x, r5.y, r5.y
mad_pp r0.x, -r5, r5, -r0
add_pp r0.x, r0, c5.y
rsq_pp r0.x, r0.x
rcp_pp r5.z, r0.x
dp3_pp r0.x, t1, r5
mov_pp_sat r1.x, -r0
add_pp r3.x, r2, -r1
mad_pp r1.x, r3, c3, r1
mul_pp r1.x, r1, r0.z
mad_pp r0.x, r0, c6, c6.y
mul_pp r1.xyz, r1.x, c2
max_pp r0.x, r0, c5
mad_pp r3.xyz, r1, c5.z, r0.x
dp3_pp r2.x, r5, r6
max_pp r0.x, r2, c5
mul_pp r1.x, r7, c6.z
pow_pp r2.x, r0.x, r1.x
mul_pp r1.xyz, r4, v0.w
mul_pp r3.xyz, r1, r3
mul_pp r0.x, r0.w, c1
mul_pp r0.x, r2.x, r0
mul_pp r1.xyz, r1, t2
mad_pp r0.xyz, r3, c0, r0.x
mad_pp r0.xyz, r0, c5.z, r1
mov_pp r0.w, r4
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_ShadowStrength]
Float 5 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_ShadowMapTexture] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 45 ALU, 4 TEX
PARAM c[8] = { program.local[0..5],
		{ 2, 1, 0.60009766, 0.39990234 },
		{ 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TXP R2.x, fragment.texcoord[4], texture[3], 2D;
TEX R2.zw, fragment.texcoord[0], texture[1], 2D;
SLT R1.x, R0.w, c[5];
DP3 R1.z, fragment.texcoord[3], fragment.texcoord[3];
MUL R0.xyz, R0, c[1];
MUL R0.xyz, R0, fragment.color.primary.w;
RSQ R1.z, R1.z;
MAD R2.x, R2, c[6], -c[6];
MOV result.color.w, R0;
KIL -R1.x;
TEX R1.xyw, fragment.texcoord[0], texture[2], 2D;
MAD R4.xy, R1.wyzw, c[6].x, -c[6].y;
MUL R1.yzw, R1.z, fragment.texcoord[3].xxyz;
ADD R3.xyz, R1.yzww, fragment.texcoord[1];
DP3_SAT R1.y, R1.yzww, -fragment.texcoord[1];
DP3 R3.w, R3, R3;
MUL R2.y, R4, R4;
MAD R2.y, -R4.x, R4.x, -R2;
ADD R2.y, R2, c[6];
RSQ R2.y, R2.y;
RSQ R3.w, R3.w;
RCP R4.z, R2.y;
MUL R3.xyz, R3.w, R3;
DP3 R2.y, R4, R3;
MUL R3.x, R1, c[7].y;
MAX R2.y, R2, c[7].x;
DP3 R1.x, fragment.texcoord[1], R4;
POW R3.x, R2.y, R3.x;
MOV_SAT R2.y, -R1.x;
ADD R1.y, R1, -R2;
MAD R1.y, R1, c[3].x, R2;
MUL R1.z, R2.w, c[1].x;
MAD R2.y, R1.x, c[6].z, c[6].w;
MUL R1.w, R3.x, R1.z;
MUL R1.y, R1, R2.z;
MUL R1.xyz, R1.y, c[2];
MAX R2.y, R2, c[7].x;
MAD R1.xyz, R1, c[6].x, R2.y;
MUL R1.xyz, R0, R1;
MAD R1.xyz, R1, c[0], R1.w;
MOV R1.w, c[6].x;
MUL R0.xyz, R0, fragment.texcoord[2];
MAD R1.w, R2.x, c[4].x, R1;
MAD result.color.xyz, R1, R1.w, R0;
END
# 45 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_ShadowStrength]
Float 5 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_ShadowMapTexture] 2D
"ps_2_0
; 48 ALU, 5 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c6, 0.00000000, 1.00000000, 2.00000000, -1.00000000
def c7, 0.60009766, 0.39990234, 128.00000000, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4
texld r3, t0, s0
texldp r7, t4, s3
texld r6, t0, s2
add_pp r0.x, r3.w, -c5
cmp r0.x, r0, c6, c6.y
mov_pp r0, -r0.x
mov r1.x, r6.w
mov r1.y, r6
mad_pp r5.xy, r1, c6.z, c6.w
mul_pp r3.xyz, r3, c1
texkill r0.xyzw
texld r0, t0, s1
dp3_pp r0.x, t3, t3
rsq_pp r0.x, r0.x
mul_pp r4.xyz, r0.x, t3
add_pp r2.xyz, r4, t1
dp3_pp r1.x, r2, r2
mul_pp r0.x, r5.y, r5.y
mad_pp r0.x, -r5, r5, -r0
add_pp r0.x, r0, c6.y
rsq_pp r0.x, r0.x
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r2
rcp_pp r5.z, r0.x
dp3_pp r0.x, r5, r1
max_pp r1.x, r0, c6
dp3_pp r0.x, t1, r5
mul_pp r2.x, r6, c7.z
pow_pp r5.x, r1.x, r2.x
mov_pp_sat r1.x, -r0
dp3_pp_sat r2.x, r4, -t1
add_pp r2.x, r2, -r1
mad_pp r1.x, r2, c3, r1
mul_pp r1.x, r1, r0.z
mad_pp r0.x, r0, c7, c7.y
mul_pp r1.xyz, r1.x, c2
max_pp r0.x, r0, c6
mad_pp r2.xyz, r1, c6.z, r0.x
mul_pp r1.x, r0.w, c1
mov_pp r0.x, r5.x
mul_pp r0.x, r0, r1
mul_pp r1.xyz, r3, v0.w
mul_pp r2.xyz, r1, r2
mad_pp r2.xyz, r2, c0, r0.x
mov_pp r0.z, c6
mad_pp r0.x, r7, c6.z, -c6.z
mul_pp r1.xyz, r1, t2
mad_pp r0.x, r0, c4, r0.z
mad_pp r0.xyz, r2, r0.x, r1
mov_pp r0.w, r3
mov_pp oC0, r0
"
}
}
 }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardAdd" "IGNOREPROJECTOR"="True" "RenderType"="TreeLeaf" }
  AlphaToMask On
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend One One
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Matrix 17 [_LightMatrix0]
Vector 21 [_Time]
Vector 22 [unity_Scale]
Vector 23 [_WorldSpaceCameraPos]
Vector 24 [_WorldSpaceLightPos0]
Vector 25 [_Scale]
Vector 26 [_SquashPlaneNormal]
Float 27 [_SquashAmount]
Vector 28 [_Wind]
Vector 29 [_MainTex_ST]
"!!ARBvp1.0
# 95 ALU
PARAM c[32] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..29],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1, -1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MUL R0, vertex.normal.y, c[6];
MAD R2, vertex.normal.x, c[5], R0;
ADD R0.xyz, R2, c[0].x;
ABS R1.x, vertex.attrib[14].w;
ADD R4.x, -R1, c[0].y;
MAD R0.xyz, R0, R4.x, vertex.position;
MAD R2, vertex.normal.z, c[7], R2;
MOV R0.w, c[0].y;
DP3 R0.w, R0.w, c[12];
ADD R0.w, vertex.color.x, R0;
ADD R3, R2, c[0].x;
MUL R0.xyz, R0, c[25];
ADD R1.x, vertex.color.y, R0.w;
MOV R1.y, R0.w;
DP4 R0.w, R3, R3;
DP3 R1.x, R0, R1.x;
ADD R1.xy, R1, c[21].y;
MUL R1, R1.xxyy, c[30];
FRC R1, R1;
MAD R1, R1, c[0].z, c[0].w;
FRC R1, R1;
MAD R1, R1, c[0].z, -c[0].y;
ABS R1, R1;
MUL R2, -R1, c[0].z;
ADD R2, R2, c[31].x;
MUL R1, R1, R1;
MUL R1, R1, R2;
RSQ R0.w, R0.w;
ADD R4.zw, R1.xyxz, R1.xyyw;
MAD R2.xyz, R0.w, R3, -vertex.normal;
MAD R1.xyz, R4.x, R2, vertex.normal;
MUL R2.xyz, R4.w, c[28];
MUL R3.xyz, vertex.texcoord[1].y, R2;
MUL R5.xy, vertex.color.y, R1.xzzw;
MUL R2.xz, R5.xyyw, c[31].z;
MUL R2.y, vertex.texcoord[1], c[31];
MAD R2.xyz, R4.zwzw, R2, R3;
MAD R0.xyz, R2, c[28].w, R0;
MAD R0.xyz, vertex.texcoord[1].x, c[28], R0;
DP3 R0.w, R0, c[26];
ADD R0.w, R0, c[26];
MUL R2.xyz, R0.w, c[26];
ADD R0.xyz, -R2, R0;
MAD R0.xyz, R2, c[27].x, R0;
MOV R0.w, c[0].y;
MUL R2, vertex.attrib[14].y, c[6];
MAD R2, vertex.attrib[14].x, c[5], R2;
MAD R2, vertex.attrib[14].z, c[7], R2;
ADD R2, R2, c[0].x;
DP4 R1.w, R2, R2;
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, R2;
DP3 R1.w, R1, R1;
MOV R2.w, c[31];
ADD R2, -vertex.attrib[14], R2;
MAD R2, R4.x, R2, vertex.attrib[14];
DP4 R3.z, R0, c[11];
DP4 R3.y, R0, c[10];
DP4 R3.x, R0, c[9];
DP4 R3.w, R0, c[12];
DP4 result.texcoord[3].z, R3, c[19];
DP4 result.texcoord[3].y, R3, c[18];
DP4 result.texcoord[3].x, R3, c[17];
DP3 R3.x, R2, R2;
RSQ R3.x, R3.x;
MUL R3.xyz, R3.x, R2;
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, R1;
MUL R4.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R4;
MOV R1.w, c[0].y;
MOV R1.xyz, c[23];
DP4 R5.z, R1, c[15];
DP4 R5.x, R1, c[13];
DP4 R5.y, R1, c[14];
MOV R1, c[24];
MAD R5.xyz, R5, c[22].w, -R0;
MUL R4.xyz, R4, R2.w;
DP4 R6.z, R1, c[15];
DP4 R6.x, R1, c[13];
DP4 R6.y, R1, c[14];
MAD R1.xyz, R6, c[22].w, -R0;
DP3 result.texcoord[1].y, R1, R4;
DP3 result.texcoord[2].y, R4, R5;
DP4 result.position.w, R0, c[4];
DP4 result.position.z, R0, c[3];
DP4 result.position.y, R0, c[2];
DP4 result.position.x, R0, c[1];
DP3 result.texcoord[1].z, R2, R1;
DP3 result.texcoord[1].x, R1, R3;
DP3 result.texcoord[2].z, R2, R5;
DP3 result.texcoord[2].x, R3, R5;
MOV result.color.xyz, c[0].y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[29], c[29].zwzw;
MOV result.color.w, vertex.color;
END
# 95 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Matrix 16 [_LightMatrix0]
Vector 20 [_Time]
Vector 21 [unity_Scale]
Vector 22 [_WorldSpaceCameraPos]
Vector 23 [_WorldSpaceLightPos0]
Vector 24 [_Scale]
Vector 25 [_SquashPlaneNormal]
Float 26 [_SquashAmount]
Vector 27 [_Wind]
Vector 28 [_MainTex_ST]
"vs_2_0
; 100 ALU
def c29, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c30, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c31, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c32, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c5
mad r2, v2.x, c4, r0
add r0.xyz, r2, c29.x
abs r0.w, v1
add r4.x, -r0.w, c29.y
mov r1.xyz, c11
dp3 r0.w, c29.y, r1
mad r0.xyz, r0, r4.x, v0
mad r2, v2.z, c6, r2
add r3, r2, c29.x
dp4 r1.w, r3, r3
mul r1.xyz, r0, c24
add r0.w, v5.x, r0
add r0.x, v5.y, r0.w
mov r0.y, r0.w
dp3 r0.x, r1, r0.x
add r0.xy, r0, c20.y
mul r0, r0.xxyy, c30
frc r0, r0
mad r0, r0, c29.z, c29.w
frc r0, r0
mad r0, r0, c31.x, c31.y
abs r0, r0
mul r2, r0, r0
mad r0, -r0, c31.x, c31.z
mul r0, r2, r0
rsq r1.w, r1.w
mad r2.xyz, r1.w, r3, -v2
add r4.zw, r0.xyxz, r0.xyyw
mad r0.xyz, r4.x, r2, v2
mul r2.xyz, r4.w, c27
mul r3.xyz, v4.y, r2
mul r5.xy, v5.y, r0.xzzw
mov r1.w, c29.y
mul r2.xz, r5.xyyw, c32.x
mul r2.y, v4, c31.w
mad r2.xyz, r4.zwzw, r2, r3
mad r1.xyz, r2, c27.w, r1
mad r2.xyz, v4.x, c27, r1
dp3 r0.w, r2, c25
add r0.w, r0, c25
mul r1.xyz, r0.w, c25
add r2.xyz, -r1, r2
mad r1.xyz, r1, c26.x, r2
mul r2, v1.y, c5
mad r2, v1.x, c4, r2
mad r2, v1.z, c6, r2
add r2, r2, c29.x
dp4 r0.w, r2, r2
rsq r0.w, r0.w
mul r2.xyz, r0.w, r2
dp3 r0.w, r0, r0
mov r2.w, c31.y
add r2, -v1, r2
mad r2, r4.x, r2, v1
dp4 r3.z, r1, c10
dp4 r3.y, r1, c9
dp4 r3.x, r1, c8
dp4 r3.w, r1, c11
dp4 oT3.z, r3, c18
dp4 oT3.y, r3, c17
dp4 oT3.x, r3, c16
dp3 r3.x, r2, r2
rsq r3.x, r3.x
mul r4.xyz, r3.x, r2
rsq r0.w, r0.w
mul r3.xyz, r0.w, r0
mul r2.xyz, r3.zxyw, r4.yzxw
mov r0.w, c29.y
mov r0.xyz, c22
dp4 r5.z, r0, c14
dp4 r5.x, r0, c12
dp4 r5.y, r0, c13
mad r6.xyz, r5, c21.w, -r1
mad r2.xyz, r3.yzxw, r4.zxyw, -r2
mul r5.xyz, r2, r2.w
mov r0, c14
dp4 r7.z, c23, r0
mov r0, c13
mov r2, c12
dp4 r7.x, c23, r2
dp4 r7.y, c23, r0
mad r0.xyz, r7, c21.w, -r1
dp3 oT1.y, r0, r5
dp3 oT2.y, r5, r6
dp4 oPos.w, r1, c3
dp4 oPos.z, r1, c2
dp4 oPos.y, r1, c1
dp4 oPos.x, r1, c0
dp3 oT1.z, r3, r0
dp3 oT1.x, r0, r4
dp3 oT2.z, r3, r6
dp3 oT2.x, r4, r6
mov oD0.xyz, c29.y
mad oT0.xy, v3, c28, c28.zwzw
mov oD0.w, v5
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_Time]
Vector 18 [unity_Scale]
Vector 19 [_WorldSpaceCameraPos]
Vector 20 [_WorldSpaceLightPos0]
Vector 21 [_Scale]
Vector 22 [_SquashPlaneNormal]
Float 23 [_SquashAmount]
Vector 24 [_Wind]
Vector 25 [_MainTex_ST]
"!!ARBvp1.0
# 87 ALU
PARAM c[28] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..25],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1, -1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MUL R0, vertex.normal.y, c[6];
MAD R2, vertex.normal.x, c[5], R0;
ADD R0.xyz, R2, c[0].x;
MAD R2, vertex.normal.z, c[7], R2;
ADD R3, R2, c[0].x;
DP4 R3.w, R3, R3;
ABS R0.w, vertex.attrib[14];
ADD R0.w, -R0, c[0].y;
MAD R0.xyz, R0, R0.w, vertex.position;
MOV R1.x, c[0].y;
DP3 R1.x, R1.x, c[12];
ADD R1.x, vertex.color, R1;
ADD R1.z, vertex.color.y, R1.x;
MUL R0.xyz, R0, c[21];
MOV R1.y, R1.x;
DP3 R1.x, R0, R1.z;
ADD R1.xy, R1, c[17].y;
MUL R1, R1.xxyy, c[26];
FRC R1, R1;
MAD R1, R1, c[0].z, c[0].w;
FRC R1, R1;
MAD R1, R1, c[0].z, -c[0].y;
ABS R1, R1;
MUL R2, -R1, c[0].z;
RSQ R3.w, R3.w;
ADD R2, R2, c[27].x;
MUL R1, R1, R1;
MUL R1, R1, R2;
MAD R2.xyz, R3.w, R3, -vertex.normal;
MAD R3.xyz, R0.w, R2, vertex.normal;
ADD R5.xy, R1.xzzw, R1.ywzw;
MUL R1.xyz, R5.y, c[24];
MUL R2.xy, vertex.color.y, R3.xzzw;
MUL R4.xyz, vertex.texcoord[1].y, R1;
MUL R2.xz, R2.xyyw, c[27].z;
MUL R1, vertex.attrib[14].y, c[6];
MUL R2.y, vertex.texcoord[1], c[27];
MAD R2.xyz, R5.xyxw, R2, R4;
MAD R0.xyz, R2, c[24].w, R0;
MAD R2.xyz, vertex.texcoord[1].x, c[24], R0;
DP3 R0.x, R2, c[22];
MAD R1, vertex.attrib[14].x, c[5], R1;
MAD R1, vertex.attrib[14].z, c[7], R1;
ADD R1, R1, c[0].x;
DP4 R0.y, R1, R1;
RSQ R0.y, R0.y;
MOV R3.w, c[0].y;
MUL R1.xyz, R0.y, R1;
ADD R0.x, R0, c[22].w;
MUL R0.xyz, R0.x, c[22];
ADD R4.xyz, -R0, R2;
MOV R1.w, c[27];
ADD R1, -vertex.attrib[14], R1;
MAD R1, R0.w, R1, vertex.attrib[14];
DP3 R2.x, R1, R1;
DP3 R0.w, R3, R3;
RSQ R2.x, R2.x;
MAD R0.xyz, R0, c[23].x, R4;
MUL R2.xyz, R2.x, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, R3;
MOV R0.w, c[0].y;
MUL R3.xyz, R1.zxyw, R2.yzxw;
MAD R5.xyz, R1.yzxw, R2.zxyw, -R3;
MOV R3.xyz, c[19];
DP4 R4.z, R3, c[15];
DP4 R4.y, R3, c[14];
DP4 R4.x, R3, c[13];
MAD R4.xyz, R4, c[18].w, -R0;
MUL R3.xyz, R5, R1.w;
DP3 result.texcoord[2].y, R3, R4;
DP3 result.texcoord[2].z, R1, R4;
DP3 result.texcoord[2].x, R2, R4;
DP4 result.position.w, R0, c[4];
DP4 result.position.z, R0, c[3];
DP4 result.position.y, R0, c[2];
DP4 result.position.x, R0, c[1];
MOV R0, c[20];
DP4 R4.z, R0, c[15];
DP4 R4.x, R0, c[13];
DP4 R4.y, R0, c[14];
DP3 result.texcoord[1].y, R4, R3;
DP3 result.texcoord[1].z, R1, R4;
DP3 result.texcoord[1].x, R4, R2;
MOV result.color.xyz, c[0].y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[25], c[25].zwzw;
MOV result.color.w, vertex.color;
END
# 87 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_Time]
Vector 17 [unity_Scale]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_WorldSpaceLightPos0]
Vector 20 [_Scale]
Vector 21 [_SquashPlaneNormal]
Float 22 [_SquashAmount]
Vector 23 [_Wind]
Vector 24 [_MainTex_ST]
"vs_2_0
; 92 ALU
def c25, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c26, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c27, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c28, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c5
mad r2, v2.x, c4, r0
mov r1.xyz, c11
dp3 r1.x, c25.y, r1
add r1.x, v5, r1
add r0.xyz, r2, c25.x
mad r2, v2.z, c6, r2
add r3, r2, c25.x
dp4 r3.w, r3, r3
abs r0.w, v1
add r0.w, -r0, c25.y
mad r0.xyz, r0, r0.w, v0
add r1.z, v5.y, r1.x
mul r0.xyz, r0, c20
mov r1.y, r1.x
dp3 r1.x, r0, r1.z
add r1.xy, r1, c16.y
mul r1, r1.xxyy, c26
frc r1, r1
mad r1, r1, c25.z, c25.w
frc r1, r1
mad r1, r1, c27.x, c27.y
abs r1, r1
mul r2, r1, r1
mad r1, -r1, c27.x, c27.z
mul r1, r2, r1
rsq r3.w, r3.w
add r5.xy, r1.xzzw, r1.ywzw
mad r2.xyz, r3.w, r3, -v2
mad r1.xyz, r0.w, r2, v2
mul r2.xyz, r5.y, c23
mul r3.xy, v5.y, r1.xzzw
mul r4.xyz, v4.y, r2
mul r3.xz, r3.xyyw, c28.x
mul r2, v1.y, c5
mul r3.y, v4, c27.w
mad r3.xyz, r5.xyxw, r3, r4
mad r0.xyz, r3, c23.w, r0
mad r3.xyz, v4.x, c23, r0
dp3 r0.x, r3, c21
mad r2, v1.x, c4, r2
mad r2, v1.z, c6, r2
add r2, r2, c25.x
dp4 r0.y, r2, r2
rsq r0.y, r0.y
mul r2.xyz, r0.y, r2
add r0.x, r0, c21.w
mul r0.xyz, r0.x, c21
add r4.xyz, -r0, r3
mov r2.w, c27.y
add r2, -v1, r2
mad r2, r0.w, r2, v1
dp3 r1.w, r2, r2
dp3 r0.w, r1, r1
rsq r1.w, r1.w
mul r3.xyz, r1.w, r2
rsq r0.w, r0.w
mul r2.xyz, r0.w, r1
mad r0.xyz, r0, c22.x, r4
mov r0.w, c25.y
mul r1.xyz, r2.zxyw, r3.yzxw
mad r4.xyz, r2.yzxw, r3.zxyw, -r1
mov r1.w, c25.y
mov r1.xyz, c18
dp4 r5.z, r1, c14
dp4 r5.y, r1, c13
dp4 r5.x, r1, c12
mad r1.xyz, r5, c17.w, -r0
mul r4.xyz, r4, r2.w
dp3 oT2.y, r4, r1
dp4 oPos.w, r0, c3
dp4 oPos.z, r0, c2
dp4 oPos.y, r0, c1
dp4 oPos.x, r0, c0
mov r0, c14
dp4 r5.z, c19, r0
mov r0, c13
dp4 r5.y, c19, r0
dp3 oT2.z, r2, r1
dp3 oT2.x, r3, r1
mov r1, c12
dp4 r5.x, c19, r1
dp3 oT1.y, r5, r4
dp3 oT1.z, r2, r5
dp3 oT1.x, r5, r3
mov oD0.xyz, c25.y
mad oT0.xy, v3, c24, c24.zwzw
mov oD0.w, v5
"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Matrix 17 [_LightMatrix0]
Vector 21 [_Time]
Vector 22 [unity_Scale]
Vector 23 [_WorldSpaceCameraPos]
Vector 24 [_WorldSpaceLightPos0]
Vector 25 [_Scale]
Vector 26 [_SquashPlaneNormal]
Float 27 [_SquashAmount]
Vector 28 [_Wind]
Vector 29 [_MainTex_ST]
"!!ARBvp1.0
# 96 ALU
PARAM c[32] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..29],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1, -1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MUL R0, vertex.normal.y, c[6];
MAD R2, vertex.normal.x, c[5], R0;
ADD R0.xyz, R2, c[0].x;
ABS R1.x, vertex.attrib[14].w;
ADD R4.x, -R1, c[0].y;
MAD R0.xyz, R0, R4.x, vertex.position;
MAD R2, vertex.normal.z, c[7], R2;
MOV R0.w, c[0].y;
DP3 R0.w, R0.w, c[12];
ADD R0.w, vertex.color.x, R0;
ADD R3, R2, c[0].x;
MUL R0.xyz, R0, c[25];
ADD R1.x, vertex.color.y, R0.w;
MOV R1.y, R0.w;
DP4 R0.w, R3, R3;
DP3 R1.x, R0, R1.x;
ADD R1.xy, R1, c[21].y;
MUL R1, R1.xxyy, c[30];
FRC R1, R1;
MAD R1, R1, c[0].z, c[0].w;
FRC R1, R1;
MAD R1, R1, c[0].z, -c[0].y;
ABS R1, R1;
MUL R2, -R1, c[0].z;
ADD R2, R2, c[31].x;
MUL R1, R1, R1;
MUL R1, R1, R2;
RSQ R0.w, R0.w;
MAD R2.xyz, R0.w, R3, -vertex.normal;
ADD R4.zw, R1.xyxz, R1.xyyw;
MAD R1.xyz, R4.x, R2, vertex.normal;
MUL R2.xyz, R4.w, c[28];
MUL R3.xyz, vertex.texcoord[1].y, R2;
MUL R5.xy, vertex.color.y, R1.xzzw;
MOV R0.w, c[0].y;
MUL R2.xz, R5.xyyw, c[31].z;
MUL R2.y, vertex.texcoord[1], c[31];
MAD R2.xyz, R4.zwzw, R2, R3;
MAD R0.xyz, R2, c[28].w, R0;
MAD R2.xyz, vertex.texcoord[1].x, c[28], R0;
DP3 R0.x, R2, c[26];
ADD R0.x, R0, c[26].w;
MUL R0.xyz, R0.x, c[26];
ADD R2.xyz, -R0, R2;
MAD R0.xyz, R0, c[27].x, R2;
MUL R2, vertex.attrib[14].y, c[6];
MAD R2, vertex.attrib[14].x, c[5], R2;
MAD R2, vertex.attrib[14].z, c[7], R2;
ADD R2, R2, c[0].x;
DP4 R1.w, R2, R2;
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, R2;
DP3 R1.w, R1, R1;
MOV R2.w, c[31];
ADD R2, -vertex.attrib[14], R2;
MAD R2, R4.x, R2, vertex.attrib[14];
DP4 R3.z, R0, c[11];
DP4 R3.y, R0, c[10];
DP4 R3.x, R0, c[9];
DP4 R3.w, R0, c[12];
DP4 result.texcoord[3].w, R3, c[20];
DP4 result.texcoord[3].z, R3, c[19];
DP4 result.texcoord[3].y, R3, c[18];
DP4 result.texcoord[3].x, R3, c[17];
DP3 R3.x, R2, R2;
RSQ R3.x, R3.x;
MUL R3.xyz, R3.x, R2;
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, R1;
MUL R4.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R4;
MOV R1.w, c[0].y;
MOV R1.xyz, c[23];
DP4 R5.z, R1, c[15];
DP4 R5.x, R1, c[13];
DP4 R5.y, R1, c[14];
MOV R1, c[24];
MAD R5.xyz, R5, c[22].w, -R0;
MUL R4.xyz, R4, R2.w;
DP4 R6.z, R1, c[15];
DP4 R6.x, R1, c[13];
DP4 R6.y, R1, c[14];
MAD R1.xyz, R6, c[22].w, -R0;
DP3 result.texcoord[1].y, R1, R4;
DP3 result.texcoord[2].y, R4, R5;
DP4 result.position.w, R0, c[4];
DP4 result.position.z, R0, c[3];
DP4 result.position.y, R0, c[2];
DP4 result.position.x, R0, c[1];
DP3 result.texcoord[1].z, R2, R1;
DP3 result.texcoord[1].x, R1, R3;
DP3 result.texcoord[2].z, R2, R5;
DP3 result.texcoord[2].x, R3, R5;
MOV result.color.xyz, c[0].y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[29], c[29].zwzw;
MOV result.color.w, vertex.color;
END
# 96 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Matrix 16 [_LightMatrix0]
Vector 20 [_Time]
Vector 21 [unity_Scale]
Vector 22 [_WorldSpaceCameraPos]
Vector 23 [_WorldSpaceLightPos0]
Vector 24 [_Scale]
Vector 25 [_SquashPlaneNormal]
Float 26 [_SquashAmount]
Vector 27 [_Wind]
Vector 28 [_MainTex_ST]
"vs_2_0
; 101 ALU
def c29, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c30, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c31, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c32, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c5
mad r2, v2.x, c4, r0
add r0.xyz, r2, c29.x
abs r0.w, v1
add r4.x, -r0.w, c29.y
mov r1.xyz, c11
dp3 r0.w, c29.y, r1
mad r0.xyz, r0, r4.x, v0
mad r2, v2.z, c6, r2
add r3, r2, c29.x
dp4 r1.w, r3, r3
mul r1.xyz, r0, c24
add r0.w, v5.x, r0
add r0.x, v5.y, r0.w
mov r0.y, r0.w
dp3 r0.x, r1, r0.x
add r0.xy, r0, c20.y
mul r0, r0.xxyy, c30
frc r0, r0
mad r0, r0, c29.z, c29.w
frc r0, r0
mad r0, r0, c31.x, c31.y
abs r0, r0
mul r2, r0, r0
mad r0, -r0, c31.x, c31.z
mul r0, r2, r0
rsq r1.w, r1.w
mad r2.xyz, r1.w, r3, -v2
add r4.zw, r0.xyxz, r0.xyyw
mad r0.xyz, r4.x, r2, v2
mul r2.xyz, r4.w, c27
mul r3.xyz, v4.y, r2
mul r5.xy, v5.y, r0.xzzw
mov r1.w, c29.y
mul r2.xz, r5.xyyw, c32.x
mul r2.y, v4, c31.w
mad r2.xyz, r4.zwzw, r2, r3
mad r1.xyz, r2, c27.w, r1
mad r2.xyz, v4.x, c27, r1
dp3 r0.w, r2, c25
add r0.w, r0, c25
mul r1.xyz, r0.w, c25
add r2.xyz, -r1, r2
mad r1.xyz, r1, c26.x, r2
mul r2, v1.y, c5
mad r2, v1.x, c4, r2
mad r2, v1.z, c6, r2
add r2, r2, c29.x
dp4 r0.w, r2, r2
rsq r0.w, r0.w
mul r2.xyz, r0.w, r2
dp3 r0.w, r0, r0
mov r2.w, c31.y
add r2, -v1, r2
mad r2, r4.x, r2, v1
dp4 r3.z, r1, c10
dp4 r3.y, r1, c9
dp4 r3.x, r1, c8
dp4 r3.w, r1, c11
dp4 oT3.w, r3, c19
dp4 oT3.z, r3, c18
dp4 oT3.y, r3, c17
dp4 oT3.x, r3, c16
dp3 r3.x, r2, r2
rsq r3.x, r3.x
mul r4.xyz, r3.x, r2
rsq r0.w, r0.w
mul r3.xyz, r0.w, r0
mul r2.xyz, r3.zxyw, r4.yzxw
mov r0.w, c29.y
mov r0.xyz, c22
dp4 r5.z, r0, c14
dp4 r5.x, r0, c12
dp4 r5.y, r0, c13
mad r6.xyz, r5, c21.w, -r1
mad r2.xyz, r3.yzxw, r4.zxyw, -r2
mul r5.xyz, r2, r2.w
mov r0, c14
dp4 r7.z, c23, r0
mov r0, c13
mov r2, c12
dp4 r7.x, c23, r2
dp4 r7.y, c23, r0
mad r0.xyz, r7, c21.w, -r1
dp3 oT1.y, r0, r5
dp3 oT2.y, r5, r6
dp4 oPos.w, r1, c3
dp4 oPos.z, r1, c2
dp4 oPos.y, r1, c1
dp4 oPos.x, r1, c0
dp3 oT1.z, r3, r0
dp3 oT1.x, r0, r4
dp3 oT2.z, r3, r6
dp3 oT2.x, r4, r6
mov oD0.xyz, c29.y
mad oT0.xy, v3, c28, c28.zwzw
mov oD0.w, v5
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Matrix 17 [_LightMatrix0]
Vector 21 [_Time]
Vector 22 [unity_Scale]
Vector 23 [_WorldSpaceCameraPos]
Vector 24 [_WorldSpaceLightPos0]
Vector 25 [_Scale]
Vector 26 [_SquashPlaneNormal]
Float 27 [_SquashAmount]
Vector 28 [_Wind]
Vector 29 [_MainTex_ST]
"!!ARBvp1.0
# 95 ALU
PARAM c[32] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..29],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1, -1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MUL R0, vertex.normal.y, c[6];
MAD R2, vertex.normal.x, c[5], R0;
ADD R0.xyz, R2, c[0].x;
ABS R1.x, vertex.attrib[14].w;
ADD R4.x, -R1, c[0].y;
MAD R0.xyz, R0, R4.x, vertex.position;
MAD R2, vertex.normal.z, c[7], R2;
MOV R0.w, c[0].y;
DP3 R0.w, R0.w, c[12];
ADD R0.w, vertex.color.x, R0;
ADD R3, R2, c[0].x;
MUL R0.xyz, R0, c[25];
ADD R1.x, vertex.color.y, R0.w;
MOV R1.y, R0.w;
DP4 R0.w, R3, R3;
DP3 R1.x, R0, R1.x;
ADD R1.xy, R1, c[21].y;
MUL R1, R1.xxyy, c[30];
FRC R1, R1;
MAD R1, R1, c[0].z, c[0].w;
FRC R1, R1;
MAD R1, R1, c[0].z, -c[0].y;
ABS R1, R1;
MUL R2, -R1, c[0].z;
ADD R2, R2, c[31].x;
MUL R1, R1, R1;
MUL R1, R1, R2;
RSQ R0.w, R0.w;
ADD R4.zw, R1.xyxz, R1.xyyw;
MAD R2.xyz, R0.w, R3, -vertex.normal;
MAD R1.xyz, R4.x, R2, vertex.normal;
MUL R2.xyz, R4.w, c[28];
MUL R3.xyz, vertex.texcoord[1].y, R2;
MUL R5.xy, vertex.color.y, R1.xzzw;
MUL R2.xz, R5.xyyw, c[31].z;
MUL R2.y, vertex.texcoord[1], c[31];
MAD R2.xyz, R4.zwzw, R2, R3;
MAD R0.xyz, R2, c[28].w, R0;
MAD R0.xyz, vertex.texcoord[1].x, c[28], R0;
DP3 R0.w, R0, c[26];
ADD R0.w, R0, c[26];
MUL R2.xyz, R0.w, c[26];
ADD R0.xyz, -R2, R0;
MAD R0.xyz, R2, c[27].x, R0;
MOV R0.w, c[0].y;
MUL R2, vertex.attrib[14].y, c[6];
MAD R2, vertex.attrib[14].x, c[5], R2;
MAD R2, vertex.attrib[14].z, c[7], R2;
ADD R2, R2, c[0].x;
DP4 R1.w, R2, R2;
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, R2;
DP3 R1.w, R1, R1;
MOV R2.w, c[31];
ADD R2, -vertex.attrib[14], R2;
MAD R2, R4.x, R2, vertex.attrib[14];
DP4 R3.z, R0, c[11];
DP4 R3.y, R0, c[10];
DP4 R3.x, R0, c[9];
DP4 R3.w, R0, c[12];
DP4 result.texcoord[3].z, R3, c[19];
DP4 result.texcoord[3].y, R3, c[18];
DP4 result.texcoord[3].x, R3, c[17];
DP3 R3.x, R2, R2;
RSQ R3.x, R3.x;
MUL R3.xyz, R3.x, R2;
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, R1;
MUL R4.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R4;
MOV R1.w, c[0].y;
MOV R1.xyz, c[23];
DP4 R5.z, R1, c[15];
DP4 R5.x, R1, c[13];
DP4 R5.y, R1, c[14];
MOV R1, c[24];
MAD R5.xyz, R5, c[22].w, -R0;
MUL R4.xyz, R4, R2.w;
DP4 R6.z, R1, c[15];
DP4 R6.x, R1, c[13];
DP4 R6.y, R1, c[14];
MAD R1.xyz, R6, c[22].w, -R0;
DP3 result.texcoord[1].y, R1, R4;
DP3 result.texcoord[2].y, R4, R5;
DP4 result.position.w, R0, c[4];
DP4 result.position.z, R0, c[3];
DP4 result.position.y, R0, c[2];
DP4 result.position.x, R0, c[1];
DP3 result.texcoord[1].z, R2, R1;
DP3 result.texcoord[1].x, R1, R3;
DP3 result.texcoord[2].z, R2, R5;
DP3 result.texcoord[2].x, R3, R5;
MOV result.color.xyz, c[0].y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[29], c[29].zwzw;
MOV result.color.w, vertex.color;
END
# 95 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Matrix 16 [_LightMatrix0]
Vector 20 [_Time]
Vector 21 [unity_Scale]
Vector 22 [_WorldSpaceCameraPos]
Vector 23 [_WorldSpaceLightPos0]
Vector 24 [_Scale]
Vector 25 [_SquashPlaneNormal]
Float 26 [_SquashAmount]
Vector 27 [_Wind]
Vector 28 [_MainTex_ST]
"vs_2_0
; 100 ALU
def c29, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c30, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c31, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c32, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c5
mad r2, v2.x, c4, r0
add r0.xyz, r2, c29.x
abs r0.w, v1
add r4.x, -r0.w, c29.y
mov r1.xyz, c11
dp3 r0.w, c29.y, r1
mad r0.xyz, r0, r4.x, v0
mad r2, v2.z, c6, r2
add r3, r2, c29.x
dp4 r1.w, r3, r3
mul r1.xyz, r0, c24
add r0.w, v5.x, r0
add r0.x, v5.y, r0.w
mov r0.y, r0.w
dp3 r0.x, r1, r0.x
add r0.xy, r0, c20.y
mul r0, r0.xxyy, c30
frc r0, r0
mad r0, r0, c29.z, c29.w
frc r0, r0
mad r0, r0, c31.x, c31.y
abs r0, r0
mul r2, r0, r0
mad r0, -r0, c31.x, c31.z
mul r0, r2, r0
rsq r1.w, r1.w
mad r2.xyz, r1.w, r3, -v2
add r4.zw, r0.xyxz, r0.xyyw
mad r0.xyz, r4.x, r2, v2
mul r2.xyz, r4.w, c27
mul r3.xyz, v4.y, r2
mul r5.xy, v5.y, r0.xzzw
mov r1.w, c29.y
mul r2.xz, r5.xyyw, c32.x
mul r2.y, v4, c31.w
mad r2.xyz, r4.zwzw, r2, r3
mad r1.xyz, r2, c27.w, r1
mad r2.xyz, v4.x, c27, r1
dp3 r0.w, r2, c25
add r0.w, r0, c25
mul r1.xyz, r0.w, c25
add r2.xyz, -r1, r2
mad r1.xyz, r1, c26.x, r2
mul r2, v1.y, c5
mad r2, v1.x, c4, r2
mad r2, v1.z, c6, r2
add r2, r2, c29.x
dp4 r0.w, r2, r2
rsq r0.w, r0.w
mul r2.xyz, r0.w, r2
dp3 r0.w, r0, r0
mov r2.w, c31.y
add r2, -v1, r2
mad r2, r4.x, r2, v1
dp4 r3.z, r1, c10
dp4 r3.y, r1, c9
dp4 r3.x, r1, c8
dp4 r3.w, r1, c11
dp4 oT3.z, r3, c18
dp4 oT3.y, r3, c17
dp4 oT3.x, r3, c16
dp3 r3.x, r2, r2
rsq r3.x, r3.x
mul r4.xyz, r3.x, r2
rsq r0.w, r0.w
mul r3.xyz, r0.w, r0
mul r2.xyz, r3.zxyw, r4.yzxw
mov r0.w, c29.y
mov r0.xyz, c22
dp4 r5.z, r0, c14
dp4 r5.x, r0, c12
dp4 r5.y, r0, c13
mad r6.xyz, r5, c21.w, -r1
mad r2.xyz, r3.yzxw, r4.zxyw, -r2
mul r5.xyz, r2, r2.w
mov r0, c14
dp4 r7.z, c23, r0
mov r0, c13
mov r2, c12
dp4 r7.x, c23, r2
dp4 r7.y, c23, r0
mad r0.xyz, r7, c21.w, -r1
dp3 oT1.y, r0, r5
dp3 oT2.y, r5, r6
dp4 oPos.w, r1, c3
dp4 oPos.z, r1, c2
dp4 oPos.y, r1, c1
dp4 oPos.x, r1, c0
dp3 oT1.z, r3, r0
dp3 oT1.x, r0, r4
dp3 oT2.z, r3, r6
dp3 oT2.x, r4, r6
mov oD0.xyz, c29.y
mad oT0.xy, v3, c28, c28.zwzw
mov oD0.w, v5
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Matrix 17 [_LightMatrix0]
Vector 21 [_Time]
Vector 22 [unity_Scale]
Vector 23 [_WorldSpaceCameraPos]
Vector 24 [_WorldSpaceLightPos0]
Vector 25 [_Scale]
Vector 26 [_SquashPlaneNormal]
Float 27 [_SquashAmount]
Vector 28 [_Wind]
Vector 29 [_MainTex_ST]
"!!ARBvp1.0
# 93 ALU
PARAM c[32] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..29],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1, -1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MUL R0, vertex.normal.y, c[6];
MAD R2, vertex.normal.x, c[5], R0;
ADD R0.xyz, R2, c[0].x;
ABS R1.x, vertex.attrib[14].w;
ADD R4.w, -R1.x, c[0].y;
MAD R2, vertex.normal.z, c[7], R2;
MOV R0.w, c[0].y;
DP3 R0.w, R0.w, c[12];
ADD R0.w, vertex.color.x, R0;
MAD R0.xyz, R0, R4.w, vertex.position;
ADD R3, R2, c[0].x;
MUL R0.xyz, R0, c[25];
ADD R1.x, vertex.color.y, R0.w;
MOV R1.y, R0.w;
DP4 R0.w, R3, R3;
DP3 R1.x, R0, R1.x;
ADD R1.xy, R1, c[21].y;
MUL R1, R1.xxyy, c[30];
FRC R1, R1;
MAD R1, R1, c[0].z, c[0].w;
FRC R1, R1;
MAD R1, R1, c[0].z, -c[0].y;
ABS R1, R1;
MUL R2, -R1, c[0].z;
ADD R2, R2, c[31].x;
MUL R1, R1, R1;
MUL R1, R1, R2;
RSQ R0.w, R0.w;
MAD R2.xyz, R0.w, R3, -vertex.normal;
ADD R3.xy, R1.xzzw, R1.ywzw;
MAD R4.xyz, R4.w, R2, vertex.normal;
MUL R1.xyz, R3.y, c[28];
MUL R2.xyz, vertex.texcoord[1].y, R1;
MUL R3.zw, vertex.color.y, R4.xyxz;
MOV R1.w, c[0].y;
MUL R1.xz, R3.zyww, c[31].z;
MUL R1.y, vertex.texcoord[1], c[31];
MAD R1.xyz, R3.xyxw, R1, R2;
DP3 R3.x, R4, R4;
MAD R0.xyz, R1, c[28].w, R0;
MAD R0.xyz, vertex.texcoord[1].x, c[28], R0;
DP3 R0.w, R0, c[26];
ADD R0.w, R0, c[26];
MUL R1.xyz, R0.w, c[26];
ADD R2.xyz, -R1, R0;
MAD R1.xyz, R1, c[27].x, R2;
MUL R0, vertex.attrib[14].y, c[6];
MAD R0, vertex.attrib[14].x, c[5], R0;
MAD R2, vertex.attrib[14].z, c[7], R0;
ADD R2, R2, c[0].x;
DP4 R0.x, R2, R2;
RSQ R0.x, R0.x;
MUL R2.xyz, R0.x, R2;
MOV R2.w, c[31];
ADD R2, -vertex.attrib[14], R2;
MAD R2, R4.w, R2, vertex.attrib[14];
DP3 R3.y, R2, R2;
DP4 R0.w, R1, c[12];
DP4 R0.z, R1, c[11];
DP4 R0.y, R1, c[10];
DP4 R0.x, R1, c[9];
DP4 result.texcoord[3].y, R0, c[18];
DP4 result.texcoord[3].x, R0, c[17];
MOV R0.xyz, c[23];
MOV R0.w, c[0].y;
RSQ R3.w, R3.x;
RSQ R3.y, R3.y;
MUL R3.xyz, R3.y, R2;
MUL R2.xyz, R3.w, R4;
MUL R4.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R4;
MUL R4.xyz, R4, R2.w;
DP4 R5.z, R0, c[15];
DP4 R5.x, R0, c[13];
DP4 R5.y, R0, c[14];
MAD R0.xyz, R5, c[22].w, -R1;
DP3 result.texcoord[2].y, R4, R0;
DP3 result.texcoord[2].z, R2, R0;
DP3 result.texcoord[2].x, R3, R0;
DP4 result.position.w, R1, c[4];
DP4 result.position.z, R1, c[3];
DP4 result.position.y, R1, c[2];
DP4 result.position.x, R1, c[1];
MOV R1, c[24];
DP4 R0.z, R1, c[15];
DP4 R0.x, R1, c[13];
DP4 R0.y, R1, c[14];
DP3 result.texcoord[1].y, R0, R4;
DP3 result.texcoord[1].z, R2, R0;
DP3 result.texcoord[1].x, R0, R3;
MOV result.color.xyz, c[0].y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[29], c[29].zwzw;
MOV result.color.w, vertex.color;
END
# 93 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Matrix 16 [_LightMatrix0]
Vector 20 [_Time]
Vector 21 [unity_Scale]
Vector 22 [_WorldSpaceCameraPos]
Vector 23 [_WorldSpaceLightPos0]
Vector 24 [_Scale]
Vector 25 [_SquashPlaneNormal]
Float 26 [_SquashAmount]
Vector 27 [_Wind]
Vector 28 [_MainTex_ST]
"vs_2_0
; 98 ALU
def c29, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c30, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c31, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c32, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c5
mad r2, v2.x, c4, r0
add r0.xyz, r2, c29.x
abs r0.w, v1
add r4.w, -r0, c29.y
mov r1.xyz, c11
dp3 r0.w, c29.y, r1
add r0.w, v5.x, r0
mad r2, v2.z, c6, r2
mad r0.xyz, r0, r4.w, v0
add r3, r2, c29.x
mul r0.xyz, r0, c24
add r1.x, v5.y, r0.w
mov r1.y, r0.w
dp4 r0.w, r3, r3
dp3 r1.x, r0, r1.x
add r1.xy, r1, c20.y
mul r1, r1.xxyy, c30
frc r1, r1
mad r1, r1, c29.z, c29.w
frc r1, r1
mad r1, r1, c31.x, c31.y
abs r1, r1
mul r2, r1, r1
mad r1, -r1, c31.x, c31.z
mul r1, r2, r1
rsq r0.w, r0.w
mad r2.xyz, r0.w, r3, -v2
add r3.xy, r1.xzzw, r1.ywzw
mad r4.xyz, r4.w, r2, v2
mul r1.xyz, r3.y, c27
mul r2.xyz, v4.y, r1
mul r3.zw, v5.y, r4.xyxz
mov r0.w, c29.y
mul r1.xz, r3.zyww, c32.x
mul r1.y, v4, c31.w
mad r1.xyz, r3.xyxw, r1, r2
mad r0.xyz, r1, c27.w, r0
mad r1.xyz, v4.x, c27, r0
dp3 r3.x, r4, r4
dp3 r0.x, r1, c25
add r0.x, r0, c25.w
mul r0.xyz, r0.x, c25
add r2.xyz, -r0, r1
mad r0.xyz, r0, c26.x, r2
mul r1, v1.y, c5
mad r1, v1.x, c4, r1
mad r2, v1.z, c6, r1
add r2, r2, c29.x
dp4 r1.x, r2, r2
rsq r1.x, r1.x
mul r2.xyz, r1.x, r2
mov r2.w, c31.y
add r2, -v1, r2
mad r2, r4.w, r2, v1
dp3 r3.y, r2, r2
dp4 r1.w, r0, c11
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
dp4 oT3.y, r1, c17
dp4 oT3.x, r1, c16
mov r1.w, c29.y
mov r1.xyz, c22
dp4 r5.z, r1, c14
dp4 r5.x, r1, c12
dp4 r5.y, r1, c13
mad r1.xyz, r5, c21.w, -r0
rsq r3.w, r3.x
rsq r3.y, r3.y
mul r3.xyz, r3.y, r2
mul r2.xyz, r3.w, r4
mul r4.xyz, r2.zxyw, r3.yzxw
mad r4.xyz, r2.yzxw, r3.zxyw, -r4
mul r4.xyz, r4, r2.w
dp3 oT2.y, r4, r1
dp4 oPos.w, r0, c3
dp4 oPos.z, r0, c2
dp4 oPos.y, r0, c1
dp4 oPos.x, r0, c0
mov r0, c14
dp4 r5.z, c23, r0
mov r0, c13
dp4 r5.y, c23, r0
dp3 oT2.z, r2, r1
dp3 oT2.x, r3, r1
mov r1, c12
dp4 r5.x, c23, r1
dp3 oT1.y, r5, r4
dp3 oT1.z, r2, r5
dp3 oT1.x, r5, r3
mov oD0.xyz, c29.y
mad oT0.xy, v3, c28, c28.zwzw
mov oD0.w, v5
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 46 ALU, 4 TEX
PARAM c[7] = { program.local[0..4],
		{ 2, 1, 0.60009766, 0.39990234 },
		{ 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R5.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R1.zw, fragment.texcoord[0], texture[1], 2D;
SLT R1.x, R0.w, c[4];
DP3 R1.y, fragment.texcoord[3], fragment.texcoord[3];
DP3 R2.z, fragment.texcoord[2], fragment.texcoord[2];
MUL R0.xyz, R0, c[1];
MAD R2.xy, R5.wyzw, c[5].x, -c[5].y;
RSQ R2.z, R2.z;
MUL R5.yzw, R2.z, fragment.texcoord[2].xxyz;
MUL R1.w, R1, c[1].x;
MUL R0.xyz, R0, fragment.color.primary.w;
MOV result.color.w, R0;
TEX R2.w, R1.y, texture[3], 2D;
KIL -R1.x;
MUL R1.x, R2.y, R2.y;
MAD R1.x, -R2, R2, -R1;
ADD R1.x, R1, c[5].y;
RSQ R1.x, R1.x;
DP3 R1.y, fragment.texcoord[1], fragment.texcoord[1];
RSQ R1.y, R1.y;
MUL R4.xyz, R1.y, fragment.texcoord[1];
ADD R3.xyz, R5.yzww, R4;
RCP R2.z, R1.x;
DP3 R1.x, R4, R2;
DP3 R1.y, R3, R3;
RSQ R3.w, R1.y;
MOV_SAT R1.y, -R1.x;
MUL R3.xyz, R3.w, R3;
DP3 R2.y, R2, R3;
MAD R1.x, R1, c[5].z, c[5].w;
DP3_SAT R4.x, R5.yzww, -R4;
ADD R4.x, R4, -R1.y;
MAD R1.y, R4.x, c[3].x, R1;
MAX R3.w, R1.x, c[6].x;
MUL R1.y, R1, R1.z;
MUL R1.xyz, R1.y, c[2];
MAD R1.xyz, R1, c[5].x, R3.w;
MUL R2.x, R5, c[6].y;
MAX R2.y, R2, c[6].x;
POW R2.x, R2.y, R2.x;
MUL R1.w, R2.x, R1;
MUL R0.xyz, R0, R1;
MAD R0.xyz, R0, c[0], R1.w;
MUL R0.xyz, R2.w, R0;
MUL result.color.xyz, R0, c[5].x;
END
# 46 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
"ps_2_0
; 50 ALU, 5 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c5, 0.00000000, 1.00000000, 2.00000000, -1.00000000
def c6, 0.60009766, 0.39990234, 128.00000000, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t0, s0
texld r8, t0, s2
add_pp r0.x, r2.w, -c4
cmp r1.x, r0, c5, c5.y
mov_pp r1, -r1.x
dp3 r0.x, t3, t3
mov r0.xy, r0.x
dp3_pp r3.x, t1, t1
rsq_pp r3.x, r3.x
mul_pp r2.xyz, r2, c1
mul_pp r4.xyz, r3.x, t1
mul_pp r2.xyz, r2, v0.w
texld r7, r0, s3
texld r0, t0, s1
texkill r1.xyzw
dp3_pp r1.x, t2, t2
rsq_pp r1.x, r1.x
mul_pp r3.xyz, r1.x, t2
add_pp r6.xyz, r3, r4
dp3_pp r1.x, r6, r6
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r6
mov r0.y, r8
mov r0.x, r8.w
mad_pp r5.xy, r0, c5.z, c5.w
mul_pp r0.x, r5.y, r5.y
mad_pp r0.x, -r5, r5, -r0
add_pp r0.x, r0, c5.y
rsq_pp r0.x, r0.x
rcp_pp r5.z, r0.x
dp3_pp r1.x, r5, r1
mul_pp r0.x, r8, c6.z
max_pp r1.x, r1, c5
pow_pp r6.x, r1.x, r0.x
dp3_pp r1.x, r4, r5
dp3_pp_sat r4.x, r3, -r4
mov_pp_sat r3.x, -r1
mov_pp r0.x, r6.x
mul_pp r5.x, r0.w, c1
add_pp r4.x, r4, -r3
mad_pp r3.x, r4, c3, r3
mul_pp r3.x, r3, r0.z
mad_pp r1.x, r1, c6, c6.y
mul_pp r0.x, r0, r5
mul_pp r3.xyz, r3.x, c2
max_pp r1.x, r1, c5
mad_pp r1.xyz, r3, c5.z, r1.x
mul_pp r1.xyz, r2, r1
mad_pp r0.xyz, r1, c0, r0.x
mul_pp r0.xyz, r7.x, r0
mul_pp r0.xyz, r0, c5.z
mov_pp r0.w, r2
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 40 ALU, 3 TEX
PARAM c[7] = { program.local[0..4],
		{ 2, 1, 0.60009766, 0.39990234 },
		{ 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R2.zw, fragment.texcoord[0], texture[1], 2D;
SLT R1.x, R0.w, c[4];
DP3 R1.z, fragment.texcoord[2], fragment.texcoord[2];
MUL R0.xyz, R0, c[1];
RSQ R1.z, R1.z;
MUL R0.xyz, R0, fragment.color.primary.w;
MOV result.color.w, R0;
KIL -R1.x;
TEX R1.xyw, fragment.texcoord[0], texture[2], 2D;
MAD R4.xy, R1.wyzw, c[5].x, -c[5].y;
MUL R1.yzw, R1.z, fragment.texcoord[2].xxyz;
ADD R3.xyz, R1.yzww, fragment.texcoord[1];
DP3 R2.y, R3, R3;
RSQ R2.y, R2.y;
MUL R2.x, R4.y, R4.y;
MAD R2.x, -R4, R4, -R2;
ADD R2.x, R2, c[5].y;
RSQ R2.x, R2.x;
MUL R3.xyz, R2.y, R3;
RCP R4.z, R2.x;
DP3 R2.x, R4, R3;
MAX R2.y, R2.x, c[6].x;
MUL R1.x, R1, c[6].y;
POW R3.x, R2.y, R1.x;
DP3_SAT R1.x, R1.yzww, -fragment.texcoord[1];
DP3 R2.x, fragment.texcoord[1], R4;
MOV_SAT R2.y, -R2.x;
MUL R1.y, R2.w, c[1].x;
ADD R1.x, R1, -R2.y;
MAD R1.x, R1, c[3], R2.y;
MAD R2.x, R2, c[5].z, c[5].w;
MUL R1.w, R3.x, R1.y;
MUL R1.x, R1, R2.z;
MUL R1.xyz, R1.x, c[2];
MAX R2.x, R2, c[6];
MAD R1.xyz, R1, c[5].x, R2.x;
MUL R0.xyz, R0, R1;
MAD R0.xyz, R0, c[0], R1.w;
MUL result.color.xyz, R0, c[5].x;
END
# 40 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
"ps_2_0
; 44 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c5, 0.00000000, 1.00000000, 2.00000000, -1.00000000
def c6, 0.60009766, 0.39990234, 128.00000000, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
texld r3, t0, s0
texld r6, t0, s2
add_pp r0.x, r3.w, -c4
cmp r0.x, r0, c5, c5.y
mov_pp r0, -r0.x
mov r1.x, r6.w
mov r1.y, r6
mad_pp r5.xy, r1, c5.z, c5.w
mul_pp r3.xyz, r3, c1
texkill r0.xyzw
texld r0, t0, s1
dp3_pp r0.x, t2, t2
rsq_pp r0.x, r0.x
mul_pp r4.xyz, r0.x, t2
add_pp r2.xyz, r4, t1
dp3_pp r1.x, r2, r2
mul_pp r0.x, r5.y, r5.y
mad_pp r0.x, -r5, r5, -r0
add_pp r0.x, r0, c5.y
rsq_pp r0.x, r0.x
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r2
rcp_pp r5.z, r0.x
dp3_pp r0.x, r5, r1
max_pp r1.x, r0, c5
dp3_pp r0.x, t1, r5
mul_pp r2.x, r6, c6.z
pow_pp r5.x, r1.x, r2.x
mov_pp_sat r1.x, -r0
dp3_pp_sat r2.x, r4, -t1
add_pp r2.x, r2, -r1
mad_pp r1.x, r2, c3, r1
mul_pp r1.x, r1, r0.z
mad_pp r0.x, r0, c6, c6.y
mul_pp r1.xyz, r1.x, c2
max_pp r0.x, r0, c5
mad_pp r2.xyz, r1, c5.z, r0.x
mul_pp r1.x, r0.w, c1
mov_pp r0.x, r5.x
mul_pp r0.x, r0, r1
mul_pp r1.xyz, r3, v0.w
mul_pp r1.xyz, r1, r2
mad_pp r0.xyz, r1, c0, r0.x
mul_pp r0.xyz, r0, c5.z
mov_pp r0.w, r3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
SetTexture 4 [_LightTextureB0] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 52 ALU, 5 TEX
PARAM c[7] = { program.local[0..4],
		{ 0, 0.5, 2, 1 },
		{ 0.60009766, 0.39990234, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2, fragment.texcoord[0], texture[0], 2D;
TEX R4.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R3.zw, fragment.texcoord[0], texture[1], 2D;
RCP R0.y, fragment.texcoord[3].w;
MAD R0.zw, fragment.texcoord[3].xyxy, R0.y, c[5].y;
SLT R0.x, R2.w, c[4];
DP3 R1.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R1.x, R1.x;
DP3 R1.y, fragment.texcoord[2], fragment.texcoord[2];
MUL R5.xyz, R1.x, fragment.texcoord[1];
DP3 R0.y, fragment.texcoord[3], fragment.texcoord[3];
RSQ R1.y, R1.y;
MOV result.color.w, R2;
TEX R1.w, R0.zwzw, texture[3], 2D;
TEX R0.w, R0.y, texture[4], 2D;
KIL -R0.x;
MAD R0.xy, R4.wyzw, c[5].z, -c[5].w;
MUL R4.yzw, R1.y, fragment.texcoord[2].xxyz;
ADD R1.xyz, R4.yzww, R5;
DP3 R3.y, R1, R1;
MUL R0.z, R0.y, R0.y;
MAD R0.z, -R0.x, R0.x, -R0;
ADD R0.z, R0, c[5].w;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
DP3 R3.x, R5, R0;
RSQ R5.w, R3.y;
DP3_SAT R4.y, R4.yzww, -R5;
MUL R5.xyz, R5.w, R1;
DP3 R0.y, R0, R5;
MOV_SAT R3.y, -R3.x;
MAD R1.x, R3, c[6], c[6].y;
ADD R4.y, R4, -R3;
MAD R1.y, R4, c[3].x, R3;
MAX R3.x, R1, c[5];
MUL R1.y, R1, R3.z;
MUL R1.xyz, R1.y, c[2];
MAD R1.xyz, R1, c[5].z, R3.x;
MUL R0.x, R4, c[6].z;
MAX R0.y, R0, c[5].x;
POW R3.y, R0.y, R0.x;
MUL R0.xyz, R2, c[1];
MUL R3.x, R3.w, c[1];
MUL R0.xyz, R0, fragment.color.primary.w;
MUL R0.xyz, R0, R1;
MUL R2.x, R3.y, R3;
SLT R1.x, c[5], fragment.texcoord[3].z;
MUL R1.x, R1, R1.w;
MAD R0.xyz, R0, c[0], R2.x;
MUL R0.w, R1.x, R0;
MUL R0.xyz, R0.w, R0;
MUL result.color.xyz, R0, c[5].z;
END
# 52 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
SetTexture 4 [_LightTextureB0] 2D
"ps_2_0
; 55 ALU, 6 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c5, 0.00000000, 1.00000000, 0.50000000, 2.00000000
def c6, 2.00000000, -1.00000000, 0.60009766, 0.39990234
def c7, 128.00000000, 0, 0, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3
texld r2, t0, s0
texld r8, t0, s2
dp3 r1.x, t3, t3
mov r4.xy, r1.x
add_pp r0.x, r2.w, -c4
cmp r0.x, r0, c5, c5.y
mov_pp r3, -r0.x
rcp r0.x, t3.w
mad r0.xy, t3, r0.x, c5.z
mul_pp r2.xyz, r2, c1
mul_pp r2.xyz, r2, v0.w
texld r1, r0, s3
texld r0, t0, s1
texkill r3.xyzw
texld r7, r4, s4
dp3_pp r3.x, t1, t1
rsq_pp r3.x, r3.x
dp3_pp r1.x, t2, t2
mul_pp r4.xyz, r3.x, t1
rsq_pp r1.x, r1.x
mul_pp r3.xyz, r1.x, t2
add_pp r6.xyz, r3, r4
dp3_pp r1.x, r6, r6
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r6
mov r0.y, r8
mov r0.x, r8.w
mad_pp r5.xy, r0, c6.x, c6.y
mul_pp r0.x, r5.y, r5.y
mad_pp r0.x, -r5, r5, -r0
add_pp r0.x, r0, c5.y
rsq_pp r0.x, r0.x
rcp_pp r5.z, r0.x
dp3_pp r1.x, r5, r1
mul_pp r0.x, r8, c7
max_pp r1.x, r1, c5
pow_pp r6.x, r1.x, r0.x
dp3_pp r1.x, r4, r5
dp3_pp_sat r4.x, r3, -r4
mov_pp_sat r3.x, -r1
mov_pp r0.x, r6.x
mul_pp r5.x, r0.w, c1
add_pp r4.x, r4, -r3
mad_pp r3.x, r4, c3, r3
mul_pp r3.x, r3, r0.z
mad_pp r1.x, r1, c6.z, c6.w
mul_pp r0.x, r0, r5
mul_pp r3.xyz, r3.x, c2
max_pp r1.x, r1, c5
mad_pp r1.xyz, r3, c5.w, r1.x
mul_pp r1.xyz, r2, r1
mad_pp r1.xyz, r1, c0, r0.x
cmp r0.x, -t3.z, c5, c5.y
mul_pp r0.x, r0, r1.w
mul_pp r0.x, r0, r7
mul_pp r0.xyz, r0.x, r1
mul_pp r0.xyz, r0, c5.w
mov_pp r0.w, r2
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTextureB0] 2D
SetTexture 4 [_LightTexture0] CUBE
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 48 ALU, 5 TEX
PARAM c[7] = { program.local[0..4],
		{ 2, 1, 0.60009766, 0.39990234 },
		{ 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2, fragment.texcoord[0], texture[0], 2D;
TEX R5.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R3.zw, fragment.texcoord[0], texture[1], 2D;
TEX R0.w, fragment.texcoord[3], texture[4], CUBE;
SLT R0.x, R2.w, c[4];
DP3 R0.y, fragment.texcoord[3], fragment.texcoord[3];
DP3 R1.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R1.x, R1.x;
DP3 R1.y, fragment.texcoord[2], fragment.texcoord[2];
MUL R4.xyz, R1.x, fragment.texcoord[1];
RSQ R1.y, R1.y;
MOV result.color.w, R2;
TEX R1.w, R0.y, texture[3], 2D;
KIL -R0.x;
MAD R0.xy, R5.wyzw, c[5].x, -c[5].y;
MUL R5.yzw, R1.y, fragment.texcoord[2].xxyz;
ADD R1.xyz, R5.yzww, R4;
DP3 R3.y, R1, R1;
MUL R0.z, R0.y, R0.y;
MAD R0.z, -R0.x, R0.x, -R0;
ADD R0.z, R0, c[5].y;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
DP3 R3.x, R4, R0;
RSQ R4.w, R3.y;
MOV_SAT R3.y, -R3.x;
DP3_SAT R4.x, R5.yzww, -R4;
ADD R5.y, R4.x, -R3;
MUL R4.xyz, R4.w, R1;
DP3 R0.y, R0, R4;
MAD R1.x, R3, c[5].z, c[5].w;
MAD R1.y, R5, c[3].x, R3;
MAX R3.x, R1, c[6];
MUL R1.y, R1, R3.z;
MUL R1.xyz, R1.y, c[2];
MAD R1.xyz, R1, c[5].x, R3.x;
MUL R0.x, R5, c[6].y;
MAX R0.y, R0, c[6].x;
POW R3.y, R0.y, R0.x;
MUL R0.xyz, R2, c[1];
MUL R3.x, R3.w, c[1];
MUL R0.xyz, R0, fragment.color.primary.w;
MUL R2.x, R3.y, R3;
MUL R0.xyz, R0, R1;
MAD R0.xyz, R0, c[0], R2.x;
MUL R0.w, R1, R0;
MUL R0.xyz, R0.w, R0;
MUL result.color.xyz, R0, c[5].x;
END
# 48 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTextureB0] 2D
SetTexture 4 [_LightTexture0] CUBE
"ps_2_0
; 51 ALU, 6 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c5, 0.00000000, 1.00000000, 2.00000000, -1.00000000
def c6, 0.60009766, 0.39990234, 128.00000000, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t0, s0
texld r8, t0, s2
add_pp r0.x, r2.w, -c4
cmp r1.x, r0, c5, c5.y
mov_pp r1, -r1.x
dp3 r0.x, t3, t3
mov r0.xy, r0.x
dp3_pp r3.x, t1, t1
rsq_pp r3.x, r3.x
mul_pp r2.xyz, r2, c1
mul_pp r4.xyz, r3.x, t1
mul_pp r2.xyz, r2, v0.w
texld r7, r0, s3
texld r0, t0, s1
texkill r1.xyzw
texld r1, t3, s4
dp3_pp r1.x, t2, t2
rsq_pp r1.x, r1.x
mul_pp r3.xyz, r1.x, t2
add_pp r6.xyz, r3, r4
dp3_pp r1.x, r6, r6
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r6
mov r0.y, r8
mov r0.x, r8.w
mad_pp r5.xy, r0, c5.z, c5.w
mul_pp r0.x, r5.y, r5.y
mad_pp r0.x, -r5, r5, -r0
add_pp r0.x, r0, c5.y
rsq_pp r0.x, r0.x
rcp_pp r5.z, r0.x
dp3_pp r1.x, r5, r1
mul_pp r0.x, r8, c6.z
max_pp r1.x, r1, c5
pow_pp r6.x, r1.x, r0.x
dp3_pp r1.x, r4, r5
dp3_pp_sat r4.x, r3, -r4
mov_pp_sat r3.x, -r1
mov_pp r0.x, r6.x
mul_pp r5.x, r0.w, c1
add_pp r4.x, r4, -r3
mad_pp r3.x, r4, c3, r3
mul_pp r3.x, r3, r0.z
mad_pp r1.x, r1, c6, c6.y
mul_pp r0.x, r0, r5
mul_pp r3.xyz, r3.x, c2
max_pp r1.x, r1, c5
mad_pp r1.xyz, r3, c5.z, r1.x
mul_pp r1.xyz, r2, r1
mad_pp r1.xyz, r1, c0, r0.x
mul r0.x, r7, r1.w
mul_pp r0.xyz, r0.x, r1
mul_pp r0.xyz, r0, c5.z
mov_pp r0.w, r2
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_ShadowStrength]
Float 5 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 44 ALU, 4 TEX
PARAM c[8] = { program.local[0..5],
		{ 2, 1, 0.60009766, 0.39990234 },
		{ 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R4.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R1.zw, fragment.texcoord[0], texture[1], 2D;
TEX R2.w, fragment.texcoord[3], texture[3], 2D;
SLT R1.x, R0.w, c[5];
DP3 R1.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.y, R1.y;
MUL R0.xyz, R0, c[1];
MAD R2.xy, R4.wyzw, c[6].x, -c[6].y;
MUL R3.xyz, R1.y, fragment.texcoord[2];
ADD R4.yzw, R3.xxyz, fragment.texcoord[1].xxyz;
DP3_SAT R3.x, R3, -fragment.texcoord[1];
MUL R0.xyz, R0, fragment.color.primary.w;
MOV result.color.w, R0;
KIL -R1.x;
MUL R1.x, R2.y, R2.y;
MAD R1.x, -R2, R2, -R1;
ADD R1.x, R1, c[6].y;
RSQ R1.y, R1.x;
DP3 R1.x, R4.yzww, R4.yzww;
RCP R2.z, R1.y;
RSQ R1.y, R1.x;
DP3 R1.x, fragment.texcoord[1], R2;
MUL R4.yzw, R1.y, R4;
MOV_SAT R1.y, -R1.x;
DP3 R2.x, R2, R4.yzww;
MAD R2.y, R1.x, c[6].z, c[6].w;
ADD R3.x, R3, -R1.y;
MAD R1.y, R3.x, c[3].x, R1;
MUL R1.y, R1, R1.z;
MUL R1.xyz, R1.y, c[2];
MAX R2.y, R2, c[7].x;
MAD R1.xyz, R1, c[6].x, R2.y;
MUL R0.xyz, R0, R1;
MAX R1.z, R2.x, c[7].x;
MUL R1.y, R4.x, c[7];
POW R1.y, R1.z, R1.y;
MUL R1.x, R1.w, c[1];
MUL R1.y, R1, R1.x;
MOV R1.z, c[6].x;
MAD R1.x, R2.w, c[6], -c[6];
MAD R1.x, R1, c[4], R1.z;
MAD R0.xyz, R0, c[0], R1.y;
MUL result.color.xyz, R0, R1.x;
END
# 44 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Vector 2 [_TranslucencyColor]
Float 3 [_TranslucencyViewDependency]
Float 4 [_ShadowStrength]
Float 5 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
"ps_2_0
; 47 ALU, 5 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c6, 0.00000000, 1.00000000, 2.00000000, -1.00000000
def c7, 0.60009766, 0.39990234, 128.00000000, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3.xy
texld r1, t3, s3
texld r4, t0, s0
texld r7, t0, s2
add_pp r0.x, r4.w, -c5
cmp r0.x, r0, c6, c6.y
mov_pp r0, -r0.x
dp3_pp r1.x, t2, t2
rsq_pp r1.x, r1.x
mul_pp r3.xyz, r1.x, t2
add_pp r6.xyz, r3, t1
dp3_pp r1.x, r6, r6
rsq_pp r2.x, r1.x
mul_pp r6.xyz, r2.x, r6
dp3_pp_sat r2.x, r3, -t1
mul_pp r4.xyz, r4, c1
texkill r0.xyzw
texld r0, t0, s1
mov r0.y, r7
mov r0.x, r7.w
mad_pp r5.xy, r0, c6.z, c6.w
mul_pp r0.x, r5.y, r5.y
mad_pp r0.x, -r5, r5, -r0
add_pp r0.x, r0, c6.y
rsq_pp r0.x, r0.x
rcp_pp r5.z, r0.x
dp3_pp r0.x, t1, r5
mov_pp_sat r1.x, -r0
add_pp r3.x, r2, -r1
mad_pp r1.x, r3, c3, r1
mul_pp r1.x, r1, r0.z
mad_pp r0.x, r0, c7, c7.y
mul_pp r1.xyz, r1.x, c2
max_pp r0.x, r0, c6
mad_pp r3.xyz, r1, c6.z, r0.x
dp3_pp r2.x, r5, r6
max_pp r0.x, r2, c6
mul_pp r1.x, r7, c7.z
pow_pp r2.x, r0.x, r1.x
mul_pp r0.xyz, r4, v0.w
mul_pp r3.xyz, r0, r3
mul_pp r0.x, r0.w, c1
mov_pp r1.x, r2.x
mul_pp r0.x, r1, r0
mov_pp r0.z, c6
mad_pp r1.x, r1.w, c6.z, -c6.z
mad_pp r1.x, r1, c4, r0.z
mad_pp r0.xyz, r3, c0, r0.x
mul_pp r0.xyz, r0, r1.x
mov_pp r0.w, r4
mov_pp oC0, r0
"
}
}
 }
 Pass {
  Name "SHADOWCASTER"
  Tags { "LIGHTMODE"="SHADOWCASTER" "IGNOREPROJECTOR"="True" "RenderType"="TreeLeaf" }
  Cull Off
  Fog { Mode Off }
  Offset 1, 1
Program "vp" {
SubProgram "opengl " {
Keywords { "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Vector 13 [_Time]
Vector 14 [unity_LightShadowBias]
Vector 15 [_Scale]
Vector 16 [_SquashPlaneNormal]
Float 17 [_SquashAmount]
Vector 18 [_Wind]
Vector 19 [_ShadowTex_ST]
"!!ARBvp1.0
# 55 ALU
PARAM c[22] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..19],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R0, vertex.normal.y, c[6];
MAD R1, vertex.normal.x, c[5], R0;
ADD R0.xyz, R1, c[0].x;
ABS R2.x, vertex.attrib[14].w;
ADD R2.w, -R2.x, c[0].y;
MAD R0.xyz, R0, R2.w, vertex.position;
MAD R1, vertex.normal.z, c[7], R1;
ADD R3, R1, c[0].x;
DP4 R3.y, R3, R3;
MOV R0.w, c[0].y;
DP3 R0.w, R0.w, c[12];
MUL R2.xyz, R0, c[15];
ADD R0.w, vertex.color.x, R0;
ADD R0.x, vertex.color.y, R0.w;
MOV R0.y, R0.w;
DP3 R0.x, R2, R0.x;
ADD R0.xy, R0, c[13].y;
MUL R0, R0.xxyy, c[20];
FRC R0, R0;
MAD R0, R0, c[0].z, c[0].w;
FRC R0, R0;
MAD R0, R0, c[0].z, -c[0].y;
ABS R0, R0;
MUL R1, -R0, c[0].z;
ADD R1, R1, c[21].x;
MUL R0, R0, R0;
MUL R0, R0, R1;
RSQ R3.y, R3.y;
MAD R1.xy, R3.y, R3.xzzw, -vertex.normal.xzzw;
ADD R3.xy, R0.xzzw, R0.ywzw;
MAD R0.xy, R2.w, R1, vertex.normal.xzzw;
MUL R0.xy, vertex.color.y, R0;
MUL R0.xz, R0.xyyw, c[21].z;
MUL R1.xyz, R3.y, c[18];
MOV R0.w, c[0].y;
MUL R1.xyz, vertex.texcoord[1].y, R1;
MUL R0.y, vertex.texcoord[1], c[21];
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[18].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[18], R0;
DP3 R0.x, R1, c[16];
ADD R0.x, R0, c[16].w;
MUL R0.xyz, R0.x, c[16];
ADD R1.xyz, -R0, R1;
MAD R0.xyz, R0, c[17].x, R1;
DP4 R1.y, R0, c[4];
DP4 R1.x, R0, c[3];
ADD R1.x, R1, c[14];
MAX R1.z, R1.x, -R1.y;
ADD R1.z, R1, -R1.x;
MAD result.position.z, R1, c[14].y, R1.x;
MOV result.position.w, R1.y;
DP4 result.position.y, R0, c[2];
DP4 result.position.x, R0, c[1];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[19], c[19].zwzw;
END
# 55 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Vector 12 [_Time]
Vector 13 [unity_LightShadowBias]
Vector 14 [_Scale]
Vector 15 [_SquashPlaneNormal]
Float 16 [_SquashAmount]
Vector 17 [_Wind]
Vector 18 [_ShadowTex_ST]
"vs_2_0
; 59 ALU
def c19, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c20, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c21, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c22, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c5
mad r1, v2.x, c4, r0
add r0.xyz, r1, c19.x
abs r0.w, v1
add r3.w, -r0, c19.y
mad r0.xyz, r0, r3.w, v0
mov r2.xyz, c11
dp3 r0.w, c19.y, r2
mad r1, v2.z, c6, r1
add r2, r1, c19.x
dp4 r2.y, r2, r2
mul r3.xyz, r0, c14
add r0.w, v5.x, r0
add r0.x, v5.y, r0.w
mov r0.y, r0.w
dp3 r0.x, r3, r0.x
add r0.xy, r0, c12.y
mul r0, r0.xxyy, c20
frc r0, r0
mad r0, r0, c19.z, c19.w
frc r0, r0
mad r0, r0, c21.x, c21.y
abs r0, r0
mul r1, r0, r0
mad r0, -r0, c21.x, c21.z
mul r0, r1, r0
rsq r2.y, r2.y
mad r1.xy, r2.y, r2.xzzw, -v2.xzzw
add r2.xy, r0.xzzw, r0.ywzw
mad r0.xy, r3.w, r1, v2.xzzw
mul r0.xy, v5.y, r0
mul r0.xz, r0.xyyw, c22.x
mul r1.xyz, r2.y, c17
mov r0.w, c19.y
mul r1.xyz, v4.y, r1
mul r0.y, v4, c21.w
mad r0.xyz, r2.xyxw, r0, r1
mad r0.xyz, r0, c17.w, r3
mad r1.xyz, v4.x, c17, r0
dp3 r0.x, r1, c15
add r0.x, r0, c15.w
mul r0.xyz, r0.x, c15
add r1.xyz, -r0, r1
mad r0.xyz, r0, c16.x, r1
dp4 r1.x, r0, c2
add r1.x, r1, c13
max r1.y, r1.x, c19.x
add r1.y, r1, -r1.x
mad r1.z, r1.y, c13.y, r1.x
dp4 r1.w, r0, c3
dp4 r1.x, r0, c0
dp4 r1.y, r0, c1
mov oPos, r1
mov oT0, r1
mad oT1.xy, v3, c18, c18.zwzw
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Vector 13 [_Time]
Vector 14 [_LightPositionRange]
Vector 15 [_Scale]
Vector 16 [_SquashPlaneNormal]
Float 17 [_SquashAmount]
Vector 18 [_Wind]
Vector 19 [_ShadowTex_ST]
"!!ARBvp1.0
# 54 ALU
PARAM c[22] = { { 0, 1, 2, -0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..19],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R0, vertex.normal.y, c[6];
MAD R1, vertex.normal.x, c[5], R0;
ADD R0.xyz, R1, c[0].x;
ABS R2.x, vertex.attrib[14].w;
ADD R2.w, -R2.x, c[0].y;
MAD R0.xyz, R0, R2.w, vertex.position;
MAD R1, vertex.normal.z, c[7], R1;
ADD R3, R1, c[0].x;
DP4 R3.y, R3, R3;
MOV R0.w, c[0].y;
DP3 R0.w, R0.w, c[12];
MUL R2.xyz, R0, c[15];
ADD R0.w, vertex.color.x, R0;
ADD R0.x, vertex.color.y, R0.w;
MOV R0.y, R0.w;
DP3 R0.x, R2, R0.x;
ADD R0.xy, R0, c[13].y;
MUL R0, R0.xxyy, c[20];
FRC R0, R0;
MAD R0, R0, c[0].z, c[0].w;
FRC R0, R0;
MAD R0, R0, c[0].z, -c[0].y;
ABS R0, R0;
MUL R1, -R0, c[0].z;
ADD R1, R1, c[21].x;
MUL R0, R0, R0;
MUL R0, R0, R1;
RSQ R3.y, R3.y;
MAD R1.xy, R3.y, R3.xzzw, -vertex.normal.xzzw;
ADD R3.xy, R0.xzzw, R0.ywzw;
MAD R0.xy, R2.w, R1, vertex.normal.xzzw;
MUL R0.xy, vertex.color.y, R0;
MUL R0.xz, R0.xyyw, c[21].z;
MUL R1.xyz, R3.y, c[18];
MOV R0.w, c[0].y;
MUL R1.xyz, vertex.texcoord[1].y, R1;
MUL R0.y, vertex.texcoord[1], c[21];
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[18].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[18], R0;
DP3 R0.x, R1, c[16];
ADD R0.x, R0, c[16].w;
MUL R0.xyz, R0.x, c[16];
ADD R1.xyz, -R0, R1;
MAD R0.xyz, R0, c[17].x, R1;
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
ADD result.texcoord[0].xyz, R1, -c[14];
DP4 result.position.w, R0, c[4];
DP4 result.position.z, R0, c[3];
DP4 result.position.y, R0, c[2];
DP4 result.position.x, R0, c[1];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[19], c[19].zwzw;
END
# 54 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_Object2World]
Vector 12 [_Time]
Vector 13 [_LightPositionRange]
Vector 14 [_Scale]
Vector 15 [_SquashPlaneNormal]
Float 16 [_SquashAmount]
Vector 17 [_Wind]
Vector 18 [_ShadowTex_ST]
"vs_2_0
; 57 ALU
def c19, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c20, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c21, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c22, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c5
mad r1, v2.x, c4, r0
add r0.xyz, r1, c19.x
abs r0.w, v1
add r3.w, -r0, c19.y
mad r0.xyz, r0, r3.w, v0
mov r2.xyz, c11
dp3 r0.w, c19.y, r2
mad r1, v2.z, c6, r1
add r2, r1, c19.x
dp4 r2.y, r2, r2
mul r3.xyz, r0, c14
add r0.w, v5.x, r0
add r0.x, v5.y, r0.w
mov r0.y, r0.w
dp3 r0.x, r3, r0.x
add r0.xy, r0, c12.y
mul r0, r0.xxyy, c20
frc r0, r0
mad r0, r0, c19.z, c19.w
frc r0, r0
mad r0, r0, c21.x, c21.y
abs r0, r0
mul r1, r0, r0
mad r0, -r0, c21.x, c21.z
mul r0, r1, r0
rsq r2.y, r2.y
mad r1.xy, r2.y, r2.xzzw, -v2.xzzw
add r2.xy, r0.xzzw, r0.ywzw
mad r0.xy, r3.w, r1, v2.xzzw
mul r0.xy, v5.y, r0
mul r0.xz, r0.xyyw, c22.x
mul r1.xyz, r2.y, c17
mov r0.w, c19.y
mul r1.xyz, v4.y, r1
mul r0.y, v4, c21.w
mad r0.xyz, r2.xyxw, r0, r1
mad r0.xyz, r0, c17.w, r3
mad r1.xyz, v4.x, c17, r0
dp3 r0.x, r1, c15
add r0.x, r0, c15.w
mul r0.xyz, r0.x, c15
add r1.xyz, -r0, r1
mad r0.xyz, r0, c16.x, r1
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
add oT0.xyz, r1, -c13
dp4 oPos.w, r0, c3
dp4 oPos.z, r0, c2
dp4 oPos.y, r0, c1
dp4 oPos.x, r0, c0
mad oT1.xy, v3, c18, c18.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SHADOWS_DEPTH" }
Float 0 [_Cutoff]
SetTexture 0 [_ShadowTex] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 4 ALU, 1 TEX
PARAM c[2] = { program.local[0],
		{ 0 } };
TEMP R0;
TEX R0.x, fragment.texcoord[1], texture[0], 2D;
SLT R0.x, R0, c[0];
MOV result.color, c[1].x;
KIL -R0.x;
END
# 4 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_DEPTH" }
Float 0 [_Cutoff]
SetTexture 0 [_ShadowTex] 2D
"ps_2_0
; 7 ALU, 2 TEX
dcl_2d s0
def c1, 0.00000000, 1.00000000, 0, 0
dcl t0.xyzw
dcl t1.xy
texld r0, t1, s0
add_pp r0.x, r0, -c0
cmp r0.x, r0, c1, c1.y
mov_pp r0, -r0.x
texkill r0.xyzw
rcp r0.x, t0.w
mul r0.x, t0.z, r0
mov r0, r0.x
mov oC0, r0
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Vector 0 [_LightPositionRange]
Float 1 [_Cutoff]
SetTexture 0 [_ShadowTex] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 10 ALU, 1 TEX
PARAM c[4] = { program.local[0..1],
		{ 1, 255, 65025, 1.6058138e+008 },
		{ 0.0039215689 } };
TEMP R0;
TEX R0.x, fragment.texcoord[1], texture[0], 2D;
SLT R0.x, R0, c[1];
KIL -R0.x;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.x, R0.x;
RCP R0.x, R0.x;
MUL R0.x, R0, c[0].w;
MUL R0, R0.x, c[2];
FRC R0, R0;
MAD result.color, -R0.yzww, c[3].x, R0;
END
# 10 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_CUBE" }
Vector 0 [_LightPositionRange]
Float 1 [_Cutoff]
SetTexture 0 [_ShadowTex] 2D
"ps_2_0
; 13 ALU, 2 TEX
dcl_2d s0
def c2, 0.00000000, 1.00000000, 0.00392157, 0
def c3, 1.00000000, 255.00000000, 65025.00000000, 160581376.00000000
dcl t0.xyz
dcl t1.xy
texld r0, t1, s0
add_pp r0.x, r0, -c1
cmp r0.x, r0, c2, c2.y
mov_pp r0, -r0.x
texkill r0.xyzw
dp3 r0.x, t0, t0
rsq r0.x, r0.x
rcp r0.x, r0.x
mul r0.x, r0, c0.w
mul r0, r0.x, c3
frc r1, r0
mov r0.z, -r1.w
mov r0.xyw, -r1.yzxw
mad r0, r0, c2.z, r1
mov oC0, r0
"
}
}
 }
 Pass {
  Name "SHADOWCOLLECTOR"
  Tags { "LIGHTMODE"="SHADOWCOLLECTOR" "IGNOREPROJECTOR"="True" "RenderType"="TreeLeaf" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Keywords { "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 13 [_Object2World]
Matrix 17 [_World2Shadow]
Matrix 21 [unity_World2Shadow0]
Matrix 25 [unity_World2Shadow1]
Matrix 29 [unity_World2Shadow2]
Matrix 33 [unity_World2Shadow3]
Vector 37 [_Time]
Vector 38 [unity_Scale]
Vector 39 [_Scale]
Vector 40 [_SquashPlaneNormal]
Float 41 [_SquashAmount]
Vector 42 [_Wind]
Vector 43 [_MainTex_ST]
"!!ARBvp1.0
# 81 ALU
PARAM c[46] = { { 0, 1, 2, -0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[13..43],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0, vertex.normal.y, c[10];
MAD R2, vertex.normal.x, c[9], R0;
ADD R0.xyz, R2, c[0].x;
MAD R2, vertex.normal.z, c[11], R2;
ADD R3, R2, c[0].x;
DP4 R3.w, R3, R3;
ABS R0.w, vertex.attrib[14];
ADD R0.w, -R0, c[0].y;
MAD R0.xyz, R0, R0.w, vertex.position;
MOV R1.x, c[0].y;
DP3 R1.x, R1.x, c[16];
ADD R1.x, vertex.color, R1;
ADD R1.z, vertex.color.y, R1.x;
MUL R0.xyz, R0, c[39];
MOV R1.y, R1.x;
DP3 R1.x, R0, R1.z;
ADD R1.xy, R1, c[37].y;
MUL R1, R1.xxyy, c[44];
FRC R1, R1;
MAD R1, R1, c[0].z, c[0].w;
FRC R1, R1;
MAD R1, R1, c[0].z, -c[0].y;
ABS R1, R1;
MUL R2, -R1, c[0].z;
ADD R2, R2, c[45].x;
MUL R1, R1, R1;
MUL R1, R1, R2;
ADD R4.xy, R1.xzzw, R1.ywzw;
RSQ R3.w, R3.w;
MAD R2.xyz, R3.w, R3, -vertex.normal;
MAD R3.xyz, R0.w, R2, vertex.normal;
MUL R1.xyz, R4.y, c[42];
MUL R2.xyz, vertex.texcoord[1].y, R1;
MUL R4.zw, vertex.color.y, R3.xyxz;
MOV R2.w, c[0].y;
MUL R1.xz, R4.zyww, c[45].z;
MUL R1.y, vertex.texcoord[1], c[45];
MAD R1.xyz, R4.xyxw, R1, R2;
MAD R0.xyz, R1, c[42].w, R0;
MAD R1.xyz, vertex.texcoord[1].x, c[42], R0;
DP3 R0.x, R1, c[40];
ADD R0.x, R0, c[40].w;
MUL R0.xyz, R0.x, c[40];
ADD R1.xyz, -R0, R1;
MAD R2.xyz, R0, c[41].x, R1;
DP4 R0.w, R2, c[3];
DP4 R1.w, R2, c[16];
DP4 R0.z, R2, c[15];
DP4 R0.x, R2, c[13];
DP4 R0.y, R2, c[14];
MOV R1.xyz, R0;
MOV R0.w, -R0;
MOV result.texcoord[4], R0;
DP3 R0.x, R3, R3;
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, R3;
DP4 result.texcoord[0].z, R1, c[23];
DP4 result.texcoord[0].y, R1, c[22];
DP4 result.texcoord[0].x, R1, c[21];
DP4 result.texcoord[1].z, R1, c[27];
DP4 result.texcoord[1].y, R1, c[26];
DP4 result.texcoord[1].x, R1, c[25];
DP4 result.texcoord[2].z, R1, c[31];
DP4 result.texcoord[2].y, R1, c[30];
DP4 result.texcoord[2].x, R1, c[29];
DP4 result.texcoord[3].z, R1, c[35];
DP4 result.texcoord[3].y, R1, c[34];
DP4 result.texcoord[3].x, R1, c[33];
MUL R0.xyz, R0, c[38].w;
DP3 R1.x, R0, c[13];
DP3 R1.y, R0, c[14];
MOV R1.w, c[0].x;
DP3 R1.z, R0, c[15];
DP4 result.position.w, R2, c[8];
DP4 result.position.z, R2, c[7];
DP4 result.position.y, R2, c[6];
DP4 result.position.x, R2, c[5];
DP4 result.texcoord[6].z, R1, c[19];
DP4 result.texcoord[6].y, R1, c[18];
DP4 result.texcoord[6].x, R1, c[17];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[43], c[43].zwzw;
END
# 81 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [glstate_matrix_invtrans_modelview0]
Matrix 12 [_Object2World]
Matrix 16 [_World2Shadow]
Matrix 20 [unity_World2Shadow0]
Matrix 24 [unity_World2Shadow1]
Matrix 28 [unity_World2Shadow2]
Matrix 32 [unity_World2Shadow3]
Vector 36 [_Time]
Vector 37 [unity_Scale]
Vector 38 [_Scale]
Vector 39 [_SquashPlaneNormal]
Float 40 [_SquashAmount]
Vector 41 [_Wind]
Vector 42 [_MainTex_ST]
"vs_2_0
; 84 ALU
def c43, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c44, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c45, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c46, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c9
mad r2, v2.x, c8, r0
mov r1.xyz, c15
dp3 r1.x, c43.y, r1
add r1.x, v5, r1
add r0.xyz, r2, c43.x
mad r2, v2.z, c10, r2
add r3, r2, c43.x
dp4 r3.w, r3, r3
abs r0.w, v1
add r0.w, -r0, c43.y
mad r0.xyz, r0, r0.w, v0
add r1.z, v5.y, r1.x
mul r0.xyz, r0, c38
mov r1.y, r1.x
dp3 r1.x, r0, r1.z
add r1.xy, r1, c36.y
mul r1, r1.xxyy, c44
frc r1, r1
mad r1, r1, c43.z, c43.w
frc r1, r1
mad r1, r1, c45.x, c45.y
abs r1, r1
mul r2, r1, r1
mad r1, -r1, c45.x, c45.z
mul r1, r2, r1
add r4.xy, r1.xzzw, r1.ywzw
rsq r3.w, r3.w
mad r2.xyz, r3.w, r3, -v2
mad r3.xyz, r0.w, r2, v2
mul r1.xyz, r4.y, c41
mul r2.xyz, v4.y, r1
mul r4.zw, v5.y, r3.xyxz
mov r2.w, c43.y
mul r1.xz, r4.zyww, c46.x
mul r1.y, v4, c45.w
mad r1.xyz, r4.xyxw, r1, r2
mad r0.xyz, r1, c41.w, r0
mad r1.xyz, v4.x, c41, r0
dp3 r0.x, r1, c39
add r0.x, r0, c39.w
mul r0.xyz, r0.x, c39
add r1.xyz, -r0, r1
mad r2.xyz, r0, c40.x, r1
dp4 r0.w, r2, c2
dp4 r1.w, r2, c15
dp4 r0.z, r2, c14
dp4 r0.x, r2, c12
dp4 r0.y, r2, c13
mov r1.xyz, r0
mov r0.w, -r0
mov oT4, r0
dp3 r0.x, r3, r3
rsq r0.x, r0.x
mul r0.xyz, r0.x, r3
dp4 oT0.z, r1, c22
dp4 oT0.y, r1, c21
dp4 oT0.x, r1, c20
dp4 oT1.z, r1, c26
dp4 oT1.y, r1, c25
dp4 oT1.x, r1, c24
dp4 oT2.z, r1, c30
dp4 oT2.y, r1, c29
dp4 oT2.x, r1, c28
dp4 oT3.z, r1, c34
dp4 oT3.y, r1, c33
dp4 oT3.x, r1, c32
mul r0.xyz, r0, c37.w
dp3 r1.x, r0, c12
dp3 r1.y, r0, c13
mov r1.w, c43.x
dp3 r1.z, r0, c14
dp4 oPos.w, r2, c7
dp4 oPos.z, r2, c6
dp4 oPos.y, r2, c5
dp4 oPos.x, r2, c4
dp4 oT6.z, r1, c18
dp4 oT6.y, r1, c17
dp4 oT6.x, r1, c16
mad oT5.xy, v3, c42, c42.zwzw
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [glstate_matrix_invtrans_modelview0]
Matrix 12 [_Object2World]
Matrix 16 [_World2Shadow]
Matrix 20 [unity_World2Shadow0]
Matrix 24 [unity_World2Shadow1]
Matrix 28 [unity_World2Shadow2]
Matrix 32 [unity_World2Shadow3]
Vector 36 [_Time]
Vector 37 [unity_Scale]
Vector 38 [_Scale]
Vector 39 [_SquashPlaneNormal]
Float 40 [_SquashAmount]
Vector 41 [_Wind]
Vector 42 [_MainTex_ST]
"vs_2_0
; 84 ALU
def c43, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c44, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c45, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c46, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c9
mad r2, v2.x, c8, r0
mov r1.xyz, c15
dp3 r1.x, c43.y, r1
add r1.x, v5, r1
add r0.xyz, r2, c43.x
mad r2, v2.z, c10, r2
add r3, r2, c43.x
dp4 r3.w, r3, r3
abs r0.w, v1
add r0.w, -r0, c43.y
mad r0.xyz, r0, r0.w, v0
add r1.z, v5.y, r1.x
mul r0.xyz, r0, c38
mov r1.y, r1.x
dp3 r1.x, r0, r1.z
add r1.xy, r1, c36.y
mul r1, r1.xxyy, c44
frc r1, r1
mad r1, r1, c43.z, c43.w
frc r1, r1
mad r1, r1, c45.x, c45.y
abs r1, r1
mul r2, r1, r1
mad r1, -r1, c45.x, c45.z
mul r1, r2, r1
add r4.xy, r1.xzzw, r1.ywzw
rsq r3.w, r3.w
mad r2.xyz, r3.w, r3, -v2
mad r3.xyz, r0.w, r2, v2
mul r1.xyz, r4.y, c41
mul r2.xyz, v4.y, r1
mul r4.zw, v5.y, r3.xyxz
mov r2.w, c43.y
mul r1.xz, r4.zyww, c46.x
mul r1.y, v4, c45.w
mad r1.xyz, r4.xyxw, r1, r2
mad r0.xyz, r1, c41.w, r0
mad r1.xyz, v4.x, c41, r0
dp3 r0.x, r1, c39
add r0.x, r0, c39.w
mul r0.xyz, r0.x, c39
add r1.xyz, -r0, r1
mad r2.xyz, r0, c40.x, r1
dp4 r0.w, r2, c2
dp4 r1.w, r2, c15
dp4 r0.z, r2, c14
dp4 r0.x, r2, c12
dp4 r0.y, r2, c13
mov r1.xyz, r0
mov r0.w, -r0
mov oT4, r0
dp3 r0.x, r3, r3
rsq r0.x, r0.x
mul r0.xyz, r0.x, r3
dp4 oT0.z, r1, c22
dp4 oT0.y, r1, c21
dp4 oT0.x, r1, c20
dp4 oT1.z, r1, c26
dp4 oT1.y, r1, c25
dp4 oT1.x, r1, c24
dp4 oT2.z, r1, c30
dp4 oT2.y, r1, c29
dp4 oT2.x, r1, c28
dp4 oT3.z, r1, c34
dp4 oT3.y, r1, c33
dp4 oT3.x, r1, c32
mul r0.xyz, r0, c37.w
dp3 r1.x, r0, c12
dp3 r1.y, r0, c13
mov r1.w, c43.x
dp3 r1.z, r0, c14
dp4 oPos.w, r2, c7
dp4 oPos.z, r2, c6
dp4 oPos.y, r2, c5
dp4 oPos.x, r2, c4
dp4 oT6.z, r1, c18
dp4 oT6.y, r1, c17
dp4 oT6.x, r1, c16
mad oT5.xy, v3, c42, c42.zwzw
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 13 [_Object2World]
Matrix 17 [_World2Shadow]
Matrix 21 [unity_World2Shadow0]
Matrix 25 [unity_World2Shadow1]
Matrix 29 [unity_World2Shadow2]
Matrix 33 [unity_World2Shadow3]
Vector 37 [_Time]
Vector 38 [unity_Scale]
Vector 39 [_Scale]
Vector 40 [_SquashPlaneNormal]
Float 41 [_SquashAmount]
Vector 42 [_Wind]
Vector 43 [_MainTex_ST]
"!!ARBvp1.0
# 81 ALU
PARAM c[46] = { { 0, 1, 2, -0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[13..43],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0, vertex.normal.y, c[10];
MAD R2, vertex.normal.x, c[9], R0;
ADD R0.xyz, R2, c[0].x;
MAD R2, vertex.normal.z, c[11], R2;
ADD R3, R2, c[0].x;
DP4 R3.w, R3, R3;
ABS R0.w, vertex.attrib[14];
ADD R0.w, -R0, c[0].y;
MAD R0.xyz, R0, R0.w, vertex.position;
MOV R1.x, c[0].y;
DP3 R1.x, R1.x, c[16];
ADD R1.x, vertex.color, R1;
ADD R1.z, vertex.color.y, R1.x;
MUL R0.xyz, R0, c[39];
MOV R1.y, R1.x;
DP3 R1.x, R0, R1.z;
ADD R1.xy, R1, c[37].y;
MUL R1, R1.xxyy, c[44];
FRC R1, R1;
MAD R1, R1, c[0].z, c[0].w;
FRC R1, R1;
MAD R1, R1, c[0].z, -c[0].y;
ABS R1, R1;
MUL R2, -R1, c[0].z;
ADD R2, R2, c[45].x;
MUL R1, R1, R1;
MUL R1, R1, R2;
ADD R4.xy, R1.xzzw, R1.ywzw;
RSQ R3.w, R3.w;
MAD R2.xyz, R3.w, R3, -vertex.normal;
MAD R3.xyz, R0.w, R2, vertex.normal;
MUL R1.xyz, R4.y, c[42];
MUL R2.xyz, vertex.texcoord[1].y, R1;
MUL R4.zw, vertex.color.y, R3.xyxz;
MOV R2.w, c[0].y;
MUL R1.xz, R4.zyww, c[45].z;
MUL R1.y, vertex.texcoord[1], c[45];
MAD R1.xyz, R4.xyxw, R1, R2;
MAD R0.xyz, R1, c[42].w, R0;
MAD R1.xyz, vertex.texcoord[1].x, c[42], R0;
DP3 R0.x, R1, c[40];
ADD R0.x, R0, c[40].w;
MUL R0.xyz, R0.x, c[40];
ADD R1.xyz, -R0, R1;
MAD R2.xyz, R0, c[41].x, R1;
DP4 R0.w, R2, c[3];
DP4 R1.w, R2, c[16];
DP4 R0.z, R2, c[15];
DP4 R0.x, R2, c[13];
DP4 R0.y, R2, c[14];
MOV R1.xyz, R0;
MOV R0.w, -R0;
MOV result.texcoord[4], R0;
DP3 R0.x, R3, R3;
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, R3;
DP4 result.texcoord[0].z, R1, c[23];
DP4 result.texcoord[0].y, R1, c[22];
DP4 result.texcoord[0].x, R1, c[21];
DP4 result.texcoord[1].z, R1, c[27];
DP4 result.texcoord[1].y, R1, c[26];
DP4 result.texcoord[1].x, R1, c[25];
DP4 result.texcoord[2].z, R1, c[31];
DP4 result.texcoord[2].y, R1, c[30];
DP4 result.texcoord[2].x, R1, c[29];
DP4 result.texcoord[3].z, R1, c[35];
DP4 result.texcoord[3].y, R1, c[34];
DP4 result.texcoord[3].x, R1, c[33];
MUL R0.xyz, R0, c[38].w;
DP3 R1.x, R0, c[13];
DP3 R1.y, R0, c[14];
MOV R1.w, c[0].x;
DP3 R1.z, R0, c[15];
DP4 result.position.w, R2, c[8];
DP4 result.position.z, R2, c[7];
DP4 result.position.y, R2, c[6];
DP4 result.position.x, R2, c[5];
DP4 result.texcoord[6].z, R1, c[19];
DP4 result.texcoord[6].y, R1, c[18];
DP4 result.texcoord[6].x, R1, c[17];
MAD result.texcoord[5].xy, vertex.texcoord[0], c[43], c[43].zwzw;
END
# 81 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [glstate_matrix_invtrans_modelview0]
Matrix 12 [_Object2World]
Matrix 16 [_World2Shadow]
Matrix 20 [unity_World2Shadow0]
Matrix 24 [unity_World2Shadow1]
Matrix 28 [unity_World2Shadow2]
Matrix 32 [unity_World2Shadow3]
Vector 36 [_Time]
Vector 37 [unity_Scale]
Vector 38 [_Scale]
Vector 39 [_SquashPlaneNormal]
Float 40 [_SquashAmount]
Vector 41 [_Wind]
Vector 42 [_MainTex_ST]
"vs_2_0
; 84 ALU
def c43, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c44, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c45, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c46, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c9
mad r2, v2.x, c8, r0
mov r1.xyz, c15
dp3 r1.x, c43.y, r1
add r1.x, v5, r1
add r0.xyz, r2, c43.x
mad r2, v2.z, c10, r2
add r3, r2, c43.x
dp4 r3.w, r3, r3
abs r0.w, v1
add r0.w, -r0, c43.y
mad r0.xyz, r0, r0.w, v0
add r1.z, v5.y, r1.x
mul r0.xyz, r0, c38
mov r1.y, r1.x
dp3 r1.x, r0, r1.z
add r1.xy, r1, c36.y
mul r1, r1.xxyy, c44
frc r1, r1
mad r1, r1, c43.z, c43.w
frc r1, r1
mad r1, r1, c45.x, c45.y
abs r1, r1
mul r2, r1, r1
mad r1, -r1, c45.x, c45.z
mul r1, r2, r1
add r4.xy, r1.xzzw, r1.ywzw
rsq r3.w, r3.w
mad r2.xyz, r3.w, r3, -v2
mad r3.xyz, r0.w, r2, v2
mul r1.xyz, r4.y, c41
mul r2.xyz, v4.y, r1
mul r4.zw, v5.y, r3.xyxz
mov r2.w, c43.y
mul r1.xz, r4.zyww, c46.x
mul r1.y, v4, c45.w
mad r1.xyz, r4.xyxw, r1, r2
mad r0.xyz, r1, c41.w, r0
mad r1.xyz, v4.x, c41, r0
dp3 r0.x, r1, c39
add r0.x, r0, c39.w
mul r0.xyz, r0.x, c39
add r1.xyz, -r0, r1
mad r2.xyz, r0, c40.x, r1
dp4 r0.w, r2, c2
dp4 r1.w, r2, c15
dp4 r0.z, r2, c14
dp4 r0.x, r2, c12
dp4 r0.y, r2, c13
mov r1.xyz, r0
mov r0.w, -r0
mov oT4, r0
dp3 r0.x, r3, r3
rsq r0.x, r0.x
mul r0.xyz, r0.x, r3
dp4 oT0.z, r1, c22
dp4 oT0.y, r1, c21
dp4 oT0.x, r1, c20
dp4 oT1.z, r1, c26
dp4 oT1.y, r1, c25
dp4 oT1.x, r1, c24
dp4 oT2.z, r1, c30
dp4 oT2.y, r1, c29
dp4 oT2.x, r1, c28
dp4 oT3.z, r1, c34
dp4 oT3.y, r1, c33
dp4 oT3.x, r1, c32
mul r0.xyz, r0, c37.w
dp3 r1.x, r0, c12
dp3 r1.y, r0, c13
mov r1.w, c43.x
dp3 r1.z, r0, c14
dp4 oPos.w, r2, c7
dp4 oPos.z, r2, c6
dp4 oPos.y, r2, c5
dp4 oPos.x, r2, c4
dp4 oT6.z, r1, c18
dp4 oT6.y, r1, c17
dp4 oT6.x, r1, c16
mad oT5.xy, v3, c42, c42.zwzw
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [glstate_matrix_invtrans_modelview0]
Matrix 12 [_Object2World]
Matrix 16 [_World2Shadow]
Matrix 20 [unity_World2Shadow0]
Matrix 24 [unity_World2Shadow1]
Matrix 28 [unity_World2Shadow2]
Matrix 32 [unity_World2Shadow3]
Vector 36 [_Time]
Vector 37 [unity_Scale]
Vector 38 [_Scale]
Vector 39 [_SquashPlaneNormal]
Float 40 [_SquashAmount]
Vector 41 [_Wind]
Vector 42 [_MainTex_ST]
"vs_2_0
; 84 ALU
def c43, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c44, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c45, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c46, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mul r0, v2.y, c9
mad r2, v2.x, c8, r0
mov r1.xyz, c15
dp3 r1.x, c43.y, r1
add r1.x, v5, r1
add r0.xyz, r2, c43.x
mad r2, v2.z, c10, r2
add r3, r2, c43.x
dp4 r3.w, r3, r3
abs r0.w, v1
add r0.w, -r0, c43.y
mad r0.xyz, r0, r0.w, v0
add r1.z, v5.y, r1.x
mul r0.xyz, r0, c38
mov r1.y, r1.x
dp3 r1.x, r0, r1.z
add r1.xy, r1, c36.y
mul r1, r1.xxyy, c44
frc r1, r1
mad r1, r1, c43.z, c43.w
frc r1, r1
mad r1, r1, c45.x, c45.y
abs r1, r1
mul r2, r1, r1
mad r1, -r1, c45.x, c45.z
mul r1, r2, r1
add r4.xy, r1.xzzw, r1.ywzw
rsq r3.w, r3.w
mad r2.xyz, r3.w, r3, -v2
mad r3.xyz, r0.w, r2, v2
mul r1.xyz, r4.y, c41
mul r2.xyz, v4.y, r1
mul r4.zw, v5.y, r3.xyxz
mov r2.w, c43.y
mul r1.xz, r4.zyww, c46.x
mul r1.y, v4, c45.w
mad r1.xyz, r4.xyxw, r1, r2
mad r0.xyz, r1, c41.w, r0
mad r1.xyz, v4.x, c41, r0
dp3 r0.x, r1, c39
add r0.x, r0, c39.w
mul r0.xyz, r0.x, c39
add r1.xyz, -r0, r1
mad r2.xyz, r0, c40.x, r1
dp4 r0.w, r2, c2
dp4 r1.w, r2, c15
dp4 r0.z, r2, c14
dp4 r0.x, r2, c12
dp4 r0.y, r2, c13
mov r1.xyz, r0
mov r0.w, -r0
mov oT4, r0
dp3 r0.x, r3, r3
rsq r0.x, r0.x
mul r0.xyz, r0.x, r3
dp4 oT0.z, r1, c22
dp4 oT0.y, r1, c21
dp4 oT0.x, r1, c20
dp4 oT1.z, r1, c26
dp4 oT1.y, r1, c25
dp4 oT1.x, r1, c24
dp4 oT2.z, r1, c30
dp4 oT2.y, r1, c29
dp4 oT2.x, r1, c28
dp4 oT3.z, r1, c34
dp4 oT3.y, r1, c33
dp4 oT3.x, r1, c32
mul r0.xyz, r0, c37.w
dp3 r1.x, r0, c12
dp3 r1.y, r0, c13
mov r1.w, c43.x
dp3 r1.z, r0, c14
dp4 oPos.w, r2, c7
dp4 oPos.z, r2, c6
dp4 oPos.y, r2, c5
dp4 oPos.x, r2, c4
dp4 oT6.z, r1, c18
dp4 oT6.y, r1, c17
dp4 oT6.x, r1, c16
mad oT5.xy, v3, c42, c42.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightShadowData]
Vector 2 [_LightSplitsNear]
Vector 3 [_LightSplitsFar]
Float 4 [_ShadowOffsetScale]
Float 5 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_BumpSpecMap] 2D
SetTexture 2 [_ShadowMapTexture] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 30 ALU, 3 TEX
PARAM c[7] = { program.local[0..5],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0.w, fragment.texcoord[5], texture[0], 2D;
TEX R0.z, fragment.texcoord[5], texture[1], 2D;
MUL R3.xyz, fragment.texcoord[6], c[4].x;
SLT R0.w, R0, c[5].x;
MAD R4.xyz, R3, R0.z, fragment.texcoord[1];
SLT R2, fragment.texcoord[4].w, c[3];
SGE R1, fragment.texcoord[4].w, c[2];
MUL R1, R1, R2;
MAD R2.xyz, R3, R0.z, fragment.texcoord[0];
MUL R4.xyz, R1.y, R4;
MAD R4.xyz, R1.x, R2, R4;
MAD R2.xyz, R3, R0.z, fragment.texcoord[2];
MAD R1.xyz, R1.z, R2, R4;
MAD R0.xyz, R3, R0.z, fragment.texcoord[3];
MAD R0.xyz, R0, R1.w, R1;
MAD_SAT R1.y, fragment.texcoord[4].w, c[1].z, c[1].w;
MOV result.color.y, c[6].x;
TEX R0.x, R0, texture[2], 2D;
KIL -R0.w;
ADD R0.z, R0.x, -R0;
MOV R0.x, c[6];
CMP R1.x, R0.z, c[1], R0;
MUL R0.y, -fragment.texcoord[4].w, c[0].w;
ADD R0.y, R0, c[6].x;
MUL R0.xy, R0.y, c[6];
FRC R0.zw, R0.xyxy;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[6].z, R0.z;
ADD_SAT result.color.x, R1, R1.y;
MOV result.color.zw, R0.xyxy;
END
# 30 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightShadowData]
Vector 2 [_LightSplitsNear]
Vector 3 [_LightSplitsFar]
Float 4 [_ShadowOffsetScale]
Float 5 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_BumpSpecMap] 2D
SetTexture 2 [_ShadowMapTexture] 2D
"ps_2_0
; 32 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c6, 0.00000000, 1.00000000, 255.00000000, 0.00392157
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4.xyzw
dcl t5.xy
dcl t6.xyz
texld r1, t5, s0
texld r4, t5, s1
mul r1.xyz, t6, c4.x
add r2, t4.w, -c3
add r0, t4.w, -c2
mad r3.xyz, r1, r4.z, t1
cmp r2, r2, c6.x, c6.y
cmp r0, r0, c6.y, c6.x
mul r0, r0, r2
mul r3.xyz, r0.y, r3
mad r2.xyz, r1, r4.z, t0
mad r2.xyz, r0.x, r2, r3
mad r3.xyz, r1, r4.z, t2
add_pp r0.x, r1.w, -c5
mad r2.xyz, r0.z, r3, r2
mad r1.xyz, r1, r4.z, t3
mad r2.xyz, r1, r0.w, r2
cmp r0.x, r0, c6, c6.y
mov_pp r1, -r0.x
texld r0, r2, s2
texkill r1.xyzw
mul r1.x, -t4.w, c0.w
mov r2.x, c1
add r0.x, r0, -r2.z
cmp r0.x, r0, c6.y, r2
add r1.x, r1, c6.y
mul r2.xy, r1.x, c6.yzxw
mad_sat r1.x, t4.w, c1.z, c1.w
frc r2.xy, r2
add_sat r0.x, r0, r1
mov r1.y, r2
mad r1.x, -r2.y, c6.w, r2
mov r0.w, r1.y
mov r0.z, r1.x
mov r0.y, c6
mov_pp oC0, r0
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightShadowData]
Vector 2 [_LightSplitsNear]
Vector 3 [_LightSplitsFar]
Float 4 [_ShadowOffsetScale]
Float 5 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_BumpSpecMap] 2D
SetTexture 2 [_ShadowMapTexture] 2D
"ps_2_0
; 33 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c6, 0.00000000, 1.00000000, 255.00000000, 0.00392157
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4.xyzw
dcl t5.xy
dcl t6.xyz
texld r2, t5, s0
texld r4, t5, s1
mul r2.xyz, t6, c4.x
add r1, t4.w, -c3
add r0, t4.w, -c2
cmp r1, r1, c6.x, c6.y
cmp r0, r0, c6.y, c6.x
mul r0, r0, r1
mad r3.xyz, r2, r4.z, t1
mad r1.xyz, r2, r4.z, t0
mul r3.xyz, r0.y, r3
mad r3.xyz, r0.x, r1, r3
mad r1.xyz, r2, r4.z, t2
add_pp r0.x, r2.w, -c5
mad r2.xyz, r2, r4.z, t3
mad r1.xyz, r0.z, r1, r3
mad r1.xyz, r2, r0.w, r1
cmp r0.x, r0, c6, c6.y
mov_pp r0, -r0.x
mov r1.w, c6.y
mul r2.x, -t4.w, c0.w
add r2.x, r2, c6.y
mul r2.xy, r2.x, c6.yzxw
frc r2.xy, r2
texkill r0.xyzw
texldp r1, r1, s2
mov r0.x, c1
add r0.x, c6.y, -r0
mad r0.x, r1, r0, c1
mad_sat r1.x, t4.w, c1.z, c1.w
add_sat r0.x, r0, r1
mov r1.y, r2
mad r1.x, -r2.y, c6.w, r2
mov r0.w, r1.y
mov r0.z, r1.x
mov r0.y, c6
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightShadowData]
Vector 2 [unity_ShadowFadeCenterAndType]
Vector 3 [unity_ShadowSplitSpheres0]
Vector 4 [unity_ShadowSplitSpheres1]
Vector 5 [unity_ShadowSplitSpheres2]
Vector 6 [unity_ShadowSplitSpheres3]
Vector 7 [unity_ShadowSplitSqRadii]
Float 8 [_ShadowOffsetScale]
Float 9 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_BumpSpecMap] 2D
SetTexture 2 [_ShadowMapTexture] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 41 ALU, 3 TEX
PARAM c[11] = { program.local[0..9],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0.w, fragment.texcoord[5], texture[0], 2D;
TEX R0.z, fragment.texcoord[5], texture[1], 2D;
ADD R1.xyz, fragment.texcoord[4], -c[3];
ADD R3.xyz, fragment.texcoord[4], -c[6];
SLT R0.w, R0, c[9].x;
DP3 R1.x, R1, R1;
ADD R2.xyz, fragment.texcoord[4], -c[4];
DP3 R1.y, R2, R2;
ADD R2.xyz, fragment.texcoord[4], -c[5];
DP3 R1.z, R2, R2;
DP3 R1.w, R3, R3;
MUL R2.xyz, fragment.texcoord[6], c[8].x;
SLT R1, R1, c[7];
MAD R3.xyz, R2, R0.z, fragment.texcoord[1];
ADD_SAT R1.yzw, R1, -R1.xxyz;
MUL R4.xyz, R1.y, R3;
MAD R3.xyz, R2, R0.z, fragment.texcoord[0];
MAD R4.xyz, R1.x, R3, R4;
MAD R3.xyz, R2, R0.z, fragment.texcoord[2];
MAD R0.xyz, R2, R0.z, fragment.texcoord[3];
MAD R1.xyz, R1.z, R3, R4;
MAD R0.xyz, R0, R1.w, R1;
ADD R2.xyz, -fragment.texcoord[4], c[2];
MOV result.color.y, c[10].x;
TEX R0.x, R0, texture[2], 2D;
KIL -R0.w;
ADD R0.y, R0.x, -R0.z;
MOV R0.x, c[10];
CMP R1.x, R0.y, c[1], R0;
DP3 R0.y, R2, R2;
RSQ R0.y, R0.y;
RCP R0.z, R0.y;
MAD_SAT R1.y, R0.z, c[1].z, c[1].w;
MUL R0.x, -fragment.texcoord[4].w, c[0].w;
ADD R0.x, R0, c[10];
MUL R0.xy, R0.x, c[10];
FRC R0.zw, R0.xyxy;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[10].z, R0.z;
ADD_SAT result.color.x, R1, R1.y;
MOV result.color.zw, R0.xyxy;
END
# 41 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightShadowData]
Vector 2 [unity_ShadowFadeCenterAndType]
Vector 3 [unity_ShadowSplitSpheres0]
Vector 4 [unity_ShadowSplitSpheres1]
Vector 5 [unity_ShadowSplitSpheres2]
Vector 6 [unity_ShadowSplitSpheres3]
Vector 7 [unity_ShadowSplitSqRadii]
Float 8 [_ShadowOffsetScale]
Float 9 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_BumpSpecMap] 2D
SetTexture 2 [_ShadowMapTexture] 2D
"ps_2_0
; 45 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c10, 0.00000000, 1.00000000, 255.00000000, 0.00392157
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4
dcl t5.xy
dcl t6.xyz
texld r1, t5, s0
texld r5, t5, s1
add r2.xyz, t4, -c6
add r0.xyz, t4, -c3
dp3 r0.w, r2, r2
dp3 r0.x, r0, r0
add r1.xyz, t4, -c4
dp3 r0.y, r1, r1
add r1.xyz, t4, -c5
dp3 r0.z, r1, r1
mul r1.xyz, t6, c8.x
add r0, r0, -c7
cmp r0, r0, c10.x, c10.y
mad r3.xyz, r1, r5.z, t1
mov r2.x, r0.y
mov r2.y, r0.z
mov r2.z, r0.w
add_sat r2.xyz, r2, -r0
mul r4.xyz, r2.x, r3
mad r3.xyz, r1, r5.z, t0
mad r3.xyz, r0.x, r3, r4
mad r4.xyz, r1, r5.z, t2
add_pp r0.x, r1.w, -c9
cmp r0.x, r0, c10, c10.y
mad r1.xyz, r1, r5.z, t3
mad r3.xyz, r2.y, r4, r3
mad r2.xyz, r1, r2.z, r3
mov_pp r1, -r0.x
texld r0, r2, s2
texkill r1.xyzw
add r0.x, r0, -r2.z
mov r1.x, c1
add r2.xyz, -t4, c2
cmp r0.x, r0, c10.y, r1
dp3 r1.x, r2, r2
mul r2.x, -t4.w, c0.w
rsq r1.x, r1.x
add r2.x, r2, c10.y
rcp r1.x, r1.x
mad_sat r1.x, r1, c1.z, c1.w
mul r2.xy, r2.x, c10.yzxw
frc r2.xy, r2
add_sat r0.x, r0, r1
mov r1.y, r2
mad r1.x, -r2.y, c10.w, r2
mov r0.w, r1.y
mov r0.z, r1.x
mov r0.y, c10
mov_pp oC0, r0
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightShadowData]
Vector 2 [unity_ShadowFadeCenterAndType]
Vector 3 [unity_ShadowSplitSpheres0]
Vector 4 [unity_ShadowSplitSpheres1]
Vector 5 [unity_ShadowSplitSpheres2]
Vector 6 [unity_ShadowSplitSpheres3]
Vector 7 [unity_ShadowSplitSqRadii]
Float 8 [_ShadowOffsetScale]
Float 9 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_BumpSpecMap] 2D
SetTexture 2 [_ShadowMapTexture] 2D
"ps_2_0
; 46 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c10, 0.00000000, 1.00000000, 255.00000000, 0.00392157
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4
dcl t5.xy
dcl t6.xyz
texld r1, t5, s0
texld r5, t5, s1
add r2.xyz, t4, -c6
add r0.xyz, t4, -c3
dp3 r0.w, r2, r2
dp3 r0.x, r0, r0
add r1.xyz, t4, -c4
dp3 r0.y, r1, r1
add r1.xyz, t4, -c5
dp3 r0.z, r1, r1
mul r1.xyz, t6, c8.x
add r0, r0, -c7
cmp r0, r0, c10.x, c10.y
mad r3.xyz, r1, r5.z, t1
mov r2.x, r0.y
mov r2.y, r0.z
mov r2.z, r0.w
add_sat r2.xyz, r2, -r0
mul r4.xyz, r2.x, r3
mad r3.xyz, r1, r5.z, t0
mad r3.xyz, r0.x, r3, r4
mad r0.xyz, r1, r5.z, t2
mad r3.xyz, r2.y, r0, r3
add_pp r0.x, r1.w, -c9
mad r1.xyz, r1, r5.z, t3
mad r1.xyz, r1, r2.z, r3
cmp r0.x, r0, c10, c10.y
mov_pp r0, -r0.x
mov r1.w, c10.y
add r2.xyz, -t4, c2
texkill r0.xyzw
texldp r1, r1, s2
mov r0.x, c1
add r0.x, c10.y, -r0
mad r0.x, r1, r0, c1
dp3 r1.x, r2, r2
mul r2.x, -t4.w, c0.w
rsq r1.x, r1.x
add r2.x, r2, c10.y
rcp r1.x, r1.x
mad_sat r1.x, r1, c1.z, c1.w
mul r2.xy, r2.x, c10.yzxw
frc r2.xy, r2
add_sat r0.x, r0, r1
mov r1.y, r2
mad r1.x, -r2.y, c10.w, r2
mov r0.w, r1.y
mov r0.z, r1.x
mov r0.y, c10
mov_pp oC0, r0
"
}
}
 }
}
SubShader { 
 Tags { "IGNOREPROJECTOR"="True" "RenderType"="TreeLeaf" }
 Pass {
  Tags { "IGNOREPROJECTOR"="True" "RenderType"="TreeLeaf" }
  Lighting On
  AlphaTest Greater [_Cutoff]
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 13 [_Object2World]
Vector 10 [_Time]
Vector 11 [unity_LightColor0]
Vector 12 [unity_LightColor1]
Vector 21 [unity_LightColor2]
Vector 22 [unity_LightColor3]
Vector 23 [unity_LightPosition0]
Vector 24 [unity_LightPosition1]
Vector 25 [unity_LightPosition2]
Vector 26 [unity_LightPosition3]
Vector 27 [unity_LightAtten0]
Vector 28 [unity_LightAtten1]
Vector 29 [unity_LightAtten2]
Vector 30 [unity_LightAtten3]
Vector 31 [_Scale]
Vector 32 [_SquashPlaneNormal]
Float 33 [_SquashAmount]
Vector 34 [_Wind]
"!!ARBvp1.0
# 105 ALU
PARAM c[37] = { { 0, 1, 2, -0.5 },
		state.lightmodel.ambient,
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[10..16],
		state.matrix.modelview[0].invtrans,
		program.local[21..34],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 3, 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0, vertex.normal.y, c[18];
MAD R1, vertex.normal.x, c[17], R0;
ADD R0.xyz, R1, c[0].x;
ABS R2.x, vertex.attrib[14].w;
ADD R3.w, -R2.x, c[0].y;
MAD R0.xyz, R0, R3.w, vertex.position;
MAD R1, vertex.normal.z, c[19], R1;
ADD R2, R1, c[0].x;
DP4 R2.w, R2, R2;
MOV R0.w, c[0].y;
DP3 R0.w, R0.w, c[16];
MUL R3.xyz, R0, c[31];
ADD R0.w, vertex.color.x, R0;
ADD R0.x, vertex.color.y, R0.w;
MOV R0.y, R0.w;
DP3 R0.x, R3, R0.x;
ADD R0.xy, R0, c[10].y;
MUL R0, R0.xxyy, c[35];
FRC R0, R0;
MAD R0, R0, c[0].z, c[0].w;
FRC R0, R0;
MAD R0, R0, c[0].z, -c[0].y;
ABS R1, R0;
MUL R0, -R1, c[0].z;
MUL R1, R1, R1;
ADD R0, R0, c[36].x;
MUL R0, R1, R0;
ADD R4.xy, R0.xzzw, R0.ywzw;
RSQ R2.w, R2.w;
MAD R1.xyz, R2.w, R2, -vertex.normal;
MAD R2.xyz, R3.w, R1, vertex.normal;
DP3 R2.w, R2, R2;
MUL R0.xyz, R4.y, c[34];
MUL R1.xyz, vertex.texcoord[1].y, R0;
MUL R4.zw, vertex.color.y, R2.xyxz;
MOV R1.w, c[0].y;
MUL R0.xz, R4.zyww, c[36].z;
MUL R0.y, vertex.texcoord[1], c[36];
MAD R0.xyz, R4.xyxw, R0, R1;
MAD R0.xyz, R0, c[34].w, R3;
MAD R1.xyz, vertex.texcoord[1].x, c[34], R0;
DP3 R0.x, R1, c[32];
RSQ R2.w, R2.w;
MUL R4.xyz, R2.w, R2;
ADD R0.x, R0, c[32].w;
MUL R0.xyz, R0.x, c[32];
ADD R1.xyz, -R0, R1;
MAD R1.xyz, R0, c[33].x, R1;
DP3 R2.z, R4, c[19];
DP3 R2.y, R4, c[18];
DP3 R2.x, R4, c[17];
DP4 R0.z, R1, c[4];
DP4 R0.x, R1, c[2];
DP4 R0.y, R1, c[3];
MAD R3.xyz, -R0, c[24].w, c[24];
DP3 R0.w, R3, R3;
RSQ R3.w, R0.w;
MUL R3.xyz, R3.w, R3;
DP3 R2.w, R2, R3;
MUL R3.x, R0.w, c[28].z;
MAX R0.w, R2, c[0].x;
ADD R2.w, R3.x, c[0].y;
MAD R3.xyz, -R0, c[23].w, c[23];
RCP R2.w, R2.w;
DP3 R3.w, R3, R3;
MUL R2.w, R0, R2;
RSQ R0.w, R3.w;
MUL R3.xyz, R0.w, R3;
DP3 R0.w, R2, R3;
MUL R3.w, R3, c[27].z;
ADD R3.w, R3, c[0].y;
RCP R3.x, R3.w;
MAX R0.w, R0, c[0].x;
MUL R0.w, R0, R3.x;
MAD R3.xyz, -R0, c[25].w, c[25];
MUL R4.xyz, R0.w, c[11];
DP3 R0.w, R3, R3;
RSQ R3.w, R0.w;
ADD R4.xyz, R4, c[1];
MAD R4.xyz, R2.w, c[12], R4;
MUL R2.w, R0, c[29].z;
MUL R3.xyz, R3.w, R3;
DP3 R0.w, R2, R3;
ADD R2.w, R2, c[0].y;
MAX R0.w, R0, c[0].x;
RCP R2.w, R2.w;
MUL R2.w, R0, R2;
MAD R0.xyz, -R0, c[26].w, c[26];
DP3 R0.w, R0, R0;
MAD R3.xyz, R2.w, c[21], R4;
RSQ R2.w, R0.w;
MUL R0.xyz, R2.w, R0;
DP3 R0.x, R2, R0;
MUL R0.w, R0, c[30].z;
ADD R0.w, R0, c[0].y;
RCP R0.y, R0.w;
MAX R0.x, R0, c[0];
MUL R0.x, R0, R0.y;
MAD result.color.xyz, R0.x, c[22], R3;
DP4 result.position.w, R1, c[9];
DP4 result.position.z, R1, c[8];
DP4 result.position.y, R1, c[7];
DP4 result.position.x, R1, c[6];
MOV result.texcoord[0], vertex.texcoord[0];
MOV result.color.w, c[0].y;
END
# 105 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [glstate_matrix_invtrans_modelview0]
Matrix 12 [_Object2World]
Vector 16 [glstate_lightmodel_ambient]
Vector 17 [_Time]
Vector 18 [unity_LightColor0]
Vector 19 [unity_LightColor1]
Vector 20 [unity_LightColor2]
Vector 21 [unity_LightColor3]
Vector 22 [unity_LightPosition0]
Vector 23 [unity_LightPosition1]
Vector 24 [unity_LightPosition2]
Vector 25 [unity_LightPosition3]
Vector 26 [unity_LightAtten0]
Vector 27 [unity_LightAtten1]
Vector 28 [unity_LightAtten2]
Vector 29 [unity_LightAtten3]
Vector 30 [_Scale]
Vector 31 [_SquashPlaneNormal]
Float 32 [_SquashAmount]
Vector 33 [_Wind]
"vs_2_0
; 108 ALU
def c34, 0.00000000, 1.00000000, 2.00000000, -0.50000000
def c35, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c36, 2.00000000, -1.00000000, 3.00000000, 0.30000001
def c37, 0.10000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
abs r1.w, v1
mul r0, v2.y, c9
mad r0, v2.x, c8, r0
add r1.xyz, r0, c34.x
add r3.w, -r1, c34.y
mad r1.xyz, r1, r3.w, v0
mov r2.xyz, c15
dp3 r1.w, c34.y, r2
mad r0, v2.z, c10, r0
add r2, r0, c34.x
dp4 r2.w, r2, r2
mul r3.xyz, r1, c30
add r1.w, v5.x, r1
add r1.x, v5.y, r1.w
mov r1.y, r1.w
dp3 r1.x, r3, r1.x
add r1.xy, r1, c17.y
mul r1, r1.xxyy, c35
frc r1, r1
mad r1, r1, c34.z, c34.w
frc r1, r1
mad r1, r1, c36.x, c36.y
abs r1, r1
mul r0, r1, r1
mad r1, -r1, c36.x, c36.z
mul r0, r0, r1
add r4.xy, r0.xzzw, r0.ywzw
rsq r2.w, r2.w
mad r1.xyz, r2.w, r2, -v2
mad r2.xyz, r3.w, r1, v2
dp3 r2.w, r2, r2
mul r0.xyz, r4.y, c33
mul r1.xyz, v4.y, r0
mul r4.zw, v5.y, r2.xyxz
mov r1.w, c34.y
mul r0.xz, r4.zyww, c37.x
mul r0.y, v4, c36.w
mad r0.xyz, r4.xyxw, r0, r1
mad r0.xyz, r0, c33.w, r3
mad r1.xyz, v4.x, c33, r0
dp3 r0.x, r1, c31
rsq r2.w, r2.w
mul r4.xyz, r2.w, r2
add r0.x, r0, c31.w
mul r0.xyz, r0.x, c31
add r1.xyz, -r0, r1
mad r1.xyz, r0, c32.x, r1
dp3 r2.z, r4, c10
dp3 r2.y, r4, c9
dp3 r2.x, r4, c8
dp4 r0.z, r1, c2
dp4 r0.x, r1, c0
dp4 r0.y, r1, c1
mad r3.xyz, -r0, c23.w, c23
dp3 r0.w, r3, r3
rsq r3.w, r0.w
mul r3.xyz, r3.w, r3
dp3 r2.w, r2, r3
mul r3.x, r0.w, c27.z
max r0.w, r2, c34.x
add r2.w, r3.x, c34.y
mad r3.xyz, -r0, c22.w, c22
rcp r2.w, r2.w
dp3 r3.w, r3, r3
mul r2.w, r0, r2
rsq r0.w, r3.w
mul r3.xyz, r0.w, r3
dp3 r0.w, r2, r3
mul r3.w, r3, c26.z
add r3.w, r3, c34.y
rcp r3.x, r3.w
max r0.w, r0, c34.x
mul r0.w, r0, r3.x
mad r3.xyz, -r0, c24.w, c24
mul r4.xyz, r0.w, c18
dp3 r0.w, r3, r3
rsq r3.w, r0.w
add r4.xyz, r4, c16
mad r4.xyz, r2.w, c19, r4
mul r2.w, r0, c28.z
mul r3.xyz, r3.w, r3
dp3 r0.w, r2, r3
add r2.w, r2, c34.y
max r0.w, r0, c34.x
rcp r2.w, r2.w
mul r2.w, r0, r2
mad r0.xyz, -r0, c25.w, c25
dp3 r0.w, r0, r0
mad r3.xyz, r2.w, c20, r4
rsq r2.w, r0.w
mul r0.xyz, r2.w, r0
dp3 r0.x, r2, r0
mul r0.w, r0, c29.z
add r0.w, r0, c34.y
rcp r0.y, r0.w
max r0.x, r0, c34
mul r0.x, r0, r0.y
mad oD0.xyz, r0.x, c21, r3
dp4 oPos.w, r1, c7
dp4 oPos.z, r1, c6
dp4 oPos.y, r1, c5
dp4 oPos.x, r1, c4
mov oT0, v3
mov oD0.w, c34.y
"
}
}
  SetTexture [_MainTex] { combine texture * primary double, texture alpha }
  SetTexture [_MainTex] { ConstantColor [_Color] combine previous * constant, previous alpha }
 }
}
SubShader { 
 Tags { "RenderType"="TreeLeaf" }
 Pass {
  Tags { "RenderType"="TreeLeaf" }
  Lighting On
  Material {
   Ambient (1,1,1,1)
   Diffuse (1,1,1,1)
  }
  AlphaTest Greater [_Cutoff]
  ColorMask RGB
  SetTexture [_MainTex] { combine texture * primary double, texture alpha }
  SetTexture [_MainTex] { ConstantColor [_Color] combine previous * constant, previous alpha }
 }
}
Dependency "BillboardShader" = "Hidden/Nature/Tree Creator Leaves Rendertex"
}