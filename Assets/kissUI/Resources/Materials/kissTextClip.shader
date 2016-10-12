// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:6953,x:34316,y:32997,varname:node_6953,prsc:2|emission-3250-OUT,clip-7225-OUT;n:type:ShaderForge.SFN_Tex2d,id:7312,x:30959,y:33132,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_7312,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e22f4bf23c4d53a4d8653ef8c56f6ad0,ntxv:0,isnm:False|UVIN-35-UVOUT;n:type:ShaderForge.SFN_Multiply,id:6864,x:33394,y:33281,varname:node_6864,prsc:2|A-368-OUT,B-675-OUT;n:type:ShaderForge.SFN_Multiply,id:803,x:32072,y:32937,cmnt:fill,varname:node_803,prsc:2|A-4435-OUT,B-2533-R;n:type:ShaderForge.SFN_Multiply,id:5377,x:32072,y:33080,cmnt:out,varname:node_5377,prsc:2|A-5333-OUT,B-2533-G;n:type:ShaderForge.SFN_Multiply,id:7037,x:32072,y:33218,cmnt:drop,varname:node_7037,prsc:2|A-3764-OUT,B-2533-B;n:type:ShaderForge.SFN_Tex2d,id:6717,x:32468,y:32763,ptovrint:False,ptlb:FillTex,ptin:_FillTex,varname:node_6717,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-1051-UVOUT;n:type:ShaderForge.SFN_Blend,id:6736,x:32680,y:32763,cmnt:fill tex,varname:node_6736,prsc:2,blmd:1,clmp:True|SRC-6717-RGB,DST-803-OUT;n:type:ShaderForge.SFN_Add,id:6608,x:32285,y:32954,cmnt:rg,varname:node_6608,prsc:2|A-803-OUT,B-5377-OUT;n:type:ShaderForge.SFN_Lerp,id:2392,x:33599,y:33012,cmnt:fill w tex,varname:node_2392,prsc:2|A-3045-OUT,B-6736-OUT,T-7766-OUT;n:type:ShaderForge.SFN_VertexColor,id:4344,x:32475,y:32466,varname:node_4344,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:35,x:30774,y:33132,varname:node_35,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:1051,x:32285,y:32763,varname:node_1051,prsc:2,uv:3;n:type:ShaderForge.SFN_Append,id:4235,x:32674,y:32466,varname:node_4235,prsc:2|A-4344-R,B-4344-G,C-4344-B;n:type:ShaderForge.SFN_Relay,id:368,x:32739,y:33389,cmnt:a,varname:node_368,prsc:2|IN-7312-A;n:type:ShaderForge.SFN_Add,id:7590,x:32285,y:33091,cmnt:rgb,varname:node_7590,prsc:2|A-803-OUT,B-5377-OUT,C-7037-OUT;n:type:ShaderForge.SFN_Multiply,id:2615,x:33599,y:33475,varname:node_2615,prsc:2|A-6864-OUT,B-7590-OUT;n:type:ShaderForge.SFN_Multiply,id:3045,x:33257,y:32740,cmnt:fillout,varname:node_3045,prsc:2|A-4235-OUT,B-6608-OUT;n:type:ShaderForge.SFN_Multiply,id:6338,x:33599,y:33154,cmnt:ds out,varname:node_6338,prsc:2|A-384-OUT,B-4235-OUT;n:type:ShaderForge.SFN_OneMinus,id:24,x:33599,y:33281,varname:node_24,prsc:2|IN-6864-OUT;n:type:ShaderForge.SFN_Lerp,id:3250,x:33856,y:33014,varname:node_3250,prsc:2|A-2392-OUT,B-6338-OUT,T-24-OUT;n:type:ShaderForge.SFN_Add,id:384,x:32285,y:33228,cmnt:gb,varname:node_384,prsc:2|A-7037-OUT,B-5377-OUT;n:type:ShaderForge.SFN_Blend,id:7766,x:32680,y:32932,varname:node_7766,prsc:2,blmd:1,clmp:True|SRC-803-OUT,DST-6717-A;n:type:ShaderForge.SFN_Relay,id:675,x:32733,y:32599,varname:node_675,prsc:2|IN-4344-A;n:type:ShaderForge.SFN_TexCoord,id:629,x:32875,y:33678,varname:node_629,prsc:2,uv:1;n:type:ShaderForge.SFN_TexCoord,id:8074,x:32736,y:34009,varname:node_8074,prsc:2,uv:2;n:type:ShaderForge.SFN_If,id:1966,x:33229,y:33698,varname:node_1966,prsc:2|A-629-U,B-8798-OUT,GT-4202-OUT,EQ-4202-OUT,LT-8798-OUT;n:type:ShaderForge.SFN_Vector1,id:8798,x:33017,y:33784,varname:node_8798,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:4202,x:33017,y:33836,varname:node_4202,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:3814,x:33014,y:33940,varname:node_3814,prsc:2|IN-8074-V;n:type:ShaderForge.SFN_OneMinus,id:1578,x:33014,y:34177,varname:node_1578,prsc:2|IN-8074-U;n:type:ShaderForge.SFN_If,id:4898,x:33229,y:33821,varname:node_4898,prsc:2|A-629-V,B-8798-OUT,GT-4202-OUT,EQ-4202-OUT,LT-8798-OUT;n:type:ShaderForge.SFN_Multiply,id:944,x:33419,y:33761,varname:node_944,prsc:2|A-1966-OUT,B-4898-OUT;n:type:ShaderForge.SFN_Vector1,id:6065,x:33012,y:34068,varname:node_6065,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:5503,x:33012,y:34120,varname:node_5503,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:5022,x:33232,y:34023,varname:node_5022,prsc:2|A-3814-OUT,B-6065-OUT,GT-5503-OUT,EQ-5503-OUT,LT-6065-OUT;n:type:ShaderForge.SFN_If,id:2807,x:33232,y:34163,varname:node_2807,prsc:2|A-1578-OUT,B-6065-OUT,GT-5503-OUT,EQ-5503-OUT,LT-6065-OUT;n:type:ShaderForge.SFN_Multiply,id:1760,x:33412,y:34088,varname:node_1760,prsc:2|A-5022-OUT,B-2807-OUT;n:type:ShaderForge.SFN_Multiply,id:2009,x:33595,y:33908,varname:node_2009,prsc:2|A-944-OUT,B-1760-OUT;n:type:ShaderForge.SFN_Multiply,id:7225,x:33854,y:33493,varname:node_7225,prsc:2|A-2615-OUT,B-2009-OUT;n:type:ShaderForge.SFN_Tangent,id:7932,x:31624,y:32936,varname:node_7932,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:2533,x:31798,y:32936,varname:node_2533,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-7932-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:7269,x:30773,y:33486,ptovrint:False,ptlb:MainTex_Invert,ptin:_MainTex_Invert,varname:node_7269,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_OneMinus,id:6868,x:31212,y:33280,varname:node_6868,prsc:2|IN-7312-R;n:type:ShaderForge.SFN_If,id:6144,x:31397,y:33280,varname:node_6144,prsc:2|A-7269-OUT,B-7281-OUT,GT-7312-R,EQ-6868-OUT,LT-7312-R;n:type:ShaderForge.SFN_Vector1,id:7281,x:30773,y:33554,varname:node_7281,prsc:2,v1:1;n:type:ShaderForge.SFN_Relay,id:4435,x:31798,y:33150,cmnt:red,varname:node_4435,prsc:2|IN-6144-OUT;n:type:ShaderForge.SFN_If,id:6666,x:31397,y:33411,varname:node_6666,prsc:2|A-7269-OUT,B-7281-OUT,GT-7312-G,EQ-2410-OUT,LT-7312-G;n:type:ShaderForge.SFN_OneMinus,id:2410,x:31212,y:33411,varname:node_2410,prsc:2|IN-7312-G;n:type:ShaderForge.SFN_Relay,id:5333,x:31798,y:33223,cmnt:green,varname:node_5333,prsc:2|IN-6666-OUT;n:type:ShaderForge.SFN_If,id:2206,x:31397,y:33561,varname:node_2206,prsc:2|A-7269-OUT,B-7281-OUT,GT-7312-B,EQ-7679-OUT,LT-7312-B;n:type:ShaderForge.SFN_OneMinus,id:7679,x:31212,y:33561,varname:node_7679,prsc:2|IN-7312-B;n:type:ShaderForge.SFN_Relay,id:3764,x:31798,y:33293,cmnt:blue,varname:node_3764,prsc:2|IN-2206-OUT;n:type:ShaderForge.SFN_NormalVector,id:4343,x:31624,y:32763,prsc:2,pt:False;proporder:7312-7269-6717;pass:END;sub:END;*/

Shader "kissUI/kissTextClip" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        [MaterialToggle] _MainTex_Invert ("MainTex_Invert", Float ) = 0
        _FillTex ("FillTex", 2D) = "black" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
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
            uniform sampler2D _FillTex; uniform float4 _FillTex_ST;
            uniform fixed _MainTex_Invert;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float2 texcoord3 : TEXCOORD3;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float2 uv3 : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.uv3 = v.texcoord3;
                o.vertexColor = v.vertexColor;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_6864 = (_MainTex_var.a*i.vertexColor.a);
                float node_7281 = 1.0;
                float node_6144_if_leA = step(_MainTex_Invert,node_7281);
                float node_6144_if_leB = step(node_7281,_MainTex_Invert);
                float3 node_2533 = i.tangentDir.rgb;
                float node_803 = (lerp((node_6144_if_leA*_MainTex_var.r)+(node_6144_if_leB*_MainTex_var.r),(1.0 - _MainTex_var.r),node_6144_if_leA*node_6144_if_leB)*node_2533.r); // fill
                float node_6666_if_leA = step(_MainTex_Invert,node_7281);
                float node_6666_if_leB = step(node_7281,_MainTex_Invert);
                float node_5377 = (lerp((node_6666_if_leA*_MainTex_var.g)+(node_6666_if_leB*_MainTex_var.g),(1.0 - _MainTex_var.g),node_6666_if_leA*node_6666_if_leB)*node_2533.g); // out
                float node_2206_if_leA = step(_MainTex_Invert,node_7281);
                float node_2206_if_leB = step(node_7281,_MainTex_Invert);
                float node_7037 = (lerp((node_2206_if_leA*_MainTex_var.b)+(node_2206_if_leB*_MainTex_var.b),(1.0 - _MainTex_var.b),node_2206_if_leA*node_2206_if_leB)*node_2533.b); // drop
                float node_8798 = 0.0;
                float node_1966_if_leA = step(i.uv1.r,node_8798);
                float node_1966_if_leB = step(node_8798,i.uv1.r);
                float node_4202 = 1.0;
                float node_4898_if_leA = step(i.uv1.g,node_8798);
                float node_4898_if_leB = step(node_8798,i.uv1.g);
                float node_6065 = 0.0;
                float node_5022_if_leA = step((1.0 - i.uv2.g),node_6065);
                float node_5022_if_leB = step(node_6065,(1.0 - i.uv2.g));
                float node_5503 = 1.0;
                float node_2807_if_leA = step((1.0 - i.uv2.r),node_6065);
                float node_2807_if_leB = step(node_6065,(1.0 - i.uv2.r));
                clip(((node_6864*(node_803+node_5377+node_7037))*((lerp((node_1966_if_leA*node_8798)+(node_1966_if_leB*node_4202),node_4202,node_1966_if_leA*node_1966_if_leB)*lerp((node_4898_if_leA*node_8798)+(node_4898_if_leB*node_4202),node_4202,node_4898_if_leA*node_4898_if_leB))*(lerp((node_5022_if_leA*node_6065)+(node_5022_if_leB*node_5503),node_5503,node_5022_if_leA*node_5022_if_leB)*lerp((node_2807_if_leA*node_6065)+(node_2807_if_leB*node_5503),node_5503,node_2807_if_leA*node_2807_if_leB)))) - 0.5);
////// Lighting:
////// Emissive:
                float3 node_4235 = float3(i.vertexColor.r,i.vertexColor.g,i.vertexColor.b);
                float4 _FillTex_var = tex2D(_FillTex,TRANSFORM_TEX(i.uv3, _FillTex));
                float3 emissive = lerp(lerp((node_4235*(node_803+node_5377)),saturate((_FillTex_var.rgb*node_803)),saturate((node_803*_FillTex_var.a))),((node_7037+node_5377)*node_4235),(1.0 - node_6864));
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
            uniform fixed _MainTex_Invert;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
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
                float3 tangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_6864 = (_MainTex_var.a*i.vertexColor.a);
                float node_7281 = 1.0;
                float node_6144_if_leA = step(_MainTex_Invert,node_7281);
                float node_6144_if_leB = step(node_7281,_MainTex_Invert);
                float3 node_2533 = i.tangentDir.rgb;
                float node_803 = (lerp((node_6144_if_leA*_MainTex_var.r)+(node_6144_if_leB*_MainTex_var.r),(1.0 - _MainTex_var.r),node_6144_if_leA*node_6144_if_leB)*node_2533.r); // fill
                float node_6666_if_leA = step(_MainTex_Invert,node_7281);
                float node_6666_if_leB = step(node_7281,_MainTex_Invert);
                float node_5377 = (lerp((node_6666_if_leA*_MainTex_var.g)+(node_6666_if_leB*_MainTex_var.g),(1.0 - _MainTex_var.g),node_6666_if_leA*node_6666_if_leB)*node_2533.g); // out
                float node_2206_if_leA = step(_MainTex_Invert,node_7281);
                float node_2206_if_leB = step(node_7281,_MainTex_Invert);
                float node_7037 = (lerp((node_2206_if_leA*_MainTex_var.b)+(node_2206_if_leB*_MainTex_var.b),(1.0 - _MainTex_var.b),node_2206_if_leA*node_2206_if_leB)*node_2533.b); // drop
                float node_8798 = 0.0;
                float node_1966_if_leA = step(i.uv1.r,node_8798);
                float node_1966_if_leB = step(node_8798,i.uv1.r);
                float node_4202 = 1.0;
                float node_4898_if_leA = step(i.uv1.g,node_8798);
                float node_4898_if_leB = step(node_8798,i.uv1.g);
                float node_6065 = 0.0;
                float node_5022_if_leA = step((1.0 - i.uv2.g),node_6065);
                float node_5022_if_leB = step(node_6065,(1.0 - i.uv2.g));
                float node_5503 = 1.0;
                float node_2807_if_leA = step((1.0 - i.uv2.r),node_6065);
                float node_2807_if_leB = step(node_6065,(1.0 - i.uv2.r));
                clip(((node_6864*(node_803+node_5377+node_7037))*((lerp((node_1966_if_leA*node_8798)+(node_1966_if_leB*node_4202),node_4202,node_1966_if_leA*node_1966_if_leB)*lerp((node_4898_if_leA*node_8798)+(node_4898_if_leB*node_4202),node_4202,node_4898_if_leA*node_4898_if_leB))*(lerp((node_5022_if_leA*node_6065)+(node_5022_if_leB*node_5503),node_5503,node_5022_if_leA*node_5022_if_leB)*lerp((node_2807_if_leA*node_6065)+(node_2807_if_leB*node_5503),node_5503,node_2807_if_leA*node_2807_if_leB)))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    //CustomEditor "ShaderForgeMaterialInspector"
}
