const defaultTheme = require("tailwindcss/defaultTheme");

module.exports = {
    content: [
        './**/*.html',
        './**/*.razor',
        './**/*.cs',
        '../Shared/**/*.html',
        '../Shared/**/*.razor',
        '../Shared/**/*.cs',
        "./wwwroot/**/*.html",
        "./Layout/**/*.{razor,cshtml,cs}",
        "./Core/**/*.{razor,cshtml,cs}",
        "./Models/**/*.{razor,cshtml,cs}",
        "./Pages/**/*.{razor,cshtml,cs}",
        "./Components/**/*.{razor,cshtml,cs}",

        './../Railwind/**/*.html',
        './../Railwind/**/*.razor',
        './../Railwind/**/*.cs',
        './../Railwind/Shared/**/*.html',
        './../Railwind/Shared/**/*.razor',
        './../Railwind/Shared/**/*.cs',
        "./../Railwind/wwwroot/**/*.html",
        "./../Railwind/Layout/**/*.{razor,cshtml,cs}",
        "./../Railwind/Core/**/*.{razor,cshtml,cs}",
        "./../Railwind/Models/**/*.{razor,cshtml,cs}",
        "./../Railwind/Pages/**/*.{razor,cshtml,cs}",
        "./../Railwind/Components/**/*.{razor,cshtml,cs}",
    ],
    theme: {
        extend: {
            fontFamily: {
                sans: ['Inter', 'sans-serif'],
                heading: ['Bebas Neue', 'sans-serif'],
                thickheading: ['Kumbh Sans', 'sans-serif'],
            },
            maxHeight: {
                '100': '25rem',   // 400px
                '104': '26rem',   // 416px
                '108': '27rem',   // 432px
                '112': '28rem',   // 448px
                '116': '29rem',   // 464px
                '120': '30rem',   // 480px
                '124': '31rem',   // 496px
                '128': '32rem',   // 512px
                '132': '33rem',   // 528px
                '136': '34rem',   // 544px
                '140': '35rem',   // 560px
                svh: '100svh', // Example custom max height
            },
            minHeight: {
                svh: '100svh', // Example custom max height
            },
            minWidth: {
                '96': '24rem', // Example custom min width
            },
            spacing: {
                '84': '21rem',  // 336px
                '88': '22rem',  // 352px
                '92': '23rem',  // 368px
                '94': '23.5rem', // 376px
            },
            colors: {
                'persimmon': {
                    '50': '#fff4f1',
                    '100': '#ffe5df',
                    '200': '#ffcfc5',
                    '300': '#ffaf9d',
                    '400': '#ff8064',
                    '500': '#ff6d4d',
                    '600': '#ed3c15',
                    '700': '#c82f0d',
                    '800': '#a52a0f',
                    '900': '#882914',
                    '950': '#4b1104',
                },
                'woodsmoke': {
                    '50': '#f5f6fa',
                    '100': '#ebedf3',
                    '200': '#d2d7e5',
                    '300': '#abb7ce',
                    '400': '#7d8fb3',
                    '500': '#5d729a',
                    '600': '#495a80',
                    '700': '#3c4968',
                    '800': '#353f57',
                    '900': '#2f374b',
                    '950': '#07080b',
                },
            },
        }
    },
    plugins: [
        require('@tailwindcss/forms'),
    ],
   
}
