Shader "Custom/OutLineShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

		_OutlineColor("OutlineColor", Color) = (1,1,1,1)
			_Outline("Outline", Range(0,10))=0.0
    }
    SubShader
    {
		Tags{"Queue" = "Transparent" "RenderType" = "Transparent"}
		CGPROGRAM
        #pragma surface surf Lambert

	    struct Input
		{
			float2 uv_MainTex;
        };
		sampler2D _MainTex;

		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
		}
		ENDCG

		Pass
		{
			Cull Front
			CGPROGRAM

#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

			struct appdata
		    {
			    float4 vertex:POSITION;
			    float3 normal:NORMAL;
            };
		struct v2f
		{
			float4 pos:SV_POSITION;
			float4 color:COLOR;
		};

		float _Outline;
		float4 _OutlineColor;

		v2f vert(appdata v)
		{
			v2f o;

			o.pos = UnityObjectToClipPos(v.vertex);
			float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
			float2 offset = TransformViewToProjection(norm.xy);
			o.pos.xy += offset * o.pos.z * _Outline;
			o.color = _OutlineColor;

			return o;
		}

		fixed4 frag(v2f i):SV_Target
		{
			return i.color;
		}

			ENDCG
		}
    }
    FallBack "Diffuse"
}
