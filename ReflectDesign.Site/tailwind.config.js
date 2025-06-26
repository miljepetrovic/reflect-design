/**@type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml',
    ],
    theme: {
        extend: {
          colors: {
            primary: '#000000',
            'primary-dark': '#000000',
            background: '#ffffff',
            foreground: '#000000',
          }
        }
    },
    plugins: [],
}