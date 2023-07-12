import logo from './logo.svg';
import './App.css';
import SideNav from './components/common/SideNav';
import Navbar from './components/common/Navbar';
import UserCard from './components/common/UserCard';
import { Link, BrowserRouter, Router, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';
import Dependents from './pages/Dependents';
import Locations from './pages/Locations';
import LoginPage from './pages/LoginPage';
import SignupPage from './pages/SignupPage';

function App() {
  return (

    <BrowserRouter>
      <Navbar />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/dependents" element={<Dependents/>} />
        <Route path='/Locations' element={<Locations />} />
        <Route path='/Login' element={<LoginPage />} />
        <Route path='/Signup' element={<SignupPage />} />
        
      </Routes>
    </BrowserRouter>
  );
}

export default App;
