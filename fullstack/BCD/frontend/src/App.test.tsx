import { render, screen } from "@testing-library/react";
import App from "./App";
import { MemoryRouter } from "react-router-dom";

describe("app component", () => {
  test("In main component, checking header", () => {
    render(
      <MemoryRouter>
        <App />
      </MemoryRouter>
    )

    //const homeLink = screen.findByRole("textbox");
    //expect(homeLink).toBeInTheDocument();
  });
});
