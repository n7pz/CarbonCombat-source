Shader "Hidden/Nature/Tree Creator Bark Optimized" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
 _BumpSpecMap ("Normalmap (GA) Spec (R)", 2D) = "bump" {}
 _TranslucencyMap ("Trans (RGB) Gloss(A)", 2D) = "white" {}
 _SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
 _Scale ("Scale", Vector) = (1,1,1,1)
 _SquashAmount ("Squash", Float) = 1
}
SubShader { 
 LOD 200
 Tags { "RenderType"="TreeBark" }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardBase" "RenderType"="TreeBark" }
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [unity_Scale]
Vector 15 [_WorldSpaceCameraPos]
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [unity_SHAr]
Vector 18 [unity_SHAg]
Vector 19 [unity_SHAb]
Vector 20 [unity_SHBr]
Vector 21 [unity_SHBg]
Vector 22 [unity_SHBb]
Vector 23 [unity_SHC]
Vector 24 [_Scale]
Vector 25 [_SquashPlaneNormal]
Float 26 [_SquashAmount]
Vector 27 [_Wind]
Vector 28 [_MainTex_ST]
"!!ARBvp1.0
# 82 ALU
PARAM c[31] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..28],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
MUL R2.xyz, vertex.position, c[24];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[13].y;
MUL R0, R0.xxyy, c[29];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R1.xyz, R3.y, c[27];
MUL R0.x, vertex.color.y, c[30].y;
MOV R1.w, c[0].x;
MOV R0.w, c[0].x;
MUL R1.xyz, vertex.texcoord[1].y, R1;
MUL R0.xz, R0.x, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[30].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[27].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[27], R0;
DP3 R0.x, R1, c[25];
ADD R0.x, R0, c[25].w;
MUL R0.xyz, R0.x, c[25];
ADD R1.xyz, -R0, R1;
MAD R1.xyz, R0, c[26].x, R1;
DP3 R0.y, vertex.attrib[14], vertex.attrib[14];
RSQ R0.y, R0.y;
DP3 R0.x, vertex.normal, vertex.normal;
RSQ R0.x, R0.x;
MUL R2.xyz, R0.x, vertex.normal;
MUL R3.xyz, R0.y, vertex.attrib[14];
MUL R0.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R0;
MOV R0.xyz, c[15];
DP4 R5.z, R0, c[11];
DP4 R5.x, R0, c[9];
DP4 R5.y, R0, c[10];
MAD R0.xyz, R5, c[14].w, -R1;
MUL R4.xyz, R4, vertex.attrib[14].w;
MOV R0.w, c[0].x;
DP3 result.texcoord[3].z, R2, R0;
DP3 result.texcoord[3].y, R4, R0;
DP3 result.texcoord[3].x, R3, R0;
DP4 result.position.w, R1, c[4];
DP4 result.position.z, R1, c[3];
DP4 result.position.y, R1, c[2];
DP4 result.position.x, R1, c[1];
MUL R1.xyz, R2, c[14].w;
DP3 R2.w, R1, c[6];
MOV R0.y, R2.w;
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R5.z, R0, c[19];
DP4 R5.y, R0, c[18];
DP4 R5.x, R0, c[17];
MUL R2.w, R2, R2;
DP4 R0.w, R1, c[22];
DP4 R0.z, R1, c[21];
DP4 R0.y, R1, c[20];
ADD R1.xyz, R5, R0.yzww;
MAD R0.x, R0, R0, -R2.w;
MUL R5.xyz, R0.x, c[23];
MOV R0, c[16];
ADD result.texcoord[2].xyz, R1, R5;
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 result.texcoord[1].y, R1, R4;
DP3 result.texcoord[1].z, R2, R1;
DP3 result.texcoord[1].x, R1, R3;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.color.w, vertex.color;
END
# 82 instructions, 6 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [unity_Scale]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_WorldSpaceLightPos0]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [_Scale]
Vector 24 [_SquashPlaneNormal]
Float 25 [_SquashAmount]
Vector 26 [_Wind]
Vector 27 [_MainTex_ST]
"vs_2_0
; 88 ALU
def c28, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c29, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c30, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c28.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mul r2.xyz, v0, c23
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c12.y
mul r0, r0.xxyy, c29
frc r0, r0
mad r0, r0, c28.y, c28.z
frc r0, r0
mad r0, r0, c28.y, c28.w
abs r0, r0
mad r1, -r0, c30.x, c30.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r1.xyz, r3.y, c26
mul r0.x, v5.y, c30.w
mov r1.w, c28.x
mov r0.w, c28.x
mul r1.xyz, v4.y, r1
mul r0.xz, r0.x, v2
mul r0.y, v4, c30.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c26.w, r2
mad r1.xyz, v4.x, c26, r0
dp3 r0.x, r1, c24
add r0.x, r0, c24.w
mul r0.xyz, r0.x, c24
add r1.xyz, -r0, r1
mad r1.xyz, r0, c25.x, r1
dp3 r0.y, v1, v1
rsq r0.y, r0.y
dp3 r0.x, v2, v2
rsq r0.x, r0.x
mul r2.xyz, r0.x, v2
mul r3.xyz, r0.y, v1
mul r0.xyz, r2.zxyw, r3.yzxw
mad r4.xyz, r2.yzxw, r3.zxyw, -r0
mov r0.xyz, c14
dp4 r5.z, r0, c10
dp4 r5.x, r0, c8
dp4 r5.y, r0, c9
mad r0.xyz, r5, c13.w, -r1
mul r4.xyz, r4, v1.w
mov r0.w, c28.x
dp3 oT3.z, r2, r0
dp3 oT3.y, r4, r0
dp3 oT3.x, r3, r0
dp4 oPos.w, r1, c3
dp4 oPos.z, r1, c2
dp4 oPos.y, r1, c1
dp4 oPos.x, r1, c0
mul r1.xyz, r2, c13.w
dp3 r2.w, r1, c5
mov r0.y, r2.w
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mul r1, r0.xyzz, r0.yzzx
dp4 r5.z, r0, c18
dp4 r5.y, r0, c17
dp4 r5.x, r0, c16
mul r2.w, r2, r2
dp4 r0.w, r1, c21
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
add r1.xyz, r5, r0.yzww
mad r0.x, r0, r0, -r2.w
mul r5.xyz, r0.x, c22
add oT2.xyz, r1, r5
mov r0, c10
dp4 r5.z, c15, r0
mov r1, c8
mov r0, c9
dp4 r5.x, c15, r1
dp4 r5.y, c15, r0
dp3 oT1.y, r5, r4
dp3 oT1.z, r2, r5
dp3 oT1.x, r5, r3
mov oD0.xyz, c28.x
mad oT0.xy, v3, c27, c27.zwzw
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
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_ProjectionParams]
Vector 15 [unity_Scale]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_WorldSpaceLightPos0]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [_Scale]
Vector 26 [_SquashPlaneNormal]
Float 27 [_SquashAmount]
Vector 28 [_Wind]
Vector 29 [_MainTex_ST]
"!!ARBvp1.0
# 87 ALU
PARAM c[32] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..29],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1, 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
MOV R4.w, c[0].x;
MUL R2.xyz, vertex.position, c[25];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[13].y;
MUL R0, R0.xxyy, c[30];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R1.xyz, R3.y, c[28];
MUL R0.x, vertex.color.y, c[31].y;
MUL R1.xyz, vertex.texcoord[1].y, R1;
MUL R0.xz, R0.x, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[31].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[28].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[28], R0;
DP3 R0.x, R1, c[26];
ADD R0.x, R0, c[26].w;
MUL R0.xyz, R0.x, c[26];
ADD R1.xyz, -R0, R1;
MAD R4.xyz, R0, c[27].x, R1;
DP4 R0.w, R4, c[4];
DP4 R0.z, R4, c[3];
DP4 R0.x, R4, c[1];
DP4 R0.y, R4, c[2];
MUL R1.xyz, R0.xyww, c[31].z;
MOV result.position, R0;
MUL R1.y, R1, c[14].x;
MOV result.texcoord[4].zw, R0;
DP3 R0.y, vertex.attrib[14], vertex.attrib[14];
RSQ R0.y, R0.y;
DP3 R0.x, vertex.normal, vertex.normal;
RSQ R0.x, R0.x;
MUL R2.xyz, R0.x, vertex.normal;
MUL R3.xyz, R0.y, vertex.attrib[14];
ADD result.texcoord[4].xy, R1, R1.z;
MUL R1.xyz, R2.zxyw, R3.yzxw;
MOV R0.w, c[0].x;
MOV R0.xyz, c[16];
DP4 R5.z, R0, c[11];
DP4 R5.x, R0, c[9];
DP4 R5.y, R0, c[10];
MAD R0.xyz, R5, c[15].w, -R4;
MAD R1.xyz, R2.yzxw, R3.zxyw, -R1;
MUL R4.xyz, R1, vertex.attrib[14].w;
MUL R1.xyz, R2, c[15].w;
MOV R0.w, c[0].x;
DP3 result.texcoord[3].z, R2, R0;
DP3 result.texcoord[3].y, R4, R0;
DP3 result.texcoord[3].x, R3, R0;
DP3 R2.w, R1, c[6];
MOV R0.y, R2.w;
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R5.z, R0, c[20];
DP4 R5.y, R0, c[19];
DP4 R5.x, R0, c[18];
MUL R2.w, R2, R2;
DP4 R0.w, R1, c[23];
DP4 R0.z, R1, c[22];
DP4 R0.y, R1, c[21];
ADD R1.xyz, R5, R0.yzww;
MAD R0.x, R0, R0, -R2.w;
MUL R5.xyz, R0.x, c[24];
MOV R0, c[17];
ADD result.texcoord[2].xyz, R1, R5;
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 result.texcoord[1].y, R1, R4;
DP3 result.texcoord[1].z, R2, R1;
DP3 result.texcoord[1].x, R1, R3;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[29], c[29].zwzw;
MOV result.color.w, vertex.color;
END
# 87 instructions, 6 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_Scale]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_WorldSpaceLightPos0]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [_Scale]
Vector 26 [_SquashPlaneNormal]
Float 27 [_SquashAmount]
Vector 28 [_Wind]
Vector 29 [_MainTex_ST]
"vs_2_0
; 93 ALU
def c30, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c31, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c32, 2.00000000, 3.00000000, 0.30000001, 0.10000000
def c33, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c30.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mov r4.w, c30.x
mul r2.xyz, v0, c25
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c12.y
mul r0, r0.xxyy, c31
frc r0, r0
mad r0, r0, c30.y, c30.z
frc r0, r0
mad r0, r0, c30.y, c30.w
abs r0, r0
mad r1, -r0, c32.x, c32.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r1.xyz, r3.y, c28
mul r0.x, v5.y, c32.w
mul r1.xyz, v4.y, r1
mul r0.xz, r0.x, v2
mul r0.y, v4, c32.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c28.w, r2
mad r1.xyz, v4.x, c28, r0
dp3 r0.x, r1, c26
add r0.x, r0, c26.w
mul r0.xyz, r0.x, c26
add r1.xyz, -r0, r1
mad r4.xyz, r0, c27.x, r1
dp4 r0.w, r4, c3
dp4 r0.z, r4, c2
dp4 r0.x, r4, c0
dp4 r0.y, r4, c1
mul r1.xyz, r0.xyww, c33.x
mov oPos, r0
mul r1.y, r1, c13.x
mov oT4.zw, r0
dp3 r0.y, v1, v1
rsq r0.y, r0.y
dp3 r0.x, v2, v2
rsq r0.x, r0.x
mul r2.xyz, r0.x, v2
mul r3.xyz, r0.y, v1
mad oT4.xy, r1.z, c14.zwzw, r1
mul r1.xyz, r2.zxyw, r3.yzxw
mov r0.w, c30.x
mov r0.xyz, c16
dp4 r5.z, r0, c10
dp4 r5.x, r0, c8
dp4 r5.y, r0, c9
mad r0.xyz, r5, c15.w, -r4
mad r1.xyz, r2.yzxw, r3.zxyw, -r1
mul r4.xyz, r1, v1.w
mul r1.xyz, r2, c15.w
mov r0.w, c30.x
dp3 oT3.z, r2, r0
dp3 oT3.y, r4, r0
dp3 oT3.x, r3, r0
dp3 r2.w, r1, c5
mov r0.y, r2.w
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mul r1, r0.xyzz, r0.yzzx
dp4 r5.z, r0, c20
dp4 r5.y, r0, c19
dp4 r5.x, r0, c18
mul r2.w, r2, r2
dp4 r0.w, r1, c23
dp4 r0.z, r1, c22
dp4 r0.y, r1, c21
add r1.xyz, r5, r0.yzww
mad r0.x, r0, r0, -r2.w
mul r5.xyz, r0.x, c24
add oT2.xyz, r1, r5
mov r0, c10
dp4 r5.z, c17, r0
mov r1, c8
mov r0, c9
dp4 r5.x, c17, r1
dp4 r5.y, c17, r0
dp3 oT1.y, r5, r4
dp3 oT1.z, r2, r5
dp3 oT1.x, r5, r3
mov oD0.xyz, c30.x
mad oT0.xy, v3, c29, c29.zwzw
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
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [unity_Scale]
Vector 15 [_WorldSpaceCameraPos]
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [unity_4LightPosX0]
Vector 18 [unity_4LightPosY0]
Vector 19 [unity_4LightPosZ0]
Vector 20 [unity_4LightAtten0]
Vector 21 [unity_LightColor0]
Vector 22 [unity_LightColor1]
Vector 23 [unity_LightColor2]
Vector 24 [unity_LightColor3]
Vector 25 [unity_SHAr]
Vector 26 [unity_SHAg]
Vector 27 [unity_SHAb]
Vector 28 [unity_SHBr]
Vector 29 [unity_SHBg]
Vector 30 [unity_SHBb]
Vector 31 [unity_SHC]
Vector 32 [_Scale]
Vector 33 [_SquashPlaneNormal]
Float 34 [_SquashAmount]
Vector 35 [_Wind]
Vector 36 [_MainTex_ST]
"!!ARBvp1.0
# 113 ALU
PARAM c[39] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..36],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.w, vertex.color.x, R0.x;
MUL R0.xyz, vertex.position, c[32];
ADD R1.x, vertex.color.y, R0.w;
MOV R1.y, R0.w;
DP3 R1.x, R0, R1.x;
ADD R1.xy, R1, c[13].y;
MUL R1, R1.xxyy, c[37];
FRC R1, R1;
MAD R1, R1, c[0].y, c[0].z;
FRC R1, R1;
MAD R1, R1, c[0].y, -c[0].x;
ABS R2, R1;
MAD R1, -R2, c[0].y, c[0].w;
MUL R2, R2, R2;
MUL R1, R2, R1;
ADD R2.xy, R1.xzzw, R1.ywzw;
MUL R1.xyz, R2.y, c[35];
MUL R3.xyz, vertex.texcoord[1].y, R1;
MUL R0.w, vertex.color.y, c[38].y;
MOV R1.w, c[0].x;
MUL R1.xz, R0.w, vertex.normal;
MUL R1.y, vertex.texcoord[1], c[38].x;
MAD R1.xyz, R2.xyxw, R1, R3;
MAD R0.xyz, R1, c[35].w, R0;
MAD R0.xyz, vertex.texcoord[1].x, c[35], R0;
DP3 R0.w, R0, c[33];
ADD R0.w, R0, c[33];
MUL R1.xyz, R0.w, c[33];
ADD R0.xyz, -R1, R0;
MAD R1.xyz, R1, c[34].x, R0;
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
ADD R3, -R0.y, c[18];
ADD R2, -R0.x, c[17];
MUL R0, R3, R3;
MAD R4, R2, R2, R0;
DP3 R5.x, vertex.normal, vertex.normal;
RSQ R0.x, R5.x;
MUL R6.xyz, R0.x, vertex.normal;
MUL R7.xyz, R6, c[14].w;
DP3 R6.w, R7, c[6];
DP4 R0.y, R1, c[7];
ADD R0, -R0.y, c[19];
MAD R4, R0, R0, R4;
DP3 R7.w, R7, c[5];
MUL R3, R6.w, R3;
MAD R2, R7.w, R2, R3;
DP3 R3.x, R7, c[7];
MAD R0, R3.x, R0, R2;
MUL R5, R4, c[20];
MOV R7.x, R6.w;
MOV R7.y, R3.x;
MOV R7.z, c[0].x;
RSQ R2.x, R4.x;
RSQ R2.y, R4.y;
RSQ R2.z, R4.z;
RSQ R2.w, R4.w;
MUL R0, R0, R2;
ADD R2, R5, c[0].x;
RCP R2.x, R2.x;
RCP R2.y, R2.y;
RCP R2.w, R2.w;
RCP R2.z, R2.z;
MAX R0, R0, c[38].z;
MUL R0, R0, R2;
MUL R2.xyz, R0.y, c[22];
MAD R2.xyz, R0.x, c[21], R2;
MAD R0.xyz, R0.z, c[23], R2;
MAD R2.xyz, R0.w, c[24], R0;
MUL R0, R7.wxyy, R7.xyyw;
MUL R2.w, R6, R6;
DP4 R4.z, R0, c[30];
DP4 R4.y, R0, c[29];
DP4 R4.x, R0, c[28];
MAD R2.w, R7, R7, -R2;
MOV R0.w, c[0].x;
DP4 R3.z, R7.wxyz, c[27];
DP4 R3.y, R7.wxyz, c[26];
DP4 R3.x, R7.wxyz, c[25];
ADD R3.xyz, R3, R4;
MUL R0.xyz, R2.w, c[31];
ADD R0.xyz, R3, R0;
ADD result.texcoord[2].xyz, R0, R2;
DP3 R0.x, vertex.attrib[14], vertex.attrib[14];
RSQ R0.x, R0.x;
MUL R2.xyz, R0.x, vertex.attrib[14];
MUL R0.xyz, R6.zxyw, R2.yzxw;
MAD R3.xyz, R6.yzxw, R2.zxyw, -R0;
MOV R0.xyz, c[15];
MUL R3.xyz, R3, vertex.attrib[14].w;
DP4 result.position.w, R1, c[4];
DP4 result.position.z, R1, c[3];
DP4 result.position.y, R1, c[2];
DP4 result.position.x, R1, c[1];
DP4 R4.z, R0, c[11];
DP4 R4.x, R0, c[9];
DP4 R4.y, R0, c[10];
MAD R0.xyz, R4, c[14].w, -R1;
DP3 result.texcoord[3].z, R6, R0;
DP3 result.texcoord[3].y, R3, R0;
MOV R1, c[16];
DP3 result.texcoord[3].x, R2, R0;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
DP3 result.texcoord[1].y, R0, R3;
DP3 result.texcoord[1].z, R6, R0;
DP3 result.texcoord[1].x, R0, R2;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[36], c[36].zwzw;
MOV result.color.w, vertex.color;
END
# 113 instructions, 8 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [unity_Scale]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_WorldSpaceLightPos0]
Vector 16 [unity_4LightPosX0]
Vector 17 [unity_4LightPosY0]
Vector 18 [unity_4LightPosZ0]
Vector 19 [unity_4LightAtten0]
Vector 20 [unity_LightColor0]
Vector 21 [unity_LightColor1]
Vector 22 [unity_LightColor2]
Vector 23 [unity_LightColor3]
Vector 24 [unity_SHAr]
Vector 25 [unity_SHAg]
Vector 26 [unity_SHAb]
Vector 27 [unity_SHBr]
Vector 28 [unity_SHBg]
Vector 29 [unity_SHBb]
Vector 30 [unity_SHC]
Vector 31 [_Scale]
Vector 32 [_SquashPlaneNormal]
Float 33 [_SquashAmount]
Vector 34 [_Wind]
Vector 35 [_MainTex_ST]
"vs_2_0
; 119 ALU
def c36, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c37, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c38, 2.00000000, 3.00000000, 0.30000001, 0.10000000
def c39, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c36.x, r0
add r0.x, v5, r0
add r0.w, v5.y, r0.x
mov r1.y, r0.x
mul r0.xyz, v0, c31
dp3 r1.x, r0, r0.w
add r1.xy, r1, c12.y
mul r1, r1.xxyy, c37
frc r1, r1
mad r1, r1, c36.y, c36.z
frc r1, r1
mad r1, r1, c36.y, c36.w
abs r2, r1
mad r1, -r2, c38.x, c38.y
mul r2, r2, r2
mul r1, r2, r1
add r2.xy, r1.xzzw, r1.ywzw
mul r1.xyz, r2.y, c34
mul r3.xyz, v4.y, r1
mul r0.w, v5.y, c38
mov r1.w, c36.x
mul r1.xz, r0.w, v2
mul r1.y, v4, c38.z
mad r1.xyz, r2.xyxw, r1, r3
mad r0.xyz, r1, c34.w, r0
mad r0.xyz, v4.x, c34, r0
dp3 r0.w, r0, c32
add r0.w, r0, c32
mul r1.xyz, r0.w, c32
add r0.xyz, -r1, r0
mad r1.xyz, r1, c33.x, r0
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
add r3, -r0.y, c17
add r2, -r0.x, c16
mul r0, r3, r3
mad r4, r2, r2, r0
dp3 r5.x, v2, v2
rsq r0.x, r5.x
mul r6.xyz, r0.x, v2
mul r7.xyz, r6, c13.w
dp3 r6.w, r7, c5
dp4 r0.y, r1, c6
add r0, -r0.y, c18
mad r4, r0, r0, r4
dp3 r7.w, r7, c4
mul r3, r6.w, r3
mad r2, r7.w, r2, r3
dp3 r3.x, r7, c6
mad r0, r3.x, r0, r2
mul r5, r4, c19
mov r7.x, r6.w
mov r7.y, r3.x
mov r7.z, c36.x
rsq r2.x, r4.x
rsq r2.y, r4.y
rsq r2.z, r4.z
rsq r2.w, r4.w
mul r0, r0, r2
add r2, r5, c36.x
rcp r2.x, r2.x
rcp r2.y, r2.y
rcp r2.w, r2.w
rcp r2.z, r2.z
max r0, r0, c39.x
mul r0, r0, r2
mul r2.xyz, r0.y, c21
mad r2.xyz, r0.x, c20, r2
mad r0.xyz, r0.z, c22, r2
mad r2.xyz, r0.w, c23, r0
mul r0, r7.wxyy, r7.xyyw
mul r2.w, r6, r6
dp4 r4.z, r0, c29
dp4 r4.y, r0, c28
dp4 r4.x, r0, c27
mad r2.w, r7, r7, -r2
mul r0.xyz, r2.w, c30
mov r2.w, c36.x
dp4 r3.z, r7.wxyz, c26
dp4 r3.y, r7.wxyz, c25
dp4 r3.x, r7.wxyz, c24
add r3.xyz, r3, r4
add r0.xyz, r3, r0
add oT2.xyz, r0, r2
dp3 r0.x, v1, v1
rsq r0.x, r0.x
mul r0.xyz, r0.x, v1
mul r2.xyz, r6.zxyw, r0.yzxw
mad r3.xyz, r6.yzxw, r0.zxyw, -r2
mov r2.xyz, c14
dp4 r4.z, r2, c10
dp4 r4.x, r2, c8
dp4 r4.y, r2, c9
mad r2.xyz, r4, c13.w, -r1
mul r3.xyz, r3, v1.w
dp4 oPos.w, r1, c3
dp4 oPos.z, r1, c2
dp4 oPos.y, r1, c1
dp4 oPos.x, r1, c0
mov r1, c10
dp4 r4.z, c15, r1
mov r1, c9
dp4 r4.y, c15, r1
dp3 oT3.z, r6, r2
dp3 oT3.y, r3, r2
dp3 oT3.x, r0, r2
mov r2, c8
dp4 r4.x, c15, r2
dp3 oT1.y, r4, r3
dp3 oT1.z, r6, r4
dp3 oT1.x, r4, r0
mov oD0.xyz, c36.x
mad oT0.xy, v3, c35, c35.zwzw
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
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_ProjectionParams]
Vector 15 [unity_Scale]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_WorldSpaceLightPos0]
Vector 18 [unity_4LightPosX0]
Vector 19 [unity_4LightPosY0]
Vector 20 [unity_4LightPosZ0]
Vector 21 [unity_4LightAtten0]
Vector 22 [unity_LightColor0]
Vector 23 [unity_LightColor1]
Vector 24 [unity_LightColor2]
Vector 25 [unity_LightColor3]
Vector 26 [unity_SHAr]
Vector 27 [unity_SHAg]
Vector 28 [unity_SHAb]
Vector 29 [unity_SHBr]
Vector 30 [unity_SHBg]
Vector 31 [unity_SHBb]
Vector 32 [unity_SHC]
Vector 33 [_Scale]
Vector 34 [_SquashPlaneNormal]
Float 35 [_SquashAmount]
Vector 36 [_Wind]
Vector 37 [_MainTex_ST]
"!!ARBvp1.0
# 119 ALU
PARAM c[40] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..37],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1, 0, 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.w, vertex.color.x, R0.x;
MUL R0.xyz, vertex.position, c[33];
ADD R1.x, vertex.color.y, R0.w;
MOV R1.y, R0.w;
DP3 R1.x, R0, R1.x;
ADD R1.xy, R1, c[13].y;
MUL R1, R1.xxyy, c[38];
FRC R1, R1;
MAD R1, R1, c[0].y, c[0].z;
FRC R1, R1;
MAD R1, R1, c[0].y, -c[0].x;
ABS R2, R1;
MAD R1, -R2, c[0].y, c[0].w;
MUL R2, R2, R2;
MUL R1, R2, R1;
ADD R2.xy, R1.xzzw, R1.ywzw;
MUL R1.xyz, R2.y, c[36];
MUL R3.xyz, vertex.texcoord[1].y, R1;
MUL R0.w, vertex.color.y, c[39].y;
MOV R1.w, c[0].x;
MUL R1.xz, R0.w, vertex.normal;
MUL R1.y, vertex.texcoord[1], c[39].x;
MAD R1.xyz, R2.xyxw, R1, R3;
MAD R0.xyz, R1, c[36].w, R0;
MAD R0.xyz, vertex.texcoord[1].x, c[36], R0;
DP3 R0.w, R0, c[34];
ADD R0.w, R0, c[34];
MUL R1.xyz, R0.w, c[34];
ADD R0.xyz, -R1, R0;
MAD R1.xyz, R1, c[35].x, R0;
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
ADD R3, -R0.y, c[19];
ADD R2, -R0.x, c[18];
MUL R0, R3, R3;
MAD R4, R2, R2, R0;
DP3 R5.x, vertex.normal, vertex.normal;
RSQ R0.x, R5.x;
MUL R6.xyz, R0.x, vertex.normal;
MUL R7.xyz, R6, c[15].w;
DP3 R6.w, R7, c[6];
DP4 R0.y, R1, c[7];
ADD R0, -R0.y, c[20];
MAD R4, R0, R0, R4;
DP3 R7.w, R7, c[5];
MUL R3, R6.w, R3;
MAD R2, R7.w, R2, R3;
DP3 R3.w, R7, c[7];
MAD R0, R3.w, R0, R2;
MUL R5, R4, c[21];
MOV R7.x, R6.w;
MOV R7.y, R3.w;
MOV R7.z, c[0].x;
RSQ R2.x, R4.x;
RSQ R2.y, R4.y;
RSQ R2.z, R4.z;
RSQ R2.w, R4.w;
MUL R0, R0, R2;
ADD R2, R5, c[0].x;
DP4 R5.z, R7.wxyz, c[28];
DP4 R5.y, R7.wxyz, c[27];
DP4 R5.x, R7.wxyz, c[26];
RCP R2.x, R2.x;
RCP R2.y, R2.y;
RCP R2.w, R2.w;
RCP R2.z, R2.z;
MAX R0, R0, c[39].z;
MUL R0, R0, R2;
MUL R2.xyz, R0.y, c[23];
MAD R2.xyz, R0.x, c[22], R2;
MAD R0.xyz, R0.z, c[24], R2;
MAD R3.xyz, R0.w, c[25], R0;
MUL R0, R7.wxyy, R7.xyyw;
MUL R2.z, R6.w, R6.w;
DP4 R2.w, R1, c[4];
DP4 R2.x, R1, c[1];
DP4 R2.y, R1, c[2];
MUL R4.xyz, R2.xyww, c[39].w;
DP4 R7.z, R0, c[31];
DP4 R7.y, R0, c[30];
DP4 R7.x, R0, c[29];
MAD R2.z, R7.w, R7.w, -R2;
MUL R0.xyz, R2.z, c[32];
DP4 R2.z, R1, c[3];
ADD R5.xyz, R5, R7;
ADD R0.xyz, R5, R0;
ADD result.texcoord[2].xyz, R0, R3;
MOV R0.x, R4;
MUL R0.y, R4, c[14].x;
ADD result.texcoord[4].xy, R0, R4.z;
DP3 R0.z, vertex.attrib[14], vertex.attrib[14];
RSQ R0.x, R0.z;
MUL R0.xyz, R0.x, vertex.attrib[14];
MUL R3.xyz, R6.zxyw, R0.yzxw;
MAD R3.xyz, R6.yzxw, R0.zxyw, -R3;
MOV result.position, R2;
MOV result.texcoord[4].zw, R2;
MOV R2.w, c[0].x;
MOV R2.xyz, c[16];
DP4 R4.z, R2, c[11];
DP4 R4.x, R2, c[9];
DP4 R4.y, R2, c[10];
MAD R1.xyz, R4, c[15].w, -R1;
MUL R3.xyz, R3, vertex.attrib[14].w;
DP3 result.texcoord[3].z, R6, R1;
DP3 result.texcoord[3].y, R3, R1;
MOV R2, c[17];
DP3 result.texcoord[3].x, R0, R1;
DP4 R1.z, R2, c[11];
DP4 R1.x, R2, c[9];
DP4 R1.y, R2, c[10];
DP3 result.texcoord[1].y, R1, R3;
DP3 result.texcoord[1].z, R6, R1;
DP3 result.texcoord[1].x, R1, R0;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[37], c[37].zwzw;
MOV result.color.w, vertex.color;
END
# 119 instructions, 8 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_Scale]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_WorldSpaceLightPos0]
Vector 18 [unity_4LightPosX0]
Vector 19 [unity_4LightPosY0]
Vector 20 [unity_4LightPosZ0]
Vector 21 [unity_4LightAtten0]
Vector 22 [unity_LightColor0]
Vector 23 [unity_LightColor1]
Vector 24 [unity_LightColor2]
Vector 25 [unity_LightColor3]
Vector 26 [unity_SHAr]
Vector 27 [unity_SHAg]
Vector 28 [unity_SHAb]
Vector 29 [unity_SHBr]
Vector 30 [unity_SHBg]
Vector 31 [unity_SHBb]
Vector 32 [unity_SHC]
Vector 33 [_Scale]
Vector 34 [_SquashPlaneNormal]
Float 35 [_SquashAmount]
Vector 36 [_Wind]
Vector 37 [_MainTex_ST]
"vs_2_0
; 125 ALU
def c38, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c39, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c40, 2.00000000, 3.00000000, 0.30000001, 0.10000000
def c41, 0.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c38.x, r0
add r0.x, v5, r0
add r0.w, v5.y, r0.x
mov r1.y, r0.x
mul r0.xyz, v0, c33
dp3 r1.x, r0, r0.w
add r1.xy, r1, c12.y
mul r1, r1.xxyy, c39
frc r1, r1
mad r1, r1, c38.y, c38.z
frc r1, r1
mad r1, r1, c38.y, c38.w
abs r2, r1
mad r1, -r2, c40.x, c40.y
mul r2, r2, r2
mul r1, r2, r1
add r2.xy, r1.xzzw, r1.ywzw
mul r1.xyz, r2.y, c36
mul r3.xyz, v4.y, r1
mul r0.w, v5.y, c40
mov r1.w, c38.x
mul r1.xz, r0.w, v2
mul r1.y, v4, c40.z
mad r1.xyz, r2.xyxw, r1, r3
mad r0.xyz, r1, c36.w, r0
mad r0.xyz, v4.x, c36, r0
dp3 r0.w, r0, c34
add r0.w, r0, c34
mul r1.xyz, r0.w, c34
add r0.xyz, -r1, r0
mad r1.xyz, r1, c35.x, r0
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
add r3, -r0.y, c19
add r2, -r0.x, c18
mul r0, r3, r3
mad r4, r2, r2, r0
dp3 r5.x, v2, v2
rsq r0.x, r5.x
mul r6.xyz, r0.x, v2
mul r7.xyz, r6, c15.w
dp3 r6.w, r7, c5
dp4 r0.y, r1, c6
add r0, -r0.y, c20
mad r4, r0, r0, r4
dp3 r7.w, r7, c4
mul r3, r6.w, r3
mad r2, r7.w, r2, r3
dp3 r3.w, r7, c6
mad r0, r3.w, r0, r2
mul r5, r4, c21
mov r7.x, r6.w
mov r7.y, r3.w
mov r7.z, c38.x
rsq r2.x, r4.x
rsq r2.y, r4.y
rsq r2.z, r4.z
rsq r2.w, r4.w
mul r0, r0, r2
add r2, r5, c38.x
dp4 r5.z, r7.wxyz, c28
dp4 r5.y, r7.wxyz, c27
dp4 r5.x, r7.wxyz, c26
rcp r2.x, r2.x
rcp r2.y, r2.y
rcp r2.w, r2.w
rcp r2.z, r2.z
max r0, r0, c41.x
mul r0, r0, r2
mul r2.xyz, r0.y, c23
mad r2.xyz, r0.x, c22, r2
mad r0.xyz, r0.z, c24, r2
mad r3.xyz, r0.w, c25, r0
mul r0, r7.wxyy, r7.xyyw
mul r2.z, r6.w, r6.w
dp4 r2.w, r1, c3
dp4 r2.x, r1, c0
dp4 r2.y, r1, c1
mul r4.xyz, r2.xyww, c41.y
dp4 r7.z, r0, c31
dp4 r7.y, r0, c30
dp4 r7.x, r0, c29
mad r2.z, r7.w, r7.w, -r2
mul r0.xyz, r2.z, c32
dp4 r2.z, r1, c2
add r5.xyz, r5, r7
add r0.xyz, r5, r0
add oT2.xyz, r0, r3
mov r0.x, r4
mul r0.y, r4, c13.x
mad oT4.xy, r4.z, c14.zwzw, r0
dp3 r0.z, v1, v1
rsq r0.x, r0.z
mul r0.xyz, r0.x, v1
mul r3.xyz, r6.zxyw, r0.yzxw
mad r3.xyz, r6.yzxw, r0.zxyw, -r3
mov oPos, r2
mov oT4.zw, r2
mov r2.w, c38.x
mov r2.xyz, c16
dp4 r4.z, r2, c10
dp4 r4.x, r2, c8
dp4 r4.y, r2, c9
mad r2.xyz, r4, c15.w, -r1
mul r3.xyz, r3, v1.w
mov r1, c10
dp4 r4.z, c17, r1
mov r1, c9
dp4 r4.y, c17, r1
dp3 oT3.z, r6, r2
dp3 oT3.y, r3, r2
dp3 oT3.x, r0, r2
mov r2, c8
dp4 r4.x, c17, r2
dp3 oT1.y, r4, r3
dp3 oT1.z, r6, r4
dp3 oT1.x, r4, r0
mov oD0.xyz, c38.x
mad oT0.xy, v3, c37, c37.zwzw
mov oD0.w, v5
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 35 ALU, 3 TEX
PARAM c[4] = { program.local[0..2],
		{ 2, 1, 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R3.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1.w, fragment.texcoord[0], texture[1], 2D;
MAD R2.xy, R3.wyzw, c[3].x, -c[3].y;
MUL R2.z, R2.y, R2.y;
MAD R2.z, -R2.x, R2.x, -R2;
DP3 R2.w, fragment.texcoord[3], fragment.texcoord[3];
ADD R2.z, R2, c[3].y;
RSQ R2.z, R2.z;
MUL R0.xyz, R0, c[2];
RCP R2.z, R2.z;
RSQ R2.w, R2.w;
MOV R1.xyz, fragment.texcoord[1];
MAD R1.xyz, R2.w, fragment.texcoord[3], R1;
DP3 R2.w, R1, R1;
RSQ R2.w, R2.w;
MUL R1.xyz, R2.w, R1;
DP3 R1.x, R2, R1;
MUL R1.y, R3.x, c[3].w;
DP3 R2.x, R2, fragment.texcoord[1];
MAX R1.x, R1, c[3].z;
MUL R1.z, R1.w, c[2].x;
POW R1.x, R1.x, R1.y;
MUL R2.w, R1.x, R1.z;
MOV R1, c[1];
MUL R1.w, R1, c[0];
MUL R0.xyz, R0, fragment.color.primary.w;
MAX R3.x, R2, c[3].z;
MUL R2.xyz, R0, c[0];
MUL R2.xyz, R2, R3.x;
MUL R1.xyz, R1, c[0];
MAD R1.xyz, R1, R2.w, R2;
MUL R1.xyz, R1, c[3].x;
MAD result.color.xyz, R0, fragment.texcoord[2], R1;
MAD result.color.w, R2, R1, R0;
END
# 35 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
"ps_2_0
; 39 ALU, 3 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c3, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c4, 128.00000000, 0, 0, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r4, t0, s2
texld r2, t0, s0
texld r0, t0, s1
dp3_pp r1.x, t3, t3
mul_pp r2.xyz, r2, c2
mov r0.y, r4
mov r0.x, r4.w
mad_pp r3.xy, r0, c3.x, c3.y
mul_pp r0.x, r3.y, r3.y
mad_pp r0.x, -r3, r3, -r0
add_pp r0.x, r0, c3.z
rsq_pp r0.x, r0.x
rcp_pp r3.z, r0.x
mul_pp r0.x, r4, c4
rsq_pp r1.x, r1.x
mov_pp r5.xyz, t1
mad_pp r5.xyz, r1.x, t3, r5
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
dp3_pp r1.x, r3, r1
max_pp r1.x, r1, c3.w
pow r4.w, r1.x, r0.x
mul_pp r1.x, r0.w, c2
mov r0.x, r4.w
mul r0.x, r0, r1
dp3_pp r1.x, r3, t1
mul_pp r2.xyz, r2, v0.w
mov_pp r3.xyz, c0
mov_pp r0.w, c0
max_pp r1.x, r1, c3.w
mul_pp r4.xyz, r2, c0
mul_pp r1.xyz, r4, r1.x
mul_pp r3.xyz, c1, r3
mad r3.xyz, r3, r0.x, r1
mul_pp r1.x, c1.w, r0.w
mad r0.w, r0.x, r1.x, r2
mul r3.xyz, r3, c3.x
mad_pp r0.xyz, r2, t2, r3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_ShadowMapTexture] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 38 ALU, 4 TEX
PARAM c[4] = { program.local[0..2],
		{ 2, 1, 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TEX R0.w, fragment.texcoord[0], texture[1], 2D;
TXP R0.x, fragment.texcoord[4], texture[3], 2D;
MAD R3.xy, R2.wyzw, c[3].x, -c[3].y;
MUL R0.y, R3, R3;
MAD R0.y, -R3.x, R3.x, -R0;
DP3 R0.z, fragment.texcoord[3], fragment.texcoord[3];
ADD R0.y, R0, c[3];
RSQ R0.y, R0.y;
RCP R3.z, R0.y;
RSQ R0.z, R0.z;
MOV R2.yzw, fragment.texcoord[1].xxyz;
MAD R2.yzw, R0.z, fragment.texcoord[3].xxyz, R2;
DP3 R0.z, R2.yzww, R2.yzww;
RSQ R0.z, R0.z;
MUL R2.yzw, R0.z, R2;
DP3 R0.y, R3, R2.yzww;
MUL R0.z, R2.x, c[3].w;
MOV R2, c[1];
MAX R0.y, R0, c[3].z;
POW R0.y, R0.y, R0.z;
MUL R0.w, R0, c[2].x;
MUL R0.y, R0, R0.w;
DP3 R0.z, R3, fragment.texcoord[1];
MUL R1.xyz, R1, c[2];
MUL R3.xyz, R1, fragment.color.primary.w;
MAX R0.z, R0, c[3];
MUL R1.xyz, R3, c[0];
MUL R1.xyz, R1, R0.z;
MUL R2.xyz, R2, c[0];
MAD R1.xyz, R2, R0.y, R1;
MUL R0.z, R0.x, c[3].x;
MUL R0.w, R2, c[0];
MUL R1.xyz, R1, R0.z;
MUL R0.y, R0, R0.w;
MAD result.color.xyz, R3, fragment.texcoord[2], R1;
MAD result.color.w, R0.x, R0.y, R1;
END
# 38 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_ShadowMapTexture] 2D
"ps_2_0
; 41 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c3, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c4, 128.00000000, 0, 0, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4
texld r4, t0, s2
texldp r6, t4, s3
texld r2, t0, s0
texld r0, t0, s1
dp3_pp r1.x, t3, t3
mov r0.y, r4
mov r0.x, r4.w
mad_pp r3.xy, r0, c3.x, c3.y
mul_pp r0.x, r3.y, r3.y
mad_pp r0.x, -r3, r3, -r0
add_pp r0.x, r0, c3.z
rsq_pp r0.x, r0.x
rcp_pp r3.z, r0.x
mul_pp r0.x, r4, c4
rsq_pp r1.x, r1.x
mov_pp r5.xyz, t1
mad_pp r5.xyz, r1.x, t3, r5
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
dp3_pp r1.x, r3, r1
max_pp r1.x, r1, c3.w
pow r4.w, r1.x, r0.x
mov r0.x, r4.w
mul_pp r1.x, r0.w, c2
mul_pp r4.xyz, r2, c2
dp3_pp r2.x, r3, t1
mul_pp r3.xyz, r4, v0.w
mul r1.x, r0, r1
mov_pp r0.w, c0
mul_pp r0.x, c1.w, r0.w
mul r0.x, r1, r0
max_pp r2.x, r2, c3.w
mul_pp r4.xyz, r3, c0
mul_pp r5.xyz, r4, r2.x
mov_pp r4.xyz, c0
mul_pp r4.xyz, c1, r4
mad r0.w, r6.x, r0.x, r2
mul_pp r2.x, r6, c3
mad r1.xyz, r4, r1.x, r5
mul r1.xyz, r1, r2.x
mad_pp r0.xyz, r3, t2, r1
mov_pp oC0, r0
"
}
}
 }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardAdd" "RenderType"="TreeBark" }
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend One One
Program "vp" {
SubProgram "opengl " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
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
# 72 ALU
PARAM c[28] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..25],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
MOV R2.w, c[0].x;
MUL R2.xyz, vertex.position, c[21];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[17].y;
MUL R0, R0.xxyy, c[26];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R1.xyz, R3.y, c[24];
MUL R0.x, vertex.color.y, c[27].y;
MUL R1.xyz, vertex.texcoord[1].y, R1;
MUL R0.xz, R0.x, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[27].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[24].w, R2;
MAD R0.xyz, vertex.texcoord[1].x, c[24], R0;
DP3 R0.w, R0, c[22];
ADD R0.w, R0, c[22];
MUL R1.xyz, R0.w, c[22];
ADD R0.xyz, -R1, R0;
MAD R2.xyz, R1, c[23].x, R0;
DP4 R0.w, R2, c[8];
DP4 R0.z, R2, c[7];
DP4 R0.x, R2, c[5];
DP4 R0.y, R2, c[6];
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
DP3 R0.y, vertex.attrib[14], vertex.attrib[14];
RSQ R0.y, R0.y;
DP3 R0.x, vertex.normal, vertex.normal;
RSQ R0.x, R0.x;
MUL R4.xyz, R0.y, vertex.attrib[14];
MUL R1.xyz, R0.x, vertex.normal;
MUL R3.xyz, R1.zxyw, R4.yzxw;
MAD R5.xyz, R1.yzxw, R4.zxyw, -R3;
MOV R0, c[20];
DP4 R3.z, R0, c[11];
DP4 R3.x, R0, c[9];
DP4 R3.y, R0, c[10];
MAD R3.xyz, R3, c[18].w, -R2;
MUL R5.xyz, R5, vertex.attrib[14].w;
MOV R0.xyz, c[19];
MOV R0.w, c[0].x;
DP4 R6.z, R0, c[11];
DP4 R6.x, R0, c[9];
DP4 R6.y, R0, c[10];
MAD R0.xyz, R6, c[18].w, -R2;
DP4 result.position.w, R2, c[4];
DP4 result.position.z, R2, c[3];
DP4 result.position.y, R2, c[2];
DP4 result.position.x, R2, c[1];
DP3 result.texcoord[1].z, R1, R3;
DP3 result.texcoord[1].y, R3, R5;
DP3 result.texcoord[1].x, R3, R4;
DP3 result.texcoord[2].z, R1, R0;
DP3 result.texcoord[2].y, R5, R0;
DP3 result.texcoord[2].x, R4, R0;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[25], c[25].zwzw;
MOV result.color.w, vertex.color;
END
# 72 instructions, 7 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
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
; 78 ALU
def c25, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c26, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c27, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c25.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mov r2.w, c25.x
mul r2.xyz, v0, c20
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c16.y
mul r0, r0.xxyy, c26
frc r0, r0
mad r0, r0, c25.y, c25.z
frc r0, r0
mad r0, r0, c25.y, c25.w
abs r0, r0
mad r1, -r0, c27.x, c27.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r1.xyz, r3.y, c23
mul r0.x, v5.y, c27.w
mul r1.xyz, v4.y, r1
mul r0.xz, r0.x, v2
mul r0.y, v4, c27.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c23.w, r2
mad r0.xyz, v4.x, c23, r0
dp3 r0.w, r0, c21
add r0.w, r0, c21
mul r1.xyz, r0.w, c21
add r0.xyz, -r1, r0
mad r2.xyz, r1, c22.x, r0
dp4 r0.w, r2, c7
dp4 r0.z, r2, c6
dp4 r0.x, r2, c4
dp4 r0.y, r2, c5
dp4 oT3.z, r0, c14
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
dp3 r0.y, v1, v1
rsq r0.y, r0.y
dp3 r0.x, v2, v2
rsq r0.x, r0.x
mul r4.xyz, r0.y, v1
mul r3.xyz, r0.x, v2
mul r1.xyz, r3.zxyw, r4.yzxw
mad r5.xyz, r3.yzxw, r4.zxyw, -r1
mov r0, c10
dp4 r6.z, c19, r0
mov r0, c9
dp4 r6.y, c19, r0
mov r1, c8
dp4 r6.x, c19, r1
mad r1.xyz, r6, c17.w, -r2
mul r5.xyz, r5, v1.w
mov r0.xyz, c18
mov r0.w, c25.x
dp4 r6.z, r0, c10
dp4 r6.x, r0, c8
dp4 r6.y, r0, c9
mad r0.xyz, r6, c17.w, -r2
dp4 oPos.w, r2, c3
dp4 oPos.z, r2, c2
dp4 oPos.y, r2, c1
dp4 oPos.x, r2, c0
dp3 oT1.z, r3, r1
dp3 oT1.y, r1, r5
dp3 oT1.x, r1, r4
dp3 oT2.z, r3, r0
dp3 oT2.y, r5, r0
dp3 oT2.x, r4, r0
mov oD0.xyz, c25.x
mad oT0.xy, v3, c24, c24.zwzw
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
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [unity_Scale]
Vector 15 [_WorldSpaceCameraPos]
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [_Scale]
Vector 18 [_SquashPlaneNormal]
Float 19 [_SquashAmount]
Vector 20 [_Wind]
Vector 21 [_MainTex_ST]
"!!ARBvp1.0
# 64 ALU
PARAM c[24] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..21],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
MUL R2.xyz, vertex.position, c[17];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[13].y;
MUL R0, R0.xxyy, c[22];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R1.xyz, R3.y, c[20];
MUL R0.x, vertex.color.y, c[23].y;
MOV R1.w, c[0].x;
MOV R0.w, c[0].x;
MUL R1.xyz, vertex.texcoord[1].y, R1;
MUL R0.xz, R0.x, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[23].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[20].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[20], R0;
DP3 R0.x, R1, c[18];
ADD R0.x, R0, c[18].w;
MUL R0.xyz, R0.x, c[18];
ADD R1.xyz, -R0, R1;
MAD R1.xyz, R0, c[19].x, R1;
DP3 R0.y, vertex.attrib[14], vertex.attrib[14];
RSQ R0.y, R0.y;
DP3 R0.x, vertex.normal, vertex.normal;
RSQ R0.x, R0.x;
MUL R3.xyz, R0.y, vertex.attrib[14];
MUL R2.xyz, R0.x, vertex.normal;
MUL R0.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R0;
MOV R0.xyz, c[15];
MUL R4.xyz, R4, vertex.attrib[14].w;
DP4 result.position.w, R1, c[4];
DP4 result.position.z, R1, c[3];
DP4 result.position.y, R1, c[2];
DP4 result.position.x, R1, c[1];
DP4 R5.z, R0, c[11];
DP4 R5.x, R0, c[9];
DP4 R5.y, R0, c[10];
MAD R0.xyz, R5, c[14].w, -R1;
DP3 result.texcoord[2].z, R2, R0;
DP3 result.texcoord[2].y, R4, R0;
MOV R1, c[16];
DP3 result.texcoord[2].x, R3, R0;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
DP3 result.texcoord[1].y, R0, R4;
DP3 result.texcoord[1].z, R2, R0;
DP3 result.texcoord[1].x, R0, R3;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[21], c[21].zwzw;
MOV result.color.w, vertex.color;
END
# 64 instructions, 6 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [unity_Scale]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_WorldSpaceLightPos0]
Vector 16 [_Scale]
Vector 17 [_SquashPlaneNormal]
Float 18 [_SquashAmount]
Vector 19 [_Wind]
Vector 20 [_MainTex_ST]
"vs_2_0
; 70 ALU
def c21, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c22, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c23, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c21.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mov r4.w, c21.x
mul r2.xyz, v0, c16
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c12.y
mul r0, r0.xxyy, c22
frc r0, r0
mad r0, r0, c21.y, c21.z
frc r0, r0
mad r0, r0, c21.y, c21.w
abs r0, r0
mad r1, -r0, c23.x, c23.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r1.xyz, r3.y, c19
mul r0.x, v5.y, c23.w
mov r1.w, c21.x
mul r1.xyz, v4.y, r1
mul r0.xz, r0.x, v2
mul r0.y, v4, c23.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c19.w, r2
mad r1.xyz, v4.x, c19, r0
dp3 r0.x, r1, c17
add r0.x, r0, c17.w
mul r0.xyz, r0.x, c17
add r1.xyz, -r0, r1
mad r4.xyz, r0, c18.x, r1
mov r1.xyz, c14
dp3 r0.y, v1, v1
rsq r0.y, r0.y
dp3 r0.x, v2, v2
rsq r0.x, r0.x
mul r3.xyz, r0.y, v1
mul r2.xyz, r0.x, v2
mul r0.xyz, r2.zxyw, r3.yzxw
dp4 r5.z, r1, c10
dp4 r5.x, r1, c8
dp4 r5.y, r1, c9
mad r1.xyz, r5, c13.w, -r4
mad r0.xyz, r2.yzxw, r3.zxyw, -r0
dp4 oPos.w, r4, c3
dp4 oPos.z, r4, c2
dp4 oPos.y, r4, c1
dp4 oPos.x, r4, c0
mul r4.xyz, r0, v1.w
mov r0, c10
dp4 r5.z, c15, r0
mov r0, c9
dp4 r5.y, c15, r0
dp3 oT2.z, r2, r1
dp3 oT2.y, r4, r1
dp3 oT2.x, r3, r1
mov r1, c8
dp4 r5.x, c15, r1
dp3 oT1.y, r5, r4
dp3 oT1.z, r2, r5
dp3 oT1.x, r5, r3
mov oD0.xyz, c21.x
mad oT0.xy, v3, c20, c20.zwzw
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
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
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
# 73 ALU
PARAM c[28] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..25],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
MOV R2.w, c[0].x;
MUL R2.xyz, vertex.position, c[21];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[17].y;
MUL R0, R0.xxyy, c[26];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R1.xyz, R3.y, c[24];
MUL R0.x, vertex.color.y, c[27].y;
MUL R1.xyz, vertex.texcoord[1].y, R1;
MUL R0.xz, R0.x, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[27].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[24].w, R2;
MAD R0.xyz, vertex.texcoord[1].x, c[24], R0;
DP3 R0.w, R0, c[22];
ADD R0.w, R0, c[22];
MUL R1.xyz, R0.w, c[22];
ADD R0.xyz, -R1, R0;
MAD R2.xyz, R1, c[23].x, R0;
DP4 R0.w, R2, c[8];
DP4 R0.z, R2, c[7];
DP4 R0.x, R2, c[5];
DP4 R0.y, R2, c[6];
DP4 result.texcoord[3].w, R0, c[16];
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
DP3 R0.y, vertex.attrib[14], vertex.attrib[14];
RSQ R0.y, R0.y;
DP3 R0.x, vertex.normal, vertex.normal;
RSQ R0.x, R0.x;
MUL R4.xyz, R0.y, vertex.attrib[14];
MUL R1.xyz, R0.x, vertex.normal;
MUL R3.xyz, R1.zxyw, R4.yzxw;
MAD R5.xyz, R1.yzxw, R4.zxyw, -R3;
MOV R0, c[20];
DP4 R3.z, R0, c[11];
DP4 R3.x, R0, c[9];
DP4 R3.y, R0, c[10];
MAD R3.xyz, R3, c[18].w, -R2;
MUL R5.xyz, R5, vertex.attrib[14].w;
MOV R0.xyz, c[19];
MOV R0.w, c[0].x;
DP4 R6.z, R0, c[11];
DP4 R6.x, R0, c[9];
DP4 R6.y, R0, c[10];
MAD R0.xyz, R6, c[18].w, -R2;
DP4 result.position.w, R2, c[4];
DP4 result.position.z, R2, c[3];
DP4 result.position.y, R2, c[2];
DP4 result.position.x, R2, c[1];
DP3 result.texcoord[1].z, R1, R3;
DP3 result.texcoord[1].y, R3, R5;
DP3 result.texcoord[1].x, R3, R4;
DP3 result.texcoord[2].z, R1, R0;
DP3 result.texcoord[2].y, R5, R0;
DP3 result.texcoord[2].x, R4, R0;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[25], c[25].zwzw;
MOV result.color.w, vertex.color;
END
# 73 instructions, 7 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
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
; 79 ALU
def c25, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c26, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c27, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c25.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mov r2.w, c25.x
mul r2.xyz, v0, c20
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c16.y
mul r0, r0.xxyy, c26
frc r0, r0
mad r0, r0, c25.y, c25.z
frc r0, r0
mad r0, r0, c25.y, c25.w
abs r0, r0
mad r1, -r0, c27.x, c27.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r1.xyz, r3.y, c23
mul r0.x, v5.y, c27.w
mul r1.xyz, v4.y, r1
mul r0.xz, r0.x, v2
mul r0.y, v4, c27.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c23.w, r2
mad r0.xyz, v4.x, c23, r0
dp3 r0.w, r0, c21
add r0.w, r0, c21
mul r1.xyz, r0.w, c21
add r0.xyz, -r1, r0
mad r2.xyz, r1, c22.x, r0
dp4 r0.w, r2, c7
dp4 r0.z, r2, c6
dp4 r0.x, r2, c4
dp4 r0.y, r2, c5
dp4 oT3.w, r0, c15
dp4 oT3.z, r0, c14
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
dp3 r0.y, v1, v1
rsq r0.y, r0.y
dp3 r0.x, v2, v2
rsq r0.x, r0.x
mul r4.xyz, r0.y, v1
mul r3.xyz, r0.x, v2
mul r1.xyz, r3.zxyw, r4.yzxw
mad r5.xyz, r3.yzxw, r4.zxyw, -r1
mov r0, c10
dp4 r6.z, c19, r0
mov r0, c9
dp4 r6.y, c19, r0
mov r1, c8
dp4 r6.x, c19, r1
mad r1.xyz, r6, c17.w, -r2
mul r5.xyz, r5, v1.w
mov r0.xyz, c18
mov r0.w, c25.x
dp4 r6.z, r0, c10
dp4 r6.x, r0, c8
dp4 r6.y, r0, c9
mad r0.xyz, r6, c17.w, -r2
dp4 oPos.w, r2, c3
dp4 oPos.z, r2, c2
dp4 oPos.y, r2, c1
dp4 oPos.x, r2, c0
dp3 oT1.z, r3, r1
dp3 oT1.y, r1, r5
dp3 oT1.x, r1, r4
dp3 oT2.z, r3, r0
dp3 oT2.y, r5, r0
dp3 oT2.x, r4, r0
mov oD0.xyz, c25.x
mad oT0.xy, v3, c24, c24.zwzw
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
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
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
# 72 ALU
PARAM c[28] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..25],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
MOV R2.w, c[0].x;
MUL R2.xyz, vertex.position, c[21];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[17].y;
MUL R0, R0.xxyy, c[26];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R1.xyz, R3.y, c[24];
MUL R0.x, vertex.color.y, c[27].y;
MUL R1.xyz, vertex.texcoord[1].y, R1;
MUL R0.xz, R0.x, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[27].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[24].w, R2;
MAD R0.xyz, vertex.texcoord[1].x, c[24], R0;
DP3 R0.w, R0, c[22];
ADD R0.w, R0, c[22];
MUL R1.xyz, R0.w, c[22];
ADD R0.xyz, -R1, R0;
MAD R2.xyz, R1, c[23].x, R0;
DP4 R0.w, R2, c[8];
DP4 R0.z, R2, c[7];
DP4 R0.x, R2, c[5];
DP4 R0.y, R2, c[6];
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
DP3 R0.y, vertex.attrib[14], vertex.attrib[14];
RSQ R0.y, R0.y;
DP3 R0.x, vertex.normal, vertex.normal;
RSQ R0.x, R0.x;
MUL R4.xyz, R0.y, vertex.attrib[14];
MUL R1.xyz, R0.x, vertex.normal;
MUL R3.xyz, R1.zxyw, R4.yzxw;
MAD R5.xyz, R1.yzxw, R4.zxyw, -R3;
MOV R0, c[20];
DP4 R3.z, R0, c[11];
DP4 R3.x, R0, c[9];
DP4 R3.y, R0, c[10];
MAD R3.xyz, R3, c[18].w, -R2;
MUL R5.xyz, R5, vertex.attrib[14].w;
MOV R0.xyz, c[19];
MOV R0.w, c[0].x;
DP4 R6.z, R0, c[11];
DP4 R6.x, R0, c[9];
DP4 R6.y, R0, c[10];
MAD R0.xyz, R6, c[18].w, -R2;
DP4 result.position.w, R2, c[4];
DP4 result.position.z, R2, c[3];
DP4 result.position.y, R2, c[2];
DP4 result.position.x, R2, c[1];
DP3 result.texcoord[1].z, R1, R3;
DP3 result.texcoord[1].y, R3, R5;
DP3 result.texcoord[1].x, R3, R4;
DP3 result.texcoord[2].z, R1, R0;
DP3 result.texcoord[2].y, R5, R0;
DP3 result.texcoord[2].x, R4, R0;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[25], c[25].zwzw;
MOV result.color.w, vertex.color;
END
# 72 instructions, 7 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
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
; 78 ALU
def c25, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c26, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c27, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c25.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mov r2.w, c25.x
mul r2.xyz, v0, c20
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c16.y
mul r0, r0.xxyy, c26
frc r0, r0
mad r0, r0, c25.y, c25.z
frc r0, r0
mad r0, r0, c25.y, c25.w
abs r0, r0
mad r1, -r0, c27.x, c27.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r1.xyz, r3.y, c23
mul r0.x, v5.y, c27.w
mul r1.xyz, v4.y, r1
mul r0.xz, r0.x, v2
mul r0.y, v4, c27.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c23.w, r2
mad r0.xyz, v4.x, c23, r0
dp3 r0.w, r0, c21
add r0.w, r0, c21
mul r1.xyz, r0.w, c21
add r0.xyz, -r1, r0
mad r2.xyz, r1, c22.x, r0
dp4 r0.w, r2, c7
dp4 r0.z, r2, c6
dp4 r0.x, r2, c4
dp4 r0.y, r2, c5
dp4 oT3.z, r0, c14
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
dp3 r0.y, v1, v1
rsq r0.y, r0.y
dp3 r0.x, v2, v2
rsq r0.x, r0.x
mul r4.xyz, r0.y, v1
mul r3.xyz, r0.x, v2
mul r1.xyz, r3.zxyw, r4.yzxw
mad r5.xyz, r3.yzxw, r4.zxyw, -r1
mov r0, c10
dp4 r6.z, c19, r0
mov r0, c9
dp4 r6.y, c19, r0
mov r1, c8
dp4 r6.x, c19, r1
mad r1.xyz, r6, c17.w, -r2
mul r5.xyz, r5, v1.w
mov r0.xyz, c18
mov r0.w, c25.x
dp4 r6.z, r0, c10
dp4 r6.x, r0, c8
dp4 r6.y, r0, c9
mad r0.xyz, r6, c17.w, -r2
dp4 oPos.w, r2, c3
dp4 oPos.z, r2, c2
dp4 oPos.y, r2, c1
dp4 oPos.x, r2, c0
dp3 oT1.z, r3, r1
dp3 oT1.y, r1, r5
dp3 oT1.x, r1, r4
dp3 oT2.z, r3, r0
dp3 oT2.y, r5, r0
dp3 oT2.x, r4, r0
mov oD0.xyz, c25.x
mad oT0.xy, v3, c24, c24.zwzw
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
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
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
# 70 ALU
PARAM c[28] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..25],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
MUL R2.xyz, vertex.position, c[21];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[17].y;
MUL R0, R0.xxyy, c[26];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R1.xyz, R3.y, c[24];
MUL R0.x, vertex.color.y, c[27].y;
MOV R1.w, c[0].x;
MUL R1.xyz, vertex.texcoord[1].y, R1;
MUL R0.xz, R0.x, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[27].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[24].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[24], R0;
DP3 R0.x, R1, c[22];
ADD R0.x, R0, c[22].w;
MUL R0.xyz, R0.x, c[22];
ADD R1.xyz, -R0, R1;
MAD R1.xyz, R0, c[23].x, R1;
DP4 R0.w, R1, c[8];
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
DP3 R0.y, vertex.attrib[14], vertex.attrib[14];
RSQ R0.y, R0.y;
DP3 R0.x, vertex.normal, vertex.normal;
RSQ R0.x, R0.x;
MUL R3.xyz, R0.y, vertex.attrib[14];
MUL R2.xyz, R0.x, vertex.normal;
MUL R0.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R0;
MOV R0.xyz, c[19];
MOV R0.w, c[0].x;
MUL R4.xyz, R4, vertex.attrib[14].w;
DP4 result.position.w, R1, c[4];
DP4 result.position.z, R1, c[3];
DP4 result.position.y, R1, c[2];
DP4 result.position.x, R1, c[1];
DP4 R5.z, R0, c[11];
DP4 R5.x, R0, c[9];
DP4 R5.y, R0, c[10];
MAD R0.xyz, R5, c[18].w, -R1;
DP3 result.texcoord[2].z, R2, R0;
DP3 result.texcoord[2].y, R4, R0;
MOV R1, c[20];
DP3 result.texcoord[2].x, R3, R0;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
DP3 result.texcoord[1].y, R0, R4;
DP3 result.texcoord[1].z, R2, R0;
DP3 result.texcoord[1].x, R0, R3;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[25], c[25].zwzw;
MOV result.color.w, vertex.color;
END
# 70 instructions, 6 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
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
; 76 ALU
def c25, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c26, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c27, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c25.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mov r4.w, c25.x
mul r2.xyz, v0, c20
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c16.y
mul r0, r0.xxyy, c26
frc r0, r0
mad r0, r0, c25.y, c25.z
frc r0, r0
mad r0, r0, c25.y, c25.w
abs r0, r0
mad r1, -r0, c27.x, c27.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r1.xyz, r3.y, c23
mul r0.x, v5.y, c27.w
mov r1.w, c25.x
mul r1.xyz, v4.y, r1
mul r0.xz, r0.x, v2
mul r0.y, v4, c27.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c23.w, r2
mad r1.xyz, v4.x, c23, r0
dp3 r0.x, r1, c21
add r0.x, r0, c21.w
mul r0.xyz, r0.x, c21
add r1.xyz, -r0, r1
mad r4.xyz, r0, c22.x, r1
mov r1.xyz, c18
dp4 r0.w, r4, c7
dp4 r0.z, r4, c6
dp4 r0.x, r4, c4
dp4 r0.y, r4, c5
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
dp3 r0.y, v1, v1
rsq r0.y, r0.y
dp3 r0.x, v2, v2
rsq r0.x, r0.x
mul r3.xyz, r0.y, v1
mul r2.xyz, r0.x, v2
mul r0.xyz, r2.zxyw, r3.yzxw
dp4 r5.z, r1, c10
dp4 r5.x, r1, c8
dp4 r5.y, r1, c9
mad r1.xyz, r5, c17.w, -r4
mad r0.xyz, r2.yzxw, r3.zxyw, -r0
dp4 oPos.w, r4, c3
dp4 oPos.z, r4, c2
dp4 oPos.y, r4, c1
dp4 oPos.x, r4, c0
mul r4.xyz, r0, v1.w
mov r0, c10
dp4 r5.z, c19, r0
mov r0, c9
dp4 r5.y, c19, r0
dp3 oT2.z, r2, r1
dp3 oT2.y, r4, r1
dp3 oT2.x, r3, r1
mov r1, c8
dp4 r5.x, c19, r1
dp3 oT1.y, r5, r4
dp3 oT1.z, r2, r5
dp3 oT1.x, r5, r3
mov oD0.xyz, c25.x
mad oT0.xy, v3, c24, c24.zwzw
mov oD0.w, v5
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 38 ALU, 4 TEX
PARAM c[4] = { program.local[0..2],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
TEX R1.w, fragment.texcoord[0], texture[1], 2D;
MAD R3.xy, R2.wyzw, c[3].y, -c[3].z;
DP3 R1.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R1.y, R1.x;
DP3 R0.w, fragment.texcoord[3], fragment.texcoord[3];
MUL R3.z, R3.y, R3.y;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
MAD R3.z, -R3.x, R3.x, -R3;
ADD R3.z, R3, c[3];
RSQ R3.z, R3.z;
MUL R2.yzw, R1.y, fragment.texcoord[1].xxyz;
RSQ R1.x, R1.x;
MAD R1.xyz, R1.x, fragment.texcoord[2], R2.yzww;
DP3 R3.w, R1, R1;
RSQ R3.w, R3.w;
MUL R1.xyz, R3.w, R1;
RCP R3.z, R3.z;
DP3 R1.x, R3, R1;
MUL R1.y, R2.x, c[3].w;
MAX R1.x, R1, c[3];
POW R1.x, R1.x, R1.y;
DP3 R1.y, R3, R2.yzww;
MUL R0.xyz, R0, c[2];
MUL R2.xyz, R0, fragment.color.primary.w;
MUL R1.z, R1.w, c[2].x;
MOV R0.xyz, c[1];
MUL R1.x, R1, R1.z;
MAX R1.y, R1, c[3].x;
MUL R2.xyz, R2, c[0];
MUL R2.xyz, R2, R1.y;
MUL R0.xyz, R0, c[0];
MAD R0.xyz, R0, R1.x, R2;
MOV result.color.w, c[3].x;
TEX R0.w, R0.w, texture[3], 2D;
MUL R0.w, R0, c[3].y;
MUL result.color.xyz, R0, R0.w;
END
# 38 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
"ps_2_0
; 41 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c3, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c4, 128.00000000, 0, 0, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t0, s0
texld r6, t0, s2
dp3_pp r1.x, t1, t1
rsq_pp r3.x, r1.x
dp3 r0.x, t3, t3
mov r0.xy, r0.x
dp3_pp r1.x, t2, t2
mul_pp r3.xyz, r3.x, t1
rsq_pp r1.x, r1.x
mad_pp r5.xyz, r1.x, t2, r3
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
texld r7, r0, s3
texld r0, t0, s1
mov r0.y, r6
mov r0.x, r6.w
mad_pp r4.xy, r0, c3.x, c3.y
mul_pp r0.x, r4.y, r4.y
mad_pp r0.x, -r4, r4, -r0
add_pp r0.x, r0, c3.z
rsq_pp r0.x, r0.x
rcp_pp r4.z, r0.x
dp3_pp r1.x, r4, r1
mul_pp r0.x, r6, c4
max_pp r1.x, r1, c3.w
pow r5.x, r1.x, r0.x
mul_pp r1.x, r0.w, c2
mov r0.x, r5.x
mul r0.x, r0, r1
mul_pp r1.xyz, r2, c2
dp3_pp r2.x, r4, r3
mul_pp r3.xyz, r1, v0.w
max_pp r1.x, r2, c3.w
mul_pp r2.xyz, r3, c0
mul_pp r3.xyz, r2, r1.x
mov_pp r2.xyz, c0
mul_pp r2.xyz, c1, r2
mul_pp r1.x, r7, c3
mad r0.xyz, r2, r0.x, r3
mul r0.xyz, r0, r1.x
mov_pp r0.w, c3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 33 ALU, 3 TEX
PARAM c[4] = { program.local[0..2],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R1.w, fragment.texcoord[0], texture[1], 2D;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
MAD R0.yz, R0.xwyw, c[3].y, -c[3].z;
MUL R0.w, R0.z, R0.z;
MAD R0.w, -R0.y, R0.y, -R0;
DP3 R2.w, fragment.texcoord[2], fragment.texcoord[2];
ADD R0.w, R0, c[3].z;
RSQ R0.w, R0.w;
RSQ R2.w, R2.w;
MOV R2.xyz, fragment.texcoord[1];
MAD R2.xyz, R2.w, fragment.texcoord[2], R2;
DP3 R2.w, R2, R2;
RSQ R2.w, R2.w;
RCP R0.w, R0.w;
MUL R2.xyz, R2.w, R2;
DP3 R2.x, R0.yzww, R2;
DP3 R0.w, R0.yzww, fragment.texcoord[1];
MAX R2.x, R2, c[3];
MUL R0.x, R0, c[3].w;
POW R0.x, R2.x, R0.x;
MUL R1.w, R1, c[2].x;
MUL R1.w, R0.x, R1;
MUL R0.xyz, R1, c[2];
MUL R0.xyz, R0, fragment.color.primary.w;
MOV R1.xyz, c[1];
MAX R0.w, R0, c[3].x;
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R0.w;
MUL R1.xyz, R1, c[0];
MAD R0.xyz, R1, R1.w, R0;
MUL result.color.xyz, R0, c[3].y;
MOV result.color.w, c[3].x;
END
# 33 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
"ps_2_0
; 36 ALU, 3 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c3, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c4, 128.00000000, 0, 0, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
texld r2, t0, s0
texld r5, t0, s2
texld r0, t0, s1
dp3_pp r1.x, t2, t2
mul_pp r2.xyz, r2, c2
mov r0.y, r5
mov r0.x, r5.w
mad_pp r3.xy, r0, c3.x, c3.y
mul_pp r0.x, r3.y, r3.y
mad_pp r0.x, -r3, r3, -r0
add_pp r0.x, r0, c3.z
rsq_pp r0.x, r0.x
rcp_pp r3.z, r0.x
mul_pp r0.x, r5, c4
rsq_pp r1.x, r1.x
mov_pp r4.xyz, t1
mad_pp r4.xyz, r1.x, t2, r4
dp3_pp r1.x, r4, r4
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r4
dp3_pp r1.x, r3, r1
max_pp r1.x, r1, c3.w
pow r4.x, r1.x, r0.x
mul_pp r1.x, r0.w, c2
mov r0.x, r4.x
mul r0.x, r0, r1
dp3_pp r1.x, r3, t1
mul_pp r2.xyz, r2, v0.w
mul_pp r3.xyz, r2, c0
max_pp r1.x, r1, c3.w
mov_pp r2.xyz, c0
mul_pp r1.xyz, r3, r1.x
mul_pp r2.xyz, c1, r2
mad r0.xyz, r2, r0.x, r1
mul r0.xyz, r0, c3.x
mov_pp r0.w, c3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
SetTexture 4 [_LightTextureB0] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 44 ALU, 5 TEX
PARAM c[5] = { program.local[0..2],
		{ 0, 2, 1, 128 },
		{ 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R4.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R2.w, fragment.texcoord[0], texture[1], 2D;
RCP R0.x, fragment.texcoord[3].w;
MAD R1.xy, fragment.texcoord[3], R0.x, c[4].x;
DP3 R1.z, fragment.texcoord[3], fragment.texcoord[3];
DP3 R2.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R2.x, R2.x;
DP3 R3.x, fragment.texcoord[2], fragment.texcoord[2];
MUL R2.xyz, R2.x, fragment.texcoord[1];
RSQ R3.x, R3.x;
MAD R3.xyz, R3.x, fragment.texcoord[2], R2;
DP3 R3.w, R3, R3;
RSQ R3.w, R3.w;
MUL R3.xyz, R3.w, R3;
MOV result.color.w, c[3].x;
TEX R0.w, R1, texture[3], 2D;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
TEX R1.w, R1.z, texture[4], 2D;
MAD R1.xy, R4.wyzw, c[3].y, -c[3].z;
MUL R1.z, R1.y, R1.y;
MAD R1.z, -R1.x, R1.x, -R1;
ADD R1.z, R1, c[3];
RSQ R1.z, R1.z;
RCP R1.z, R1.z;
DP3 R3.x, R1, R3;
DP3 R1.x, R1, R2;
MUL R0.xyz, R0, c[2];
MUL R0.xyz, R0, fragment.color.primary.w;
SLT R2.x, c[3], fragment.texcoord[3].z;
MUL R0.w, R2.x, R0;
MUL R0.w, R0, R1;
MUL R3.z, R2.w, c[2].x;
MAX R1.x, R1, c[3];
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R1.x;
MOV R1.xyz, c[1];
MAX R3.x, R3, c[3];
MUL R3.y, R4.x, c[3].w;
POW R2.w, R3.x, R3.y;
MUL R2.w, R2, R3.z;
MUL R1.xyz, R1, c[0];
MUL R0.w, R0, c[3].y;
MAD R0.xyz, R1, R2.w, R0;
MUL result.color.xyz, R0, R0.w;
END
# 44 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
SetTexture 4 [_LightTextureB0] 2D
"ps_2_0
; 46 ALU, 5 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c3, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c4, 128.00000000, 0.50000000, 0, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3
texld r2, t0, s0
texld r6, t0, s2
rcp r1.x, t3.w
dp3 r0.x, t3, t3
mov r0.xy, r0.x
mad r1.xy, t3, r1.x, c4.y
texld r7, r0, s4
texld r0, t0, s1
texld r1, r1, s3
dp3_pp r1.x, t1, t1
rsq_pp r3.x, r1.x
dp3_pp r1.x, t2, t2
mov r0.y, r6
mov r0.x, r6.w
mad_pp r4.xy, r0, c3.x, c3.y
mul_pp r0.x, r4.y, r4.y
mad_pp r0.x, -r4, r4, -r0
add_pp r0.x, r0, c3.z
rsq_pp r0.x, r0.x
rcp_pp r4.z, r0.x
mul_pp r0.x, r6, c4
mul_pp r3.xyz, r3.x, t1
rsq_pp r1.x, r1.x
mad_pp r5.xyz, r1.x, t2, r3
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
dp3_pp r1.x, r4, r1
max_pp r1.x, r1, c3.w
pow r5.x, r1.x, r0.x
mul_pp r1.x, r0.w, c2
mov r0.x, r5.x
mul r0.x, r0, r1
mul_pp r1.xyz, r2, c2
dp3_pp r2.x, r4, r3
mul_pp r3.xyz, r1, v0.w
max_pp r1.x, r2, c3.w
mul_pp r2.xyz, r3, c0
mov_pp r3.xyz, c0
mul_pp r2.xyz, r2, r1.x
cmp r1.x, -t3.z, c3.w, c3.z
mul_pp r3.xyz, c1, r3
mul_pp r1.x, r1, r1.w
mul_pp r1.x, r1, r7
mul_pp r1.x, r1, c3
mad r0.xyz, r3, r0.x, r2
mul r0.xyz, r0, r1.x
mov_pp r0.w, c3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTextureB0] 2D
SetTexture 4 [_LightTexture0] CUBE
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 40 ALU, 5 TEX
PARAM c[4] = { program.local[0..2],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R4.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
TEX R2.w, fragment.texcoord[0], texture[1], 2D;
TEX R1.w, fragment.texcoord[3], texture[4], CUBE;
MAD R1.xy, R4.wyzw, c[3].y, -c[3].z;
MUL R1.z, R1.y, R1.y;
MAD R1.z, -R1.x, R1.x, -R1;
DP3 R0.w, fragment.texcoord[3], fragment.texcoord[3];
DP3 R2.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R2.x, R2.x;
DP3 R3.x, fragment.texcoord[2], fragment.texcoord[2];
ADD R1.z, R1, c[3];
RSQ R1.z, R1.z;
MUL R0.xyz, R0, c[2];
MUL R0.xyz, R0, fragment.color.primary.w;
RCP R1.z, R1.z;
MUL R2.xyz, R2.x, fragment.texcoord[1];
RSQ R3.x, R3.x;
MAD R3.xyz, R3.x, fragment.texcoord[2], R2;
DP3 R3.w, R3, R3;
RSQ R3.w, R3.w;
MUL R3.xyz, R3.w, R3;
DP3 R3.x, R1, R3;
DP3 R1.x, R1, R2;
MUL R3.z, R2.w, c[2].x;
MAX R1.x, R1, c[3];
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R1.x;
MOV R1.xyz, c[1];
MAX R3.x, R3, c[3];
MUL R3.y, R4.x, c[3].w;
POW R2.w, R3.x, R3.y;
MUL R2.w, R2, R3.z;
MUL R1.xyz, R1, c[0];
MAD R0.xyz, R1, R2.w, R0;
MOV result.color.w, c[3].x;
TEX R0.w, R0.w, texture[3], 2D;
MUL R0.w, R0, R1;
MUL R0.w, R0, c[3].y;
MUL result.color.xyz, R0, R0.w;
END
# 40 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTextureB0] 2D
SetTexture 4 [_LightTexture0] CUBE
"ps_2_0
; 42 ALU, 5 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c3, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c4, 128.00000000, 0, 0, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r1, t3, s4
texld r2, t0, s0
texld r6, t0, s2
dp3_pp r1.x, t1, t1
rsq_pp r3.x, r1.x
dp3 r0.x, t3, t3
mov r0.xy, r0.x
dp3_pp r1.x, t2, t2
mul_pp r3.xyz, r3.x, t1
rsq_pp r1.x, r1.x
mad_pp r5.xyz, r1.x, t2, r3
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
texld r7, r0, s3
texld r0, t0, s1
mov r0.y, r6
mov r0.x, r6.w
mad_pp r4.xy, r0, c3.x, c3.y
mul_pp r0.x, r4.y, r4.y
mad_pp r0.x, -r4, r4, -r0
add_pp r0.x, r0, c3.z
rsq_pp r0.x, r0.x
rcp_pp r4.z, r0.x
dp3_pp r1.x, r4, r1
mul_pp r0.x, r6, c4
max_pp r1.x, r1, c3.w
pow r5.x, r1.x, r0.x
mul_pp r1.x, r0.w, c2
mov r0.x, r5.x
mul r0.x, r0, r1
mul_pp r1.xyz, r2, c2
dp3_pp r2.x, r4, r3
mul_pp r3.xyz, r1, v0.w
max_pp r1.x, r2, c3.w
mul_pp r2.xyz, r3, c0
mov_pp r3.xyz, c0
mul_pp r2.xyz, r2, r1.x
mul_pp r3.xyz, c1, r3
mul r1.x, r7, r1.w
mul_pp r1.x, r1, c3
mad r0.xyz, r3, r0.x, r2
mul r0.xyz, r0, r1.x
mov_pp r0.w, c3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 35 ALU, 4 TEX
PARAM c[4] = { program.local[0..2],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R3.xyw, fragment.texcoord[0], texture[2], 2D;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
TEX R0.w, fragment.texcoord[3], texture[3], 2D;
TEX R1.w, fragment.texcoord[0], texture[1], 2D;
MAD R1.xy, R3.wyzw, c[3].y, -c[3].z;
MUL R1.z, R1.y, R1.y;
MAD R1.z, -R1.x, R1.x, -R1;
DP3 R2.w, fragment.texcoord[2], fragment.texcoord[2];
ADD R1.z, R1, c[3];
RSQ R1.z, R1.z;
RCP R1.z, R1.z;
RSQ R2.w, R2.w;
MOV R2.xyz, fragment.texcoord[1];
MAD R2.xyz, R2.w, fragment.texcoord[2], R2;
DP3 R2.w, R2, R2;
RSQ R2.w, R2.w;
MUL R2.xyz, R2.w, R2;
DP3 R2.x, R1, R2;
MAX R2.x, R2, c[3];
MUL R2.z, R1.w, c[2].x;
MUL R2.y, R3.x, c[3].w;
POW R1.w, R2.x, R2.y;
DP3 R1.x, R1, fragment.texcoord[1];
MUL R0.xyz, R0, c[2];
MAX R2.x, R1, c[3];
MUL R1.xyz, R0, fragment.color.primary.w;
MOV R0.xyz, c[1];
MUL R1.xyz, R1, c[0];
MUL R1.w, R1, R2.z;
MUL R1.xyz, R1, R2.x;
MUL R0.xyz, R0, c[0];
MUL R0.w, R0, c[3].y;
MAD R0.xyz, R0, R1.w, R1;
MUL result.color.xyz, R0, R0.w;
MOV result.color.w, c[3].x;
END
# 35 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
SetTexture 3 [_LightTexture0] 2D
"ps_2_0
; 37 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c3, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c4, 128.00000000, 0, 0, 0
dcl t0.xy
dcl v0.xyzw
dcl t1.xyz
dcl t2.xyz
dcl t3.xy
texld r1, t3, s3
texld r4, t0, s2
texld r2, t0, s0
texld r0, t0, s1
dp3_pp r1.x, t2, t2
mul_pp r2.xyz, r2, c2
mul_pp r2.xyz, r2, v0.w
mov r0.y, r4
mov r0.x, r4.w
mad_pp r3.xy, r0, c3.x, c3.y
mul_pp r0.x, r3.y, r3.y
mad_pp r0.x, -r3, r3, -r0
add_pp r0.x, r0, c3.z
rsq_pp r0.x, r0.x
rcp_pp r3.z, r0.x
mul_pp r0.x, r4, c4
rsq_pp r1.x, r1.x
mov_pp r5.xyz, t1
mad_pp r5.xyz, r1.x, t2, r5
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
dp3_pp r1.x, r3, r1
max_pp r1.x, r1, c3.w
pow r4.x, r1.x, r0.x
mul_pp r1.x, r0.w, c2
mov r0.x, r4.x
mul r0.x, r0, r1
dp3_pp r1.x, r3, t1
max_pp r1.x, r1, c3.w
mul_pp r2.xyz, r2, c0
mul_pp r3.xyz, r2, r1.x
mov_pp r2.xyz, c0
mul_pp r2.xyz, c1, r2
mul_pp r1.x, r1.w, c3
mad r0.xyz, r2, r0.x, r3
mul r0.xyz, r0, r1.x
mov_pp r0.w, c3
mov_pp oC0, r0
"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassBase" "RenderType"="TreeBark" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [unity_Scale]
Vector 11 [_Scale]
Vector 12 [_SquashPlaneNormal]
Float 13 [_SquashAmount]
Vector 14 [_Wind]
Vector 15 [_MainTex_ST]
"!!ARBvp1.0
# 58 ALU
PARAM c[18] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..15],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
MUL R2.xyz, vertex.position, c[11];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[9].y;
MUL R0, R0.xxyy, c[16];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R0.xyz, R3.y, c[14];
MUL R1.xyz, vertex.texcoord[1].y, R0;
MUL R0.w, vertex.color.y, c[17].y;
MOV R1.w, c[0].x;
MUL R0.xz, R0.w, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[17].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[14].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[14], R0;
DP3 R0.x, R1, c[12];
ADD R0.x, R0, c[12].w;
MUL R0.xyz, R0.x, c[12];
ADD R1.xyz, -R0, R1;
MAD R1.xyz, R0, c[13].x, R1;
DP3 R0.y, vertex.attrib[14], vertex.attrib[14];
RSQ R0.y, R0.y;
DP3 R0.x, vertex.normal, vertex.normal;
MUL R2.xyz, R0.y, vertex.attrib[14];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, vertex.normal;
MUL R3.xyz, R0.zxyw, R2.yzxw;
MAD R3.xyz, R0.yzxw, R2.zxyw, -R3;
DP4 result.position.w, R1, c[4];
DP4 result.position.z, R1, c[3];
DP4 result.position.y, R1, c[2];
DP4 result.position.x, R1, c[1];
MUL R3.xyz, R3, vertex.attrib[14].w;
DP3 R1.y, R3, c[5];
DP3 R1.x, R2, c[5];
DP3 R1.z, R0, c[5];
MUL result.texcoord[1].xyz, R1, c[10].w;
DP3 R1.y, R3, c[6];
DP3 R1.x, R2, c[6];
DP3 R1.z, R0, c[6];
MUL result.texcoord[2].xyz, R1, c[10].w;
DP3 R1.y, R3, c[7];
DP3 R1.x, R2, c[7];
DP3 R1.z, R0, c[7];
MUL result.texcoord[3].xyz, R1, c[10].w;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[15], c[15].zwzw;
END
# 58 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [unity_Scale]
Vector 10 [_Scale]
Vector 11 [_SquashPlaneNormal]
Float 12 [_SquashAmount]
Vector 13 [_Wind]
Vector 14 [_MainTex_ST]
"vs_2_0
; 62 ALU
def c15, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c16, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c17, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c15.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mul r2.xyz, v0, c10
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c8.y
mul r0, r0.xxyy, c16
frc r0, r0
mad r0, r0, c15.y, c15.z
frc r0, r0
mad r0, r0, c15.y, c15.w
abs r0, r0
mad r1, -r0, c17.x, c17.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r0.xyz, r3.y, c13
mul r1.xyz, v4.y, r0
mul r0.w, v5.y, c17
mov r1.w, c15.x
mul r0.xz, r0.w, v2
mul r0.y, v4, c17.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c13.w, r2
mad r1.xyz, v4.x, c13, r0
dp3 r0.x, r1, c11
add r0.x, r0, c11.w
mul r0.xyz, r0.x, c11
add r1.xyz, -r0, r1
mad r1.xyz, r0, c12.x, r1
dp3 r0.y, v1, v1
rsq r0.y, r0.y
dp3 r0.x, v2, v2
mul r2.xyz, r0.y, v1
rsq r0.x, r0.x
mul r0.xyz, r0.x, v2
mul r3.xyz, r0.zxyw, r2.yzxw
mad r3.xyz, r0.yzxw, r2.zxyw, -r3
dp4 oPos.w, r1, c3
dp4 oPos.z, r1, c2
dp4 oPos.y, r1, c1
dp4 oPos.x, r1, c0
mul r3.xyz, r3, v1.w
dp3 r1.y, r3, c4
dp3 r1.x, r2, c4
dp3 r1.z, r0, c4
mul oT1.xyz, r1, c9.w
dp3 r1.y, r3, c5
dp3 r1.x, r2, c5
dp3 r1.z, r0, c5
mul oT2.xyz, r1, c9.w
dp3 r1.y, r3, c6
dp3 r1.x, r2, c6
dp3 r1.z, r0, c6
mul oT3.xyz, r1, c9.w
mad oT0.xy, v3, c14, c14.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
SetTexture 0 [_BumpSpecMap] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 12 ALU, 1 TEX
PARAM c[1] = { { 2, 1, 0.5 } };
TEMP R0;
TEMP R1;
TEX R0.xyw, fragment.texcoord[0], texture[0], 2D;
MAD R1.xy, R0.wyzw, c[0].x, -c[0].y;
MUL R0.y, R1, R1;
MAD R0.y, -R1.x, R1.x, -R0;
ADD R0.y, R0, c[0];
RSQ R0.y, R0.y;
RCP R1.z, R0.y;
DP3 R0.w, fragment.texcoord[3], R1;
DP3 R0.y, R1, fragment.texcoord[1];
DP3 R0.z, R1, fragment.texcoord[2];
MAD result.color.xyz, R0.yzww, c[0].z, c[0].z;
MOV result.color.w, R0.x;
END
# 12 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
SetTexture 0 [_BumpSpecMap] 2D
"ps_2_0
; 14 ALU, 1 TEX
dcl_2d s0
def c0, 2.00000000, -1.00000000, 1.00000000, 0.50000000
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t0, s0
mov r0.y, r2
mov r0.x, r2.w
mad_pp r1.xy, r0, c0.x, c0.y
mul_pp r0.x, r1.y, r1.y
mad_pp r0.x, -r1, r1, -r0
add_pp r0.x, r0, c0.z
rsq_pp r0.x, r0.x
rcp_pp r1.z, r0.x
dp3 r0.z, t3, r1
dp3 r0.x, r1, t1
dp3 r0.y, r1, t2
mad_pp r0.xyz, r0, c0.w, c0.w
mov_pp r0.w, r2.x
mov_pp oC0, r0
"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassFinal" "RenderType"="TreeBark" }
  ZWrite Off
Program "vp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_ProjectionParams]
Vector 11 [unity_Scale]
Vector 12 [unity_SHAr]
Vector 13 [unity_SHAg]
Vector 14 [unity_SHAb]
Vector 15 [unity_SHBr]
Vector 16 [unity_SHBg]
Vector 17 [unity_SHBb]
Vector 18 [unity_SHC]
Vector 19 [_Scale]
Vector 20 [_SquashPlaneNormal]
Float 21 [_SquashAmount]
Vector 22 [_Wind]
Vector 23 [_MainTex_ST]
"!!ARBvp1.0
# 65 ALU
PARAM c[26] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..23],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1, 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
MUL R2.xyz, vertex.position, c[19];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[9].y;
MUL R0, R0.xxyy, c[24];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R0.xyz, R3.y, c[22];
MUL R1.xyz, vertex.texcoord[1].y, R0;
MUL R0.w, vertex.color.y, c[25].y;
MOV R1.w, c[0].x;
MUL R0.xz, R0.w, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[25].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[22].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[22], R0;
DP3 R0.x, R1, c[20];
ADD R0.x, R0, c[20].w;
MUL R0.xyz, R0.x, c[20];
ADD R1.xyz, -R0, R1;
MAD R1.xyz, R0, c[21].x, R1;
DP4 R0.w, R1, c[4];
DP4 R0.x, R1, c[1];
DP4 R0.y, R1, c[2];
MUL R2.xyz, R0.xyww, c[25].z;
MUL R2.y, R2, c[10].x;
ADD result.texcoord[1].xy, R2, R2.z;
DP3 R0.z, vertex.normal, vertex.normal;
RSQ R2.x, R0.z;
DP4 R0.z, R1, c[3];
MUL R1.xyz, R2.x, vertex.normal;
MUL R1.xyz, R1, c[11].w;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MOV R0.w, c[0].x;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[14];
DP4 R2.y, R0, c[13];
DP4 R2.x, R0, c[12];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[17];
DP4 R0.y, R1, c[16];
DP4 R0.x, R1, c[15];
MUL R1.xyz, R0.w, c[18];
ADD R0.xyz, R2, R0;
ADD result.texcoord[2].xyz, R0, R1;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MOV result.color.w, vertex.color;
END
# 65 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_Scale]
Vector 12 [unity_SHAr]
Vector 13 [unity_SHAg]
Vector 14 [unity_SHAb]
Vector 15 [unity_SHBr]
Vector 16 [unity_SHBg]
Vector 17 [unity_SHBb]
Vector 18 [unity_SHC]
Vector 19 [_Scale]
Vector 20 [_SquashPlaneNormal]
Float 21 [_SquashAmount]
Vector 22 [_Wind]
Vector 23 [_MainTex_ST]
"vs_2_0
; 69 ALU
def c24, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c25, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c26, 2.00000000, 3.00000000, 0.30000001, 0.10000000
def c27, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c24.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mul r2.xyz, v0, c19
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c8.y
mul r0, r0.xxyy, c25
frc r0, r0
mad r0, r0, c24.y, c24.z
frc r0, r0
mad r0, r0, c24.y, c24.w
abs r0, r0
mad r1, -r0, c26.x, c26.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r0.xyz, r3.y, c22
mul r1.xyz, v4.y, r0
mul r0.w, v5.y, c26
mov r1.w, c24.x
mul r0.xz, r0.w, v2
mul r0.y, v4, c26.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c22.w, r2
mad r1.xyz, v4.x, c22, r0
dp3 r0.x, r1, c20
add r0.x, r0, c20.w
mul r0.xyz, r0.x, c20
add r1.xyz, -r0, r1
mad r1.xyz, r0, c21.x, r1
dp4 r0.w, r1, c3
dp4 r0.x, r1, c0
dp4 r0.y, r1, c1
mul r2.xyz, r0.xyww, c27.x
mul r2.y, r2, c9.x
mad oT1.xy, r2.z, c10.zwzw, r2
dp3 r0.z, v2, v2
rsq r2.x, r0.z
dp4 r0.z, r1, c2
mul r1.xyz, r2.x, v2
mul r1.xyz, r1, c11.w
mov oPos, r0
mov oT1.zw, r0
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c24.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c14
dp4 r2.y, r0, c13
dp4 r2.x, r0, c12
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c17
dp4 r0.y, r1, c16
dp4 r0.x, r1, c15
mul r1.xyz, r0.w, c18
add r0.xyz, r2, r0
add oT2.xyz, r0, r1
mov oD0.xyz, c24.x
mad oT0.xy, v3, c23, c23.zwzw
mov oD0.w, v5
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_ProjectionParams]
Vector 11 [unity_Scale]
Vector 12 [unity_SHAr]
Vector 13 [unity_SHAg]
Vector 14 [unity_SHAb]
Vector 15 [unity_SHBr]
Vector 16 [unity_SHBg]
Vector 17 [unity_SHBb]
Vector 18 [unity_SHC]
Vector 19 [_Scale]
Vector 20 [_SquashPlaneNormal]
Float 21 [_SquashAmount]
Vector 22 [_Wind]
Vector 23 [_MainTex_ST]
"!!ARBvp1.0
# 65 ALU
PARAM c[26] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..23],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1, 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
MUL R2.xyz, vertex.position, c[19];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[9].y;
MUL R0, R0.xxyy, c[24];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R0.xyz, R3.y, c[22];
MUL R1.xyz, vertex.texcoord[1].y, R0;
MUL R0.w, vertex.color.y, c[25].y;
MOV R1.w, c[0].x;
MUL R0.xz, R0.w, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[25].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[22].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[22], R0;
DP3 R0.x, R1, c[20];
ADD R0.x, R0, c[20].w;
MUL R0.xyz, R0.x, c[20];
ADD R1.xyz, -R0, R1;
MAD R1.xyz, R0, c[21].x, R1;
DP4 R0.w, R1, c[4];
DP4 R0.x, R1, c[1];
DP4 R0.y, R1, c[2];
MUL R2.xyz, R0.xyww, c[25].z;
MUL R2.y, R2, c[10].x;
ADD result.texcoord[1].xy, R2, R2.z;
DP3 R0.z, vertex.normal, vertex.normal;
RSQ R2.x, R0.z;
DP4 R0.z, R1, c[3];
MUL R1.xyz, R2.x, vertex.normal;
MUL R1.xyz, R1, c[11].w;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MOV R0.w, c[0].x;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[14];
DP4 R2.y, R0, c[13];
DP4 R2.x, R0, c[12];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[17];
DP4 R0.y, R1, c[16];
DP4 R0.x, R1, c[15];
MUL R1.xyz, R0.w, c[18];
ADD R0.xyz, R2, R0;
ADD result.texcoord[2].xyz, R0, R1;
MOV result.color.xyz, c[0].x;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MOV result.color.w, vertex.color;
END
# 65 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_Scale]
Vector 12 [unity_SHAr]
Vector 13 [unity_SHAg]
Vector 14 [unity_SHAb]
Vector 15 [unity_SHBr]
Vector 16 [unity_SHBg]
Vector 17 [unity_SHBb]
Vector 18 [unity_SHC]
Vector 19 [_Scale]
Vector 20 [_SquashPlaneNormal]
Float 21 [_SquashAmount]
Vector 22 [_Wind]
Vector 23 [_MainTex_ST]
"vs_2_0
; 69 ALU
def c24, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c25, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c26, 2.00000000, 3.00000000, 0.30000001, 0.10000000
def c27, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c24.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mul r2.xyz, v0, c19
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c8.y
mul r0, r0.xxyy, c25
frc r0, r0
mad r0, r0, c24.y, c24.z
frc r0, r0
mad r0, r0, c24.y, c24.w
abs r0, r0
mad r1, -r0, c26.x, c26.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r0.xyz, r3.y, c22
mul r1.xyz, v4.y, r0
mul r0.w, v5.y, c26
mov r1.w, c24.x
mul r0.xz, r0.w, v2
mul r0.y, v4, c26.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c22.w, r2
mad r1.xyz, v4.x, c22, r0
dp3 r0.x, r1, c20
add r0.x, r0, c20.w
mul r0.xyz, r0.x, c20
add r1.xyz, -r0, r1
mad r1.xyz, r0, c21.x, r1
dp4 r0.w, r1, c3
dp4 r0.x, r1, c0
dp4 r0.y, r1, c1
mul r2.xyz, r0.xyww, c27.x
mul r2.y, r2, c9.x
mad oT1.xy, r2.z, c10.zwzw, r2
dp3 r0.z, v2, v2
rsq r2.x, r0.z
dp4 r0.z, r1, c2
mul r1.xyz, r2.x, v2
mul r1.xyz, r1, c11.w
mov oPos, r0
mov oT1.zw, r0
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c24.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c14
dp4 r2.y, r0, c13
dp4 r2.x, r0, c12
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c17
dp4 r0.y, r1, c16
dp4 r0.x, r1, c15
mul r1.xyz, r0.w, c18
add r0.xyz, r2, r0
add oT2.xyz, r0, r1
mov oD0.xyz, c24.x
mad oT0.xy, v3, c23, c23.zwzw
mov oD0.w, v5
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 3 [_LightBuffer] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 16 ALU, 3 TEX
PARAM c[2] = { program.local[0..1] };
TEMP R0;
TEMP R1;
TEMP R2;
TXP R1, fragment.texcoord[1], texture[3], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R2.w, fragment.texcoord[0], texture[1], 2D;
MUL R0.xyz, R0, c[1];
LG2 R1.x, R1.x;
LG2 R1.z, R1.z;
LG2 R1.y, R1.y;
ADD R1.xyz, -R1, fragment.texcoord[2];
MUL R2.xyz, R1, c[0];
MUL R2.w, R2, c[1].x;
LG2 R1.w, R1.w;
MUL R1.w, -R1, R2;
MUL R2.xyz, R1.w, R2;
MUL R0.xyz, R0, fragment.color.primary.w;
MAD result.color.xyz, R0, R1, R2;
MAD result.color.w, R1, c[0], R0;
END
# 16 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 3 [_LightBuffer] 2D
"ps_2_0
; 14 ALU, 3 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s3
dcl t0.xy
dcl v0.xyzw
dcl t1
dcl t2.xyz
texld r1, t0, s1
texld r2, t0, s0
texldp r0, t1, s3
log_pp r0.x, r0.x
log_pp r1.x, r0.w
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r3.xyz, -r0, t2
mul_pp r0.x, r1.w, c1
mul_pp r0.x, -r1, r0
mul_pp r1.xyz, r2, c1
mul_pp r4.xyz, r3, c0
mul_pp r2.xyz, r0.x, r4
mul_pp r1.xyz, r1, v0.w
mad_pp r1.xyz, r1, r3, r2
mad_pp r1.w, r0.x, c0, r2
mov_pp oC0, r1
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 3 [_LightBuffer] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 12 ALU, 3 TEX
PARAM c[2] = { program.local[0..1] };
TEMP R0;
TEMP R1;
TEMP R2;
TXP R1, fragment.texcoord[1], texture[3], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R2.w, fragment.texcoord[0], texture[1], 2D;
ADD R1.xyz, R1, fragment.texcoord[2];
MUL R0.xyz, R0, c[1];
MUL R2.w, R2, c[1].x;
MUL R1.w, R1, R2;
MUL R2.xyz, R1, c[0];
MUL R2.xyz, R1.w, R2;
MUL R0.xyz, R0, fragment.color.primary.w;
MAD result.color.xyz, R0, R1, R2;
MAD result.color.w, R1, c[0], R0;
END
# 12 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 3 [_LightBuffer] 2D
"ps_2_0
; 10 ALU, 3 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s3
dcl t0.xy
dcl v0.xyzw
dcl t1
dcl t2.xyz
texld r0, t0, s1
texld r1, t0, s0
texldp r2, t1, s3
add_pp r2.xyz, r2, t2
mul_pp r0.x, r0.w, c1
mul_pp r0.x, r2.w, r0
mul_pp r3.xyz, r2, c0
mul_pp r1.xyz, r1, c1
mul_pp r3.xyz, r0.x, r3
mul_pp r1.xyz, r1, v0.w
mad_pp r1.xyz, r1, r2, r3
mad_pp r1.w, r0.x, c0, r1
mov_pp oC0, r1
"
}
}
 }
 Pass {
  Name "SHADOWCASTER"
  Tags { "LIGHTMODE"="SHADOWCASTER" "RenderType"="TreeBark" }
  Cull Off
  Fog { Mode Off }
  Offset 1, 1
Program "vp" {
SubProgram "opengl " {
Keywords { "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [unity_LightShadowBias]
Vector 11 [_Scale]
Vector 12 [_SquashPlaneNormal]
Float 13 [_SquashAmount]
Vector 14 [_Wind]
"!!ARBvp1.0
# 41 ALU
PARAM c[17] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..14],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
ADD R0.z, vertex.color.y, R0.x;
MUL R2.xyz, vertex.position, c[11];
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[9].y;
MUL R0, R0.xxyy, c[15];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R0.xyz, R3.y, c[14];
MUL R1.xyz, vertex.texcoord[1].y, R0;
MUL R0.w, vertex.color.y, c[16].y;
MUL R0.xz, R0.w, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[16].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[14].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[14], R0;
DP3 R0.x, R1, c[12];
ADD R0.x, R0, c[12].w;
MUL R0.xyz, R0.x, c[12];
ADD R1.xyz, -R0, R1;
MAD R0.xyz, R0, c[13].x, R1;
MOV R0.w, c[0].x;
DP4 R1.y, R0, c[4];
DP4 R1.x, R0, c[3];
ADD R1.x, R1, c[10];
MAX R1.z, R1.x, -R1.y;
ADD R1.z, R1, -R1.x;
MAD result.position.z, R1, c[10].y, R1.x;
MOV result.position.w, R1.y;
DP4 result.position.y, R0, c[2];
DP4 result.position.x, R0, c[1];
END
# 41 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [unity_LightShadowBias]
Vector 10 [_Scale]
Vector 11 [_SquashPlaneNormal]
Float 12 [_SquashAmount]
Vector 13 [_Wind]
"vs_2_0
; 46 ALU
def c14, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c15, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c16, 2.00000000, 3.00000000, 0.30000001, 0.10000000
def c17, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v2
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c14.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mul r2.xyz, v0, c10
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c8.y
mul r0, r0.xxyy, c15
frc r0, r0
mad r0, r0, c14.y, c14.z
frc r0, r0
mad r0, r0, c14.y, c14.w
abs r0, r0
mad r1, -r0, c16.x, c16.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r0.xyz, r3.y, c13
mul r1.xyz, v4.y, r0
mul r0.w, v5.y, c16
mov r1.w, c14.x
mul r0.xz, r0.w, v2
mul r0.y, v4, c16.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c13.w, r2
mad r1.xyz, v4.x, c13, r0
dp3 r0.x, r1, c11
add r0.x, r0, c11.w
mul r0.xyz, r0.x, c11
add r1.xyz, -r0, r1
mad r1.xyz, r0, c12.x, r1
dp4 r0.x, r1, c2
add r0.x, r0, c9
max r0.y, r0.x, c17.x
add r0.y, r0, -r0.x
mad r0.z, r0.y, c9.y, r0.x
dp4 r0.w, r1, c3
dp4 r0.x, r1, c0
dp4 r0.y, r1, c1
mov oPos, r0
mov oT0, r0
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_LightPositionRange]
Vector 11 [_Scale]
Vector 12 [_SquashPlaneNormal]
Float 13 [_SquashAmount]
Vector 14 [_Wind]
"!!ARBvp1.0
# 40 ALU
PARAM c[17] = { { 1, 2, -0.5, 3 },
		state.matrix.mvp,
		program.local[5..14],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[8];
ADD R0.x, vertex.color, R0;
ADD R0.z, vertex.color.y, R0.x;
MUL R2.xyz, vertex.position, c[11];
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[9].y;
MUL R0, R0.xxyy, c[15];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R0.xyz, R3.y, c[14];
MUL R1.xyz, vertex.texcoord[1].y, R0;
MUL R0.w, vertex.color.y, c[16].y;
MOV R1.w, c[0].x;
MUL R0.xz, R0.w, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[16].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[14].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[14], R0;
DP3 R0.x, R1, c[12];
ADD R0.x, R0, c[12].w;
MUL R0.xyz, R0.x, c[12];
ADD R1.xyz, -R0, R1;
MAD R1.xyz, R0, c[13].x, R1;
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
ADD result.texcoord[0].xyz, R0, -c[10];
DP4 result.position.w, R1, c[4];
DP4 result.position.z, R1, c[3];
DP4 result.position.y, R1, c[2];
DP4 result.position.x, R1, c[1];
END
# 40 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_LightPositionRange]
Vector 10 [_Scale]
Vector 11 [_SquashPlaneNormal]
Float 12 [_SquashAmount]
Vector 13 [_Wind]
"vs_2_0
; 44 ALU
def c14, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c15, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c16, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_normal0 v2
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c7
dp3 r0.x, c14.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mul r2.xyz, v0, c10
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c8.y
mul r0, r0.xxyy, c15
frc r0, r0
mad r0, r0, c14.y, c14.z
frc r0, r0
mad r0, r0, c14.y, c14.w
abs r0, r0
mad r1, -r0, c16.x, c16.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r0.xyz, r3.y, c13
mul r1.xyz, v4.y, r0
mul r0.w, v5.y, c16
mov r1.w, c14.x
mul r0.xz, r0.w, v2
mul r0.y, v4, c16.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c13.w, r2
mad r1.xyz, v4.x, c13, r0
dp3 r0.x, r1, c11
add r0.x, r0, c11.w
mul r0.xyz, r0.x, c11
add r1.xyz, -r0, r1
mad r1.xyz, r0, c12.x, r1
dp4 r0.z, r1, c6
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
add oT0.xyz, r0, -c9
dp4 oPos.w, r1, c3
dp4 oPos.z, r1, c2
dp4 oPos.y, r1, c1
dp4 oPos.x, r1, c0
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SHADOWS_DEPTH" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 1 ALU, 0 TEX
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_DEPTH" }
"ps_2_0
; 4 ALU
dcl t0.xyzw
rcp r0.x, t0.w
mul r0.x, t0.z, r0
mov_pp r0, r0.x
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Vector 0 [_LightPositionRange]
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 7 ALU, 0 TEX
PARAM c[3] = { program.local[0],
		{ 1, 255, 65025, 1.6058138e+008 },
		{ 0.0039215689 } };
TEMP R0;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.x, R0.x;
RCP R0.x, R0.x;
MUL R0.x, R0, c[0].w;
MUL R0, R0.x, c[1];
FRC R0, R0;
MAD result.color, -R0.yzww, c[2].x, R0;
END
# 7 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_CUBE" }
Vector 0 [_LightPositionRange]
"ps_2_0
; 10 ALU
def c1, 1.00000000, 255.00000000, 65025.00000000, 160581376.00000000
def c2, 0.00392157, 0, 0, 0
dcl t0.xyz
dp3 r0.x, t0, t0
rsq r0.x, r0.x
rcp r0.x, r0.x
mul r0.x, r0, c0.w
mul r0, r0.x, c1
frc r1, r0
mov r0.z, -r1.w
mov r0.xyw, -r1.yzxw
mad r0, r0, c2.x, r1
mov_pp oC0, r0
"
}
}
 }
 Pass {
  Name "SHADOWCOLLECTOR"
  Tags { "LIGHTMODE"="SHADOWCOLLECTOR" "RenderType"="TreeBark" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Keywords { "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Matrix 9 [_Object2World]
Matrix 13 [unity_World2Shadow0]
Matrix 17 [unity_World2Shadow1]
Matrix 21 [unity_World2Shadow2]
Matrix 25 [unity_World2Shadow3]
Vector 29 [_Time]
Vector 30 [_Scale]
Vector 31 [_SquashPlaneNormal]
Float 32 [_SquashAmount]
Vector 33 [_Wind]
"!!ARBvp1.0
# 56 ALU
PARAM c[36] = { { 1, 2, -0.5, 3 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..33],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[12];
ADD R0.x, vertex.color, R0;
MOV R2.w, c[0].x;
MUL R2.xyz, vertex.position, c[30];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[29].y;
MUL R0, R0.xxyy, c[34];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R0.xyz, R3.y, c[33];
MUL R1.xyz, vertex.texcoord[1].y, R0;
MUL R0.w, vertex.color.y, c[35].y;
MUL R0.xz, R0.w, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[35].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[33].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[33], R0;
DP3 R0.x, R1, c[31];
ADD R0.x, R0, c[31].w;
MUL R0.xyz, R0.x, c[31];
ADD R1.xyz, -R0, R1;
MAD R2.xyz, R0, c[32].x, R1;
DP4 R0.w, R2, c[3];
DP4 R1.w, R2, c[12];
DP4 R0.z, R2, c[11];
DP4 R0.x, R2, c[9];
DP4 R0.y, R2, c[10];
MOV R1.xyz, R0;
MOV R0.w, -R0;
DP4 result.texcoord[0].z, R1, c[15];
DP4 result.texcoord[0].y, R1, c[14];
DP4 result.texcoord[0].x, R1, c[13];
DP4 result.texcoord[1].z, R1, c[19];
DP4 result.texcoord[1].y, R1, c[18];
DP4 result.texcoord[1].x, R1, c[17];
DP4 result.texcoord[2].z, R1, c[23];
DP4 result.texcoord[2].y, R1, c[22];
DP4 result.texcoord[2].x, R1, c[21];
DP4 result.texcoord[3].z, R1, c[27];
DP4 result.texcoord[3].y, R1, c[26];
DP4 result.texcoord[3].x, R1, c[25];
MOV result.texcoord[4], R0;
DP4 result.position.w, R2, c[8];
DP4 result.position.z, R2, c[7];
DP4 result.position.y, R2, c[6];
DP4 result.position.x, R2, c[5];
END
# 56 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [unity_World2Shadow0]
Matrix 16 [unity_World2Shadow1]
Matrix 20 [unity_World2Shadow2]
Matrix 24 [unity_World2Shadow3]
Vector 28 [_Time]
Vector 29 [_Scale]
Vector 30 [_SquashPlaneNormal]
Float 31 [_SquashAmount]
Vector 32 [_Wind]
"vs_2_0
; 60 ALU
def c33, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c34, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c35, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_normal0 v2
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c11
dp3 r0.x, c33.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mov r2.w, c33.x
mul r2.xyz, v0, c29
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c28.y
mul r0, r0.xxyy, c34
frc r0, r0
mad r0, r0, c33.y, c33.z
frc r0, r0
mad r0, r0, c33.y, c33.w
abs r0, r0
mad r1, -r0, c35.x, c35.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r0.xyz, r3.y, c32
mul r1.xyz, v4.y, r0
mul r0.w, v5.y, c35
mul r0.xz, r0.w, v2
mul r0.y, v4, c35.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c32.w, r2
mad r1.xyz, v4.x, c32, r0
dp3 r0.x, r1, c30
add r0.x, r0, c30.w
mul r0.xyz, r0.x, c30
add r1.xyz, -r0, r1
mad r2.xyz, r0, c31.x, r1
dp4 r0.w, r2, c2
dp4 r1.w, r2, c11
dp4 r0.z, r2, c10
dp4 r0.x, r2, c8
dp4 r0.y, r2, c9
mov r1.xyz, r0
mov r0.w, -r0
dp4 oT0.z, r1, c14
dp4 oT0.y, r1, c13
dp4 oT0.x, r1, c12
dp4 oT1.z, r1, c18
dp4 oT1.y, r1, c17
dp4 oT1.x, r1, c16
dp4 oT2.z, r1, c22
dp4 oT2.y, r1, c21
dp4 oT2.x, r1, c20
dp4 oT3.z, r1, c26
dp4 oT3.y, r1, c25
dp4 oT3.x, r1, c24
mov oT4, r0
dp4 oPos.w, r2, c7
dp4 oPos.z, r2, c6
dp4 oPos.y, r2, c5
dp4 oPos.x, r2, c4
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [unity_World2Shadow0]
Matrix 16 [unity_World2Shadow1]
Matrix 20 [unity_World2Shadow2]
Matrix 24 [unity_World2Shadow3]
Vector 28 [_Time]
Vector 29 [_Scale]
Vector 30 [_SquashPlaneNormal]
Float 31 [_SquashAmount]
Vector 32 [_Wind]
"vs_2_0
; 60 ALU
def c33, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c34, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c35, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_normal0 v2
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c11
dp3 r0.x, c33.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mov r2.w, c33.x
mul r2.xyz, v0, c29
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c28.y
mul r0, r0.xxyy, c34
frc r0, r0
mad r0, r0, c33.y, c33.z
frc r0, r0
mad r0, r0, c33.y, c33.w
abs r0, r0
mad r1, -r0, c35.x, c35.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r0.xyz, r3.y, c32
mul r1.xyz, v4.y, r0
mul r0.w, v5.y, c35
mul r0.xz, r0.w, v2
mul r0.y, v4, c35.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c32.w, r2
mad r1.xyz, v4.x, c32, r0
dp3 r0.x, r1, c30
add r0.x, r0, c30.w
mul r0.xyz, r0.x, c30
add r1.xyz, -r0, r1
mad r2.xyz, r0, c31.x, r1
dp4 r0.w, r2, c2
dp4 r1.w, r2, c11
dp4 r0.z, r2, c10
dp4 r0.x, r2, c8
dp4 r0.y, r2, c9
mov r1.xyz, r0
mov r0.w, -r0
dp4 oT0.z, r1, c14
dp4 oT0.y, r1, c13
dp4 oT0.x, r1, c12
dp4 oT1.z, r1, c18
dp4 oT1.y, r1, c17
dp4 oT1.x, r1, c16
dp4 oT2.z, r1, c22
dp4 oT2.y, r1, c21
dp4 oT2.x, r1, c20
dp4 oT3.z, r1, c26
dp4 oT3.y, r1, c25
dp4 oT3.x, r1, c24
mov oT4, r0
dp4 oPos.w, r2, c7
dp4 oPos.z, r2, c6
dp4 oPos.y, r2, c5
dp4 oPos.x, r2, c4
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Matrix 9 [_Object2World]
Matrix 13 [unity_World2Shadow0]
Matrix 17 [unity_World2Shadow1]
Matrix 21 [unity_World2Shadow2]
Matrix 25 [unity_World2Shadow3]
Vector 29 [_Time]
Vector 30 [_Scale]
Vector 31 [_SquashPlaneNormal]
Float 32 [_SquashAmount]
Vector 33 [_Wind]
"!!ARBvp1.0
# 56 ALU
PARAM c[36] = { { 1, 2, -0.5, 3 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..33],
		{ 1.975, 0.79299998, 0.375, 0.193 },
		{ 0.30000001, 0.1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.x, c[0];
DP3 R0.x, R0.x, c[12];
ADD R0.x, vertex.color, R0;
MOV R2.w, c[0].x;
MUL R2.xyz, vertex.position, c[30];
ADD R0.z, vertex.color.y, R0.x;
MOV R0.y, R0.x;
DP3 R0.x, R2, R0.z;
ADD R0.xy, R0, c[29].y;
MUL R0, R0.xxyy, c[34];
FRC R0, R0;
MAD R0, R0, c[0].y, c[0].z;
FRC R0, R0;
MAD R0, R0, c[0].y, -c[0].x;
ABS R0, R0;
MAD R1, -R0, c[0].y, c[0].w;
MUL R0, R0, R0;
MUL R0, R0, R1;
ADD R3.xy, R0.xzzw, R0.ywzw;
MUL R0.xyz, R3.y, c[33];
MUL R1.xyz, vertex.texcoord[1].y, R0;
MUL R0.w, vertex.color.y, c[35].y;
MUL R0.xz, R0.w, vertex.normal;
MUL R0.y, vertex.texcoord[1], c[35].x;
MAD R0.xyz, R3.xyxw, R0, R1;
MAD R0.xyz, R0, c[33].w, R2;
MAD R1.xyz, vertex.texcoord[1].x, c[33], R0;
DP3 R0.x, R1, c[31];
ADD R0.x, R0, c[31].w;
MUL R0.xyz, R0.x, c[31];
ADD R1.xyz, -R0, R1;
MAD R2.xyz, R0, c[32].x, R1;
DP4 R0.w, R2, c[3];
DP4 R1.w, R2, c[12];
DP4 R0.z, R2, c[11];
DP4 R0.x, R2, c[9];
DP4 R0.y, R2, c[10];
MOV R1.xyz, R0;
MOV R0.w, -R0;
DP4 result.texcoord[0].z, R1, c[15];
DP4 result.texcoord[0].y, R1, c[14];
DP4 result.texcoord[0].x, R1, c[13];
DP4 result.texcoord[1].z, R1, c[19];
DP4 result.texcoord[1].y, R1, c[18];
DP4 result.texcoord[1].x, R1, c[17];
DP4 result.texcoord[2].z, R1, c[23];
DP4 result.texcoord[2].y, R1, c[22];
DP4 result.texcoord[2].x, R1, c[21];
DP4 result.texcoord[3].z, R1, c[27];
DP4 result.texcoord[3].y, R1, c[26];
DP4 result.texcoord[3].x, R1, c[25];
MOV result.texcoord[4], R0;
DP4 result.position.w, R2, c[8];
DP4 result.position.z, R2, c[7];
DP4 result.position.y, R2, c[6];
DP4 result.position.x, R2, c[5];
END
# 56 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [unity_World2Shadow0]
Matrix 16 [unity_World2Shadow1]
Matrix 20 [unity_World2Shadow2]
Matrix 24 [unity_World2Shadow3]
Vector 28 [_Time]
Vector 29 [_Scale]
Vector 30 [_SquashPlaneNormal]
Float 31 [_SquashAmount]
Vector 32 [_Wind]
"vs_2_0
; 60 ALU
def c33, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c34, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c35, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_normal0 v2
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c11
dp3 r0.x, c33.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mov r2.w, c33.x
mul r2.xyz, v0, c29
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c28.y
mul r0, r0.xxyy, c34
frc r0, r0
mad r0, r0, c33.y, c33.z
frc r0, r0
mad r0, r0, c33.y, c33.w
abs r0, r0
mad r1, -r0, c35.x, c35.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r0.xyz, r3.y, c32
mul r1.xyz, v4.y, r0
mul r0.w, v5.y, c35
mul r0.xz, r0.w, v2
mul r0.y, v4, c35.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c32.w, r2
mad r1.xyz, v4.x, c32, r0
dp3 r0.x, r1, c30
add r0.x, r0, c30.w
mul r0.xyz, r0.x, c30
add r1.xyz, -r0, r1
mad r2.xyz, r0, c31.x, r1
dp4 r0.w, r2, c2
dp4 r1.w, r2, c11
dp4 r0.z, r2, c10
dp4 r0.x, r2, c8
dp4 r0.y, r2, c9
mov r1.xyz, r0
mov r0.w, -r0
dp4 oT0.z, r1, c14
dp4 oT0.y, r1, c13
dp4 oT0.x, r1, c12
dp4 oT1.z, r1, c18
dp4 oT1.y, r1, c17
dp4 oT1.x, r1, c16
dp4 oT2.z, r1, c22
dp4 oT2.y, r1, c21
dp4 oT2.x, r1, c20
dp4 oT3.z, r1, c26
dp4 oT3.y, r1, c25
dp4 oT3.x, r1, c24
mov oT4, r0
dp4 oPos.w, r2, c7
dp4 oPos.z, r2, c6
dp4 oPos.y, r2, c5
dp4 oPos.x, r2, c4
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [unity_World2Shadow0]
Matrix 16 [unity_World2Shadow1]
Matrix 20 [unity_World2Shadow2]
Matrix 24 [unity_World2Shadow3]
Vector 28 [_Time]
Vector 29 [_Scale]
Vector 30 [_SquashPlaneNormal]
Float 31 [_SquashAmount]
Vector 32 [_Wind]
"vs_2_0
; 60 ALU
def c33, 1.00000000, 2.00000000, -0.50000000, -1.00000000
def c34, 1.97500002, 0.79299998, 0.37500000, 0.19300000
def c35, 2.00000000, 3.00000000, 0.30000001, 0.10000000
dcl_position0 v0
dcl_normal0 v2
dcl_texcoord1 v4
dcl_color0 v5
mov r0.xyz, c11
dp3 r0.x, c33.x, r0
add r0.x, v5, r0
mov r0.y, r0.x
mov r2.w, c33.x
mul r2.xyz, v0, c29
add r0.x, v5.y, r0
dp3 r0.x, r2, r0.x
add r0.xy, r0, c28.y
mul r0, r0.xxyy, c34
frc r0, r0
mad r0, r0, c33.y, c33.z
frc r0, r0
mad r0, r0, c33.y, c33.w
abs r0, r0
mad r1, -r0, c35.x, c35.y
mul r0, r0, r0
mul r0, r0, r1
add r3.xy, r0.xzzw, r0.ywzw
mul r0.xyz, r3.y, c32
mul r1.xyz, v4.y, r0
mul r0.w, v5.y, c35
mul r0.xz, r0.w, v2
mul r0.y, v4, c35.z
mad r0.xyz, r3.xyxw, r0, r1
mad r0.xyz, r0, c32.w, r2
mad r1.xyz, v4.x, c32, r0
dp3 r0.x, r1, c30
add r0.x, r0, c30.w
mul r0.xyz, r0.x, c30
add r1.xyz, -r0, r1
mad r2.xyz, r0, c31.x, r1
dp4 r0.w, r2, c2
dp4 r1.w, r2, c11
dp4 r0.z, r2, c10
dp4 r0.x, r2, c8
dp4 r0.y, r2, c9
mov r1.xyz, r0
mov r0.w, -r0
dp4 oT0.z, r1, c14
dp4 oT0.y, r1, c13
dp4 oT0.x, r1, c12
dp4 oT1.z, r1, c18
dp4 oT1.y, r1, c17
dp4 oT1.x, r1, c16
dp4 oT2.z, r1, c22
dp4 oT2.y, r1, c21
dp4 oT2.x, r1, c20
dp4 oT3.z, r1, c26
dp4 oT3.y, r1, c25
dp4 oT3.x, r1, c24
mov oT4, r0
dp4 oPos.w, r2, c7
dp4 oPos.z, r2, c6
dp4 oPos.y, r2, c5
dp4 oPos.x, r2, c4
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
SetTexture 1 [_ShadowMapTexture] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 21 ALU, 1 TEX
PARAM c[5] = { program.local[0..3],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
SLT R1, fragment.texcoord[4].w, c[3];
SGE R0, fragment.texcoord[4].w, c[2];
MUL R0, R0, R1;
MUL R1.xyz, R0.y, fragment.texcoord[1];
MAD R1.xyz, R0.x, fragment.texcoord[0], R1;
MAD R0.xyz, R0.z, fragment.texcoord[2], R1;
MAD R0.xyz, fragment.texcoord[3], R0.w, R0;
MAD_SAT R1.y, fragment.texcoord[4].w, c[1].z, c[1].w;
MOV result.color.y, c[4].x;
TEX R0.x, R0, texture[1], 2D;
ADD R0.z, R0.x, -R0;
MOV R0.x, c[4];
CMP R1.x, R0.z, c[1], R0;
MUL R0.y, -fragment.texcoord[4].w, c[0].w;
ADD R0.y, R0, c[4].x;
MUL R0.xy, R0.y, c[4];
FRC R0.zw, R0.xyxy;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[4].z, R0.z;
ADD_SAT result.color.x, R1, R1.y;
MOV result.color.zw, R0.xyxy;
END
# 21 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightShadowData]
Vector 2 [_LightSplitsNear]
Vector 3 [_LightSplitsFar]
SetTexture 1 [_ShadowMapTexture] 2D
"ps_2_0
; 26 ALU, 1 TEX
dcl_2d s1
def c4, 1.00000000, 0.00000000, 255.00000000, 0.00392157
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4.xyzw
add r1, t4.w, -c3
add r0, t4.w, -c2
cmp r1, r1, c4.y, c4.x
cmp r0, r0, c4.x, c4.y
mul r0, r0, r1
mul r1.xyz, r0.y, t1
mad r1.xyz, r0.x, t0, r1
mad r0.xyz, r0.z, t2, r1
mad r1.xyz, t3, r0.w, r0
mov r2.x, c1
mov r2.y, c4.z
texld r0, r1, s1
add r0.x, r0, -r1.z
cmp r0.x, r0, c4, r2
mul r1.x, -t4.w, c0.w
add r1.x, r1, c4
mov r2.x, c4
mul r2.xy, r1.x, r2
mad_sat r1.x, t4.w, c1.z, c1.w
frc r2.xy, r2
add_sat r0.x, r0, r1
mov r1.y, r2
mad r1.x, -r2.y, c4.w, r2
mov r0.w, r1.y
mov r0.z, r1.x
mov r0.y, c4.x
mov_pp oC0, r0
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightShadowData]
Vector 2 [_LightSplitsNear]
Vector 3 [_LightSplitsFar]
SetTexture 1 [_ShadowMapTexture] 2D
"ps_2_0
; 25 ALU, 1 TEX
dcl_2d s1
def c4, 0.00000000, 1.00000000, 255.00000000, 0.00392157
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4.xyzw
add r1, t4.w, -c3
add r0, t4.w, -c2
cmp r1, r1, c4.x, c4.y
cmp r0, r0, c4.y, c4.x
mul r0, r0, r1
mul r1.xyz, r0.y, t1
mad r1.xyz, r0.x, t0, r1
mad r0.xyz, r0.z, t2, r1
mad r1.xyz, t3, r0.w, r0
mov r1.w, c4.y
mov r0.x, c1
add r0.x, c4.y, -r0
mov r0.y, c4
texldp r2, r1, s1
mul r1.x, -t4.w, c0.w
add r1.x, r1, c4.y
mad r0.x, r2, r0, c1
mul r2.xy, r1.x, c4.yzxw
mad_sat r1.x, t4.w, c1.z, c1.w
frc r2.xy, r2
add_sat r0.x, r0, r1
mov r1.y, r2
mad r1.x, -r2.y, c4.w, r2
mov r0.w, r1.y
mov r0.z, r1.x
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
SetTexture 1 [_ShadowMapTexture] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 32 ALU, 1 TEX
PARAM c[9] = { program.local[0..7],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
TEMP R2;
ADD R0.xyz, fragment.texcoord[4], -c[3];
ADD R2.xyz, fragment.texcoord[4], -c[6];
DP3 R0.x, R0, R0;
ADD R1.xyz, fragment.texcoord[4], -c[4];
DP3 R0.y, R1, R1;
ADD R1.xyz, fragment.texcoord[4], -c[5];
DP3 R0.w, R2, R2;
DP3 R0.z, R1, R1;
SLT R2, R0, c[7];
ADD_SAT R0.xyz, R2.yzww, -R2;
MUL R1.xyz, R0.x, fragment.texcoord[1];
MAD R1.xyz, R2.x, fragment.texcoord[0], R1;
MAD R1.xyz, R0.y, fragment.texcoord[2], R1;
MAD R0.xyz, fragment.texcoord[3], R0.z, R1;
ADD R1.xyz, -fragment.texcoord[4], c[2];
MOV result.color.y, c[8].x;
TEX R0.x, R0, texture[1], 2D;
ADD R0.y, R0.x, -R0.z;
DP3 R0.z, R1, R1;
RSQ R0.z, R0.z;
MOV R0.x, c[8];
CMP R0.x, R0.y, c[1], R0;
MUL R0.y, -fragment.texcoord[4].w, c[0].w;
ADD R0.y, R0, c[8].x;
RCP R1.x, R0.z;
MUL R0.zw, R0.y, c[8].xyxy;
MAD_SAT R0.y, R1.x, c[1].z, c[1].w;
FRC R0.zw, R0;
ADD_SAT result.color.x, R0, R0.y;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[8].z, R0.z;
MOV result.color.zw, R0.xyxy;
END
# 32 instructions, 3 R-regs
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
SetTexture 1 [_ShadowMapTexture] 2D
"ps_2_0
; 37 ALU, 1 TEX
dcl_2d s1
def c8, 1.00000000, 255.00000000, 0.00392157, 0.00000000
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4
add r0.xyz, t4, -c3
add r2.xyz, t4, -c6
dp3 r0.x, r0, r0
add r1.xyz, t4, -c4
dp3 r0.y, r1, r1
add r1.xyz, t4, -c5
dp3 r0.z, r1, r1
dp3 r0.w, r2, r2
add r0, r0, -c7
cmp r0, r0, c8.w, c8.x
mov r1.x, r0.y
mov r1.z, r0.w
mov r1.y, r0.z
add_sat r1.xyz, r1, -r0
mul r2.xyz, r1.x, t1
mad r0.xyz, r0.x, t0, r2
mad r0.xyz, r1.y, t2, r0
mad r1.xyz, t3, r1.z, r0
add r2.xyz, -t4, c2
texld r0, r1, s1
mov r1.x, c1
add r0.x, r0, -r1.z
cmp r0.x, r0, c8, r1
dp3 r1.x, r2, r2
mul r2.x, -t4.w, c0.w
rsq r1.x, r1.x
add r2.x, r2, c8
rcp r1.x, r1.x
mad_sat r1.x, r1, c1.z, c1.w
mul r2.xy, r2.x, c8
frc r2.xy, r2
add_sat r0.x, r0, r1
mov r1.y, r2
mad r1.x, -r2.y, c8.z, r2
mov r0.w, r1.y
mov r0.z, r1.x
mov r0.y, c8.x
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
SetTexture 1 [_ShadowMapTexture] 2D
"ps_2_0
; 38 ALU, 1 TEX
dcl_2d s1
def c8, 0.00000000, 1.00000000, 255.00000000, 0.00392157
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4
add r0.xyz, t4, -c3
add r2.xyz, t4, -c6
dp3 r0.x, r0, r0
add r1.xyz, t4, -c4
dp3 r0.y, r1, r1
add r1.xyz, t4, -c5
dp3 r0.z, r1, r1
dp3 r0.w, r2, r2
add r0, r0, -c7
cmp r0, r0, c8.x, c8.y
mov r1.z, r0.w
mov r1.x, r0.y
mov r1.y, r0.z
add_sat r1.xyz, r1, -r0
mul r2.xyz, r1.x, t1
mad r0.xyz, r0.x, t0, r2
mad r0.xyz, r1.y, t2, r0
mad r0.xyz, t3, r1.z, r0
mov r0.w, c8.y
add r1.xyz, -t4, c2
dp3 r1.x, r1, r1
rsq r1.x, r1.x
rcp r1.x, r1.x
mad_sat r1.x, r1, c1.z, c1.w
texldp r2, r0, s1
mov r0.x, c1
add r0.x, c8.y, -r0
mad r0.x, r2, r0, c1
mul r2.x, -t4.w, c0.w
add r2.x, r2, c8.y
mul r2.xy, r2.x, c8.yzxw
frc r2.xy, r2
add_sat r0.x, r0, r1
mov r1.y, r2
mad r1.x, -r2.y, c8.w, r2
mov r0.w, r1.y
mov r0.z, r1.x
mov r0.y, c8
mov_pp oC0, r0
"
}
}
 }
}
SubShader { 
 Tags { "RenderType"="TreeBark" }
 Pass {
  Tags { "RenderType"="TreeBark" }
  Lighting On
  Material {
   Ambient (1,1,1,1)
   Diffuse (1,1,1,1)
  }
  SetTexture [_MainTex] { combine texture * primary double, texture alpha * primary alpha }
  SetTexture [_MainTex] { ConstantColor [_Color] combine previous * constant, previous alpha }
 }
}
Dependency "BillboardShader" = "Hidden/Nature/Tree Creator Bark Rendertex"
}