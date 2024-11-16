import { useState } from "react";

const UserNav = () => {

    const [isOpen, setIsOpen] = useState(false);
    const toggleOpen = () => setIsOpen(!isOpen);
  
    const menuClass = `dropdown-menu${isOpen ? " show" : ""}  text-small`;
  
    return (
        <div className="dropdown text-end" onClick={()=>toggleOpen()}>
        <a
          href="#"
          className="d-block link-body-emphasis text-decoration-none dropdown-toggle"
          data-bs-toggle="dropdown"
          aria-expanded="false"
        >
          <img
            src="images/loggedIn.jpg"
            alt="mdo"
            width="32"
            height="32"
            className="rounded-circle"
          />
        </a>
        <ul className={menuClass}>
          {/* <li>
            <a className="dropdown-item" href="#">
              New project...
            </a>
          </li>
          <li>
            <a className="dropdown-item" href="#">
              Settings
            </a>
          </li> */}
          <li>
            <a className="dropdown-item" href="#">
              Profile
            </a>
          </li>
          <li>
            <hr className="dropdown-divider" />
          </li>
          <li>
            <a className="dropdown-item" href="#">
              Sign out
            </a>
          </li>
        </ul>
      </div>
    );
}

export default UserNav