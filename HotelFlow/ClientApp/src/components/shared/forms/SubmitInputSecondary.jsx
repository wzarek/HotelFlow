import React from 'react'

const SubmitInputSecondary = ({name, text, classes}) => {
  const classList = `text-white bg-blue-600 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center ${classes}`

  return (
      <button type="submit" id={name} name={name} className={classList}>{text}</button>
  )
}

export default SubmitInputSecondary