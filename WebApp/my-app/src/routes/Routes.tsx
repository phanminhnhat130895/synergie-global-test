import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import ProtectedRoute from "./ProtectedRoute";
import LoginPage from "../pages/login/loginPage";
import RegisterPage from "../pages/register/registerPage";
import FlashCardPage from "../pages/flash-card/flashCardPage";
import AddFlashCardPage from "../pages/add-flash-card/addFlashCardPage";

export const router = createBrowserRouter([
    {
      path: "/",
      element: <App />,
      children: [
        { path: "login", element: <LoginPage /> },
        { path: "register", element: <RegisterPage /> },
        {
          path: "",
          element: (
            <ProtectedRoute>
             <FlashCardPage />
            </ProtectedRoute>
          ),
        },
        {
            path: "add-flash-card",
            element: (
              <ProtectedRoute>
               <AddFlashCardPage />
              </ProtectedRoute>
            ),
          }
      ],
    },
  ]);