import { useAuth } from "../../hooks/useAuth";
import './topBar.css';

export const TopBarComponent = () => {
    const { logoutUser } = useAuth();

    const logout = async () => {
        await logoutUser();
    }

    return (
        <div className="top-bar-container">
            <button className="no-outline-button" onClick={logout}>Logout</button>
        </div>
    )
}