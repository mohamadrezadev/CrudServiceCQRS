const colors = require('tailwindcss/colors')
const defaultTheme = require('tailwindcss/defaultTheme')
module.exports = {
    mode: 'jit',
    content: [
        './Views/**/*.cshtml',
        'node_modules/preline/dist/*.js',
    ],
    //darkMode: false, // or 'media' or 'class'
    darkMode: 'class',
    theme: {
        extend: {
            colors: {
                cyan: colors.cyan,
                primary: { "50": "#eff6ff", "100": "#dbeafe", "200": "#bfdbfe", "300": "#93c5fd", "400": "#60a5fa", "500": "#3b82f6", "600": "#2563eb", "700": "#1d4ed8", "800": "#1e40af", "900": "#1e3a8a", "950": "#172554" },
                primary: "#0c0c0d",
                secondary: "#1BCF84",
                acent1: "#8C4AF2",
                acent2: "#6F55F6",
                acent3: "#1BCF84",
                acent4: "#E25F25",
                acent5: "#369FFF",
                gray: "#515A5A",
                sitebg: "#f8f8f8",
                bgLight: "rgba(164, 229, 224, 0.45)",
                softLight: "rgba(255, 255, 255, 0.6)",

            },
            dropShadow: {
                xl: "0px 10px 20px 0px rgba(164, 229, 224, 0.15)",
            },
            container: {
                center: true,
                screens: {
                    sm: "100%",
                    md: "100%",
                    lg: "100%",
                    xl: "100%",
                },
            },
            fontSize: {
                sm: "12px",
                base: "14px",
                md: "16px",
                lg: "17px",
                xl: "18px",
                "2xl": "20px",
                "3xl": "22px",
                "4xl": "23px",
            },
            fontFamily: {
                sans: ['Inter var', ...defaultTheme.fontFamily.sans]
                'body': [
                    'Inter',
                    'ui-sans-serif',
                    'system-ui',
                    '-apple-system',
                    'system-ui',
                    'Segoe UI',
                    'Roboto',
                    'Helvetica Neue',
                    'Arial',
                    'Noto Sans',
                    'sans-serif',
                    'Apple Color Emoji',
                    'Segoe UI Emoji',
                    'Segoe UI Symbol',
                    'Noto Color Emoji'
                ],
                
            }

        },
        
    },
    variants: {
        extend: {},
    },
    plugins: [
        require('tailwindcss-textshadow'),
        require('preline/plugin'),
    ]
}