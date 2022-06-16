import { Link } from "react-router-dom";
import Navigation from "./Navigation";


function About() {

    // if (!(sessionStorage.getItem('token'))) {
    //     location.href = '/login.html';
    // }

    return (
        <div>
            <Navigation/>
            <br></br>
            <div>About!!!</div>
        </div>

    )
}

export default About;
