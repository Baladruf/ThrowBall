Shader "Unlit/Sin"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_SpeedSin("Speed sinus", float) = 10
		_PowerSin("Power sinus", float) = 0.01
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"


			sampler2D _MainTex;
			float _SpeedSin;
			float _PowerSin;


			fixed4 frag(v2f_img i) : COLOR
			{
				float2 uv = i.uv;
				uv.x = uv.x + sin((uv.y + _Time.y) * _SpeedSin) * _PowerSin;
				
				fixed4 col = tex2D(_MainTex, uv);
				return col;
			}
			ENDCG
		}
	}
}
