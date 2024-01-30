import Home from "./components/home/Home"
import Login from "./components/home/Login"
import Register from "./components/home/Register"
import NotFound from "./components/shared/NotFound"

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    index: 1,
    path: '/login',
    element: <Login />
  },
  {
    index: 2,
    path: '/register',
    element: <Register />
  },
  {
    index: 100,
    path: '*',
    element: <NotFound />
  }
]

export default AppRoutes
