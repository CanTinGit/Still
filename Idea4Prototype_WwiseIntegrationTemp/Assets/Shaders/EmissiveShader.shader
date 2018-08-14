// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|diff-7382-OUT,spec-3025-OUT,gloss-8870-OUT,emission-1643-OUT,difocc-7331-R;n:type:ShaderForge.SFN_Color,id:7241,x:31308,y:31531,ptovrint:False,ptlb:Light,ptin:_Light,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7019608,c2:0.6352941,c3:0.7450981,c4:1;n:type:ShaderForge.SFN_LightVector,id:5131,x:31194,y:31992,varname:node_5131,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2065,x:31194,y:32138,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:5747,x:31507,y:31992,varname:node_5747,prsc:2,dt:0|A-5131-OUT,B-2065-OUT;n:type:ShaderForge.SFN_Step,id:3432,x:31691,y:31992,varname:node_3432,prsc:2|A-5747-OUT,B-6578-OUT;n:type:ShaderForge.SFN_Tex2d,id:4367,x:30687,y:32410,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_4367,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d4aa66a331e37c542974cb55cefd56c2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5652,x:31691,y:31807,varname:node_5652,prsc:2|A-4367-RGB,B-8187-RGB;n:type:ShaderForge.SFN_Lerp,id:7382,x:31936,y:31807,varname:node_7382,prsc:2|A-7523-OUT,B-5652-OUT,T-3432-OUT;n:type:ShaderForge.SFN_Slider,id:6578,x:31383,y:32163,ptovrint:False,ptlb:Shadow Cutoff,ptin:_ShadowCutoff,varname:node_6578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.5257735,max:1;n:type:ShaderForge.SFN_Multiply,id:7523,x:31702,y:31569,varname:node_7523,prsc:2|A-4367-RGB,B-7241-RGB;n:type:ShaderForge.SFN_Color,id:8187,x:31308,y:31728,ptovrint:False,ptlb:Shadow,ptin:_Shadow,varname:node_8187,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.352745,c2:0.3264062,c3:0.4245283,c4:1;n:type:ShaderForge.SFN_Tex2d,id:5137,x:31701,y:33251,ptovrint:False,ptlb:Metallic Map,ptin:_MetallicMap,varname:node_5137,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e1dc5b13afe4c51499558abfa61348da,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:2618,x:31544,y:33546,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_2618,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:8870,x:31904,y:33548,varname:node_8870,prsc:2|A-5137-R,B-2618-OUT;n:type:ShaderForge.SFN_Multiply,id:3025,x:31904,y:33416,varname:node_3025,prsc:2|A-5137-R,B-6957-OUT;n:type:ShaderForge.SFN_Slider,id:6957,x:31544,y:33443,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_6957,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:7331,x:32279,y:33444,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_7331,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cad59e85d98e16f4e8a896cab31861f0,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:2967,x:31479,y:32621,varname:node_2967,prsc:2|A-7142-OUT,B-4367-RGB,T-8013-RGB;n:type:ShaderForge.SFN_Vector1,id:7142,x:31227,y:32519,varname:node_7142,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:8013,x:30971,y:32611,ptovrint:False,ptlb:EmissiveMask,ptin:_EmissiveMask,varname:node_8013,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:534136b4716d3294b8004a71193ba18b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:6952,x:31322,y:32772,ptovrint:False,ptlb:EmissiveStrength,ptin:_EmissiveStrength,varname:node_6952,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:1643,x:31780,y:32717,varname:node_1643,prsc:2|A-2967-OUT,B-6952-OUT,C-6731-RGB;n:type:ShaderForge.SFN_Color,id:6731,x:31290,y:32922,ptovrint:False,ptlb:Emissive Colour,ptin:_EmissiveColour,varname:node_6731,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;proporder:7241-4367-6578-8187-5137-2618-6957-7331-8013-6952-6731;pass:END;sub:END;*/

Shader "Shader Forge/EmissiveShader" {
    Properties {
        _Light ("Light", Color) = (0.7019608,0.6352941,0.7450981,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _ShadowCutoff ("Shadow Cutoff", Range(-1, 1)) = 0.5257735
        _Shadow ("Shadow", Color) = (0.352745,0.3264062,0.4245283,1)
        _MetallicMap ("Metallic Map", 2D) = "white" {}
        _Gloss ("Gloss", Range(0, 1)) = 0
        _Metallic ("Metallic", Range(0, 1)) = 0
        _AO ("AO", 2D) = "white" {}
        _EmissiveMask ("EmissiveMask", 2D) = "white" {}
        _EmissiveStrength ("EmissiveStrength", Range(0, 1)) = 1
        _EmissiveColour ("Emissive Colour", Color) = (1,0,0,1)
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
            uniform float4 _Light;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _ShadowCutoff;
            uniform float4 _Shadow;
            uniform sampler2D _MetallicMap; uniform float4 _MetallicMap_ST;
            uniform float _Gloss;
            uniform float _Metallic;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform sampler2D _EmissiveMask; uniform float4 _EmissiveMask_ST;
            uniform float _EmissiveStrength;
            uniform float4 _EmissiveColour;
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
                float4 _MetallicMap_var = tex2D(_MetallicMap,TRANSFORM_TEX(i.uv0, _MetallicMap));
                float gloss = (_MetallicMap_var.r*_Gloss);
                float perceptualRoughness = 1.0 - (_MetallicMap_var.r*_Gloss);
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
                float3 specularColor = (_MetallicMap_var.r*_Metallic);
                float specularMonochrome;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = lerp((_Diffuse_var.rgb*_Light.rgb),(_Diffuse_var.rgb*_Shadow.rgb),step(dot(lightDirection,i.normalDir),_ShadowCutoff)); // Need this for specular when using metallic
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
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                indirectDiffuse *= _AO_var.r; // Diffuse AO
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_7142 = 0.0;
                float4 _EmissiveMask_var = tex2D(_EmissiveMask,TRANSFORM_TEX(i.uv0, _EmissiveMask));
                float3 emissive = (lerp(float3(node_7142,node_7142,node_7142),_Diffuse_var.rgb,_EmissiveMask_var.rgb)*_EmissiveStrength*_EmissiveColour.rgb);
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
            uniform float4 _Light;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _ShadowCutoff;
            uniform float4 _Shadow;
            uniform sampler2D _MetallicMap; uniform float4 _MetallicMap_ST;
            uniform float _Gloss;
            uniform float _Metallic;
            uniform sampler2D _EmissiveMask; uniform float4 _EmissiveMask_ST;
            uniform float _EmissiveStrength;
            uniform float4 _EmissiveColour;
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
                float4 _MetallicMap_var = tex2D(_MetallicMap,TRANSFORM_TEX(i.uv0, _MetallicMap));
                float gloss = (_MetallicMap_var.r*_Gloss);
                float perceptualRoughness = 1.0 - (_MetallicMap_var.r*_Gloss);
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = (_MetallicMap_var.r*_Metallic);
                float specularMonochrome;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = lerp((_Diffuse_var.rgb*_Light.rgb),(_Diffuse_var.rgb*_Shadow.rgb),step(dot(lightDirection,i.normalDir),_ShadowCutoff)); // Need this for specular when using metallic
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
