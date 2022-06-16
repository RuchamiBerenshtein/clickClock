import React, { useState } from "react";
import { Link } from "react-router-dom";
import { UserOutlined } from '@ant-design/icons';
import { useNavigate } from "react-router-dom";
import { Input } from 'antd';
import Navigation from "./Navigation";

function Login() {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const innerLogin = (e) => {
        // יש לקרוא לפונקציה זו כדי למנוע את הטעינה האוטמטית של העמוד שקוראת בלחיצה על סבמיט
        e.preventDefault();
        let token
        //nead to get token in server call
        sessionStorage.getItem('token', JSON.stringify(token));
        navigate('/')
        // signin(username, password);
    }

    return (
        <div>
            <Navigation />
            <br></br>
            Login!!!

            <form onSubmit={(e) => innerLogin(e)}>
            <Input type="text" placeholder="username" value={username} onChange={e => setUsername(e.target.value)} prefix={<UserOutlined />} /> <br />
                <Input type="password" placeholder="password" value={password} onChange={e => setPassword(e.target.value)} /> <br />
                <button type="submit"> Login </button>
            </form>
        </div>
    )
}

export default Login;
