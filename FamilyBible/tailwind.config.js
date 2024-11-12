/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["*.{html,js}", "../FamilyBible.api/Components/*.razor"],
  theme: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography')
  ]
}

