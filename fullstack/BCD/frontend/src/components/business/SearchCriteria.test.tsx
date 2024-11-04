import { render, screen } from "@testing-library/react";
import SearchCriteria from "./SearchCriteria";
import { createMemoryRouter, RouterProvider } from "react-router-dom";
import { userEvent } from "@testing-library/user-event";
import { act } from "react";

const router = createMemoryRouter([
  {
    path: "/",
    element: <SearchCriteria />,
  },
]);

describe("test look and feel", () => {
  test("Elements UI existence", () => {
    render(<RouterProvider router={router} />);
    const btn = screen.getByRole("button");
    expect(btn).toBeInTheDocument();
  });
});

describe("test functionality", () => {
  let renderResult;

  beforeAll(() => {
    userEvent.setup();
    renderResult = render(<RouterProvider router={router} />);
  });

  test("checking click event from search button", async () => {
    const btn = screen.getByRole("button")
    await userEvent.click(btn);

    const input = screen.getByPlaceholderText("I'm looking for ...")
    expect(input).toHaveValue("local")
  });

  test("checking zip-code textbox", async ()=>{
    
    userEvent.setup();
    renderResult = render(<RouterProvider router={router} />);

    const input = screen.getByTestId("zip-code")
    expect(input).toBeInTheDocument();

    await act(async()=> {
        await userEvent.type(input, "Lahti")
    })    

    expect(input).toHaveValue("Lahti");
  })

});
