import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import App from "./App";
import BusinessList from "./features/businesses/BusinessList";
import Home from "./pages/Home";

const router = createBrowserRouter([
  {
    path: "/", element: <App />, 
    children: [
      { path: "/", element: <Home /> },
      { path: "businesses", element: <BusinessList /> },
    ],
  },
]);

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <RouterProvider router={router}></RouterProvider>
  </StrictMode>
);
