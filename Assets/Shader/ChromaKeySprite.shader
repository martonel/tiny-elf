Shader "Custom/ChromaKeySprite"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "yellow" {}
        _KeyColor ("Key Color", Color) = (255,255,1,1)
        _Threshold ("Threshold", Range(0,1)) = 0.15
        _Smoothness ("Edge Smoothness", Range(0,1)) = 0.05
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Sprite"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex   : POSITION;
                float2 uv       : TEXCOORD0;
                float4 color    : COLOR;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv     : TEXCOORD0;
                float4 color  : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _KeyColor;
            float _Threshold;
            float _Smoothness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * i.color;

                // Színkülönbség számítása
                float diff = distance(col.rgb, _KeyColor.rgb);

                // Smooth alpha
                float alpha = smoothstep(_Threshold, _Threshold + _Smoothness, diff);

                col.a *= alpha;
                return col;
            }
            ENDCG
        }
    }
}
