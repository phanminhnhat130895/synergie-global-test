import { useState } from "react";
import { useAuth } from "../../hooks/useAuth";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";

const RegisterPage = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const { registerUser } = useAuth();
    const navigate = useNavigate();

    const register = async () => {
        if (!email || !password) {
            toast.error("Email or password is empty.");
            return;
        }

        if (password !== confirmPassword) {
            toast.error("Password is not match.");
            return;
        }

        await registerUser(email, password);
    }

    const goToLogin = () => {
        navigate("/login");
    }

    return (
        <div className="page">
            <h2>Register Page</h2>
            <input className="input-control" name="email" placeholder="Email" type="text" 
                value={email} onChange={(e) => setEmail(e.target.value)} />
            <input className="input-control" name="password" placeholder="Password" type="password" 
                value={password} onChange={(e) => setPassword(e.target.value)} />
            <input className="input-control" name="password" placeholder="Confirm Password" type="password" 
                value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} />
            <button className="button-control primary-button" onClick={register}>Register</button>
            <button className="no-outline-button" onClick={goToLogin}>Login</button>
        </div>
    )
}

export default RegisterPage;