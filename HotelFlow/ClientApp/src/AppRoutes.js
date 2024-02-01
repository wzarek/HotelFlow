import Home from "./components/home/Home"
import Login from "./components/shared/pages/Login"
import Logout from "./components/shared/pages/Logout"
import Register from "./components/shared/pages/Register"
import NotFound from "./components/shared/pages/NotFound"
import RoomSearch from "./components/shared/pages/RoomSearch"
import AdminPanel from "./components/admin/AdminPanel"
import { authConstants } from "./services/auth/authorizationServices"
import { Navigate } from "react-router-dom"
import ClientPanel from "./components/client/ClientPanel"
import EmployeePanel from "./components/employee/EmployeePanel"
import ReservationCreation from "./components/client/ReservationCreation"

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
    index: 11,
    path: '/client/create-reservation',
    role: authConstants.client,
    element: <ReservationCreation />
  },
  {
    index: 30,
    path: '/employee/panel',
    role: authConstants.employee,
    element: <EmployeePanel />
  },
  {
    index: 50,
    path: '/admin/panel',
    role: authConstants.admin,
    element: <AdminPanel />
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
