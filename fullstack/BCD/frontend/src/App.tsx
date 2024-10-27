import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import Header from "./components/Header";
import Footer from "./components/Footer";
import { Outlet } from "react-router-dom";

function App() {
  return (
    <div> 
        <Header></Header> 
        <Outlet></Outlet>
        <Footer></Footer>
    </div>
  );
}

export default App;
