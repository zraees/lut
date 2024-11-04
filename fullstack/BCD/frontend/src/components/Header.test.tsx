import { render, screen } from "@testing-library/react";
import Header from "./Header";
import { MemoryRouter } from "react-router-dom";

test("check Home nav exist", () => {
  render(
    <MemoryRouter>
      <Header />
    </MemoryRouter>
  );
  const homeNav = screen.getByText("Home");
  expect(homeNav).toBeInTheDocument();
});
