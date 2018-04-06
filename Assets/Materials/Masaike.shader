// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:6,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33597,y:32338,varname:node_9361,prsc:2|custl-8958-OUT;n:type:ShaderForge.SFN_VertexColor,id:1358,x:33156,y:32719,varname:node_1358,prsc:2;n:type:ShaderForge.SFN_SceneColor,id:8625,x:33156,y:32579,varname:node_8625,prsc:2|UVIN-6716-OUT;n:type:ShaderForge.SFN_ScreenPos,id:2321,x:31902,y:32422,varname:node_2321,prsc:2,sctp:2;n:type:ShaderForge.SFN_Multiply,id:2848,x:32109,y:32719,varname:node_2848,prsc:2|A-2321-V,B-8467-OUT;n:type:ShaderForge.SFN_Trunc,id:5119,x:32285,y:32719,varname:node_5119,prsc:2|IN-2848-OUT;n:type:ShaderForge.SFN_Time,id:7219,x:31902,y:32868,varname:node_7219,prsc:2;n:type:ShaderForge.SFN_Frac,id:6716,x:32985,y:32579,varname:node_6716,prsc:2|IN-2450-OUT;n:type:ShaderForge.SFN_Add,id:4703,x:32455,y:32719,varname:node_4703,prsc:2|A-5119-OUT,B-6646-OUT;n:type:ShaderForge.SFN_Sin,id:4027,x:32109,y:32868,varname:node_4027,prsc:2|IN-7219-T;n:type:ShaderForge.SFN_Multiply,id:8958,x:33373,y:32579,varname:node_8958,prsc:2|A-8625-RGB,B-1358-RGB;n:type:ShaderForge.SFN_ValueProperty,id:5034,x:31713,y:32753,ptovrint:False,ptlb:UnitSize,ptin:_UnitSize,varname:node_5034,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:100;n:type:ShaderForge.SFN_ScreenParameters,id:4168,x:31713,y:32579,varname:node_4168,prsc:2;n:type:ShaderForge.SFN_Divide,id:8467,x:31902,y:32719,varname:node_8467,prsc:2|A-4168-PXH,B-5034-OUT;n:type:ShaderForge.SFN_Divide,id:5309,x:31902,y:32579,varname:node_5309,prsc:2|A-4168-PXW,B-5034-OUT;n:type:ShaderForge.SFN_Multiply,id:3980,x:32109,y:32579,varname:node_3980,prsc:2|A-2321-U,B-5309-OUT;n:type:ShaderForge.SFN_Trunc,id:8783,x:32285,y:32579,varname:node_8783,prsc:2|IN-3980-OUT;n:type:ShaderForge.SFN_Add,id:8255,x:32455,y:32579,varname:node_8255,prsc:2|A-8783-OUT,B-6646-OUT;n:type:ShaderForge.SFN_Divide,id:3341,x:32648,y:32579,varname:node_3341,prsc:2|A-8255-OUT,B-5309-OUT;n:type:ShaderForge.SFN_Divide,id:9185,x:32648,y:32719,varname:node_9185,prsc:2|A-4703-OUT,B-8467-OUT;n:type:ShaderForge.SFN_Append,id:2450,x:32820,y:32579,varname:node_2450,prsc:2|A-3341-OUT,B-9185-OUT;n:type:ShaderForge.SFN_Vector1,id:8105,x:32109,y:33015,varname:node_8105,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:6646,x:32285,y:32868,varname:node_6646,prsc:2|A-4027-OUT,B-8105-OUT;proporder:5034;pass:END;sub:END;*/

Shader "Shader Forge/Masaike" {
    Properties {
        _UnitSize ("UnitSize", Float ) = 100
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
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
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float _UnitSize;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
                float node_5309 = (_ScreenParams.r/_UnitSize);
                float4 node_7219 = _Time;
                float node_4027 = sin(node_7219.g);
                float node_8105 = 0.5;
                float node_6646 = (node_4027+node_8105);
                float node_8467 = (_ScreenParams.g/_UnitSize);
                float3 finalColor = (tex2D( _GrabTexture, frac(float2(((trunc((sceneUVs.r*node_5309))+node_6646)/node_5309),((trunc((sceneUVs.g*node_8467))+node_6646)/node_8467)))).rgb*i.vertexColor.rgb);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
