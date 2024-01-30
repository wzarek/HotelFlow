import React from 'react'
import {ReactComponent as Error404} from '../../../imgs/404.svg'

const NotFound = () => {
  return (
    <div className='h-[80vh] flex justify-center items-center'>
        <Error404 className='w-[50%]'/>
    </div>
  )
}

export default NotFound