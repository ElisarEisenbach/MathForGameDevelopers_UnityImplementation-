Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_ForwardVec("Forward vector", Vector) = (.25, .5, .5, 1)
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100
			Cull off
			Pass
			{
				CGPROGRAM



				#pragma vertex vert
				#pragma fragment frag
				// make fog work
				#pragma multi_compile_fog

				#include "UnityCG.cginc"


				uniform float4x4 _mymatrix;

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					float4 vertex : SV_POSITION;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float4 _ForwardVec;

				v2f vert(appdata v)
				{
					//float4 vecUp = (0,1,0);
					//float3 right =  cross(vecUp,_ForwardVec);
					//float4x4 mPlayer = 
					//
					//(_ForwardVec.x, _ForwardVec.y, _ForwardVec.z, _ForwardVec.w,
					//    vecUp.x, vecUp.y, vecUp.z, vecUp.w,
					//    right.x, right.y, right.z, 1,
					//    0,0,0,1);

					v2f o;
					v.vertex = mul(_mymatrix,v.vertex);
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					// sample the texture
					fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG



		}



		}

}


