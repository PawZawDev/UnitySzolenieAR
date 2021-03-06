﻿Shader "DrawCircleShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		CX("Center-X", Float) = 30
		CY("Center-Y", Float) = 130
		R("Radius", Float) = 20
		W("Width", Float) = 0.005
		A("AspectRatio", Float) = 1
	}
		SubShader
		{
			Pass{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag


				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};
				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};
				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				};

				sampler2D _MainTex;
				float CX;
				float CY;
				float R;
				float W;
				float A;
				fixed4 frag(v2f i) : SV_Target
				{
					fixed4 col = tex2D(_MainTex, float2(i.uv.x, 1 - i.uv.y));
					CX = CX * A;
					float x = i.uv.x * A;
					float y = i.uv.y;
					//GORA
					if (x >= CX - R && x <= CX + R && y >= (CY + R) - W && y <= (CY + R)+W)
					{
						col = fixed4(1, 0, 0, 1);
					}
					//DOL
					else if (x >= CX - R && x <= CX + R && y >= (CY - R) - W && y <= (CY - R) + W)
					{
						col = fixed4(0, 1, 0, 1);
					}
					//prawy
					else if (y >= CY - R && y <= CY + R && x >= (CX - R) - W && x <= (CX - R) + W)
					{
						col = fixed4(0, 0, 1, 1);
					}
					//lewy
					else if (y >= CY - R && y <= CY + R && x >= (CX + R) - W && x <= (CX + R) + W)
					{
						col = fixed4(1, 1, 0, 1);
					}
					return col;
				}
				ENDCG
			}
		}
}
