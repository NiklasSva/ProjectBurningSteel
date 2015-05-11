// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:0,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:8318,x:32842,y:32743,varname:node_8318,prsc:2|diff-4847-RGB,spec-2774-RGB,gloss-530-OUT,normal-4199-RGB,lwrap-9099-RGB;n:type:ShaderForge.SFN_Tex2d,id:4847,x:32403,y:32622,ptovrint:False,ptlb:Diffuse Beast 1,ptin:_DiffuseBeast1,varname:node_4847,prsc:2,tex:e1e35a92664c53a45857e93f305c68b4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1680,x:32221,y:33046,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_1680,prsc:2,tex:5c7579de3ed3dbe4cb554631b9f3aab6,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:8926,x:32553,y:32530,varname:node_8926,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:8776,x:32789,y:32530,varname:node_8776,prsc:2|A-8926-OUT;n:type:ShaderForge.SFN_Tex2d,id:4199,x:32591,y:33010,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_4199,prsc:2,tex:c34b17e782ea5694cb6fb9acde342207,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2774,x:32239,y:32818,ptovrint:False,ptlb:Dirt/Specular,ptin:_DirtSpecular,varname:node_2774,prsc:2,tex:623b87d3f5c26804db5f53cbc7970388,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9099,x:32572,y:33187,ptovrint:False,ptlb:Test-Ligt (Ambient),ptin:_TestLigtAmbient,varname:node_9099,prsc:2,tex:9c74e73c8e35bd84f9a941a9876f8515,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:4437,x:32432,y:32846,varname:node_4437,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:530,x:32608,y:32846,varname:node_530,prsc:2|A-4437-OUT,B-3758-OUT,T-1680-RGB;n:type:ShaderForge.SFN_Vector1,id:3758,x:32382,y:32928,varname:node_3758,prsc:2,v1:0.5;proporder:4847-1680-4199-2774-9099;pass:END;sub:END;*/

Shader "Shader Forge/BeastShaderTest" {
    Properties {
        _DiffuseBeast1 ("Diffuse Beast 1", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _Normal ("Normal", 2D) = "bump" {}
        _DirtSpecular ("Dirt/Specular", 2D) = "white" {}
        _TestLigtAmbient ("Test-Ligt (Ambient)", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _DiffuseBeast1; uniform float4 _DiffuseBeast1_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _DirtSpecular; uniform float4 _DirtSpecular_ST;
            uniform sampler2D _TestLigtAmbient; uniform float4 _TestLigtAmbient_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float gloss = lerp(1.0,0.5,_Mask_var.rgb);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _DirtSpecular_var = tex2D(_DirtSpecular,TRANSFORM_TEX(i.uv0, _DirtSpecular));
                float3 specularColor = _DirtSpecular_var.rgb;
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float4 _TestLigtAmbient_var = tex2D(_TestLigtAmbient,TRANSFORM_TEX(i.uv0, _TestLigtAmbient));
                float3 w = _TestLigtAmbient_var.rgb*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _DiffuseBeast1_var = tex2D(_DiffuseBeast1,TRANSFORM_TEX(i.uv0, _DiffuseBeast1));
                float3 diffuseColor = _DiffuseBeast1_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _DiffuseBeast1; uniform float4 _DiffuseBeast1_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _DirtSpecular; uniform float4 _DirtSpecular_ST;
            uniform sampler2D _TestLigtAmbient; uniform float4 _TestLigtAmbient_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float gloss = lerp(1.0,0.5,_Mask_var.rgb);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _DirtSpecular_var = tex2D(_DirtSpecular,TRANSFORM_TEX(i.uv0, _DirtSpecular));
                float3 specularColor = _DirtSpecular_var.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float4 _TestLigtAmbient_var = tex2D(_TestLigtAmbient,TRANSFORM_TEX(i.uv0, _TestLigtAmbient));
                float3 w = _TestLigtAmbient_var.rgb*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float4 _DiffuseBeast1_var = tex2D(_DiffuseBeast1,TRANSFORM_TEX(i.uv0, _DiffuseBeast1));
                float3 diffuseColor = _DiffuseBeast1_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
