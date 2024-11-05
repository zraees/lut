import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import Header from "./components/Header";
import Footer from "./components/Footer";
import { Outlet } from "react-router-dom";
import { ThemeContext } from "./contexts/ThemeContext";
import { useContext } from "react";

function App() {
  const { isDarkTheme } = useContext(ThemeContext);
  //console.log('isDark', isDark);
  return (
    <div data-bs-theme={isDarkTheme ? "dark" : "light"} className={isDarkTheme ? "bg-dark text-white" : "bg-light text-dark"}>
      <Header></Header>
      <Outlet></Outlet>
      <Footer></Footer>
    </div>
  );
}

export default App;
