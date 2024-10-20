import { Outlet } from 'react-router-dom';
import './App.css';
import { UserProvider } from './hooks/useAuth';
import { ToastContainer } from 'react-toastify';
import { Provider } from 'react-redux';
import store from './store/store';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  return (
    <>
      <UserProvider>
        <Provider store={store}>
          <Outlet />
          <ToastContainer
          position="top-right"
          autoClose={5000}
          hideProgressBar={false}
          newestOnTop={false}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss
          draggable
          pauseOnHover
          theme="light" />
        </Provider>
      </UserProvider>
    </>
  );
}

export default App;
