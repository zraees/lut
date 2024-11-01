import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import App from "./App";

import { Index as Home } from "./pages/home/Index";
import { Index as Services } from "./pages/services/Index";
import { Index as Businesses } from "./pages/businesses/Index";
import { Index as AboutUs } from "./pages/about-us/Index";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "/", element: <Home /> },
      { path: "businesses", element: <Businesses /> },
      { path: "services", element: <Services /> },
      { path: "about-us", element: <AboutUs /> },
    ],
  },
]);

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <RouterProvider router={router}></RouterProvider>
  </StrictMode>
);
