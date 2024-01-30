import React from 'react'

const Login = () => {
  return (
    <div className='h-[80vh] w-full flex flex-col justify-center gap-[5rem] items-center relative'>
      <div className='flex justify-between items-center gap-[2rem] relative z-10'>
        <div className='w-[30vw] h-[5px] bg-black rounded-lg'></div>
        <h1 className='font-semibold text-[2.5rem] whitespace-nowrap'>login</h1>
        <div className='w-full h-[5px] bg-black rounded-lg'></div>
      </div>
      <form className="w-[25em]">
        <div className="mb-5">
          <label for="email" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">email</label>
          <input type="email" id="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="name@abc.com" required/>
        </div>
        <div class="mb-5">
          <label for="password" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">password</label>
          <input type="password" id="password" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="password" required/>
        </div>
        <button type="submit" className="text-white bg-blue-600 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">submit</button>
      </form>
    </div>
  )
}

export default Login