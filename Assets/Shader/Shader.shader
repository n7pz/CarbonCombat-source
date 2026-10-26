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
SubShader { 
 Tags { "QUEUE"="Geometry" "IGNOREPROJECTOR"="False" "RenderType"="Opaque" }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardBase" "QUEUE"="Geometry" "IGNOREPROJECTOR"="False" "RenderType"="Opaque" }
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
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
"!!ARBvp1.0
# 57 ALU
PARAM c[23] = { { 1 },
		state.matrix.mvp,
		program.local[5..22] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[13].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MUL R1, R0.xyzz, R0.yzzx;
MOV R0.w, c[0].x;
DP4 R2.z, R0, c[18];
DP4 R2.y, R0, c[17];
DP4 R2.x, R0, c[16];
MUL R0.y, R2.w, R2.w;
DP4 R3.z, R1, c[21];
DP4 R3.y, R1, c[20];
DP4 R3.x, R1, c[19];
ADD R2.xyz, R2, R3;
MAD R0.x, R0, R0, -R0.y;
MUL R3.xyz, R0.x, c[22];
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
ADD result.texcoord[5].xyz, R2, R3;
MUL R3.xyz, R0, vertex.attrib[14].w;
MOV R0, c[15];
MOV R1.xyz, c[14];
MOV R1.w, c[0].x;
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R2.xyz, R2, c[13].w, -vertex.position;
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 R0.y, R3, c[5];
DP3 R0.w, -R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[13].w;
DP3 R0.y, R3, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[13].w;
DP3 R0.y, R3, c[7];
DP3 R0.w, -R2, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
DP3 result.texcoord[0].y, R2, R3;
DP3 result.texcoord[4].y, R3, R1;
MUL result.texcoord[3], R0, c[13].w;
DP3 result.texcoord[0].z, vertex.normal, R2;
DP3 result.texcoord[0].x, R2, vertex.attrib[14];
DP3 result.texcoord[4].z, vertex.normal, R1;
DP3 result.texcoord[4].x, vertex.attrib[14], R1;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 57 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_Scale]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
"vs_2_0
; 60 ALU
def c22, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mul r1.xyz, v2, c12.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c22.x
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.y, r2.w, r2.w
dp4 r3.z, r1, c20
dp4 r3.y, r1, c19
dp4 r3.x, r1, c18
add r1.xyz, r2, r3
mad r0.x, r0, r0, -r0.y
mul r2.xyz, r0.x, c21
add oT5.xyz, r1, r2
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r3.xyz, r0, v1.w
mov r0, c10
dp4 r4.z, c14, r0
mov r0, c9
dp4 r4.y, c14, r0
mov r1.w, c22.x
mov r1.xyz, c13
dp4 r2.z, r1, c10
dp4 r2.x, r1, c8
dp4 r2.y, r1, c9
mad r2.xyz, r2, c12.w, -v0
mov r1, c8
dp4 r4.x, c14, r1
dp3 r0.y, r3, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT1, r0, c12.w
dp3 r0.y, r3, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT2, r0, c12.w
dp3 r0.y, r3, c6
dp3 r0.w, -r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
dp3 oT0.y, r2, r3
dp3 oT4.y, r3, r4
mul oT3, r0, c12.w
dp3 oT0.z, v2, r2
dp3 oT0.x, r2, v1
dp3 oT4.z, v2, r4
dp3 oT4.x, v1, r4
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [unity_Scale]
Vector 14 [_WorldSpaceCameraPos]
Vector 16 [unity_LightmapST]
"!!ARBvp1.0
# 33 ALU
PARAM c[17] = { { 1 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, R0, vertex.attrib[14].w;
MOV R0.xyz, c[14];
MOV R0.w, c[0].x;
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
MAD R1.xyz, R1, c[13].w, -vertex.position;
DP3 R0.y, R2, c[5];
DP3 R0.w, -R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[13].w;
DP3 R0.y, R2, c[6];
DP3 R0.w, -R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[13].w;
DP3 R0.y, R2, c[7];
DP3 R0.w, -R1, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
DP3 result.texcoord[0].y, R1, R2;
MUL result.texcoord[3], R0, c[13].w;
DP3 result.texcoord[0].z, vertex.normal, R1;
DP3 result.texcoord[0].x, R1, vertex.attrib[14];
MAD result.texcoord[4].xy, vertex.texcoord[1], c[16], c[16].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 33 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_Scale]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [unity_LightmapST]
"vs_2_0
; 34 ALU
def c15, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord1 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r0, v1.w
mov r0.xyz, c13
mov r0.w, c15.x
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
mad r1.xyz, r1, c12.w, -v0
dp3 r0.y, r2, c4
dp3 r0.w, -r1, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT1, r0, c12.w
dp3 r0.y, r2, c5
dp3 r0.w, -r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT2, r0, c12.w
dp3 r0.y, r2, c6
dp3 r0.w, -r1, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
dp3 oT0.y, r1, r2
mul oT3, r0, c12.w
dp3 oT0.z, v2, r1
dp3 oT0.x, r1, v1
mad oT4.xy, v3, c14, c14.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
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
"!!ARBvp1.0
# 63 ALU
PARAM c[24] = { { 1, 0.5 },
		state.matrix.mvp,
		program.local[5..23] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[14].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MUL R1, R0.xyzz, R0.yzzx;
MOV R0.w, c[0].x;
DP4 R2.z, R0, c[19];
DP4 R2.y, R0, c[18];
DP4 R2.x, R0, c[17];
MUL R0.y, R2.w, R2.w;
DP4 R3.z, R1, c[22];
DP4 R3.y, R1, c[21];
DP4 R3.x, R1, c[20];
ADD R2.xyz, R2, R3;
MAD R0.x, R0, R0, -R0.y;
MUL R3.xyz, R0.x, c[23];
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
ADD result.texcoord[5].xyz, R2, R3;
MUL R3.xyz, R0, vertex.attrib[14].w;
MOV R0, c[16];
MOV R1.xyz, c[15];
MOV R1.w, c[0].x;
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R2.xyz, R2, c[14].w, -vertex.position;
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP4 R1.z, R0, c[11];
DP3 R0.w, -R2, c[5];
DP3 result.texcoord[4].y, R3, R1;
DP3 R0.y, R3, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[14].w;
DP3 R0.w, -R2, c[6];
DP3 R0.y, R3, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[14].w;
DP3 R0.w, -R2, c[7];
DP3 R0.y, R3, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[14].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP3 result.texcoord[4].z, vertex.normal, R1;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP3 result.texcoord[4].x, vertex.attrib[14], R1;
DP3 result.texcoord[0].y, R2, R3;
DP3 result.texcoord[0].z, vertex.normal, R2;
DP3 result.texcoord[0].x, R2, vertex.attrib[14];
MUL R2.xyz, R0.xyww, c[0].y;
MOV R1.x, R2;
MUL R1.y, R2, c[13].x;
ADD result.texcoord[6].xy, R1, R2.z;
MOV result.position, R0;
MOV result.texcoord[6].zw, R0;
END
# 63 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
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
"vs_2_0
; 65 ALU
def c24, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mul r1.xyz, v2, c14.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c24.x
dp4 r2.z, r0, c19
dp4 r2.y, r0, c18
dp4 r2.x, r0, c17
mul r0.y, r2.w, r2.w
dp4 r3.z, r1, c22
dp4 r3.y, r1, c21
dp4 r3.x, r1, c20
add r1.xyz, r2, r3
mad r0.x, r0, r0, -r0.y
mul r2.xyz, r0.x, c23
add oT5.xyz, r1, r2
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r3.xyz, r0, v1.w
mov r0, c10
dp4 r4.z, c16, r0
mov r0, c9
dp4 r4.y, c16, r0
mov r1.w, c24.x
mov r1.xyz, c15
dp4 r2.z, r1, c10
dp4 r2.x, r1, c8
dp4 r2.y, r1, c9
mad r2.xyz, r2, c14.w, -v0
mov r1, c8
dp4 r4.x, c16, r1
dp3 r0.y, r3, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT1, r0, c14.w
dp3 r0.y, r3, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT2, r0, c14.w
dp3 r0.y, r3, c6
dp3 r0.w, -r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT3, r0, c14.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c24.y
mul r1.y, r1, c12.x
dp3 oT0.y, r2, r3
dp3 oT4.y, r3, r4
dp3 oT0.z, v2, r2
dp3 oT0.x, r2, v1
dp3 oT4.z, v2, r4
dp3 oT4.x, v1, r4
mad oT6.xy, r1.z, c13.zwzw, r1
mov oPos, r0
mov oT6.zw, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
Vector 14 [unity_Scale]
Vector 15 [_WorldSpaceCameraPos]
Vector 17 [unity_LightmapST]
"!!ARBvp1.0
# 39 ALU
PARAM c[18] = { { 1, 0.5 },
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, R0, vertex.attrib[14].w;
MOV R0.xyz, c[15];
MOV R0.w, c[0].x;
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
MAD R1.xyz, R1, c[14].w, -vertex.position;
DP3 R0.w, -R1, c[5];
DP3 result.texcoord[0].y, R1, R2;
DP3 R0.y, R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[14].w;
DP3 R0.w, -R1, c[6];
DP3 R0.y, R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[14].w;
DP3 R0.w, -R1, c[7];
DP3 R0.y, R2, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[14].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP3 result.texcoord[0].z, vertex.normal, R1;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].y;
DP3 result.texcoord[0].x, R1, vertex.attrib[14];
MOV R1.x, R2;
MUL R1.y, R2, c[13].x;
ADD result.texcoord[5].xy, R1, R2.z;
MOV result.position, R0;
MOV result.texcoord[5].zw, R0;
MAD result.texcoord[4].xy, vertex.texcoord[1], c[17], c[17].zwzw;
END
# 39 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_Scale]
Vector 15 [_WorldSpaceCameraPos]
Vector 16 [unity_LightmapST]
"vs_2_0
; 40 ALU
def c17, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord1 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r0, v1.w
mov r0.xyz, c15
mov r0.w, c17.x
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
mad r1.xyz, r1, c14.w, -v0
dp3 r0.w, -r1, c4
dp3 oT0.y, r1, r2
dp3 r0.y, r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT1, r0, c14.w
dp3 r0.w, -r1, c5
dp3 r0.y, r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT2, r0, c14.w
dp3 r0.w, -r1, c6
dp3 r0.y, r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT3, r0, c14.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp3 oT0.z, v2, r1
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c17.y
dp3 oT0.x, r1, v1
mov r1.x, r2
mul r1.y, r2, c12.x
mad oT5.xy, r2.z, c13.zwzw, r1
mov oPos, r0
mov oT5.zw, r0
mad oT4.xy, v3, c16, c16.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
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
"!!ARBvp1.0
# 88 ALU
PARAM c[31] = { { 1, 0 },
		state.matrix.mvp,
		program.local[5..30] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R3.xyz, vertex.normal, c[13].w;
DP4 R0.x, vertex.position, c[6];
ADD R1, -R0.x, c[17];
DP3 R3.w, R3, c[6];
DP3 R4.x, R3, c[5];
DP3 R3.x, R3, c[7];
MUL R2, R3.w, R1;
DP4 R0.x, vertex.position, c[5];
ADD R0, -R0.x, c[16];
MUL R1, R1, R1;
MOV R4.z, R3.x;
MAD R2, R4.x, R0, R2;
MOV R4.w, c[0].x;
DP4 R4.y, vertex.position, c[7];
MAD R1, R0, R0, R1;
ADD R0, -R4.y, c[18];
MAD R1, R0, R0, R1;
MAD R0, R3.x, R0, R2;
MUL R2, R1, c[19];
MOV R4.y, R3.w;
RSQ R1.x, R1.x;
RSQ R1.y, R1.y;
RSQ R1.w, R1.w;
RSQ R1.z, R1.z;
MUL R0, R0, R1;
ADD R1, R2, c[0].x;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].y;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[21];
MAD R1.xyz, R0.x, c[20], R1;
MAD R0.xyz, R0.z, c[22], R1;
MAD R1.xyz, R0.w, c[23], R0;
MUL R0, R4.xyzz, R4.yzzx;
DP4 R3.z, R0, c[29];
DP4 R3.y, R0, c[28];
DP4 R3.x, R0, c[27];
MUL R1.w, R3, R3;
MAD R0.x, R4, R4, -R1.w;
MOV R1.w, c[0].x;
DP4 R2.z, R4, c[26];
DP4 R2.y, R4, c[25];
DP4 R2.x, R4, c[24];
ADD R2.xyz, R2, R3;
MUL R3.xyz, R0.x, c[30];
ADD R3.xyz, R2, R3;
MOV R0.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R0.yzxw;
ADD result.texcoord[5].xyz, R3, R1;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R2;
MOV R1.xyz, c[14];
MUL R3.xyz, R0, vertex.attrib[14].w;
MOV R0, c[15];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R2.xyz, R2, c[13].w, -vertex.position;
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 R0.y, R3, c[5];
DP3 R0.w, -R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[13].w;
DP3 R0.y, R3, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[13].w;
DP3 R0.y, R3, c[7];
DP3 R0.w, -R2, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
DP3 result.texcoord[0].y, R2, R3;
DP3 result.texcoord[4].y, R3, R1;
MUL result.texcoord[3], R0, c[13].w;
DP3 result.texcoord[0].z, vertex.normal, R2;
DP3 result.texcoord[0].x, R2, vertex.attrib[14];
DP3 result.texcoord[4].z, vertex.normal, R1;
DP3 result.texcoord[4].x, vertex.attrib[14], R1;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 88 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_Scale]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_4LightPosX0]
Vector 16 [unity_4LightPosY0]
Vector 17 [unity_4LightPosZ0]
Vector 18 [unity_4LightAtten0]
Vector 19 [unity_LightColor0]
Vector 20 [unity_LightColor1]
Vector 21 [unity_LightColor2]
Vector 22 [unity_LightColor3]
Vector 23 [unity_SHAr]
Vector 24 [unity_SHAg]
Vector 25 [unity_SHAb]
Vector 26 [unity_SHBr]
Vector 27 [unity_SHBg]
Vector 28 [unity_SHBb]
Vector 29 [unity_SHC]
"vs_2_0
; 91 ALU
def c30, 1.00000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mul r3.xyz, v2, c12.w
dp4 r0.x, v0, c5
add r1, -r0.x, c16
dp3 r3.w, r3, c5
dp3 r4.x, r3, c4
dp3 r3.x, r3, c6
mul r2, r3.w, r1
dp4 r0.x, v0, c4
add r0, -r0.x, c15
mul r1, r1, r1
mov r4.z, r3.x
mad r2, r4.x, r0, r2
mov r4.w, c30.x
dp4 r4.y, v0, c6
mad r1, r0, r0, r1
add r0, -r4.y, c17
mad r1, r0, r0, r1
mad r0, r3.x, r0, r2
mul r2, r1, c18
mov r4.y, r3.w
rsq r1.x, r1.x
rsq r1.y, r1.y
rsq r1.w, r1.w
rsq r1.z, r1.z
mul r0, r0, r1
add r1, r2, c30.x
dp4 r2.z, r4, c25
dp4 r2.y, r4, c24
dp4 r2.x, r4, c23
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c30.y
mul r0, r0, r1
mul r1.xyz, r0.y, c20
mad r1.xyz, r0.x, c19, r1
mad r0.xyz, r0.z, c21, r1
mad r1.xyz, r0.w, c22, r0
mul r0, r4.xyzz, r4.yzzx
mul r1.w, r3, r3
dp4 r3.z, r0, c28
dp4 r3.y, r0, c27
dp4 r3.x, r0, c26
mad r1.w, r4.x, r4.x, -r1
mul r0.xyz, r1.w, c29
add r2.xyz, r2, r3
add r2.xyz, r2, r0
add oT5.xyz, r2, r1
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r3.xyz, r0, v1.w
mov r0, c10
dp4 r4.z, c14, r0
mov r0, c9
dp4 r4.y, c14, r0
mov r1.w, c30.x
mov r1.xyz, c13
dp4 r2.z, r1, c10
dp4 r2.x, r1, c8
dp4 r2.y, r1, c9
mad r2.xyz, r2, c12.w, -v0
mov r1, c8
dp4 r4.x, c14, r1
dp3 r0.y, r3, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT1, r0, c12.w
dp3 r0.y, r3, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT2, r0, c12.w
dp3 r0.y, r3, c6
dp3 r0.w, -r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
dp3 oT0.y, r2, r3
dp3 oT4.y, r3, r4
mul oT3, r0, c12.w
dp3 oT0.z, v2, r2
dp3 oT0.x, r2, v1
dp3 oT4.z, v2, r4
dp3 oT4.x, v1, r4
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
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
"!!ARBvp1.0
# 94 ALU
PARAM c[32] = { { 1, 0, 0.5 },
		state.matrix.mvp,
		program.local[5..31] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R3.xyz, vertex.normal, c[14].w;
DP4 R0.x, vertex.position, c[6];
ADD R1, -R0.x, c[18];
DP3 R3.w, R3, c[6];
DP3 R4.x, R3, c[5];
DP3 R3.x, R3, c[7];
MUL R2, R3.w, R1;
DP4 R0.x, vertex.position, c[5];
ADD R0, -R0.x, c[17];
MUL R1, R1, R1;
MOV R4.z, R3.x;
MAD R2, R4.x, R0, R2;
MOV R4.w, c[0].x;
DP4 R4.y, vertex.position, c[7];
MAD R1, R0, R0, R1;
ADD R0, -R4.y, c[19];
MAD R1, R0, R0, R1;
MAD R0, R3.x, R0, R2;
MUL R2, R1, c[20];
MOV R4.y, R3.w;
RSQ R1.x, R1.x;
RSQ R1.y, R1.y;
RSQ R1.w, R1.w;
RSQ R1.z, R1.z;
MUL R0, R0, R1;
ADD R1, R2, c[0].x;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].y;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[22];
MAD R1.xyz, R0.x, c[21], R1;
MAD R0.xyz, R0.z, c[23], R1;
MAD R1.xyz, R0.w, c[24], R0;
MUL R0, R4.xyzz, R4.yzzx;
DP4 R3.z, R0, c[30];
DP4 R3.y, R0, c[29];
DP4 R3.x, R0, c[28];
MUL R1.w, R3, R3;
MAD R0.x, R4, R4, -R1.w;
MOV R1.w, c[0].x;
DP4 R2.z, R4, c[27];
DP4 R2.y, R4, c[26];
DP4 R2.x, R4, c[25];
ADD R2.xyz, R2, R3;
MUL R3.xyz, R0.x, c[31];
ADD R3.xyz, R2, R3;
MOV R0.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R0.yzxw;
ADD result.texcoord[5].xyz, R3, R1;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R2;
MOV R1.xyz, c[15];
MUL R3.xyz, R0, vertex.attrib[14].w;
MOV R0, c[16];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R2.xyz, R2, c[14].w, -vertex.position;
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP4 R1.z, R0, c[11];
DP3 R0.w, -R2, c[5];
DP3 result.texcoord[4].y, R3, R1;
DP3 R0.y, R3, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[14].w;
DP3 R0.w, -R2, c[6];
DP3 R0.y, R3, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[14].w;
DP3 R0.w, -R2, c[7];
DP3 R0.y, R3, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[14].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP3 result.texcoord[4].z, vertex.normal, R1;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP3 result.texcoord[4].x, vertex.attrib[14], R1;
DP3 result.texcoord[0].y, R2, R3;
DP3 result.texcoord[0].z, vertex.normal, R2;
DP3 result.texcoord[0].x, R2, vertex.attrib[14];
MUL R2.xyz, R0.xyww, c[0].z;
MOV R1.x, R2;
MUL R1.y, R2, c[13].x;
ADD result.texcoord[6].xy, R1, R2.z;
MOV result.position, R0;
MOV result.texcoord[6].zw, R0;
END
# 94 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
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
"vs_2_0
; 96 ALU
def c32, 1.00000000, 0.00000000, 0.50000000, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mul r3.xyz, v2, c14.w
dp4 r0.x, v0, c5
add r1, -r0.x, c18
dp3 r3.w, r3, c5
dp3 r4.x, r3, c4
dp3 r3.x, r3, c6
mul r2, r3.w, r1
dp4 r0.x, v0, c4
add r0, -r0.x, c17
mul r1, r1, r1
mov r4.z, r3.x
mad r2, r4.x, r0, r2
mov r4.w, c32.x
dp4 r4.y, v0, c6
mad r1, r0, r0, r1
add r0, -r4.y, c19
mad r1, r0, r0, r1
mad r0, r3.x, r0, r2
mul r2, r1, c20
mov r4.y, r3.w
rsq r1.x, r1.x
rsq r1.y, r1.y
rsq r1.w, r1.w
rsq r1.z, r1.z
mul r0, r0, r1
add r1, r2, c32.x
dp4 r2.z, r4, c27
dp4 r2.y, r4, c26
dp4 r2.x, r4, c25
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c32.y
mul r0, r0, r1
mul r1.xyz, r0.y, c22
mad r1.xyz, r0.x, c21, r1
mad r0.xyz, r0.z, c23, r1
mad r1.xyz, r0.w, c24, r0
mul r0, r4.xyzz, r4.yzzx
mul r1.w, r3, r3
dp4 r3.z, r0, c30
dp4 r3.y, r0, c29
dp4 r3.x, r0, c28
mad r1.w, r4.x, r4.x, -r1
mul r0.xyz, r1.w, c31
add r2.xyz, r2, r3
add r2.xyz, r2, r0
add oT5.xyz, r2, r1
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r3.xyz, r0, v1.w
mov r0, c10
dp4 r4.z, c16, r0
mov r0, c9
dp4 r4.y, c16, r0
mov r1.w, c32.x
mov r1.xyz, c15
dp4 r2.z, r1, c10
dp4 r2.x, r1, c8
dp4 r2.y, r1, c9
mad r2.xyz, r2, c14.w, -v0
mov r1, c8
dp4 r4.x, c16, r1
dp3 r0.y, r3, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT1, r0, c14.w
dp3 r0.y, r3, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT2, r0, c14.w
dp3 r0.y, r3, c6
dp3 r0.w, -r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT3, r0, c14.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c32.z
mul r1.y, r1, c12.x
dp3 oT0.y, r2, r3
dp3 oT4.y, r3, r4
dp3 oT0.z, v2, r2
dp3 oT0.x, r2, v1
dp3 oT4.z, v2, r4
dp3 oT4.x, v1, r4
mad oT6.xy, r1.z, c13.zwzw, r1
mov oPos, r0
mov oT6.zw, r0
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Float 4 [_Fresnel]
Float 5 [_FresnelInverse]
Vector 6 [_RefColor]
Vector 7 [_RefColorInverse]
Vector 8 [_Specular]
Float 9 [_Gloss]
SetTexture 0 [_CubeMap] CUBE
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 47 ALU, 1 TEX
PARAM c[12] = { program.local[0..9],
		{ 1, 0, 128, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.x, fragment.texcoord[1].z;
MOV R1.y, fragment.texcoord[2].z;
MOV R1.z, fragment.texcoord[3];
MOV R0.x, fragment.texcoord[1].w;
MOV R0.z, fragment.texcoord[3].w;
MOV R0.y, fragment.texcoord[2].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[10].w, R0;
DP3 R0.w, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.w, R0.w;
MOV R1.xyz, fragment.texcoord[4];
MAD R1.xyz, fragment.texcoord[0], R0.w, R1;
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R1.x, R0.w, R1.z;
MAX R1.w, R1.x, c[10].y;
MOV R1.xyz, c[11];
DP3 R1.x, R1, c[0];
MOV R0.w, c[10].z;
MUL R0.w, R0, c[9].x;
POW R0.w, R1.w, R0.w;
MUL R1.w, R0, R1.x;
MAX R1.y, fragment.texcoord[4].z, c[10];
MUL R1.xyz, R1.y, c[0];
MUL R1, R1, c[10].w;
MUL R2.xyz, R1.w, c[8];
DP3 R0.w, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.w, R0.w;
MAD R1.w, -R0, fragment.texcoord[0].z, c[10].x;
MUL R3.xyz, R1, R2;
POW R2.x, R1.w, c[2].x;
MUL R0.w, R0, fragment.texcoord[0].z;
POW R2.w, R0.w, c[2].x;
MUL R2.xyz, R2.x, c[3];
MAD R2.xyz, R2.w, c[1], R2;
MAD R1.xyz, R2, R1, R3;
POW R1.w, R1.w, c[4].x;
POW R0.w, R0.w, c[5].x;
MAD R1.xyz, R2, fragment.texcoord[5], R1;
MOV result.color.w, c[10].x;
TEX R0.xyz, R0, texture[0], CUBE;
MUL R3.xyz, R0, c[7];
MUL R0.xyz, R0, c[6];
MUL R0.xyz, R0, R1.w;
MAD R0.xyz, R3, R0.w, R0;
ADD result.color.xyz, R1, R0;
END
# 47 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Float 4 [_Fresnel]
Float 5 [_FresnelInverse]
Vector 6 [_RefColor]
Vector 7 [_RefColorInverse]
Vector 8 [_Specular]
Float 9 [_Gloss]
SetTexture 0 [_CubeMap] CUBE
"ps_2_0
; 60 ALU, 1 TEX
dcl_cube s0
def c10, 1.00000000, 0.00000000, 128.00000000, 2.00000000
def c11, 0.21997070, 0.70703125, 0.07098389, 0
dcl t0.xyz
dcl t1.xyzw
dcl t2.xyzw
dcl t3.xyzw
dcl t4.xyz
dcl t5.xyz
mov_pp r2.x, t1.z
mov_pp r2.y, t2.z
mov_pp r2.z, t3
mov r1.x, t1.w
mov r1.z, t3.w
mov r1.y, t2.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c10.w, r1
mov_pp r1.xyz, t4
mov_pp r0.w, c10.x
texld r3, r0, s0
dp3_pp r0.x, t0, t0
rsq_pp r0.x, r0.x
mad_pp r0.xyz, t0, r0.x, r1
dp3_pp r0.x, r0, r0
rsq_pp r1.x, r0.x
mul_pp r0.z, r1.x, r0
mov_pp r0.x, c9
max_pp r1.x, r0.z, c10.y
mul_pp r0.x, c10.z, r0
pow r2.x, r1.x, r0.x
mov_pp r1.xyz, c0
mov r0.x, r2.x
dp3_pp r2.x, c11, r1
mul r1.w, r0.x, r2.x
max_pp r1.x, t4.z, c10.y
mul_pp r1.xyz, r1.x, c0
mul_pp r2, r1, c10.w
dp3 r0.x, t0, t0
rsq r1.x, r0.x
mul_pp r4.xyz, r2.w, c8
mad r0.x, -r1, t0.z, c10
mul r0.z, r1.x, t0
pow r1.w, r0.z, c2.x
mul_pp r5.xyz, r2, r4
pow r4.w, r0.x, c2.x
mul r4.xyz, r4.w, c3
mad r1.xyz, r1.w, c1, r4
mad_pp r2.xyz, r1, r2, r5
mad_pp r2.xyz, r1, t5, r2
pow r1.x, r0.x, c4.x
mov r0.x, r1.x
mul r4.xyz, r3, c6
pow r1.x, r0.z, c5.x
mul r4.xyz, r4, r0.x
mul r3.xyz, r3, c7
mov r0.x, r1.x
mad r0.xyz, r3, r0.x, r4
add_pp r0.xyz, r2, r0
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [unity_Lightmap] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 29 ALU, 2 TEX
PARAM c[8] = { program.local[0..6],
		{ 1, 8, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
DP3 R1.w, fragment.texcoord[0], fragment.texcoord[0];
RSQ R1.w, R1.w;
MAD R2.w, -R1, fragment.texcoord[0].z, c[7].x;
POW R3.x, R2.w, c[3].x;
MOV R1.x, fragment.texcoord[1].z;
MOV R1.y, fragment.texcoord[2].z;
MOV R1.z, fragment.texcoord[3];
MOV R0.x, fragment.texcoord[1].w;
MOV R0.z, fragment.texcoord[3].w;
MOV R0.y, fragment.texcoord[2].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[7].z, R0;
MUL R1.w, R1, fragment.texcoord[0].z;
POW R2.w, R2.w, c[1].x;
MOV result.color.w, c[7].x;
TEX R1.xyz, R0, texture[0], CUBE;
TEX R0, fragment.texcoord[4], texture[1], 2D;
MUL R2.xyz, R1, c[6];
MUL R1.xyz, R1, c[5];
MUL R1.xyz, R1, R3.x;
POW R3.x, R1.w, c[4].x;
MAD R2.xyz, R2, R3.x, R1;
MUL R1.xyz, R2.w, c[2];
POW R1.w, R1.w, c[1].x;
MAD R1.xyz, R1.w, c[0], R1;
MUL R0.xyz, R0.w, R0;
MUL R0.xyz, R0, R1;
MAD result.color.xyz, R0, c[7].y, R2;
END
# 29 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [unity_Lightmap] 2D
"ps_2_0
; 40 ALU, 2 TEX
dcl_cube s0
dcl_2d s1
def c7, 1.00000000, 2.00000000, 8.00000000, 0
dcl t0.xyz
dcl t1.xyzw
dcl t2.xyzw
dcl t3.xyzw
dcl t4.xy
mov_pp r2.x, t1.z
mov_pp r2.y, t2.z
mov_pp r2.z, t3
mov r1.x, t1.w
mov r1.z, t3.w
mov r1.y, t2.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c7.y, r1
mov_pp r0.w, c7.x
texld r4, r0, s0
texld r2, t4, s1
dp3 r0.x, t0, t0
rsq r1.x, r0.x
mad r0.x, -r1, t0.z, c7
pow r3.x, r0.x, c3.x
mul r5.xyz, r4, c5
mul r0.z, r1.x, t0
mov r1.x, r3.x
pow r3.w, r0.z, c4.x
mul r5.xyz, r5, r1.x
mov r1.x, r3.w
mul r4.xyz, r4, c6
mad r3.xyz, r4, r1.x, r5
pow r1.w, r0.x, c1.x
mov r0.x, r1.w
pow r4.x, r0.z, c1.x
mul r1.xyz, r0.x, c2
mov r0.x, r4.x
mad r0.xyz, r0.x, c0, r1
mul_pp r1.xyz, r2.w, r2
mul_pp r0.xyz, r1, r0
mad_pp r0.xyz, r0, c7.z, r3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Float 4 [_Fresnel]
Float 5 [_FresnelInverse]
Vector 6 [_RefColor]
Vector 7 [_RefColorInverse]
Vector 8 [_Specular]
Float 9 [_Gloss]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_ShadowMapTexture] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 49 ALU, 2 TEX
PARAM c[12] = { program.local[0..9],
		{ 1, 0, 128, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TXP R2.x, fragment.texcoord[6], texture[1], 2D;
MOV R1.x, fragment.texcoord[1].z;
MOV R1.y, fragment.texcoord[2].z;
MOV R1.z, fragment.texcoord[3];
MOV R0.x, fragment.texcoord[1].w;
MOV R0.z, fragment.texcoord[3].w;
MOV R0.y, fragment.texcoord[2].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[10].w, R0;
DP3 R0.w, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.w, R0.w;
MOV R1.xyz, fragment.texcoord[4];
MAD R1.xyz, fragment.texcoord[0], R0.w, R1;
DP3 R0.w, R1, R1;
RSQ R1.x, R0.w;
MOV R0.w, c[10].z;
MUL R1.y, R0.w, c[9].x;
MUL R1.x, R1, R1.z;
MAX R0.w, R1.x, c[10].y;
POW R0.w, R0.w, R1.y;
MOV R1.xyz, c[11];
DP3 R1.w, R1, c[0];
MAX R2.y, fragment.texcoord[4].z, c[10];
MUL R1.w, R0, R1;
MUL R1.xyz, R2.y, c[0];
MUL R1, R2.x, R1;
MUL R1, R1, c[10].w;
MUL R2.xyz, R1.w, c[8];
DP3 R0.w, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.w, R0.w;
MAD R1.w, -R0, fragment.texcoord[0].z, c[10].x;
MUL R3.xyz, R1, R2;
POW R2.x, R1.w, c[2].x;
MUL R0.w, R0, fragment.texcoord[0].z;
POW R2.w, R0.w, c[2].x;
MUL R2.xyz, R2.x, c[3];
MAD R2.xyz, R2.w, c[1], R2;
MAD R1.xyz, R2, R1, R3;
POW R1.w, R1.w, c[4].x;
POW R0.w, R0.w, c[5].x;
MAD R1.xyz, R2, fragment.texcoord[5], R1;
MOV result.color.w, c[10].x;
TEX R0.xyz, R0, texture[0], CUBE;
MUL R3.xyz, R0, c[7];
MUL R0.xyz, R0, c[6];
MUL R0.xyz, R0, R1.w;
MAD R0.xyz, R3, R0.w, R0;
ADD result.color.xyz, R1, R0;
END
# 49 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Float 4 [_Fresnel]
Float 5 [_FresnelInverse]
Vector 6 [_RefColor]
Vector 7 [_RefColorInverse]
Vector 8 [_Specular]
Float 9 [_Gloss]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_ShadowMapTexture] 2D
"ps_2_0
; 61 ALU, 2 TEX
dcl_cube s0
dcl_2d s1
def c10, 1.00000000, 0.00000000, 128.00000000, 2.00000000
def c11, 0.21997070, 0.70703125, 0.07098389, 0
dcl t0.xyz
dcl t1.xyzw
dcl t2.xyzw
dcl t3.xyzw
dcl t4.xyz
dcl t5.xyz
dcl t6
texldp r4, t6, s1
mov_pp r2.x, t1.z
mov_pp r2.y, t2.z
mov_pp r2.z, t3
mov r1.x, t1.w
mov r1.z, t3.w
mov r1.y, t2.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c10.w, r1
mov_pp r1.xyz, t4
texld r3, r0, s0
dp3_pp r0.x, t0, t0
rsq_pp r0.x, r0.x
mad_pp r0.xyz, t0, r0.x, r1
dp3_pp r0.x, r0, r0
rsq_pp r1.x, r0.x
mul_pp r0.z, r1.x, r0
mov_pp r0.x, c9
max_pp r1.x, r0.z, c10.y
mul_pp r0.x, c10.z, r0
pow r2.x, r1.x, r0.x
mov_pp r1.xyz, c0
mov r0.x, r2.x
dp3_pp r2.x, c11, r1
mul r0.w, r0.x, r2.x
max_pp r1.x, t4.z, c10.y
mul_pp r0.xyz, r1.x, c0
mul_pp r1, r4.x, r0
mul_pp r2, r1, c10.w
dp3 r0.x, t0, t0
rsq r1.x, r0.x
mul_pp r4.xyz, r2.w, c8
mad r0.x, -r1, t0.z, c10
mul r0.z, r1.x, t0
pow r1.w, r0.z, c2.x
mul_pp r5.xyz, r2, r4
pow r4.w, r0.x, c2.x
mul r4.xyz, r4.w, c3
mad r1.xyz, r1.w, c1, r4
mad_pp r2.xyz, r1, r2, r5
mad_pp r2.xyz, r1, t5, r2
pow r1.x, r0.x, c4.x
mov r0.x, r1.x
mul r4.xyz, r3, c6
pow r1.x, r0.z, c5.x
mul r4.xyz, r4, r0.x
mul r3.xyz, r3, c7
mov r0.x, r1.x
mad r0.xyz, r3, r0.x, r4
mov_pp r0.w, c10.x
add_pp r0.xyz, r2, r0
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_ShadowMapTexture] 2D
SetTexture 2 [unity_Lightmap] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 35 ALU, 3 TEX
PARAM c[8] = { program.local[0..6],
		{ 1, 8, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TXP R3.x, fragment.texcoord[5], texture[1], 2D;
DP3 R1.w, fragment.texcoord[0], fragment.texcoord[0];
RSQ R2.w, R1.w;
MAD R1.w, -R2, fragment.texcoord[0].z, c[7].x;
MOV R1.x, fragment.texcoord[1].z;
MOV R1.y, fragment.texcoord[2].z;
MOV R1.z, fragment.texcoord[3];
MOV R0.x, fragment.texcoord[1].w;
MOV R0.z, fragment.texcoord[3].w;
MOV R0.y, fragment.texcoord[2].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[7].z, R0;
POW R3.y, R1.w, c[3].x;
MUL R2.w, R2, fragment.texcoord[0].z;
MOV result.color.w, c[7].x;
TEX R1.xyz, R0, texture[0], CUBE;
TEX R0, fragment.texcoord[4], texture[2], 2D;
MUL R2.xyz, R1, c[6];
MUL R1.xyz, R1, c[5];
MUL R1.xyz, R1, R3.y;
POW R3.y, R2.w, c[4].x;
MAD R2.xyz, R2, R3.y, R1;
MUL R1.xyz, R0, R3.x;
MUL R0.xyz, R0.w, R0;
MUL R0.xyz, R0, c[7].y;
MUL R1.xyz, R1, c[7].z;
MIN R1.xyz, R0, R1;
MUL R0.xyz, R0, R3.x;
POW R0.w, R1.w, c[1].x;
MAX R1.xyz, R1, R0;
MUL R0.xyz, R0.w, c[2];
POW R0.w, R2.w, c[1].x;
MAD R0.xyz, R0.w, c[0], R0;
MAD result.color.xyz, R0, R1, R2;
END
# 35 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_ShadowMapTexture] 2D
SetTexture 2 [unity_Lightmap] 2D
"ps_2_0
; 45 ALU, 3 TEX
dcl_cube s0
dcl_2d s1
dcl_2d s2
def c7, 1.00000000, 8.00000000, 2.00000000, 0
dcl t0.xyz
dcl t1.xyzw
dcl t2.xyzw
dcl t3.xyzw
dcl t4.xy
dcl t5
texldp r6, t5, s1
mov_pp r2.x, t1.z
mov_pp r2.y, t2.z
mov_pp r2.z, t3
mov r1.x, t1.w
mov r1.z, t3.w
mov r1.y, t2.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c7.z, r1
mov_pp r0.w, c7.x
texld r4, r0, s0
texld r2, t4, s2
dp3 r0.x, t0, t0
rsq r1.x, r0.x
mad r0.x, -r1, t0.z, c7
pow r3.x, r0.x, c3.x
mul r5.xyz, r4, c5
mul r0.z, r1.x, t0
mov r1.x, r3.x
pow r3.w, r0.z, c4.x
mul r5.xyz, r5, r1.x
mov r1.x, r3.w
mul r4.xyz, r4, c6
mad r3.xyz, r4, r1.x, r5
mul_pp r1.xyz, r2, r6.x
mul_pp r2.xyz, r2.w, r2
mul_pp r2.xyz, r2, c7.y
mul_pp r1.xyz, r1, c7.z
min_pp r1.xyz, r2, r1
mul_pp r4.xyz, r2, r6.x
pow r2.w, r0.x, c1.x
max_pp r4.xyz, r1, r4
mov r0.x, r2.w
pow r1.x, r0.z, c1.x
mul r2.xyz, r0.x, c2
mov r0.x, r1.x
mad r0.xyz, r0.x, c0, r2
mad_pp r0.xyz, r0, r4, r3
mov_pp oC0, r0
"
}
}
 }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardAdd" "QUEUE"="Geometry" "IGNOREPROJECTOR"="False" "RenderType"="Opaque" }
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend One One
Program "vp" {
SubProgram "opengl " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [unity_Scale]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_WorldSpaceLightPos0]
"!!ARBvp1.0
# 32 ALU
PARAM c[20] = { { 1 },
		state.matrix.mvp,
		program.local[5..19] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R2;
MOV R1, c[19];
MOV R0.w, c[0].x;
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R2.xyz, R2, c[17].w, -vertex.position;
MUL R1.xyz, R0, vertex.attrib[14].w;
MOV R0.xyz, c[18];
DP4 R3.z, R0, c[11];
DP4 R3.x, R0, c[9];
DP4 R3.y, R0, c[10];
MAD R0.xyz, R3, c[17].w, -vertex.position;
DP3 result.texcoord[0].y, R0, R1;
DP3 result.texcoord[0].z, vertex.normal, R0;
DP3 result.texcoord[0].x, R0, vertex.attrib[14];
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[1].y, R1, R2;
DP3 result.texcoord[1].z, vertex.normal, R2;
DP3 result.texcoord[1].x, vertex.attrib[14], R2;
DP4 result.texcoord[2].z, R0, c[15];
DP4 result.texcoord[2].y, R0, c[14];
DP4 result.texcoord[2].x, R0, c[13];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 32 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [unity_Scale]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_WorldSpaceLightPos0]
"vs_2_0
; 35 ALU
def c19, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mov r1.xyz, v1
mov r0, c10
dp4 r3.z, c18, r0
mov r0, c9
dp4 r3.y, c18, r0
mul r2.xyz, v2.zxyw, r1.yzxw
mov r1.xyz, v1
mad r2.xyz, v2.yzxw, r1.zxyw, -r2
mov r1, c8
dp4 r3.x, c18, r1
mad r0.xyz, r3, c16.w, -v0
mul r2.xyz, r2, v1.w
mov r1.xyz, c17
mov r1.w, c19.x
dp3 oT1.y, r2, r0
dp3 oT1.z, v2, r0
dp3 oT1.x, v1, r0
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r3.z, r1, c10
dp4 r3.x, r1, c8
dp4 r3.y, r1, c9
mad r1.xyz, r3, c16.w, -v0
dp3 oT0.y, r1, r2
dp3 oT0.z, v2, r1
dp3 oT0.x, r1, v1
dp4 oT2.z, r0, c14
dp4 oT2.y, r0, c13
dp4 oT2.x, r0, c12
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_World2Object]
Vector 9 [unity_Scale]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [_WorldSpaceLightPos0]
"!!ARBvp1.0
# 24 ALU
PARAM c[12] = { { 1 },
		state.matrix.mvp,
		program.local[5..11] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R0.xyz, c[10];
MOV R0.w, c[0].x;
DP4 R2.z, R0, c[7];
DP4 R2.x, R0, c[5];
DP4 R2.y, R0, c[6];
MAD R0.xyz, R2, c[9].w, -vertex.position;
MUL R2.xyz, R1, vertex.attrib[14].w;
MOV R1, c[11];
DP4 R3.z, R1, c[7];
DP4 R3.x, R1, c[5];
DP4 R3.y, R1, c[6];
DP3 result.texcoord[0].y, R0, R2;
DP3 result.texcoord[1].y, R2, R3;
DP3 result.texcoord[0].z, vertex.normal, R0;
DP3 result.texcoord[0].x, R0, vertex.attrib[14];
DP3 result.texcoord[1].z, vertex.normal, R3;
DP3 result.texcoord[1].x, vertex.attrib[14], R3;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 24 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_World2Object]
Vector 8 [unity_Scale]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_WorldSpaceLightPos0]
"vs_2_0
; 27 ALU
def c11, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r3.xyz, r0, v1.w
mov r0, c6
dp4 r4.z, c10, r0
mov r0, c5
mov r1.w, c11.x
mov r1.xyz, c9
dp4 r4.y, c10, r0
dp4 r2.z, r1, c6
dp4 r2.x, r1, c4
dp4 r2.y, r1, c5
mad r2.xyz, r2, c8.w, -v0
mov r1, c4
dp4 r4.x, c10, r1
dp3 oT0.y, r2, r3
dp3 oT1.y, r3, r4
dp3 oT0.z, v2, r2
dp3 oT0.x, r2, v1
dp3 oT1.z, v2, r4
dp3 oT1.x, v1, r4
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [unity_Scale]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_WorldSpaceLightPos0]
"!!ARBvp1.0
# 33 ALU
PARAM c[20] = { { 1 },
		state.matrix.mvp,
		program.local[5..19] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R2;
MOV R1, c[19];
MOV R0.w, c[0].x;
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R2.xyz, R2, c[17].w, -vertex.position;
MUL R1.xyz, R0, vertex.attrib[14].w;
MOV R0.xyz, c[18];
DP4 R3.z, R0, c[11];
DP4 R3.x, R0, c[9];
DP4 R3.y, R0, c[10];
MAD R0.xyz, R3, c[17].w, -vertex.position;
DP4 R0.w, vertex.position, c[8];
DP3 result.texcoord[0].y, R0, R1;
DP3 result.texcoord[0].z, vertex.normal, R0;
DP3 result.texcoord[0].x, R0, vertex.attrib[14];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[1].y, R1, R2;
DP3 result.texcoord[1].z, vertex.normal, R2;
DP3 result.texcoord[1].x, vertex.attrib[14], R2;
DP4 result.texcoord[2].w, R0, c[16];
DP4 result.texcoord[2].z, R0, c[15];
DP4 result.texcoord[2].y, R0, c[14];
DP4 result.texcoord[2].x, R0, c[13];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 33 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [unity_Scale]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_WorldSpaceLightPos0]
"vs_2_0
; 36 ALU
def c19, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mov r1.xyz, v1
mov r0, c10
dp4 r3.z, c18, r0
mov r0, c9
dp4 r3.y, c18, r0
mul r2.xyz, v2.zxyw, r1.yzxw
mov r1.xyz, v1
mad r2.xyz, v2.yzxw, r1.zxyw, -r2
mov r1, c8
dp4 r3.x, c18, r1
mad r0.xyz, r3, c16.w, -v0
mul r2.xyz, r2, v1.w
mov r1.xyz, c17
mov r1.w, c19.x
dp4 r0.w, v0, c7
dp3 oT1.y, r2, r0
dp3 oT1.z, v2, r0
dp3 oT1.x, v1, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r3.z, r1, c10
dp4 r3.x, r1, c8
dp4 r3.y, r1, c9
mad r1.xyz, r3, c16.w, -v0
dp3 oT0.y, r1, r2
dp3 oT0.z, v2, r1
dp3 oT0.x, r1, v1
dp4 oT2.w, r0, c15
dp4 oT2.z, r0, c14
dp4 oT2.y, r0, c13
dp4 oT2.x, r0, c12
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [unity_Scale]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_WorldSpaceLightPos0]
"!!ARBvp1.0
# 32 ALU
PARAM c[20] = { { 1 },
		state.matrix.mvp,
		program.local[5..19] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R2;
MOV R1, c[19];
MOV R0.w, c[0].x;
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R2.xyz, R2, c[17].w, -vertex.position;
MUL R1.xyz, R0, vertex.attrib[14].w;
MOV R0.xyz, c[18];
DP4 R3.z, R0, c[11];
DP4 R3.x, R0, c[9];
DP4 R3.y, R0, c[10];
MAD R0.xyz, R3, c[17].w, -vertex.position;
DP3 result.texcoord[0].y, R0, R1;
DP3 result.texcoord[0].z, vertex.normal, R0;
DP3 result.texcoord[0].x, R0, vertex.attrib[14];
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[1].y, R1, R2;
DP3 result.texcoord[1].z, vertex.normal, R2;
DP3 result.texcoord[1].x, vertex.attrib[14], R2;
DP4 result.texcoord[2].z, R0, c[15];
DP4 result.texcoord[2].y, R0, c[14];
DP4 result.texcoord[2].x, R0, c[13];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 32 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [unity_Scale]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_WorldSpaceLightPos0]
"vs_2_0
; 35 ALU
def c19, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mov r1.xyz, v1
mov r0, c10
dp4 r3.z, c18, r0
mov r0, c9
dp4 r3.y, c18, r0
mul r2.xyz, v2.zxyw, r1.yzxw
mov r1.xyz, v1
mad r2.xyz, v2.yzxw, r1.zxyw, -r2
mov r1, c8
dp4 r3.x, c18, r1
mad r0.xyz, r3, c16.w, -v0
mul r2.xyz, r2, v1.w
mov r1.xyz, c17
mov r1.w, c19.x
dp3 oT1.y, r2, r0
dp3 oT1.z, v2, r0
dp3 oT1.x, v1, r0
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r3.z, r1, c10
dp4 r3.x, r1, c8
dp4 r3.y, r1, c9
mad r1.xyz, r3, c16.w, -v0
dp3 oT0.y, r1, r2
dp3 oT0.z, v2, r1
dp3 oT0.x, r1, v1
dp4 oT2.z, r0, c14
dp4 oT2.y, r0, c13
dp4 oT2.x, r0, c12
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [unity_Scale]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_WorldSpaceLightPos0]
"!!ARBvp1.0
# 30 ALU
PARAM c[20] = { { 1 },
		state.matrix.mvp,
		program.local[5..19] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R0.w, c[0].x;
MOV R0.xyz, c[18];
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R0.xyz, R2, c[17].w, -vertex.position;
MUL R2.xyz, R1, vertex.attrib[14].w;
MOV R1, c[19];
DP3 result.texcoord[0].y, R0, R2;
DP4 R3.z, R1, c[11];
DP4 R3.x, R1, c[9];
DP4 R3.y, R1, c[10];
DP3 result.texcoord[0].z, vertex.normal, R0;
DP3 result.texcoord[0].x, R0, vertex.attrib[14];
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[1].y, R2, R3;
DP3 result.texcoord[1].z, vertex.normal, R3;
DP3 result.texcoord[1].x, vertex.attrib[14], R3;
DP4 result.texcoord[2].y, R0, c[14];
DP4 result.texcoord[2].x, R0, c[13];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 30 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [unity_Scale]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_WorldSpaceLightPos0]
"vs_2_0
; 33 ALU
def c19, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r3.xyz, r0, v1.w
mov r0, c10
dp4 r4.z, c18, r0
mov r0, c9
dp4 r4.y, c18, r0
mov r1.w, c19.x
mov r1.xyz, c17
dp4 r2.z, r1, c10
dp4 r2.x, r1, c8
dp4 r2.y, r1, c9
mad r2.xyz, r2, c16.w, -v0
mov r1, c8
dp4 r4.x, c18, r1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 oT0.y, r2, r3
dp3 oT1.y, r3, r4
dp3 oT0.z, v2, r2
dp3 oT0.x, r2, v1
dp3 oT1.z, v2, r4
dp3 oT1.x, v1, r4
dp4 oT2.y, r0, c13
dp4 oT2.x, r0, c12
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Vector 4 [_Specular]
Float 5 [_Gloss]
SetTexture 0 [_LightTexture0] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 34 ALU, 1 TEX
PARAM c[8] = { program.local[0..5],
		{ 0, 1, 128, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
DP3 R0.x, fragment.texcoord[2], fragment.texcoord[2];
DP3 R1.x, fragment.texcoord[0], fragment.texcoord[0];
RSQ R1.x, R1.x;
MOV result.color.w, c[6].x;
TEX R0.w, R0.x, texture[0], 2D;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
MAD R1.xyz, fragment.texcoord[0], R1.x, R0;
DP3 R0.x, R1, R1;
RSQ R0.y, R0.x;
MOV R0.x, c[6].z;
MUL R0.y, R0, R1.z;
MUL R1.x, R0, c[5];
MAX R0.x, R0.y, c[6];
POW R0.x, R0.x, R1.x;
MOV R1.xyz, c[7];
DP3 R0.y, R1, c[0];
MUL R1.w, R0.x, R0.y;
MAX R0.z, R0, c[6].x;
MUL R1.xyz, R0.z, c[0];
MUL R1, R0.w, R1;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
MUL R1, R1, c[6].w;
RSQ R0.w, R0.x;
MUL R0.xyz, R1.w, c[4];
MAD R1.w, -R0, fragment.texcoord[0].z, c[6].y;
MUL R2.xyz, R1, R0;
POW R0.x, R1.w, c[2].x;
MUL R0.w, R0, fragment.texcoord[0].z;
MUL R0.xyz, R0.x, c[3];
POW R0.w, R0.w, c[2].x;
MAD R0.xyz, R0.w, c[1], R0;
MAD result.color.xyz, R0, R1, R2;
END
# 34 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Vector 4 [_Specular]
Float 5 [_Gloss]
SetTexture 0 [_LightTexture0] 2D
"ps_2_0
; 44 ALU, 1 TEX
dcl_2d s0
def c6, 1.00000000, 0.00000000, 128.00000000, 2.00000000
def c7, 0.21997070, 0.70703125, 0.07098389, 0
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dp3 r0.x, t2, t2
mov r0.xy, r0.x
mov_pp r4.xyz, c0
texld r3, r0, s0
dp3_pp r0.x, t1, t1
rsq_pp r1.x, r0.x
dp3_pp r0.x, t0, t0
mul_pp r1.xyz, r1.x, t1
rsq_pp r0.x, r0.x
mad_pp r0.xyz, t0, r0.x, r1
dp3_pp r0.x, r0, r0
rsq_pp r1.x, r0.x
mul_pp r0.z, r1.x, r0
mov_pp r0.x, c5
max_pp r1.x, r0.z, c6.y
mul_pp r0.x, c6.z, r0
pow r2.x, r1.x, r0.x
mov r0.x, r2.x
dp3_pp r1.x, c7, r4
mul r0.w, r0.x, r1.x
max_pp r2.x, r1.z, c6.y
mul_pp r0.xyz, r2.x, c0
mul_pp r1, r3.x, r0
mul_pp r2, r1, c6.w
mul_pp r3.xyz, r2.w, c4
dp3 r0.x, t0, t0
rsq r0.x, r0.x
mad r1.x, -r0, t0.z, c6
mul_pp r4.xyz, r2, r3
pow r3.w, r1.x, c2.x
mul r0.z, r0.x, t0
mov r0.x, r3.w
pow r1.x, r0.z, c2.x
mul r3.xyz, r0.x, c3
mov r0.x, r1.x
mad r0.xyz, r0.x, c1, r3
mad_pp r0.xyz, r0, r2, r4
mov_pp r0.w, c6.y
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Vector 4 [_Specular]
Float 5 [_Gloss]
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 29 ALU, 0 TEX
PARAM c[8] = { program.local[0..5],
		{ 0, 1, 128, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
MOV R1.xyz, fragment.texcoord[1];
RSQ R0.x, R0.x;
MAD R0.xyz, fragment.texcoord[0], R0.x, R1;
DP3 R0.x, R0, R0;
RSQ R0.x, R0.x;
MUL R0.y, R0.x, R0.z;
MOV R0.x, c[6].z;
MUL R1.x, R0, c[5];
MAX R0.w, R0.y, c[6].x;
MOV R0.xyz, c[7];
DP3 R0.x, R0, c[0];
POW R0.w, R0.w, R1.x;
MUL R0.w, R0, R0.x;
MAX R0.y, fragment.texcoord[1].z, c[6].x;
MUL R0.xyz, R0.y, c[0];
MUL R1, R0, c[6].w;
DP3 R2.x, fragment.texcoord[0], fragment.texcoord[0];
MUL R0.xyz, R1.w, c[4];
RSQ R0.w, R2.x;
MAD R1.w, -R0, fragment.texcoord[0].z, c[6].y;
MUL R2.xyz, R1, R0;
POW R0.x, R1.w, c[2].x;
MUL R0.w, R0, fragment.texcoord[0].z;
MUL R0.xyz, R0.x, c[3];
POW R0.w, R0.w, c[2].x;
MAD R0.xyz, R0.w, c[1], R0;
MAD result.color.xyz, R0, R1, R2;
MOV result.color.w, c[6].x;
END
# 29 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Vector 4 [_Specular]
Float 5 [_Gloss]
"ps_2_0
; 39 ALU
def c6, 1.00000000, 0.00000000, 128.00000000, 2.00000000
def c7, 0.21997070, 0.70703125, 0.07098389, 0
dcl t0.xyz
dcl t1.xyz
dp3_pp r0.x, t0, t0
mov_pp r1.xyz, t1
rsq_pp r0.x, r0.x
mad_pp r0.xyz, t0, r0.x, r1
dp3_pp r0.x, r0, r0
rsq_pp r1.x, r0.x
mul_pp r0.z, r1.x, r0
mov_pp r0.x, c5
max_pp r1.x, r0.z, c6.y
mul_pp r0.x, c6.z, r0
pow r2.x, r1.x, r0.x
mov_pp r1.xyz, c0
mov r0.x, r2.x
dp3_pp r2.x, c7, r1
mul r1.w, r0.x, r2.x
max_pp r1.x, t1.z, c6.y
mul_pp r1.xyz, r1.x, c0
mul_pp r2, r1, c6.w
mul_pp r3.xyz, r2.w, c4
dp3 r0.x, t0, t0
rsq r0.x, r0.x
mad r1.x, -r0, t0.z, c6
mul_pp r4.xyz, r2, r3
pow r3.w, r1.x, c2.x
mul r0.z, r0.x, t0
mov r0.x, r3.w
pow r1.x, r0.z, c2.x
mul r3.xyz, r0.x, c3
mov r0.x, r1.x
mad r0.xyz, r0.x, c1, r3
mad_pp r0.xyz, r0, r2, r4
mov_pp r0.w, c6.y
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Vector 4 [_Specular]
Float 5 [_Gloss]
SetTexture 0 [_LightTexture0] 2D
SetTexture 1 [_LightTextureB0] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 40 ALU, 2 TEX
PARAM c[8] = { program.local[0..5],
		{ 0, 1, 0.5, 128 },
		{ 0.2199707, 0.70703125, 0.070983887, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
DP3 R0.z, fragment.texcoord[2], fragment.texcoord[2];
RCP R0.x, fragment.texcoord[2].w;
MAD R0.xy, fragment.texcoord[2], R0.x, c[6].z;
DP3 R1.x, fragment.texcoord[0], fragment.texcoord[0];
RSQ R1.x, R1.x;
MOV result.color.w, c[6].x;
TEX R0.w, R0, texture[0], 2D;
TEX R1.w, R0.z, texture[1], 2D;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
MAD R1.xyz, fragment.texcoord[0], R1.x, R0;
DP3 R0.x, R1, R1;
RSQ R0.x, R0.x;
MUL R0.y, R0.x, R1.z;
MAX R0.z, R0, c[6].x;
MOV R0.x, c[6].w;
MUL R2.xyz, R0.z, c[0];
MAX R0.y, R0, c[6].x;
MUL R0.x, R0, c[5];
POW R0.x, R0.y, R0.x;
MOV R1.xyz, c[7];
DP3 R0.y, R1, c[0];
MUL R2.w, R0.x, R0.y;
SLT R0.x, c[6], fragment.texcoord[2].z;
MUL R0.x, R0, R0.w;
MUL R0.x, R0, R1.w;
MUL R1, R0.x, R2;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
MUL R1, R1, c[7].w;
RSQ R0.w, R0.x;
MUL R0.xyz, R1.w, c[4];
MAD R1.w, -R0, fragment.texcoord[0].z, c[6].y;
MUL R2.xyz, R1, R0;
POW R0.x, R1.w, c[2].x;
MUL R0.w, R0, fragment.texcoord[0].z;
MUL R0.xyz, R0.x, c[3];
POW R0.w, R0.w, c[2].x;
MAD R0.xyz, R0.w, c[1], R0;
MAD result.color.xyz, R0, R1, R2;
END
# 40 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Vector 4 [_Specular]
Float 5 [_Gloss]
SetTexture 0 [_LightTexture0] 2D
SetTexture 1 [_LightTextureB0] 2D
"ps_2_0
; 49 ALU, 2 TEX
dcl_2d s0
dcl_2d s1
def c6, 1.00000000, 0.00000000, 0.50000000, 128.00000000
def c7, 0.21997070, 0.70703125, 0.07098389, 2.00000000
dcl t0.xyz
dcl t1.xyz
dcl t2
rcp r1.x, t2.w
mad r2.xy, t2, r1.x, c6.z
dp3 r0.x, t2, t2
mov r1.xy, r0.x
texld r3, r1, s1
texld r0, r2, s0
dp3_pp r0.x, t1, t1
rsq_pp r1.x, r0.x
dp3_pp r0.x, t0, t0
mul_pp r1.xyz, r1.x, t1
rsq_pp r0.x, r0.x
mad_pp r0.xyz, t0, r0.x, r1
dp3_pp r0.x, r0, r0
rsq_pp r1.x, r0.x
mul_pp r0.z, r1.x, r0
mov_pp r0.x, c5
mul_pp r0.x, c6.w, r0
max_pp r1.x, r0.z, c6.y
pow r2.w, r1.x, r0.x
mov r1.x, r2.w
mov_pp r2.xyz, c0
cmp r0.x, -t2.z, c6.y, c6
mul_pp r0.x, r0, r0.w
mul_pp r0.x, r0, r3
max_pp r3.x, r1.z, c6.y
dp3_pp r2.x, c7, r2
mul r3.w, r1.x, r2.x
mul_pp r3.xyz, r3.x, c0
mul_pp r1, r0.x, r3
mul_pp r2, r1, c7.w
mul_pp r3.xyz, r2.w, c4
dp3 r0.x, t0, t0
rsq r0.x, r0.x
mad r1.x, -r0, t0.z, c6
mul_pp r4.xyz, r2, r3
pow r3.w, r1.x, c2.x
mul r0.z, r0.x, t0
mov r0.x, r3.w
pow r1.x, r0.z, c2.x
mul r3.xyz, r0.x, c3
mov r0.x, r1.x
mad r0.xyz, r0.x, c1, r3
mad_pp r0.xyz, r0, r2, r4
mov_pp r0.w, c6.y
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Vector 4 [_Specular]
Float 5 [_Gloss]
SetTexture 0 [_LightTextureB0] 2D
SetTexture 1 [_LightTexture0] CUBE
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 36 ALU, 2 TEX
PARAM c[8] = { program.local[0..5],
		{ 0, 1, 128, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R1.w, fragment.texcoord[2], texture[1], CUBE;
DP3 R0.x, fragment.texcoord[2], fragment.texcoord[2];
DP3 R1.x, fragment.texcoord[0], fragment.texcoord[0];
RSQ R1.x, R1.x;
MOV result.color.w, c[6].x;
TEX R0.w, R0.x, texture[0], 2D;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
MAD R1.xyz, fragment.texcoord[0], R1.x, R0;
DP3 R0.x, R1, R1;
RSQ R0.x, R0.x;
MUL R0.y, R0.x, R1.z;
MAX R0.z, R0, c[6].x;
MOV R0.x, c[6].z;
MUL R2.xyz, R0.z, c[0];
MAX R0.y, R0, c[6].x;
MUL R0.x, R0, c[5];
POW R0.x, R0.y, R0.x;
MOV R1.xyz, c[7];
DP3 R0.y, R1, c[0];
MUL R2.w, R0.x, R0.y;
MUL R0.x, R0.w, R1.w;
MUL R1, R0.x, R2;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
MUL R1, R1, c[6].w;
RSQ R0.w, R0.x;
MUL R0.xyz, R1.w, c[4];
MAD R1.w, -R0, fragment.texcoord[0].z, c[6].y;
MUL R2.xyz, R1, R0;
POW R0.x, R1.w, c[2].x;
MUL R0.w, R0, fragment.texcoord[0].z;
MUL R0.xyz, R0.x, c[3];
POW R0.w, R0.w, c[2].x;
MAD R0.xyz, R0.w, c[1], R0;
MAD result.color.xyz, R0, R1, R2;
END
# 36 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Vector 4 [_Specular]
Float 5 [_Gloss]
SetTexture 0 [_LightTextureB0] 2D
SetTexture 1 [_LightTexture0] CUBE
"ps_2_0
; 45 ALU, 2 TEX
dcl_2d s0
dcl_cube s1
def c6, 1.00000000, 0.00000000, 128.00000000, 2.00000000
def c7, 0.21997070, 0.70703125, 0.07098389, 0
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
dp3 r0.x, t2, t2
mov r0.xy, r0.x
texld r3, r0, s0
texld r0, t2, s1
dp3_pp r0.x, t1, t1
rsq_pp r1.x, r0.x
dp3_pp r0.x, t0, t0
mul_pp r1.xyz, r1.x, t1
rsq_pp r0.x, r0.x
mad_pp r0.xyz, t0, r0.x, r1
dp3_pp r0.x, r0, r0
rsq_pp r1.x, r0.x
mul_pp r0.z, r1.x, r0
mov_pp r0.x, c5
mul_pp r0.x, c6.z, r0
max_pp r1.x, r0.z, c6.y
pow r2.w, r1.x, r0.x
mov r1.x, r2.w
mov_pp r2.xyz, c0
mul r0.x, r3, r0.w
max_pp r3.x, r1.z, c6.y
dp3_pp r2.x, c7, r2
mul r3.w, r1.x, r2.x
mul_pp r3.xyz, r3.x, c0
mul_pp r1, r0.x, r3
mul_pp r2, r1, c6.w
mul_pp r3.xyz, r2.w, c4
dp3 r0.x, t0, t0
rsq r0.x, r0.x
mad r1.x, -r0, t0.z, c6
mul_pp r4.xyz, r2, r3
pow r3.w, r1.x, c2.x
mul r0.z, r0.x, t0
mov r0.x, r3.w
pow r1.x, r0.z, c2.x
mul r3.xyz, r0.x, c3
mov r0.x, r1.x
mad r0.xyz, r0.x, c1, r3
mad_pp r0.xyz, r0, r2, r4
mov_pp r0.w, c6.y
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Vector 4 [_Specular]
Float 5 [_Gloss]
SetTexture 0 [_LightTexture0] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 31 ALU, 1 TEX
PARAM c[8] = { program.local[0..5],
		{ 0, 1, 128, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.w, fragment.texcoord[2], texture[0], 2D;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
MOV R1.xyz, fragment.texcoord[1];
RSQ R0.x, R0.x;
MAD R0.xyz, fragment.texcoord[0], R0.x, R1;
DP3 R0.x, R0, R0;
RSQ R0.y, R0.x;
MAX R1.x, fragment.texcoord[1].z, c[6];
MUL R0.y, R0, R0.z;
MOV R0.x, c[6].z;
MUL R0.z, R0.x, c[5].x;
MAX R0.x, R0.y, c[6];
POW R1.w, R0.x, R0.z;
MOV R0.xyz, c[7];
DP3 R0.x, R0, c[0];
MUL R1.w, R1, R0.x;
MUL R1.xyz, R1.x, c[0];
MUL R1, R0.w, R1;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
MUL R1, R1, c[6].w;
RSQ R0.w, R0.x;
MUL R0.xyz, R1.w, c[4];
MAD R1.w, -R0, fragment.texcoord[0].z, c[6].y;
MUL R2.xyz, R1, R0;
POW R0.x, R1.w, c[2].x;
MUL R0.w, R0, fragment.texcoord[0].z;
MUL R0.xyz, R0.x, c[3];
POW R0.w, R0.w, c[2].x;
MAD R0.xyz, R0.w, c[1], R0;
MAD result.color.xyz, R0, R1, R2;
MOV result.color.w, c[6].x;
END
# 31 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
Float 2 [_SecondaryFresnel]
Vector 3 [_SecondaryColor]
Vector 4 [_Specular]
Float 5 [_Gloss]
SetTexture 0 [_LightTexture0] 2D
"ps_2_0
; 40 ALU, 1 TEX
dcl_2d s0
def c6, 1.00000000, 0.00000000, 128.00000000, 2.00000000
def c7, 0.21997070, 0.70703125, 0.07098389, 0
dcl t0.xyz
dcl t1.xyz
dcl t2.xy
texld r0, t2, s0
dp3_pp r0.x, t0, t0
mov_pp r1.xyz, t1
rsq_pp r0.x, r0.x
mad_pp r0.xyz, t0, r0.x, r1
dp3_pp r0.x, r0, r0
rsq_pp r1.x, r0.x
mul_pp r0.z, r1.x, r0
mov_pp r0.x, c5
max_pp r1.x, r0.z, c6.y
mul_pp r0.x, c6.z, r0
pow r2.x, r1.x, r0.x
mov r0.x, r2.x
mov_pp r1.xyz, c0
dp3_pp r2.x, c7, r1
max_pp r1.x, t1.z, c6.y
mul r1.w, r0.x, r2.x
mul_pp r1.xyz, r1.x, c0
mul_pp r1, r0.w, r1
mul_pp r2, r1, c6.w
mul_pp r3.xyz, r2.w, c4
dp3 r0.x, t0, t0
rsq r0.x, r0.x
mad r1.x, -r0, t0.z, c6
mul_pp r4.xyz, r2, r3
pow r3.w, r1.x, c2.x
mul r0.z, r0.x, t0
mov r0.x, r3.w
pow r1.x, r0.z, c2.x
mul r3.xyz, r0.x, c3
mov r0.x, r1.x
mad r0.xyz, r0.x, c1, r3
mad_pp r0.xyz, r0, r2, r4
mov_pp r0.w, c6.y
mov_pp oC0, r0
"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassBase" "QUEUE"="Geometry" "IGNOREPROJECTOR"="False" "RenderType"="Opaque" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Vector 9 [unity_Scale]
"!!ARBvp1.0
# 20 ALU
PARAM c[10] = { program.local[0],
		state.matrix.mvp,
		program.local[5..9] };
TEMP R0;
TEMP R1;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, R0, vertex.attrib[14].w;
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[0].xyz, R0, c[9].w;
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[1].xyz, R0, c[9].w;
DP3 R0.y, R1, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[2].xyz, R0, c[9].w;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 20 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [unity_Scale]
"vs_2_0
; 21 ALU
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, r0, v1.w
dp3 r0.y, r1, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT0.xyz, r0, c8.w
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT1.xyz, r0, c8.w
dp3 r0.y, r1, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT2.xyz, r0, c8.w
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_Gloss]
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 5 ALU, 0 TEX
PARAM c[2] = { program.local[0],
		{ 0.5 } };
TEMP R0;
MOV R0.z, fragment.texcoord[2];
MOV R0.x, fragment.texcoord[0].z;
MOV R0.y, fragment.texcoord[1].z;
MAD result.color.xyz, R0, c[1].x, c[1].x;
MOV result.color.w, c[0].x;
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_Gloss]
"ps_2_0
; 6 ALU
def c1, 0.50000000, 0, 0, 0
dcl t0.xyz
dcl t1.xyz
dcl t2.xyz
mov_pp r0.z, t2
mov_pp r0.x, t0.z
mov_pp r0.y, t1.z
mad_pp r0.xyz, r0, c1.x, c1.x
mov_pp r0.w, c0.x
mov_pp oC0, r0
"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassFinal" "QUEUE"="Geometry" "IGNOREPROJECTOR"="False" "RenderType"="Opaque" }
  ZWrite Off
Program "vp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
Vector 14 [unity_Scale]
Vector 15 [_WorldSpaceCameraPos]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
"!!ARBvp1.0
# 56 ALU
PARAM c[23] = { { 1, 0.5 },
		state.matrix.mvp,
		program.local[5..22] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[14].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MUL R1, R0.xyzz, R0.yzzx;
MOV R0.w, c[0].x;
DP4 R2.z, R0, c[18];
DP4 R2.y, R0, c[17];
DP4 R2.x, R0, c[16];
MUL R0.y, R2.w, R2.w;
DP4 R3.z, R1, c[21];
DP4 R3.x, R1, c[19];
DP4 R3.y, R1, c[20];
MOV R1.xyz, vertex.attrib[14];
MAD R0.w, R0.x, R0.x, -R0.y;
ADD R2.xyz, R2, R3;
MUL R3.xyz, R0.w, c[22];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
ADD result.texcoord[5].xyz, R2, R3;
MUL R2.xyz, R0, vertex.attrib[14].w;
MOV R0.xyz, c[15];
MOV R0.w, c[0].x;
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
MAD R1.xyz, R1, c[14].w, -vertex.position;
DP3 R0.w, -R1, c[5];
DP3 result.texcoord[0].y, R1, R2;
DP3 R0.y, R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[14].w;
DP3 R0.w, -R1, c[6];
DP3 R0.y, R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[14].w;
DP3 R0.w, -R1, c[7];
DP3 R0.y, R2, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[14].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP3 result.texcoord[0].z, vertex.normal, R1;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].y;
DP3 result.texcoord[0].x, R1, vertex.attrib[14];
MOV R1.x, R2;
MUL R1.y, R2, c[13].x;
ADD result.texcoord[1].xy, R1, R2.z;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
END
# 56 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_Scale]
Vector 15 [_WorldSpaceCameraPos]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
"vs_2_0
; 57 ALU
def c23, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mul r1.xyz, v2, c14.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c23.x
dp4 r2.z, r0, c18
dp4 r2.y, r0, c17
dp4 r2.x, r0, c16
mul r0.y, r2.w, r2.w
mad r0.w, r0.x, r0.x, -r0.y
dp4 r3.z, r1, c21
dp4 r3.y, r1, c20
dp4 r3.x, r1, c19
add r2.xyz, r2, r3
mul r3.xyz, r0.w, c22
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
add oT5.xyz, r2, r3
mul r2.xyz, r0, v1.w
mov r0.xyz, c15
mov r0.w, c23.x
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
mad r1.xyz, r1, c14.w, -v0
dp3 r0.w, -r1, c4
dp3 oT0.y, r1, r2
dp3 r0.y, r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT2, r0, c14.w
dp3 r0.w, -r1, c5
dp3 r0.y, r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT3, r0, c14.w
dp3 r0.w, -r1, c6
dp3 r0.y, r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT4, r0, c14.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp3 oT0.z, v2, r1
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c23.y
dp3 oT0.x, r1, v1
mov r1.x, r2
mul r1.y, r2, c12.x
mad oT1.xy, r2.z, c13.zwzw, r1
mov oPos, r0
mov oT1.zw, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_Scale]
Vector 19 [_WorldSpaceCameraPos]
Vector 20 [unity_LightmapST]
Vector 21 [unity_ShadowFadeCenterAndType]
"!!ARBvp1.0
# 48 ALU
PARAM c[22] = { { 1, 0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..21] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, R0, vertex.attrib[14].w;
MOV R0.xyz, c[19];
MOV R0.w, c[0].x;
DP4 R1.z, R0, c[15];
DP4 R1.x, R0, c[13];
DP4 R1.y, R0, c[14];
MAD R1.xyz, R1, c[18].w, -vertex.position;
DP3 R0.w, -R1, c[9];
DP3 result.texcoord[0].y, R1, R2;
DP3 R0.y, R2, c[9];
DP3 result.texcoord[0].z, vertex.normal, R1;
DP3 result.texcoord[0].x, R1, vertex.attrib[14];
DP3 R0.x, vertex.attrib[14], c[9];
DP3 R0.z, vertex.normal, c[9];
MUL result.texcoord[2], R0, c[18].w;
DP3 R0.w, -R1, c[10];
DP3 R0.y, R2, c[10];
DP3 R0.x, vertex.attrib[14], c[10];
DP3 R0.z, vertex.normal, c[10];
MUL result.texcoord[3], R0, c[18].w;
DP3 R0.w, -R1, c[11];
DP3 R0.y, R2, c[11];
DP3 R0.x, vertex.attrib[14], c[11];
DP3 R0.z, vertex.normal, c[11];
MUL result.texcoord[4], R0, c[18].w;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].y;
MOV result.position, R0;
MOV R0.x, c[0];
ADD R0.y, R0.x, -c[21].w;
DP4 R0.x, vertex.position, c[3];
MOV R1.x, R2;
MUL R1.y, R2, c[17].x;
ADD result.texcoord[1].xy, R1, R2.z;
DP4 R1.z, vertex.position, c[11];
DP4 R1.x, vertex.position, c[9];
DP4 R1.y, vertex.position, c[10];
ADD R1.xyz, R1, -c[21];
MOV result.texcoord[1].zw, R0;
MUL result.texcoord[6].xyz, R1, c[21].w;
MAD result.texcoord[5].xy, vertex.texcoord[1], c[20], c[20].zwzw;
MUL result.texcoord[6].w, -R0.x, R0.y;
END
# 48 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_Scale]
Vector 19 [_WorldSpaceCameraPos]
Vector 20 [unity_LightmapST]
Vector 21 [unity_ShadowFadeCenterAndType]
"vs_2_0
; 49 ALU
def c22, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord1 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r0, v1.w
mov r0.xyz, c19
mov r0.w, c22.x
dp4 r1.z, r0, c14
dp4 r1.x, r0, c12
dp4 r1.y, r0, c13
mad r1.xyz, r1, c18.w, -v0
dp3 r0.w, -r1, c8
dp3 oT0.y, r1, r2
dp3 r0.y, r2, c8
dp3 oT0.z, v2, r1
dp3 oT0.x, r1, v1
dp3 r0.x, v1, c8
dp3 r0.z, v2, c8
mul oT2, r0, c18.w
dp3 r0.w, -r1, c9
dp3 r0.y, r2, c9
dp3 r0.x, v1, c9
dp3 r0.z, v2, c9
mul oT3, r0, c18.w
dp3 r0.w, -r1, c10
dp3 r0.y, r2, c10
dp3 r0.x, v1, c10
dp3 r0.z, v2, c10
mul oT4, r0, c18.w
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r2.xyz, r0.xyww, c22.y
mov oPos, r0
mov r0.x, c21.w
add r0.y, c22.x, -r0.x
dp4 r0.x, v0, c2
mov r1.x, r2
mul r1.y, r2, c16.x
mad oT1.xy, r2.z, c17.zwzw, r1
dp4 r1.z, v0, c10
dp4 r1.x, v0, c8
dp4 r1.y, v0, c9
add r1.xyz, r1, -c21
mov oT1.zw, r0
mul oT6.xyz, r1, c21.w
mad oT5.xy, v3, c20, c20.zwzw
mul oT6.w, -r0.x, r0.y
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
Vector 14 [unity_Scale]
Vector 15 [_WorldSpaceCameraPos]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
"!!ARBvp1.0
# 56 ALU
PARAM c[23] = { { 1, 0.5 },
		state.matrix.mvp,
		program.local[5..22] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[14].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MUL R1, R0.xyzz, R0.yzzx;
MOV R0.w, c[0].x;
DP4 R2.z, R0, c[18];
DP4 R2.y, R0, c[17];
DP4 R2.x, R0, c[16];
MUL R0.y, R2.w, R2.w;
DP4 R3.z, R1, c[21];
DP4 R3.x, R1, c[19];
DP4 R3.y, R1, c[20];
MOV R1.xyz, vertex.attrib[14];
MAD R0.w, R0.x, R0.x, -R0.y;
ADD R2.xyz, R2, R3;
MUL R3.xyz, R0.w, c[22];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
ADD result.texcoord[5].xyz, R2, R3;
MUL R2.xyz, R0, vertex.attrib[14].w;
MOV R0.xyz, c[15];
MOV R0.w, c[0].x;
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
MAD R1.xyz, R1, c[14].w, -vertex.position;
DP3 R0.w, -R1, c[5];
DP3 result.texcoord[0].y, R1, R2;
DP3 R0.y, R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[14].w;
DP3 R0.w, -R1, c[6];
DP3 R0.y, R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[14].w;
DP3 R0.w, -R1, c[7];
DP3 R0.y, R2, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[14].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP3 result.texcoord[0].z, vertex.normal, R1;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].y;
DP3 result.texcoord[0].x, R1, vertex.attrib[14];
MOV R1.x, R2;
MUL R1.y, R2, c[13].x;
ADD result.texcoord[1].xy, R1, R2.z;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
END
# 56 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_Scale]
Vector 15 [_WorldSpaceCameraPos]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
"vs_2_0
; 57 ALU
def c23, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
mul r1.xyz, v2, c14.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c23.x
dp4 r2.z, r0, c18
dp4 r2.y, r0, c17
dp4 r2.x, r0, c16
mul r0.y, r2.w, r2.w
mad r0.w, r0.x, r0.x, -r0.y
dp4 r3.z, r1, c21
dp4 r3.y, r1, c20
dp4 r3.x, r1, c19
add r2.xyz, r2, r3
mul r3.xyz, r0.w, c22
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
add oT5.xyz, r2, r3
mul r2.xyz, r0, v1.w
mov r0.xyz, c15
mov r0.w, c23.x
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
mad r1.xyz, r1, c14.w, -v0
dp3 r0.w, -r1, c4
dp3 oT0.y, r1, r2
dp3 r0.y, r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT2, r0, c14.w
dp3 r0.w, -r1, c5
dp3 r0.y, r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT3, r0, c14.w
dp3 r0.w, -r1, c6
dp3 r0.y, r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT4, r0, c14.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp3 oT0.z, v2, r1
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c23.y
dp3 oT0.x, r1, v1
mov r1.x, r2
mul r1.y, r2, c12.x
mad oT1.xy, r2.z, c13.zwzw, r1
mov oPos, r0
mov oT1.zw, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_Scale]
Vector 19 [_WorldSpaceCameraPos]
Vector 20 [unity_LightmapST]
Vector 21 [unity_ShadowFadeCenterAndType]
"!!ARBvp1.0
# 48 ALU
PARAM c[22] = { { 1, 0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..21] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, R0, vertex.attrib[14].w;
MOV R0.xyz, c[19];
MOV R0.w, c[0].x;
DP4 R1.z, R0, c[15];
DP4 R1.x, R0, c[13];
DP4 R1.y, R0, c[14];
MAD R1.xyz, R1, c[18].w, -vertex.position;
DP3 R0.w, -R1, c[9];
DP3 result.texcoord[0].y, R1, R2;
DP3 R0.y, R2, c[9];
DP3 result.texcoord[0].z, vertex.normal, R1;
DP3 result.texcoord[0].x, R1, vertex.attrib[14];
DP3 R0.x, vertex.attrib[14], c[9];
DP3 R0.z, vertex.normal, c[9];
MUL result.texcoord[2], R0, c[18].w;
DP3 R0.w, -R1, c[10];
DP3 R0.y, R2, c[10];
DP3 R0.x, vertex.attrib[14], c[10];
DP3 R0.z, vertex.normal, c[10];
MUL result.texcoord[3], R0, c[18].w;
DP3 R0.w, -R1, c[11];
DP3 R0.y, R2, c[11];
DP3 R0.x, vertex.attrib[14], c[11];
DP3 R0.z, vertex.normal, c[11];
MUL result.texcoord[4], R0, c[18].w;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].y;
MOV result.position, R0;
MOV R0.x, c[0];
ADD R0.y, R0.x, -c[21].w;
DP4 R0.x, vertex.position, c[3];
MOV R1.x, R2;
MUL R1.y, R2, c[17].x;
ADD result.texcoord[1].xy, R1, R2.z;
DP4 R1.z, vertex.position, c[11];
DP4 R1.x, vertex.position, c[9];
DP4 R1.y, vertex.position, c[10];
ADD R1.xyz, R1, -c[21];
MOV result.texcoord[1].zw, R0;
MUL result.texcoord[6].xyz, R1, c[21].w;
MAD result.texcoord[5].xy, vertex.texcoord[1], c[20], c[20].zwzw;
MUL result.texcoord[6].w, -R0.x, R0.y;
END
# 48 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_Scale]
Vector 19 [_WorldSpaceCameraPos]
Vector 20 [unity_LightmapST]
Vector 21 [unity_ShadowFadeCenterAndType]
"vs_2_0
; 49 ALU
def c22, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord1 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r0, v1.w
mov r0.xyz, c19
mov r0.w, c22.x
dp4 r1.z, r0, c14
dp4 r1.x, r0, c12
dp4 r1.y, r0, c13
mad r1.xyz, r1, c18.w, -v0
dp3 r0.w, -r1, c8
dp3 oT0.y, r1, r2
dp3 r0.y, r2, c8
dp3 oT0.z, v2, r1
dp3 oT0.x, r1, v1
dp3 r0.x, v1, c8
dp3 r0.z, v2, c8
mul oT2, r0, c18.w
dp3 r0.w, -r1, c9
dp3 r0.y, r2, c9
dp3 r0.x, v1, c9
dp3 r0.z, v2, c9
mul oT3, r0, c18.w
dp3 r0.w, -r1, c10
dp3 r0.y, r2, c10
dp3 r0.x, v1, c10
dp3 r0.z, v2, c10
mul oT4, r0, c18.w
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r2.xyz, r0.xyww, c22.y
mov oPos, r0
mov r0.x, c21.w
add r0.y, c22.x, -r0.x
dp4 r0.x, v0, c2
mov r1.x, r2
mul r1.y, r2, c16.x
mad oT1.xy, r2.z, c17.zwzw, r1
dp4 r1.z, v0, c10
dp4 r1.x, v0, c8
dp4 r1.y, v0, c9
add r1.xyz, r1, -c21
mov oT1.zw, r0
mul oT6.xyz, r1, c21.w
mad oT5.xy, v3, c20, c20.zwzw
mul oT6.w, -r0.x, r0.y
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
Vector 7 [_Specular]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_LightBuffer] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 35 ALU, 2 TEX
PARAM c[9] = { program.local[0..7],
		{ 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
DP3 R1.w, fragment.texcoord[0], fragment.texcoord[0];
RSQ R1.w, R1.w;
MAD R2.w, -R1, fragment.texcoord[0].z, c[8].x;
MOV R1.x, fragment.texcoord[2].z;
MOV R1.y, fragment.texcoord[3].z;
MOV R1.z, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[8].y, R0;
POW R3.x, R2.w, c[3].x;
MUL R1.w, R1, fragment.texcoord[0].z;
MOV result.color.w, c[8].x;
TEX R1.xyz, R0, texture[0], CUBE;
TXP R0, fragment.texcoord[1], texture[1], 2D;
MUL R2.xyz, R1, c[6];
MUL R1.xyz, R1, c[5];
MUL R1.xyz, R1, R3.x;
POW R3.x, R1.w, c[4].x;
MAD R3.xyz, R2, R3.x, R1;
LG2 R0.w, R0.w;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R1.xyz, -R0, fragment.texcoord[5];
MUL R0.xyz, -R0.w, c[7];
POW R0.w, R2.w, c[1].x;
MUL R2.xyz, R1, R0;
MUL R0.xyz, R0.w, c[2];
POW R0.w, R1.w, c[1].x;
MAD R0.xyz, R0.w, c[0], R0;
MAD R0.xyz, R0, R1, R2;
ADD result.color.xyz, R0, R3;
END
# 35 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
Vector 7 [_Specular]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_LightBuffer] 2D
"ps_2_0
; 44 ALU, 2 TEX
dcl_cube s0
dcl_2d s1
def c8, 1.00000000, 2.00000000, 0, 0
dcl t0.xyz
dcl t1
dcl t2.xyzw
dcl t3.xyzw
dcl t4.xyzw
dcl t5.xyz
mov_pp r2.x, t2.z
mov_pp r2.y, t3.z
mov_pp r2.z, t4
mov r1.x, t2.w
mov r1.z, t4.w
mov r1.y, t3.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r1.xyz, -r0, c8.y, r1
texld r2, r1, s0
texldp r0, t1, s1
dp3 r1.x, t0, t0
rsq r1.x, r1.x
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r4.xyz, -r0, t5
log_pp r0.x, r0.w
mul_pp r3.xyz, -r0.x, c7
mad r0.x, -r1, t0.z, c8
mul r0.z, r1.x, t0
pow r1.w, r0.z, c1.x
mul_pp r5.xyz, r4, r3
pow r3.w, r0.x, c1.x
mul r3.xyz, r3.w, c2
mad r1.xyz, r1.w, c0, r3
mad_pp r3.xyz, r1, r4, r5
pow r1.x, r0.x, c3.x
mov r0.x, r1.x
mul r4.xyz, r2, c5
pow r1.x, r0.z, c4.x
mul r4.xyz, r4, r0.x
mul r2.xyz, r2, c6
mov r0.x, r1.x
mad r0.xyz, r2, r0.x, r4
mov_pp r0.w, c8.x
add_pp r0.xyz, r3, r0
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
Vector 7 [_Specular]
Vector 8 [unity_LightmapFade]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_LightBuffer] 2D
SetTexture 2 [unity_Lightmap] 2D
SetTexture 3 [unity_LightmapInd] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 46 ALU, 4 TEX
PARAM c[10] = { program.local[0..8],
		{ 1, 8, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2, fragment.texcoord[5], texture[3], 2D;
DP3 R3.w, fragment.texcoord[0], fragment.texcoord[0];
RSQ R4.w, R3.w;
MAD R3.w, -R4, fragment.texcoord[0].z, c[9].x;
MUL R2.xyz, R2.w, R2;
MUL R2.xyz, R2, c[9].y;
MOV R1.x, fragment.texcoord[2].z;
MOV R1.y, fragment.texcoord[3].z;
MOV R1.z, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[9].z, R0;
POW R5.x, R3.w, c[3].x;
MUL R4.w, R4, fragment.texcoord[0].z;
MOV result.color.w, c[9].x;
TEX R3.xyz, R0, texture[0], CUBE;
TXP R0, fragment.texcoord[1], texture[1], 2D;
TEX R1, fragment.texcoord[5], texture[2], 2D;
MUL R1.xyz, R1.w, R1;
MUL R4.xyz, R3, c[6];
MUL R3.xyz, R3, c[5];
MUL R3.xyz, R3, R5.x;
POW R5.x, R4.w, c[4].x;
DP4 R1.w, fragment.texcoord[6], fragment.texcoord[6];
RSQ R1.w, R1.w;
RCP R1.w, R1.w;
MAD R1.xyz, R1, c[9].y, -R2;
MAD_SAT R1.w, R1, c[8].z, c[8];
MAD R1.xyz, R1.w, R1, R2;
LG2 R0.w, R0.w;
MAD R3.xyz, R4, R5.x, R3;
LG2 R0.x, R0.x;
LG2 R0.y, R0.y;
LG2 R0.z, R0.z;
ADD R0.xyz, -R0, R1;
MUL R1.xyz, -R0.w, c[7];
MUL R2.xyz, R0, R1;
POW R0.w, R3.w, c[1].x;
MUL R1.xyz, R0.w, c[2];
POW R0.w, R4.w, c[1].x;
MAD R1.xyz, R0.w, c[0], R1;
MAD R0.xyz, R1, R0, R2;
ADD result.color.xyz, R0, R3;
END
# 46 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
Vector 7 [_Specular]
Vector 8 [unity_LightmapFade]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_LightBuffer] 2D
SetTexture 2 [unity_Lightmap] 2D
SetTexture 3 [unity_LightmapInd] 2D
"ps_2_0
; 53 ALU, 4 TEX
dcl_cube s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c9, 1.00000000, 8.00000000, 2.00000000, 0
dcl t0.xyz
dcl t1
dcl t2.xyzw
dcl t3.xyzw
dcl t4.xyzw
dcl t5.xy
dcl t6
texld r3, t5, s2
mov_pp r2.x, t2.z
mov_pp r2.y, t3.z
mov_pp r2.z, t4
mov r1.x, t2.w
mov r1.z, t4.w
mov r1.y, t3.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c9.z, r1
mul_pp r3.xyz, r3.w, r3
texld r2, r0, s0
texldp r1, t1, s1
texld r0, t5, s3
mul_pp r4.xyz, r0.w, r0
mul_pp r4.xyz, r4, c9.y
dp4 r0.x, t6, t6
rsq r0.x, r0.x
rcp r0.x, r0.x
mad_pp r3.xyz, r3, c9.y, -r4
mad_sat r0.x, r0, c8.z, c8.w
mad_pp r0.xyz, r0.x, r3, r4
log_pp r3.x, r1.w
log_pp r1.x, r1.x
log_pp r1.y, r1.y
log_pp r1.z, r1.z
add_pp r4.xyz, -r1, r0
dp3 r0.x, t0, t0
rsq r1.x, r0.x
mul_pp r3.xyz, -r3.x, c7
mad r0.x, -r1, t0.z, c9
mul r0.z, r1.x, t0
pow r1.w, r0.z, c1.x
mul_pp r5.xyz, r4, r3
pow r3.w, r0.x, c1.x
mul r3.xyz, r3.w, c2
mad r1.xyz, r1.w, c0, r3
mad_pp r3.xyz, r1, r4, r5
pow r1.x, r0.x, c3.x
mov r0.x, r1.x
mul r4.xyz, r2, c5
pow r1.x, r0.z, c4.x
mul r4.xyz, r4, r0.x
mul r2.xyz, r2, c6
mov r0.x, r1.x
mad r0.xyz, r2, r0.x, r4
mov_pp r0.w, c9.x
add_pp r0.xyz, r3, r0
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
Vector 7 [_Specular]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_LightBuffer] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 31 ALU, 2 TEX
PARAM c[9] = { program.local[0..7],
		{ 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
DP3 R1.w, fragment.texcoord[0], fragment.texcoord[0];
RSQ R1.w, R1.w;
MAD R2.w, -R1, fragment.texcoord[0].z, c[8].x;
MOV R1.x, fragment.texcoord[2].z;
MOV R1.y, fragment.texcoord[3].z;
MOV R1.z, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[8].y, R0;
POW R3.x, R2.w, c[3].x;
MUL R1.w, R1, fragment.texcoord[0].z;
MOV result.color.w, c[8].x;
TEX R1.xyz, R0, texture[0], CUBE;
TXP R0, fragment.texcoord[1], texture[1], 2D;
MUL R2.xyz, R1, c[6];
MUL R1.xyz, R1, c[5];
MUL R1.xyz, R1, R3.x;
POW R3.x, R1.w, c[4].x;
MAD R3.xyz, R2, R3.x, R1;
ADD R1.xyz, R0, fragment.texcoord[5];
MUL R0.xyz, R0.w, c[7];
POW R0.w, R2.w, c[1].x;
MUL R2.xyz, R1, R0;
MUL R0.xyz, R0.w, c[2];
POW R0.w, R1.w, c[1].x;
MAD R0.xyz, R0.w, c[0], R0;
MAD R0.xyz, R0, R1, R2;
ADD result.color.xyz, R0, R3;
END
# 31 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
Vector 7 [_Specular]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_LightBuffer] 2D
"ps_2_0
; 40 ALU, 2 TEX
dcl_cube s0
dcl_2d s1
def c8, 1.00000000, 2.00000000, 0, 0
dcl t0.xyz
dcl t1
dcl t2.xyzw
dcl t3.xyzw
dcl t4.xyzw
dcl t5.xyz
mov_pp r2.x, t2.z
mov_pp r2.y, t3.z
mov_pp r2.z, t4
mov r1.x, t2.w
mov r1.z, t4.w
mov r1.y, t3.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c8.y, r1
mov_pp r0.w, c8.x
texld r2, r0, s0
texldp r1, t1, s1
add_pp r4.xyz, r1, t5
mul_pp r3.xyz, r1.w, c7
dp3 r0.x, t0, t0
rsq r1.x, r0.x
mad r0.x, -r1, t0.z, c8
mul r0.z, r1.x, t0
pow r1.w, r0.z, c1.x
mul_pp r5.xyz, r4, r3
pow r3.w, r0.x, c1.x
mul r3.xyz, r3.w, c2
mad r1.xyz, r1.w, c0, r3
mad_pp r3.xyz, r1, r4, r5
pow r1.x, r0.x, c3.x
mov r0.x, r1.x
mul r4.xyz, r2, c5
pow r1.x, r0.z, c4.x
mul r4.xyz, r4, r0.x
mul r2.xyz, r2, c6
mov r0.x, r1.x
mad r0.xyz, r2, r0.x, r4
add_pp r0.xyz, r3, r0
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
Vector 7 [_Specular]
Vector 8 [unity_LightmapFade]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_LightBuffer] 2D
SetTexture 2 [unity_Lightmap] 2D
SetTexture 3 [unity_LightmapInd] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 42 ALU, 4 TEX
PARAM c[10] = { program.local[0..8],
		{ 1, 8, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2, fragment.texcoord[5], texture[3], 2D;
MUL R2.xyz, R2.w, R2;
MUL R2.xyz, R2, c[9].y;
MOV R1.x, fragment.texcoord[2].z;
MOV R1.y, fragment.texcoord[3].z;
MOV R1.z, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[9].z, R0;
MOV result.color.w, c[9].x;
TEX R3.xyz, R0, texture[0], CUBE;
TEX R1, fragment.texcoord[5], texture[2], 2D;
TXP R0, fragment.texcoord[1], texture[1], 2D;
MUL R1.xyz, R1.w, R1;
DP4 R1.w, fragment.texcoord[6], fragment.texcoord[6];
RSQ R1.w, R1.w;
RCP R2.w, R1.w;
DP3 R1.w, fragment.texcoord[0], fragment.texcoord[0];
MAD R1.xyz, R1, c[9].y, -R2;
MAD_SAT R2.w, R2, c[8].z, c[8];
MAD R1.xyz, R2.w, R1, R2;
ADD R0.xyz, R0, R1;
RSQ R1.w, R1.w;
MAD R2.w, -R1, fragment.texcoord[0].z, c[9].x;
MUL R1.xyz, R0.w, c[7];
MUL R2.xyz, R3, c[6];
POW R3.w, R2.w, c[3].x;
MUL R3.xyz, R3, c[5];
MUL R3.xyz, R3, R3.w;
MUL R1.w, R1, fragment.texcoord[0].z;
POW R3.w, R1.w, c[4].x;
MAD R2.xyz, R2, R3.w, R3;
MUL R3.xyz, R0, R1;
POW R0.w, R2.w, c[1].x;
MUL R1.xyz, R0.w, c[2];
POW R0.w, R1.w, c[1].x;
MAD R1.xyz, R0.w, c[0], R1;
MAD R0.xyz, R1, R0, R3;
ADD result.color.xyz, R0, R2;
END
# 42 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Float 1 [_SecondaryFresnel]
Vector 2 [_SecondaryColor]
Float 3 [_Fresnel]
Float 4 [_FresnelInverse]
Vector 5 [_RefColor]
Vector 6 [_RefColorInverse]
Vector 7 [_Specular]
Vector 8 [unity_LightmapFade]
SetTexture 0 [_CubeMap] CUBE
SetTexture 1 [_LightBuffer] 2D
SetTexture 2 [unity_Lightmap] 2D
SetTexture 3 [unity_LightmapInd] 2D
"ps_2_0
; 49 ALU, 4 TEX
dcl_cube s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c9, 1.00000000, 8.00000000, 2.00000000, 0
dcl t0.xyz
dcl t1
dcl t2.xyzw
dcl t3.xyzw
dcl t4.xyzw
dcl t5.xy
dcl t6
texld r3, t5, s3
mul_pp r3.xyz, r3.w, r3
mov_pp r2.x, t2.z
mov_pp r2.y, t3.z
mov_pp r2.z, t4
mov r1.x, t2.w
mov r1.z, t4.w
mov r1.y, t3.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c9.z, r1
mul_pp r3.xyz, r3, c9.y
texld r2, r0, s0
texldp r1, t1, s1
texld r0, t5, s2
mul_pp r4.xyz, r0.w, r0
dp4 r0.x, t6, t6
rsq r0.x, r0.x
rcp r0.x, r0.x
mad_pp r4.xyz, r4, c9.y, -r3
mad_sat r0.x, r0, c8.z, c8.w
mad_pp r3.xyz, r0.x, r4, r3
add_pp r4.xyz, r1, r3
mul_pp r3.xyz, r1.w, c7
dp3 r0.x, t0, t0
rsq r1.x, r0.x
mad r0.x, -r1, t0.z, c9
mul r0.z, r1.x, t0
pow r1.w, r0.z, c1.x
mul_pp r5.xyz, r4, r3
pow r3.w, r0.x, c1.x
mul r3.xyz, r3.w, c2
mad r1.xyz, r1.w, c0, r3
mad_pp r3.xyz, r1, r4, r5
pow r1.x, r0.x, c3.x
mov r0.x, r1.x
mul r4.xyz, r2, c5
pow r1.x, r0.z, c4.x
mul r4.xyz, r4, r0.x
mul r2.xyz, r2, c6
mov r0.x, r1.x
mad r0.xyz, r2, r0.x, r4
mov_pp r0.w, c9.x
add_pp r0.xyz, r3, r0
mov_pp oC0, r0
"
}
}
 }
}
Fallback "Reflective/Diffuse"
}