import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import App from "./App";

import { Index as Home } from "./pages/home/Index";
import { Index as Services } from "./pages/services/Index";
import { Index as Businesses } from "./pages/businesses/Index";
import { Index as AboutUs } from "./pages/about-us/Index";
import { ThemeProvider } from "./contexts/ThemeContext";
import BusinessDetail from "./components/business/BusinessDetail";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "/", element: <Home /> },
      { path: "businesses", element: <Businesses /> },
      { path: "business-detail/:id", element: <BusinessDetail /> },
      { path: "services", element: <Services /> },
      { path: "about-us", element: <AboutUs /> },
    ],
  },
]);

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <ThemeProvider>
      <RouterProvider router={router}></RouterProvider>
    </ThemeProvider>
  </StrictMode>
);
