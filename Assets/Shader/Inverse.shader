Shader "Unlit/Inverse"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
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
			
			
			fixed4 frag (v2f_img i) : COLOR
			{
				float2 uv = i.uv;
				uv.x = 1 - uv.x;

				fixed4 col = tex2D(_MainTex, uv);
				return col;
			}
			ENDCG
		}
	}
}
