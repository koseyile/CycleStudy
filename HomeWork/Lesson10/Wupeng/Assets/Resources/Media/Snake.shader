Shader "Unlit/Snake"
{
    Properties
    {
        _EfffectTex ("_EffectTex", 2D) = "white" {}
        _Color("Color", Color) = (1, 1, 1, 1)
        _Lumination("Lumination", Float) = 1.0
        _IsEffect("IsEffect", Float) = 1.0
        _MatCap("MatCap", 2D) = "white"{}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass //shadow
        {
            Tags{ "LightMode" = "ShadowCaster"}
            CGPROGRAM
            #pragma vertex vs_main
            #pragma fragment ps_main

            #include "UnityCG.cginc"

            struct v2f
            {
                V2F_SHADOW_CASTER;
            };

            v2f vs_main(appdata_base v)
            {
                v2f o;
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
                return o;
            }

            fixed4 ps_main(v2f i) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(i)
            }

            ENDCG
        }

        Pass
        {
        Cull Off
        Tags{ "LightMode" = "ForwardBase" }
        CGPROGRAM
        #pragma multi_compile_fwdbase	
        #pragma vertex vs_main
        #pragma fragment ps_main

            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            fixed4 _Color;
            float _Lumination;
            sampler2D _Matcap;
            sampler2D _EfffectTex;
            float4 _EffectTex_ST;
            float _IsEffect;

            struct appdata
            {
                float4 vertex  : POSITION;
                float2 uv      : TEXCOORD0;
                float3 normal  : NORMAL;
                float4 tangent : TANGENT;
            };

            struct v2f
            {
                float2 uv       : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 pos   : SV_POSITION;
                float3 worldNormal : TEXCOORD2;
                float3 viewNormal : TEXCOORD3;
                float3 worldPos : TEXCOORD4;
                unityShadowCoord4 _ShadowCoord : TEXCOORD5;
            };

            v2f vs_main(appdata v)
            {
                v2f o;

                o.pos = UnityObjectToClipPos(v.vertex);

                o.uv = v.uv;

                UNITY_TRANSFER_FOG(o,o.pos);

                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

                float3 worldNormal = normalize(mul(v.normal, (float3x3)unity_ObjectToWorld).xyz);

                float3 viewNormal = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal).xyz);

                o.worldNormal = worldNormal;
                o.viewNormal = viewNormal;
                o.worldPos = worldPos;

                TRANSFER_SHADOW(o);

                return o;
            }

            fixed4 ps_main(v2f i) : SV_Target
            {
                //reflect
                float3 worldViewDir = normalize(i.worldPos - _WorldSpaceCameraPos);
                float3 n = dot(worldViewDir, i.worldNormal) * i.worldNormal;
                float3 reflect = worldViewDir - 2 * n;

                //matcap
                float3 sampleVertex = i.viewNormal;

                fixed4 col_matcap = tex2D(_Matcap, float2(sampleVertex.x * 0.5 + 0.7, sampleVertex.y * 0.5 + 0.5));

                fixed4 albedo = _Color;
                fixed4 finalcol = albedo * col_matcap * _Lumination * _LightColor0.rgba;
                
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, finalcol);

                //apply shadow 
                fixed shadow = SHADOW_ATTENUATION(i);
                fixed3 ambient = finalcol.rgb *shadow;

                finalcol.rgb += ambient;
                finalcol.rgb *= _Color.rgb;

                finalcol.rgb = pow(finalcol.rgb, 0.5);

                //effect

                fixed3 effect = tex2D(_EfffectTex, i.uv.xy).rgb * _IsEffect * (sin(_Time.y * 2) * 0.5 + 0.5);
                
                return fixed4(finalcol.rgb + effect, 1);
            }
            ENDCG
        }
    }
}
