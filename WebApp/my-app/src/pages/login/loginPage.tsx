import { useState } from "react";
import { toast } from "react-toastify";
import { useAuth } from "../../hooks/useAuth";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const { loginUser } = useAuth();
    const navigate = useNavigate();

    const login = async () => {
        if (!email || !password) {
            toast.error("Email or password is empty.");
            return;
        }

        await loginUser(email, password);
    }

    const goToRegister = () => {
        navigate("/register");
    }

    return (
        <div className="page">
            <h2>Login Page</h2>
            <input className="input-control" name="email" placeholder="Email" type="text" 
                value={email} onChange={(e) => setEmail(e.target.value)} />
            <input className="input-control" name="password" placeholder="Password" type="password" 
                value={password} onChange={(e) => setPassword(e.target.value)} />
            <button className="button-control primary-button" onClick={login}>Login</button>
            <button className="no-outline-button" onClick={goToRegister}>Register</button>
        </div>
    )
}

export default LoginPage;