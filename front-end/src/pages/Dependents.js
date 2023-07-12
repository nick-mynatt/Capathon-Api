import React from 'react'
import UserCard from '../components/common/UserCard'


function Dependents() {
  return (
    <div>
      <div className="text-sm breadcrumbs">
        <ul>
          <li><a>Home</a></li>
          <li><a>Dependents</a></li>
        </ul>
      </div>
        <h1>Dependents</h1>
        <UserCard />
    </div>
  )
}

export default Dependents