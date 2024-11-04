import { render, screen } from '@testing-library/react'
//import userEvent from '@testing-library/user-event'
import { Index } from './Index'

describe('Simple working tes 2t', () => {

  test('the title is visible', () => {
    render(<Index />)
    expect(screen.getByText(/Discover Local, Support Local/i)).toBeInTheDocument()
  })

  // test('should increment count on click', async () => {
  //   render(<Index />)
  //   userEvent.click(screen.getByRole('button'))
  //   expect(await screen.findByText(/Find a Business/i)).toBeInTheDocument()
  // })

})
