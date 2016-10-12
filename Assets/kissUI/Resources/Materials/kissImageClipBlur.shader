// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:1,spxs:False,tesm:0,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3214,x:33980,y:33863,varname:node_3214,prsc:2|emission-7644-OUT,custl-8451-OUT,clip-2203-OUT;n:type:ShaderForge.SFN_Tex2d,id:2322,x:32541,y:33468,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1b196e9db5dfe044ea3b78200ba27a8a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:7689,x:32715,y:33612,varname:node_7689,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3694,x:33072,y:33468,varname:node_3694,prsc:2|A-2928-OUT,B-7689-RGB;n:type:ShaderForge.SFN_TexCoord,id:9412,x:31827,y:33877,varname:node_9412,prsc:2,uv:1;n:type:ShaderForge.SFN_TexCoord,id:4539,x:31686,y:34218,varname:node_4539,prsc:2,uv:2;n:type:ShaderForge.SFN_If,id:3654,x:32181,y:33897,varname:node_3654,prsc:2|A-9412-U,B-3923-OUT,GT-28-OUT,EQ-28-OUT,LT-3923-OUT;n:type:ShaderForge.SFN_Vector1,id:3923,x:31969,y:33983,varname:node_3923,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:28,x:31969,y:34035,varname:node_28,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:1405,x:31964,y:34149,varname:node_1405,prsc:2|IN-4539-V;n:type:ShaderForge.SFN_OneMinus,id:9975,x:31964,y:34386,varname:node_9975,prsc:2|IN-4539-U;n:type:ShaderForge.SFN_If,id:7322,x:32181,y:34020,varname:node_7322,prsc:2|A-9412-V,B-3923-OUT,GT-28-OUT,EQ-28-OUT,LT-3923-OUT;n:type:ShaderForge.SFN_Multiply,id:4717,x:32371,y:33960,varname:node_4717,prsc:2|A-3654-OUT,B-7322-OUT;n:type:ShaderForge.SFN_Vector1,id:3827,x:31962,y:34277,varname:node_3827,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:8622,x:31962,y:34329,varname:node_8622,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:2490,x:32182,y:34232,varname:node_2490,prsc:2|A-1405-OUT,B-3827-OUT,GT-8622-OUT,EQ-8622-OUT,LT-3827-OUT;n:type:ShaderForge.SFN_If,id:4922,x:32182,y:34372,varname:node_4922,prsc:2|A-9975-OUT,B-3827-OUT,GT-8622-OUT,EQ-8622-OUT,LT-3827-OUT;n:type:ShaderForge.SFN_Multiply,id:3749,x:32362,y:34297,varname:node_3749,prsc:2|A-2490-OUT,B-4922-OUT;n:type:ShaderForge.SFN_Multiply,id:5280,x:32585,y:34141,varname:node_5280,prsc:2|A-4717-OUT,B-3749-OUT;n:type:ShaderForge.SFN_Multiply,id:2203,x:33210,y:34107,varname:node_2203,prsc:2|A-3086-OUT,B-5280-OUT,C-8616-OUT;n:type:ShaderForge.SFN_Multiply,id:3086,x:32926,y:33657,varname:node_3086,prsc:2|A-2322-A,B-7689-A;n:type:ShaderForge.SFN_Desaturate,id:4476,x:32715,y:33468,varname:node_4476,prsc:2|COL-2322-RGB,DES-2708-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2238,x:32715,y:33407,ptovrint:False,ptlb:brightness,ptin:_brightness,varname:_brightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:2708,x:32541,y:33387,ptovrint:False,ptlb:desaturate,ptin:_desaturate,varname:_desaturate,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:2928,x:32894,y:33468,varname:node_2928,prsc:2|A-4476-OUT,B-2238-OUT;n:type:ShaderForge.SFN_TexCoord,id:8455,x:31250,y:35015,varname:node_8455,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:1154,x:31629,y:35015,varname:node_1154,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-1237-UVOUT;n:type:ShaderForge.SFN_Length,id:3960,x:31801,y:35015,varname:node_3960,prsc:2|IN-1154-OUT;n:type:ShaderForge.SFN_Floor,id:2644,x:32260,y:35017,varname:node_2644,prsc:2|IN-4366-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4942,x:32001,y:35177,ptovrint:False,ptlb:CircleInner,ptin:_CircleInner,varname:node_4942,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:528,x:32260,y:35163,varname:node_528,prsc:2|A-3960-OUT,B-4942-OUT;n:type:ShaderForge.SFN_Floor,id:9185,x:32434,y:35163,varname:node_9185,prsc:2|IN-528-OUT;n:type:ShaderForge.SFN_OneMinus,id:5777,x:32434,y:35017,varname:node_5777,prsc:2|IN-2644-OUT;n:type:ShaderForge.SFN_Multiply,id:910,x:32629,y:35017,varname:node_910,prsc:2|A-5777-OUT,B-9185-OUT;n:type:ShaderForge.SFN_ArcTan2,id:4685,x:31998,y:34748,varname:node_4685,prsc:2|A-6550-G,B-6550-R;n:type:ShaderForge.SFN_ComponentMask,id:6550,x:31805,y:34748,varname:node_6550,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1154-OUT;n:type:ShaderForge.SFN_Slider,id:2108,x:32001,y:34926,ptovrint:False,ptlb:CircleSlider,ptin:_CircleSlider,varname:node_2108,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Ceil,id:5755,x:32511,y:34748,varname:node_5755,prsc:2|IN-6845-OUT;n:type:ShaderForge.SFN_RemapRange,id:4929,x:32155,y:34748,varname:node_4929,prsc:2,frmn:-3.141593,frmx:3.141593,tomn:0,tomx:1|IN-4685-OUT;n:type:ShaderForge.SFN_Subtract,id:6845,x:32335,y:34748,varname:node_6845,prsc:2|A-6773-OUT,B-2108-OUT;n:type:ShaderForge.SFN_OneMinus,id:2793,x:32676,y:34748,varname:node_2793,prsc:2|IN-5755-OUT;n:type:ShaderForge.SFN_Multiply,id:8995,x:32848,y:35008,varname:node_8995,prsc:2|A-2793-OUT,B-9185-OUT,C-910-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8265,x:31801,y:35177,ptovrint:False,ptlb:CircleOuter,ptin:_CircleOuter,varname:_CircleWidth_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-35;n:type:ShaderForge.SFN_Add,id:4366,x:32001,y:35015,varname:node_4366,prsc:2|A-3960-OUT,B-8265-OUT;n:type:ShaderForge.SFN_OneMinus,id:6773,x:32155,y:34616,varname:node_6773,prsc:2|IN-4929-OUT;n:type:ShaderForge.SFN_Rotator,id:1237,x:31452,y:35015,varname:node_1237,prsc:2|UVIN-8455-UVOUT,ANG-6105-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6105,x:31250,y:35192,ptovrint:False,ptlb:CircleRotate,ptin:_CircleRotate,varname:node_6105,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3.141593;n:type:ShaderForge.SFN_Clamp01,id:8616,x:32848,y:34862,varname:node_8616,prsc:2|IN-8995-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4274,x:31974,y:31867,ptovrint:False,ptlb:blurriness,ptin:_blurriness,varname:node_4274,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_ScreenPos,id:4292,x:31974,y:31700,varname:node_4292,prsc:2,sctp:2;n:type:ShaderForge.SFN_Add,id:8107,x:32225,y:31703,varname:node_8107,prsc:2|A-4292-U,B-4274-OUT;n:type:ShaderForge.SFN_Append,id:5369,x:32438,y:31703,varname:node_5369,prsc:2|A-8107-OUT,B-414-OUT;n:type:ShaderForge.SFN_SceneColor,id:8132,x:32622,y:31703,varname:node_8132,prsc:2|UVIN-5369-OUT;n:type:ShaderForge.SFN_Vector3,id:9874,x:33072,y:33354,varname:node_9874,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_If,id:8451,x:33503,y:33241,varname:node_8451,prsc:2|A-4274-OUT,B-4234-OUT,GT-9553-OUT,EQ-9874-OUT,LT-9553-OUT;n:type:ShaderForge.SFN_Vector1,id:4234,x:33072,y:33294,varname:node_4234,prsc:2,v1:0;n:type:ShaderForge.SFN_If,id:7644,x:33503,y:33466,varname:node_7644,prsc:2|A-4274-OUT,B-4234-OUT,GT-9874-OUT,EQ-3694-OUT,LT-9874-OUT;n:type:ShaderForge.SFN_Add,id:414,x:32225,y:31837,varname:node_414,prsc:2|A-4292-V,B-4274-OUT;n:type:ShaderForge.SFN_Subtract,id:7427,x:32225,y:32013,varname:node_7427,prsc:2|A-4292-U,B-4274-OUT;n:type:ShaderForge.SFN_Append,id:6563,x:32432,y:32013,varname:node_6563,prsc:2|A-7427-OUT,B-25-OUT;n:type:ShaderForge.SFN_Subtract,id:25,x:32225,y:32140,varname:node_25,prsc:2|A-4292-V,B-4274-OUT;n:type:ShaderForge.SFN_SceneColor,id:4232,x:32617,y:32013,varname:node_4232,prsc:2|UVIN-6563-OUT;n:type:ShaderForge.SFN_Add,id:4612,x:32828,y:31823,varname:node_4612,prsc:2|A-8132-RGB,B-4232-RGB;n:type:ShaderForge.SFN_Divide,id:9553,x:33196,y:32232,varname:node_9553,prsc:2|A-2337-OUT,B-7577-OUT;n:type:ShaderForge.SFN_Vector1,id:7577,x:33016,y:32309,varname:node_7577,prsc:2,v1:4;n:type:ShaderForge.SFN_Add,id:5038,x:32224,y:32289,varname:node_5038,prsc:2|A-4292-U,B-4274-OUT;n:type:ShaderForge.SFN_Append,id:5018,x:32437,y:32289,varname:node_5018,prsc:2|A-5038-OUT,B-1985-OUT;n:type:ShaderForge.SFN_SceneColor,id:582,x:32621,y:32289,varname:node_582,prsc:2|UVIN-5018-OUT;n:type:ShaderForge.SFN_Subtract,id:6822,x:32224,y:32599,varname:node_6822,prsc:2|A-4292-U,B-4274-OUT;n:type:ShaderForge.SFN_Append,id:7268,x:32431,y:32599,varname:node_7268,prsc:2|A-6822-OUT,B-4554-OUT;n:type:ShaderForge.SFN_SceneColor,id:5999,x:32616,y:32599,varname:node_5999,prsc:2|UVIN-7268-OUT;n:type:ShaderForge.SFN_Subtract,id:1985,x:32224,y:32417,varname:node_1985,prsc:2|A-4292-V,B-4274-OUT;n:type:ShaderForge.SFN_Add,id:4554,x:32224,y:32731,varname:node_4554,prsc:2|A-4292-V,B-4274-OUT;n:type:ShaderForge.SFN_Add,id:6027,x:32828,y:32483,varname:node_6027,prsc:2|A-582-RGB,B-5999-RGB;n:type:ShaderForge.SFN_Add,id:2337,x:33016,y:32191,varname:node_2337,prsc:2|A-4612-OUT,B-6027-OUT;proporder:2322-2708-2238-8265-4942-2108-6105-4274;pass:END;sub:END;*/

Shader "kissUI/kissImageClipBlur" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _desaturate ("desaturate", Float ) = 0
        _brightness ("brightness", Float ) = 0
        _CircleOuter ("CircleOuter", Float ) = -35
        _CircleInner ("CircleInner", Float ) = 1
        _CircleSlider ("CircleSlider", Range(0, 1)) = 1
        _CircleRotate ("CircleRotate", Float ) = 3.141593
        _blurriness ("blurriness", Float ) = 0.2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        LOD 200
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _brightness;
            uniform float _desaturate;
            uniform float _CircleInner;
            uniform float _CircleSlider;
            uniform float _CircleOuter;
            uniform float _CircleRotate;
            uniform float _blurriness;
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
                float4 screenPos : TEXCOORD3;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
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
                float node_1237_ang = _CircleRotate;
                float node_1237_spd = 1.0;
                float node_1237_cos = cos(node_1237_spd*node_1237_ang);
                float node_1237_sin = sin(node_1237_spd*node_1237_ang);
                float2 node_1237_piv = float2(0.5,0.5);
                float2 node_1237 = (mul(i.uv0-node_1237_piv,float2x2( node_1237_cos, -node_1237_sin, node_1237_sin, node_1237_cos))+node_1237_piv);
                float2 node_1154 = (node_1237*2.0+-1.0);
                float2 node_6550 = node_1154.rg;
                float node_3960 = length(node_1154);
                float node_9185 = floor((node_3960+_CircleInner));
                clip(((_MainTex_var.a*i.vertexColor.a)*((lerp((node_3654_if_leA*node_3923)+(node_3654_if_leB*node_28),node_28,node_3654_if_leA*node_3654_if_leB)*lerp((node_7322_if_leA*node_3923)+(node_7322_if_leB*node_28),node_28,node_7322_if_leA*node_7322_if_leB))*(lerp((node_2490_if_leA*node_3827)+(node_2490_if_leB*node_8622),node_8622,node_2490_if_leA*node_2490_if_leB)*lerp((node_4922_if_leA*node_3827)+(node_4922_if_leB*node_8622),node_8622,node_4922_if_leA*node_4922_if_leB)))*saturate(((1.0 - ceil(((1.0 - (atan2(node_6550.g,node_6550.r)*0.1591549+0.5))-_CircleSlider)))*node_9185*((1.0 - floor((node_3960+_CircleOuter)))*node_9185)))) - 0.5);
////// Lighting:
////// Emissive:
                float node_4234 = 0.0;
                float node_7644_if_leA = step(_blurriness,node_4234);
                float node_7644_if_leB = step(node_4234,_blurriness);
                float3 node_9874 = float3(0,0,0);
                float3 emissive = lerp((node_7644_if_leA*node_9874)+(node_7644_if_leB*node_9874),((lerp(_MainTex_var.rgb,dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)),_desaturate)+_brightness)*i.vertexColor.rgb),node_7644_if_leA*node_7644_if_leB);
                float node_8451_if_leA = step(_blurriness,node_4234);
                float node_8451_if_leB = step(node_4234,_blurriness);
                float3 node_9553 = (((tex2D( _GrabTexture, float2((sceneUVs.r+_blurriness),(sceneUVs.g+_blurriness))).rgb+tex2D( _GrabTexture, float2((sceneUVs.r-_blurriness),(sceneUVs.g-_blurriness))).rgb)+(tex2D( _GrabTexture, float2((sceneUVs.r+_blurriness),(sceneUVs.g-_blurriness))).rgb+tex2D( _GrabTexture, float2((sceneUVs.r-_blurriness),(sceneUVs.g+_blurriness))).rgb))/4.0);
                float3 finalColor = emissive + lerp((node_8451_if_leA*node_9553)+(node_8451_if_leB*node_9553),node_9874,node_8451_if_leA*node_8451_if_leB);
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
            uniform float _CircleInner;
            uniform float _CircleSlider;
            uniform float _CircleOuter;
            uniform float _CircleRotate;
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
                float node_1237_ang = _CircleRotate;
                float node_1237_spd = 1.0;
                float node_1237_cos = cos(node_1237_spd*node_1237_ang);
                float node_1237_sin = sin(node_1237_spd*node_1237_ang);
                float2 node_1237_piv = float2(0.5,0.5);
                float2 node_1237 = (mul(i.uv0-node_1237_piv,float2x2( node_1237_cos, -node_1237_sin, node_1237_sin, node_1237_cos))+node_1237_piv);
                float2 node_1154 = (node_1237*2.0+-1.0);
                float2 node_6550 = node_1154.rg;
                float node_3960 = length(node_1154);
                float node_9185 = floor((node_3960+_CircleInner));
                clip(((_MainTex_var.a*i.vertexColor.a)*((lerp((node_3654_if_leA*node_3923)+(node_3654_if_leB*node_28),node_28,node_3654_if_leA*node_3654_if_leB)*lerp((node_7322_if_leA*node_3923)+(node_7322_if_leB*node_28),node_28,node_7322_if_leA*node_7322_if_leB))*(lerp((node_2490_if_leA*node_3827)+(node_2490_if_leB*node_8622),node_8622,node_2490_if_leA*node_2490_if_leB)*lerp((node_4922_if_leA*node_3827)+(node_4922_if_leB*node_8622),node_8622,node_4922_if_leA*node_4922_if_leB)))*saturate(((1.0 - ceil(((1.0 - (atan2(node_6550.g,node_6550.r)*0.1591549+0.5))-_CircleSlider)))*node_9185*((1.0 - floor((node_3960+_CircleOuter)))*node_9185)))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    //CustomEditor "ShaderForgeMaterialInspector"
}
