Shader "Custom/PostEffectShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_DistortionAmount("Distortion", Float) = 20
	}
		SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				float _DistortionAmount;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;

			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, IN.uv + float2(sin(IN.vertex.y / _DistortionAmount + _Time[2]) / 10, sin(IN.vertex.x / _DistortionAmount + _Time[1]) / 10));
			// just invert the colors

			return col;
		}
		ENDCG
	}
		}
}
