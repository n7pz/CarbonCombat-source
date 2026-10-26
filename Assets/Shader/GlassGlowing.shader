Shader "Transparent/GlassShiny" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _FColor ("Fallback Color", Color) = (1,1,1,1)
 _SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
 _Cube ("Reflection Cubemap", CUBE) = "_Skybox" { TexGen CubeNormal }
}
SubShader { 
 Tags { "QUEUE"="Transparent-140" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent-140" "RenderType"="Transparent" }
  ZWrite Off
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [unity_Scale]
Vector 14 [_WorldSpaceCameraPos]
"!!ARBvp1.0
# 16 ALU
PARAM c[15] = { { 1 },
		state.matrix.mvp,
		program.local[5..14] };
TEMP R0;
TEMP R1;
MOV R1.w, c[0].x;
MOV R1.xyz, c[14];
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MAD R0.xyz, R0, c[13].w, -vertex.position;
DP3 result.texcoord[1].z, R0, c[7];
DP3 result.texcoord[1].y, R0, c[6];
DP3 result.texcoord[1].x, R0, c[5];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP3 result.texcoord[0].z, vertex.normal, c[7];
DP3 result.texcoord[0].y, vertex.normal, c[6];
DP3 result.texcoord[0].x, vertex.normal, c[5];
END
# 16 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_Scale]
Vector 13 [_WorldSpaceCameraPos]
"vs_2_0
; 16 ALU
def c14, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
mov r1.w, c14.x
mov r1.xyz, c13
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mad r0.xyz, r0, c12.w, -v0
dp3 oT1.z, r0, c6
dp3 oT1.y, r0, c5
dp3 oT1.x, r0, c4
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp3 oT0.z, v1, c6
dp3 oT0.y, v1, c5
dp3 oT0.x, v1, c4
"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 0 [_Color]
Vector 1 [_SpecColor]
SetTexture 0 [_Cube] CUBE
"!!ARBfp1.0
OPTION ARB_fog_exp2;
OPTION ARB_precision_hint_fastest;
# 13 ALU, 1 TEX
PARAM c[3] = { program.local[0..1],
		{ 0.89999998, 2, 0.89990234, 0.5 } };
TEMP R0;
TEMP R1;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.x, R0.x;
MUL R1.xyz, R0.x, fragment.texcoord[1];
DP3 R0.x, fragment.texcoord[0], -R1;
MUL R0.xyz, fragment.texcoord[0], R0.x;
MAD R0.xyz, -R0, c[2].y, -R1;
DP3_SAT R0.w, fragment.texcoord[0], R1;
MAD result.color.w, -R0, c[2], c[2].z;
TEX R0.xyz, R0, texture[0], CUBE;
ADD R0.xyz, R0, c[1];
ADD R0.xyz, R0, -c[0];
MUL R0.xyz, R0, c[2].x;
ADD result.color.xyz, R0, c[0];
END
# 13 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_Color]
Vector 1 [_SpecColor]
SetTexture 0 [_Cube] CUBE
"ps_2_0
; 13 ALU, 1 TEX
dcl_cube s0
def c2, 2.00000000, 0.89999998, 0.50000000, 0.89990234
dcl t0.xyz
dcl t1.xyz
dp3 r0.x, t1, t1
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
dp3 r1.x, t0, -r0
mul r1.xyz, t0, r1.x
mad r1.xyz, -r1, c2.x, -r0
dp3_sat r0.x, t0, r0
mad_pp r0.w, -r0.x, c2.z, c2
texld r1, r1, s0
add r1.xyz, r1, c1
add r1.xyz, r1, -c0
mul r1.xyz, r1, c2.y
add r0.xyz, r1, c0
mov_pp oC0, r0
"
}
}
  SetTexture [_Cube] { combine texture }
 }
}
SubShader { 
 Tags { "QUEUE"="Transparent-140" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent-140" "RenderType"="Transparent" }
  Color [_FColor]
  ZWrite Off
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
 }
}
}