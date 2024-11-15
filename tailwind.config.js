/** @type {import('tailwindcss').Config} */
export default {
  content: ['./src/**/*.{html,js,jsx,vue}'],
  theme: {
    extend: {},
  },
  plugins: [
    function ({ addUtilities }) {
      addUtilities({
        '.hide-scrollbar': {
          '-ms-overflow-style': 'none' /* IE и Edge */,
          'scrollbar-width': 'none' /* Firefox */,
        },
        '.hide-scrollbar::-webkit-scrollbar': {
          display: 'none' /* Chrome, Safari, Opera */,
        },
      })
    },
  ],
}
