import Home from "./components/home/Home"
import Login from "./components/shared/pages/Login"
import Logout from "./components/shared/pages/Logout"
import Register from "./components/shared/pages/Register"
import NotFound from "./components/shared/pages/NotFound"
import RoomSearch from "./components/shared/pages/RoomSearch"
import UsersListPage from "./components/admin/UsersListPage"
import { authConstants } from "./services/auth/authorizationServices"
import { Navigate } from "react-router-dom"
import ClientPanel from "./components/client/ClientPanel"

const AppRoutes = [
  {
    index: true,
    path: '/',
    role: authConstants.guest,
    element: <Home />
  },
  {
    index: 1,
    path: '/login',
    role: authConstants.guest,
    element: <Login />
  },
  {
    index: 2,
    path: '/logout',
    role: authConstants.guest,
    element: <Logout />
  },
  {
    index: 3,
    path: '/register',
    role: authConstants.guest,
    element: <Register />
  },
  {
    index: 4,
    path: '/find-room',
    role: authConstants.guest,
    element: <RoomSearch />
  },
  {
    index: 10,
    path: '/client/panel',
    role: authConstants.client,
    element: <ClientPanel />
  },
  {
    index: 50,
    path: '/admin/users-list',
    role: authConstants.admin,
    element: <UsersListPage />
  },
  {
    index: 100,
    path: '/not-found',
    role: authConstants.guest,
    element: <NotFound />
  },
  {
    index: 100,
    path: '*',
    role: authConstants.guest,
    element: <Navigate to='/not-found' />
  }
]

export default AppRoutes
