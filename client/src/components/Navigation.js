import react from "react";
import { Link } from "react-router-dom";
import Home  from'./Home';

function Navigation() {
    return (
        <div className="navigation">
            <Link to="/login">Login</Link>
            <Link to="/Game">Game</Link>
            <Link to="/about">About</Link>
            <Link to="/creatGame">CreatGame</Link>
            <Link to="/feedback">Feedback</Link>
            <Link to="/">Home</Link>
        </div>
    );
}

export default Navigation;


