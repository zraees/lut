import { useContext, useState } from "react";
import { ThemeContext } from "../contexts/ThemeContext";
import { NavLink } from "react-router-dom";
import { LuMoonStar, LuSun } from "react-icons/lu";
import UserNav from "./user/UserNav";

const Header = () => {
  const { isDarkTheme, toggleTheme } = useContext(ThemeContext);

  return (
    <header className="p-3 mb-3 border-bottom">
      <div className="container">
        <div className="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
          <a
            href="/"
            className="d-flex align-items-center mb-2 mb-lg-0 link-body-emphasis text-decoration-none"
          >
            <svg
              className="bi me-2"
              width="40"
              height="32"
              role="img"
              aria-label="Bootstrap"
            >
              <use xlinkHref="#bootstrap"></use>
            </svg>
          </a>

          <ul className="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
            <li>
              {/* link-body-emphasis */}
              <NavLink to="/" className="nav-link px-2">
                Home
              </NavLink>
            </li>
            <li>
              <NavLink to="businesses" className="nav-link px-2">
                Find a Business
              </NavLink>
            </li>
            <li>
              <NavLink to="services" className="nav-link px-2">
                Services
              </NavLink>
            </li>
            <li>
              <NavLink to="about-us" className="nav-link px-2">
                About Us
              </NavLink>
            </li>
            <li className="nav-item dropdown">
              <a
                className="nav-link dropdown-toggle"
                href="#"
                role="button"
                data-bs-toggle="dropdown"
                aria-expanded="false"
              >
                Dropdown link
              </a>
              <ul className="dropdown-menu">
                <li>
                  <a className="dropdown-item" href="#">
                    Action
                  </a>
                </li>
                <li>
                  <a className="dropdown-item" href="#">
                    Another action
                  </a>
                </li>
                <li>
                  <a className="dropdown-item" href="#">
                    Something else here
                  </a>
                </li>
              </ul>
            </li>
          </ul>

          <form
            className="col-12 col-lg-auto mb-3 mb-lg-0 me-lg-3"
            role="search"
          >
            <input
              type="search"
              className="form-control"
              placeholder="Search..."
              aria-label="Search"
            />
          </form>

          <UserNav></UserNav>

          <button
            className="btn btn-secondary theme-toggle"
            id="themeToggle"
            onClick={() => toggleTheme(!isDarkTheme)}
          >
            {isDarkTheme ? <LuSun /> : <LuMoonStar />}
            {isDarkTheme ? " Light Mode" : " Dark Mode"}
          </button>
        </div>
      </div>
    </header>
  );
};

export default Header;
