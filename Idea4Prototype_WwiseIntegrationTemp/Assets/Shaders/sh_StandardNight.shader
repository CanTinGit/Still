// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32708,y:32714,varname:node_3138,prsc:2|diff-7382-OUT,spec-3025-OUT,gloss-8870-OUT,difocc-5537-R;n:type:ShaderForge.SFN_Color,id:7241,x:31341,y:32184,ptovrint:False,ptlb:Light_Modifier,ptin:_Light_Modifier,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7568628,c2:0.7333333,c3:0.8588235,c4:1;n:type:ShaderForge.SFN_LightVector,id:5131,x:31227,y:32645,varname:node_5131,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2065,x:31227,y:32791,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:5747,x:31540,y:32645,varname:node_5747,prsc:2,dt:0|A-5131-OUT,B-2065-OUT;n:type:ShaderForge.SFN_Step,id:3432,x:31724,y:32645,varname:node_3432,prsc:2|A-5747-OUT,B-6578-OUT;n:type:ShaderForge.SFN_Multiply,id:5652,x:31724,y:32460,varname:node_5652,prsc:2|A-7297-RGB,B-8187-RGB;n:type:ShaderForge.SFN_Lerp,id:7382,x:31969,y:32460,varname:node_7382,prsc:2|A-7523-OUT,B-5652-OUT,T-3432-OUT;n:type:ShaderForge.SFN_Slider,id:6578,x:31416,y:32816,ptovrint:False,ptlb:Shadow_Cutoff,ptin:_Shadow_Cutoff,varname:node_6578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.5,max:1;n:type:ShaderForge.SFN_Multiply,id:7523,x:31735,y:32222,varname:node_7523,prsc:2|A-7297-RGB,B-7241-RGB;n:type:ShaderForge.SFN_Color,id:8187,x:31341,y:32381,ptovrint:False,ptlb:Shadow_Modifier,ptin:_Shadow_Modifier,varname:node_8187,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.352745,c2:0.3264062,c3:0.4245283,c4:1;n:type:ShaderForge.SFN_Slider,id:2618,x:31379,y:33475,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_2618,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Multiply,id:8870,x:31739,y:33362,varname:node_8870,prsc:2|A-7352-RGB,B-2618-OUT;n:type:ShaderForge.SFN_Multiply,id:3025,x:31748,y:32967,varname:node_3025,prsc:2|A-2993-RGB,B-6957-OUT;n:type:ShaderForge.SFN_Slider,id:6957,x:31379,y:33199,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_6957,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:7297,x:31341,y:31975,ptovrint:False,ptlb:Base_Colour,ptin:_Base_Colour,varname:node_7297,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5537,x:32402,y:33196,ptovrint:False,ptlb:Ambient_Occlusion,ptin:_Ambient_Occlusion,varname:node_5537,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2993,x:31392,y:32986,ptovrint:False,ptlb:Metallic_Map,ptin:_Metallic_Map,varname:node_2993,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7352,x:31379,y:33301,ptovrint:False,ptlb:Gloss_Map,ptin:_Gloss_Map,varname:node_7352,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;proporder:7297-7241-8187-6578-5537-2993-6957-7352-2618;pass:END;sub:END;*/

Shader "Team05/sh_StandardNight" {
    Properties {
        _Base_Colour ("Base_Colour", 2D) = "white" {}
        _Light_Modifier ("Light_Modifier", Color) = (0.7568628,0.7333333,0.8588235,1)
        _Shadow_Modifier ("Shadow_Modifier", Color) = (0.352745,0.3264062,0.4245283,1)
        _Shadow_Cutoff ("Shadow_Cutoff", Range(-1, 1)) = 0.5
        _Ambient_Occlusion ("Ambient_Occlusion", 2D) = "white" {}
        _Metallic_Map ("Metallic_Map", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss_Map ("Gloss_Map", 2D) = "white" {}
        _Gloss ("Gloss", Range(0, 2)) = 0
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
            uniform sampler2D _Base_Colour; uniform float4 _Base_Colour_ST;
            uniform sampler2D _Ambient_Occlusion; uniform float4 _Ambient_Occlusion_ST;
            uniform sampler2D _Metallic_Map; uniform float4 _Metallic_Map_ST;
            uniform sampler2D _Gloss_Map; uniform float4 _Gloss_Map_ST;
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
                float4 _Gloss_Map_var = tex2D(_Gloss_Map,TRANSFORM_TEX(i.uv0, _Gloss_Map));
                float gloss = (_Gloss_Map_var.rgb*_Gloss);
                float perceptualRoughness = 1.0 - (_Gloss_Map_var.rgb*_Gloss);
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
                float4 _Metallic_Map_var = tex2D(_Metallic_Map,TRANSFORM_TEX(i.uv0, _Metallic_Map));
                float3 specularColor = (_Metallic_Map_var.rgb*_Metallic).r;
                float specularMonochrome;
                float4 _Base_Colour_var = tex2D(_Base_Colour,TRANSFORM_TEX(i.uv0, _Base_Colour));
                float3 diffuseColor = lerp((_Base_Colour_var.rgb*_Light_Modifier.rgb),(_Base_Colour_var.rgb*_Shadow_Modifier.rgb),step(dot(lightDirection,i.normalDir),_Shadow_Cutoff)); // Need this for specular when using metallic
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
                float4 _Ambient_Occlusion_var = tex2D(_Ambient_Occlusion,TRANSFORM_TEX(i.uv0, _Ambient_Occlusion));
                indirectDiffuse *= _Ambient_Occlusion_var.r; // Diffuse AO
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            uniform sampler2D _Base_Colour; uniform float4 _Base_Colour_ST;
            uniform sampler2D _Metallic_Map; uniform float4 _Metallic_Map_ST;
            uniform sampler2D _Gloss_Map; uniform float4 _Gloss_Map_ST;
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
                float4 _Gloss_Map_var = tex2D(_Gloss_Map,TRANSFORM_TEX(i.uv0, _Gloss_Map));
                float gloss = (_Gloss_Map_var.rgb*_Gloss);
                float perceptualRoughness = 1.0 - (_Gloss_Map_var.rgb*_Gloss);
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float4 _Metallic_Map_var = tex2D(_Metallic_Map,TRANSFORM_TEX(i.uv0, _Metallic_Map));
                float3 specularColor = (_Metallic_Map_var.rgb*_Metallic).r;
                float specularMonochrome;
                float4 _Base_Colour_var = tex2D(_Base_Colour,TRANSFORM_TEX(i.uv0, _Base_Colour));
                float3 diffuseColor = lerp((_Base_Colour_var.rgb*_Light_Modifier.rgb),(_Base_Colour_var.rgb*_Shadow_Modifier.rgb),step(dot(lightDirection,i.normalDir),_Shadow_Cutoff)); // Need this for specular when using metallic
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
