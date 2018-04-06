// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Unlit/Color,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5764706,fgcg:0.7058824,fgcb:0.8784314,fgca:1,fgde:0.213,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:34207,y:32947,varname:node_9361,prsc:2|emission-4115-OUT;n:type:ShaderForge.SFN_SceneColor,id:5961,x:33107,y:33009,varname:node_5961,prsc:2|UVIN-449-UVOUT;n:type:ShaderForge.SFN_ScreenPos,id:7945,x:32438,y:33004,varname:node_7945,prsc:2,sctp:2;n:type:ShaderForge.SFN_Fresnel,id:502,x:32883,y:32702,varname:node_502,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3618,x:33107,y:32840,varname:node_3618,prsc:2|A-502-OUT,B-8941-OUT;n:type:ShaderForge.SFN_Vector1,id:7684,x:32365,y:33260,varname:node_7684,prsc:2,v1:3;n:type:ShaderForge.SFN_SceneColor,id:3276,x:33115,y:33193,varname:node_3276,prsc:2;n:type:ShaderForge.SFN_Add,id:4115,x:33857,y:33023,varname:node_4115,prsc:2|A-8508-OUT,B-2845-OUT;n:type:ShaderForge.SFN_OneMinus,id:8941,x:32883,y:32840,varname:node_8941,prsc:2|IN-3673-OUT;n:type:ShaderForge.SFN_Multiply,id:2845,x:33607,y:33209,varname:node_2845,prsc:2|A-3276-RGB,B-3423-OUT;n:type:ShaderForge.SFN_Multiply,id:8508,x:33607,y:33023,varname:node_8508,prsc:2|A-3618-OUT,B-5961-RGB,C-406-OUT;n:type:ShaderForge.SFN_Parallax,id:449,x:32705,y:33006,varname:node_449,prsc:2|UVIN-7945-UVOUT,HEI-9863-OUT,REF-3390-OUT;n:type:ShaderForge.SFN_Frac,id:9689,x:32883,y:33006,varname:node_9689,prsc:2|IN-449-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:6513,x:31793,y:33117,varname:node_6513,prsc:2|IN-5785-OUT;n:type:ShaderForge.SFN_Fresnel,id:3673,x:32538,y:33240,varname:node_3673,prsc:2|EXP-7684-OUT;n:type:ShaderForge.SFN_Fresnel,id:5785,x:31524,y:33078,varname:node_5785,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9131,x:31971,y:33178,varname:node_9131,prsc:2|A-6513-OUT,B-932-OUT,C-7786-OUT,D-7790-OUT;n:type:ShaderForge.SFN_Add,id:3390,x:32192,y:33154,varname:node_3390,prsc:2|A-9863-OUT,B-9131-OUT;n:type:ShaderForge.SFN_Vector1,id:9863,x:31770,y:33004,varname:node_9863,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:18,x:31124,y:33145,varname:node_18,prsc:2|IN-3631-OUT;n:type:ShaderForge.SFN_Power,id:7790,x:31440,y:33272,varname:node_7790,prsc:2|VAL-18-OUT,EXP-6736-OUT;n:type:ShaderForge.SFN_Vector1,id:6736,x:31124,y:33314,varname:node_6736,prsc:2,v1:2;n:type:ShaderForge.SFN_If,id:594,x:30535,y:33196,varname:node_594,prsc:2|A-5045-OUT,B-3145-OUT,GT-9850-OUT,EQ-9850-OUT,LT-5045-OUT;n:type:ShaderForge.SFN_Vector1,id:9976,x:29823,y:33197,varname:node_9976,prsc:2,v1:6;n:type:ShaderForge.SFN_Vector1,id:9850,x:30317,y:33390,varname:node_9850,prsc:2,v1:0;n:type:ShaderForge.SFN_DepthBlend,id:5045,x:30010,y:33203,varname:node_5045,prsc:2|DIST-9976-OUT;n:type:ShaderForge.SFN_Vector1,id:3145,x:30316,y:33333,varname:node_3145,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:3631,x:30736,y:33045,varname:node_3631,prsc:2|A-6781-OUT,B-9305-OUT,C-594-OUT;n:type:ShaderForge.SFN_OneMinus,id:6781,x:30535,y:32996,varname:node_6781,prsc:2|IN-5045-OUT;n:type:ShaderForge.SFN_Vector1,id:9305,x:30535,y:33122,varname:node_9305,prsc:2,v1:4;n:type:ShaderForge.SFN_Slider,id:932,x:31636,y:33308,ptovrint:False,ptlb:NoiseHeight,ptin:_NoiseHeight,varname:node_932,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:8;n:type:ShaderForge.SFN_ScreenPos,id:9190,x:30845,y:33659,varname:node_9190,prsc:2,sctp:2;n:type:ShaderForge.SFN_Noise,id:827,x:31373,y:33656,varname:node_827,prsc:2|XY-3195-OUT;n:type:ShaderForge.SFN_Time,id:1596,x:30990,y:33730,varname:node_1596,prsc:2;n:type:ShaderForge.SFN_Add,id:3195,x:31204,y:33656,varname:node_3195,prsc:2|A-9190-UVOUT,B-1596-TSL;n:type:ShaderForge.SFN_Vector1,id:8399,x:32465,y:33498,varname:node_8399,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:3423,x:33431,y:33435,varname:node_3423,prsc:2|IN-967-OUT;n:type:ShaderForge.SFN_Multiply,id:9176,x:32698,y:33428,varname:node_9176,prsc:2|A-6781-OUT,B-8399-OUT;n:type:ShaderForge.SFN_Power,id:9630,x:32948,y:33448,varname:node_9630,prsc:2|VAL-9176-OUT,EXP-5715-OUT;n:type:ShaderForge.SFN_Vector1,id:5715,x:32698,y:33585,varname:node_5715,prsc:2,v1:20;n:type:ShaderForge.SFN_Add,id:967,x:33127,y:33430,varname:node_967,prsc:2|A-3673-OUT,B-9630-OUT;n:type:ShaderForge.SFN_OneMinus,id:406,x:33409,y:33136,varname:node_406,prsc:2|IN-967-OUT;n:type:ShaderForge.SFN_Tex2d,id:8599,x:31349,y:33838,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_8599,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2c29c08dd1c0b6749b7cd0fcff7a29fd,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7722,x:31552,y:33643,varname:node_7722,prsc:2|A-827-OUT,B-8599-R,C-2461-OUT;n:type:ShaderForge.SFN_OneMinus,id:7786,x:31745,y:33643,varname:node_7786,prsc:2|IN-7722-OUT;n:type:ShaderForge.SFN_Slider,id:2461,x:31192,y:34045,ptovrint:False,ptlb:Gray,ptin:_Gray,varname:node_2461,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5791031,max:1;proporder:932-8599-2461;pass:END;sub:END;*/

Shader "Shader Forge/CrystalBall" {
    Properties {
        _NoiseHeight ("NoiseHeight", Range(0, 8)) = 0
        _Noise ("Noise", 2D) = "white" {}
        _Gray ("Gray", Range(0, 1)) = 0.5791031
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ "Refraction" }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D Refraction;
            uniform sampler2D _CameraDepthTexture;
            uniform float _NoiseHeight;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Gray;
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
                float4 projPos : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = tex2D(Refraction, sceneUVs);
////// Lighting:
////// Emissive:
                float node_3673 = pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0);
                float node_9863 = 0.5;
                float4 node_1596 = _Time;
                float2 node_3195 = (sceneUVs.rg+node_1596.r);
                float2 node_827_skew = node_3195 + 0.2127+node_3195.x*0.3713*node_3195.y;
                float2 node_827_rnd = 4.789*sin(489.123*(node_827_skew));
                float node_827 = frac(node_827_rnd.x*node_827_rnd.y*(1+node_827_skew.x));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_5045 = saturate((sceneZ-partZ)/6.0);
                float node_6781 = (1.0 - node_5045);
                float node_594_if_leA = step(node_5045,1.0);
                float node_594_if_leB = step(1.0,node_5045);
                float node_9850 = 0.0;
                float2 node_449 = (0.05*(node_9863 - (node_9863+((1.0 - (1.0-max(0,dot(normalDirection, viewDirection))))*_NoiseHeight*(1.0 - (node_827*_Noise_var.r*_Gray))*pow(saturate((node_6781*4.0*lerp((node_594_if_leA*node_5045)+(node_594_if_leB*node_9850),node_9850,node_594_if_leA*node_594_if_leB))),2.0))))*mul(tangentTransform, viewDirection).xy + sceneUVs.rg);
                float node_967 = (node_3673+pow((node_6781*1.0),20.0));
                float3 emissive = ((((1.0-max(0,dot(normalDirection, viewDirection)))*(1.0 - node_3673))*tex2D( Refraction, node_449.rg).rgb*(1.0 - node_967))+(sceneColor.rgb*saturate(node_967)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Unlit/Color"
    CustomEditor "ShaderForgeMaterialInspector"
}
