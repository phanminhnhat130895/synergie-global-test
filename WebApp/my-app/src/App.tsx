import { Outlet } from 'react-router-dom';
import './App.css';
import { UserProvider } from './hooks/useAuth';
import { ToastContainer } from 'react-toastify';
import { Provider } from 'react-redux';
import store from './store/store';

function App() {
  return (
    <>
      <UserProvider>
        <Provider store={store}>
          <Outlet />
          <ToastContainer />
        </Provider>
      </UserProvider>
    </>
  );
}

export default App;
