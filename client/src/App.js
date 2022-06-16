import logo from './logo.svg';
import './App.css';
// import Navigation from './components/Navigation';
import { Route, Router, Routes } from 'react-router';
import Home from './components/Home';
import Login from './components/Login';
import Game from './components/Game';
import About from './components/About';
import CreatGame from './components/CreatGame';
import Feedback from './components/Feedback';
function App() {

  return (
    <div className="App">
      <Routes>
        <Route  path="/login" element={<Login/>}/>
        <Route  path="/Game" element={<Game/>}/>
        <Route  path="/about" element={<About/>}/>
        <Route  path="/creatGame" element={<CreatGame/>}/>
        <Route  path="/feedback" element={<Feedback/>}/>
        <Route exact path="/" element={<Home/>}/>

      </Routes>
    </div>
  );
}




export default App;
