import { render, screen } from "@testing-library/react"
import Hero from "./Hero"

test("checking hero component and testing title", ()=>{
    render(<Hero/>)
    const titleTag = screen.getByText("Discover Local, Support Local");
    expect(titleTag).toBeInTheDocument();
})