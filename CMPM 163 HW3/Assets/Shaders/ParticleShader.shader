Shader "Custom/ParticleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_StartColor ("Start Color", Color) = (1,1,1,1)
		_EndColor ("End Color", Color) = (0,0,0,1)
		_Jiggle ("Jiggle", Float) = 1
		[MaterialToggle]
		_NoiseAffectsColor ("NoiseAffectsColor", Float) = 1
        //Define properties for Start and End Color
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Opaque" }
        LOD 100
        
        Blend One One
        ZWrite off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            struct appdata
            {
                float4 vertex : POSITION;
				float4 uv : TEXCOORD0;
				float3 noise : TEXCOORD1;
            };

            struct v2f
            {   
                float4 vertex : SV_POSITION;
				float4 uv : TEXCOORD0;
				float3 noise : TEXCOORD1;
            };

            sampler2D _MainTex;
			float4 _StartColor;
			float4 _EndColor;
			float _Jiggle;
			float _NoiseAffectsColor;
          

            v2f vert (appdata v)
            {
                v2f o;
				v.vertex.x += v.noise.x * _Jiggle * v.uv.z;
				v.vertex.y += v.noise.y * _Jiggle * v.uv.z;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv; //Correct this for particle shader
				o.noise = v.noise;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                //Get particle age percentage
				float age = i.uv.z;
                
                //Sample color from particle texture
				float4 texColor = tex2D(_MainTex, i.uv.xy);
                
				float4 startColor = _StartColor * texColor;
                //Find "start color"
				if(_NoiseAffectsColor == 1)
					startColor = (_StartColor + float4(i.noise * 2, texColor.a)) * texColor;

                //Find "end color"
				float4 endColor = _EndColor * texColor.a;


                //Do a linear interpolation of start color and end color based on particle age percentage			
                return lerp(startColor, endColor, age);
            }
            ENDCG
        }
    }
}
