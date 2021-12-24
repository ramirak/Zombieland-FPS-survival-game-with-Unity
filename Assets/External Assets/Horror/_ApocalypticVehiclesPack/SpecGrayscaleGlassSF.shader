#warning Upgrade NOTE: unity_Scale shader variable was removed; replaced 'unity_Scale.w' with '1.0'
// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_LightmapInd', a built-in variable
// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
// Upgrade NOTE: replaced tex2D unity_Lightmap with UNITY_SAMPLE_TEX2D
// Upgrade NOTE: replaced tex2D unity_LightmapInd with UNITY_SAMPLE_TEX2D_SAMPLER

// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:2,uamb:True,mssp:True,lmpd:True,lprd:True,enco:False,frtr:True,vitr:True,dbil:True,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:2,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:False,ufog:True,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.1280277,fgcg:0.1953466,fgcb:0.2352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32467,y:32736|diff-77-OUT,spec-90-OUT,gloss-146-OUT,normal-26-RGB,emission-544-OUT,lwrap-474-OUT;n:type:ShaderForge.SFN_Cubemap,id:2,x:34080,y:32191,ptlb:Cubemap,ptin:_Cubemap,cube:2b9f65f9313cb424c9fe4ae3882fc5e1,pvfc:0;n:type:ShaderForge.SFN_Slider,id:3,x:33498,y:33306,ptlb:GlossLow,ptin:_GlossLow,min:0,cur:0.1666343,max:1;n:type:ShaderForge.SFN_Tex2d,id:4,x:32736,y:32474,ptlb:Diffuse,ptin:_Diffuse,tex:287bed2bc6dfccd4eb8ab0609c107347,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:10,x:33227,y:32693,ptlb:LowSpecColor,ptin:_LowSpecColor,glob:False,c1:0.07352942,c2:0.07352942,c3:0.07352942,c4:1;n:type:ShaderForge.SFN_Tex2d,id:26,x:32755,y:32672,ptlb:NormalMap,ptin:_NormalMap,tex:cdbc6b02957691a488a8516403f60614,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Color,id:52,x:34080,y:32032,ptlb:CubeColor,ptin:_CubeColor,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:53,x:33912,y:32032|A-52-RGB,B-2-RGB;n:type:ShaderForge.SFN_Multiply,id:59,x:33309,y:32139|A-53-OUT,B-60-RGB;n:type:ShaderForge.SFN_Tex2d,id:60,x:33912,y:32191,ptlb:Shining,ptin:_Shining,tex:533cb52fb74f36348b6b283055edbba5,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:77,x:32578,y:32464|A-4-RGB,B-78-RGB;n:type:ShaderForge.SFN_Color,id:78,x:32758,y:32308,ptlb:DiffColor,ptin:_DiffColor,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:84,x:33547,y:32362|A-60-RGB,B-92-RGB;n:type:ShaderForge.SFN_Add,id:90,x:33041,y:32670|A-180-OUT,B-10-RGB;n:type:ShaderForge.SFN_Color,id:92,x:33986,y:32430,ptlb:HighSpecColor,ptin:_HighSpecColor,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:103,x:33320,y:33193|A-60-R,B-130-OUT;n:type:ShaderForge.SFN_Slider,id:130,x:33498,y:33199,ptlb:GlossHigh,ptin:_GlossHigh,min:0,cur:0.7169596,max:1;n:type:ShaderForge.SFN_Add,id:146,x:33164,y:33193|A-103-OUT,B-3-OUT;n:type:ShaderForge.SFN_Tex2d,id:161,x:33488,y:32972,ptlb:IllumText,ptin:_IllumText,tex:81e9d0d768299cf469da6d745078f351,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:162,x:33321,y:32914|A-164-RGB,B-161-A;n:type:ShaderForge.SFN_Add,id:163,x:32960,y:32812|A-59-OUT,B-320-OUT;n:type:ShaderForge.SFN_Color,id:164,x:33488,y:32806,ptlb:IllumColor,ptin:_IllumColor,glob:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:179,x:33749,y:32579,ptlb:HighSpecMultiplayer,ptin:_HighSpecMultiplayer,min:0,cur:1.91453,max:6;n:type:ShaderForge.SFN_Multiply,id:180,x:33393,y:32362|A-84-OUT,B-179-OUT;n:type:ShaderForge.SFN_Multiply,id:320,x:33127,y:32902|A-4-RGB,B-162-OUT;n:type:ShaderForge.SFN_Color,id:395,x:32304,y:32709,ptlb:Translucent,ptin:_Translucent,glob:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:412,x:32113,y:32653|A-525-RGB,B-395-RGB;n:type:ShaderForge.SFN_Slider,id:467,x:32098,y:32914,ptlb:TranslucentRange,ptin:_TranslucentRange,min:0,cur:1,max:3;n:type:ShaderForge.SFN_Multiply,id:474,x:31947,y:32653|A-412-OUT,B-467-OUT;n:type:ShaderForge.SFN_Tex2d,id:525,x:32304,y:32527,ptlb:TranslucentText,ptin:_TranslucentText,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Fresnel,id:543,x:32907,y:33831;n:type:ShaderForge.SFN_Add,id:544,x:32739,y:32837|A-163-OUT,B-577-OUT;n:type:ShaderForge.SFN_Slider,id:576,x:32864,y:33985,ptlb:FresnelRange,ptin:_FresnelRange,min:1,cur:3,max:3;n:type:ShaderForge.SFN_Multiply,id:577,x:32733,y:33592|A-583-OUT,B-589-RGB;n:type:ShaderForge.SFN_Power,id:583,x:32723,y:33738|VAL-543-OUT,EXP-576-OUT;n:type:ShaderForge.SFN_Color,id:589,x:32927,y:33675,ptlb:FresnelColor,ptin:_FresnelColor,glob:False,c1:1,c2:1,c3:1,c4:1;proporder:4-78-26-60-2-52-130-92-3-10-161-164-179-395-467-525-576-589;pass:END;sub:END;*/

Shader "Shader Forge/SpecGrayscaleGlassSF" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _DiffColor ("DiffColor", Color) = (1,1,1,1)
        _NormalMap ("NormalMap", 2D) = "bump" {}
        _Shining ("Shining", 2D) = "black" {}
        _Cubemap ("Cubemap", Cube) = "_Skybox" {}
        _CubeColor ("CubeColor", Color) = (0.5,0.5,0.5,1)
        _GlossHigh ("GlossHigh", Range(0, 1)) = 0.7169596
        _HighSpecColor ("HighSpecColor", Color) = (1,1,1,1)
        _GlossLow ("GlossLow", Range(0, 1)) = 0.1666343
        _LowSpecColor ("LowSpecColor", Color) = (0.07352942,0.07352942,0.07352942,1)
        _IllumText ("IllumText", 2D) = "white" {}
        _IllumColor ("IllumColor", Color) = (0,0,0,1)
        _HighSpecMultiplayer ("HighSpecMultiplayer", Range(0, 6)) = 1.91453
        _Translucent ("Translucent", Color) = (1,0,0,1)
        _TranslucentRange ("TranslucentRange", Range(0, 3)) = 1
        _TranslucentText ("TranslucentText", 2D) = "white" {}
        _FresnelRange ("FresnelRange", Range(1, 3)) = 3
        _FresnelColor ("FresnelColor", Color) = (1,1,1,1)
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
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
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            #ifndef LIGHTMAP_OFF
                // float4 unity_LightmapST;
                // sampler2D unity_Lightmap;
                #ifndef DIRLIGHTMAP_OFF
                    // sampler2D unity_LightmapInd;
                #endif
            #endif
            uniform samplerCUBE _Cubemap;
            uniform float _GlossLow;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _LowSpecColor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float4 _CubeColor;
            uniform sampler2D _Shining; uniform float4 _Shining_ST;
            uniform float4 _DiffColor;
            uniform float4 _HighSpecColor;
            uniform float _GlossHigh;
            uniform sampler2D _IllumText; uniform float4 _IllumText_ST;
            uniform float4 _IllumColor;
            uniform float _HighSpecMultiplayer;
            uniform float4 _Translucent;
            uniform float _TranslucentRange;
            uniform sampler2D _TranslucentText; uniform float4 _TranslucentText_ST;
            uniform float _FresnelRange;
            uniform float4 _FresnelColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                #ifndef LIGHTMAP_OFF
                    float2 uvLM : TEXCOORD5;
                #else
                    float3 shLight : TEXCOORD5;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                #ifdef LIGHTMAP_OFF
                    o.shLight = ShadeSH9(float4(mul(unity_ObjectToWorld, float4(v.normal,0)).xyz * 1.0,1));
                #endif
                o.normalDir = mul(float4(v.normal,0), unity_WorldToObject).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                #ifndef LIGHTMAP_OFF
                    o.uvLM = v.texcoord1 * unity_LightmapST.xy + unity_LightmapST.zw;
                #endif
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_601 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_601.rg, _NormalMap))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                #ifndef LIGHTMAP_OFF
                    float4 lmtex = UNITY_SAMPLE_TEX2D(unity_Lightmap,i.uvLM);
                    #ifndef DIRLIGHTMAP_OFF
                        float3 lightmap = DecodeLightmap(lmtex);
                        float3 scalePerBasisVector = DecodeLightmap(UNITY_SAMPLE_TEX2D_SAMPLER(unity_LightmapInd,unity_Lightmap,i.uvLM));
                        UNITY_DIRBASIS
                        half3 normalInRnmBasis = saturate (mul (unity_DirBasis, normalLocal));
                        lightmap *= dot (normalInRnmBasis, scalePerBasisVector);
                    #else
                        float3 lightmap = DecodeLightmap(lmtex);
                    #endif
                #endif
                #ifndef LIGHTMAP_OFF
                    #ifdef DIRLIGHTMAP_OFF
                        float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                    #else
                        float3 lightDirection = normalize (scalePerBasisVector.x * unity_DirBasis[0] + scalePerBasisVector.y * unity_DirBasis[1] + scalePerBasisVector.z * unity_DirBasis[2]);
                        lightDirection = mul(lightDirection,tangentTransform); // Tangent to world
                    #endif
                #else
                    float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                #endif
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = ((tex2D(_TranslucentText,TRANSFORM_TEX(node_601.rg, _TranslucentText)).rgb*_Translucent.rgb)*_TranslucentRange)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                #ifndef LIGHTMAP_OFF
                    float3 diffuse = lightmap.rgb;
                #else
                    float3 diffuse = forwardLight * attenColor;
                #endif
////// Emissive:
                float4 node_60 = tex2D(_Shining,TRANSFORM_TEX(node_601.rg, _Shining));
                float4 node_4 = tex2D(_Diffuse,TRANSFORM_TEX(node_601.rg, _Diffuse));
                float3 emissive = ((((_CubeColor.rgb*texCUBE(_Cubemap,viewReflectDirection).rgb)*node_60.rgb)+(node_4.rgb*(_IllumColor.rgb*tex2D(_IllumText,TRANSFORM_TEX(node_601.rg, _IllumText)).a)))+(pow((1.0-max(0,dot(normalDirection, viewDirection))),_FresnelRange)*_FresnelColor.rgb));
///////// Gloss:
                float gloss = ((node_60.r*_GlossHigh)+_GlossLow);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = (((node_60.rgb*_HighSpecColor.rgb)*_HighSpecMultiplayer)+_LowSpecColor.rgb);
                float3 specular = 1 * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow) * specularColor;
                #ifndef LIGHTMAP_OFF
                    #ifndef DIRLIGHTMAP_OFF
                        specular *= lightmap;
                    #else
                        specular *= (floor(attenuation) * _LightColor0.xyz);
                    #endif
                #else
                    specular *= (floor(attenuation) * _LightColor0.xyz);
                #endif
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                #ifdef LIGHTMAP_OFF
                    diffuseLight += i.shLight; // Per-Vertex Light Probes / Spherical harmonics
                #endif
                finalColor += diffuseLight * (node_4.rgb*_DiffColor.rgb);
                finalColor += specular;
                finalColor += emissive;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            #ifndef LIGHTMAP_OFF
                // float4 unity_LightmapST;
                // sampler2D unity_Lightmap;
                #ifndef DIRLIGHTMAP_OFF
                    // sampler2D unity_LightmapInd;
                #endif
            #endif
            uniform samplerCUBE _Cubemap;
            uniform float _GlossLow;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _LowSpecColor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float4 _CubeColor;
            uniform sampler2D _Shining; uniform float4 _Shining_ST;
            uniform float4 _DiffColor;
            uniform float4 _HighSpecColor;
            uniform float _GlossHigh;
            uniform sampler2D _IllumText; uniform float4 _IllumText_ST;
            uniform float4 _IllumColor;
            uniform float _HighSpecMultiplayer;
            uniform float4 _Translucent;
            uniform float _TranslucentRange;
            uniform sampler2D _TranslucentText; uniform float4 _TranslucentText_ST;
            uniform float _FresnelRange;
            uniform float4 _FresnelColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), unity_WorldToObject).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_602 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_602.rg, _NormalMap))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i)*2;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = ((tex2D(_TranslucentText,TRANSFORM_TEX(node_602.rg, _TranslucentText)).rgb*_Translucent.rgb)*_TranslucentRange)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 diffuse = forwardLight * attenColor;
///////// Gloss:
                float4 node_60 = tex2D(_Shining,TRANSFORM_TEX(node_602.rg, _Shining));
                float gloss = ((node_60.r*_GlossHigh)+_GlossLow);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = (((node_60.rgb*_HighSpecColor.rgb)*_HighSpecMultiplayer)+_LowSpecColor.rgb);
                float3 specular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float4 node_4 = tex2D(_Diffuse,TRANSFORM_TEX(node_602.rg, _Diffuse));
                finalColor += diffuseLight * (node_4.rgb*_DiffColor.rgb);
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
