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
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:2,uamb:True,mssp:True,lmpd:True,lprd:True,enco:False,frtr:True,vitr:True,dbil:True,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.1280277,fgcg:0.1953466,fgcb:0.2352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|diff-77-OUT,spec-90-OUT,gloss-146-OUT,normal-26-RGB,emission-163-OUT;n:type:ShaderForge.SFN_Cubemap,id:2,x:33964,y:32300,ptlb:Cubemap,ptin:_Cubemap,cube:2b9f65f9313cb424c9fe4ae3882fc5e1,pvfc:0;n:type:ShaderForge.SFN_Slider,id:3,x:33498,y:33306,ptlb:GlossLow,ptin:_GlossLow,min:0,cur:0.1666343,max:1;n:type:ShaderForge.SFN_Tex2d,id:4,x:32736,y:32474,ptlb:Diffuse,ptin:_Diffuse,tex:287bed2bc6dfccd4eb8ab0609c107347,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:10,x:33227,y:32693,ptlb:LowSpecColor,ptin:_LowSpecColor,glob:False,c1:0.07352942,c2:0.07352942,c3:0.07352942,c4:1;n:type:ShaderForge.SFN_Tex2d,id:26,x:33346,y:33429,ptlb:NormalMap,ptin:_NormalMap,tex:cdbc6b02957691a488a8516403f60614,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Color,id:52,x:33964,y:32141,ptlb:CubeColor,ptin:_CubeColor,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:53,x:33740,y:32228|A-52-RGB,B-2-RGB;n:type:ShaderForge.SFN_Multiply,id:59,x:33121,y:32230|A-53-OUT,B-60-RGB;n:type:ShaderForge.SFN_Tex2d,id:60,x:33805,y:32381,ptlb:Shining,ptin:_Shining,tex:533cb52fb74f36348b6b283055edbba5,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:77,x:32518,y:32474|A-4-RGB,B-78-RGB;n:type:ShaderForge.SFN_Color,id:78,x:32758,y:32308,ptlb:DiffColor,ptin:_DiffColor,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:84,x:33180,y:32430|A-60-RGB,B-92-RGB;n:type:ShaderForge.SFN_Add,id:90,x:33070,y:32693|A-180-OUT,B-10-RGB;n:type:ShaderForge.SFN_Color,id:92,x:34019,y:32520,ptlb:HighSpecColor,ptin:_HighSpecColor,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:103,x:33320,y:33193|A-60-R,B-130-OUT;n:type:ShaderForge.SFN_Slider,id:130,x:33498,y:33199,ptlb:GlossHigh,ptin:_GlossHigh,min:0,cur:0.7169596,max:1;n:type:ShaderForge.SFN_Add,id:146,x:33164,y:33193|A-103-OUT,B-3-OUT;n:type:ShaderForge.SFN_Tex2d,id:161,x:33488,y:32972,ptlb:IllumText,ptin:_IllumText,tex:81e9d0d768299cf469da6d745078f351,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:162,x:33321,y:32914|A-164-RGB,B-161-A;n:type:ShaderForge.SFN_Add,id:163,x:32960,y:32812|A-59-OUT,B-320-OUT;n:type:ShaderForge.SFN_Color,id:164,x:33488,y:32806,ptlb:IllumColor,ptin:_IllumColor,glob:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:179,x:33500,y:32671,ptlb:HighSpecMultiplayer,ptin:_HighSpecMultiplayer,min:0,cur:1.91453,max:6;n:type:ShaderForge.SFN_Multiply,id:180,x:32947,y:32504|A-84-OUT,B-179-OUT;n:type:ShaderForge.SFN_Multiply,id:320,x:33127,y:32902|A-4-RGB,B-162-OUT;proporder:4-78-26-60-2-52-130-92-3-10-161-164-179;pass:END;sub:END;*/

Shader "Shader Forge/SpecGrayscaleSF" {
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
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
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
                #ifndef LIGHTMAP_OFF
                    float2 uvLM : TEXCOORD7;
                #else
                    float3 shLight : TEXCOORD7;
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
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_404 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_404.rg, _NormalMap))).rgb;
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
                float attenuation = LIGHT_ATTENUATION(i)*2;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                #ifndef LIGHTMAP_OFF
                    float3 diffuse = lightmap.rgb;
                #else
                    float3 diffuse = max( 0.0, NdotL) * attenColor;
                #endif
////// Emissive:
                float4 node_60 = tex2D(_Shining,TRANSFORM_TEX(node_404.rg, _Shining));
                float4 node_4 = tex2D(_Diffuse,TRANSFORM_TEX(node_404.rg, _Diffuse));
                float3 emissive = (((_CubeColor.rgb*texCUBE(_Cubemap,viewReflectDirection).rgb)*node_60.rgb)+(node_4.rgb*(_IllumColor.rgb*tex2D(_IllumText,TRANSFORM_TEX(node_404.rg, _IllumText)).a)));
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
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
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
                float2 node_405 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_405.rg, _NormalMap))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i)*2;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float4 node_60 = tex2D(_Shining,TRANSFORM_TEX(node_405.rg, _Shining));
                float gloss = ((node_60.r*_GlossHigh)+_GlossLow);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = (((node_60.rgb*_HighSpecColor.rgb)*_HighSpecMultiplayer)+_LowSpecColor.rgb);
                float3 specular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float4 node_4 = tex2D(_Diffuse,TRANSFORM_TEX(node_405.rg, _Diffuse));
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
