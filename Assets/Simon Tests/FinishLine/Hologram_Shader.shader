// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4855,x:32893,y:32719,varname:node_4855,prsc:2|emission-7738-OUT,alpha-7884-OUT;n:type:ShaderForge.SFN_Add,id:7315,x:31172,y:33118,varname:node_7315,prsc:2|A-5646-OUT,B-8642-OUT;n:type:ShaderForge.SFN_Vector1,id:6315,x:30441,y:33014,varname:node_6315,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2910,x:30441,y:33072,varname:node_2910,prsc:2,v1:1;n:type:ShaderForge.SFN_Append,id:2234,x:30620,y:33032,varname:node_2234,prsc:2|A-6315-OUT,B-2910-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:1510,x:30472,y:32777,varname:node_1510,prsc:2;n:type:ShaderForge.SFN_Append,id:4014,x:30705,y:32810,varname:node_4014,prsc:2|A-1510-Y,B-1510-X;n:type:ShaderForge.SFN_Multiply,id:5646,x:30942,y:33044,varname:node_5646,prsc:2|A-4014-OUT,B-2234-OUT;n:type:ShaderForge.SFN_Vector1,id:5003,x:30499,y:33189,varname:node_5003,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7352,x:30499,y:33242,varname:node_7352,prsc:2,v1:3;n:type:ShaderForge.SFN_Append,id:7742,x:30708,y:33189,varname:node_7742,prsc:2|A-5003-OUT,B-7352-OUT;n:type:ShaderForge.SFN_Time,id:7601,x:30708,y:33344,varname:node_7601,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8642,x:30942,y:33200,varname:node_8642,prsc:2|A-7742-OUT,B-7601-T;n:type:ShaderForge.SFN_OneMinus,id:8441,x:31343,y:33118,varname:node_8441,prsc:2|IN-7315-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8202,x:31504,y:33118,varname:node_8202,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-8441-OUT;n:type:ShaderForge.SFN_Frac,id:5704,x:31696,y:33045,varname:node_5704,prsc:2|IN-8202-OUT;n:type:ShaderForge.SFN_Vector1,id:6104,x:31677,y:33379,cmnt:Scanline Exp,varname:node_6104,prsc:2,v1:10;n:type:ShaderForge.SFN_Power,id:3652,x:31860,y:33122,varname:node_3652,prsc:2|VAL-5704-OUT,EXP-4020-OUT;n:type:ShaderForge.SFN_Multiply,id:7125,x:32190,y:32918,varname:node_7125,prsc:2|A-3652-OUT,B-3708-OUT;n:type:ShaderForge.SFN_Slider,id:3708,x:32062,y:33146,ptovrint:False,ptlb:Scanline Opacity,ptin:_ScanlineOpacity,varname:node_3708,prsc:2,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Add,id:7884,x:32473,y:33054,varname:node_7884,prsc:2|A-7125-OUT,B-7193-OUT;n:type:ShaderForge.SFN_Slider,id:7193,x:32107,y:33272,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_7193,prsc:2,min:0,cur:0.6310679,max:1;n:type:ShaderForge.SFN_ScreenPos,id:8185,x:31074,y:32573,varname:node_8185,prsc:2,sctp:0;n:type:ShaderForge.SFN_Time,id:4715,x:31103,y:32732,varname:node_4715,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7438,x:31271,y:32692,varname:node_7438,prsc:2|A-8185-UVOUT,B-4715-TSL;n:type:ShaderForge.SFN_Noise,id:3822,x:31408,y:32845,varname:node_3822,prsc:2|XY-7438-OUT;n:type:ShaderForge.SFN_RemapRange,id:1330,x:31571,y:32693,varname:node_1330,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3822-OUT;n:type:ShaderForge.SFN_Multiply,id:965,x:31774,y:32710,varname:node_965,prsc:2|A-1330-OUT,B-2135-OUT;n:type:ShaderForge.SFN_Vector1,id:139,x:31504,y:33005,cmnt:Fuzzy Power,varname:node_139,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Lerp,id:839,x:31968,y:32631,varname:node_839,prsc:2|A-8475-OUT,B-965-OUT,T-2135-OUT;n:type:ShaderForge.SFN_Vector1,id:8475,x:31743,y:32604,varname:node_8475,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Slider,id:9972,x:31053,y:32450,ptovrint:False,ptlb:Desaturation Amount,ptin:_DesaturationAmount,varname:node_9972,prsc:2,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Desaturate,id:512,x:31443,y:32461,varname:node_512,prsc:2|COL-514-RGB,DES-9972-OUT;n:type:ShaderForge.SFN_Tex2d,id:514,x:31131,y:32238,ptovrint:False,ptlb:node_514,ptin:_node_514,varname:node_514,prsc:2,tex:0909523204fa5294d95c16a3dfdd0ce7,ntxv:1,isnm:False|UVIN-6418-OUT;n:type:ShaderForge.SFN_Multiply,id:8595,x:31649,y:32370,varname:node_8595,prsc:2|A-8781-RGB,B-512-OUT;n:type:ShaderForge.SFN_Color,id:8781,x:31415,y:32210,ptovrint:False,ptlb:node_8781,ptin:_node_8781,varname:node_8781,prsc:2,glob:False,c1:0,c2:0.9515719,c3:0.9926471,c4:1;n:type:ShaderForge.SFN_Multiply,id:3459,x:31991,y:32450,varname:node_3459,prsc:2|A-8595-OUT,B-839-OUT;n:type:ShaderForge.SFN_Multiply,id:1621,x:32322,y:32427,varname:node_1621,prsc:2|A-2559-OUT,B-3459-OUT;n:type:ShaderForge.SFN_Vector1,id:1053,x:32126,y:32219,cmnt:Brightness,varname:node_1053,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Add,id:6260,x:32547,y:32543,varname:node_6260,prsc:2|A-1621-OUT,B-7125-OUT;n:type:ShaderForge.SFN_Multiply,id:7738,x:32672,y:32802,varname:node_7738,prsc:2|A-6260-OUT,B-7884-OUT;n:type:ShaderForge.SFN_TexCoord,id:9478,x:30538,y:32026,varname:node_9478,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:3208,x:30339,y:32260,varname:node_3208,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3684,x:30538,y:32184,varname:node_3684,prsc:2|A-2027-OUT,B-3208-TSL;n:type:ShaderForge.SFN_Append,id:2027,x:30339,y:32110,varname:node_2027,prsc:2|A-1455-OUT,B-2452-OUT;n:type:ShaderForge.SFN_Vector1,id:6520,x:30093,y:31947,cmnt:U Speed,varname:node_6520,prsc:2,v1:5;n:type:ShaderForge.SFN_Vector1,id:2126,x:30090,y:32313,cmnt:V Speed,varname:node_2126,prsc:2,v1:0;n:type:ShaderForge.SFN_Add,id:6418,x:30753,y:32149,varname:node_6418,prsc:2|A-9478-UVOUT,B-3684-OUT;n:type:ShaderForge.SFN_Slider,id:1455,x:29997,y:32069,ptovrint:False,ptlb:Left - right Speed,ptin:_LeftrightSpeed,varname:node_1455,prsc:2,min:-10,cur:0,max:10;n:type:ShaderForge.SFN_Slider,id:2452,x:29997,y:32187,ptovrint:False,ptlb:node_2452,ptin:_node_2452,varname:node_2452,prsc:2,min:-10,cur:0,max:10;n:type:ShaderForge.SFN_Slider,id:4020,x:31578,y:33286,ptovrint:False,ptlb:Scanline exp,ptin:_Scanlineexp,varname:node_4020,prsc:2,min:0,cur:10,max:10;n:type:ShaderForge.SFN_Slider,id:2135,x:31652,y:32955,ptovrint:False,ptlb:Fuzzy Power (noise),ptin:_FuzzyPowernoise,varname:node_2135,prsc:2,min:-2,cur:0.5,max:2;n:type:ShaderForge.SFN_Slider,id:2559,x:31969,y:32306,ptovrint:False,ptlb:node_2559,ptin:_node_2559,varname:node_2559,prsc:2,min:-10,cur:1.5,max:10;proporder:3708-7193-9972-514-8781-1455-2452-4020-2135-2559;pass:END;sub:END;*/

Shader "Shader Forge/Hologram_Shader" {
    Properties {
        _ScanlineOpacity ("Scanline Opacity", Range(0, 1)) = 0.5
        _Opacity ("Opacity", Range(0, 1)) = 0.6310679
        _DesaturationAmount ("Desaturation Amount", Range(0, 1)) = 1
        _node_514 ("node_514", 2D) = "gray" {}
        _node_8781 ("node_8781", Color) = (0,0.9515719,0.9926471,1)
        _LeftrightSpeed ("Left - right Speed", Range(-10, 10)) = 0
        _node_2452 ("node_2452", Range(-10, 10)) = 0
        _Scanlineexp ("Scanline exp", Range(0, 10)) = 10
        _FuzzyPowernoise ("Fuzzy Power (noise)", Range(-2, 2)) = 0.5
        _node_2559 ("node_2559", Range(-10, 10)) = 1.5
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _ScanlineOpacity;
            uniform float _Opacity;
            uniform float _DesaturationAmount;
            uniform sampler2D _node_514; uniform float4 _node_514_ST;
            uniform float4 _node_8781;
            uniform float _LeftrightSpeed;
            uniform float _node_2452;
            uniform float _Scanlineexp;
            uniform float _FuzzyPowernoise;
            uniform float _node_2559;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 node_3208 = _Time + _TimeEditor;
                float2 node_6418 = (i.uv0+(float2(_LeftrightSpeed,_node_2452)*node_3208.r));
                float4 _node_514_var = tex2D(_node_514,TRANSFORM_TEX(node_6418, _node_514));
                float4 node_4715 = _Time + _TimeEditor;
                float2 node_7438 = (i.screenPos.rg*node_4715.r);
                float2 node_3822_skew = node_7438 + 0.2127+node_7438.x*0.3713*node_7438.y;
                float2 node_3822_rnd = 4.789*sin(489.123*(node_3822_skew));
                float node_3822 = frac(node_3822_rnd.x*node_3822_rnd.y*(1+node_3822_skew.x));
                float4 node_7601 = _Time + _TimeEditor;
                float node_7125 = (pow(frac((1.0 - ((float2(i.posWorld.g,i.posWorld.r)*float2(1.0,1.0))+(float2(0.0,3.0)*node_7601.g))).g),_Scanlineexp)*_ScanlineOpacity);
                float node_7884 = (node_7125+_Opacity);
                float3 emissive = (((_node_2559*((_node_8781.rgb*lerp(_node_514_var.rgb,dot(_node_514_var.rgb,float3(0.3,0.59,0.11)),_DesaturationAmount))*lerp(0.5,((node_3822*2.0+-1.0)*_FuzzyPowernoise),_FuzzyPowernoise)))+node_7125)*node_7884);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,node_7884);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
