import { render, screen } from "@testing-library/react"
import Footer from "./Footer"

test("test footer newletter input", ()=>{
    render(<Footer />)
    const input = screen.getByRole("textbox");
    expect(input).toBeInTheDocument();
})