// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:1,spxs:False,tesm:0,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3214,x:33980,y:33863,varname:node_3214,prsc:2|emission-3694-OUT,clip-2203-OUT;n:type:ShaderForge.SFN_Tex2d,id:2322,x:32541,y:33468,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1b196e9db5dfe044ea3b78200ba27a8a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:7689,x:32715,y:33612,varname:node_7689,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3694,x:33072,y:33468,varname:node_3694,prsc:2|A-2928-OUT,B-7689-RGB;n:type:ShaderForge.SFN_TexCoord,id:9412,x:31827,y:33877,varname:node_9412,prsc:2,uv:1;n:type:ShaderForge.SFN_TexCoord,id:4539,x:31686,y:34218,varname:node_4539,prsc:2,uv:2;n:type:ShaderForge.SFN_If,id:3654,x:32181,y:33897,varname:node_3654,prsc:2|A-9412-U,B-3923-OUT,GT-28-OUT,EQ-28-OUT,LT-3923-OUT;n:type:ShaderForge.SFN_Vector1,id:3923,x:31969,y:33983,varname:node_3923,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:28,x:31969,y:34035,varname:node_28,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:1405,x:31964,y:34149,varname:node_1405,prsc:2|IN-4539-V;n:type:ShaderForge.SFN_OneMinus,id:9975,x:31964,y:34386,varname:node_9975,prsc:2|IN-4539-U;n:type:ShaderForge.SFN_If,id:7322,x:32181,y:34020,varname:node_7322,prsc:2|A-9412-V,B-3923-OUT,GT-28-OUT,EQ-28-OUT,LT-3923-OUT;n:type:ShaderForge.SFN_Multiply,id:4717,x:32371,y:33960,varname:node_4717,prsc:2|A-3654-OUT,B-7322-OUT;n:type:ShaderForge.SFN_Vector1,id:3827,x:31962,y:34277,varname:node_3827,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:8622,x:31962,y:34329,varname:node_8622,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:2490,x:32182,y:34232,varname:node_2490,prsc:2|A-1405-OUT,B-3827-OUT,GT-8622-OUT,EQ-8622-OUT,LT-3827-OUT;n:type:ShaderForge.SFN_If,id:4922,x:32182,y:34372,varname:node_4922,prsc:2|A-9975-OUT,B-3827-OUT,GT-8622-OUT,EQ-8622-OUT,LT-3827-OUT;n:type:ShaderForge.SFN_Multiply,id:3749,x:32362,y:34297,varname:node_3749,prsc:2|A-2490-OUT,B-4922-OUT;n:type:ShaderForge.SFN_Multiply,id:5280,x:32585,y:34141,varname:node_5280,prsc:2|A-4717-OUT,B-3749-OUT;n:type:ShaderForge.SFN_Multiply,id:2203,x:33210,y:34107,varname:node_2203,prsc:2|A-3086-OUT,B-5280-OUT;n:type:ShaderForge.SFN_Multiply,id:3086,x:32926,y:33657,varname:node_3086,prsc:2|A-2322-A,B-7689-A;n:type:ShaderForge.SFN_Desaturate,id:4476,x:32715,y:33468,varname:node_4476,prsc:2|COL-2322-RGB,DES-2708-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2238,x:32715,y:33407,ptovrint:False,ptlb:brightness,ptin:_brightness,varname:_brightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:2708,x:32541,y:33387,ptovrint:False,ptlb:desaturate,ptin:_desaturate,varname:_desaturate,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:2928,x:32894,y:33468,varname:node_2928,prsc:2|A-4476-OUT,B-2238-OUT;proporder:2322-2708-2238;pass:END;sub:END;*/

Shader "kissUI/kissImageClip" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _desaturate ("desaturate", Float ) = 0
        _brightness ("brightness", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _brightness;
            uniform float _desaturate;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_3923 = 0.0;
                float node_3654_if_leA = step(i.uv1.r,node_3923);
                float node_3654_if_leB = step(node_3923,i.uv1.r);
                float node_28 = 1.0;
                float node_7322_if_leA = step(i.uv1.g,node_3923);
                float node_7322_if_leB = step(node_3923,i.uv1.g);
                float node_3827 = 0.0;
                float node_2490_if_leA = step((1.0 - i.uv2.g),node_3827);
                float node_2490_if_leB = step(node_3827,(1.0 - i.uv2.g));
                float node_8622 = 1.0;
                float node_4922_if_leA = step((1.0 - i.uv2.r),node_3827);
                float node_4922_if_leB = step(node_3827,(1.0 - i.uv2.r));
                clip(((_MainTex_var.a*i.vertexColor.a)*((lerp((node_3654_if_leA*node_3923)+(node_3654_if_leB*node_28),node_28,node_3654_if_leA*node_3654_if_leB)*lerp((node_7322_if_leA*node_3923)+(node_7322_if_leB*node_28),node_28,node_7322_if_leA*node_7322_if_leB))*(lerp((node_2490_if_leA*node_3827)+(node_2490_if_leB*node_8622),node_8622,node_2490_if_leA*node_2490_if_leB)*lerp((node_4922_if_leA*node_3827)+(node_4922_if_leB*node_8622),node_8622,node_4922_if_leA*node_4922_if_leB)))) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = ((lerp(_MainTex_var.rgb,dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)),_desaturate)+_brightness)*i.vertexColor.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_3923 = 0.0;
                float node_3654_if_leA = step(i.uv1.r,node_3923);
                float node_3654_if_leB = step(node_3923,i.uv1.r);
                float node_28 = 1.0;
                float node_7322_if_leA = step(i.uv1.g,node_3923);
                float node_7322_if_leB = step(node_3923,i.uv1.g);
                float node_3827 = 0.0;
                float node_2490_if_leA = step((1.0 - i.uv2.g),node_3827);
                float node_2490_if_leB = step(node_3827,(1.0 - i.uv2.g));
                float node_8622 = 1.0;
                float node_4922_if_leA = step((1.0 - i.uv2.r),node_3827);
                float node_4922_if_leB = step(node_3827,(1.0 - i.uv2.r));
                clip(((_MainTex_var.a*i.vertexColor.a)*((lerp((node_3654_if_leA*node_3923)+(node_3654_if_leB*node_28),node_28,node_3654_if_leA*node_3654_if_leB)*lerp((node_7322_if_leA*node_3923)+(node_7322_if_leB*node_28),node_28,node_7322_if_leA*node_7322_if_leB))*(lerp((node_2490_if_leA*node_3827)+(node_2490_if_leB*node_8622),node_8622,node_2490_if_leA*node_2490_if_leB)*lerp((node_4922_if_leA*node_3827)+(node_4922_if_leB*node_8622),node_8622,node_4922_if_leA*node_4922_if_leB)))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    //CustomEditor "ShaderForgeMaterialInspector"
}
