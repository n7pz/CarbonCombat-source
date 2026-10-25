Shader "Hidden/Nature/Tree Creator Bark Rendertex" {
Properties {
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
 _BumpSpecMap ("Normalmap (GA) Spec (R)", 2D) = "bump" {}
 _TranslucencyMap ("Trans (RGB) Gloss(A)", 2D) = "white" {}
 _SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
 _Scale ("Scale", Vector) = (1,1,1,1)
 _SquashAmount ("Squash", Float) = 1
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
Matrix 5 [_World2Object]
Vector 9 [unity_Scale]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [_TerrainTreeLightDirections0]
Vector 12 [_TerrainTreeLightDirections1]
Vector 13 [_TerrainTreeLightDirections2]
"!!ARBvp1.0
# 35 ALU
PARAM c[14] = { { 1, 0 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
MOV R1.w, c[0].x;
MOV R1.xyz, c[10];
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
MAD R0.xyz, R0, c[9].w, -vertex.position;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MAD R1.xyz, R0.w, R0, c[11];
DP3 R1.w, R1, R1;
RSQ R1.w, R1.w;
MUL R1.xyz, R1.w, R1;
DP3 R1.x, vertex.normal, R1;
MAX result.texcoord[2].y, R1.x, c[0];
MAD R1.xyz, R0.w, R0, c[12];
MAD R0.xyz, R0.w, R0, c[13];
DP3 R1.w, R1, R1;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
RSQ R1.w, R1.w;
MUL R1.xyz, R1.w, R1;
DP3 R0.w, vertex.normal, R1;
DP3 R0.x, vertex.normal, R0;
MAX result.texcoord[3].y, R0.w, c[0];
MAX result.texcoord[4].y, R0.x, c[0];
MOV result.texcoord[1].xyz, vertex.color.w;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP3 result.texcoord[2].x, vertex.normal, c[11];
DP3 result.texcoord[3].x, vertex.normal, c[12];
DP3 result.texcoord[4].x, vertex.normal, c[13];
END
# 35 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_World2Object]
Vector 8 [unity_Scale]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_TerrainTreeLightDirections0]
Vector 11 [_TerrainTreeLightDirections1]
Vector 12 [_TerrainTreeLightDirections2]
"vs_2_0
; 35 ALU
def c13, 1.00000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mov r1.w, c13.x
mov r1.xyz, c9
dp4 r0.z, r1, c6
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
mad r0.xyz, r0, c8.w, -v0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mad r1.xyz, r0.w, r0, c10
dp3 r1.w, r1, r1
rsq r1.w, r1.w
mul r1.xyz, r1.w, r1
dp3 r1.x, v1, r1
max oT2.y, r1.x, c13
mad r1.xyz, r0.w, r0, c11
mad r0.xyz, r0.w, r0, c12
dp3 r1.w, r1, r1
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
rsq r1.w, r1.w
mul r1.xyz, r1.w, r1
dp3 r0.w, v1, r1
dp3 r0.x, v1, r0
max oT3.y, r0.w, c13
max oT4.y, r0.x, c13
mov oT1.xyz, v3.w
mov oT0.xy, v2
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp3 oT2.x, v1, c10
dp3 oT3.x, v1, c11
dp3 oT4.x, v1, c12
"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 1 [_TerrainTreeLightColors0]
Vector 2 [_TerrainTreeLightColors1]
Vector 3 [_TerrainTreeLightColors2]
Vector 4 [_SpecColor]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
"!!ARBfp1.0
# 30 ALU, 3 TEX
PARAM c[6] = { state.lightmodel.ambient,
		program.local[1..4],
		{ 1, 128, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1.x, fragment.texcoord[0], texture[2], 2D;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
TEX R0.w, fragment.texcoord[0], texture[1], 2D;
MUL R1.w, R1.x, c[5].y;
POW R1.x, fragment.texcoord[2].y, R1.w;
POW R2.w, fragment.texcoord[3].y, R1.w;
MUL R0.xyz, R0, fragment.texcoord[1];
MUL R2.x, R1, R0.w;
MOV R3.xyz, c[4];
MUL R1.xyz, R3, c[1];
MUL R4.xyz, R1, R2.x;
MUL R2.xyz, R0, c[1];
MUL R1.xyz, R0, c[0];
MAD R1.xyz, R2, fragment.texcoord[2].x, R1;
MUL R2.xyz, R0, c[2];
ADD R1.xyz, R1, R4;
MAD R2.xyz, R2, fragment.texcoord[3].x, R1;
MUL R2.w, R0, R2;
MUL R1.xyz, R3, c[2];
MUL R1.xyz, R1, R2.w;
ADD R1.xyz, R2, R1;
POW R1.w, fragment.texcoord[4].y, R1.w;
MUL R0.xyz, R0, c[3];
MUL R0.w, R0, R1;
MUL R2.xyz, R3, c[3];
MUL R2.xyz, R2, R0.w;
MAD R0.xyz, R0, fragment.texcoord[4].x, R1;
ADD R0.xyz, R0, R2;
MUL result.color.xyz, R0, c[5].z;
MOV result.color.w, c[5].x;
END
# 30 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [glstate_lightmodel_ambient]
Vector 1 [_TerrainTreeLightColors0]
Vector 2 [_TerrainTreeLightColors1]
Vector 3 [_TerrainTreeLightColors2]
Vector 4 [_SpecColor]
SetTexture 0 [_MainTex] 2D
SetTexture 1 [_TranslucencyMap] 2D
SetTexture 2 [_BumpSpecMap] 2D
"ps_2_0
; 38 ALU, 3 TEX
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c5, 128.00000000, 2.00000000, 1.00000000, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xy
dcl t3.xy
dcl t4.xy
texld r2, t0, s2
texld r1, t0, s0
texld r0, t0, s1
mul r0.x, r2, c5
mul r2.xyz, r1, t1
pow r1.w, t2.y, r0.x
mul r3.xyz, r2, c0
mul_pp r4.xyz, r2, c1
mad_pp r5.xyz, r4, t2.x, r3
pow r3.w, t3.y, r0.x
mov_pp r4.xyz, c1
mul r1.x, r1.w, r0.w
mul_pp r4.xyz, c4, r4
mul r1.xyz, r4, r1.x
add_pp r4.xyz, r5, r1
mov r1.x, r3.w
mul_pp r3.xyz, r2, c2
mad_pp r4.xyz, r3, t3.x, r4
pow r3.w, t4.y, r0.x
mov_pp r5.xyz, c2
mul r1.x, r0.w, r1
mul_pp r0.xyz, c4, r5
mul r0.xyz, r0, r1.x
add_pp r1.xyz, r4, r0
mov r0.x, r3.w
mul r0.x, r0.w, r0
mov_pp r3.xyz, c3
mul_pp r3.xyz, c4, r3
mul_pp r2.xyz, r2, c3
mul r0.xyz, r3, r0.x
mad_pp r1.xyz, r2, t4.x, r1
add_pp r0.xyz, r1, r0
mul_pp r0.xyz, r0, c5.y
mov_pp r0.w, c5.z
mov_pp oC0, r0
"
}
}
 }
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
Vector 6 [_TerrainTreeLightDirections0]
Vector 7 [_TerrainTreeLightDirections1]
Vector 8 [_TerrainTreeLightDirections2]
Vector 9 [_TerrainTreeLightColors0]
Vector 10 [_TerrainTreeLightColors1]
Vector 11 [_TerrainTreeLightColors2]
"!!ARBvp1.0
# 16 ALU
PARAM c[12] = { { 1 },
		state.lightmodel.ambient,
		state.matrix.mvp,
		program.local[6..11] };
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
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[5];
DP4 result.position.z, vertex.position, c[4];
DP4 result.position.y, vertex.position, c[3];
DP4 result.position.x, vertex.position, c[2];
MOV result.color.w, c[0].x;
END
# 16 instructions, 3 R-regs
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
"vs_2_0
; 16 ALU
def c11, 1.00000000, 0, 0, 0
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
mov oT0.xy, v2
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
mov oD0.w, c11.x
"
}
}
  SetTexture [_MainTex] { combine texture * primary double, primary alpha }
 }
}
Fallback Off
}