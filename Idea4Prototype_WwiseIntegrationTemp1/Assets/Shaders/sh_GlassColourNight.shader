// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|diff-7382-OUT,spec-1253-OUT,gloss-5209-OUT,emission-1643-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31308,y:31531,ptovrint:False,ptlb:Light_Modifier,ptin:_Light_Modifier,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7019608,c2:0.6352941,c3:0.7450981,c4:1;n:type:ShaderForge.SFN_LightVector,id:5131,x:31194,y:31992,varname:node_5131,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2065,x:31194,y:32138,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:5747,x:31507,y:31992,varname:node_5747,prsc:2,dt:0|A-5131-OUT,B-2065-OUT;n:type:ShaderForge.SFN_Step,id:3432,x:31691,y:31992,varname:node_3432,prsc:2|A-5747-OUT,B-6578-OUT;n:type:ShaderForge.SFN_Multiply,id:5652,x:31691,y:31807,varname:node_5652,prsc:2|A-391-RGB,B-8187-RGB;n:type:ShaderForge.SFN_Lerp,id:7382,x:31936,y:31807,varname:node_7382,prsc:2|A-7523-OUT,B-5652-OUT,T-3432-OUT;n:type:ShaderForge.SFN_Slider,id:6578,x:31383,y:32163,ptovrint:False,ptlb:Shadow_Cutoff,ptin:_Shadow_Cutoff,varname:node_6578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.5,max:1;n:type:ShaderForge.SFN_Multiply,id:7523,x:31702,y:31569,varname:node_7523,prsc:2|A-391-RGB,B-7241-RGB;n:type:ShaderForge.SFN_Color,id:8187,x:31308,y:31728,ptovrint:False,ptlb:Shadow_Modifier,ptin:_Shadow_Modifier,varname:node_8187,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.352745,c2:0.3264062,c3:0.4245283,c4:1;n:type:ShaderForge.SFN_Slider,id:2618,x:31200,y:32973,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_2618,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Slider,id:6957,x:31194,y:32417,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_6957,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Slider,id:6952,x:30722,y:33637,ptovrint:False,ptlb:Emissive_Strength,ptin:_Emissive_Strength,varname:node_6952,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:1643,x:31180,y:33582,varname:node_1643,prsc:2|A-391-RGB,B-6952-OUT,C-6731-RGB;n:type:ShaderForge.SFN_Color,id:6731,x:30879,y:33755,ptovrint:False,ptlb:Emissive_Colour,ptin:_Emissive_Colour,varname:node_6731,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:391,x:30454,y:32020,ptovrint:False,ptlb:Base_Colour,ptin:_Base_Colour,varname:node_391,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7727,x:31010,y:32573,ptovrint:False,ptlb:Spec_Map,ptin:_Spec_Map,varname:node_7727,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a16f7b26cc87670448260af28d24ed52,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1253,x:31658,y:32462,varname:node_1253,prsc:2|A-7727-R,B-6957-OUT;n:type:ShaderForge.SFN_Multiply,id:5209,x:31658,y:32637,varname:node_5209,prsc:2|A-7727-R,B-2618-OUT;proporder:391-7241-8187-6578-6957-2618-6952-6731-7727;pass:END;sub:END;*/

Shader "Team05/sh_GlassColourNight" {
    Properties {
        _Base_Colour ("Base_Colour", Color) = (0.5,0.5,0.5,1)
        _Light_Modifier ("Light_Modifier", Color) = (0.7019608,0.6352941,0.7450981,1)
        _Shadow_Modifier ("Shadow_Modifier", Color) = (0.352745,0.3264062,0.4245283,1)
        _Shadow_Cutoff ("Shadow_Cutoff", Range(-1, 1)) = 0.5
        _Metallic ("Metallic", Range(0, 2)) = 0
        _Gloss ("Gloss", Range(0, 2)) = 0
        _Emissive_Strength ("Emissive_Strength", Range(0, 1)) = 0
        _Emissive_Colour ("Emissive_Colour", Color) = (1,1,1,1)
        _Spec_Map ("Spec_Map", 2D) = "white" {}
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
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Light_Modifier;
            uniform float _Shadow_Cutoff;
            uniform float4 _Shadow_Modifier;
            uniform float _Gloss;
            uniform float _Metallic;
            uniform float _Emissive_Strength;
            uniform float4 _Emissive_Colour;
            uniform float4 _Base_Colour;
            uniform sampler2D _Spec_Map; uniform float4 _Spec_Map_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation,i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Spec_Map_var = tex2D(_Spec_Map,TRANSFORM_TEX(i.uv0, _Spec_Map));
                float gloss = (_Spec_Map_var.r*_Gloss);
                float perceptualRoughness = 1.0 - (_Spec_Map_var.r*_Gloss);
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = (_Spec_Map_var.r*_Metallic);
                float specularMonochrome;
                float3 diffuseColor = lerp((_Base_Colour.rgb*_Light_Modifier.rgb),(_Base_Colour.rgb*_Shadow_Modifier.rgb),step(dot(lightDirection,i.normalDir),_Shadow_Cutoff)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (_Base_Colour.rgb*_Emissive_Strength*_Emissive_Colour.rgb);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                return fixed4(finalColor,1);
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
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Light_Modifier;
            uniform float _Shadow_Cutoff;
            uniform float4 _Shadow_Modifier;
            uniform float _Gloss;
            uniform float _Metallic;
            uniform float _Emissive_Strength;
            uniform float4 _Emissive_Colour;
            uniform float4 _Base_Colour;
            uniform sampler2D _Spec_Map; uniform float4 _Spec_Map_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation,i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Spec_Map_var = tex2D(_Spec_Map,TRANSFORM_TEX(i.uv0, _Spec_Map));
                float gloss = (_Spec_Map_var.r*_Gloss);
                float perceptualRoughness = 1.0 - (_Spec_Map_var.r*_Gloss);
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = (_Spec_Map_var.r*_Metallic);
                float specularMonochrome;
                float3 diffuseColor = lerp((_Base_Colour.rgb*_Light_Modifier.rgb),(_Base_Colour.rgb*_Shadow_Modifier.rgb),step(dot(lightDirection,i.normalDir),_Shadow_Cutoff)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
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
