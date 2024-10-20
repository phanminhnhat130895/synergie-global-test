import axios from "axios";
import { handleError } from "../common/helper/ErrorHandler";
import { AuthenticationUserResponse } from "../models/authenticationUserResponse";
import { CreateUserResponse } from "../models/createUserResponse";

const api = process.env.REACT_APP_API_BASE_URL;

export const loginAPI = async (email: string, password: string) => {
  try {
    const data = await axios.post<AuthenticationUserResponse>(api + "user/authenticate", {
      email: email,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const registerAPI = async (
  email: string,
  password: string
) => {
  try {
    const data = await axios.post<CreateUserResponse>(api + "user", {
      email: email,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const logoutAPI = async () => {
  try {
    const accessToken = localStorage.getItem("token");
    await axios.post(api + "user/logout", {
      token: accessToken
    });
  } catch (error) {
    handleError(error);
  }
}