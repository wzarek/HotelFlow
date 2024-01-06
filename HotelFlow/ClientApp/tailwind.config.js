/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {
      keyframes: {
        glow: {
          '0%, 25%, 75%, 100%': { boxShadow: 'unset' },
          '50%': { boxShadow: '0 0 50px #48abe0' },
        },
        buttonDown: {
          '0%, 60%': { filter: 'unset', transform: 'translateY(0)' },
          '50%': { filter: 'drop-shadow(0 0 50px #48abe0)' },
          '70%': { transform: 'translateY(-5%)'},
          '75%': { transform: 'translateY(8%)'},
          '80%': { transform: 'translateY(-3%)'},
          '85%': { transform: 'translateY(6%)'},
          '95%, 100%': { transform: 'translateY(0)'}
        }
      },
      animation: {
        'bounce-slow': 'bounce 2s infinite',
        'glow': 'glow 5s infinite',
        'button-down': 'buttonDown 5s infinite'
      }
    },
  },
  plugins: [],
}

