Shader "Hidden/Nature/Tree Creator Leaves Rendertex" {
Properties {
 _TranslucencyColor ("Translucency Color", Color) = (0.73,0.85,0.41,1)
 _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
 _HalfOverCutoff ("0.5 / alpha cutoff", Range(0,1)) = 1
 _TranslucencyViewDependency ("View dependency", Range(0,1)) = 0.7
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
 _BumpSpecMap ("Normalmap (GA) Spec (R) Shadow Offset (B)", 2D) = "bump" {}
 _TranslucencyMap ("Trans (B) Gloss(A)", 2D) = "white" {}
}
SubShader { 
 Pass {
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 9 [_World2Object]
Vector 13 [unity_Scale]
Vector 14 [_WorldSpaceCameraPos]
Float 15 [_TranslucencyViewDependency]
Vector 16 [_TerrainTreeLightDirections0]
Vector 17 [_TerrainTreeLightDirections1]
Vector 18 [_TerrainTreeLightDirections2]
"!!ARBvp1.0
# 79 ALU
PARAM c[20] = { { 0, 1, 2, 0.60009766 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9..18],
		{ 0.39990234 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0, vertex.normal.y, c[6];
MAD R1, vertex.normal.x, c[5], R0;
ABS R2.x, vertex.attrib[14].w;
ADD R3.w, -R2.x, c[0].y;
ADD R0, R1, c[0].x;
MAD R0, R0, R3.w, vertex.position;
MAD R1, vertex.normal.z, c[7], R1;
ADD R1, R1, c[0].x;
DP4 R1.w, R1, R1;
RSQ R1.w, R1.w;
MAD R1.xyz, R1.w, R1, -vertex.normal;
MAD R1.xyz, R3.w, R1, vertex.normal;
MOV R2.w, c[0].y;
MOV R2.xyz, c[14];
DP4 R3.z, R2, c[11];
DP4 R3.y, R2, c[10];
DP4 R3.x, R2, c[9];
MAD R2.xyz, R3, c[13].w, -R0;
DP3 R2.w, R2, R2;
RSQ R2.w, R2.w;
MUL R2.xyz, R2.w, R2;
ADD R3.xyz, R2, c[18];
DP3 R2.w, R3, R3;
RSQ R2.w, R2.w;
MUL R3.xyz, R2.w, R3;
DP3 R1.w, R1, R3;
ADD R4.xyz, R2, c[17];
DP3 R2.w, R4, R4;
MAX result.texcoord[4].z, R1.w, c[0].x;
RSQ R1.w, R2.w;
ADD R3.xyz, R2, c[16];
DP3 R2.w, R3, R3;
RSQ R2.w, R2.w;
MUL R3.xyz, R2.w, R3;
DP3 R3.x, R1, R3;
DP3 R2.w, R2, -c[18];
MUL R4.xyz, R1.w, R4;
DP3 R1.w, R1, R4;
MAX result.texcoord[4].y, R1.w, c[0].x;
DP3 R1.w, R1, c[18];
MIN R3.w, -R1, c[0].y;
MIN R2.w, R2, c[0].y;
MAX result.texcoord[4].x, R3, c[0];
DP3 R3.x, R2, -c[17];
MIN R3.y, R3.x, c[0];
MAX R3.w, R3, c[0].x;
MAX R2.w, R2, c[0].x;
ADD R2.w, R2, -R3;
MAD R2.w, R2, c[15].x, R3;
MUL result.texcoord[2].z, R2.w, c[0];
DP3 R2.w, R1, c[17];
DP3 R1.x, R1, c[16];
DP3 R1.y, R2, -c[16];
MIN R3.z, -R2.w, c[0].y;
MIN R1.z, -R1.x, c[0].y;
MIN R1.y, R1, c[0];
MAX R3.x, R3.z, c[0];
MAX R3.y, R3, c[0].x;
MAX R1.z, R1, c[0].x;
MAX R1.y, R1, c[0].x;
ADD R2.x, R1.y, -R1.z;
MAD R1.z, R2.x, c[15].x, R1;
ADD R3.y, R3, -R3.x;
MAD R1.y, R3, c[15].x, R3.x;
MUL result.texcoord[2].y, R1, c[0].z;
MOV R1.y, c[19].x;
MUL result.texcoord[2].x, R1.z, c[0].z;
MAD R1.z, R1.w, c[0].w, R1.y;
DP4 result.position.w, R0, c[4];
DP4 result.position.z, R0, c[3];
DP4 result.position.y, R0, c[2];
DP4 result.position.x, R0, c[1];
MAD R0.x, R2.w, c[0].w, R1.y;
MAD R0.y, R1.x, c[0].w, R1;
MAX result.texcoord[3].z, R1, c[0].x;
MAX result.texcoord[3].y, R0.x, c[0].x;
MAX result.texcoord[3].x, R0.y, c[0];
MOV result.texcoord[1].xyz, vertex.color.w;
MOV result.texcoord[0].xy, vertex.texcoord[0];
END
# 79 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Matrix 8 [_World2Object]
Vector 12 [unity_Scale]
Vector 13 [_WorldSpaceCameraPos]
Float 14 [_TranslucencyViewDependency]
Vector 15 [_TerrainTreeLightDirections0]
Vector 16 [_TerrainTreeLightDirections1]
Vector 17 [_TerrainTreeLightDirections2]
"vs_2_0
; 78 ALU
def c18, 0.00000000, 1.00000000, 2.00000000, 0
def c19, 0.60009766, 0.39990234, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_color0 v4
mul r0, v2.y, c5
mad r1, v2.x, c4, r0
abs r2.x, v1.w
add r3.w, -r2.x, c18.y
add r0, r1, c18.x
mad r0, r0, r3.w, v0
mad r1, v2.z, c6, r1
add r1, r1, c18.x
dp4 r1.w, r1, r1
rsq r1.w, r1.w
mad r1.xyz, r1.w, r1, -v2
mad r1.xyz, r3.w, r1, v2
mov r2.w, c18.y
mov r2.xyz, c13
dp4 r3.z, r2, c10
dp4 r3.y, r2, c9
dp4 r3.x, r2, c8
mad r2.xyz, r3, c12.w, -r0
dp3 r2.w, r2, r2
rsq r2.w, r2.w
mul r2.xyz, r2.w, r2
add r3.xyz, r2, c17
dp3 r2.w, r3, r3
rsq r2.w, r2.w
mul r3.xyz, r2.w, r3
dp3 r1.w, r1, r3
add r4.xyz, r2, c16
dp3 r2.w, r4, r4
max oT4.z, r1.w, c18.x
rsq r1.w, r2.w
add r3.xyz, r2, c15
dp3 r2.w, r3, r3
rsq r2.w, r2.w
mul r3.xyz, r2.w, r3
dp3 r3.x, r1, r3
dp3 r2.w, r2, -c17
mul r4.xyz, r1.w, r4
dp3 r1.w, r1, r4
max oT4.y, r1.w, c18.x
dp3 r1.w, r1, c17
min r3.w, -r1, c18.y
min r2.w, r2, c18.y
max oT4.x, r3, c18
dp3 r3.x, r2, -c16
min r3.y, r3.x, c18
max r3.w, r3, c18.x
max r2.w, r2, c18.x
add r2.w, r2, -r3
mad r2.w, r2, c14.x, r3
mul oT2.z, r2.w, c18
dp3 r2.w, r1, c16
dp3 r1.x, r1, c15
dp3 r1.y, r2, -c15
min r3.z, -r2.w, c18.y
min r1.z, -r1.x, c18.y
min r1.y, r1, c18
max r3.x, r3.z, c18
max r3.y, r3, c18.x
max r1.z, r1, c18.x
max r1.y, r1, c18.x
add r2.x, r1.y, -r1.z
add r3.y, r3, -r3.x
mad r1.y, r3, c14.x, r3.x
mad r1.z, r2.x, c14.x, r1
mul oT2.y, r1, c18.z
mad r1.y, r1.w, c19.x, c19
dp4 oPos.w, r0, c3
dp4 oPos.z, r0, c2
dp4 oPos.y, r0, c1
dp4 oPos.x, r0, c0
mad r0.x, r2.w, c19, c19.y
mad r0.y, r1.x, c19.x, c19
mul oT2.x, r1.z, c18.z
max oT3.z, r1.y, c18.x
max oT3.y, r0.x, c18.x
max oT3.x, r0.y, c18
mov oT1.xyz, v4.w
mov oT0.xy, v3
"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 1 [_SpecColor]
Vector 2 [_TranslucencyColor]
Vector 3 [_TerrainTreeLightColors0]
Vector 4 [_TerrainTreeLightColors1]
Vector 5 [_TerrainTreeLightColors2]
Float 6 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_BumpSpecMap] 2D
SetTexture 2 [_TranslucencyMap] 2D
"!!ARBfp1.0
# 29 ALU, 3 TEX
PARAM c[8] = { state.lightmodel.ambient,
		program.local[1..6],
		{ 1, 128, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TEX R0.zw, fragment.texcoord[0], texture[2], 2D;
MUL R3.xyw, fragment.texcoord[2].xyzz, R0.z;
SLT R0.x, R1.w, c[6];
MAD R2.xyz, R3.y, c[2], fragment.texcoord[3].y;
MUL R1.xyz, R1, fragment.texcoord[1];
MAD R3.xyz, R3.x, c[2], fragment.texcoord[3].x;
MOV result.color.w, c[7].x;
KIL -R0.x;
TEX R0.x, fragment.texcoord[0], texture[1], 2D;
MUL R1.w, R0.x, c[7].y;
POW R0.x, fragment.texcoord[4].y, R1.w;
POW R2.w, fragment.texcoord[4].x, R1.w;
MUL R0.x, R0.w, R0;
MUL R0.xyz, R0.x, c[1];
MAD R2.xyz, R1, R2, R0;
MUL R2.w, R0, R2;
MUL R0.xyz, R2.w, c[1];
MAD R3.xyz, R1, R3, R0;
MUL R0.xyz, R1, c[0];
MAD R0.xyz, R3, c[3], R0;
POW R1.w, fragment.texcoord[4].z, R1.w;
MAD R2.xyz, R2, c[4], R0;
MUL R0.w, R0, R1;
MUL R0.xyz, R0.w, c[1];
MAD R3.xyz, R3.w, c[2], fragment.texcoord[3].z;
MAD R0.xyz, R1, R3, R0;
MAD R0.xyz, R0, c[5], R2;
MUL result.color.xyz, R0, c[7].z;
END
# 29 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [glstate_lightmodel_ambient]
Vector 1 [_SpecColor]
Vector 2 [_TranslucencyColor]
Vector 3 [_TerrainTreeLightColors0]
Vector 4 [_TerrainTreeLightColors1]
Vector 5 [_TerrainTreeLightColors2]
Float 6 [_Cutoff]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_BumpSpecMap] 2D
SetTexture 2 [_TranslucencyMap] 2D
"ps_2_0
; 37 ALU, 4 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c7, 0.00000000, 1.00000000, 128.00000000, 2.00000000
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4.xyz
texld r0, t0, s0
texld r2, t0, s2
add_pp r1.x, r0.w, -c6
cmp r1.x, r1, c7, c7.y
mov_pp r1, -r1.x
mul r0.xyz, r0, t1
mov_pp r0.w, c7.y
texkill r1.xyzw
texld r1, t0, s1
mul r1.x, r1, c7.z
pow_pp r3.w, t4.x, r1.x
pow_pp r4.w, t4.y, r1.x
mov_pp r2.x, r3.w
mov_pp r3.x, r4.w
mul r4.xyz, t2, r2.z
mul_pp r3.x, r2.w, r3
mul_pp r2.x, r2.w, r2
mad_pp r5.xyz, r4.y, c2, t3.y
mul_pp r3.xyz, r3.x, c1
mad_pp r3.xyz, r0, r5, r3
pow_pp r5.x, t4.z, r1.x
mul_pp r2.xyz, r2.x, c1
mad_pp r1.xyz, r4.x, c2, t3.x
mad_pp r1.xyz, r0, r1, r2
mul r2.xyz, r0, c0
mad_pp r1.xyz, r1, c3, r2
mad_pp r1.xyz, r3, c4, r1
mov_pp r4.x, r5.x
mul_pp r2.x, r2.w, r4
mul_pp r2.xyz, r2.x, c1
mad_pp r3.xyz, r4.z, c2, t3.z
mad_pp r0.xyz, r0, r3, r2
mad_pp r0.xyz, r0, c5, r1
mul_pp r0.xyz, r0, c7.w
mov_pp oC0, r0
"
}
}
 }
}
SubShader { 
 Pass {
  Fog { Mode Off }
  AlphaTest GEqual 1
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Vector 6 [_TerrainTreeLightDirections0]
Vector 7 [_TerrainTreeLightDirections1]
Vector 8 [_TerrainTreeLightDirections2]
Vector 9 [_TerrainTreeLightColors0]
Vector 10 [_TerrainTreeLightColors1]
Vector 11 [_TerrainTreeLightColors2]
Float 12 [_HalfOverCutoff]
"!!ARBvp1.0
# 17 ALU
PARAM c[13] = { { 0.5 },
		state.lightmodel.ambient,
		state.matrix.mvp,
		program.local[6..12] };
TEMP R0;
TEMP R1;
TEMP R2;
DP3 R0.x, vertex.normal, c[8];
MUL R2.xyz, R0.x, c[11];
DP3 R0.x, vertex.normal, c[6];
MUL R1.xyz, R0.x, c[9];
DP3 R0.y, vertex.normal, c[7];
MUL R0.xyz, R0.y, c[10];
ADD R1.xyz, R1, c[1];
ADD R0.xyz, R1, R0;
ADD R0.xyz, R0, R2;
MUL result.color.xyz, R0, vertex.color.w;
MOV R0.x, c[0];
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[5];
DP4 result.position.z, vertex.position, c[4];
DP4 result.position.y, vertex.position, c[3];
DP4 result.position.x, vertex.position, c[2];
MUL result.color.w, R0.x, c[12].x;
END
# 17 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [glstate_lightmodel_ambient]
Vector 5 [_TerrainTreeLightDirections0]
Vector 6 [_TerrainTreeLightDirections1]
Vector 7 [_TerrainTreeLightDirections2]
Vector 8 [_TerrainTreeLightColors0]
Vector 9 [_TerrainTreeLightColors1]
Vector 10 [_TerrainTreeLightColors2]
Float 11 [_HalfOverCutoff]
"vs_2_0
; 17 ALU
def c12, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
dp3 r0.x, v1, c7
mul r2.xyz, r0.x, c10
dp3 r0.x, v1, c5
mul r1.xyz, r0.x, c8
dp3 r0.y, v1, c6
mul r0.xyz, r0.y, c9
add r1.xyz, r1, c4
add r0.xyz, r1, r0
add r0.xyz, r0, r2
mul oD0.xyz, r0, v3.w
mov r0.x, c11
mov oT0.xy, v2
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
mul oD0.w, c12.x, r0.x
"
}
}
  SetTexture [_MainTex] { combine texture * primary double, texture alpha * primary alpha quad }
 }
}
Fallback Off
}