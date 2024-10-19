import { createContext, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { loginAPI, logoutAPI, registerAPI } from "../services/AuthService";
import { toast } from "react-toastify";
import React from "react";
import axios from "axios";

type UserContextType = {
  token: string | null;
  registerUser: (email: string, password: string) => void;
  loginUser: (email: string, password: string) => void;
  logout: () => void;
  isLoggedIn: () => boolean;
};

type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
  const navigate = useNavigate();
  const [token, setToken] = useState<string | null>(null);
  const [isReady, setIsReady] = useState(false);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      setToken(token);
      axios.defaults.headers.common["Authorization"] = "Bearer " + token;
    }
    setIsReady(true);
  }, []);

  const registerUser = async (
    email: string,
    password: string
  ) => {
    try {
      const response = await registerAPI(email, password);
      if (response) {
        toast.success("Register Success!");
        navigate("/login");
      }
    } catch {
      toast.warning("Server error occured")
    }
  };

  const loginUser = async (username: string, password: string) => {
    try {
      const response = await loginAPI(username, password);
      if (response) {
        localStorage.setItem("token", response.data.accessToken);
        setToken(response.data.accessToken);
        toast.success("Login Success!");
        navigate("/");
      }
    } catch {
      toast.warning("Server error occured")
    }
  };

  const isLoggedIn = () => {
    return !!token;
  };

  const logout = async () => {
    await logoutAPI();
    localStorage.removeItem("token");
    setToken("");
    navigate("/");
  };

  return (
    <UserContext.Provider
      value={{ loginUser, token, logout, isLoggedIn, registerUser }}
    >
      {isReady ? children : null}
    </UserContext.Provider>
  );
};

export const useAuth = () => React.useContext(UserContext);