import Home from "./components/home/Home"
import Login from "./components/shared/pages/Login"
import Register from "./components/shared/pages/Register"
import NotFound from "./components/shared/pages/NotFound"
import RoomSearch from "./components/shared/pages/RoomSearch"
import UsersListPage from "./components/admin/UsersListPage"
import { authConstants } from "./services/auth/authorizationServices"

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
    path: '/register',
    role: authConstants.guest,
    element: <Register />
  },
  {
    index: 3,
    path: '/find-room',
    role: authConstants.guest,
    element: <RoomSearch />
  },
  {
    index: 4,
    path: '/admin/users-list',
    role: authConstants.admin,
    element: <UsersListPage />
  },
  {
    index: 100,
    path: '*',
    role: authConstants.guest,
    element: <NotFound />
  }
]

export default AppRoutes
