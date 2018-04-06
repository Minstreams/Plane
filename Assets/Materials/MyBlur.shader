// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:False,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:6,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:1,qpre:4,rntp:5,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5764706,fgcg:0.7058824,fgcb:0.8784314,fgca:1,fgde:0.213,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33229,y:33166,varname:node_2865,prsc:2|custl-5228-OUT;n:type:ShaderForge.SFN_TexCoord,id:4219,x:31539,y:33391,cmnt:Default coordinates,varname:node_4219,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2dAsset,id:4430,x:31539,y:33572,ptovrint:False,ptlb:MainTex,ptin:_MainTex,cmnt:MainTex contains the color of the scene,varname:node_9933,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:641bb2dce818a8a499b537a1963889ac,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7542,x:32248,y:33168,varname:node_1672,prsc:2,tex:641bb2dce818a8a499b537a1963889ac,ntxv:0,isnm:False|UVIN-4219-UVOUT,TEX-4430-TEX;n:type:ShaderForge.SFN_Vector1,id:9961,x:31539,y:33745,varname:node_9961,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Multiply,id:8402,x:32449,y:33168,varname:node_8402,prsc:2|A-7542-RGB,B-4101-OUT;n:type:ShaderForge.SFN_Vector1,id:4101,x:32248,y:33305,varname:node_4101,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Add,id:5228,x:32798,y:33166,varname:node_5228,prsc:2|A-8402-OUT,B-1227-OUT,C-9127-OUT,D-8578-OUT,E-6799-OUT;n:type:ShaderForge.SFN_Panner,id:6185,x:32062,y:33394,varname:node_6185,prsc:2,spu:0,spv:1|UVIN-4219-UVOUT,DIST-9961-OUT;n:type:ShaderForge.SFN_Multiply,id:1227,x:32449,y:33394,varname:node_1227,prsc:2|A-8930-RGB,B-1075-OUT;n:type:ShaderForge.SFN_Vector1,id:1075,x:32248,y:33531,varname:node_1075,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Tex2d,id:712,x:32248,y:33619,varname:_node_1044_copy,prsc:2,tex:641bb2dce818a8a499b537a1963889ac,ntxv:0,isnm:False|UVIN-5429-UVOUT,TEX-4430-TEX;n:type:ShaderForge.SFN_Panner,id:5429,x:32062,y:33619,varname:node_5429,prsc:2,spu:0,spv:-1|UVIN-4219-UVOUT,DIST-9961-OUT;n:type:ShaderForge.SFN_Multiply,id:9127,x:32449,y:33619,varname:node_9127,prsc:2|A-712-RGB,B-391-OUT;n:type:ShaderForge.SFN_Vector1,id:391,x:32248,y:33756,varname:node_391,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Tex2d,id:4263,x:32248,y:33844,varname:_node_1044_copy_copy,prsc:2,tex:641bb2dce818a8a499b537a1963889ac,ntxv:0,isnm:False|UVIN-4578-UVOUT,TEX-4430-TEX;n:type:ShaderForge.SFN_Panner,id:4578,x:32062,y:33844,varname:node_4578,prsc:2,spu:1,spv:0|UVIN-4219-UVOUT,DIST-9961-OUT;n:type:ShaderForge.SFN_Multiply,id:8578,x:32449,y:33844,varname:node_8578,prsc:2|A-4263-RGB,B-7936-OUT;n:type:ShaderForge.SFN_Vector1,id:7936,x:32248,y:33981,varname:node_7936,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Tex2d,id:37,x:32248,y:34070,varname:_node_1044_copy_copy_copy,prsc:2,tex:641bb2dce818a8a499b537a1963889ac,ntxv:0,isnm:False|UVIN-4968-UVOUT,TEX-4430-TEX;n:type:ShaderForge.SFN_Panner,id:4968,x:32062,y:34070,varname:node_4968,prsc:2,spu:-1,spv:0|UVIN-4219-UVOUT,DIST-9961-OUT;n:type:ShaderForge.SFN_Multiply,id:6799,x:32449,y:34070,varname:node_6799,prsc:2|A-37-RGB,B-9443-OUT;n:type:ShaderForge.SFN_Vector1,id:9443,x:32248,y:34207,varname:node_9443,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Tex2d,id:8930,x:32248,y:33394,varname:node_8930,prsc:2,tex:641bb2dce818a8a499b537a1963889ac,ntxv:0,isnm:False|UVIN-6185-UVOUT,TEX-4430-TEX;proporder:4430;pass:END;sub:END;*/

Shader "Shader Forge/MyBlur" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay+1"
            "RenderType"="Overlay"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
                float4 node_1672 = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_9961 = 0.01;
                float2 node_6185 = (i.uv0+node_9961*float2(0,1));
                float4 node_8930 = tex2D(_MainTex,TRANSFORM_TEX(node_6185, _MainTex));
                float2 node_5429 = (i.uv0+node_9961*float2(0,-1));
                float4 _node_1044_copy = tex2D(_MainTex,TRANSFORM_TEX(node_5429, _MainTex));
                float2 node_4578 = (i.uv0+node_9961*float2(1,0));
                float4 _node_1044_copy_copy = tex2D(_MainTex,TRANSFORM_TEX(node_4578, _MainTex));
                float2 node_4968 = (i.uv0+node_9961*float2(-1,0));
                float4 _node_1044_copy_copy_copy = tex2D(_MainTex,TRANSFORM_TEX(node_4968, _MainTex));
                float3 finalColor = ((node_1672.rgb*0.2)+(node_8930.rgb*0.2)+(_node_1044_copy.rgb*0.2)+(_node_1044_copy_copy.rgb*0.2)+(_node_1044_copy_copy_copy.rgb*0.2));
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
